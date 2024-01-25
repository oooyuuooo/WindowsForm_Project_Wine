using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Wine.Core.Model.Dto;
using Wine.Core.Model.Interfaces;

namespace Wine.Core.Model.Repositories
{
	public class ProductDapperRepository : IProductRepository
	{
		public int Create(ProductsDto dto)
		{
			string connStr = SqlDb.GetConnectionString("default");
			string sql = "INSERT INTO Products(Name,Year,Cat_id,Orig_id,Cap_id,TastesID,Price,ImageLink,Count) VALUES (@Name,@Year,@Cat_id,@Orig_id,@Cap_id,@TastesID,@Price,@ImageLink,@Count);SELECT SCOPE_IDENTITY()";

			int newId;
			using (var conn = new SqlConnection(connStr))
			{
				newId = conn.QueryFirst<int>(sql, new { Name = dto.Name, Year = dto.Year, Cat_id = dto.Cat_Id, Orig_id = dto.Orig_Id, Cap_id = dto.Cap_Id, TastesID = dto.TastesId, Price = dto.Price, ImageLink = dto.ImageLink, Count = dto.Count });
			}
			return newId;
		}

		public void Delete(int id)
		{
			string connStr = SqlDb.GetConnectionString("default");
			string sql = "DELETE FROM Products WHERE ID = @Id";

			using (var conn = new SqlConnection(connStr))
			{
				conn.Execute(sql, new { Id = id });
			}
		}

		public ProductsDto Get(int id)
		{
			string connStr = SqlDb.GetConnectionString("default");
			//string sql = "SELECT * FROM Products WHERE Id = @Id";
			string sql = @"SELECT p.Name,p.Year,cap.Capacity,cate.Category,o.Origin,t.Taste,p.Price,p.ImageLink,p.Count
				 FROM Products p
				 JOIN Capacities cap ON p.Cap_id = cap.ID
				 JOIN Categories cate ON p.Cat_id = cate.ID
				 JOIN Origins o ON p.Orig_id = o.ID
				 JOIN Tastes t ON p.TastesID = t.ID
				 WHERE p.ID = @Id ";

			using (var conn = new SqlConnection(connStr))
			{
				ProductsDto data = conn.QueryFirst<ProductsDto>(sql, new { Id = id });
				return data;
			}
		}

		public List<ProductsDto> Search(ProductsDto dto)
		{
			string connStr = SqlDb.GetConnectionString("default");
			string sql = @"SELECT p.ID Id,p.Name Name,p.Year Year,p.Price Price,p.ImageLink ImageLink,p.Count,cap.Capacity Capacity,cate.Category Category,o.Origin Origin,t.Taste Taste " +
				 "FROM Products p " +
				 "JOIN Capacities cap ON p.Cap_id = cap.ID " +
				 "JOIN Categories cate ON p.Cat_id = cate.ID " +
				 "JOIN Origins o ON p.Orig_id = o.ID " +
				 "JOIN Tastes t ON p.TastesID = t.ID " +
				 "WHERE 1=1";
			if (dto.Cap_Id != 0)
			{
				sql += " AND p.Cap_id = @Cap_id";
			}
			if (dto.Cat_Id != 0)
			{
				sql += " AND p.Cat_id = @Cat_id";
			}
			if (dto.Orig_Id != 0)
			{
				sql += " AND p.Orig_id = @Orig_id";
			}
			if (dto.TastesId != 0)
			{
				sql += " AND p.TastesID = @TastesID";
			}
			if (dto.Name != "")
			{
				sql += " AND p.Name LIKE '%' + @Name + '%' ORDER BY Price DESC";
			}
			else
			{
				sql += " ORDER BY Price DESC";
			}
			using (var conn = new SqlConnection(connStr))
			{
				string finalSql = sql;
				IEnumerable<ProductsDto> data = conn.Query<ProductsDto>(sql, new
				{
					Cap_id = dto.Cap_Id,
					TastesID = dto.TastesId,
					Cat_id = dto.Cat_Id,
					Orig_id = dto.Orig_Id,
					dto.Name
				});
				return (List<ProductsDto>)data;
			}
		}

		public List<ProductsDto> GetAllData()
		{
			string connStr = SqlDb.GetConnectionString("default");
			string sql = @"SELECT p.ID Id,p.Name Name,p.Year Year,p.Price Price,p.ImageLink ImageLink,p.Count,cap.Capacity Capacity,cate.Category Category,o.Origin Origin,t.Taste Taste
				 FROM Products p 
				 JOIN Capacities cap ON p.Cap_id = cap.ID 
				 JOIN Categories cate ON p.Cat_id = cate.ID 
				 JOIN Origins o ON p.Orig_id = o.ID 
				 JOIN Tastes t ON p.TastesID = t.ID ";

			using (var conn = new SqlConnection(connStr))
			{
				return conn.Query<ProductsDto>(sql).ToList();
			}
		}

		public void Update(ProductsDto dto)
		{
			string connStr = SqlDb.GetConnectionString("default");
			string sql = @"UPDATE Products SET Name = @Name,Year = @Year,
							Cat_id = (SELECT ID FROM Categories WHERE Category = @Category),
							Orig_id = (SELECT ID FROM Origins WHERE Origin = @Origin),
							Cap_id = (SELECT ID FROM Capacities WHERE Capacity = @Capacity),
							TastesID = (SELECT ID FROM Tastes WHERE Taste = @Taste),
							Price = @Price,
							ImageLink = @ImageLink
							WHERE ID = @Id;";
			using (var conn = new SqlConnection(connStr))
			{
				conn.Execute(sql, dto);
			}
		}

		public void UploadCSV(string filePath)
		{
			DataTable dataTable = new DataTable();
			string[] lines = System.IO.File.ReadAllLines(filePath);

			// 假設第一行是標題，從第二行開始讀取資料
			using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8)) // 使用正確的編碼方式讀取檔案
			{
				if (lines.Length > 1)
				{
					string[] headers = lines[0].Split(',');
					foreach (string header in headers)
					{
						dataTable.Columns.Add(new DataColumn(header));
					}

					for (int i = 1; i < lines.Length; i++)
					{
						string[] data = lines[i].Split(',');
						DataRow row = dataTable.NewRow();
						for (int j = 0; j < headers.Length; j++)
						{
							if (headers[j] == "Year" && string.IsNullOrEmpty(data[j]))
							{
								data[j] = string.Empty;
							}
							row[j] = data[j];
						}
						dataTable.Rows.Add(row);
					}
				}
			}

			string connStr = SqlDb.GetConnectionString("default");
			using (var conn = new SqlConnection(connStr))
			{
				using (SqlCommand cmd = new SqlCommand())
				{
					cmd.Connection = conn;
					conn.Open();

					foreach (DataRow row in dataTable.Rows)
					{
						cmd.CommandText = $"INSERT INTO Products (Name, Year, Cat_id, Orig_id, Cap_id, TastesID, Price, ImageLink, Count) VALUES (@Name, @Year, @Cat_id, @Orig_id, @Cap_id, @TastesID, @Price, @ImageLink, @Count)";
						cmd.Parameters.Clear();
						// 設定參數的值
						cmd.Parameters.AddWithValue("@Name", row["Name"]);
						cmd.Parameters.AddWithValue("@Year", row["Year"]);
						cmd.Parameters.AddWithValue("@Cat_id", row["Cat_id"]);
						cmd.Parameters.AddWithValue("@Orig_id", row["Orig_id"]);
						cmd.Parameters.AddWithValue("@Cap_id", row["Cap_id"]);
						cmd.Parameters.AddWithValue("@TastesID", row["TastesID"]);
						cmd.Parameters.AddWithValue("@Price", row["Price"]);
						cmd.Parameters.AddWithValue("@ImageLink", row["ImageLink"]);
						cmd.Parameters.AddWithValue("@Count", row["Count"]);

						cmd.ExecuteNonQuery();
					}
				}
			}
		}
	}
}