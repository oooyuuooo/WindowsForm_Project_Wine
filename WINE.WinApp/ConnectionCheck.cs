using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wine.Core;

namespace WINE.WinApp
{
	public partial class ConnectionCheck : Form
	{
		public ConnectionCheck()
		{
			InitializeComponent();
			this.buttonStringConnection.Click += ButtonStringConnection_Click;
		}

		private void ButtonStringConnection_Click(object sender, EventArgs e)
		{
			try
			{
				string connString = SqlDb.GetConnectionString("default");
				MessageBox.Show(connString);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
