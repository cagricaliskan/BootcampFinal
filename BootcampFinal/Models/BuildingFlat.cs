using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampFinal.Models
{
    public class BuildingFlat
    {
        public int Id { get; set; }


        public int BuildingId { get; set; }
        [ForeignKey("BuildingId")]
        public virtual Building Building { get; set; }


        public int FlatId { get; set; }
        [ForeignKey("FlatId")]
        public virtual Flat Flat { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }


        public int FlatTypeId { get; set; }
        [ForeignKey("FlatTypeId")]
        public virtual FlatType FlatType { get; set; }

    }
}
