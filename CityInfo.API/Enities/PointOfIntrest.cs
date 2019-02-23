using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Enities
{
    public class PointOfIntrest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        // Conventional based approach to make relationship
        [ForeignKey("CityId")]
        public City City { get; set; }
        public int CityId { get; set; }
        
    }
}
