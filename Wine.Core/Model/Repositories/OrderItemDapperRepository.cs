using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wine.Core.Model.Dto;
using Wine.Core.Model.Interfaces;

namespace Wine.Core.Model.Repositories
{
	public class OrderItemDapperRepository : IOrderItemRepository
	{
		public int Create(OrderItemDto dto) //新增訂單至資料庫
		{
			string connStr = SqlDb.GetConnectionString("default");
			string sql = @"INSERT INTO Order_Items(OrderID,ProductsID,ProductCount,ProductsPrice,TotalMoney) VALUES (@OrderID,@ProductsID,@ProductCount,@ProductsPrice,@TotalMoney); SELECT SCOPE_IDENTITY()";

			int newId;
			using (var conn = new SqlConnection(connStr))
			{
				newId = conn.QueryFirst<int>(sql, new { OrderID = dto.OrderID, ProductsID = dto.ProductsID, ProductCount = dto.ProductCount, ProductsPrice = dto.ProductsPrice, TotalMoney = dto.TotalMoney });
			}
			return newId;
		}

		public void Delete(int id) // 刪除特定ID訂單項目
		{
			string connStr = SqlDb.GetConnectionString("default");
			string sql = @"DELETE FROM Order_Items WHERE ProductsID = @ProductsID";

			using (var conn = new SqlConnection(connStr))
			{
				conn.Execute(sql, new {ProductsID = id});
			}
		}

		public List<OrderItemDto> Get(int id) //取得特定ID訂單項目
		{
			string connStr = SqlDb.GetConnectionString("default");
			string sql = @"SELECT OrderID, ProductsID,ProductCount,ProductsPrice,TotalMoney FROM Order_Items WHERE ID = @Id";

			using (var conn = new SqlConnection(connStr))
			{
				var data = conn.Query<OrderItemDto>(sql, new { Id = id }).ToList();
				return data;
			}
		}

		public List<OrderItemDto> GetAll(int orderId) //顯示所有訂單明細內容
		{
			string connStr = SqlDb.GetConnectionString("default");
			string sql = @"SELECT o.ID,o.OrderID,o.ProductCount,o.ProductsPrice,o.TotalMoney,o.ProductsID,p.Name FROM Order_Items o JOIN Products p ON o.ProductsID = p.ID WHERE OrderID = @OrderID";

			using (var conn = new SqlConnection(connStr))
			{
				return conn.Query<OrderItemDto>(sql, new { OrderID = orderId}).ToList();
			}
		}

		public void Update(OrderItemDto dto) //更新特定訂單項目資訊
		{
			string connStr = SqlDb.GetConnectionString("default");
			string sql = @"UPDATE Order_Items SET TotalMoney = @TotalMoney,ProductCount = @ProductCount WHERE ID = @Id";

			using (var conn = new SqlConnection(connStr))
			{
				conn.Execute(sql, dto);
			}
		}
	}
}
