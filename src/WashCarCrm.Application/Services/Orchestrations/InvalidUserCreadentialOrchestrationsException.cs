using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xeptions;

namespace WashCarCrm.Application.Services.Orchestrations
{
    public class InvalidUserCredentialOrchestrationsException: Xeption
    {
         public InvalidUserCredentialOrchestrationsException()
            : base(message: "Credential missing. Fix the error and try again.")
        { }
    }
}