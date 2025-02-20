using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GadgetHub.Domain.Entities;

namespace GadgetHub.Domain.Entities
{
    public class Gadget
    {
        [Key]  //Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Auto-incremented
        public int GadgetId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Brand { get; set; }

        [Required]
        [Range(0, 10000)]
        public decimal Price { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; }
    }
}

