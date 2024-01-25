namespace WINE.WinApp
{
	partial class MemberOrderItem
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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.button1 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.labelState = new System.Windows.Forms.Label();
			this.buttonCheck = new System.Windows.Forms.Button();
			this.buttonDone = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label1.ForeColor = System.Drawing.Color.Maroon;
			this.label1.Location = new System.Drawing.Point(226, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(268, 50);
			this.label1.TabIndex = 78;
			this.label1.Text = "會員訂購明細";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.BackgroundColor = System.Drawing.Color.SeaShell;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
			this.dataGridView1.GridColor = System.Drawing.Color.RosyBrown;
			this.dataGridView1.Location = new System.Drawing.Point(30, 136);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(647, 312);
			this.dataGridView1.TabIndex = 79;
			// 
			// Column1
			// 
			this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Column1.DataPropertyName = "Name";
			this.Column1.HeaderText = "產品";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			// 
			// Column2
			// 
			this.Column2.DataPropertyName = "ProductsPrice";
			this.Column2.HeaderText = "價格";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			// 
			// Column3
			// 
			this.Column3.DataPropertyName = "ProductCount";
			this.Column3.HeaderText = "數量";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			// 
			// Column4
			// 
			this.Column4.DataPropertyName = "TotalMoney";
			this.Column4.HeaderText = "總金額";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
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
			this.button1.Location = new System.Drawing.Point(30, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(52, 50);
			this.button1.TabIndex = 80;
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label2.Location = new System.Drawing.Point(25, 95);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(101, 26);
			this.label2.TabIndex = 82;
			this.label2.Text = "處理狀態:";
			// 
			// labelState
			// 
			this.labelState.AutoSize = true;
			this.labelState.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labelState.Location = new System.Drawing.Point(122, 95);
			this.labelState.Name = "labelState";
			this.labelState.Size = new System.Drawing.Size(106, 26);
			this.labelState.TabIndex = 82;
			this.labelState.Text = "處理狀態: ";
			// 
			// buttonCheck
			// 
			this.buttonCheck.BackColor = System.Drawing.Color.AntiqueWhite;
			this.buttonCheck.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
			this.buttonCheck.FlatAppearance.BorderSize = 0;
			this.buttonCheck.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RosyBrown;
			this.buttonCheck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RosyBrown;
			this.buttonCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCheck.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.buttonCheck.ForeColor = System.Drawing.Color.Maroon;
			this.buttonCheck.Location = new System.Drawing.Point(183, 458);
			this.buttonCheck.Name = "buttonCheck";
			this.buttonCheck.Size = new System.Drawing.Size(95, 41);
			this.buttonCheck.TabIndex = 83;
			this.buttonCheck.Text = "已確認";
			this.buttonCheck.UseVisualStyleBackColor = false;
			this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
			// 
			// buttonDone
			// 
			this.buttonDone.BackColor = System.Drawing.Color.AntiqueWhite;
			this.buttonDone.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
			this.buttonDone.FlatAppearance.BorderSize = 0;
			this.buttonDone.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RosyBrown;
			this.buttonDone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RosyBrown;
			this.buttonDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonDone.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.buttonDone.ForeColor = System.Drawing.Color.Maroon;
			this.buttonDone.Location = new System.Drawing.Point(440, 458);
			this.buttonDone.Name = "buttonDone";
			this.buttonDone.Size = new System.Drawing.Size(95, 41);
			this.buttonDone.TabIndex = 83;
			this.buttonDone.Text = "已完成";
			this.buttonDone.UseVisualStyleBackColor = false;
			this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
			// 
			// MemberOrderItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.AntiqueWhite;
			this.ClientSize = new System.Drawing.Size(703, 511);
			this.Controls.Add(this.buttonDone);
			this.Controls.Add(this.buttonCheck);
			this.Controls.Add(this.labelState);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.label1);
			this.MaximumSize = new System.Drawing.Size(719, 550);
			this.MinimumSize = new System.Drawing.Size(719, 550);
			this.Name = "MemberOrderItem";
			this.Text = "MemberOrderItem";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label labelState;
		private System.Windows.Forms.Button buttonCheck;
		private System.Windows.Forms.Button buttonDone;
	}
}