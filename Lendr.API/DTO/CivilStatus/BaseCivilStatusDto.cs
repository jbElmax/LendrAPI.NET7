using System.ComponentModel.DataAnnotations;

namespace Lendr.API.DTO.CivilStatus
{
    public abstract class BaseCivilStatusDto
    {
        [Required]
        public string Name { get; set; }
    }
}
