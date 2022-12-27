using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcelonaStore.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        [Range(1,10000)]
        public double ListPrice { get; set; }
        public double Price { get; set; }
        [Required]
        [Range(1, 10000)]
        public double Price5 { get; set; }
        [Required]
        [Range(1, 10000)]
        public double Price10 { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [Required]
        public int MaterialTypeId { get; set; }
        public MaterialType MaterialType { get; set; }

    }
}
