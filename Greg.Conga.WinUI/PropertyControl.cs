using WeifenLuo.WinFormsUI.Docking;

namespace Greg.Conga.WinUI
{
	public partial class PropertyControl : DockContent
	{
		public PropertyControl()
		{
			InitializeComponent();
			this.TabText = "Properties";
			this.Text = this.TabText;
		}


		public string Label
		{
			get => this.tlblName.Text;
			set => this.tlblName.Text = value;
		}
		public object SelectedObject
		{
			get => this.propertyGrid.SelectedObject;
			set => this.propertyGrid.SelectedObject = value;
		}
	}
}
