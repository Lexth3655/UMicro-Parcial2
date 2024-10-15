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
    public class EditorialRepository : Repository<Editorial>, IEditorialRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Editorial> _dbSet;

        public EditorialRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Editorial>();
        }

        public async Task<IEnumerable<Editorial>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Editorial> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(Editorial entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task UpdateAsync(Editorial entity)
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
