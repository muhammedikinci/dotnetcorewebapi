using Application;
using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Persistence
{
    public partial class WebApiDBContext : DbContext, IWebApiDBContext
    {
        public WebApiDBContext(DbContextOptions<WebApiDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ogrenci>().Property(b => b.Ogretmenler).HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<Counter<string>>(v)
                );

            modelBuilder.Entity<Ogrenci>().Property(b => b.Okullar).HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<Counter<string>>(v)
                );

            modelBuilder.Entity<Ogretmen>().Property(b => b.Okullar).HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<Counter<string>>(v)
                );

            modelBuilder.Entity<Okul>().Property(b => b.Ogrenciler).HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<List<string>>(v)
                );

            modelBuilder.Entity<Ogretmen>().Property(b => b.Ogrenciler).HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<List<string>>(v)
                );
        }

        public DbSet<Okul> Okullar { get; set; }
        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Ogretmen> Ogretmenler { get; set; }
    }
}
