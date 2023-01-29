using market_api.Specifications;
using Microsoft.EntityFrameworkCore;

namespace market_api.Data
{
    public class SpecificationEvaluator<T> where T : class
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecificationInterface<T> spec)
        {
            if (spec.Criteria != null)
            {
                inputQuery= inputQuery.Where(spec.Criteria);
            }

            inputQuery = spec.Includes.Aggregate(inputQuery, (current, include) => current.Include(include));

            return inputQuery;
        }
    }
}
