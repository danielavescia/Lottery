using System.Collections.Generic;
using webapi.Data;
using webapi.Models.Domain;
using webapi.Services;

namespace webapi.Repository
{
    public class ResultRepository:IResultRepository
    {
        private readonly DataPersistance dbContext;
        private readonly ResultService resultService;
        

        //dependecy injection
        public ResultRepository( DataPersistance dbContext, ResultService resultService )
        {
            this.dbContext = dbContext;
            this.resultService = resultService;
        }
        public async Task<List<Result>> GetAllResultsAsync()
        {
            return await dbContext.ReadResultsFromJson(); //Reads json to get the results from this session
        }

        public async Task<Result> GenerateResultAsync( ) 
        {
            List<Ticket> ticketsList = new( );
            ticketsList = await dbContext.ReadTicketsFromJson();
            Result domainResults= resultService.GenerateResults( ticketsList );
            dbContext.WriteResultsToJson( domainResults );

            return domainResults;

        }
    }
}
