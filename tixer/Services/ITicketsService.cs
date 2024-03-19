using Tixer.Models;

namespace Tixer.Services
{
    public interface ITicketsService
    {
        Ticket? GetTicket(string id);

        IEnumerable<Ticket> GetTickets();

        void AddTicket(Ticket ticket);

        void UpdateTicket(Ticket ticket);

        void DeleteTicket(Ticket ticket);
    }
}