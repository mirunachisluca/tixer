using Tixer.Models;

namespace Tixer.Repositories
{
    public interface ITicketsRepository
    {
        Ticket? GetTicket(string id);

        IEnumerable<Ticket> GetTickets();

        void AddTicket(Ticket ticket);

        void UpdateTicket(Ticket ticket);

        void DeleteTicket(Ticket ticket);
    }
}