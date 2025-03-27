using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECommerceFEApp.Models {
    public class Ticket {
        [Key]
        public int Id {get; set;}

        [Required]
        [MaxLength(50)]
        public string? Title {get; set;}

        [Required]
        [MaxLength(500)]
        public string? Description {get; set;}

        public int? UserId {get; set;} 
    }
}