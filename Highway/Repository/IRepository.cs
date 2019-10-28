using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Highway.Repository
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T obj);
        void Delete(T obj);
        void Update(T obj);
        bool Exist(int obj);
        bool Save();
    }
}
