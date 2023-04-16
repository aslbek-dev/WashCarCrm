using WashCarCrm.Domain;
using WashCarCrm.Infrastructure.Repositories;

namespace WashCarCrm.Application.Services.Foundations.Securities
{
    public class SecurityService : ISecurityService
    {
        private readonly ITokenRepository tokenRepository;
        public SecurityService(ITokenRepository tokenRepository)
        {
            this.tokenRepository = tokenRepository;
        }
        public string CreateToken(User user)
        {
            return tokenRepository.GenerateJWT(user);
        }
    }
}