namespace Greg.Conga.WinUI
{
	partial class ConnectionSettingsView
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionSettingsView));
			this.lstEnvironments = new System.Windows.Forms.ListBox();
			this.txtEnvironmentName = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnRemoveEnvironment = new System.Windows.Forms.Button();
			this.btnAddEnvironment = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lstEnvironments
			// 
			this.lstEnvironments.FormattingEnabled = true;
			this.lstEnvironments.Location = new System.Drawing.Point(12, 43);
			this.lstEnvironments.Name = "lstEnvironments";
			this.lstEnvironments.Size = new System.Drawing.Size(224, 329);
			this.lstEnvironments.TabIndex = 0;
			this.lstEnvironments.SelectedIndexChanged += new System.EventHandler(this.OnConnectionSettingsSelected);
			// 
			// txtEnvironmentName
			// 
			this.txtEnvironmentName.Location = new System.Drawing.Point(12, 12);
			this.txtEnvironmentName.Name = "txtEnvironmentName";
			this.txtEnvironmentName.Size = new System.Drawing.Size(153, 20);
			this.txtEnvironmentName.TabIndex = 1;
			this.txtEnvironmentName.TextChanged += new System.EventHandler(this.OnEnvironmentNameChanged);
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(255, 31);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(517, 20);
			this.textBox1.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(252, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Username:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(252, 61);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Password:";
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(255, 77);
			this.textBox2.Name = "textBox2";
			this.textBox2.PasswordChar = '*';
			this.textBox2.Size = new System.Drawing.Size(517, 20);
			this.textBox2.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(252, 153);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(121, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Authentication Client ID:";
			// 
			// textBox3
			// 
			this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox3.Location = new System.Drawing.Point(255, 169);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(517, 20);
			this.textBox3.TabIndex = 8;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(252, 107);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(123, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Authentication Endpoint:";
			// 
			// textBox4
			// 
			this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox4.Location = new System.Drawing.Point(255, 123);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(517, 20);
			this.textBox4.TabIndex = 6;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(252, 335);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 13);
			this.label5.TabIndex = 17;
			this.label5.Text = "Storefront:";
			// 
			// textBox5
			// 
			this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox5.Location = new System.Drawing.Point(255, 351);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(517, 20);
			this.textBox5.TabIndex = 16;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(252, 289);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(151, 13);
			this.label6.TabIndex = 15;
			this.label6.Text = "Salesforce API Root Endpoint:";
			// 
			// textBox6
			// 
			this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox6.Location = new System.Drawing.Point(255, 305);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(517, 20);
			this.textBox6.TabIndex = 14;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(252, 243);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(123, 13);
			this.label7.TabIndex = 13;
			this.label7.Text = "Rest API Root Endpoint:";
			// 
			// textBox7
			// 
			this.textBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox7.Location = new System.Drawing.Point(255, 259);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(517, 20);
			this.textBox7.TabIndex = 12;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(252, 197);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(112, 13);
			this.label8.TabIndex = 11;
			this.label8.Text = "Authentication Secret:";
			// 
			// textBox8
			// 
			this.textBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox8.Location = new System.Drawing.Point(255, 213);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(517, 20);
			this.textBox8.TabIndex = 10;
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.Location = new System.Drawing.Point(586, 385);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(90, 30);
			this.btnOk.TabIndex = 18;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.OnOKClick);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(682, 385);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(90, 30);
			this.btnCancel.TabIndex = 19;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.OnCancelClick);
			// 
			// btnRemoveEnvironment
			// 
			this.btnRemoveEnvironment.Image = global::Greg.Conga.WinUI.Properties.Resources.delete;
			this.btnRemoveEnvironment.Location = new System.Drawing.Point(207, 7);
			this.btnRemoveEnvironment.Name = "btnRemoveEnvironment";
			this.btnRemoveEnvironment.Size = new System.Drawing.Size(30, 30);
			this.btnRemoveEnvironment.TabIndex = 20;
			this.btnRemoveEnvironment.UseVisualStyleBackColor = true;
			this.btnRemoveEnvironment.Click += new System.EventHandler(this.OnRemoveEnvironmentClick);
			// 
			// btnAddEnvironment
			// 
			this.btnAddEnvironment.Image = global::Greg.Conga.WinUI.Properties.Resources.add;
			this.btnAddEnvironment.Location = new System.Drawing.Point(171, 7);
			this.btnAddEnvironment.Name = "btnAddEnvironment";
			this.btnAddEnvironment.Size = new System.Drawing.Size(30, 30);
			this.btnAddEnvironment.TabIndex = 21;
			this.btnAddEnvironment.UseVisualStyleBackColor = true;
			this.btnAddEnvironment.Click += new System.EventHandler(this.OnAddEnvironmentClick);
			// 
			// ConnectionSettingsView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 427);
			this.Controls.Add(this.btnAddEnvironment);
			this.Controls.Add(this.btnRemoveEnvironment);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textBox6);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.textBox7);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.textBox8);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.txtEnvironmentName);
			this.Controls.Add(this.lstEnvironments);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ConnectionSettingsView";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Connection settings";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox lstEnvironments;
		private System.Windows.Forms.TextBox txtEnvironmentName;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnRemoveEnvironment;
		private System.Windows.Forms.Button btnAddEnvironment;
	}
}