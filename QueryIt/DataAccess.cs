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

    public interface IReadOnlyRepository<out T> : IDisposable    //Use of Out Keyword (Generic Modifier) is know as Covariance (i.e. it makes the Interface Covariant) which means that Methods inside the Interface are allowed to return a Type that is more derived than the type sepcified by the Generic Parameter. Note that it can only be used for Delegates and Interfaces.
    {
        T FindById(int id);                                     //Note that we have separated out the Interfaces becoz Covariance is only supported when you have Methods that return the Covariant Type Parameter.
        IQueryable<T> FindAll();
    }

    public interface IWriteOnlyRepository<in T> : IDisposable  //Use of In Keyword (Generic Modifier) is know as Contravariance (i.e. it makes the Interface Contravariant) which means that Methods inside the Interface are allowed to accept an input parameter as a Type that is more derived than the type sepcified by the Generic Parameter. Note that it can only be used for Delegates and Interfaces.
    {
        void Add(T newEntity);
        void Delete(T entity);
        int Commit();
    }
    public interface IRepository<T> : IReadOnlyRepository<T>, IWriteOnlyRepository<T>, IDisposable //where T : class, IEntity     //Interface is Generic becoz we could have respositories to Accounts, Employees, etc
    {                                             //Constraints can be applied to the Interface also. BUt should be avoided and kept for the Implementation only.
       
    }

    public class SqlRepository<T> : IRepository<T> where T : class, IEntity //This is a Generic Constraint indicating that the Type of T must be of class type i.e. Reference Type and not Value Type.                                                                            
    {                                            //where T2 : struct                        //If u specify struct, it will take it as a Value Type. You cannot specify noth i.e. struct and class. You can also use Person -> C# compiler will asuumer type as Class                                                                            
        DbContext _ctx;                          //You can specify Constraints for a list of Generic Types                          // Also note that class or struct must be the First Constraint in the List and new() should be the last. New() indicates that the Generric Type T has a default constructor
        DbSet<T> _set;
        public SqlRepository(DbContext ctx)
        {
            _ctx = ctx;
            _set = _ctx.Set<T>();
        }
        public void Add(T newEntity)
        {
            if (newEntity.IsValid())
            {
                _set.Add(newEntity);
            }
        }

        public void Delete(T entity)
        {
            _set.Remove(entity);
        }

        public T FindById(int id)
        {
            return _set.Find(id);
        }

        public IQueryable<T> FindAll()
        {
            return _set;
        }

        public int Commit()
        {
            return _ctx.SaveChanges();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
