using Lendr.API.Models;

namespace Lendr.API.Contracts
{
    public interface IBorrowerRepository:IGenericRepository<Borrower>
    {
        Task<Borrower> GetDetails(int id);
    }
}
