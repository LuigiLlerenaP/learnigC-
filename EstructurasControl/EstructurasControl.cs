/* =====================================
    TÍTULO: Estructuras de control 
 ===================================== */

/*
   Descripción:
   Los lenguajes de programación se ejecutan de manera secuencial, es decir, de arriba hacia abajo. 
   Sin embargo, las estructuras de control permiten modificar este comportamiento, alterando el flujo 
   de ejecución según ciertas condiciones lógicas.
   Con las estructuras de control, podemos evaluar expresiones lógicas y, 
   dependiendo de si son verdaderas o falsas, realizar diferentes acciones.
*/

/*
	Consideraciones: 
	Una estructura de control se ejecuta solo si la condición que evalúa es verdadera. 
	Si la condición es falsa, también podemos realizar acciones alternativas, como en el caso de un bloque `else` o `default`.
	Es importante que siempre haya una condición que determine si se debe ejecutar o no una acción específica.
*/

/*
 * && (AND): Devuelve `true` solo si ambos operandos son `true`; si el primero es `false`, no evalúa el segundo (corto circuito).
 * || (OR): Devuelve `true` si al menos uno de los operandos es `true`; si uno es `true`, no evalúa el segundo (corto circuito).
 * ! (NOT): Niega la condición, invirtiendo su valor (de `true` a `false` y viceversa).
 * () (Paréntesis): Se usan para agrupar expresiones y controlar el orden de evaluación.La negación `!` tiene mayor precedencia que `&&` Tien mayor precedencia que  `||`.
 */



bool isHungry = true;
bool hasMoney = false;
bool isLegalAge = false;
bool isThirsty = true;


/*
 * IF () {} ELSE {} : Evalúa una condición booleana 
 *                    y ejecuta una de dos acciones dependiendo de si la condición es verdadera o falsa.
 */


if (isHungry)
{
	Console.WriteLine("You need to eat");
}
else
{
	Console.WriteLine("If not hungry, you don't need to eat");
}

if (hasMoney && isLegalAge)
{
	Console.WriteLine("You can go into the disco");
}

if ((isHungry || isThirsty) && hasMoney)
{
	Console.WriteLine("You can buy food or drink");
}
if(IsRestaurantOpen("Pizza Hut", 9))
{
	Console.WriteLine("You can eat");
}

/*
 * TERNARIO:
 * (Condición) ? camino1True : camino2False;
 * Similar a un `if`, pero más simplificado. 
 * Evalúa una condición y retorna un valor dependiendo de si la condición es verdadera o falsa.
 * SOLO PUEDE SER USADO EN UNA EXPRESION QUE DEVULVA UN VALOR O UNA ASIGNACION 
 */

string eat = (isHungry) ? "You need to eat" : "If not hungry, you don't need to eat";
int ageLegal = (isLegalAge) ? 18 : 17;



Console.WriteLine(eat);
Console.WriteLine($"The age is {ageLegal}");
Console.WriteLine((hasMoney) ? "You have money" : "You need to work");

/*
 * IF() {} ELIF() {} ELSE {} : 
 * La estructura `if` evalúa condiciones secuencialmente 
   y ejecuta el primer bloque cuyo resultado sea verdadero.
 * Si la condición del `if` es falsa,
   pasa a evaluar la condición de los `else if`(en caso de haber más de uno).
 * Si ninguna condición se cumple, se ejecutará el bloque `else` (si existe).
 * Importante: Solo se ejecuta el bloque de código del primer `true` encontrado. 
   Si un `if` o `else if` es verdadero, 
 * las condiciones siguientes no se evaluarán.
 */


if (hasMoney)
{
	Console.WriteLine("You have money.");
}
else if (isThirsty)
{
	Console.WriteLine("You are thirsty.");
}
else if (isHungry)
{
	Console.WriteLine("You are hungry.");
}
else
{
	Console.WriteLine("You don't have money, and you are not thirsty or hungry.");
}



static bool IsRestaurantOpen(string restaurantName, int hour = 0)
{
	
	if (restaurantName == "Pizza Hut" && hour > 8 && hour < 23)
	{
		return true;
	}
	else if (restaurantName == "Macdonald's 24 horas")
	{
		return true;
	}
	else
	{
		return false;
	}
}


/*
 * SWITCH() : Se utiliza para evaluar una expresión contra varios casos posibles. 
 * No permite evaluaciones complejas como `&&` (AND) o `||` (OR) en la misma expresión, 
 * pero en C# puedes usar evaluaciones lógicas con operadores como `and` y `or` dentro de los `case` de forma más legible.
 * Los valores evaluados en un `switch` deben ser discretos, es decir, valores como enteros, cadenas o enumeraciones. 
 * La estructura `switch` proporciona una forma más organizada y eficiente de manejar múltiples condiciones cuando se trata de un solo valor.
 */



int numberLucky = 7;
switch (numberLucky)
{
	case 1:
		Console.WriteLine("It is not the lucky number.");
		break;
	case 2:
		Console.WriteLine("It is not the right number.");
		break;
	case 3:
		Console.WriteLine("You are far from the right number.");
		break;
	case 4:
		Console.WriteLine("So close, but that is not the number.");
		break;
	case 5:
		Console.WriteLine("It's the lucky number!");
		break;
	default:
		Console.WriteLine("No lucky number found.");
		break;
}

switch (numberLucky)
{
	// El "int n" declara la variable n y le asigna el valor de numberLucky
	// El "when" agrega una condición adicional para evaluar a n 
	case int n when (n > 1 && n < 10):
		Console.WriteLine("It's within the range of 2 to 9.");
		break;
	case int n when (n < 2 || n > 10):
		Console.WriteLine("It's outside the range of 2 to 9.");
		break;
	default:
		Console.WriteLine("No specific range for the number.");
		break;
}