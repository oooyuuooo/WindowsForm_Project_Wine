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
	public partial class 產品管理 : Form, IDataContainer
	{
		private readonly int _id;
		public 產品管理()
		{
			InitializeComponent();
			this.Load += 產品管理_Load;
			this.dataGridView1.CellClick += DataGridView1_CellClick;
			this.ButtonCreateOne.Click += ButtonCreateOne_Click;
			this.buttonCreateMany.Click += ButtonCreateMany_Click;

			dataGridView1.AutoGenerateColumns = false;

		}

		private void ButtonCreateMany_Click(object sender, EventArgs e)
		{
			var form = new CreateManyPrdoucts();
			form.Owner = this;
			form.ShowDialog();
		}

		private void ButtonCreateOne_Click(object sender, EventArgs e)
		{
			var form = new CreateOneProduct();
			form.Owner = this;
			form.ShowDialog();
		}

		private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0) return;

			List<ProductsDto> products = dataGridView1.DataSource as List<ProductsDto>;

			int id = products[e.RowIndex].Id;

			var form = new EditOneProduct(id);
			form.Owner = this;
			form.ShowDialog();
		}

		private void 產品管理_Load(object sender, EventArgs e)
		{
			Display();
			this.Text = "產品管理";
		}

		public void Display()
		{
			var service = GetProductService();
			List<ProductsDto> allData = service.GetAllData();
			dataGridView1.DataSource = allData;
		}

		private IProductService GetProductService()
		{
			string setting = System.Configuration.ConfigurationManager.AppSettings["productService"];
			string[] items = setting.Split(',');
			string className = items[0];
			string dllName = items[1];

			IProductService obj = (IProductService)System.Reflection.Assembly.Load(dllName).CreateInstance(className);
			return obj;
		}
	}
}
