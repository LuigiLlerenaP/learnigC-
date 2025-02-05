/* =====================================
    TÍTULO: Paradigma Funcional en C#
===================================== */

/*
    📌 Descripción:
    -----------------
    En C#, un delegado es un tipo que representa una referencia a un método con una firma específica.
    Es una forma de tratar las funciones como valores, lo que permite asignarlas a variables, pasarlas como
    parámetros y devolverlas desde otras funciones.

    Esto se alinea con el paradigma funcional, aunque C# no es un lenguaje funcional puro.

    🔹 ¿Qué es un delegado?
    ------------------------
    - Es una estructura que define la firma de un método (qué tipo de valor retorna y qué parámetros recibe).
    - Se puede almacenar en variables y cambiar su referencia en tiempo de ejecución.
    - Se usa para implementar funciones de orden superior.

    📌 Ejemplo de Uso:
    -------------------
*/
// Uso de delegados básicos
Operation result = Functions.Sum;
Console.WriteLine($"Suma: {result(4, 5)}");  // Output: 9

result = Functions.Mult;
Console.WriteLine($"Multiplicación: {result(4, 5)}");  // Output: 20

Show resultTwo = Functions.Greet;
resultTwo("¡Hola, mundo!");

/*
    🔹 Delegados con parámetros:
    -----------------------------
    - Programación funcional en C# permite usar funciones como parámetros.
    - Función de primer orden: Recibe otra función como parámetro.
    - Función de orden superior: Puede almacenar funciones en variables y usarlas como argumentos.
    - Multidifusión: Un delegado puede almacenar varias funciones y ejecutarlas todas.
*/
Show greet = Functions.Greet;
greet += Functions.GreetUpperCase;
greet("hola");
Functions.Some("Luigi", "Llerena", greet);

/*
    🔹 Delegados genéricos (Action, Func y Predicate):
    ---------------------------------------------------
    Nos permiten definir el tipo de dato en tiempo de ejecución y reutilizar código.
*/

#region Action
// Action: Para funciones que no retornan valores.
Action<int, double> operation = (a, b) => Console.WriteLine($"Operación: {a + b}");
operation(5, 5);

Action<string, string> greetAction = (firstName, lastName) => Console.WriteLine($"{firstName} {lastName}");
Functions.SomeTwo("Maria", "Ana", (p) => Console.WriteLine($"Eres {p}"));
#endregion

#region Func
// Func: Retorna un valor (el último tipo especificado es el tipo de retorno).
Func<string, string, string> BindsNames = (firstName, lastName) => firstName + " " + lastName;
Console.WriteLine(BindsNames("Ana", "Maria"));

Func<int> numnerRandom = () => new Random().Next(0, 3);
Console.WriteLine(numnerRandom());

Func<int, int, double> AddNumbers = (arg1, arg2) => (arg1 + arg2) / 2.0;
Console.WriteLine(AddNumbers(3, 4));
#endregion

#region Predicate
// Predicate: Siempre devuelve un booleano y recibe un solo parámetro.
var words = new List<string>() { "Beer", "Patito", "Sandia", "Hola", "Java" };

Predicate<string> hasLetterA = (word) => word.Contains("a") || word.Contains("A");
Console.WriteLine(hasLetterA("Beer")); // False
Console.WriteLine(hasLetterA("Java")); // True

var wordsWithA = words.FindAll(hasLetterA);
foreach (var word in wordsWithA)
{
	Console.WriteLine(word);
}
#endregion

// Definición de delegados
public delegate int Operation(int a, int b);
public delegate void Show(string message);

// Clase que contiene funciones para los delegados
public static class Functions
{
	public static int Sum(int x, int y) => x + y;
	public static int Mult(int x, int y) => x * y;
	public static void Greet(string message) => Console.WriteLine(message);
	public static void GreetUpperCase(string message) => Console.WriteLine(message.ToUpper());

	// Función de orden superior que usa un delegado
	public static void Some(string name, string lastName, Show greetF)
	{
		Console.WriteLine("Iniciando función Some");
		greetF($"Hola, {name} {lastName}");
		Console.WriteLine("Finalizando función Some");
	}

	public static void SomeTwo(string name, string lastName, Action<string> greetF)
	{
		Console.WriteLine("Iniciando función SomeTwo");
		greetF($"Hola, {name} {lastName}");
		Console.WriteLine("Finalizando función SomeTwo");
	}
}