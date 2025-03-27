using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECommerceFEApp.Models
{
    public class Product {
        [Key]
        public int Id {get; set;}

        [Required(ErrorMessage = "Set a name for your product")]
        [MaxLength(50)]
        public string? Name {get; set;}

        [Required(ErrorMessage = "Set a description for your product")]
        [MaxLength(500)]
        public string? Description {get; set;}

        [Required(ErrorMessage = "Set a price for your product")]
        public decimal Price {get; set;}

        [Required(ErrorMessage = "Set a stock for your product")]
        [Range(0, 1000, ErrorMessage = "Stock must be between 0 and 1000")]
        public int Stock {get; set;}

        [Required(ErrorMessage = "Set a size for your product")]
        public string? Size {get; set;}

        public string? ImageUrl {get; set;}
        public string? ImageFileName {get; set;}
        
        public ICollection<Review> Reviews {get; set;} = new List<Review>();
    }
}