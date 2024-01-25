using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Wine.Core.Model.Dto;
using Wine.Core.Model.Interfaces;
using Wine.Core.Model.Services;

namespace WINE.WinApp
{
	public partial class Products : Form, IDataContainer
	{
		private readonly int _memberId;
		public Products(int memberId)
		{
			InitializeComponent();
			this.Text = "產品頁面";
			this.Load += Products_Load;
			this.buttonSearch.Click += ButtonSearch_Click;
			this.dataGridView1.CellClick += DataGridView1_CellClick;
			_memberId = memberId;

			dataGridView1.AutoGenerateColumns = false;
		}

		private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0) return;

			List<ProductsDto> products = dataGridView1.DataSource as List<ProductsDto>;

			int productId = products[e.RowIndex].Id;
			int currentCount = 1;
			var form = new ProductDetailsForm(productId,_memberId,currentCount);
			form.Owner = this;
			form.ShowDialog();
		}

		private void ButtonSearch_Click(object sender, EventArgs e)
		{
			Display();
		}

		private void buttonReset_Click(object sender, EventArgs e)
		{
			//回到預設值
			comboBoxCategory.SelectedIndex = 0;
			comboBoxOrigin.SelectedIndex = 0;
			comboBoxCapacity.SelectedIndex = 0;
			comboBoxTaste.SelectedIndex = 0;
			comboBoxPrice.SelectedIndex = 0;
			textBoxName.Text = "";
			// 更新 DataGridView
			Display();
		}

		private void Products_Load(object sender, EventArgs e)
		{
			Display();
			BindComboBox<CategoryDto>(comboBoxCategory, GetCategoryService(), "Category", "cate.Id");
			BindComboBox<CapacityDto>(comboBoxCapacity, GetCapacityService(), "Capacity", "cap.Id");
			BindComboBox<OriginDto>(comboBoxOrigin, GetOriginService(), "Origin", "o.Id");
			BindComboBox<TasteDto>(comboBoxTaste, GetTasteService(), "Taste", "t.Id");
			
		}

		public void Display()
		{
			var service = GetProductService();
			string name = textBoxName.Text;
			int selectedCategoryId = comboBoxCategory.SelectedIndex; // 假設類型 category 的 ComboBox 的值是對應類型的索引值
			int selectedOriginId = comboBoxOrigin.SelectedIndex; // 假設產地 origin 的 ComboBox 的值是對應產地的索引值
			int selectedCapacityId = comboBoxCapacity.SelectedIndex; // 假設容量 capacity 的 ComboBox 的值是對應容量的索引值
			int selectedTasteId = comboBoxTaste.SelectedIndex; // 假設口感 taste 的 ComboBox 的值是對應口感的索引值
			int selectedPriceId = comboBoxPrice.SelectedIndex;

			if (selectedCategoryId == -1 && selectedOriginId == -1 && selectedCapacityId == -1 && selectedTasteId == -1 && name == "" && selectedPriceId == -1)
			{
				List<ProductsDto> allData = service.GetAllData();
				dataGridView1.DataSource = allData;
			}
			else
			{
				List<ProductsDto> data = service.Search(new ProductsDto()
				{
					Cap_Id = selectedCapacityId,
					Cat_Id = selectedCategoryId,
					Orig_Id = selectedOriginId,
					TastesId = selectedTasteId,
					Name = name,
				});
				if (selectedPriceId == 2)
				{
					dataGridView1.DataSource = data;
				}
				else
				{
					List<ProductsDto> data2 = data.OrderBy(x => x.Price).ToList();
					dataGridView1.DataSource = data2;
				}
			}
		}

		private void BindComboBox<T>(ComboBox comboBox, object service, string displayMember, string valueMember)
		{

			var serviceType = service.GetType();
			var getDataMethod = serviceType.GetMethod("GetData");
			var data = (List<T>)getDataMethod.Invoke(service, null);

			var firstItem = (T)Activator.CreateInstance(typeof(T)); // 创建一个空对象，可以根据实际情况修改
			data.Insert(0, firstItem);

			comboBox.DataSource = data;
			comboBox.DisplayMember = displayMember;
			comboBox.ValueMember = valueMember;
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

		private ICategoryService GetCategoryService()
		{
			string setting = System.Configuration.ConfigurationManager.AppSettings["categoryService"];
			string[] items = setting.Split(',');
			string className = items[0];
			string dllName = items[1];

			ICategoryService obj = (ICategoryService)System.Reflection.Assembly.Load(dllName).CreateInstance(className);
			return obj;
		}

		private ICapacityService GetCapacityService()
		{
			string setting = System.Configuration.ConfigurationManager.AppSettings["capacityService"];
			string[] items = setting.Split(',');
			string className = items[0];
			string dllName = items[1];

			ICapacityService obj = (ICapacityService)System.Reflection.Assembly.Load(dllName).CreateInstance(className);
			return obj;
		}

		private IOriginService GetOriginService()
		{
			string setting = System.Configuration.ConfigurationManager.AppSettings["originService"];
			string[] items = setting.Split(',');
			string className = items[0];
			string dllName = items[1];

			IOriginService obj = (IOriginService)System.Reflection.Assembly.Load(dllName).CreateInstance(className);
			return obj;
		}

		private ITasteService GetTasteService()
		{
			string setting = System.Configuration.ConfigurationManager.AppSettings["tasteService"];
			string[] items = setting.Split(',');
			string className = items[0];
			string dllName = items[1];

			ITasteService obj = (ITasteService)System.Reflection.Assembly.Load(dllName).CreateInstance(className);
			return obj;
		}
	}
}

