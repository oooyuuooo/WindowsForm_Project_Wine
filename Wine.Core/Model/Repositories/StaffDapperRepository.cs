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
	public class StaffDapperRepository : IStaffRepository
	{
		public StaffDto Get(string account, string password)
		{
			string connStr = SqlDb.GetConnectionString("default");

			using (var conn = new SqlConnection(connStr))
			{
				string sql = "SELECT ID, StaffAccount, StaffPassword FROM Staffs WHERE StaffAccount = @StaffAccount";

				StaffDto staff = conn.QueryFirstOrDefault<StaffDto>(sql, new { StaffAccount = account, StaffPassword = password });
				return staff;
			}
		}
	}
}
