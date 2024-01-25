namespace WINE.WinApp
{
	partial class MemberInformationUpdate
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
			this.components = new System.ComponentModel.Container();
			this.OrderItem = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.label9 = new System.Windows.Forms.Label();
			this.textBoxCheckPW = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.textBoxPhone = new System.Windows.Forms.TextBox();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.textBoxEmail = new System.Windows.Forms.TextBox();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			this.buttonDelete = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.labelAccount = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			this.SuspendLayout();
			// 
			// OrderItem
			// 
			this.OrderItem.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.OrderItem.ForeColor = System.Drawing.Color.Maroon;
			this.OrderItem.Location = new System.Drawing.Point(265, 34);
			this.OrderItem.Name = "OrderItem";
			this.OrderItem.Size = new System.Drawing.Size(215, 50);
			this.OrderItem.TabIndex = 2;
			this.OrderItem.Text = "會員資料修改";
			this.OrderItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.CalendarFont = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold);
			this.dateTimePicker1.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.dateTimePicker1.Location = new System.Drawing.Point(331, 380);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(214, 33);
			this.dateTimePicker1.TabIndex = 78;
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold);
			this.label9.Location = new System.Drawing.Point(167, 264);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(158, 30);
			this.label9.TabIndex = 85;
			this.label9.Text = "確認密碼";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBoxCheckPW
			// 
			this.textBoxCheckPW.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.textBoxCheckPW.Location = new System.Drawing.Point(331, 263);
			this.textBoxCheckPW.MaxLength = 12;
			this.textBoxCheckPW.Name = "textBoxCheckPW";
			this.textBoxCheckPW.PasswordChar = '*';
			this.textBoxCheckPW.Size = new System.Drawing.Size(214, 33);
			this.textBoxCheckPW.TabIndex = 75;
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold);
			this.label7.Location = new System.Drawing.Point(167, 381);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(158, 30);
			this.label7.TabIndex = 84;
			this.label7.Text = "出生日期";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold);
			this.label4.Location = new System.Drawing.Point(167, 342);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(158, 30);
			this.label4.TabIndex = 83;
			this.label4.Text = "電        話";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label5.Location = new System.Drawing.Point(167, 184);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(158, 30);
			this.label5.TabIndex = 82;
			this.label5.Text = "姓        名";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBoxPhone
			// 
			this.textBoxPhone.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.textBoxPhone.Location = new System.Drawing.Point(331, 341);
			this.textBoxPhone.Name = "textBoxPhone";
			this.textBoxPhone.Size = new System.Drawing.Size(214, 33);
			this.textBoxPhone.TabIndex = 77;
			// 
			// textBoxName
			// 
			this.textBoxName.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.textBoxName.Location = new System.Drawing.Point(331, 183);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(214, 33);
			this.textBoxName.TabIndex = 72;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold);
			this.label2.Location = new System.Drawing.Point(167, 223);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(158, 30);
			this.label2.TabIndex = 81;
			this.label2.Text = "密        碼";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold);
			this.label6.Location = new System.Drawing.Point(167, 142);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(158, 30);
			this.label6.TabIndex = 79;
			this.label6.Text = "帳        號";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(167, 303);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(158, 30);
			this.label1.TabIndex = 80;
			this.label1.Text = "E m a i l";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.textBoxPassword.Location = new System.Drawing.Point(331, 222);
			this.textBoxPassword.MaxLength = 12;
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.PasswordChar = '*';
			this.textBoxPassword.Size = new System.Drawing.Size(214, 33);
			this.textBoxPassword.TabIndex = 74;
			// 
			// textBoxEmail
			// 
			this.textBoxEmail.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.textBoxEmail.Location = new System.Drawing.Point(331, 302);
			this.textBoxEmail.Name = "textBoxEmail";
			this.textBoxEmail.Size = new System.Drawing.Size(214, 33);
			this.textBoxEmail.TabIndex = 76;
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// buttonDelete
			// 
			this.buttonDelete.BackColor = System.Drawing.Color.AntiqueWhite;
			this.buttonDelete.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
			this.buttonDelete.FlatAppearance.BorderSize = 0;
			this.buttonDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RosyBrown;
			this.buttonDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RosyBrown;
			this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonDelete.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.buttonDelete.ForeColor = System.Drawing.Color.Maroon;
			this.buttonDelete.Location = new System.Drawing.Point(650, 12);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(107, 35);
			this.buttonDelete.TabIndex = 88;
			this.buttonDelete.Text = "註銷帳號";
			this.buttonDelete.UseVisualStyleBackColor = false;
			this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.BackColor = System.Drawing.Color.AntiqueWhite;
			this.buttonSave.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
			this.buttonSave.FlatAppearance.BorderSize = 0;
			this.buttonSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RosyBrown;
			this.buttonSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RosyBrown;
			this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonSave.Font = new System.Drawing.Font("微軟正黑體", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.buttonSave.ForeColor = System.Drawing.Color.Maroon;
			this.buttonSave.Location = new System.Drawing.Point(322, 433);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(109, 71);
			this.buttonSave.TabIndex = 86;
			this.buttonSave.Text = "保存";
			this.buttonSave.UseVisualStyleBackColor = false;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// labelAccount
			// 
			this.labelAccount.AutoSize = true;
			this.labelAccount.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold);
			this.labelAccount.Location = new System.Drawing.Point(327, 145);
			this.labelAccount.Name = "labelAccount";
			this.labelAccount.Size = new System.Drawing.Size(65, 24);
			this.labelAccount.TabIndex = 89;
			this.labelAccount.Text = "label3";
			// 
			// MemberInformationUpdate
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.AntiqueWhite;
			this.ClientSize = new System.Drawing.Size(769, 535);
			this.Controls.Add(this.labelAccount);
			this.Controls.Add(this.buttonDelete);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.textBoxCheckPW);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBoxPhone);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxPassword);
			this.Controls.Add(this.textBoxEmail);
			this.Controls.Add(this.OrderItem);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "MemberInformationUpdate";
			this.Text = "MemberInformationUpdate";
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label OrderItem;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBoxCheckPW;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBoxPhone;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxPassword;
		private System.Windows.Forms.TextBox textBoxEmail;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private System.Windows.Forms.Button buttonDelete;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Label labelAccount;
	}
}