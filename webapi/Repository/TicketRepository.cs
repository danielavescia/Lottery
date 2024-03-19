using webapi.Data;
using webapi.Models.Domain;
using webapi.Models.DTO;
using webapi.Services;

namespace webapi.Repository
{
    public class TicketRepository: ITicketRepository
    {
        private readonly DataPersistance dbContext;
        private readonly TicketService ticketService;

        //dependecy injection
        public TicketRepository( DataPersistance dbContext, TicketService ticketService )
        {
            this.dbContext = dbContext;
            this.ticketService = ticketService;
        }


        public async Task<List<Ticket>> GetAllTicketsAsync() 
        {
            return  await dbContext.ReadTicketsFromJson(); //Reads json to get the tickets from this session
        }

        public async Task<Ticket> GetTicketnByIdAsync( int id )
        {
            var tickets = await dbContext.ReadTicketsFromJson();

            foreach ( var ticket in tickets )
            {
                if ( ticket.Id == id )
                {
                    return ticket;
                }
            }

            return null;
        }
        public async Task<Ticket> CreateTicketAsync( CreateTicketDto createdTicketDto )
        {
            List<Ticket> ticketsDomain = await dbContext.ReadTicketsFromJson(); // return list of tickets
            int id = ticketService.CreateTicketId( ticketsDomain ); // return the next Id
            var ticketDomainModel = new Ticket

            {
                Id = id, Cpf = createdTicketDto.Cpf,
                Name = createdTicketDto.Name,
                SelectedNumbers =  createdTicketDto.SelectedNumbers.OrderBy( number => number ).ToList() //ascending order 
            };
               

            ticketsDomain.Add( ticketDomainModel ); // add the new ticketDomain into the list
            dbContext.WriteTicketsToJson( ticketsDomain ); //save the new list into json file

            return ticketDomainModel;
        }

        public async Task<Ticket> CreateRandomTicketAsync( TicketRandomDto ticketRandomDto )
        {
            List<Ticket> ticketsDomain = await dbContext.ReadTicketsFromJson(); // return list of tickets
            int id = ticketService.CreateTicketId( ticketsDomain ); // return the next Id
            var ticketDomainModel = new Ticket { Id = id, Cpf = ticketRandomDto.Cpf, Name = ticketRandomDto.Name, SelectedNumbers = ticketService.GenerateRandomTicket() };


            ticketsDomain.Add( ticketDomainModel ); // add the new ticketDomain into the list
            dbContext.WriteTicketsToJson( ticketsDomain ); //save the new list into json file

            return ticketDomainModel;
        }

    }   
}


