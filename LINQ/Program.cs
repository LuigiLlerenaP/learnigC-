/* =====================================
 * LINQ (Language Integrated Query)
 * =====================================
 * - Extensión del lenguaje de C# que permite trabajar con colecciones de objetos
 *   de manera declarativa, similar a cómo se trabaja con SQL.
 * - Proporciona métodos para realizar operaciones como selección, filtrado,
 *   ordenamiento, agrupamiento, etc., sobre colecciones.
 * =====================================
 */

using System.Data;

// Lista de Items con Descripción detallada
List<InventoryItem<Computer>> computers = new List<InventoryItem<Computer>>
{
	new InventoryItem<Computer>
	{
		Id = 1,
		SellerName  = "Asus Store",
		ItemDetails  = new Computer
		{
			NameComputer = "Asus ROG Zephyrus",
			Capacity = "1TB SSD",
			Ram = "16GB DDR5",
			Display = "15.6\" 4K OLED",
			Brand = "Asus"
		},
		ItemPrice = 1200,
		Quantity = 1
	},
	new InventoryItem<Computer>
	{
		Id = 2,
		SellerName  = "Dell Store",
		ItemDetails  = new Computer
		{
			NameComputer = "Dell Inspiron 15",
			Capacity = "512GB SSD",
			Ram = "8GB DDR4",
			Display = "15.6\" FHD",
			Brand = "Dell"
		},
		ItemPrice = 900,
		Quantity = 2
	},
	new InventoryItem<Computer>
	{
		Id = 4,
		SellerName  = "Asus Store",
		ItemDetails  = new Computer
		{
			NameComputer = "MacBook Pro M2",
			Capacity = "1TB SSD",
			Ram = "16GB Unified Memory",
			Display = "14\" Retina XDR",
			Brand = "Apple"
		},
		ItemPrice = 2500,
		Quantity = 1
	}
};

List<InventoryItem<Cellphone>> cellphones = new List<InventoryItem<Cellphone>>
{
	new InventoryItem<Cellphone>
	{
		Id = 1,
		SellerName  = "Asus Store",
		ItemDetails  = new Cellphone
		{
			NameCellphone = "Asus ROG Phone 7",
			Capacity = "512GB",
			Ram = "16GB DDR5",
			Display = "6.78-inch AMOLED",
			cameras = "50MP + 13MP + 5MP",
			Brand = "Asus"
		},
		ItemPrice = 900,
		Quantity = 10
	},
	new InventoryItem<Cellphone>
	{
		Id = 2,
		SellerName  = "Dell Store",
		ItemDetails  = new Cellphone
		{
			NameCellphone = "Samsung Galaxy S23 Ultra",
			Capacity = "512GB",
			Ram = "12GB",
			Display = "6.8-inch AMOLED",
			cameras = "200MP + 10MP + 12MP + 10MP",
			Brand = "Samsung"
		},
		ItemPrice = 1200,
		Quantity = 8
	}
};

// Mostrar todos los elementos en la lista
Console.WriteLine("Lista de Computadoras:");
foreach (InventoryItem<Computer> item in computers)
{
	Console.WriteLine(item);
}
Console.WriteLine("------------");

// SELECCIÓN
// Uso de SELECT para obtener campos específicos
var itemNames = from computer in computers
				select new
				{
					Name = computer.SellerName ,
					PriceComputer = computer.ItemPrice
				};
Console.WriteLine("Nombres y Precios:");
foreach (var name in itemNames)
{
	Console.WriteLine($"Nombre: {name.Name}, Precio: ${name.PriceComputer}");
}
Console.WriteLine("------------");

// FILTRADO
// Usando WHERE para filtrar elementos con "Asus" en el nombre
var itemsAsus = from c in computers
				where c.SellerName .Contains("Asus")
				select c;
Console.WriteLine("Filtrado por 'Asus':");
foreach (var asus in itemsAsus)
{
	Console.WriteLine(asus);
}
Console.WriteLine("------------");

// FILTRADO CON MULTIPLES CONDICIONES
// Usando WHERE para incluir "Asus" o "Dell"
var itemsDellAsus = from c in computers
					where c.SellerName .Contains("Asus") || c.SellerName .Contains("Dell")
					select c;
Console.WriteLine("Filtrado por 'Asus' o 'Dell':");
foreach (var asusDell in itemsDellAsus)
{
	Console.WriteLine(asusDell);
}
Console.WriteLine("------------");

// FILTRADO CON LAMBDA
// Excluir elementos que contengan "Asus"
var notAsus = computers.Where(c => !c.SellerName .Contains("Asus")).ToList();
Console.WriteLine("Excluyendo 'Asus':");
foreach (var nA in notAsus)
{
	Console.WriteLine(nA);
}
Console.WriteLine("------------");

// ORDENAMIENTO
// Ordenar por Marca de manera descendente
var orderBrand = computers
	.Select(c => new
	{
		Name = c.SellerName ,
		Brand = c.ItemDetails .Brand
	})
	.OrderByDescending(c => c.Brand)
	.ToList();
Console.WriteLine("Ordenado por Marca (descendente):");
foreach (var ob in orderBrand)
{
	Console.WriteLine(ob);
}
Console.WriteLine("------------");

// TRABAJANDO CON DataTable
// Creando un DataTable y aplicando LINQ
DataTable tabla = new("Personas");
tabla.Columns.Add("ID", typeof(int));
tabla.Columns.Add("Nombre", typeof(string));
tabla.Columns.Add("Edad", typeof(int));
tabla.Rows.Add(1, "Luigi", 28);
tabla.Rows.Add(2, "Ana", 30);
tabla.Rows.Add(3, "Carlos", 25);

// FILTRO: Donde ID es igual a 1
var noId = tabla.AsEnumerable()
				.Where(row => row.Field<int>("ID") == 1)
				.ToList();
Console.WriteLine("Filtrado por ID = 1:");
foreach (var row in noId)
{
	Console.WriteLine($"ID: {row.Field<int>("ID")}, Nombre: {row.Field<string>("Nombre")}, Edad: {row.Field<int>("Edad")}");
}
Console.WriteLine("------------");

// FILTRO: Excluir filas donde Nombre contiene "Luigi"
var diferentColumn = tabla.AsEnumerable()
	.Where(row => !(row.Field<string>("Nombre")?.Contains("Luigi") ?? false))
	.ToList();
Console.WriteLine("Excluyendo 'Luigi':");
foreach (var row in diferentColumn)
{
	Console.WriteLine($"ID: {row.Field<int>("ID")}, Nombre: {row.Field<string>("Nombre")}, Edad: {row.Field<int>("Edad")}");
}
Console.WriteLine("------------");
Console.WriteLine("Union");

// Unión: Combina dos colecciones de información basándose en un criterio común.
// Busca un patrón o columna en común para realizar la unión de los datos.


// Unir colecciones por coincidencia en la cantidad de RAM
var devicesWithRam = from computer in computers
					 join cellphone in cellphones
					 on computer.ItemDetails.Ram.Trim().ToLower() equals cellphone.ItemDetails.Ram.Trim().ToLower()
					 select new
					 {
						 ComputerSeller = computer.SellerName,
						 ComputerPrice = computer.ItemPrice,
						 ComputerRam = computer.ItemDetails.Ram,
						 CellphoneSeller = cellphone.SellerName,
						 CellphonePrice = cellphone.ItemPrice,
						 CellphobeRam = cellphone.ItemDetails.Ram,
					 };
if (!devicesWithRam.Any())
{
	Console.WriteLine("No hay coicidencia");
	return;
}
foreach (var item in devicesWithRam)
{
	Console.WriteLine($"Computer Seller: {item.ComputerSeller}, Price: ${item.ComputerPrice} , Ram: {item.ComputerRam}");
	Console.WriteLine($"Cellphone Seller: {item.CellphoneSeller}, Price: ${item.CellphonePrice}, Ram: { item.CellphobeRam}");
	Console.WriteLine();
}
Console.WriteLine("------------");
Console.WriteLine("Union SALLER");
//Unir por vendedor  , y usar  exprecion landa 
var devicesWithSeller = cellphones.Join(
	computers,
	computer => computer.SellerName.Trim().ToLower(), // Limpia y normaliza la clave en computadores
	cellphone => cellphone.SellerName.Trim().ToLower(), // Limpia y normaliza la clave en celulares
	(computer, cellphone) => new
	{
		ComputerSeller = computer.SellerName,
		ComputerPrice = computer.ItemPrice,
		CellphoneSeller = cellphone.SellerName,
		CellphonePrice = cellphone.ItemPrice,
	}
);

if (!devicesWithSeller.Any())
{
	Console.WriteLine("No hay coincidencia");
	return;
}
foreach (var item in devicesWithSeller)
{
	Console.WriteLine($"{item}");
	Console.WriteLine();
}
Console.WriteLine("------------");



// CLASES
public class InventoryItem<T>
{
	public int Id { get; set; }
	public required string SellerName  { get; set; }
	public required T ItemDetails  { get; set; }
	public int ItemPrice { get; set; }
	public int Quantity { get; set; }

	public override string ToString()
	{
		return $"Name: {SellerName }, Description: {ItemDetails }, Price: ${ItemPrice}, Quantity: {Quantity}";
	}
}

public class Computer
{
	public required string NameComputer { get; set; }
	public required string Capacity { get; set; }
	public required string Ram { get; set; }
	public required string Display { get; set; }
	public required string Brand { get; set; }

	public override string ToString()
	{
		return $"Computer: {NameComputer}, Capacity: {Capacity}, RAM: {Ram}, Display: {Display}, Brand: {Brand}";
	}
}

public class Cellphone
{
	public required string NameCellphone { get; set; }
	public required string Capacity { get; set; }
	public required string Ram { get; set; }
	public required string Display { get; set; }
	public required string cameras { get; set; }
	public required string Brand { get; set; }
	public override string ToString()
	{
		return $"Cellphone: {NameCellphone}, Brand: {Brand}, Capacity: {Capacity}, RAM: {Ram}, Display: {Display}, Cameras: {cameras}";
	}

}