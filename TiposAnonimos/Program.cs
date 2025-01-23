/* =====================================
 * Objetos anónimos en C#
 * =====================================
 * - Los objetos anónimos nos permiten declarar y usar objetos sin necesidad de 
 *   definir previamente una clase.
 * - Se utilizan comúnmente con la palabra clave `var`.
 * - Son inmutables: una vez creados, no se pueden modificar sus valores.
 * =====================================
 */

// Crear un objeto anónimo.
var hector = new
{
	Name = "Lu",
	Country = "Ecuador"
};
Console.WriteLine($"Nombre: {hector.Name}, País: {hector.Country}");

// Crear un array de objetos anónimos.
var people = new[]
{
	new { Name = "Antho", Age = 23 },
	new { Name = "Lu", Age = 44 }
};

Console.WriteLine("Lista de personas:");
foreach (var person in people)
{
	Console.WriteLine($"Nombre: {person.Name}, Edad: {person.Age}");
}


/* =====================================
 * Tuplas en C#
 * =====================================
 * - Una tupla es una colección de valores de diferentes tipos agrupados.
 * - Las tuplas son modificables (si están definidas como variables, no como `readonly` o `const`).
 * - Podemos acceder a sus elementos por nombre o posición (`Item1`, `Item2`, etc.).
 * - También se pueden usar tuplas anónimas, donde los elementos no tienen nombres específicos.
 * =====================================
 */

// Ejemplo de tupla con nombres.
(int id, string name) product = (1, "Cerveza");
Console.WriteLine($"ID: {product.id}, Nombre: {product.name}");

// Ejemplo de tupla anónima (sin nombres explícitos).
var car = ("Chevrolet", "Sail");
Console.WriteLine($"Marca: {car.Item1}, Modelo: {car.Item2}");

// Arreglo de tuplas con nombres definidos.
(int id, string ComercialName, bool isNew)[] cars = new[]
{
	(1, "Sail, Chevrolet", true),
	(3, "Camaro", false),
};

// Arreglo de tuplas anónimas.
var computers = new[]
{
	(id: 1, brand: "Asus", ram: 32, processor: "Intel i7", storage: 500, price: 900),
	(id: 2, brand: "HP", ram: 16, processor: "Intel i5", storage: 256, price: 700),
	(id: 3, brand: "Dell", ram: 8, processor: "Intel i3", storage: 128, price: 400)
};

// Mostrar elementos del arreglo de computadoras.
Console.WriteLine("Lista de computadoras:");
foreach (var computer in computers)
{
	Console.WriteLine($"ID: {computer.id}, Marca: {computer.brand}, Procesador: {computer.processor}, Almacenamiento: {computer.storage}GB, Precio: ${computer.price}");
}

// Mostrar elementos del arreglo de autos.
Console.WriteLine("\nLista de autos:");
foreach (var car1 in cars)
{
	Console.WriteLine($"ID: {car1.id}, Nombre Comercial: {car1.ComercialName}, Es nuevo: {car1.isNew}");
}

// Ejemplo: Destructuración de tuplas para obtener un solo valor.
var (_, lng, _) = GetLocation(); // Solo obtenemos la longitud.
Console.WriteLine($"\nLongitud: {lng}");

// Ejemplo: Obtener todos los valores de una tupla.
var cityInfo = GetLocation();
Console.WriteLine($"\nUbicación: Latitud: {cityInfo.lat}, Longitud: {cityInfo.lng}, Ciudad: {cityInfo.nameCity}");

// Método que retorna una tupla con tres valores.
static (float lat, float lng, string nameCity) GetLocation()
{
	float lat = 199.11F;
	float lng = -44F;
	string nameCity = "Ecuador";
	return (lat, lng, nameCity);
}
