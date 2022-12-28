using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
        [Display(Name = "List Price")]
        public double ListPrice { get; set; }
        [Display(Name = "Price For 1-4")]
        public double Price { get; set; }
        [Required]
        [Range(1, 10000)]
        [Display(Name = "Price For 5-9")]
        public double Price5 { get; set; }
        [Required]
        [Range(1, 10000)]
        [Display(Name = "Price For 10+")]
        public double Price10 { get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        [Required]
		[Display(Name="Material Type")]        
        public int MaterialTypeId { get; set; }
        [ValidateNever]
        public MaterialType MaterialType { get; set; }

    }
}
