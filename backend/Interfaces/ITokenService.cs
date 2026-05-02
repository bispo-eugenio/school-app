using Microsoft.IdentityModel.Tokens;
using schoolApi.Models;

namespace schoolApi.Interfaces;

public interface ITokenService
{
    public string CreateToken(AppUser user);
}
