using PetResort.Core.Contracts;
using PetResort.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetResort.Data.Sql
{
    public class SQLRepository<T> : IRepository<T> where T : BaseEntity
    {
        // our internal variables that are needed
        internal DataContext context;  // the context from the class we created
        internal DbSet<T> dbSet;  // the underlying table that we want access to

        public SQLRepository(DataContext context)  // constructor that passess in a Datacontext 
        {
            this.context = context;  // context = context we r passing in
            this.dbSet = context.Set<T>(); // referencing the context and calling the set command passing in (t)
        }

        public IQueryable<T> Collection()
        {
            return dbSet;   
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(string Id)
        {
            var t = Find(Id);  // finds the internal id
            if (context.Entry(t).State == EntityState.Detached)  // checks the state of the entry
                dbSet.Attach(t);  // passes on the object(t) to EF

            dbSet.Remove(t);  // removes it
            
        }

        public T Find(string Id)
        {
            return dbSet.Find(Id);
        }

        public void Insert(T t)
        {
            dbSet.Add(t);
        }

        public void Update(T t)
        {
            dbSet.Attach(t);  // passes in (t) object and attaches it to EF table
            context.Entry(t).State = EntityState.Modified; // set that entry to State of modified
        }
    }
}
