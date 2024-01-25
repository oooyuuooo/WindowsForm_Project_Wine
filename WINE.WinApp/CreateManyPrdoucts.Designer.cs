namespace WINE.WinApp
{
	partial class CreateManyPrdoucts
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
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxFilePath = new System.Windows.Forms.TextBox();
			this.buttonChoose = new System.Windows.Forms.Button();
			this.buttonConfirm = new System.Windows.Forms.Button();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.buttonCancle = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label1.Location = new System.Drawing.Point(92, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(150, 35);
			this.label1.TabIndex = 0;
			this.label1.Text = "請選擇檔案";
			// 
			// textBoxFilePath
			// 
			this.textBoxFilePath.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.textBoxFilePath.Location = new System.Drawing.Point(32, 133);
			this.textBoxFilePath.Name = "textBoxFilePath";
			this.textBoxFilePath.Size = new System.Drawing.Size(281, 35);
			this.textBoxFilePath.TabIndex = 1;
			// 
			// buttonChoose
			// 
			this.buttonChoose.BackColor = System.Drawing.Color.AntiqueWhite;
			this.buttonChoose.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
			this.buttonChoose.FlatAppearance.BorderSize = 0;
			this.buttonChoose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RosyBrown;
			this.buttonChoose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RosyBrown;
			this.buttonChoose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonChoose.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.buttonChoose.ForeColor = System.Drawing.Color.Maroon;
			this.buttonChoose.Location = new System.Drawing.Point(120, 86);
			this.buttonChoose.Name = "buttonChoose";
			this.buttonChoose.Size = new System.Drawing.Size(95, 41);
			this.buttonChoose.TabIndex = 0;
			this.buttonChoose.Text = "選擇檔案";
			this.buttonChoose.UseVisualStyleBackColor = false;
			// 
			// buttonConfirm
			// 
			this.buttonConfirm.BackColor = System.Drawing.Color.AntiqueWhite;
			this.buttonConfirm.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
			this.buttonConfirm.FlatAppearance.BorderSize = 0;
			this.buttonConfirm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RosyBrown;
			this.buttonConfirm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RosyBrown;
			this.buttonConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonConfirm.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.buttonConfirm.ForeColor = System.Drawing.Color.Maroon;
			this.buttonConfirm.Location = new System.Drawing.Point(66, 174);
			this.buttonConfirm.Name = "buttonConfirm";
			this.buttonConfirm.Size = new System.Drawing.Size(95, 41);
			this.buttonConfirm.TabIndex = 2;
			this.buttonConfirm.Text = "確定";
			this.buttonConfirm.UseVisualStyleBackColor = false;
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog";
			// 
			// buttonCancle
			// 
			this.buttonCancle.BackColor = System.Drawing.Color.AntiqueWhite;
			this.buttonCancle.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
			this.buttonCancle.FlatAppearance.BorderSize = 0;
			this.buttonCancle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RosyBrown;
			this.buttonCancle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RosyBrown;
			this.buttonCancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancle.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.buttonCancle.ForeColor = System.Drawing.Color.Maroon;
			this.buttonCancle.Location = new System.Drawing.Point(181, 174);
			this.buttonCancle.Name = "buttonCancle";
			this.buttonCancle.Size = new System.Drawing.Size(95, 41);
			this.buttonCancle.TabIndex = 2;
			this.buttonCancle.Text = "取消";
			this.buttonCancle.UseVisualStyleBackColor = false;
			this.buttonCancle.Click += new System.EventHandler(this.buttonCancle_Click);
			// 
			// CreateManyPrdoucts
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.AntiqueWhite;
			this.ClientSize = new System.Drawing.Size(356, 267);
			this.Controls.Add(this.buttonCancle);
			this.Controls.Add(this.buttonConfirm);
			this.Controls.Add(this.buttonChoose);
			this.Controls.Add(this.textBoxFilePath);
			this.Controls.Add(this.label1);
			this.Name = "CreateManyPrdoucts";
			this.Text = "CreateManyPrdoucts";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxFilePath;
		private System.Windows.Forms.Button buttonChoose;
		private System.Windows.Forms.Button buttonConfirm;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.Button buttonCancle;
	}
}