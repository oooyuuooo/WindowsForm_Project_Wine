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
	public partial class EditOneProduct : Form
	{
		private readonly int _id;
		public EditOneProduct(int id)
		{
			InitializeComponent();
			_id = id;
			this.Load += EditProduct_Load; ;
			this.buttonCancel.Click += ButtonCancel_Click;
		}

		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			this.Close();
			this.DialogResult = DialogResult.OK;
		}

		private void EditProduct_Load(object sender, EventArgs e)
		{
			this.Text = "編輯產品";
			this.FormBorderStyle = FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			BindData();
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			try
			{
				ProductsDto dto = new ProductsDto
				{
					Id = _id,
					Name = textBoxName.Text,
					Year = textBoxYear.Text,
					Category = textBoxCategory.Text,
					Capacity = textBoxCapacity.Text,
					Origin = textBoxOrigin.Text,
					Taste = textBoxTaste.Text,
					Price = decimal.Parse(textBoxPrice.Text),
					ImageLink = textBoxImageLink.Text,
				};
				if (dto.Year == null)
				{
					textBoxYear.Text = string.Empty;
				}
				GetProductService().Update(dto);
				MessageBox.Show("產品資料已更新");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

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

		private void buttonDelete_Click(object sender, EventArgs e)
		{
			GetProductService().Delete(_id);

			MessageBox.Show("產品已刪除");

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

		private void BindData()
		{
			ProductsDto model = GetProductService().Get(_id);
			int breakPosition = 18;
			string productName = model.Name;
			if (breakPosition < productName.Length)
			{
				productName = productName.Insert(breakPosition, "\n");
			}
			textBoxName.Text = productName;
			textBoxYear.Text = model.Year.ToString();
			textBoxOrigin.Text = model.Origin;
			textBoxCapacity.Text = model.Capacity;
			textBoxCategory.Text = model.Category;
			textBoxTaste.Text = model.Taste;
			textBoxPrice.Text = model.Price.ToString();
			textBoxImageLink.Text = model.ImageLink;
			pictureBox1.ImageLocation = model.ImageLink;
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
