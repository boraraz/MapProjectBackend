using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ParcelBackend.Models;

namespace ParcelBackend.Models
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<Parcel> Parcels { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.Entity<Parcel>().ToTable("parcel");

    }
}