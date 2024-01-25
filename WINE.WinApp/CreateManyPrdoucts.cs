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

namespace WINE.WinApp
{
	public partial class CreateManyPrdoucts : Form
	{
		public CreateManyPrdoucts()
		{
			InitializeComponent();
			this.Load += CreateManyPrdoucts_Load;
			this.buttonChoose.Click += ButtonChoose_Click;
			this.buttonConfirm.Click += ButtonConfirm_Click;
		}

		private void CreateManyPrdoucts_Load(object sender, EventArgs e)
		{
			this.Text = "新增多項產品";
			this.FormBorderStyle = FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
		}

		private void ButtonConfirm_Click(object sender, EventArgs e)
		{
			string filePath = textBoxFilePath.Text;
			try
			{
				GetProductService().UploadCSV(filePath);
				MessageBox.Show("CSV 檔案資料已成功上傳至資料庫！");
			}
			catch (Exception ex)
			{
				MessageBox.Show($"上傳檔案時發生錯誤：{ex.Message}");
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

		private void ButtonChoose_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*"; // 可以選擇 CSV 檔案或者所有檔案
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				textBoxFilePath.Text = openFileDialog.FileName; // 設定所選檔案的路徑到 TextBox
			}
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

		private void buttonCancle_Click(object sender, EventArgs e)
		{
			this.Close();
			this.DialogResult = DialogResult.OK;
		}
	}
}
