using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WashCarCrm.Domain;

namespace WashCarCrm.Application.Services.Orchestrations
{
    public partial class UserSecurityOrchestrationsService
    {
         private static void ValidateEmailAndPassword(string email, string password)
        {
            Validate(
                (Rule: IsInvalid(email), Parameter: nameof(User.Email)),
                (Rule: IsInvalid(password), Parameter: nameof(User.Password)));
        }

        private void ValidateUserExists(User user)
        {
            if (user is null)
            {
                throw new NotFoundUserException();
            }
        }

        private static dynamic IsInvalid(string text) => new
        {
            Condition = string.IsNullOrWhiteSpace(text),
            Message = "Value is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidUserCreadentialOrchestrationException =
                new InvalidUserCredentialOrchestrationsException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidUserCreadentialOrchestrationException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidUserCreadentialOrchestrationException.ThrowIfContainsErrors();
        }
    }
}