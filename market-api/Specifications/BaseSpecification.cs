using System.Linq.Expressions;

namespace market_api.Specifications
{
    public class BaseSpecification<T> : ISpecificationInterface<T>
    {
        public BaseSpecification() { }
        public BaseSpecification(Expression<Func<T, bool>> criteria) 
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T, object>> include) { Includes.Add(include); }
    }
}
