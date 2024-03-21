﻿using Tixer.Helpers;
using Tixer.Models;
using Tixer.ResourceParameters;

namespace Tixer.Services
{
    public interface ITicketsService
    {
        Ticket? GetTicket(string id);

        PagedList<Ticket> GetTickets(TicketResourceParameters parameters);

        void AddTicket(Ticket ticket);

        void UpdateTicket(Ticket ticket);

        void DeleteTicket(Ticket ticket);
    }
}