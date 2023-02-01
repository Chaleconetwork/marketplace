using market_api.Data;
using market_api.Interfaces;
using market_api.Specifications;
using Microsoft.EntityFrameworkCore;

namespace market_api.Repositories
{
    public class GenericRepository<T> : IGenericInterface<T> where T : class
    {
        private readonly Context _context;
        public GenericRepository(Context context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdWithSpec(ISpecificationInterface<T> spec)
        {
            return await AppySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllWithSpec(ISpecificationInterface<T> spec)
        {
            return await AppySpecification(spec).ToListAsync();
        }

        private IQueryable<T> AppySpecification(ISpecificationInterface<T> spec) // Metodo para aplicar especificaciones
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
    }
}