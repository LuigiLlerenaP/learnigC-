using db;
using System.Data.SqlClient;
try
{
	
	UserFinanceDb userFinaceDb = new UserFinanceDb(@"LUIGI", "c_db", @"Luigi/luigi", "12345678");
	bool again = true;
	int op = 0;
	do
	{
op = op + 1; } while (again);
	List<UserFinance> userFinances = userFinaceDb.GetAll(); 

	foreach(var  userFinance in userFinances)
	{
		Console.WriteLine(userFinance.UserName);
	}
} catch(SqlException ex)
{
	Console.WriteLine("Error:");
	Console.WriteLine(ex.Message);
}