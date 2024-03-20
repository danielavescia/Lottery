using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webapi.Data;
using webapi.Models.DTO;
using webapi.Repository;

namespace webapi.Controllers
{
    [Route( "/[controller]" )]
    [ApiController]
    public class ResultController : Controller
    {
        private readonly DataPersistance dbContext; //An object of DataPersistance that simulates a dbContext
        private readonly IMapper mapper; // maps and transforms domain/dto or dto/domain
        private readonly ResultRepository resultRepository; //An object of TicketRepository that is responsible for CRUD operations

        public ResultController( DataPersistance dbContext, IMapper mapper, ResultRepository resultRepository ) //DI
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.resultRepository = resultRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var resultDomain = await resultRepository.GetAllResultsAsync(); //Reads json to get the tickets from this session

            var resultDto = mapper.Map<ResultDto>( resultDomain ); //Mapping RegionDomain to RegionDto

            if ( resultDto == null )
            {
                return NotFound();
            }

            return Ok( resultDto ); //return status 200
        }

    }
}
