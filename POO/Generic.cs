using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
	public class Generic
	{
		/* ==================================================
		 * Clase Genérica (Generic):
		 * - Permite crear clases reutilizables que funcionen 
		 *   con cualquier tipo de dato especificado en tiempo 
		 *   de compilación.
		 * - Utiliza un parámetro de tipo genérico <T>, que 
		 *   representa el tipo de dato con el que trabajará 
		 *   la clase.
		 * - Ventajas:
		 *   1. Reutilización de código para diferentes tipos.
		 *   2. Reducción de errores de conversión al trabajar 
		 *      directamente con tipos específicos.
		 *   3. Permite crear estructuras flexibles que aceptan 
		 *      diferentes tipos de datos (por ejemplo, `int`, 
		 *      `string`, `People`, etc.).
		 * - Comportamiento:
		 *   - Si se accede a un elemento no inicializado, se 
		 *     devuelve el valor por defecto del tipo especificado.
		 * ================================================== */


		public class MyList<T>
		{
			private T[] _elements;
			private int _index = 0;
			public MyList(int n)
			{
				_elements = new T[n];
			}

			public void Add(T e)
			{
				if (_index < _elements.Length)
				{
					_elements[_index] = e;
					_index++;
				}
			}

			public T? GetElement(int index)
			{
				if (index <= _index && index >= 0)
				{
					return _elements[index];
				}
				return default;
			}

			public string GetString()
			{
				int i = 0;
				string result = "";
				while (i < _index)
				{
					result += $"{_elements[i]}|";
					i++;
				}
				return result;
			}
		}

		public class People
		{
			public string FirstName { get; set; }
			public string LastName { get; set; }

			public People(string firstName, string lastName) { 
				FirstName = firstName;
				LastName = lastName;
			}
			public override string ToString()
			{
				return $"{FirstName} {LastName}";
			}
		}
	}
}
