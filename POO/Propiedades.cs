using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* =====================================
    Clase "Book" y concepto de encapsulamiento
 ===================================== */
namespace POO
{
    /*
      Propiedades:
      Nos ayudan a acceder a los valores o atributos del objeto y escribir en ellos.

      Encapsulamiento:
      Permite proteger nuestros elementos o valores. 
      Contamos con los siguientes modificadores de acceso:
        - Public: Todos pueden acceder.
        - Private: Solo dentro de la clase.
        - Protected: Dentro de la clase y también en las clases hijas.
    */
    public class Book
    {
        private string Title;
        private string Description;
        private string Author;
        private string ISBN;
        private DateTime date;
        private double price;

        /*
         Podemos controlar los datos que el usuario ingresa en nuestras propiedades,
         especificando en ellas sentencias que los validen.
         */
        public string Date
        {
            get {
                return date.ToLongDateString();
            }
        }
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (price < 0)
                {
                    price = 0;
                }
                price = value;
            }
        }
        public Book(string title , string description, string athor , string isbn , DateTime date) 
        { 
            Title = title;
            Description = description;
            Author = athor;
            ISBN = isbn;
            this.date = date;
        }

        public string ShowInfo()
        {
            return $"Titulo: {Title}\nDescripcion: {Description}\nAutor: {Author}\nISBN: {ISBN}\nFecha: {Date}\nPrecio: {Price:C}";
        }
    }
}
