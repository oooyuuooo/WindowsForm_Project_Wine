using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wine.Core.Model.Dto;
using Wine.Core.Model.Interfaces;

namespace Wine.Core.Model.Repositories
{
	public class CategoryDapperRepositroy : ICategoryRepository
	{
		public List<CategoryDto> GetData()
		{
			string connStr = SqlDb.GetConnectionString("default");
			string sql = "SELECT ID,Category FROM Categories";

			using (var conn = new SqlConnection(connStr))
			{
				return conn.Query<CategoryDto>(sql, conn).ToList();
			}
		}
	}
}
