using System.ComponentModel.DataAnnotations;

namespace Tixer.DTOs
{
    public class TicketToInsertDto
    {
        [Required(ErrorMessage = "Title cannot be empty")]
        [MaxLength(150, ErrorMessage = "Title must not be greater than 150 characters")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Range(0, 5000.0, ErrorMessage = "Price must be between than 0 and 5000")]
        public decimal Price { get; set; }
    }
}
