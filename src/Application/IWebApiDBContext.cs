using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Application
{
    public interface IWebApiDBContext
    {
        DbSet<Okul> Okullar { get; set; }
        DbSet<Ogrenci> Ogrenciler { get; set; }
        DbSet<Ogretmen> Ogretmenler { get; set; }

        int SaveChanges();

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
