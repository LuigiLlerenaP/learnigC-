using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db
{
	public abstract class Db
	{
		private string _connectionString;
		[Obsolete]
		protected SqlConnection _connection;
		public Db(string server, string db, string user, string password)
		{
			_connectionString = $"Data Source={server};Initial Catalog={db};User={user};Password={password}";
		}

		[Obsolete]
		public void Connect()
		{
			_connection = new SqlConnection(_connectionString);
			_connection.Open();
		}

		[Obsolete]
		public void Close()
		{
			if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
			{
				_connection.Close();
			}
		}
	}
}
