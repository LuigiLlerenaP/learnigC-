/* =====================================
	TÍTULO: Tipos de datos C#
 ===================================== */

/*
   Descripción:
   En C#, los tipos de datos determinan qué tipo de información puede almacenar una variable.
   Delimitan el tipo de valor que una variable puede contener y restringen su uso solo a ese tipo específico.
   Esto asegura que los valores almacenados en la variable sean consistentes con su tipo y evita errores de tipo.

 */

/*
  Consideraciones:
  Los tipos de datos en C# se dividen en dos grandes categorías:
  
  1. **Tipos de datos primitivos**: Son los tipos básicos que proporcionan C# para representar valores simples.
  2. **Tipos de datos de referencia**: Son objetos que pueden almacenar instancias más complejas, como clases, arrays, o strings.
  
  Los tipos de referencia permiten manejar estructuras de datos más complejas y representan objetos en la memoria.

 */

/*
  Tipos de datos en C#:
 */

//  - **Tipos de valor (Value Types)**: Valor directamente , de referencia 
int itemCount = 5;
int itemQuantity = 4;
double unitPrice = 33.00;
float subTotalAmount = 44.44F;
decimal totalAmount = 4444.44M;
char itemSection = 'A';
bool hasDiscount = false;

//  **Tipos de referencia (Reference Types)**:

string description = "Smartphone Samsung S24 Ultra";
string[] itemsToBuy = { "Smartphone", "Laptop", "Headphones" };
int[] prices = { 999, 1200, 150 };
List<string> shoppingCart = new List<string> { "Smartphone", "Laptop" };
Dictionary<string, decimal> itemPrices = new Dictionary<string, decimal>
{
	{ "Smartphone", 999.99M },
	{ "Laptop", 1200.00M },
	{ "Headphones", 150.00M }
};

//// **Constantes**:
// Las constantes son valores fijos que no pueden cambiar durante la ejecución del programa.
// Se deben declarar usando la palabra clave `const` y se debe asignar un valor en el momento de la declaración.const double IVA = 15;

const double IVA = 15;



Console.WriteLine("Tipos de valor:");
Console.WriteLine($"Cantidad de artículos: {itemCount}");
Console.WriteLine($"Cantidad de cada artículo: {itemQuantity}");
Console.WriteLine($"Precio unitario: {unitPrice}");
Console.WriteLine($"Subtotal antes de impuestos: {subTotalAmount}");
Console.WriteLine($"Total con impuestos: {totalAmount}");
Console.WriteLine($"Sección del artículo: {itemSection}");
Console.WriteLine($"¿Tiene descuento? {hasDiscount}");
Console.WriteLine($"El producto es {description}");
Console.WriteLine($"\nEl IVA es: {IVA}%");