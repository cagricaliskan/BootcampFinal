using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampFinal.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Plate { get; set; }
        public string Type { get; set; }
    }
}
