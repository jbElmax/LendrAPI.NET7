using Lendr.API.Core.DTO.Borrower;

namespace Lendr.API.Core.DTO.CivilStatus
{
    public class CivilStatusDto:BaseCivilStatusDto
    {
        public int Id { get; set; }
        public ICollection<BorrowerDto> Borrowers { get; set; }
    }


}
