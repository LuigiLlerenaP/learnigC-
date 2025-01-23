/* =====================================
 * Excepciones en C#
 * =====================================
 * - Las excepciones permiten manejar situaciones inesperadas
 *   que ocurren durante la ejecución del programa.
 * - Si ocurre una excepción, el control pasa al bloque `catch` 
 *	 donde podemos manejar el error específico.
 * - Usar bloques `catch` específicos (por ejemplo, `FileNotFoundException`) 
 *	 es ideal para capturar errores esperados.
 * - Se puede usar `Exception` para manejar errores generales
 *	 si no sabemos la causa exacta.
 * - El bloque `finally` siempre se ejecuta, 
 *	 haya o no una excepción, y se utiliza para liberar recursos o ejecutar código final.
 * - Podemos lanzar excepciones manualmente usando `throw new Exception()`.
 * =====================================
 */


try
{
	// Leer contenido de un archivo.
	string content = File.ReadAllText(@"C:\Users\luigi\Documents\example.txt");
	Console.WriteLine("Contenido del archivo:");
	Console.WriteLine(content);

	// Lanzar una excepción de forma manual.
	throw new Exception("Se lanzó una excepción de prueba.");
}
catch (FileNotFoundException ex)
{
	// Manejo específico para archivos no encontrados.
	Console.WriteLine($"Error: Archivo no encontrado. Detalles: {ex.Message}");
}
catch (Exception ex)
{
	// Manejo general de excepciones.
	Console.WriteLine($"Error general: {ex.Message}");
}
finally
{
	// Código que siempre se ejecutará.
	Console.WriteLine("Bloque 'finally': Liberando recursos o finalizando tareas.");
}

/* =====================================
 * Excepciones personalizadas en C#
 * =====================================
 * - Para crear una excepción personalizada, se debe crear una clase que herede de Exception.
 * - Esto permite representar escenarios específicos relacionados con nuestro negocio.
 * - Ayuda a hacer el software más entendible y mantenible para el giro del negocio.
 * =====================================
 */
Console.WriteLine("------------------");

try
{
	var beer = new Beer("Pilsener", "Es la cerveza más popular en Ecuador, con buen precio", "Pilsener", 0, 0);
	Console.WriteLine(beer);
	BeerInventory beerInventory = new BeerInventory();
	beerInventory.AddBeer(beer);
}
catch (InvalidBeerException ex)
{
	Console.WriteLine($"Error: {ex.Message}");
}
catch (Exception ex)
{
	Console.WriteLine($"Error general: {ex.Message}");
}

// Clase para manejar excepciones personalizadas
public class InvalidBeerException : Exception
{
	public InvalidBeerException()
		: base("Cerveza inválida: el precio y el ID deben ser mayores a cero.")
	{
	}

	public InvalidBeerException(string message) : base(message) { }
}

// Clase principal para las cervezas
public class Beer
{
	public string Name { get; set; }
	public string Description { get; set; }
	public string Brand { get; set; }
	public int Id { get; set; }
	public int Price { get; set; }

	public Beer(string name, string description, string brand, int id, int price)
	{
		if (string.IsNullOrEmpty(name)) throw new InvalidBeerException("El nombre de la cerveza no puede estar vacío.");
		if (string.IsNullOrEmpty(brand)) throw new InvalidBeerException("La marca de la cerveza no puede estar vacía.");
		if (id <= 0 || price <= 0) throw new InvalidBeerException();

		Name = name;
		Description = description;
		Brand = brand;
		Id = id;
		Price = price;
	}

	public override string ToString()
	{
		return $"Cerveza: {Name}, Marca: {Brand}, Descripción: {Description}, Precio: ${Price}, ID: {Id}";
	}
}

// Clase adicional para gestionar inventarios de cervezas
public class BeerInventory
{
	private readonly List<Beer> _beers = new();

	public void AddBeer(Beer beer)
	{
		if (beer == null) throw new ArgumentNullException(nameof(beer), "La cerveza no puede ser nula.");
		_beers.Add(beer);
		Console.WriteLine($"Cerveza añadida: {beer.Name}");
	}

	public IEnumerable<Beer> GetAllBeers()
	{
		return _beers;
	}

	public Beer GetBeerById(int id)
	{
		var beer = _beers.FirstOrDefault(b => b.Id == id);
		return beer ?? throw new InvalidBeerException("No se encontró una cerveza con el ID especificado.");
	}
}