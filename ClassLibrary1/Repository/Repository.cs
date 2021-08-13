using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFSample.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext DbContext;
        private readonly DbSet<T> DbSet;

        public Repository(DbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<T>();
        }
        public int SaveChange()
        {
            
           return   DbContext.SaveChanges();
        }
        public void Add(T entity)
        {
             DbSet.Add(entity);
        }


        public IEnumerable<T> GetAll()
        {
           return DbSet.ToList();
        }

        public T GetById(int id)
        {
           return DbSet.Find(id);
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;

        }
    }
}
