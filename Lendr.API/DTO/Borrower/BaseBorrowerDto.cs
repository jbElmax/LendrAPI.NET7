using System.ComponentModel.DataAnnotations;

namespace Lendr.API.DTO.Borrower
{
    public abstract class BaseBorrowerDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string? Suffix { get; set; }
        [Required]
        public int CivilStatusId { get; set; }
    }
}
