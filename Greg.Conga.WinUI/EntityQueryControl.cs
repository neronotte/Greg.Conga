using Greg.Conga.Sdk;
using Greg.Conga.Sdk.Messages;
using Greg.Conga.WinUI.Model;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Greg.Conga.WinUI
{
	public partial class EntityQueryControl : DockContent
	{
		private readonly MetadataRepository metadataRepository;
		private readonly ICongaService service;
		
		public EntityQueryControl(MetadataRepository metadataRepository, ICongaService service)
		{
			InitializeComponent();

			this.TabText = "Query";
			this.Text = this.TabText;
			this.metadataRepository = metadataRepository;
			this.service = service;

			this.intellisensePanel1.ContainerControl = this;
			this.intellisensePanel1.TextControl = this.textBox1;
		}

		private string[] fields;
		public string[] Fields 
		{
			get => this.fields; 
			set {
				this.fields = value;
				this.intellisensePanel1.Fields = value;
			}
		}

		private void OnLoadEntityClick(object sender, System.EventArgs e)
		{
			try
			{
				var metadata = this.metadataRepository.GetMetadataForEntity(this.txtEntityName.Text);
				this.Fields = metadata.Fields.Select(x => x.Name).ToArray();
				this.txtEntityName.BackColor = ColorPalette.SuccessBackground;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void OnWhereKeyUp(object sender, KeyEventArgs e)
		{
			//if (this.Fields == null || this.Fields.Length == 0) return;
			
			this.flow.SuspendLayout();

			

			this.flow.Controls.Clear();
			var text = this.textBox1.Text;

			if (!GetWord(text, this.textBox1.SelectionStart, out int startIndex, out int length))
			{
				this.flow.ResumeLayout();
				return;
			}

			if (length < Properties.Settings.Default.NumberOfCharsToStartIntellisense)
			{
				this.flow.ResumeLayout();
				return;
			}

			var word = text.Substring(startIndex, length);

			var foundFields = this.Fields?
				.Where(x => x.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0)
				.Take(10)
				.ToArray() ?? Array.Empty<string>();

			foreach (var f in foundFields)
			{
				var l = new LinkLabel();
				l.Click += (s, e1) =>
				{
					this.textBox1.Text = text.Substring(0, startIndex) + f + text.Substring(startIndex + length);
				};
				l.Text = f;
				l.Margin = new Padding(0, 0, 20, 20);
				l.AutoSize = true;
				this.flow.Controls.Add(l);
			}
			this.flow.ResumeLayout();
		}

		private bool GetWord(string text, int selectionStart, out int startIndex, out int length)
		{
			startIndex = -1;
			length = -1;

			if (text == null) return false;
			if (selectionStart < 1) return false;

			const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_";

			char currentChar;
			startIndex = selectionStart;
			do
			{
				startIndex--;
				currentChar = text[startIndex];
			}
			while (validChars.Contains(currentChar) && startIndex > 0);

			if (!validChars.Contains(currentChar))
				startIndex++;

			if (selectionStart == text.Length)
			{
				length = text.Length - startIndex;
				return true;
			}

			int endIndex;
			length = 0;
			do
			{
				endIndex = startIndex + length;
				currentChar = text[endIndex];
				length++;
			}
			while (validChars.Contains(currentChar) && endIndex < text.Length-1);

			if (!validChars.Contains(currentChar))
				length--;

			return true;
		}

		private void OnEntityNameChanged(object sender, EventArgs e)
		{
			this.Fields = Array.Empty<string>();
			this.txtEntityName.BackColor = Color.White;
			try
			{
				var metadata = this.metadataRepository.GetMetadataForEntity(this.txtEntityName.Text);
				this.Fields = metadata.Fields.Select(x => x.Name).ToArray();
				this.txtEntityName.BackColor = ColorPalette.SuccessBackground;
				toolTip1.SetToolTip(this.txtEntityName, string.Empty);
			}
			catch (Exception ex)
			{
				toolTip1.SetToolTip(this.txtEntityName, ex.Message);

				this.txtEntityName.BackColor = ColorPalette.ErrorBackground;
			}
		}

		private void OnExecuteQueryClick(object sender, EventArgs e)
		{
			try
			{
				var query = $"SELECT Id FROM {this.txtEntityName.Text} WHERE {this.textBox1.Text}";

				var result = this.service.RetrieveMultiple(query).Records;

				this.resultList.SetObjects(result);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void OnGridButtonClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
		{
			var entity = e.Item.RowObject as DynamicEntity;
			RecordSelected?.Invoke(this, new RecordSelectedEventArgs(this.txtEntityName.Text, entity.Id));
		}


		public event EventHandler<RecordSelectedEventArgs> RecordSelected;
	}


	public class RecordSelectedEventArgs : EventArgs
	{
		public RecordSelectedEventArgs(string entityName, string id)
		{
			this.EntityName = entityName;
			this.Id = id;
		}

		public string EntityName { get; }
		public string Id { get; }
	}
}
