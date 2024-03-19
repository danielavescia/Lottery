using webapi.Models.Domain;

namespace webapi.Repository
{
    public interface IResultRepository
    {
        Task<List<Result>> GetAllResultsAsync();

        //Task<Result> GenerateResultAsync( Result result );
    }
}
