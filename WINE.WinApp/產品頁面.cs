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

namespace WINE.WinApp
{
	public partial class 產品頁面 : Form
	{
		private string _account;
		private string _password;
		private int _memberId;
		public 產品頁面(int memberId,string account, string password)
		{
			InitializeComponent();
			this.Load += 產品頁面_Load;
			_memberId = memberId;
			_account = account;
			_password = password;
		}

		private void 產品頁面_Load(object sender, EventArgs e)
		{
			openChildForm(new Products(_memberId));
			toolTip1.SetToolTip(LogOut, "登出");
		}

		private Form activeForm = null;
		private void openChildForm(Form childForm)
		{
			if (activeForm != null)
			{
				activeForm.Close();
			}
			activeForm = childForm;//若表單位未開啟將表單名指定給變數
			childForm.TopLevel = false;//最上層視窗通常用來作為應用程式中的主要表單 故子表單不能為最上層表單
			childForm.FormBorderStyle = FormBorderStyle.None; //設定子表單邊框為無
			childForm.Dock = DockStyle.Fill;//設定子表單位置
			panel1.Controls.Add(childForm);//將表單加入panel
			panel1.Tag = childForm;//將標籤設為子表單名
			childForm.BringToFront(); //將表單放置到前面
			childForm.Show(); //開啟表單
		}

		private void buttonProductSearch_Click(object sender, EventArgs e)
		{
			openChildForm(new Products(_memberId));
		}

		private void buttonOrder_Click(object sender, EventArgs e)
		{
			openChildForm(new Order(_memberId));
		}

		private void LogOut_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("確定要登出嗎？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

			if (result == DialogResult.OK)
			{
				var form = new Login();
				this.Hide(); // 隱藏目前的視窗
				form.Owner = this;
				form.ShowDialog();
				this.Close(); // 在新視窗關閉後關閉目前的視窗
			}
		}

		private void buttonMembers_Click(object sender, EventArgs e)
		{
			var form = new MemberInformationUpdate(_memberId,_account,_password);
			form.Owner= this;
			openChildForm(form);
			
		}

	}
}
