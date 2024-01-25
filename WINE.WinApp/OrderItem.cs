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
	public partial class OrderItem : Form, IDataContainer
	{
		private readonly int _id;
		private readonly int _memberId;
		public OrderItem(int id, int memberId)
		{
			InitializeComponent();
			_id = id;
			_memberId = memberId;
			this.Load += OrderItem_Load;
			this.dataGridView1.CellClick += DataGridView1_CellClick;
			dataGridView1.AutoGenerateColumns = false;
		}

		private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0) return;

			List<OrderItemDto> orders = dataGridView1.DataSource as List<OrderItemDto>;

			int productId = orders[e.RowIndex].ProductsID;
			int count = orders[e.RowIndex].ProductCount;

			var form =new ProductDetailForm2(productId, _memberId, count);
			form.Owner = this;
			form.ShowDialog();
		}

		private void OrderItem_Load(object sender, EventArgs e)
		{
			Display();
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
			this.Close(); // 在新視窗關閉後關閉目前的視窗
		}
	}
}
