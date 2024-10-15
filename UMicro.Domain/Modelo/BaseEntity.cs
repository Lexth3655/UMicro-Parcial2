using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMicro.Domain.Modelo
{
    public class BaseEntity
    {
        public int id { get; set; }
        public DateTime fechaCreado { get; set; }
        public DateTime fechaModificado { get; set; }

        public bool activo { get; set; }
    }
}
