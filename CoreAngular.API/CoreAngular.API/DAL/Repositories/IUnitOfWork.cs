using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CoreAngular.API.DAL.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }
        void SaveChanges();
    }
}
