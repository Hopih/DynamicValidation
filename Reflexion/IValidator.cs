namespace Reflexion;

public interface IValidator<T>
{
    ValidationResult Validate(T model);
}

public class ValidationResult
{
    public bool IsValid { get; set; } = true;
    public List<string> Errors { get; set; } = new();
}
