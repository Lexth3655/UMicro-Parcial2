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
    public class AutorRepository : Repository<Autor>, IAutorRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Autor> _dbSet;

        public AutorRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
            _dbSet = _context.Set<Autor>();
        }

        public async Task<IEnumerable<Autor>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Autor> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(Autor entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task UpdateAsync(Autor entity)
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
