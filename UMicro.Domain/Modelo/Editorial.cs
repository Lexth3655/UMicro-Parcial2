using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMicro.Domain.Modelo
{
    public class Editorial: BaseEntity
    {
        public string nombre_edit { get; set; }
        public ICollection<Libros> Libro { get; set; }

    }
}
