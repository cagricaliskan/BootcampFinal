using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampFinal.Models
{
    public class BuildingType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Building> Buildings { get; set; }    
    }
}
