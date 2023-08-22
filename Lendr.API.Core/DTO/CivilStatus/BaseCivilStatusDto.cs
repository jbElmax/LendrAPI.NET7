using System.ComponentModel.DataAnnotations;

namespace Lendr.API.Core.DTO.CivilStatus
{
    public abstract class BaseCivilStatusDto
    {
        [Required]
        public string Name { get; set; }
    }
}
