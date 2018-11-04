using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;

namespace HL.DomainModel.DataMapping
{
   public interface IRepository<T> where T : class
   {
      void Add(T entity);
      void Delete(T entity);
      void DeleteAll(IEnumerable<T> entities);
      IQueryable<T> Find(Expression<Func<T, bool>> specification);
      IQueryable<T> FindAll();
      T Single(Expression<Func<T, bool>> specification);
      T SingleOrDefault(Expression<Func<T, bool>> specification);
      T First(Expression<Func<T, bool>> specification);
      T FirstOrDefault(Expression<Func<T, bool>> specification);
      void Attach(T entity);
      IEnumerable<T> Inserts();
      IEnumerable<T> Deletes();
      IEnumerable<T> Updates();
   }

   public class SqlRepository<T> : IRepository<T> where T : class
   {
      private OperationalDataContext _DataContext;
      private Table<T> _Table;

      public SqlRepository(OperationalDataContext dataContext)
      {
         _DataContext = dataContext;
         _Table = dataContext.GetTable<T>();
      }

      public void Add(T entity)
      {
         _Table.InsertOnSubmit(entity);
      }

      public void Delete(T entity)
      {
         _Table.DeleteOnSubmit(entity);
      }

      public void DeleteAll(IEnumerable<T> entities)
      {
         _Table.DeleteAllOnSubmit(entities);
      }

      public IQueryable<T> Find(Expression<Func<T, bool>> specification)
      {
         return _Table.Where(specification);
      }

      public IQueryable<T> FindAll()
      {
         return _Table;
      }

      public T Single(Expression<Func<T, bool>> specification)
      {
         return _Table.Single(specification);
      }

      public T SingleOrDefault(Expression<Func<T, bool>> specification)
      {
         return _Table.SingleOrDefault(specification);
      }

      public T First(Expression<Func<T, bool>> specification)
      {
         return _Table.First(specification);
      }

      public T FirstOrDefault(Expression<Func<T, bool>> specification)
      {
         return _Table.FirstOrDefault(specification);
      }

      public void Attach(T entity)
      {
         _Table.Attach(entity);
      }

      public IEnumerable<T> Inserts()
      {
         return _Table.Context.GetChangeSet().Inserts.OfType<T>();
      }

      public IEnumerable<T> Deletes()
      {
         return _Table.Context.GetChangeSet().Deletes.OfType<T>();
      }

      public IEnumerable<T> Updates()
      {
         return _Table.Context.GetChangeSet().Updates.OfType<T>();
      }
   }
}
