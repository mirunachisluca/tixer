using Tixer.Models;
using Tixer.Repositories;

namespace Tixer.Services
{
    public class TicketsService : ITicketsService
    {
        private readonly ITicketsRepository _ticketsRepository;

        public TicketsService(ITicketsRepository ticketsRepository)
        {
            _ticketsRepository = ticketsRepository ?? throw new ArgumentNullException(nameof(ticketsRepository));
        }

        public Ticket? GetTicket(string id)
        {
            var ticket = _ticketsRepository.GetTicket(id);

            return ticket;
        }

        public IEnumerable<Ticket> GetTickets()
        {
            var tickets = _ticketsRepository.GetTickets();

            return tickets;
        }

        public void AddTicket(Ticket ticket)
        {
            _ticketsRepository.AddTicket(ticket);
        }

        public void UpdateTicket(Ticket ticket)
        {
            _ticketsRepository.UpdateTicket(ticket);
        }

        public void DeleteTicket(Ticket ticket)
        {
            _ticketsRepository.DeleteTicket(ticket);
        }
    }
}
