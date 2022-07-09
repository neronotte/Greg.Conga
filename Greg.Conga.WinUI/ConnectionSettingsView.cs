using Greg.Conga.WinUI.Model;
using System;
using System.Windows.Forms;

namespace Greg.Conga.WinUI
{
	public partial class ConnectionSettingsView : Form
	{
		public ConnectionSettingsView()
		{
			InitializeComponent();

			this.btnAddEnvironment.Enabled = false;
			this.btnRemoveEnvironment.Enabled = false;
			this.txtEnvironmentName.Enabled = false;

			this.lstEnvironments.Items.Add(ConnectionSettings.Default);
			this.lstEnvironments.SelectedIndex = 0;
		}

		private void OnConnectionSettingsSelected(object sender, EventArgs e)
		{
			var settings = this.lstEnvironments.SelectedItem as ConnectionSettings;

			this.textBox1.Text = settings?.Credentials.Username;
			this.textBox2.Text = settings?.Credentials.Password;

			this.textBox3.Text = settings?.Endpoint.AuthenticationEndpoint;
			this.textBox4.Text = settings?.Endpoint.AuthenticationClientId;
			this.textBox5.Text = settings?.Endpoint.AuthenticationSecret;
			this.textBox6.Text = settings?.Endpoint.RestApiRootEndpoint;
			this.textBox7.Text = settings?.Endpoint.SalesforceApiRootEndpoint;
			this.textBox8.Text = settings?.Endpoint.Storefront;

			this.btnRemoveEnvironment.Enabled = (settings != null && !settings.IsDefault);
			this.textBox1.Enabled = (settings != null && !settings.IsDefault);
			this.textBox2.Enabled = (settings != null && !settings.IsDefault);
			this.textBox3.Enabled = (settings != null && !settings.IsDefault);
			this.textBox4.Enabled = (settings != null && !settings.IsDefault);
			this.textBox5.Enabled = (settings != null && !settings.IsDefault);
			this.textBox6.Enabled = (settings != null && !settings.IsDefault);
			this.textBox7.Enabled = (settings != null && !settings.IsDefault);
			this.textBox8.Enabled = (settings != null && !settings.IsDefault);
		}

		private void OnEnvironmentNameChanged(object sender, EventArgs e)
		{
			this.btnAddEnvironment.Enabled = this.txtEnvironmentName.Text.Length > 0;
		}

		private void OnAddEnvironmentClick(object sender, EventArgs e)
		{

		}

		private void OnRemoveEnvironmentClick(object sender, EventArgs e)
		{

		}

		private void OnOKClick(object sender, EventArgs e)
		{
			this.Close();
		}

		private void OnCancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
