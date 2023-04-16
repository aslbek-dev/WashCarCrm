using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WashCarCrm.Domain;

namespace WashCarCrm.Application.Services.Foundations.Securities
{
    public interface ISecurityService
    {
        string CreateToken(User user);
    }
}