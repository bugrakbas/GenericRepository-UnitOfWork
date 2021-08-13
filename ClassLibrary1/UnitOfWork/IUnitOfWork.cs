using EFSample.Data.Models;
using EFSample.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFSample.DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Telefon> TelefonRepository { get; }
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        IRepository<OrderModel> OrderRepository { get; }
        void Save();

    }
}
