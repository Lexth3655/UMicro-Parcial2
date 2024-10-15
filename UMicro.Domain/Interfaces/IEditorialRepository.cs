using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UMicro.Domain.Modelo;

namespace UMicro.Domain.Interfaces
{
    public interface IEditorialRepository : IRepository<Editorial>
    {
        Task<IEnumerable<Editorial>> GetAllAsync();
        Task<Editorial> GetByIdAsync(int? id);
        Task<Editorial> AgregarAsync(Editorial entity);
        Task<Editorial> EliminarAsync(int id);
        Task ActualizarAsync(Editorial entity);
        int AuxContar(Expression<Func<Editorial, bool>> expression);
        Task<Editorial> Find(Expression<Func<Editorial, bool>> expr);
    }
}
