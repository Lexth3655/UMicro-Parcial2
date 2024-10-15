using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UMicro.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int? id);
        Task<T> AgregarAsync(T entity);
        Task<T> EliminarAsync(int id);
        Task ActualizarAsync(T entity);
        int AuxContar(Expression<Func<T, bool>> expression);
        Task<T> Find(Expression<Func<T, bool>> expr);
    }
}
