using Tixer.Context;
using Tixer.Models;

namespace Tixer.Repositories
{
    public class TicketsRepository : ITicketsRepository
    {
        private readonly TixerDbContext _context;

        public TicketsRepository(TixerDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Ticket? GetTicket(string id)
        {
            return _context.Tickets.Where(x => x.PublicId.Equals(id)).FirstOrDefault();
        }

        public IEnumerable<Ticket> GetTickets()
        {
            return _context.Tickets.AsEnumerable();
        }

        public void AddTicket(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
        }

        public void UpdateTicket(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            _context.SaveChanges();
        }

        public void DeleteTicket(Ticket ticket)
        {
            _context.Tickets.Remove(ticket);
            _context.SaveChanges();
        }
    }
}
