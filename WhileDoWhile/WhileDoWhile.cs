/* =====================================
    TÍTULO: While y Do While
 ===================================== */

/*
   Descripción:
   Los bucles `while` y `do-while` son estructuras de control que permiten ejecutar un bloque de código repetidamente 
   mientras se cumpla una condición de evaluación.

   - **while**: El bucle `while` ejecuta el bloque de código **mientras la condición sea verdadera**. 
                La evaluación de la condición se realiza **antes** de ejecutar el bloque de código, 
                lo que significa que, si la condición no se cumple al inicio, el bloque de código **nunca se ejecutará**.

   - **do-while**: El bucle `do-while` también ejecuta un bloque de código repetidamente, 
                   pero la evaluación de la condición se realiza **después** de ejecutar el bloque de código. 
                   Esto garantiza que el bloque de código se ejecute **al menos una vez**, 
                   incluso si la condición es falsa al inicio.

*/

/*
    Consideraciones Importantes:
    - Ambos bucles son útiles para tareas donde se requiere repetir un bloque de código mientras se cumpla una condición específica.
    - Es crucial asegurarse de que la condición en el bucle se vuelva `false` en algún momento, o de lo contrario el bucle entrará en un **bucle infinito**.
    - Un bucle infinito ocurre cuando la condición siempre evalúa como `true`, lo que hace que el bucle siga ejecutándose indefinidamente.
    - Es util cuando no sabemos el numero de veces que sea realizara el loop 
*/

int numberOne = 0;

while (numberOne <= 10)
{
    Console.WriteLine($"The number is : {numberOne}");
    numberOne++;
}


int numberTwo = 0;
do
{
	Console.WriteLine($"The number is : {numberTwo} , execute one tieme");
    numberTwo++;
}while (numberTwo > 10);



/*
    - **break**: Se utiliza para **salir inmediatamente del bucle** y continuar la ejecución del código fuera de él. 
      Este comando interrumpe la ejecución del bucle en cualquier momento, sin importar si se ha completado o 
      no todas las iteraciones. 
      Se usa comúnmente cuando se ha alcanzado una condición específica que requiere terminar 
      el bucle antes de que se cumpla su condición original.

    - **continue**: Se utiliza para **saltar una iteración del bucle** y continuar con la siguiente iteración. 
      Al usar `continue`, el código que sigue dentro del bucle en esa iteración no se ejecuta, 
      pero el bucle continuará con la siguiente iteración, evaluando nuevamente la condición. 
      Es útil cuando deseas omitir parte del código para ciertos casos sin interrumpir todo el bucle.

    - **return**: Se utiliza para **terminar la ejecución de un método o función**, lo que también **termina la ejecución del bucle** si está dentro de ese método. 
      A diferencia de `break`, que solo sale del bucle, `return` finaliza completamente el método, lo que significa que no se ejecutará ningún código después de él, ni dentro del bucle ni fuera.
*/

int[] numbersInt = {1,2,3,4,5,6,7,8,9};
int index = 0;
int length = numbersInt.Length;
while(index < length)
{
    if (numbersInt[index] == 4)
    {
		Console.WriteLine("Number found: 4");
		index++;
		continue;
    }
    if ( numbersInt[index] == 8)
    {
		Console.WriteLine("Found number 8, exiting loop.");
		break;
    }
    Console.WriteLine($"Number : {numbersInt[index]}");
    index++;
}