namespace Tixer.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public string PublicId { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty; 
        
        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
