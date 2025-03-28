using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECommerceFEApp.Models {
    public class Order {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // e.g. "Pending", "Awaiting Payment", "Paid", "Failed"
        public string Status { get; set; } = "Awaiting Payment";

        // Store the Stripe session ID to match in the webhook
        public string? StripeSessionId { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new();
    }
}