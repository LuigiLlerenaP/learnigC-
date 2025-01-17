using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
	/* =====================================
	  * Interfaces:
	     - Son un concepto abstracto que nos permite definir un contrato que las clases deben cumplir.
	        Es decir, una clase que implementa una interfaz debe proporcionar la implementación de todos los métodos y propiedades definidos en ella.
	     - Son fundamentales en la programación orientada a objetos y en los patrones de diseño, ya que permiten definir comportamientos sin especificar cómo deben ser implementados.
	     - Proporcionan una forma de categorizar y estructurar el código, ya que una clase puede implementar múltiples interfaces.
	        Esto difiere de la herencia, que solo permite la herencia de una única clase base.
	     - Permiten la creación de código más flexible y extensible, promoviendo la reutilización y el desacoplamiento.
	  * =====================================
	  */
	public class SubscriptionManager
	{
		public void ManageSubscription(ISubscription subscription)
		{
			subscription.ShowDetails();
			subscription.ProcessPayment(200);
			subscription.Cancel();
		}
	}

	public interface ISubscription
	{
		void ProcessPayment(decimal amount);
		void Cancel();
		void ShowDetails();
	}

	public class MonthlySubscription : ISubscription
	{
		public void Cancel()
		{
			Console.WriteLine("The monthly subscription has been canceled.");
		}

		public void ShowDetails()
		{
			Console.WriteLine("Monthly subscription: Full access for 30 days.");
		}
		  
		public void ProcessPayment(decimal amount)
		{
			Console.WriteLine($"Processing monthly payment of {amount}.");
		}
	}

	public class AnnualSubscription : ISubscription
	{
		public void Cancel()
		{
			Console.WriteLine("The annual subscription has been canceled.");
		}

		public void ShowDetails()
		{
			Console.WriteLine("Annual subscription: Full access for 30 days. 4k for two screens ");
		}

		public void ProcessPayment(decimal amount)
		{
			Console.WriteLine($"Processing annual payment of {amount}.");
		}
	}



}
