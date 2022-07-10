using Greg.Conga.Sdk;
using Greg.Conga.WinUI.Model;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Greg.Conga.WinUI
{
	public partial class MainForm : Form
	{
		private readonly EntityBrowserControl entityBrowserControl;
		private readonly EntityQueryControl entityQueryControl;
		private readonly PropertyControl propertyControl;

		public MainForm()
		{
			if (Debugger.IsAttached && Screen.AllScreens.Length == 3)
			{
				// Get handle to active window
				IntPtr windowHandle = this.Handle;

				// get position for second monitor  
				var secondMonitor = Screen.AllScreens[2].WorkingArea;

				// move application window to the second monitor
				Program.SetWindowPos(windowHandle, 0, secondMonitor.Left, secondMonitor.Top, secondMonitor.Width, secondMonitor.Height, 0);
			}

			InitializeComponent();

			var congaService = GetCongaService();
			var metadataRepository = new MetadataRepository(congaService);
			var dataRepository = new DataRepository(congaService);

			this.dockPanel1.Theme = new VS2015BlueTheme();

			this.entityBrowserControl = new EntityBrowserControl(metadataRepository, dataRepository);
			this.entityBrowserControl.Show(this.dockPanel1, DockState.Document);

			var editorView = new EditorView();
			editorView.Show(this.dockPanel1, DockState.Document);


			this.entityQueryControl = new EntityQueryControl(metadataRepository, congaService);
			this.entityQueryControl.Show(this.dockPanel1, DockState.DockLeft);


			this.propertyControl = new PropertyControl();
			this.propertyControl.Show(this.dockPanel1, DockState.DockRight);


			this.entityBrowserControl.SearchCompleted += this.OnEntityBrowserControlSearchCompleted;
			this.entityBrowserControl.PathChanged += this.OnEntityBrowserControlPathChanged;

			this.entityQueryControl.RecordSelected += this.OnEntityQueryControlRecordSelected;

			this.tRecordId.Text = Properties.Settings.Default.LastEntityId;
			this.tRecordEntityName.Text = Properties.Settings.Default.LastEntityName;
		}

		public static ICongaService GetCongaService()
		{
			var endpoint = ConnectionSettings.Default.Endpoint;
			var credentials = ConnectionSettings.Default.Credentials;

			var congaService = new CongaService(endpoint);
			congaService.Authenticate(credentials);
			return congaService;
		}



		private void OnSearchClick(object sender, System.EventArgs e)
		{
			this.tRecordEntityName.Enabled = false;
			this.tRecordId.Enabled = false;

			this.entityBrowserControl.Search(this.tRecordId.Text, this.tRecordEntityName.Text);
		}

		private void OnEntityQueryControlRecordSelected(object sender, RecordSelectedEventArgs e)
		{
			this.tRecordEntityName.Enabled = false;
			this.tRecordId.Enabled = false;

			this.tRecordEntityName.Text = e.EntityName;
			this.tRecordId.Text = e.Id;

			this.entityBrowserControl.Search(e.Id, e.EntityName);
			this.entityBrowserControl.Show();
		}

		private void OnEntityBrowserControlSearchCompleted(object sender, System.EventArgs e)
		{
			this.tRecordEntityName.Enabled = true;
			this.tRecordId.Enabled = true;
		}

		private void OnEntityBrowserControlPathChanged(object sender, System.EventArgs e)
		{
			this.sPath.Text = this.entityBrowserControl.Path;

			this.propertyControl.Label = this.sPath.Text;
			this.propertyControl.SelectedObject = this.entityBrowserControl.SelectedRow;
		}

		private void OnMenuExitClick(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void OnConnectToClick(object sender, System.EventArgs e)
		{
			using(var view = new ConnectionSettingsView())
			{
				view.ShowDialog(this);
			}
		}
	}
}
