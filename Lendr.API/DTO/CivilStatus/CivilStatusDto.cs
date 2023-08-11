using Lendr.API.DTO.Borrower;

namespace Lendr.API.DTO.CivilStatus
{
    public class CivilStatusDto:BaseCivilStatusDto
    {
        public int Id { get; set; }
        public ICollection<BorrowerDto> Borrowers { get; set; }
    }


}
