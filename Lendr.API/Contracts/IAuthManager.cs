using Lendr.API.DTO.User;
using Microsoft.AspNetCore.Identity;

namespace Lendr.API.Contracts
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto);
    }
}
