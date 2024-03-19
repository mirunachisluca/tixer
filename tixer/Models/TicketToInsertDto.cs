using System.ComponentModel.DataAnnotations;

namespace Tixer.DTOs
{
    public class TicketToInsertDto
    {
        [Required]
        [MaxLength(20)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }
    }
}
