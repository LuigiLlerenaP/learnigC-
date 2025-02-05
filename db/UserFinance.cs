using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace db
{
	[Table("user_finance")]
	public class UserFinance
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("user_name")]
		public string UserName { get; set; }

		[Column("password")]
		public string Password { get; set; }

		[Column("email")]
		public string Email { get; set; }

		[Column("initial_budget")]
		public decimal InitialBudget { get; set; }

		public UserFinance ( string userName, string password, string email, decimal initialBudget)
		{
			UserName = userName;
			Password = password;
			Email = email;
			InitialBudget = initialBudget;
		}
		public UserFinance(int id,  string userName, string password, string email, decimal initialBudget)
			: this( userName, password, email, initialBudget)
		{
			Id = id;
		}

	}
}
