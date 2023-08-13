using Lendr.API.DTO.CivilStatus;

namespace Lendr.API.DTO.Borrower
{
    public class GetBorrowerDto:BorrowerDto
    {
        public GetCivilStatusesDto CivilStatus { get; set; }
    }
}
