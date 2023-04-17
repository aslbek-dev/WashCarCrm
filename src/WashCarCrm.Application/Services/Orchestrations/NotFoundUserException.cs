using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xeptions;

namespace WashCarCrm.Application.Services.Orchestrations
{
    public class NotFoundUserException : Xeption
    {
         public NotFoundUserException(int userId)
            : base(message: $"Could not find user with id:{userId}.")
        { }

        public NotFoundUserException()
            : base(message: "Could not find user with given credentials")
        { }
    }
}