using FlashCardBlazorApp.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace FlashCardBlazorApp.DataAccess.Services.RepositoryService
{
    public class Repository<T> : IRepository<T> where T : class 
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
        }

        public void Add(T obj)
        {
            dbSet.Add(obj);
        }

        public void Delete(T obj)
        {
            dbSet.Remove(obj);
        }

        public T Get(int id)
        {
            if (id == 0) return null;
            else return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> list = dbSet;
            return list.ToList();
        }

        public void Update(T obj)
        {
            dbSet.Update(obj);
        }
    }
}
