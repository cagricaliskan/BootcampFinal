using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampFinal.Models
{
    public enum UserRole
    {
        Administrator, // admin
        Resident // kullanıcı
    }
    public class User
    {
        public int Id { get; set; }

        public virtual ICollection<BuildingFlat> BuildingFlats { get; set; }
        
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        
        
        public string Name { get; set; }
        public string LastName { get; set; }
        public string TCKN { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public UserRole UserRole { get; set; }
    }
}
