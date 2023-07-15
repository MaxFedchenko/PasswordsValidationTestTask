namespace PasswordsValidationTestTask.Models.Services
{
    internal interface IPasswordStringValidator
    {
        bool? Validate(string passwordStr);
    }
}