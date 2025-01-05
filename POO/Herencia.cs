using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* =====================================
 * Estandar en c# si es privado inicia con _ 
    Herencia :Reutlizar codigo y abtrar y organizar nuestras entidades
    Solo puedo heredar de una clase de forma gerarquica
 ===================================== */
namespace POO
{
    public abstract  class BankAccount
    {
        private string _accountNumber { get; }
        private string _accountHolder { get; }

        protected decimal _balance;

        public BankAccount(string accountNumber, string accountHolder, decimal initialBalance)
        {
            _accountNumber = accountNumber;
            _accountHolder = accountHolder;
            _balance = initialBalance;
        }
        public decimal Balance
        {
            get { return _balance; }
        }
        public void Deposit(decimal amount)
        {
            if(amount < 0)
            {
                throw new Exception("Valor invalido");
            }
            _balance += amount;
        }

        public abstract void Withdraw (decimal amount);

        public override string ToString()
        {
            return $"Número de Cuenta: {_accountNumber}\n" +
                   $"Titular: {_accountHolder}\n" +
                   $"Saldo: {_balance:C}\n";
        }
    }
    public class SavingsAccount : BankAccount
    {
        private decimal _interestRate;

        public SavingsAccount(string accountNumber, string accountHolder, decimal initialBalance , decimal interestRate) : base(accountNumber, accountHolder, initialBalance)
        {
            _interestRate = interestRate;
            ApplyInterest();
        }
         private void ApplyInterest()
        {
            decimal inteested = _balance * _interestRate;
            _balance += inteested;
        }
        public override void Withdraw(decimal amount)
        {
            decimal remainingBalance = _balance - amount;
            if (remainingBalance < 0) {
                throw new Exception("No puedes retirar dienro");
            }
            _balance -= amount;
        }
        public override string ToString()
        {
            string baseInfo = base.ToString();
            return $"Cuenta de Ahorros:\n{baseInfo}Tasa de Interés: {_interestRate * 100}%\n";
        }
    }
    public class CheckingAccount : BankAccount {
        private decimal _overdraftLimit;

        public CheckingAccount(string accountNumber, string accountHolder, decimal initialBalance, decimal overdraftLimit) : base(accountNumber, accountHolder, initialBalance)
        {
            _overdraftLimit = overdraftLimit;
        }

        public override void Withdraw(decimal amount)
        {
            decimal remainingBalance = _balance - amount;

            if (remainingBalance < -_overdraftLimit)
            {
                throw new InvalidOperationException("Excediste el límite de sobregiro.");
            }

            _balance -= amount;
        }

        public override string ToString()
        {
            string baseInfo = base.ToString();
            return $"Cuenta Corriente:\n{baseInfo}Límite de Sobregiro: {_overdraftLimit:C}\n";
        }
    }

}
