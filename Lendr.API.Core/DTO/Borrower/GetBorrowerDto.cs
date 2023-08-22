using Lendr.API.Core.DTO.CivilStatus;

namespace Lendr.API.Core.DTO.Borrower
{
    public class GetBorrowerDto:BorrowerDto
    {
        public GetCivilStatusesDto CivilStatus { get; set; }
    }
}
