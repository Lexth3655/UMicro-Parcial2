using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMicro.Domain.Modelo
{
    public class Autor: BaseEntity
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public ICollection<Libros> Libro { get; set; }
    }
}
