using webapi.Models.Domain;
using webapi.Models.DTO;

namespace webapi.Repository
{
    public interface ITicketRepository
    {
        Task<List<Ticket>> GetAllTicketsAsync();

        Task<Ticket> GetTicketnByIdAsync( int id );

        Task<Ticket> CreateTicketAsync( CreateTicketDto createdTicketDto );

        Task<Ticket> CreateRandomTicketAsync( TicketRandomDto ticketRandomDto );

    }
}
