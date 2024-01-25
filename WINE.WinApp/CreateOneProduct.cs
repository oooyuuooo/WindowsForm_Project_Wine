using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Wine.Core.Model.Dto;
using Wine.Core.Model.Interfaces;

namespace WINE.WinApp
{
	public partial class CreateOneProduct : Form
	{
		public CreateOneProduct()
		{
			InitializeComponent();
			this.Load += CreateOneProduct_Load;
			this.buttonSave.Click += ButtonSave_Click;
			this.buttonLeave.Click += ButtonLeave_Click;
		}

		private void ButtonLeave_Click(object sender, EventArgs e)
		{
			this.Close();
			this.DialogResult = DialogResult.OK;
		}

		private void ButtonSave_Click(object sender, EventArgs e)
		{
			int selectedCategoryId = comboBoxCategory.SelectedIndex; // 類型 category 的 ComboBox 的值是對應類型的索引值
			int selectedOriginId = comboBoxOrigin.SelectedIndex; // 產地 origin 的 ComboBox 的值是對應產地的索引值
			int selectedCapacityId = comboBoxCapacity.SelectedIndex; // 容量 capacity 的 ComboBox 的值是對應容量的索引值
			int selectedTasteId = comboBoxTaste.SelectedIndex; // 口感 taste 的 ComboBox 的值是對應口感的索引值
			try
			{
				ProductsDto dto = new ProductsDto
				{
					Name = textBoxName.Text,
					Year = textBoxYear.Text,
					Cat_Id = selectedCategoryId,
					Cap_Id = selectedCapacityId,
					Orig_Id = selectedOriginId,
					TastesId = selectedTasteId,
					Price = decimal.Parse(textBoxPrice.Text),
					Count = 0,
					ImageLink = textBoxImageLink.Text,
				};
				if(dto.Year == null)
				{
					textBoxYear.Text = string.Empty;
				}
				GetProductService().Create(dto);
				MessageBox.Show("產品資料已新增");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			if (!string.IsNullOrEmpty(textBoxImageLink.Text)) // 檢查是否 ImageLink 不為空
			{
				if (Uri.IsWellFormedUriString(textBoxImageLink.Text, UriKind.Absolute)) // 檢查 ImageLink 是否為有效連結
				{
					try
					{
						pictureBox1.ImageLocation = textBoxImageLink.Text; // 設定 PictureBox 圖片
					}
					catch (Exception ex)
					{
						MessageBox.Show("圖片連結無效：" + ex.Message);
					}
				}
				else
				{
					MessageBox.Show("請輸入有效的圖片連結");
				}
			}
			else
			{
				// 如果 ImageLink 為空，你可以選擇在這裡設定 PictureBox 為空，或者執行其他你希望的邏輯
				pictureBox1.Image = null; // 清除 PictureBox 圖片
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

			//this.DialogResult = DialogResult.OK;
		}

		private void CreateOneProduct_Load(object sender, EventArgs e)
		{
			this.Text = "新增單項產品";
			this.FormBorderStyle = FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			BindComboBox<CategoryDto>(comboBoxCategory, GetCategoryService(), "Category", "Categories.Id");
			BindComboBox<CapacityDto>(comboBoxCapacity, GetCapacityService(), "Capacity", "Capacities.Id");
			BindComboBox<OriginDto>(comboBoxOrigin, GetOriginService(), "Origin", "Origins.Id");
			BindComboBox<TasteDto>(comboBoxTaste, GetTasteService(), "Taste", "Tastes.Id");
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
