namespace Reflexion;

public class CreateUserRequestValidator : IValidator<CreateUserRequest>
{
    public ValidationResult Validate(CreateUserRequest model)
    {
        var result = new ValidationResult();

        if (string.IsNullOrWhiteSpace(model.Login))
        {
            result.IsValid = false;
            result.Errors.Add("Login is required");
        }

        if (model.Password.Length < 6)
        {
            result.IsValid = false;
            result.Errors.Add("Password must contain at least 6 characters");
        }

        if (model.Age < 18)
        {
            result.IsValid = false;
            result.Errors.Add("User must be at least 18 years old");
        }

        return result;
    }

}