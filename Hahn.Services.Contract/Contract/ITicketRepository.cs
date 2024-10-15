using Hahn.Shared;
using Hahn.ticket.Entity;

namespace Hahn.Services.Contract.Contract
{
    public interface ITicketRepository
    {
        Task<List<Ticket>> GetAllTickets(Pager filter);
        bool AddTicket(Ticket ticket);
        bool DeleteTicket(int Idticket);
        Ticket GetTicketById(int Id);
        bool UpdateTicket(Ticket ticket);
        void Save();
    }
}
