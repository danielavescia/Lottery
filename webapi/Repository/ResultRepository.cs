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
        public async Task<Result> GetAllResultsAsync()
        {
            var ticketsList = await dbContext.ReadTicketsFromJson();
            Result domainResults = resultService.GenerateResults( ticketsList );
            dbContext.WriteResultsToJson( domainResults );
            return domainResults; 
        }

    }
}
