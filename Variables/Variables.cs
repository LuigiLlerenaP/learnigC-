/* =====================================
	TÍTULO: Uso de Variables en C#
 ===================================== */

/*
   Descripción: 
	Las variables son espacios en memoria donde almacenamos datos mientras el programa está activo.
	Nos permiten leer y modificar información de un tipo específico durante la ejecución del programa.
 */



/*
  Consideraciones:
   1. Los nombres de las variables pueden comenzar con letras o guion bajo , seguidos de letras o números.
   2. No se pueden nombrar variables que empiecen con números (ej. 12variable es inválido).
   3. Se recomienda usar nombres descriptivos y convenciones de nomenclatura como camelCase o PascalCase.
   4. Evita usar nombres técnicos genéricos (ej. strNombre) que no aporten claridad sobre el propósito de la variable.
   5. Los nombres deben ser representativos y fáciles de entender, evitando frases complicadas o demasiado largas.
   6. Los nombres de las variables deben ser **declarativos** y reflejar la **acción** o **propósito** de lo que almacenan.
 */


// La 'M' o 'm' al final de un número denota que es un valor de tipo 'decimal'.

string firstName = "Luigi";
string lastName = "Llerena";
int age = 24;
decimal height = 171.8M;
double weight = 75.5;
string greet = "Hey Im";

/*
   Constantes:
    Las constantes en C# son valores que no pueden cambiar durante la ejecución del programa.
    Una vez que se asigna un valor a una constante, no se puede modificar. 
	Las constantes se deben inicializar en el momento de su declaración.
 */

const string COUNTRY = "Ecuador";

/*
  Interpolación de cadenas:
  Utilizamos el signo '$' antes de las comillas dobles ("") para indicar que se va a realizar interpolación.
  Las variables o expresiones se insertan dentro de la cadena utilizando `{}`.
  Esto permite insertar valores dentro de la cadena directamente, sin necesidad de usar concatenaciones 
  como `+` o `string.Concat()`.
*/

Console.WriteLine($"{greet} {firstName} {lastName} \n I'm {age} years old \n {height} cm tall, weighing {weight} kg \t");
