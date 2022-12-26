﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcelonaStore.Models
{
    public class MaterialType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Material Type")]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
