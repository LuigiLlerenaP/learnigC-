using DBEN;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

DbContextOptionsBuilder<CDbContext> optionsBuilder = new();
optionsBuilder.UseSqlServer("\"Server=LUIGI;Database=c_db;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True\"");



bool again = false;
int option = 0;

do
{
	ShowMenu();
	Console.WriteLine("Chose one option");
	option = int.Parse(Console.ReadLine() ?? "0");
	switch (option)
	{
		case 1:
			Show(optionsBuilder);
		break;
		case 2:
			Add(optionsBuilder);
		break;
			case 3:
				Edit(optionsBuilder);
			break;
			case 4:
				Delete(optionsBuilder);
			break;
			case 5:
				again = false;
			break;
		default:
			Console.WriteLine("Invalid option ");
			break;
	}
}while (again);



static void Show(DbContextOptionsBuilder<CDbContext> optionsBuilder)
{
	Console.Clear();
	Console.WriteLine("Users");
	using (CDbContext cDbContext = new(optionsBuilder.Options))
	{
		List<UserFinance> users = [.. cDbContext.UserFinances.OrderBy(u=>u.UserName)];
		List<UserFinance> usersOrd = [.. (from u in cDbContext.UserFinances
									  where u.UserName.Contains("l")
									  orderby u.UserName 
									  select u)];
		foreach(var user in usersOrd)
		{
			Console.WriteLine($"Username: {user.UserName}, Email: {user.Email}, Initial Budget: {user.InitialBudget}");

		}
	};
}
static void Add(DbContextOptionsBuilder<CDbContext> optionsBuilder)
{
	Console.Clear();
	Console.WriteLine("Add User");

	Console.Write("Insert the user name: ");
	string userName = Console.ReadLine() ?? "";

	Console.Write("Insert the password: ");
	string password = Console.ReadLine() ?? "";

	Console.Write("Insert the email: ");
	string email = Console.ReadLine() ?? "";

	Console.Write("Insert the initial : ");
	decimal initialBudget = decimal.Parse(Console.ReadLine() ?? "0");

	using CDbContext cDbContext = new(optionsBuilder.Options);
	UserFinance userFinance = new()
	{
		UserName = userName,
		Password = password,
		Email = email,
		InitialBudget = initialBudget,
	};
	try
	{
		cDbContext.Add(userFinance);
		cDbContext.SaveChanges();
		Console.WriteLine("User added successfully!");
	}
	catch (DbUpdateException dbEx)
	{
		Console.WriteLine($"Database error: {dbEx.InnerException?.Message ?? dbEx.Message}");
	}
	catch (Exception ex)
	{
		Console.WriteLine($"Unexpected error: {ex.Message}");
	}

}
static void Edit(DbContextOptionsBuilder<CDbContext> optionsBuilder)
{
	Console.Clear();
	Console.WriteLine("User Edit");
	Show(optionsBuilder);
	Console.WriteLine("Write the name of user you need to edit");
	string userNameEdit = Console.ReadLine()?.Trim() ?? "";
	using var context = new CDbContext(optionsBuilder.Options);
	var userFinance = context.UserFinances.Where(u => u.UserName == userNameEdit).FirstOrDefault();
	if (userFinance == null)
	{
		Console.WriteLine("The user was not found.");
		return;
	}

	Console.Write("Insert the user name: ");
	string userName = Console.ReadLine() ?? "";

	Console.Write("Insert the password: ");
	string password = Console.ReadLine() ?? "";

	Console.Write("Insert the email: ");
	string email = Console.ReadLine() ?? "";

	Console.Write("Insert the initial : ");
	decimal initialBudget = decimal.Parse(Console.ReadLine() ?? "0");

	userFinance.UserName = userName;
	userFinance.Password = password;
	userFinance.InitialBudget = initialBudget;
	userFinance.Email = email;

	context.Entry(userFinance).State = EntityState.Modified;

	try
	{
		context.SaveChanges();
		Console.WriteLine("User updated successfully!");
	}
	catch (Exception ex)
	{
		Console.WriteLine($"Error updating user: {ex.Message}");
	}
}
 static void Delete (DbContextOptionsBuilder<CDbContext> optionsBuilder)
{
	Console.Clear();
	Console.WriteLine("Delete User");
	Show(optionsBuilder);
	Console.WriteLine("What user woudl you like to delete , inserte the username");
	string userNameDelete = Console.ReadLine()?.Trim() ?? "";
	using var context = new CDbContext(optionsBuilder.Options);
	var userFinance =  context.UserFinances.Where(u=>u.UserName == userNameDelete).FirstOrDefault();
	if (userFinance == null) {
		Console.WriteLine("The user was not found.");
		return;
	}
	context.UserFinances.Remove(userFinance);
	try
	{
		context.SaveChanges();
		Console.WriteLine("User delete successfully!");
	}
	catch (Exception ex)
	{
		Console.WriteLine($"Error updating user: {ex.Message}");
	}

}
static void ShowMenu()
{
	Console.WriteLine("\n=== Menú CRUD ===");
	Console.WriteLine("1. Show");
	Console.WriteLine("2. Add");
	Console.WriteLine("3. Edit");
	Console.WriteLine("4. Delete");
	Console.WriteLine("5. Close");
}