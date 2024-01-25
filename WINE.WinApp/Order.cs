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
	public partial class Order : Form, IDataContainer
	{
		private readonly int _memberId;
		public Order(int memberId)
		{
			InitializeComponent();
			_memberId = memberId;
			this.Load += Order_Load;
			this.dataGridView1.CellClick += DataGridView1_CellClick;
			dataGridView1.AutoGenerateColumns = false;
		}

		private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0) return;

			List<OrderDto> orders = dataGridView1.DataSource as List<OrderDto>;

			int orderId = orders[e.RowIndex].Id;

			var form = new OrderItem(orderId,_memberId);
			form.Owner = this;
			form.ShowDialog();
		}

		private void Order_Load(object sender, EventArgs e)
		{
			Display();
			this.Text = "訂購單";
		}

		public void Display()
		{
			var service = GetOrderService();
			List<OrderDto> orders = service.GetAllforMember(_memberId);
			dataGridView1.DataSource = orders;
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
	}
}
