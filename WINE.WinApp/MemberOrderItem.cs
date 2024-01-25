using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Wine.Core.Model.Dto;
using Wine.Core.Model.Interfaces;
using Wine.Core.Model.Repositories;

namespace WINE.WinApp
{
	public partial class MemberOrderItem : Form
	{
		private readonly int _id;
		private readonly int _memberId;
		private string _state;
		private int _stateId;
		public MemberOrderItem(int id, int memberId,string state,int stateId)
		{
			InitializeComponent();
			_id = id;
			_memberId = memberId;
			_state = state;
			_stateId = stateId;
			this.Load += MemberOrderItem_Load; ;
			dataGridView1.AutoGenerateColumns = false;
		}

		private void MemberOrderItem_Load(object sender, EventArgs e)
		{
			Display();
			labelState.Text = _state;
			this.Text = "訂購明細";
		}

		private IOrderItemService GetOrderItemService()
		{
			string setting = System.Configuration.ConfigurationManager.AppSettings["orderItemService"];
			string[] items = setting.Split(',');
			string className = items[0];
			string dllName = items[1];

			IOrderItemService obj = (IOrderItemService)System.Reflection.Assembly.Load(dllName).CreateInstance(className);
			return obj;
		}

		public void Display()
		{
			var service = GetOrderItemService();
			List<OrderItemDto> data = service.GetAll(_id);
			dataGridView1.DataSource = data;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Hide(); // 隱藏目前的視窗
			this.Close(); // 在新視窗關閉後關閉目前的視窗
		}

		private IOrderService GetOrderService()
		{
			string setting = System.Configuration.ConfigurationManager.AppSettings["orderService"];
			string[] items = setting.Split(',');
			string className = items[0];
			string dllName = items[1];

			IOrderService obj = (IOrderService)System.Reflection.Assembly.Load(dllName).CreateInstance(className);
			return obj;
		}

		private void buttonCheck_Click(object sender, EventArgs e)
		{
			var service = GetOrderService();
			_stateId = 2;
			service.Update(_id, _stateId);
			labelState.Text = _state;
			MessageBox.Show("訂單狀態已更新");
			var container = this.Owner as IDataContainer;
			if (container != null)
			{
				container.Display();
			}
			else
			{
				MessageBox.Show("Owner 表單沒有實作 IDataContainer 介面，請在嘗試一次");
			}

			this.DialogResult = DialogResult.OK;
		}

		private void buttonDone_Click(object sender, EventArgs e)
		{
			var service = GetOrderService();
			_stateId = 3;
			service.Update(_id, _stateId);
			labelState.Text = _state;
			MessageBox.Show("訂單狀態已更新");
			var container = this.Owner as IDataContainer;
			if (container != null)
			{
				container.Display();
			}
			else
			{
				MessageBox.Show("Owner 表單沒有實作 IDataContainer 介面，請在嘗試一次");
			}

			this.DialogResult = DialogResult.OK;
		}
	}
}
