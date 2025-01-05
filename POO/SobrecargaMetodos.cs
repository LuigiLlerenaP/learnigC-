using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace POO
{
    /* ====================================
     * Sobrecarga de metodos: Es la capacidad de las clases de tener métodos con el mismo nombre 
       pero con un comportamiento diferente o similar, pudiendo variar también los tipos de datos
     * ===================================== */
    public class InputValidator
    {
        // Validación para cadenas (strings)
        public bool ValidateInput(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("El campo no puede estar vacío.");
            }
            return true;
        }

        // Validación para enteros (int)
        public bool ValidateInput(int input)
        {
            if (input <= 0)
            {
                throw new ArgumentException("El número debe ser mayor que cero.");
            }
            return true;
        }

        public bool ValidateInput(string email , bool isEmail)
        {
            if (!isEmail)
            {
                return false;
            }

            var emailRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            if (!emailRegex.IsMatch(email))
            {
                throw new ArgumentException("El correo electrónico no tiene un formato válido.");
            }

            return true;
        }
        public bool ValidateInput(int[] input)
        {
            foreach (var item in input)
            {
                if (item <= 0)
                {
                    throw new ArgumentException("Todos los números deben ser mayores que cero.");
                }
            }
            return true;
        }
    }
}
