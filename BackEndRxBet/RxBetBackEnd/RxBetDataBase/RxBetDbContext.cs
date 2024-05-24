using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RxBetDataBase.Configurations;
using RxBetDataBase.Models;


namespace RxBetDataBase
{
    public class RxBetDbContext: DbContext
    {
        public RxBetDbContext(DbContextOptions<RxBetDbContext> options) : base(options) { }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<BetEntity> Bets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new BetConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
