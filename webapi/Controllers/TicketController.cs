using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webapi.Data;
using webapi.Models.Domain;
using webapi.Models.DTO;
using webapi.Repository;

namespace webapi.Controllers
{
    [Route( "[controller]")]
    [ApiController]
    public class TicketController : Controller
    {
        private readonly DataPersistance dbContext; //An object of DataPersistance that simulates a dbContext
        private readonly IMapper mapper; // maps and transforms domain/dto or dto/domain
        private readonly TicketRepository ticketRepository; //An object of TicketRepository that is responsible for CRUD operations
     

        public TicketController( DataPersistance dbContext, IMapper mapper, TicketRepository ticketRepository )
        {
            this.dbContext = dbContext;
            this.mapper = mapper; 
            this.ticketRepository = ticketRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ticketDomain = await ticketRepository.GetAllTicketsAsync(); //Reads json to get the tickets from this session

            var ticketDto = mapper.Map<List<TicketDto>>( ticketDomain ); //Mapping RegionDomain to RegionDto
           
            if ( ticketDto == null )
            {
                return NotFound();
            }

            return Ok( ticketDto ); //return status 200

        }
        
        [HttpGet]
        [Route( "{id:int}" )]
        public async Task<IActionResult> GetRegionById( [FromRoute]  int id )
        {
            var ticketDomainModel = await ticketRepository.GetTicketnByIdAsync( id );

            if ( ticketDomainModel == null )
            {
                return NotFound();
            }

            //Map Region Domain Model to Region DTO
            var ticketDto = mapper.Map<TicketDto>( ticketDomainModel );

            return Ok( ticketDto );
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket( [FromBody] CreateTicketDto createdTicketDto) {

            //Using Domain Model to create a new Ticket and insert into Json
            Ticket ticketDomainModel = await ticketRepository.CreateTicketAsync( createdTicketDto );

            //creates DTO to show to the client
            var ticketDTO = mapper.Map<TicketDto>( ticketDomainModel );

            return Ok(  ticketDTO );
        }

        [HttpPost]
        [Route ("/randomTicket")]
        public async Task<IActionResult> CreateRandomTicket( [FromBody] TicketRandomDto ticketRandomDto  )
        {

            //Using Domain Model to create a new Ticket and insert into Json
            Ticket ticketDomainModel = await ticketRepository.CreateRandomTicketAsync( ticketRandomDto );

            //creates DTO to show to the client
            var ticketDTO = mapper.Map<TicketDto>( ticketDomainModel );

            return Ok( ticketDTO );
        }
    }
}
