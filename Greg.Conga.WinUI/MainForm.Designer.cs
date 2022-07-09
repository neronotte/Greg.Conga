namespace Greg.Conga.WinUI
{
	partial class MainForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.tRecordEntityName = new System.Windows.Forms.ToolStripComboBox();
			this.tRecordId = new System.Windows.Forms.ToolStripTextBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.sPath = new System.Windows.Forms.ToolStripStatusLabel();
			this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.connectToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.mExit = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tSearch = new System.Windows.Forms.ToolStripButton();
			this.menuStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1098, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// toolStrip1
			// 
			this.toolStrip1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tLabel1,
            this.tRecordEntityName,
            this.tRecordId,
            this.tSearch});
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(1098, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// tLabel1
			// 
			this.tLabel1.Name = "tLabel1";
			this.tLabel1.Size = new System.Drawing.Size(289, 22);
			this.tLabel1.Text = "Inserire il nome e l\'id del record da mostrare:";
			// 
			// tRecordEntityName
			// 
			this.tRecordEntityName.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tRecordEntityName.Items.AddRange(new object[] {
            "Apttus_Config2__ProductConfiguration__c",
            "Apttus_Config2__LineItem__c",
            "Apttus_Config2__ProductAttributeValue__c",
            "Apttus_Proposal__Proposal__c",
            "Apttus_Proposal__Proposal_Line_Item__c",
            "Apttus_QPConfig__ProposalProductAttributeValue__c",
            "Apttus_Config2__Order__c",
            "Apttus_Config2__OrderLineItem__c",
            "Apttus_Config2__OrderProductAttributeValue__c",
            "Apttus_Config2__AssetLineItem__c",
            "Apttus_Config2__AssetAttributeValue__c",
            "Apttus_Config2__AccountLocation__c",
            "egl_address__c",
            "Product2",
            "Account",
            "Contact"});
			this.tRecordEntityName.Name = "tRecordEntityName";
			this.tRecordEntityName.Size = new System.Drawing.Size(300, 25);
			// 
			// tRecordId
			// 
			this.tRecordId.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tRecordId.Name = "tRecordId";
			this.tRecordId.Size = new System.Drawing.Size(300, 25);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sPath});
			this.statusStrip1.Location = new System.Drawing.Point(0, 506);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1098, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// sPath
			// 
			this.sPath.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sPath.Name = "sPath";
			this.sPath.Size = new System.Drawing.Size(14, 17);
			this.sPath.Text = "-";
			// 
			// dockPanel1
			// 
			this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dockPanel1.Location = new System.Drawing.Point(0, 49);
			this.dockPanel1.Name = "dockPanel1";
			this.dockPanel1.Size = new System.Drawing.Size(1098, 457);
			this.dockPanel1.TabIndex = 3;
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToToolStripMenuItem,
            this.toolStripMenuItem2,
            this.mExit});
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
			this.toolStripMenuItem1.Text = "File";
			// 
			// connectToToolStripMenuItem
			// 
			this.connectToToolStripMenuItem.Name = "connectToToolStripMenuItem";
			this.connectToToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.connectToToolStripMenuItem.Text = "Connection info...";
			this.connectToToolStripMenuItem.Click += new System.EventHandler(this.OnConnectToClick);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(166, 6);
			// 
			// mExit
			// 
			this.mExit.Name = "mExit";
			this.mExit.Size = new System.Drawing.Size(169, 22);
			this.mExit.Text = "Exit";
			this.mExit.Click += new System.EventHandler(this.OnMenuExitClick);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// tSearch
			// 
			this.tSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tSearch.Image = global::Greg.Conga.WinUI.Properties.Resources.zoom;
			this.tSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tSearch.Name = "tSearch";
			this.tSearch.Size = new System.Drawing.Size(23, 22);
			this.tSearch.Text = "Search";
			this.tSearch.Click += new System.EventHandler(this.OnSearchClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1098, 528);
			this.Controls.Add(this.dockPanel1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "Greg\'s CONGA Workbench";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
		private System.Windows.Forms.ToolStripLabel tLabel1;
		private System.Windows.Forms.ToolStripComboBox tRecordEntityName;
		private System.Windows.Forms.ToolStripTextBox tRecordId;
		private System.Windows.Forms.ToolStripButton tSearch;
		private System.Windows.Forms.ToolStripStatusLabel sPath;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem connectToToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem mExit;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
	}
}

