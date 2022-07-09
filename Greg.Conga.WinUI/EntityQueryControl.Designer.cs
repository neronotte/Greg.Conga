namespace Greg.Conga.WinUI
{
	partial class EntityQueryControl
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnExecuteQuery = new System.Windows.Forms.Button();
			this.flow = new System.Windows.Forms.FlowLayoutPanel();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.txtEntityName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.resultList = new BrightIdeasSoftware.ObjectListView();
			this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.intellisensePanel1 = new Greg.Conga.WinUI.IntellisensePanel();
			this.lblPosition = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.resultList)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.btnExecuteQuery);
			this.groupBox1.Controls.Add(this.flow);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.txtEntityName);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(13, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1051, 242);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Search criteria";
			// 
			// btnExecuteQuery
			// 
			this.btnExecuteQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExecuteQuery.Location = new System.Drawing.Point(907, 197);
			this.btnExecuteQuery.Name = "btnExecuteQuery";
			this.btnExecuteQuery.Size = new System.Drawing.Size(138, 39);
			this.btnExecuteQuery.TabIndex = 7;
			this.btnExecuteQuery.Text = "Execute query";
			this.btnExecuteQuery.UseVisualStyleBackColor = true;
			this.btnExecuteQuery.Click += new System.EventHandler(this.OnExecuteQueryClick);
			// 
			// flow
			// 
			this.flow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flow.Location = new System.Drawing.Point(79, 154);
			this.flow.Name = "flow";
			this.flow.Size = new System.Drawing.Size(966, 26);
			this.flow.TabIndex = 6;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 158);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(68, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Suggestions:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 57);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(42, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Where:";
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.textBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
			this.textBox1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(79, 54);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(966, 94);
			this.textBox1.TabIndex = 3;
			this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnWhereKeyUp);
			// 
			// txtEntityName
			// 
			this.txtEntityName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtEntityName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.txtEntityName.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtEntityName.Location = new System.Drawing.Point(79, 28);
			this.txtEntityName.Name = "txtEntityName";
			this.txtEntityName.Size = new System.Drawing.Size(966, 20);
			this.txtEntityName.TabIndex = 1;
			this.txtEntityName.TextChanged += new System.EventHandler(this.OnEntityNameChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(36, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Entity:";
			// 
			// resultList
			// 
			this.resultList.AllColumns.Add(this.olvColumn1);
			this.resultList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.resultList.CellEditUseWholeCell = false;
			this.resultList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1});
			this.resultList.Cursor = System.Windows.Forms.Cursors.Default;
			this.resultList.HideSelection = false;
			this.resultList.Location = new System.Drawing.Point(13, 262);
			this.resultList.Name = "resultList";
			this.resultList.ShowGroups = false;
			this.resultList.Size = new System.Drawing.Size(1051, 341);
			this.resultList.TabIndex = 1;
			this.resultList.UseCompatibleStateImageBehavior = false;
			this.resultList.View = System.Windows.Forms.View.Details;
			this.resultList.ButtonClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.OnGridButtonClick);
			// 
			// olvColumn1
			// 
			this.olvColumn1.AspectName = "Id";
			this.olvColumn1.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
			this.olvColumn1.IsButton = true;
			this.olvColumn1.Text = "ID";
			this.olvColumn1.Width = 200;
			// 
			// intellisensePanel1
			// 
			this.intellisensePanel1.BackColor = System.Drawing.Color.Red;
			this.intellisensePanel1.Location = new System.Drawing.Point(335, 351);
			this.intellisensePanel1.Name = "intellisensePanel1";
			this.intellisensePanel1.Size = new System.Drawing.Size(276, 100);
			this.intellisensePanel1.TabIndex = 2;
			// 
			// lblPosition
			// 
			this.lblPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblPosition.AutoSize = true;
			this.lblPosition.Location = new System.Drawing.Point(13, 619);
			this.lblPosition.Name = "lblPosition";
			this.lblPosition.Size = new System.Drawing.Size(35, 13);
			this.lblPosition.TabIndex = 3;
			this.lblPosition.Text = "label4";
			// 
			// EntityQueryControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1076, 644);
			this.Controls.Add(this.lblPosition);
			this.Controls.Add(this.intellisensePanel1);
			this.Controls.Add(this.resultList);
			this.Controls.Add(this.groupBox1);
			this.Name = "EntityQueryControl";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.resultList)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtEntityName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.FlowLayoutPanel flow;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button btnExecuteQuery;
		private BrightIdeasSoftware.ObjectListView resultList;
		private BrightIdeasSoftware.OLVColumn olvColumn1;
		private IntellisensePanel intellisensePanel1;
		private System.Windows.Forms.Label lblPosition;
	}
}
