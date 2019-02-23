using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Enities
{
    public class CityInfoContext:DbContext
    {
        public CityInfoContext(DbContextOptions<CityInfoContext> dbContextOptions):base(dbContextOptions)
        {
            Database.EnsureCreated();
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfIntrest> pointOfIntrests { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
