using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
	/* =====================================
     * Sobrescritura: Nos permite ampliar o modificar la funcionalidad 
        de un método heredado en una clase base para adaptarlo a una clase derivada.
		Usamos la palabra reserbada virtual para sobre escribir un metodo 
     * ===================================== */
	/* =====================================
	 * Campo vs Propiedad:
	 * 
	 * Campo:
	 * - Es una variable que pertenece directamente a una instancia o clase.
	 * - Puede ser declarado como `readonly` para hacerlo inmutable después de la inicialización.
	 * - Su convención de nombres suele incluir un guion bajo (`_`) al inicio si es privada.
	 * 
	 * Propiedad:
	 * - Es una abstracción más avanzada que encapsula un campo, proporcionando acceso controlado mediante `get` y `set`.
	 * - Generalmente se nombran con PascalCase (primera letra en mayúscula).
	 * - Permiten agregar lógica adicional al acceder o modificar el valor.
	 * ===================================== */
	/* =====================================
	 * this(): Hace referencia a otro (constructor / metodo / atributo) dentro de la misma clase.
	 * base(): Hace referencia a otro (constructor / metodo / atributo) de la clase base (superclase).
	* ===================================== */
	public abstract class Payment
	{
		private DateTime DatePayment { get;}
		private string PaymentConcept { get;}
		private string Payee { get; }
		private string Payer { get; }

		private readonly string _currencyType;

		protected Payment (DateTime datePayment, string paymentConcept, string payee , string payer) 
		{
			DatePayment = datePayment;
			PaymentConcept = paymentConcept;
			Payee = payee;
			Payer = payer;
		}

		protected Payment(DateTime datePayment, string paymentConcept, string payee, string currencyType,string payer ) :this(datePayment, paymentConcept , payee , payer)
		{
			_currencyType = currencyType;
		}

		public abstract string ProcessPayment(decimal amount);
		protected virtual bool ValidatePayment(decimal amount)
		{
			if (amount > 0)
			{
				throw new ArgumentException("The payment amount must be greater than zero.");
			}
			return true;
		}
		public override string ToString()
		{
			return $"Payment Details: \n" +
				   $"- Date: {DatePayment.ToShortDateString()} \n" +
				   $"- Concept: {PaymentConcept} \n" +
				   $"- Payee: {Payee} \n" +
				   $"- Currency: {_currencyType}\n"+
				   $"- Payer:{Payer}";
		}


	}

    public class CreditCardPayment : Payment
    {
		private decimal CreditLimit { get; set; } 
		public CreditCardPayment(DateTime datePayment, string paymentConcept, string payee, string payer, string currencyType = "USD", decimal creditLimit= 1000M) : base(datePayment, paymentConcept, payee, currencyType , payer)
		{
			CreditLimit = creditLimit;
		}

		protected override bool ValidatePayment(decimal amount)
		{
			base.ValidatePayment(amount);
			if (amount > CreditLimit)
			{
				throw new ArgumentException($"The payment amount exceeds the credit card limit {CreditLimit}.");
			}
			return true;
		}

		public override string ProcessPayment(decimal amount)
        {
			if (!base.ValidatePayment(amount))
			{
				return "Payment validation failed.";
			}
			return "Processing Credit Card payment...";

		}
    }

	public class CashPayment : Payment
	{
		private decimal MinimumCashAmount { get; set; } 
		public CashPayment(DateTime datePayment, string paymentConcept, string payee, string payer, string currencyType = "USD" , decimal minimumCashAmount = 0.5M) : base(datePayment, paymentConcept, payee, currencyType, payer)
		{
			MinimumCashAmount = minimumCashAmount;
		}

		protected override bool ValidatePayment(decimal amount)
		{
			base.ValidatePayment(amount);
			if (amount < MinimumCashAmount)
			{
				throw new ArgumentException($"The payment amount must be at least {MinimumCashAmount}.");
			}

			return true;
		}

		public override string ProcessPayment(decimal amount)
		{
			if (!base.ValidatePayment(amount))
			{
				return "Payment validation failed.";
			}
			return "Processing Cash payment...";
		}
	}

	public class TransferPayment : Payment
	{
		private decimal MaximumTransferAmount { get; set; } 

		public TransferPayment(DateTime datePayment, string paymentConcept, string payee, string payer, string currencyType = "USD", decimal maximumTransferAmount = 1000M)
			: base(datePayment, paymentConcept, payee, currencyType ,payer)
		{
			MaximumTransferAmount = maximumTransferAmount;
		}

		protected override bool ValidatePayment(decimal amount)
		{
			base.ValidatePayment(amount);

			if (amount > MaximumTransferAmount)
			{
				throw new Exception($"The payment amount exceeds the maximum allowed: {MaximumTransferAmount}.");
			}

			return true;
		}

		public override string ProcessPayment(decimal amount)
		{
			if (!ValidatePayment(amount))
			{
				return "Payment validation failed.";
			}

			return "Processing Transfer payment...";
		}
	}

	// - > Another example 

	public class Sale
	{
		private decimal[] _amounts;
		private int _limitAmount;
		private int _linitEnd;

		public Sale( int limitAmount)
		{
			_amounts = new decimal[limitAmount];
			_limitAmount = limitAmount;
			_linitEnd = 0;
		}

		public void AddAmount(decimal amount)
		{
			if( _linitEnd < _limitAmount)
			{
				_amounts[_linitEnd]= amount;
				_linitEnd++;
			}
		}
		public virtual decimal GetTotal()
		{
			decimal resultAmount = 0;
			int index = 0;
			int maxLength = _amounts.Length;
			while (index < maxLength)
			{
				resultAmount += _amounts[index];
				index++;
			}
			return resultAmount;
		}	
	}

	public class SaleWithTax : Sale
	{
		private const decimal TAX = 1.15M;
		public SaleWithTax(int limitAmount) : base(limitAmount)
		{
		}

		public override decimal GetTotal()
		{
			return base.GetTotal() * TAX;
		}
	}
}
 