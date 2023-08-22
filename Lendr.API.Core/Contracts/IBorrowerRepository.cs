using Lendr.API.Data;
using Lendr.API.Core.Models;
using Lendr.API.Core.DTO.Borrower;

namespace Lendr.API.Core.Contracts
{
    public interface IBorrowerRepository:IGenericRepository<Borrower>
    {
        Task<BorrowerDto> GetDetails(int id);
    }
}
