namespace Greg.Conga.WinUI
{
	partial class IntellisensePanel
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
			this.lblPosition = new System.Windows.Forms.Label();
			this.flow = new System.Windows.Forms.FlowLayoutPanel();
			this.SuspendLayout();
			// 
			// lblPosition
			// 
			this.lblPosition.AutoSize = true;
			this.lblPosition.Location = new System.Drawing.Point(4, 4);
			this.lblPosition.Name = "lblPosition";
			this.lblPosition.Size = new System.Drawing.Size(35, 13);
			this.lblPosition.TabIndex = 0;
			this.lblPosition.Text = "label1";
			// 
			// flow
			// 
			this.flow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flow.BackColor = System.Drawing.Color.White;
			this.flow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flow.Location = new System.Drawing.Point(3, 4);
			this.flow.Name = "flow";
			this.flow.Size = new System.Drawing.Size(270, 93);
			this.flow.TabIndex = 1;
			// 
			// IntellisensePanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LightGray;
			this.Controls.Add(this.flow);
			this.Controls.Add(this.lblPosition);
			this.Name = "IntellisensePanel";
			this.Size = new System.Drawing.Size(276, 100);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblPosition;
		private System.Windows.Forms.FlowLayoutPanel flow;
	}
}
