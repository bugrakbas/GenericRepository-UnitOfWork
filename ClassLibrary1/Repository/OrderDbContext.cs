using EFSample.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFSample.Data;
using EFSample.Data.Models;

namespace EFSample.DataAccess.Repository
{
    public class OrderDbContext : DbContext
    {
        public DbSet<OrderModel> OrderData { get; set; }
        public DbSet<Telefon> Telefon { get; set; }
        public OrderDbContext()
        {
        }
        
        


        public OrderDbContext(DbContextOptions
            <OrderDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost; Port=3306;Database=db2;Uid=root;Pwd=router;");
        }
    }
}
