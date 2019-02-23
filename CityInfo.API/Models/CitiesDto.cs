﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Models
{
    public class CitiesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberofPointofIntreast { get
            {
                return PointofIntest.Count;
            }

        }
        public ICollection<PointOfIntrestDto> PointofIntest { get; set; }
        = new List<PointOfIntrestDto>();
    }
}
