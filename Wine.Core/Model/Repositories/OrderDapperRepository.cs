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
	public class OrderDapperRepository : IOrderRepository
	{
		public int Create(OrderDto dto)
		{
			string connStr = SqlDb.GetConnectionString("default");
			string sql = @"INSERT INTO Orders (MemberID,OrderDate,TotalMoney,StateID) VALUES (@MemberID,@OrderDate,@TotalMoney,@StateID); SELECT SCOPE_IDENTITY()";

			int newId;
			using (var conn = new SqlConnection(connStr))
			{
				newId = conn.QueryFirst<int>(sql, new { MemberID = dto.MemberID, OrderDate = dto.OrderDate, TotalMoney = dto.TotalMoney, StateID = dto.StateID });
			}
			return newId;
		}

		public OrderDto Get(int memberID) //獲取訂單資訊
		{
			string connStr = SqlDb.GetConnectionString("default");
			string sql = @"SELECT ID,MemberID,OrderDate,TotalMoney,StateID FROM Orders WHERE MemberID = @MemberID";

			using (var conn = new SqlConnection(connStr))
			{
				OrderDto data = conn.QueryFirstOrDefault<OrderDto>(sql, new { MemberID = memberID });
				return data;
			}
		}

		public void Update(int orderId,int state)  // 店家更新訂單狀態
		{
			string connStr = SqlDb.GetConnectionString("default");
			string sql = @"UPDATE Orders SET StateID=@StateID WHERE ID = @Id";

			using (var conn = new SqlConnection(connStr))
			{
				conn.Execute(sql, new {Id = orderId,StateID = state});
			}
		}

		public List<OrderDto> Search(DateTime orderDate, int stateId)  //透過下定日期或是訂單狀態查詢
		{
			string connStr = SqlDb.GetConnectionString("default");
			string sql = @"SELECT o.ID, o.MemberID, o.OrderDate, o.TotalMoney,s.StateName 
						   FROM Orders o
						   JOIN States s ON o.StateID = s.Id
						   WHERE 1=1";
			if (orderDate != null)
			{
				sql += " AND o.OrderDate = @OrderDate";
			}
			if (stateId != 0)
			{
				sql += " AND s.StateName = @StateName";
			}

			using (var conn = new SqlConnection(connStr))
			{
				var data = conn.Query<OrderDto>(sql, new { OrderDate = orderDate, StateId = stateId }).ToList();
				return data;
			}
		}
		public void UpdateOrderTotalMoney(int orderId, decimal totalMoney)
		{
			string connStr = SqlDb.GetConnectionString("default");
			string sql = @"UPDATE Orders SET TotalMoney = @TotalMoney WHERE ID = @OrderId";

			using (var conn = new SqlConnection(connStr))
			{
				conn.Execute(sql, new { TotalMoney = totalMoney, OrderId = orderId });
			}
		}
		public List<OrderDto>GetAll()
		{
			string connStr = SqlDb.GetConnectionString("default");
			string sql = @"SELECT o.ID, o.MemberID, o.OrderDate,o.StateID,SUM(i.TotalMoney) TotalMoney,s.StateName,m.Account 
						 FROM Orders o
						   JOIN States s ON o.StateID = s.Id
						   JOIN Order_Items i ON o.ID = i.OrderID
						   JOIN Members m ON o.MemberID = m.ID
GROUP BY o.ID,o.MemberID,o.OrderDate,o.StateID,s.StateName,m.Account";

			using(var conn = new SqlConnection(connStr))
			{
				return conn.Query<OrderDto>(sql).ToList();
			}
		}

		public List<OrderDto> GetAllforMember(int memberId)
		{
			string connStr = SqlDb.GetConnectionString("default");
			string sql = @"SELECT o.ID, o.MemberID, o.OrderDate,o.StateID,SUM(i.TotalMoney) TotalMoney,s.StateName,m.Account 
						 FROM Orders o
						   JOIN States s ON o.StateID = s.Id
						   JOIN Order_Items i ON o.ID = i.OrderID
						   JOIN Members m ON o.MemberID = m.ID
GROUP BY o.ID,o.MemberID,o.OrderDate,o.StateID,s.StateName,m.Account
HAVING o.MemberID = @MemberID";

			using (var conn = new SqlConnection(connStr))
			{
				return conn.Query<OrderDto>(sql, new {MemberID = memberId}).ToList();
			}
		}
	}
}
