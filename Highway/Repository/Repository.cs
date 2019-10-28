using Highway.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Highway.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private HighwayContext _context;
        private DbSet<T> table = null;
        public Repository(HighwayContext ctx)
        {
            _context = ctx;
            table = _context.Set<T>();
        }
        public void Add(T obj)
        {
            table.Add(obj);
        }

        public void Delete(T obj)
        {
            table.Remove(obj);
        }

        public bool Exist(int id)
        {
            var obj = table.Find(id);
            if (obj != null)
                return true;
            return false;
        }

        public T Get(int id)
        {
            return table.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public bool Save()
        {
          return (_context.SaveChanges() >= 0);
        }

        public void Update(T obj)
        {
            
        }
    }
}
