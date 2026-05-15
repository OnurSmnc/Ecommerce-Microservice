using CatalogService.Application.Interfaces.Repositories;
using CatalogService.Application.Interfaces.UnitOfWork;
using CatalogService.Infrastructure.Context;
using CatalogService.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly CatalogDbContext dbContext;
        public UnitOfWork(CatalogDbContext catalogDbContext)
        {
             this.dbContext = catalogDbContext;
        }
        public async ValueTask DisposeAsync()
        {
            await this.dbContext.DisposeAsync();
        }

        public int Save() => dbContext.SaveChanges();

        public async Task<int> SaveChangesAsync()=> await this.dbContext.SaveChangesAsync();

        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(dbContext);

        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(dbContext);

      
    }
}
