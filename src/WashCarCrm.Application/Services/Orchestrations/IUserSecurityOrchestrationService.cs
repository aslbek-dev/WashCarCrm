using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WashCarCrm.Domain;

namespace WashCarCrm.Application.Services.Orchestrations
{
    public interface IUserSecurityOrchestrationService
    {
        ValueTask<User> CreateUserAccountAsync(User user);
        UserToken CreateUserToken(string email, string password);
    }
}