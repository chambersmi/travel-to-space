using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    // SECTION 3 -> LESSON 37

    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        // Passing an TEntity as an IQueryable and calling it inputQuery
        // #6 We can use DB Context to apply to the queries in the expression
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery;
            
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }

            if (spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }

            //Pagination - Ordering is important
            if(spec.IsPagingEnabled) {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }

            // Include the product type and the product brand
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}