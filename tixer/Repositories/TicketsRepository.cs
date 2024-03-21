using Tixer.Context;
using Tixer.Helpers;
using Tixer.Models;
using Tixer.ResourceParameters;

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

        public PagedList<Ticket> GetTickets(TicketResourceParameters parameters)
        {
            ArgumentNullException.ThrowIfNull(parameters);

            var collection = _context.Tickets.AsQueryable();

            if (!string.IsNullOrEmpty(parameters.SearchQuery))
            {
                var searchQuery = parameters.SearchQuery.Trim();

                collection = collection.Where(e => e.Title.ToLower().Contains(searchQuery.ToLower()));
            }

            if (!string.IsNullOrEmpty(parameters.OrderBy))
            {
                var orderByTrimmed = parameters.OrderBy.Trim();
                var reversedOrder = orderByTrimmed.Contains(" desc") || orderByTrimmed.Contains(" descending");

                var firstWhiteSpace = orderByTrimmed.IndexOf(' ');
                if (firstWhiteSpace != -1)
                {
                    orderByTrimmed = orderByTrimmed.Substring(0, firstWhiteSpace);
                }

                switch (orderByTrimmed)
                {
                    case "title":
                        collection = reversedOrder ? collection.OrderByDescending(e => e.Title) : collection.OrderBy(e => e.Title);
                        break;
                    case "price":
                        collection = reversedOrder ? collection.OrderByDescending(e => e.Price) : collection.OrderBy(e => e.Price);
                        break;
                    default: break;
                }
            }

            var pagedCollection = collection.Skip(parameters.PageSize * (parameters.PageNumber - 1)).Take(parameters.PageSize);

            return new PagedList<Ticket>(pagedCollection.ToList(), collection.Count(), parameters.PageNumber, parameters.PageSize);
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
