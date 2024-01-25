using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Wine.Core
{
	public class SqlDb
	{
		/// <summary>
		/// 取得連線字串
		/// </summary>
		/// <param name="keyOfConn"></param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public static string GetConnectionString(string keyOfConn)
		{
			try
			{
				string conn = System.Configuration.ConfigurationManager.ConnectionStrings[keyOfConn].ToString();
				return conn;
			}
			catch (Exception)
			{
				throw new Exception($"找不到名為 {keyOfConn} 的連線字串");
			}
		}

		//回傳sqlConnection
		public static SqlConnection GetConnection(string keyOfConn)
		{
			string connString = GetConnectionString(keyOfConn);
			return new SqlConnection(connString);
		}

		//新增
		public static int Create(string keyOfConn, string sql, params SqlParameter[] parameters)
		{
			string connString = GetConnectionString(keyOfConn);
			sql += ";SELECT SCOPE_IDENTITY";

			using (var conn = new SqlConnection(connString))
			{
				using (var cmd = new SqlCommand(sql, conn))
				{
					if (parameters != null)
					{
						cmd.Parameters.AddRange(parameters);
					}
					conn.Open();

					return int.Parse(cmd.ExecuteScalar().ToString());
				}
			}
		}

		//查詢
		public static List<T> Search<T>(string keyOfConn, string sql, Func<SqlDataReader, T> funcAssember, params SqlParameter[] parameters)
		{
			string connString = GetConnectionString(keyOfConn);
			using (var conn = new SqlConnection(connString))
			{
				using (var cmd = new SqlCommand(sql, conn))
				{
					if (parameters != null)
					{
						cmd.Parameters.AddRange(parameters);
					}
					conn.Open();

					List<T> dataSet = new List<T>();
					using (var reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							T record = funcAssember(reader);
							dataSet.Add(record);
						}
						return dataSet;
					}
				}
			}
		}

		//刪除更新
		public static void DeleteOrUpdate(string ketOfConn, string sql, params SqlParameter[] parameters)
		{
			string connString = GetConnectionString(ketOfConn);
			using (var conn = new SqlConnection(connString))
			{
				using (var cmd = new SqlCommand(sql, conn))
				{
					if (parameters != null)
					{
						cmd.Parameters.AddRange(parameters);
					}
					conn.Open();

					cmd.ExecuteNonQuery();
				}
			}
		}

		//得到
		public static T Get<T>(string keyOfConn, string sql, Func<SqlDataReader, T> funcAssember, params SqlParameter[] parameters)
		{
			string connString = GetConnectionString(keyOfConn);
			using (var conn = new SqlConnection(connString))
			{
				using (var cmd = new SqlCommand(sql, conn))
				{
					if (parameters != null)
					{
						cmd.Parameters.AddRange(parameters);
					}
					conn.Open();

					using (var reader = cmd.ExecuteReader())
					{
						if (reader.Read())
						{
							T record = funcAssember(reader);
							return record;
						}
						else
						{
							return default(T);
						}
					}
				}
			}
		}
	}
}
