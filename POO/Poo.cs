/* =====================================
    TÍTULO: Paradigma POO 
 ===================================== */

/*
   Descripción:
   La Programación Orientada a Objetos (POO) es un paradigma que permite estructurar y organizar mejor nuestra información mediante objetos.
    - Los objetos representan entidades del mundo real o conceptual.
    - Cada objeto tiene propiedades (atributos) que describen sus características y métodos (comportamientos) que definen sus acciones.
    - En código, los objetos se crean o "instancian" a partir de clases, que actúan como moldes o plantillas que definen las características y comportamientos del objeto.
*/

/*
   Consideraciones:
   La POO se basa en cuatro pilares fundamentales que deben tenerse en cuenta al definir entidades:

   1. Encapsulamiento:
      - Consiste en proteger los datos de un objeto estableciendo niveles de acceso (público, privado, protegido).
      - Esto ayuda a mantener la integridad de los datos y a controlar cómo interactúa el código externo con el objeto.

   2. Herencia:
      - Permite que una clase (clase hija) herede atributos y métodos de otra clase (clase base o padre).
      - Esto facilita la reutilización del código y evita la redundancia.
      - Además, se pueden agregar o modificar funcionalidades en la clase hija.

   3. Polimorfismo:
      - Significa "muchas formas" y permite que una misma acción se ejecute de diferentes maneras según el contexto.
      - Esto se logra mediante la sobrecarga de métodos y la sobreescritura de métodos heredados.

   4. Abstracción:
      - Consiste en simplificar el modelo representando solo las características esenciales de una entidad y ocultando los detalles innecesarios.
      - Ayuda a enfocar la atención en lo que es relevante para resolver un problema específico.
*/

/* Creamos una instancia de la clase "MedicalAppoiment" o Instanciamos un objeto de la clase "MedicalAppoiment"
   Usando un constructor parametrizado. Hay uno por defecto si no parametrizamos
   La variable "medicalAppoiment" representa al objeto.*/

using POO;
//Medical -> Comceptos generales
Console.WriteLine("---------------");
MedicalAppoiment medicalAppoiment = new MedicalAppoiment("Luigi","Dolor de cabeza y fiebre",DateTime.Now, "Dra. Ana Gómez", "Medicina General", "Consultorio 3");
Console.WriteLine(medicalAppoiment.GetInfo());
Console.WriteLine("---------------");
//Book -> Propiedades
Console.WriteLine("---------------");
Book myBook = new Book(
    "El Principito",
    "Un cuento filosófico que explora el significado de la vida.",
    "Antoine de Saint-Exupéry",
    "978-3-16-148410-0",
    new DateTime(1943, 4, 6)
);
myBook.Price = 12.99;
Console.WriteLine(myBook.ShowInfo());
Console.WriteLine(myBook.Date);
Console.WriteLine("---------------");
// -> Herencia
SavingsAccount savingsAccount = new SavingsAccount("10002221","Luigi Llerena",0.00M,15.0M);
savingsAccount.Deposit(200);
Console.WriteLine(savingsAccount);
CheckingAccount checkingAccount = new CheckingAccount("20002022","Ana P",00.0M,100M);
checkingAccount.Deposit(300);
Console.WriteLine(checkingAccount);
checkingAccount.Withdraw(150); 
Console.WriteLine("Después de retirar 150 de la cuenta corriente:");
Console.WriteLine(checkingAccount);
Console.WriteLine("---------------");
//-> Sobrecarga de metodos 
InputValidator validator = new InputValidator();
try
{
    Console.WriteLine("=== Validación de una cadena ===");
    Console.WriteLine(validator.ValidateInput("Luigi"));
    Console.WriteLine("\n=== Validación de un correo electrónico ===");
    Console.WriteLine(validator.ValidateInput("luigi@gmail.com", true));
    Console.WriteLine("\n=== Validación de un número positivo ===");
    Console.WriteLine(validator.ValidateInput(19));
    Console.WriteLine(validator.ValidateInput(""));
    Console.WriteLine(validator.ValidateInput("luigi", true));
    Console.WriteLine(validator.ValidateInput(-19));
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}
Console.WriteLine("---------------");

//-->Sobrescritura de metodos 
CreditCardPayment payment1 = new CreditCardPayment(
	DateTime.Now,
	"Online Shopping",
	"John Doe",
	"Luigi Llerena"
);
Console.WriteLine(payment1);
Console.WriteLine("---------------");

CashPayment cashPayment = new CashPayment(
	 DateTime.Now,
	 "Restaurant Bill",
	 "Restaurant Jon",
	 "Anthony"
 );
Console.WriteLine(cashPayment);
Console.WriteLine("---------------");

TransferPayment bankTransferPayment = new TransferPayment(
	DateTime.Now,
	"Invoice Payment",
	"Maria J.",
	"Pedro"
);
Console.WriteLine(bankTransferPayment);
Console.WriteLine("---------------");

Console.WriteLine("---------------");
Sale sale = new Sale(10);
sale.AddAmount(3);
sale.AddAmount(4);
Console.WriteLine(sale.GetTotal());

SaleWithTax saleWithTax = new SaleWithTax(10);
saleWithTax.AddAmount(3);
saleWithTax.AddAmount(4);
Console.WriteLine(saleWithTax.GetTotal());

Console.WriteLine("---------------");
try
{
	double kilometers = 10;
	double miles = UnitConverter.KilometersToMiles(kilometers);
	Console.WriteLine($"{kilometers} kilómetros son {miles} millas.");

	double miles2 = 6.2;
	double kilometers2 = UnitConverter.MilesToKilometers(miles2);
	Console.WriteLine($"{miles2} millas son {kilometers2} kilómetros.");
}
catch (ArgumentException ex)
{
	Console.WriteLine($"Error: {ex.Message}");
}