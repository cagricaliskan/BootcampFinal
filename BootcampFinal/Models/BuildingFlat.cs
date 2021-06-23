using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampFinal.Models
{
    public class BuildingFlat
    {
        public int Id { get; set; }


        public int BuildingId { get; set; }
        public Building Building { get; set; }


        public int FlatId { get; set; }
        public Flat Flat { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}
