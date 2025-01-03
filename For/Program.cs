/* =====================================
    TÍTULO:For
 ===================================== */

/*
   Descripción:
    El bucle **for** es una estructura de control de flujo que permite 
    ejecutar un bloque de código un número específico de veces, 
    lo que lo hace ideal cuando **sabemos cuántas veces queremos iterar**.
*/

/*
    Consideraciones Importantes:
     El bucle `for` se compone de **tres partes principales**:  
        **Inicialización**,
        ***Condición de evaluación** , 
        ***Actualización**:
*/


string[] shapes = { "Círculo", "Cuadrado", "Triángulo", "Rectángulo", "Hexágono" };

foreach (string shape in shapes)
{
	Console.WriteLine(shape);
}	

Console.WriteLine("---------------------");
Console.WriteLine("Find");

int maxLength = shapes.Length;

for (int i = 0; i < maxLength; i++)
{
	if (shapes[i].Equals("Cuadrado"))
	{
		Console.WriteLine("It is a Square.");
		continue;  
	}
	if (shapes[i].Equals("Rectángulo"))
	{
		Console.WriteLine("It is a Rectangle.");
		break;  
	}
	Console.WriteLine(shapes[i]);
}