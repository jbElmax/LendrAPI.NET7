using Lendr.API.Models;

namespace Lendr.API.Contracts
{
    public interface ICivilStatusRepository : IGenericRepository<CivilStatus> 
    {
        Task<CivilStatus> GetDetails(int id);    
    }
}
