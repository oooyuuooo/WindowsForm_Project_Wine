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
	public class CapacityDapperRepository : ICapacityRepository
	{
		public List<CapacityDto> GetData()
		{
			string connStr = SqlDb.GetConnectionString("default");
			string sql = "SELECT ID, Capacity FROM Capacities";

			using (var conn = new SqlConnection(connStr))
			{
				return conn.Query<CapacityDto>(sql, conn).ToList();
			}
		}
	}
}
