using Lendr.API.DTO.User;
using Microsoft.AspNetCore.Identity;

namespace Lendr.API.Contracts
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto);
        Task<AuthResponseDto> Login(LoginDto loginDto);

        Task<string> CreateRefreshToken();

        Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto responseDto);
    }
}
