using CityInfo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();
        public List<CitiesDto> Cities { get; set; }
        public CitiesDataStore()
        {
            Cities = new List<CitiesDto>()
            {
                new CitiesDto()
                {
                    Id=1,
                    Name="New York",
                    Description="LKjdskfjkldsjfkls",
                    PointofIntest=new List<PointOfIntrestDto>()
                    {
                        new PointOfIntrestDto()
                        {
                           Id=1,
                           Name="sjkdhfhdsj",
                           Description="kjdshfjks"
                        },
                         new PointOfIntrestDto()
                        {
                           Id=2,
                           Name="sjkdhfhdsj",
                           Description="kjdshfjks"
                        }
                    }
                },
                new CitiesDto()
                {
                    Id=2,
                    Name="California",
                    Description="sdfsdfsdfsd",
                    PointofIntest=new List<PointOfIntrestDto>()
                    {
                        new PointOfIntrestDto()
                        {
                           Id=1,
                           Name="sjkdhfhdsj",
                           Description="kjdshfjks"
                        },
                         new PointOfIntrestDto()
                        {
                           Id=2,
                           Name="sjkdhfhdsj",
                           Description="kjdshfjks"
                        }
                    }
                },
                new CitiesDto()
                {
                    Id=3,
                    Name="Roukela",
                    Description="sdfsdfsdfsd",
                    PointofIntest=new List<PointOfIntrestDto>()
                    {
                        new PointOfIntrestDto()
                        {
                           Id=1,
                           Name="sjkdhfhdsj",
                           Description="kjdshfjks"
                        },
                         new PointOfIntrestDto()
                        {
                           Id=2,
                           Name="sjkdhfhdsj",
                           Description="kjdshfjks"
                        }
                    }
                },
            };
        }
    }
}
