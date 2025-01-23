namespace POO
{
	public class Interfaces2
	{
		/* =====================================
		* Interfaces:
		 - Darle un comportamiento a una clase, permitiendo que tenga varios comportamientos.
		 - Compartir el tipo y definir acciones comunes para múltiples clases.
		 - Facilitan la mantenibilidad del código al proporcionar contratos claros.
		 - Obligan a implementar los métodos y propiedades necesarios.
		 - Manejar diferentes tipos de datos , categorizar y delimitar su comportamiento
		* =====================================
		*/

		public static void ShowFish(IFish[] fishs)
		{
			Console.WriteLine("Mostrar los peces");
			foreach (var fish in fishs)
			{
				Console.WriteLine(fish.Swim());
			}
		}

		public static void ShowAnimals(IAnimal[] animals)
		{
			Console.WriteLine("Mostrar los peces");
			foreach (var aminal in animals)
			{
				Console.WriteLine(aminal.Name);
			}
		}
	}
}

public class Siren : IFish
{
	public int Speed { get; set; }

	public Siren(int speed)
	{
		Speed = speed;
	}

	public string Swim()
	{
		return $"It is swimming at {Speed} speed";
	}
}

public class Shark : IAnimal, IFish
{
	private int _speed;
	public string Name { get; set; }

	public int Speed
	{
		get => _speed;
		set
		{
			if (value < 0)
			{
				throw new Exception("Speed must be greater than zero");
			}
			else
			{
				_speed = value;
			}
		}
	}

	public Shark(string name, int speed)
	{
		Name = name;
		Speed = speed;
	}

	public string Swim()
	{
		return $"{Name} is swimming at {Speed} speed.";
	}
}

public interface IAnimal
{
	string Name { get; set; }
}

public interface IFish
{
	int Speed { get; set; }
	string Swim();
}
