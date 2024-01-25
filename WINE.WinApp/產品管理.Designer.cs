namespace WINE.WinApp
{
	partial class 產品管理
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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ButtonCreateOne = new System.Windows.Forms.Button();
			this.buttonCreateMany = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
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
            this.Column5,
            this.Column3,
            this.Column4,
            this.Column6});
			this.dataGridView1.GridColor = System.Drawing.Color.RosyBrown;
			this.dataGridView1.Location = new System.Drawing.Point(17, 25);
			this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersWidth = 62;
			this.dataGridView1.RowTemplate.Height = 31;
			this.dataGridView1.Size = new System.Drawing.Size(736, 407);
			this.dataGridView1.TabIndex = 2;
			// 
			// Column1
			// 
			this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Column1.DataPropertyName = "Name";
			this.Column1.HeaderText = "產品";
			this.Column1.MinimumWidth = 8;
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			// 
			// Column2
			// 
			this.Column2.DataPropertyName = "Year";
			this.Column2.HeaderText = "年份";
			this.Column2.MinimumWidth = 8;
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Width = 75;
			// 
			// Column5
			// 
			this.Column5.DataPropertyName = "Category";
			this.Column5.HeaderText = "類別";
			this.Column5.MinimumWidth = 8;
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			this.Column5.Width = 75;
			// 
			// Column3
			// 
			this.Column3.DataPropertyName = "Origin";
			this.Column3.HeaderText = "產地";
			this.Column3.MinimumWidth = 8;
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.Width = 75;
			// 
			// Column4
			// 
			this.Column4.DataPropertyName = "Capacity";
			this.Column4.HeaderText = "容量";
			this.Column4.MinimumWidth = 8;
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.Column4.Width = 75;
			// 
			// Column6
			// 
			this.Column6.DataPropertyName = "Taste";
			this.Column6.HeaderText = "口感";
			this.Column6.MinimumWidth = 8;
			this.Column6.Name = "Column6";
			this.Column6.ReadOnly = true;
			this.Column6.Width = 75;
			// 
			// ButtonCreateOne
			// 
			this.ButtonCreateOne.BackColor = System.Drawing.Color.AntiqueWhite;
			this.ButtonCreateOne.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
			this.ButtonCreateOne.FlatAppearance.BorderSize = 0;
			this.ButtonCreateOne.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RosyBrown;
			this.ButtonCreateOne.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RosyBrown;
			this.ButtonCreateOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonCreateOne.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.ButtonCreateOne.ForeColor = System.Drawing.Color.Maroon;
			this.ButtonCreateOne.Location = new System.Drawing.Point(47, 458);
			this.ButtonCreateOne.Name = "ButtonCreateOne";
			this.ButtonCreateOne.Size = new System.Drawing.Size(267, 41);
			this.ButtonCreateOne.TabIndex = 30;
			this.ButtonCreateOne.Text = "添加一筆商品";
			this.ButtonCreateOne.UseVisualStyleBackColor = false;
			// 
			// buttonCreateMany
			// 
			this.buttonCreateMany.BackColor = System.Drawing.Color.AntiqueWhite;
			this.buttonCreateMany.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
			this.buttonCreateMany.FlatAppearance.BorderSize = 0;
			this.buttonCreateMany.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RosyBrown;
			this.buttonCreateMany.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RosyBrown;
			this.buttonCreateMany.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCreateMany.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.buttonCreateMany.ForeColor = System.Drawing.Color.Maroon;
			this.buttonCreateMany.Location = new System.Drawing.Point(420, 458);
			this.buttonCreateMany.Name = "buttonCreateMany";
			this.buttonCreateMany.Size = new System.Drawing.Size(267, 41);
			this.buttonCreateMany.TabIndex = 30;
			this.buttonCreateMany.Text = "添加多筆商品";
			this.buttonCreateMany.UseVisualStyleBackColor = false;
			// 
			// 產品管理
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.AntiqueWhite;
			this.ClientSize = new System.Drawing.Size(770, 535);
			this.Controls.Add(this.buttonCreateMany);
			this.Controls.Add(this.ButtonCreateOne);
			this.Controls.Add(this.dataGridView1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "產品管理";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
		private System.Windows.Forms.Button ButtonCreateOne;
		private System.Windows.Forms.Button buttonCreateMany;
	}
}