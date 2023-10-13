using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
    // The generic field will only take types that are inherited by BaseEntity
    public interface IGenericRepository<T> where T : BaseEntity
    {
        // Read
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task<int> CountAsync(ISpecification<T> spec);

        //Write
        //Tracking Methods
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}