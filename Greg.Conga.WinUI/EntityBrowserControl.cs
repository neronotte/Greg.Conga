using Greg.Conga.WinUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Greg.Conga.WinUI
{
	public partial class EntityBrowserControl : DockContent
	{
		private readonly MetadataRepository metadataRepository;
		private readonly DataRepository dataRepository;

		private EntityDescriptor currentEntity;

		public EntityBrowserControl(MetadataRepository metadataRepository, DataRepository dataRepository)
		{
			this.metadataRepository = metadataRepository;
			this.dataRepository = dataRepository;


			InitializeComponent();
			this.TabText = "Entity browser";
			this.Text = "Entity browser";

			this.tree.CanExpandGetter = x =>
			{
				var node = x as IHaveFields;
				if (node == null) return false;
				return node.Fields.Count > 0;
			};

			this.tree.ChildrenGetter = x =>
			{
				var node = x as IHaveFields;
				if (node == null) return null;
				return node.Fields;
			};

			this.Load += OnControlLoaded;
		}

		private void OnControlLoaded(object sender, EventArgs e)
		{
			if (!Properties.Settings.Default.PreloadEntity) return;

			var entityId = Properties.Settings.Default.LastEntityId;
			var entityName = Properties.Settings.Default.LastEntityName;

			if (string.IsNullOrWhiteSpace(entityId)) return;
			if (string.IsNullOrWhiteSpace(entityName)) return;


			var metadata = this.metadataRepository.GetMetadataForEntity(entityName);
			var fields = metadata.Fields.Select(x => x.Name).ToArray();
			var data = this.dataRepository.Get(entityId, metadata.Name, fields);
			var entityDescriptor = EntityDescriptor.FromDescribeResponse(metadata, data);
			this.tree.SetObjects(entityDescriptor.Fields);
			this.currentEntity = entityDescriptor;
		}

		public void Search(string id, string entityName)
		{
			try
			{
				var metadata = this.metadataRepository.GetMetadataForEntity(entityName);
				var fields = metadata.Fields.Select(x => x.Name).ToArray();
				var data = this.dataRepository.Get(id, metadata.Name, fields);
				var entityDescriptor = EntityDescriptor.FromDescribeResponse(metadata, data);
				this.tree.SetObjects(entityDescriptor.Fields);
				this.currentEntity = entityDescriptor;

				this.TabText = $"{metadata.Name}: {id}";

				Properties.Settings.Default.LastEntityId = id;
				Properties.Settings.Default.LastEntityName = entityName;
				Properties.Settings.Default.Save();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			this.SearchCompleted?.Invoke(this, EventArgs.Empty);
		}


		public event EventHandler SearchCompleted;


		private void OnNodeExpanding(object sender, BrightIdeasSoftware.TreeBranchExpandingEventArgs e)
		{
			var field = e.Model as FieldDescriptorReference;
			if (field == null) return;
			if (field.Fields.Count == 0) return;
			if (field.Fields.Count > 1) return;
			if (field.Fields[0] != FieldDescriptorFake.Instance) return;

			if (field.ReferenceTo == null || field.ReferenceTo.Length == 0) return;
			if (field.Value == null)
			{
				field.Fields.Clear();
				e.Canceled = true;
				return;
			}
			if (field.ReferenceTo.Length > 1)
			{
				field.Fields.Clear();
				field.Fields.Add(new FieldDescriptorError("Non so dove guardare, punto a più tipi di dati..."));
				return;
			}


			var metadata = this.metadataRepository.GetMetadataForEntity(field.ReferenceTo[0]);
			var fields = metadata.Fields.Select(x => x.Name).ToArray();
			var data = this.dataRepository.Get(field.Value.ToString(), metadata.Name, fields);
			var entityDescriptor = EntityDescriptor.FromDescribeResponse(metadata, data);

			field.Fields.Clear();
			field.Fields.AddRange(entityDescriptor.Fields);
			foreach (var field1 in entityDescriptor.Fields)
			{
				field1.Parent = field;
			}

		}

		private void OnItemSelected(object sender, EventArgs e)
		{
			if (this.tree.SelectedItem == null) return;

			var currentItem = this.tree.SelectedItem?.RowObject as IHaveId;
			if (currentItem == null) return;


			this.Path = currentItem.GetPath();
			this.PathChanged?.Invoke(this, EventArgs.Empty);
		}

		public string Path { get; private set; }

		public object SelectedRow { get => this.tree.SelectedItem?.RowObject; }

		public event EventHandler PathChanged;

		private void OnSearchKeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode != Keys.Enter) return;

			var text = ((ToolStripTextBox)sender).Text;

			var model = this.Find(text);
			this.tree.SelectObject(model, true);
			this.tree.EnsureModelVisible(model);
			this.tree.Focus();

			e.Handled = true;
		}

		private FieldDescriptor Find(string text, IReadOnlyCollection<FieldDescriptor> fieldCollection = null)
		{
			if (fieldCollection == null) fieldCollection = this.currentEntity.Fields;

			foreach (var field in fieldCollection)
			{
				if (field.Id.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0)
					return field;

				if (field.Fields.Count > 1)
				{
					var result = Find(text, field.Fields);
					if (result != null)
						return result;
				}

				if (field.Fields.Count == 1 && field.Fields[0] != FieldDescriptorFake.Instance && !(field.Fields[0] is FieldDescriptorError))
				{
					var result = Find(text, field.Fields);
					if (result != null)
						return result;
				}
			}

			return null;
		}
	}
}
