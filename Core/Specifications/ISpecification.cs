using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria {get; } // LINQ .Where() criteria
        List<Expression<Func<T, object>>> Includes { get; }  // object is most generic thing. LINQ .Includes()

        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending { get; }
        
        // Pagination
        // Take: take a certain amount of records/products
        // Skip: skip a certain amount of products
        // Take 5, skip 0. Next page, take 5, then skip 5. Next page, take 5, skip 10
        int Take { get; }
        int Skip { get; }
        bool IsPagingEnabled { get; }

    }
}