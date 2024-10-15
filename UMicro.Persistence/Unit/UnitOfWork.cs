using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Domain.Interfaces;
using UMicro.Domain.Modelo;
using UMicro.Persistence.Data;
using UMicro.Persistence.Repository;

namespace UMicro.Persistence.Unit
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        private IRepository<Autor> _autores;
        private IRepository<Libros> _libros;
        private IRepository<Editorial> _editoriales;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IRepository<Autor> Autores => _autores ?? new Repository<Autor>(_context);
        public IRepository<Libros> Libros => _libros ?? new Repository<Libros>(_context);
        public IRepository<Editorial> Editoriales => _editoriales ?? new Repository<Editorial>(_context);

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
