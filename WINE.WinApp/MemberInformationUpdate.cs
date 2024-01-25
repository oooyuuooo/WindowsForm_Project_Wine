using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Wine.Core.Model.Dto;
using Wine.Core.Model.Interfaces;

namespace WINE.WinApp
{
	public partial class MemberInformationUpdate : Form
	{
		private string _account;
		private string _password;
		private int _id;
		public MemberInformationUpdate(int id,string account, string password)
		{
			InitializeComponent();
			this.Load += MemberInformationUpdate_Load;
			this.textBoxCheckPW.TextChanged += TextBoxCheckPW_TextChanged;
			_id = id;
			_account = account;
			_password = password;
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

		private void MemberInformationUpdate_Load(object sender, EventArgs e)
		{
			var member = GetMemberService().GetMember(_account, _password);
			labelAccount.Text = member.Account;
			textBoxPassword.Text = member.Password;
			textBoxEmail.Text = member.Email;
			textBoxPhone.Text = member.Phone;
			textBoxCheckPW.Text = string.Empty;
			textBoxName.Text = member.Name;
			dateTimePicker1.Value = member.DateOfBirth;
		}
		
		private void buttonSave_Click(object sender, EventArgs e)
		{
			try
			{
				_account = labelAccount.Text;
				MemberDto dto = new MemberDto
				{
					Account = _account,
					Password = textBoxPassword.Text,
					ConfirmPassword = textBoxCheckPW.Text,
					Email = textBoxEmail.Text,
					Phone = textBoxPhone.Text,
					Name = textBoxName.Text,
					DateOfBirth = dateTimePicker1.Value,
				};
				if (dto.Password != _password)
				{
					GetMemberService().Update(dto);
					var loginForm = new Login();
					this.Owner.Hide();
					loginForm.ShowDialog();
					this.Owner.Close();
				}
				GetMemberService().Update(dto);
				MessageBox.Show("會員資料已更新");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			this.DialogResult = DialogResult.OK;
		}

		private void buttonDelete_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("確定要註銷帳號嗎？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

			if (result == DialogResult.OK)
			{
				// 執行註銷帳號的動作
				try
				{
					GetMemberService().Delete(_id);
					MessageBox.Show("帳號已註銷");
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
				var loginForm = new Login();
				this.Owner.Hide();
				loginForm.ShowDialog();
				this.Owner.Close();
			}
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
