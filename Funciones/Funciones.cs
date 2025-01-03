/* =====================================
	TÍTULO: Funciones
 ===================================== */

/*
   Descripción:
   Una **función** es un bloque de código que agrupa una serie de pasos lógicos con el fin de realizar una tarea específica. 
   Las funciones pueden ser reutilizadas a lo largo del programa y tienen las siguientes características:


   - **Principio (inicio)** y **fin (salida)**. 
   - Pueden **recibir parámetros** como entrada (valores que se pasan a la función).
   - Pueden **regresar un valor** (funciones con retorno), o **no regresar ningún valor** (funciones `void`).
   

 Las funciones son fundamentales para:
   - **Organizar** el código de manera estructurada.
   - **Reutilizar** código sin necesidad de repetirlo.
   - **Facilitar el mantenimiento** del código, ya que cambios en la lógica de una 
		función no afectan al resto del programa.
*/



/*
	Consideraciones: Tenemos varias formas de crear una función o método según el requerimiento.
 */



// Función sin parámetros que no retorna un valor (void)
static void Show()
{
	Console.WriteLine("Hey, I am a text how call function ");
}

// Función con parámetros que no retorna un valor (void)
static void Grate(string grate)
{
	Console.WriteLine($"Hey, {grate}");
}

// Función con parámetros que retorna un valor de tipo int
static int Sum(int x, int y)
{
	return x + y;
}

// Funcion para  multiplicar retorno landa 
static double Mult(double x, double y) => x + y;

//Funciones con parametro con argumentos 
static double Subt(params double[] numbers)
{
	if (numbers.Length == 0)
	{
		return 0;
	}
	double result = numbers[0];
	foreach (var number in numbers)
	{
		result -= number;
	}
	return result;
} ;

//Landa functions  (ENTRADA 2 INT ) (SALIDA UN INT) 
Func<int , int , int > multiply = (x, y) => x * y;

Show();
Grate("Luigi");
int result1 = Sum(1, 3);
double result2 = Mult(1.5, 3.5);
double result3 = Subt(10, 5, 3);
int result4 = multiply(43, 4);


Console.WriteLine($"The result of Sum is {result1}");
Console.WriteLine($"The result of Mult is {result2}");
Console.WriteLine($"The result of Subt is {result3}");
Console.WriteLine($"The result of Multiplay is {result4}");