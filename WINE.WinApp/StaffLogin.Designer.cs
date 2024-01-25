namespace WINE.WinApp
{
	partial class StaffLogin
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
			this.LoginBotton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxAccount = new System.Windows.Forms.TextBox();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// LoginBotton
			// 
			this.LoginBotton.BackColor = System.Drawing.Color.RosyBrown;
			this.LoginBotton.Font = new System.Drawing.Font("Source Code Pro", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LoginBotton.ForeColor = System.Drawing.Color.White;
			this.LoginBotton.Location = new System.Drawing.Point(132, 215);
			this.LoginBotton.Name = "LoginBotton";
			this.LoginBotton.Size = new System.Drawing.Size(109, 43);
			this.LoginBotton.TabIndex = 2;
			this.LoginBotton.Text = "Login";
			this.LoginBotton.UseVisualStyleBackColor = false;
			this.LoginBotton.Click += new System.EventHandler(this.LoginBotton_Click);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold);
			this.label2.Location = new System.Drawing.Point(59, 169);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 23);
			this.label2.TabIndex = 55;
			this.label2.Text = "密碼";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(60, 115);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 23);
			this.label1.TabIndex = 54;
			this.label1.Text = "帳號";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.label4.Location = new System.Drawing.Point(108, 51);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(133, 37);
			this.label4.TabIndex = 56;
			this.label4.Text = "員工登入";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBoxAccount
			// 
			this.textBoxAccount.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.textBoxAccount.Location = new System.Drawing.Point(129, 113);
			this.textBoxAccount.Name = "textBoxAccount";
			this.textBoxAccount.Size = new System.Drawing.Size(138, 27);
			this.textBoxAccount.TabIndex = 0;
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold);
			this.textBoxPassword.Location = new System.Drawing.Point(128, 167);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.PasswordChar = '*';
			this.textBoxPassword.Size = new System.Drawing.Size(138, 27);
			this.textBoxPassword.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.BackgroundImage = global::WINE.WinApp.Properties.Resources.arrowLeft;
			this.button1.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RosyBrown;
			this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RosyBrown;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.ForeColor = System.Drawing.Color.AntiqueWhite;
			this.button1.Location = new System.Drawing.Point(12, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(52, 50);
			this.button1.TabIndex = 3;
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// StaffLogin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.AntiqueWhite;
			this.ClientSize = new System.Drawing.Size(361, 307);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBoxPassword);
			this.Controls.Add(this.textBoxAccount);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.LoginBotton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "StaffLogin";
			this.Text = "員工登入";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button LoginBotton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBoxAccount;
		private System.Windows.Forms.TextBox textBoxPassword;
		private System.Windows.Forms.Button button1;
	}
}