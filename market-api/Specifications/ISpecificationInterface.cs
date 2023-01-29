﻿using System.Linq.Expressions;

namespace market_api.Specifications
{
    public interface ISpecificationInterface<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
    }
}
