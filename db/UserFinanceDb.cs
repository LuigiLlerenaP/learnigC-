using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db
{
	public class UserFinanceDb : Db
	{
		public UserFinanceDb(string server, string db, string user, string password) : base(server, db, user, password)
		{

		}

		[Obsolete]
		public List<UserFinance> GetAll() {
			Connect();
			List<UserFinance> userFinances = [];
			string query = "SELECT id , user_name , password , email , initial_budget FROM  user_finance;";
			SqlCommand command = new SqlCommand(query, _connection);
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read()) {
				int id = reader.GetInt32(0);
				string userName = reader.GetString(1);
				string password = reader.GetString(2);
				string email = reader.GetString(3);
				decimal initialBudget = reader.GetDecimal(4);
				userFinances.Add(new UserFinance(id, userName, password, email, initialBudget));
			}
			Close();
			return userFinances;
		}
	}
}
