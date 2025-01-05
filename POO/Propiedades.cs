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
        private string _title;
        private string _description;
        private string _author;
        private string _ISBN;
        private DateTime _date;
        private double _price;

        /*
         Podemos controlar los datos que el usuario ingresa en nuestras propiedades,
         especificando en ellas sentencias que los validen.
         */
        public string Date
        {
            get {
                return _date.ToLongDateString();
            }
        }
        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (_price < 0)
                {
                    _price = 0;
                }
                _price = value;
            }
        }
        public Book(string title , string description, string athor , string isbn , DateTime date) 
        { 
            _title = title;
            _description = description;
            _author = athor;
            _ISBN = isbn;
            this._date = date;
        }

        public string ShowInfo()
        {
            return $"Titulo: {_title}\nDescripcion: {_description}\nAutor: {_author}\nISBN: {_ISBN}\nFecha: {Date}\nPrecio: {Price:C}";
        }
    }
}
