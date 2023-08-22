using System.ComponentModel.DataAnnotations;

namespace Lendr.API.Core.DTO.User
{
    public class ApiUserDto:LoginDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

    }
}
