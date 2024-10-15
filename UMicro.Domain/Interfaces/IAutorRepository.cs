using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UMicro.Domain.Modelo;

namespace UMicro.Domain.Interfaces
{
    public interface IAutorRepository: IRepository<Autor>
    {
        Task<IEnumerable<Autor>> GetAllAsync();           
        Task<Autor> GetByIdAsync(int? id);                
        Task<Autor> AgregarAsync(Autor entity);            
        Task<Autor> EliminarAsync(int id);                 
        Task ActualizarAsync(Autor entity);                
        int AuxContar(Expression<Func<Autor, bool>> expression); 
        Task<Autor> Find(Expression<Func<Autor, bool>> expr);    
    }
}
