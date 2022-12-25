using System.ComponentModel.DataAnnotations;

namespace BarcelonaStore.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name ="Display Oreder")]
        [Range(1,100,ErrorMessage =" Display Oreder 1-100 arası olması gerekiyor")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    }
}
