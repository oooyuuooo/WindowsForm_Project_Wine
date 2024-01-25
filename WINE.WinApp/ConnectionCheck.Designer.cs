namespace WINE.WinApp
{
	partial class ConnectionCheck
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
			this.buttonStringConnection = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// buttonStringConnection
			// 
			this.buttonStringConnection.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.buttonStringConnection.Location = new System.Drawing.Point(67, 57);
			this.buttonStringConnection.Name = "buttonStringConnection";
			this.buttonStringConnection.Size = new System.Drawing.Size(210, 87);
			this.buttonStringConnection.TabIndex = 3;
			this.buttonStringConnection.Text = "取得連線";
			this.buttonStringConnection.UseVisualStyleBackColor = true;
			// 
			// ConnectionCheck
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(336, 192);
			this.Controls.Add(this.buttonStringConnection);
			this.Name = "ConnectionCheck";
			this.Text = "ConnectionCheck";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonStringConnection;
	}
}