/* =====================================
 * JSON (JavaScript Object Notation):
 * -------------------------------------
 * JSON es un formato de texto que permite estructurar y representar datos de manera sencilla y entendible, 
 * ideal para la comunicación entre sistemas o lenguajes de programación.
 *
 * Principales características:
 * - Usa un sistema de clave-valor (key-value).
 * - Sirve para serializar (convertir un objeto en texto) y 
 *		deserializar (convertir texto en un objeto) datos.
 * - Las claves (keys) deben ir entre comillas dobles ("").
 * - Admite estructuras complejas como:
 *   - Objetos: Representados por llaves `{}`.
 *   - Colecciones de objetos (arreglos): Representadas por corchetes `[]`.
 * - Facilita la comunicación entre sistemas de terceros mediante APIs u otros medios.
 * - Es un formato ampliamente utilizado en programación web y backend.
 *
 * Ejemplo de representación de un objeto en JSON:
 * { 
 *   "Name": "Pikantus", 
 *   "Brand": "ER", 
 *   "Description": "Good" 
 * }
 * 
 * Ejemplo de una colección de objetos en JSON:
 * [
 *   { "Name": "Pikantus", "Brand": "ER", "Description": "Good" },
 *   { "Name": "Weissbier", "Brand": "ER", "Description": "Great!" }
 * ]
 * =====================================
 */

// Ejemplo práctico en C#
// Representación de un objeto "BeerTwo"
using System.Text.Json;

BeerTwo myBeer = new()
{
	Name = "Pikantus",
	Brand = "ER",
	Description = "Good"
};

// Serialización manual a JSON
string json = "{\"Name\": \"Pikantus\", \"Brand\": \"ER\", \"Description\": \"Good\"}";

// Colección de objetos serializada a JSON manualmente
string json2 = "[" +
	"{\"Name\": \"Pikantus\", \"Brand\": \"ER\", \"Description\": \"Good\"}," +
	"{\"Name\": \"Weissbier\", \"Brand\": \"ER\", \"Description\": \"Great!\"}" +
	"]";

// Crear un arreglo de objetos BeerTwo
BeerTwo[] beers = new BeerTwo[]
{
			new BeerTwo
			{
				Name = "Pikantus",
				Brand = "ER",
				Description = "A strong and flavorful beer."
			},
			new BeerTwo
			{
				Name = "Weissbier",
				Brand = "ER",
				Description = "A refreshing wheat beer."
			},
			new BeerTwo
			{
				Name = "Dunkel",
				Brand = "ER",
				Description = "A dark beer with rich malty flavor."
			}
};

// Serialización usando System.Text.Json
string json3 = JsonSerializer.Serialize(myBeer);
Console.WriteLine("JSON de un solo objeto:");
Console.WriteLine(json3);

string json4 = JsonSerializer.Serialize(beers);
Console.WriteLine("\nJSON de colección de objetos:");
Console.WriteLine(json4);

// Deserialización de un solo objeto
BeerTwo? beer = JsonSerializer.Deserialize<BeerTwo>(json3);
if (beer != null)
{
	Console.WriteLine("\nObjeto deserializado:");
	Console.WriteLine($"Name: {beer.Name}, Brand: {beer.Brand}, Description: {beer.Description}");
}

// Definición de la clase BeerTwo
public class BeerTwo
{
	public required string Name { get; set; }
	public required string Brand { get; set; }
	public required string Description { get; set; }
}

