using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampFinal.Models
{
    public class Building
    {
        public int Id { get; set; }

        public int BuildingTypeId { get; set; }
        public virtual BuildingType BuildingType { get; set; }

        public ICollection<BuildingFlat> BuildingFlats{ get; set; }


        public string Name { get; set; }
        public int Floor { get; set; }
        public int Subscription { get; set; }
        public int Bill { get; set; }
    }
}
