using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wine.Core.Model.Interfaces;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WINE.WinApp
{
	public partial class 員工介面 : Form,IDataContainer
	{
		public 員工介面()
		{
			InitializeComponent();
			this.Load += 員工介面_Load;
		}

		private void 員工介面_Load(object sender, EventArgs e)
		{
			Display();
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

		private void buttonProductManage_Click(object sender, EventArgs e)
		{
			Display();
		}

		private void button1_Click(object sender, EventArgs e) //logout
		{
			var form = new Login();
			this.Hide(); // 隱藏目前的視窗
			form.Owner = this;
			form.ShowDialog();
			this.Close(); // 在新視窗關閉後關閉目前的視窗
		}

		private void buttonMemberOrder_Click(object sender, EventArgs e)
		{
			openChildForm(new MemberOrders());
		}

		public void Display()
		{
			openChildForm(new 產品管理());
			toolTip1.SetToolTip(button1, "登出");
		}

		private void buttonMemberData_Click(object sender, EventArgs e)
		{
			openChildForm(new MemberManager());
		}
	}
}
