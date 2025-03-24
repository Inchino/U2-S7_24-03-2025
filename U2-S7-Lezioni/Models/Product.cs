using System;
using System.ComponentModel.DataAnnotations;

namespace U2_S7_Lezioni.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public required string Name { get; set; }
        [Required]
        [StringLength(1000)]
        public required string Description { get; set; }
        [Required]
        public required decimal Price { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime? Updated { get; set; }
        public DateTime? Deleted { get; set; }
    }
}
