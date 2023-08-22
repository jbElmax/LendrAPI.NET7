using Lendr.API.Data;


namespace Lendr.API.Core.Contracts
{
    public interface ICivilStatusRepository : IGenericRepository<CivilStatus> 
    {
        Task<CivilStatus> GetDetails(int id);    
    }
}
