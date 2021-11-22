using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryIt
{
    public class EmployeeDb : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }

    public interface IRepository<T> : IDisposable       //Interface is Generic becoz we could have respositories to Accounts, Employees, etc
    {
        void Add(T newEntity);
        void Delete(T entity);
        T FindById(int id);
        IQueryable<T> FindAll();
        int commit();
    }

    public class SqlRepository<T> : IRepository<T> where T : class //This is a Generic Constraint indicating that the Type of T must be of class type i.e. Reference Type and not Value Type
    {
        DbContext _ctx;
        DbSet _set;
        public SqlRepository(DbContext ctx)
        {
            _ctx = ctx;
            _set = _ctx.Set<T>();
        }
        public void Add(T newEntity)
        {
            _set.Add(newEntity);
        }

        public int commit()
        {
            return _ctx.SaveChanges();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }

        public IQueryable<T> FindAll()
        {
            throw new NotImplementedException();
        }

        public T FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
