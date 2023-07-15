using System.Collections.Generic;

namespace PasswordsValidationTestTask.Models.Services
{
    internal interface IPasswordStringsProviderService
    {
        IEnumerable<string> GetStrings();
    }
}