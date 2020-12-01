using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServersListing.Models;

namespace ServersListing.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<ServerInfo> ServerInfo { get; set; }
        public virtual DbSet<ServerType> ServerType { get; set; }
        public virtual DbSet<ServerService> ServerService { get; set; }
        public virtual DbSet<ServerServiceInfo> ServerServiceinfo { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=WHITSLTL127MW\SQLEXPRESS;Initial Catalog=ServersListing;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServerInfo>().ToTable("ServerInfo").Property(si => si.Id).UseIdentityColumn();
            modelBuilder.Entity<ServerType>().ToTable("ServerType").Property(st => st.Id).UseIdentityColumn();
            modelBuilder.Entity<ServerService>().ToTable("ServerService").Property(ss => ss.Id).UseIdentityColumn();
            modelBuilder.Entity<ServerServiceInfo>().ToTable("ServerServiceInfo").HasKey(ssi => new { ssi.ServerInfoId, ssi.ServerServiceId });
        }
        
    }
}
