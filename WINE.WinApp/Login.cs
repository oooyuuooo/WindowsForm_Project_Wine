using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wine.Core.Model.Dto;
using Wine.Core.Model.Interfaces;

namespace WINE.WinApp
{
	public partial class Login : Form
	{
		private string _account;
		private string _password;
		public Login()
		{
			InitializeComponent();
		}

		private void LoginBotton_Click(object sender, EventArgs e)
		{
			try
			{
				var service = GetMemberService();
				_account = textBoxAccount.Text;
				_password = textBoxPassword.Text;

				MemberDto member = service.GetMember(_account, _password);

				if (member != null)
				{
					member.Account = textBoxAccount.Text;
					member.Password = textBoxPassword.Text;

					MessageBox.Show("登入成功");

					var form = new 產品頁面(member.Id,member.Account,member.Password);
					this.Hide(); // 隱藏目前的視窗
					form.Owner = this;
					form.ShowDialog();
					//this.Close(); // 在新視窗關閉後關閉目前的視窗
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}

		private void linkLabel_Account_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{	
			var form = new Register();
			form.Owner = this;
			this.Hide();
			form.ShowDialog();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var form = new StaffLogin();
			form.Owner = this;
			this.Hide();
			form.ShowDialog();
		}

		private IMemberService GetMemberService()
		{
			string setting = System.Configuration.ConfigurationManager.AppSettings["memberService"];
			string[] items = setting.Split(',');
			string className = items[0];
			string dllName = items[1];

			IMemberService obj = (IMemberService)System.Reflection.Assembly.Load(dllName).CreateInstance(className);
			return obj;
		}
	}
}
