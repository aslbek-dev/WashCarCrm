using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WashCarCrm.Domain;

namespace WashCarCrm.Application.Services.Processings
{
    public interface IUserProcessingService
    {
        User RetrieveUserByCredentails(string email, string password);
    }
}