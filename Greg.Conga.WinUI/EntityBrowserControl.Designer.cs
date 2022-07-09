namespace Greg.Conga.WinUI
{
	partial class EntityBrowserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.tree = new BrightIdeasSoftware.TreeListView();
			this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
			((System.ComponentModel.ISupportInitialize)(this.tree)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tree
			// 
			this.tree.AllColumns.Add(this.olvColumn1);
			this.tree.AllColumns.Add(this.olvColumn2);
			this.tree.AllColumns.Add(this.olvColumn3);
			this.tree.AllColumns.Add(this.olvColumn4);
			this.tree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tree.CellEditUseWholeCell = false;
			this.tree.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3,
            this.olvColumn4});
			this.tree.Cursor = System.Windows.Forms.Cursors.Default;
			this.tree.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tree.GridLines = true;
			this.tree.HideSelection = false;
			this.tree.Location = new System.Drawing.Point(0, 28);
			this.tree.MultiSelect = false;
			this.tree.Name = "tree";
			this.tree.ShowGroups = false;
			this.tree.Size = new System.Drawing.Size(860, 418);
			this.tree.TabIndex = 0;
			this.tree.UseCompatibleStateImageBehavior = false;
			this.tree.View = System.Windows.Forms.View.Details;
			this.tree.VirtualMode = true;
			this.tree.Expanding += new System.EventHandler<BrightIdeasSoftware.TreeBranchExpandingEventArgs>(this.OnNodeExpanding);
			this.tree.SelectedIndexChanged += new System.EventHandler(this.OnItemSelected);
			// 
			// olvColumn1
			// 
			this.olvColumn1.AspectName = "Id";
			this.olvColumn1.Text = "Property";
			this.olvColumn1.Width = 300;
			// 
			// olvColumn2
			// 
			this.olvColumn2.AspectName = "Value";
			this.olvColumn2.Text = "Value";
			this.olvColumn2.Width = 200;
			// 
			// olvColumn3
			// 
			this.olvColumn3.AspectName = "TypeName";
			this.olvColumn3.Text = "Type";
			this.olvColumn3.Width = 100;
			// 
			// olvColumn4
			// 
			this.olvColumn4.AspectName = "AdditionalData";
			this.olvColumn4.FillsFreeSpace = true;
			this.olvColumn4.Text = "Additional data";
			this.olvColumn4.Width = 200;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtSearch});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(860, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// txtSearch
			// 
			this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(200, 25);
			this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnSearchKeyUp);
			// 
			// EntityBrowserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(860, 446);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.tree);
			this.Name = "EntityBrowserControl";
			((System.ComponentModel.ISupportInitialize)(this.tree)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private BrightIdeasSoftware.TreeListView tree;
		private BrightIdeasSoftware.OLVColumn olvColumn1;
		private BrightIdeasSoftware.OLVColumn olvColumn2;
		private BrightIdeasSoftware.OLVColumn olvColumn3;
		private BrightIdeasSoftware.OLVColumn olvColumn4;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripTextBox txtSearch;
	}
}
