using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Domain.Modelo;

namespace UMicro.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Autor> Autores { get; }
        IRepository<Libros> Libros { get; }
        IRepository<Editorial> Editoriales { get; }
        Task<int> CompleteAsync();
    }
}
