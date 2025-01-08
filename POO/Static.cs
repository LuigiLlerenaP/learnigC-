using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
	/* =====================================
	 * Static:
	   - El modificador `static` se utiliza para definir miembros (propiedades, métodos, campos) que pertenecen a la clase en sí, 
		  en lugar de pertenecer a una instancia específica de la clase.
	   - Los miembros estáticos son compartidos por todas las instancias de la clase, lo que significa que el estado 
	       y el comportamiento definido como `static` es común para todas las instancias.
	 *Concideraciones:
		- Si una clase es statica no se peude inicializar , todo sus metodos y clases tiene que ser estatico 
		  Solo realizar acciones 
		===================================== */
	public static class UnitConverter
	{
		public static double KilometersToMiles(double kilometers)
		{
			var validation = ValidateNumberConvert.CheckNumber(kilometers);
			
			if (!validation.IsValid)
			{
				throw new ArgumentException(validation.Message);
			}

			return (kilometers * 0.621371); // 1 km = 0.621371 millas
		}
		public static double MilesToKilometers(double miles)
		{
			var validation = ValidateNumberConvert.CheckNumber(miles);
			if (!validation.IsValid)
			{
				throw new ArgumentException(validation.Message);
			}
			return (miles / 0.621371);
		}
	}
	public static class ValidateNumberConvert
	{
		public static (bool IsValid, string Message) CheckNumber(double number)
		{
			if (number < 0)
			{
				return (false, "Error: El número no puede ser negativo.");
			}

			if (number > 1_000_000_000)
			{
				return (false, "Advertencia: El número es extremadamente grande.");
			}

			if (number < 0.0001)
			{
				return (false, "Advertencia: El número es extremadamente pequeño.");
			}
			return (true, "El número es válido.");
		}
	}


}
