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
     * ===================================== */
     public abstract class Payment 
    {
        public abstract void ProcessPayment(decimal amount);
    }
    public class CreditCardPayment : Payment
    {
        public override void ProcessPayment(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
