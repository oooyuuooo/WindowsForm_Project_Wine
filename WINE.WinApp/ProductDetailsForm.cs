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
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace WINE.WinApp
{
	public partial class ProductDetailsForm : Form
	{
		private readonly int _productId;
		private readonly int _memberId;
		private int _orderId;
		private int _count;
		private int originCount;
		bool isAdd;
		public ProductDetailsForm(int productId, int memberId, int count)
		{
			InitializeComponent();
			_productId = productId;
			_memberId = memberId;
			_count = count;
			originCount = _count;
			this.Load += ProductDetailsForm_Load;
		}

		private void ProductDetailsForm_Load(object sender, EventArgs e)
		{
			labelCount.Text = _count.ToString();
			this.Text = "產品內容";
			this.FormBorderStyle = FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;

			BindData();
		}

		private void BindData()
		{
			ProductsDto model = GetProductService().Get(_productId);
			string length = model.Name;
			int maxLength = 19;
			if (length.Length > maxLength)
			{
				length = length.Insert(maxLength, "\n");
			}
			labelProduct.Text = length;
			labelYear.Text = model.Year.ToString();
			labelOrigin.Text = model.Origin;
			labelCapacity.Text = model.Capacity;
			labelCategory.Text = model.Category;
			labelTaste.Text = model.Taste;
			labelPrice.Text = $"$ {model.Price:#}";
			labelPrece2.Text = model.Price.ToString();
			pictureBox1.ImageLocation = model.ImageLink;
		}

		private void buttonPlus_Click(object sender, EventArgs e)
		{
			isAdd = true;
			_count = int.Parse(labelCount.Text);
			_count++;
			labelCount.Text = _count.ToString();
		}

		private void buttonMinus_Click(object sender, EventArgs e)
		{
			isAdd = false;
			_count = int.Parse(labelCount.Text);
			if (_count > 1)
			{
				_count--; // 減 1

				labelCount.Text = _count.ToString();
			}
			// 如果你希望在數值為 1 時不進行減少操作，可以將這個部分刪除或者在此添加一個提示
			else
			{
				MessageBox.Show("數值不能再少於1");
			}
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			OrderDto existingOrder = GetUnconfirmedOrder(_memberId);

			if (existingOrder == null || existingOrder.StateID != 1) //如果沒有訂單或訂單狀態為 2 或 3，則建立新訂單
			{
				existingOrder = new OrderDto
				{
					MemberID = _memberId,
					OrderDate = DateTime.Now,
					TotalMoney = (decimal.Parse(labelPrece2.Text) * (int.Parse(labelCount.Text))),
					StateID = 1,
				};
				_orderId = GetOrderService().Create(existingOrder);

				if (_orderId > 0)
				{
					OrderItemDto orderItem = new OrderItemDto
					{
						OrderID = _orderId,
						ProductsID = _productId,
						ProductCount = int.Parse(labelCount.Text),
						ProductsPrice = decimal.Parse(labelPrece2.Text),
						TotalMoney = (decimal.Parse(labelPrece2.Text) * (int.Parse(labelCount.Text)))
					};
					int orderItemId = GetOrderItemService().Create(orderItem);

					if (_orderId > 0)
					{
						MessageBox.Show("成功加入訂購單");
						this.Hide(); // 隱藏目前的視窗
						this.Close(); // 在新視窗關閉後關閉目前的視窗
					}
					else
					{
						MessageBox.Show("無法加入訂單項目");
					}
				}
				else
				{
					MessageBox.Show("無法創建訂單");
				}
			}
			else
			{
				List<OrderDto> orders = GetOrderService().GetAll();
				List<OrderItemDto> orderItems = GetOrderItemService().GetAll(existingOrder.Id);
				OrderItemDto existingItem = orderItems.FirstOrDefault(item => item.ProductsID == _productId);

				if (existingItem != null)
				{
					// 如果產品已存在於訂購單中，顯示該產品的數量並提供選項是否要增加數量
					var result = MessageBox.Show($"該產品已存在於訂購單中，目前數量為 {existingItem.ProductCount}，是否要調整數量？", "產品已存在", MessageBoxButtons.YesNo);

					if (result == DialogResult.Yes)
					{
						if (isAdd)
						{
							// 增加產品數量
							int addCount = (int.Parse(labelCount.Text) - originCount);
							existingItem.ProductCount += addCount;
							existingItem.TotalMoney = existingItem.ProductsPrice * existingItem.ProductCount;
						}
						else
						{
							int minusCount = originCount - (int.Parse(labelCount.Text));
							int finalCount = originCount - minusCount;
							existingItem.ProductCount = finalCount;
							existingItem.TotalMoney = existingItem.ProductsPrice * existingItem.ProductCount;
						}


						// 更新訂單項目中該產品的數量及金額
						GetOrderItemService().Update(existingItem);

						// 更新訂單的總金額
						decimal totalMoney = orderItems.Sum(x => x.TotalMoney);
						GetOrderService().UpdateOrderTotalMoney(existingOrder.Id, totalMoney);

						MessageBox.Show("產品數量已更新");
						this.Hide(); // 隱藏目前的視窗
						this.Close(); // 在新視窗關閉後關閉目前的視窗
					}
					else
					{
						MessageBox.Show("未更新產品數量");
						this.Hide(); // 隱藏目前的視窗
						this.Close(); // 在新視窗關閉後關閉目前的視窗
					}
				}
				else
				{
					// 產品不存在於訂購單中，新增產品至訂購單
					OrderItemDto orderItem = new OrderItemDto
					{
						OrderID = existingOrder.Id,
						ProductsID = _productId,
						ProductCount = int.Parse(labelCount.Text),
						ProductsPrice = decimal.Parse(labelPrece2.Text),
						TotalMoney = (decimal.Parse(labelPrece2.Text) * (int.Parse(labelCount.Text)))
					};

					int orderItemId = GetOrderItemService().Create(orderItem);

					if (orderItemId > 0)
					{
						decimal totalMoney = orderItems.Sum(x => x.TotalMoney);
						GetOrderService().UpdateOrderTotalMoney(existingOrder.Id, totalMoney);
						decimal ordersTotalMoney = orders.Sum(x => x.TotalMoney);
						GetOrderService().UpdateOrderTotalMoney(existingOrder.Id, ordersTotalMoney);
						MessageBox.Show("成功加入訂購單");
						this.Hide();
						this.Close();
					}
					else
					{
						MessageBox.Show("無法加入訂單項目");
					}
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
		}

		public OrderDto GetUnconfirmedOrder(int memberId)
		{
			List<OrderDto> orders = GetOrderService().GetAllforMember(memberId);

			if (orders != null && orders.Any())
			{
				// 檢查是否存在未確認的訂單
				var unconfirmedOrder = orders.FirstOrDefault(order => order.StateID != 2 && order.StateID != 3);
				if (unconfirmedOrder != null)
				{
					return unconfirmedOrder;
				}
			}
			return null;
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

		private IOrderService GetOrderService()
		{
			string setting = System.Configuration.ConfigurationManager.AppSettings["orderService"];
			string[] items = setting.Split(',');
			string className = items[0];
			string dllName = items[1];

			IOrderService obj = (IOrderService)System.Reflection.Assembly.Load(dllName).CreateInstance(className);
			return obj;
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