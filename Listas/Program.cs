/* =====================================
 * Listas en C#:
 * - Una lista es una colección genérica definida en el espacio de nombres `System.Collections.Generic`.
 * - Permite almacenar y gestionar un conjunto de elementos del mismo tipo de manera dinámica.
 * - Ofrecen funcionalidades avanzadas como agregar, eliminar, ordenar, buscar elementos y más.
 * - Su tamaño se ajusta automáticamente según los elementos añadidos o eliminados.
 * - Son ideales para trabajar con datos que cambian en tiempo de ejecución.
 * - La clase genérica más utilizada es `List<T>`, donde `T` representa el tipo de datos de los elementos.
 * - Ejemplo: `List<int>` para números enteros, `List<string>` para cadenas de texto, etc.
 * =====================================
 */

// Crear una lista vacía de números enteros
List<int> numbersTwo = new List<int>();


numbersTwo.Add(1);
numbersTwo.Add(2);
numbersTwo.Add(3);


Console.WriteLine($"The length of the list is: {numbersTwo.Count}");

// Crear una lista inicializada con elementos
List<int> numbers = new List<int> { 1, 2, 3 };

// Agregar un elemento adicional a la lista
numbers.Add(4);


Console.WriteLine($"The length of the list is: {numbers.Count}");

// Borrar todos los elementos de la lista
numbers.Clear();
Console.WriteLine($"The length of the list after clearing is: {numbers.Count}");

// Crear una lista de cadenas (strings)
List<string> countries = new List<string> { "Ecuador", "Peru", "Colombia" };


countries.Add("Argentina");
countries.Add("Chile");

// Iterar sobre la lista usando `foreach`
Console.WriteLine("Countries in the list:");
foreach (string country in countries)
{
	Console.WriteLine($"- {country}");
}

/* =====================================
 * Uso de `var` con listas:
 * - Podemos simplificar la declaración usando `var`, ya que el tipo es inferido automáticamente por el compilador.
 * - Nota: El tipo no se puede cambiar en tiempo de ejecución ni después de su especificación.
 * - Usar `var` es más útil cuando el tipo es largo o complejo.
 * =====================================
 */

// Lista de caracteres utilizando `var`
var letters = new List<char> { 'A', 'B', 'C', 'D' };

// Iterar sobre la lista de caracteres
foreach (var letter in letters)
{
	Console.WriteLine($"The letter is {letter}");
}

// Otra forma de inicializar una lista con el inicializador de colección
List<double> doubles = new()
{
	55.8,
	56.6,
	567.5
};

// Mostrar los elementos de la lista `doubles`
foreach (double value in doubles)
{
	Console.WriteLine($"Value: {value}");
}

/* =====================================
 * Listas con objetos personalizados:
 * - Podemos usar listas para almacenar objetos personalizados.
 * - Esto nos permite crear colecciones complejas y trabajar con datos estructurados.
 * =====================================
 */

var cars = new List<Car>
{
	new Car("Toyota", "Red", 1234),
	new Car("Honda", "Blue", 5678),
};


static void Show(List<Car> cars)
{
	Console.WriteLine("Car details:");
	foreach (var car in cars)
	{
		Console.WriteLine($"Car Name: {car.CarName}, Color: {car.Color}, Plate: {car.Plate}");
	}
}
/* =====================================
 * Funcionalidades más comunes con listas en C#
 * =====================================
 * - List<T> nos proporciona diversas funcionalidades para manejar colecciones.
 * - Estas funcionalidades ya están implementadas, por lo que no es necesario reescribirlas.
 */

// Método para mostrar los números de una lista.
static void ShowNumbers(List<int> numbers)
{
	Console.WriteLine("Mostrar números:");
	foreach (int number in numbers)
	{
		Console.WriteLine($"El número es: {number}");
	}
}

// Crear una lista de números.
List<int> numbersList = new List<int>
{
	0, 1, 2, 4, 6, 7, 11, 99, 22, 444, 55, 6, 1, 22
};

// Mostrar los números iniciales.
ShowNumbers(numbersList);

// Insertar un número en una posición específica de la lista.
numbersList.Insert(0, 10); // Inserta el número 10 en la posición 0.
ShowNumbers(numbersList);

// Verificar si un elemento está en la lista (retorna true o false).
string message = numbersList.Contains(10) ? "Sí, el número existe." : "No, el número no existe.";
Console.WriteLine(message);

// Obtener la posición de un número en la lista (si existe). Si no existe, retorna -1.
int position = numbersList.IndexOf(4);
Console.WriteLine($"El número 4 está en la posición: {position}");

// Ordenar la lista en orden ascendente (modifica la lista original).
numbersList.Sort();
Console.WriteLine("Lista ordenada:");
ShowNumbers(numbersList);

// Agregar una lista de números a la lista existente (AddRange).
numbersList.AddRange(new List<int> { 111, 112, 113, 114 });
Console.WriteLine("Lista después de agregar nuevos números:");
ShowNumbers(numbersList);

// Los strings en C# son inmutables, lo que significa que cualquier modificación genera una nueva copia.
string name = "Luigi";
name = name.ToLower(); // Convierte el string a minúsculas y genera una nueva copia.
Console.WriteLine($"Nombre en minúsculas: {name}");

// Nota: La inmutabilidad de los strings asegura que el valor original no se modifique.


Show(cars);
cars.RemoveAt(0);
Show(cars);
class Car
{
	public string CarName { get; set; }
	public string Color { get; set; }
	public int Plate { get; set; }

	public Car(string carName, string color, int plate)
	{
		CarName = carName;
		Color = color;
		Plate = plate;
	}
}


