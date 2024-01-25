using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wine.Core.Model.Dto;
using Wine.Core.Model.Interfaces;
using Wine.Core.Model.Repositories;

namespace WINE.WinApp
{
	public partial class StaffLogin : Form
	{
		private string _account;
		private string _password;
		public StaffLogin()
		{
			InitializeComponent();
		}

		private void LoginBotton_Click(object sender, EventArgs e)
		{
			try
			{
				var service = GetStaffService();
				_account = textBoxAccount.Text;
				_password = textBoxPassword.Text;
				StaffDto staff = service.Get(_account,_password);
				staff.StaffAccount = textBoxAccount.Text;
				staff.StaffPassword = textBoxPassword.Text;
				MessageBox.Show("登入成功");

				var form = new 員工介面();
				this.Hide(); // 隱藏目前的視窗
				form.Owner = this;
				form.ShowDialog();
				this.Close(); // 在新視窗關閉後關閉目前的視窗
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}

		private IStaffService GetStaffService()
		{
			string setting = System.Configuration.ConfigurationManager.AppSettings["staffService"];
			string[] items = setting.Split(',');
			string className = items[0];
			string dllName = items[1];

			IStaffService obj = (IStaffService)System.Reflection.Assembly.Load(dllName).CreateInstance(className);
			return obj;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var form = new Login();
			this.Hide(); // 隱藏目前的視窗
			form.Owner = this;
			form.ShowDialog();
			this.Close(); // 在新視窗關閉後關閉目前的視窗
		}
	}
}
