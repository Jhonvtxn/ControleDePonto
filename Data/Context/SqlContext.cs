using Data.Mapping;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {

        }
        public DbSet<Collaborator> Collaborators { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<Schedules> schedules{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Collaborator>(new CollaboratorMap().Configure);
            modelBuilder.Entity<Company>(new CompanyMap().Configure);
            modelBuilder.Entity<Schedules>(new SchedulesMap().Configure);
        }
    }
}
