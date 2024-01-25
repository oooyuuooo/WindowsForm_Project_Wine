using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Wine.Core.Model.Dto;
using Wine.Core.Model.Interfaces;

namespace Wine.Core.Model.Repositories
{
	public class MemberDapperRepository : IMemberRepository
	{
		public int Create(MemberDto dto)
		{
			string connStr = SqlDb.GetConnectionString("default");
			string sql = "INSERT INTO Members (Name,Account,Password,Email,Phone,DateOfBirth) VALUES (@Name,@Account,@Password,@Email,@Phone,@DateOfBirth); SELECT SCOPE_IDENTITY()";
			int newId;
			using (var conn = new SqlConnection(connStr))
			{
				newId = conn.QueryFirst<int>(sql, new { Name = dto.Name, Account = dto.Account, Password = dto.Password, Email = dto.Email, Phone = dto.Phone, DateOfBirth = dto.DateOfBirth });
				return newId;
			}
		}

		public void Delete(int id)
		{
			string connStr = SqlDb.GetConnectionString("default");
			string sql = @"DELETE FROM Members WHERE ID = @Id";
			using (var conn = new SqlConnection(connStr))
			{
				conn.Execute(sql, new { Id = id });
			}
		}

		public MemberDto GetMember(string account, string password)
		{
			string connStr = SqlDb.GetConnectionString("default");

			using (var conn = new SqlConnection(connStr))
			{
				string sql = "SELECT ID,Name,Account,Password,Email,Phone,DateOfBirth FROM Members WHERE Account = @Account";

				MemberDto member = conn.QueryFirstOrDefault<MemberDto>(sql, new { Account = account, Password = password });
				return member;
			}
		}

		public List<MemberDto> Search(int id)
		{
			string connStr = SqlDb.GetConnectionString("default");
			string sql = @"SELECT ID,Name,Account,Password,Email,Phone,DateOfBirth FROM Members WHERE ID = @Id";

			using (var conn = new SqlConnection(connStr))
			{
				string finalSql = sql;
				List<MemberDto> data = conn.Query<MemberDto>(sql, new { Id = id }).ToList();
				return data;
			}
		}

		public void Update(MemberDto dto)
		{
			string connStr = SqlDb.GetConnectionString("default");
			string sql = @"UPDATE Members SET Name = @Name, Account = @Account, Password = @Password, Email = @Email, Phone = @Phone, DateOfBirth = @DateOfBirth WHERE Account = @Account";

			using (var conn = new SqlConnection(connStr))
			{
				conn.Execute(sql, dto);
			}
		}

		public List<MemberDto> GetAllData()
		{
			string connStr = SqlDb.GetConnectionString("default");
			string sql = @"SELECT ID,Name,Account,Password,Email,Phone,DateOfBirth FROM Members";

			using (var conn = new SqlConnection(connStr))
			{
				return conn.Query<MemberDto>(sql).ToList();
			}
		}
		public List<MemberDto> SearchAccount(string account)
		{
			string connStr = SqlDb.GetConnectionString("default");
			string sql = @"SELECT ID,Name,Account,Password,Email,Phone,DateOfBirth FROM Members WHERE Account = @Account";

			using (var conn = new SqlConnection(connStr))
			{
				string finalSql = sql;
				List<MemberDto> data = conn.Query<MemberDto>(sql, new { Account = account }).ToList();
				return data;
			}
		}
	}
}
