using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Data
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task AddAsync(T entity);
    }
}
