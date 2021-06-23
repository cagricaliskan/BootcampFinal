using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampFinal.Models
{
    public class Payment
    {
        public int Id { get; set; }


        public ICollection<BuildingFlat> BuildingFlats { get; set; }


        public float Price { get; set; }
        public string Description{ get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
