using webapi.Models.Domain;

namespace webapi.Repository
{
    public interface IResultRepository
    {
        Task<Result> GetAllResultsAsync();

    }
}
