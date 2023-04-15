
using WashCarCrm.Domain;

namespace WashCarCrm.Infrastructure.Repositories
{
    public interface ITokenRepository
    {
        string GenerateJWT(User user);
    }
}