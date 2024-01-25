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
	public partial class MemberManager : Form, IDataContainer
	{
		public MemberManager()
		{
			InitializeComponent();
			this.Load += MemberManager_Load;
			this.Text = "會員資料";
			dataGridView1.AutoGenerateColumns = false;
		}

		private void MemberManager_Load(object sender, EventArgs e)
		{
			Display();			
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

		public void Display()
		{
			var service = GetMemberService();
			List<MemberDto> data = service.GetAllData();
			dataGridView1.DataSource = data;
		}
	}
}
