using market_api.Specifications;

namespace market_api.Interfaces
{
    public interface IGenericInterface<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();

        // Metodos con especificacion de consultas
        Task<T> GetByIdWithSpec(ISpecificationInterface<T> spec);
        Task<IReadOnlyList<T>> GetAllWithSpec(ISpecificationInterface<T> spec);
    }
}
