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

namespace WINE.WinApp
{
	public partial class Register : Form
	{
		public Register()
		{
			InitializeComponent();
			this.buttonRegiste.Click += ButtonRegiste_Click;
			this.textBoxCheckPW.TextChanged += TextBoxCheckPW_TextChanged;
		}

		private void TextBoxCheckPW_TextChanged(object sender, EventArgs e)
		{
			if (textBoxPassword.Text != textBoxCheckPW.Text)
			{
				errorProvider1.SetError(textBoxCheckPW, "密碼與確認密碼不相符");
			}
			else
			{
				errorProvider1.Clear();
			}
		}

		private void ButtonRegiste_Click(object sender, EventArgs e)
		{
			try
			{
				MemberDto dto = new MemberDto
				{
					Name = textBoxName.Text,
					Account = textBoxAccount.Text,
					Password = textBoxPassword.Text,
					ConfirmPassword = textBoxCheckPW.Text,
					Email = textBoxEmail.Text,
					Phone = textBoxPhone.Text,
					DateOfBirth = dateTimePicker1.Value
				};
				GetMemberService().Create(dto);
				MessageBox.Show("註冊成功");
				var form = new Login();
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

		private void button1_Click(object sender, EventArgs e)
		{
			var form = new Login();
			this.Hide(); // 隱藏目前的視窗
			form.Owner = this;
			form.ShowDialog();
			this.Close(); // 在新視窗關閉後關閉目前的視窗
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
