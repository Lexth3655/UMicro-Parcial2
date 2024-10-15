using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UMicro.Domain.Modelo;

namespace UMicro.Domain.Interfaces
{
    public interface ILibroRepository: IRepository<Libros>
    {
        Task<IEnumerable<Libros>> GetAllAsync();
        Task<Libros> GetByIdAsync(int? id);
        Task<Libros> AgregarAsync(Libros entity);
        Task<Libros> EliminarAsync(int id);
        Task ActualizarAsync(Libros entity);
        int AuxContar(Expression<Func<Libros, bool>> expression);
        Task<Libros> Find(Expression<Func<Libros, bool>> expr);
    }
   
}
