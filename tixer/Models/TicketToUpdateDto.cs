using System.ComponentModel.DataAnnotations;

namespace Tixer.Models
{
    public class TicketToUpdateDto
    {
        [Required]
        [MaxLength(20)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }
    }
}
