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
	public class StateRepository : IStateRepository
	{
		public void Update(StateDto dto)
		{
			string connStr = SqlDb.GetConnectionString("default");
			string sql = @"UPDATE Orders SET StateID = (SELECT ID FROM States WHERE StateName = @StateName) WHERE ID = @Id";

			using (var conn = new SqlConnection(connStr))
			{
				conn.Execute(sql, dto);
			}
		}
	}
}
