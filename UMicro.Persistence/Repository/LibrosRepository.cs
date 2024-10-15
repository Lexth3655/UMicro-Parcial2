using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Domain.Interfaces;
using UMicro.Domain.Modelo;
using UMicro.Persistence.Data;

namespace UMicro.Persistence.Repository
{
    public class LibrosRepository : Repository<Libros>, ILibroRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Libros> _dbSet;

        public LibrosRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Libros>();
        }

        public async Task<IEnumerable<Libros>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Libros> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(Libros entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task UpdateAsync(Libros entity)
        {
            _dbSet.Update(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }
    }
}
