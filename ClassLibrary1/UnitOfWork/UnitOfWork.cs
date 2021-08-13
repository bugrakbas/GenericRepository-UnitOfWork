using EFSample.Data.Models;
using EFSample.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFSample.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private OrderDbContext _context = new OrderDbContext();
        private IRepository<Telefon> telefonRepository;
        public IRepository<OrderModel> orderRepository;

        // Bu yöntem de kullanılabilir 
        public IRepository<Telefon> TelefonRepository
        {
            get
            {
                if (this.telefonRepository == null)
                {
                    this.telefonRepository = new Repository<Telefon>(_context);

                }
                return telefonRepository;
            }
        }

        public IRepository<OrderModel> OrderRepository
        {
            get
            {
                if (this.orderRepository == null)
                {
                    this.orderRepository = new Repository<OrderModel>(_context);
                }
                return orderRepository;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        //  ama bu Kullanım daha pratik
        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return new Repository<TEntity>(_context);
        }
        private bool disposed = false;
    }
}
