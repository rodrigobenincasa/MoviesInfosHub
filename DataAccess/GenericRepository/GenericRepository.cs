using DataBase.Models.Themoviedb;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private TheMovieDbContext context = null;
        private DbSet<T> table = null;
        public GenericRepository()
        {
            context = new TheMovieDbContext();
            table = context.Set<T>();
        }
        public GenericRepository(TheMovieDbContext context)
        {
            this.context = context;
            table = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
            Save();
        }
        public void BulkInsert(List<T> obj)
        {
            table.AddRange(obj);
            Save();
        }
        public void Update(T obj)
        {
            context.Update(obj);
            Save();
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
