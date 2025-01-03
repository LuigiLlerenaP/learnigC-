/* =====================================
    TÍTULO: Arreglos
 ===================================== */

/*
   Descripción:
   Un arreglo (o array) es una estructura de datos que permite almacenar un conjunto de elementos del mismo tipo. 
   Los elementos del arreglo se almacenan de forma contigua en memoria, y se pueden acceder mediante índices, 
   comenzando desde el índice 0. 
   Los arreglos tienen un tamaño fijo, lo que significa que, una vez definidos, no se pueden redimensionar en tiempo de ejecución.
*/

/*
   Consideraciones:
   - Es importante definir el tamaño del arreglo al momento de su creación.
   - Se debe especificar el tipo de datos que se almacenarán en el arreglo (por ejemplo, enteros, cadenas, etc.).
   - Los arreglos son estáticos, lo que significa que no se pueden cambiar de tamaño una vez que se han creado.
   - No pasarme del rango de mi indice 
*/


string[] boysNames = new string[10];

boysNames[0] = "Luigi";
boysNames[1] = "Anthony";
boysNames[2] = "Carlos";
boysNames[3] = "Sebastian";
boysNames[4] = "Juan";
boysNames[5] = "Pedro";
boysNames[6] = "Manuel";
boysNames[7] = "Javier";
boysNames[8] = "Marco";
boysNames[9] = "Miguel";

Console.WriteLine($"The name in the array at index 0 is: {boysNames[0]}");

/*
   Nota sobre el valor "null":
   En C#, cuando declaras un arreglo de tipo de referencia (como `string[]`), los elementos no inicializados tendrán 
   automáticamente el valor **null**. 
   Esto significa que el elemento está definido en la memoria, pero aún no tiene un valor asignado.
*/
string[] cards =
{
	"Toyota",
	"Chevrolet",
	"Peugeot",
	"Nissan",
	"Honda",
	"Ford",
	"BMW",
	"Mercedes",
	null
};

// Modificando el valor en el índice 8
cards[8] = "Audi";  // Asignamos "Audi" al índice 8

foreach (string card in cards)
{
	Console.WriteLine(card );
}
