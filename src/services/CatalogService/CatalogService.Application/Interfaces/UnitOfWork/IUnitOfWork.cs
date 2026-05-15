using CatalogService.Application.Interfaces.Repositories;
using CatalogService.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IReadRepository<T> GetReadRepository<T>() where T : class, IEntityBase, new();
        IWriteRepository<T> GetWriteRepository<T>() where T : class, IEntityBase, new();

        Task<int> SaveChangesAsync();
        int Save();
    }
}
