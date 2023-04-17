using GenericRepository.Data;
using Microsoft.EntityFrameworkCore;

namespace GenericRepository.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private UserDbContext _context = null;
        private DbSet<T> table = null;

        public GenericRepository(UserDbContext context) 
        {
            this._context = context;
            table = _context.Set<T>();
        }

        public void Delete(int id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetbyId(int id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
  
    }

