using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAngular.API.DAL.Repositories
{
    public class UnitOfWork :  IUnitOfWork
    {
        public DbContext Context { get; }
 
        public UnitOfWork(DbContext context)
        {
            Context = context;
        }
        public void SaveChanges()
        {
            Context.SaveChanges();
        }
 
        public void Dispose()
        {
           Context.Dispose();
            
        }
    }
}
