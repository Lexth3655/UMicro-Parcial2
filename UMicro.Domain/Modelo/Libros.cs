using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMicro.Domain.Modelo
{
    public class Libros : BaseEntity
    {
        public string titulo { get; set; }
        public int anio_publicacion { get; set; }


        [ForeignKey("autorID_fk")]
        public int autorID { get; set; }
        public Autor autor { get; set; }


        [ForeignKey("editorialID_fk")]
        public int editorialID { get; set; }
        public Editorial ditorial  { get; set; }

    }
}
