namespace Reflexion;
using System.Reflection;
public class ValidationService
{
    private readonly Dictionary<Type, object> _validators = new();
    
    public void RegisterValidatorsFromAssembly(Assembly assembly)
    {
        foreach (var type in assembly.GetTypes())
        {
            Type[] interfaces = type.GetInterfaces();
            foreach (var iface in interfaces)
            {
                if (iface.IsGenericType && iface.GetGenericTypeDefinition() == typeof(IValidator<>))
                {
                    var genericType = iface.GetGenericArguments()[0];
                    _validators.Add(genericType, Activator.CreateInstance(type));
                }
            }
        }
    }
    public ValidationResult Validate(object model)
    {
        foreach (var type in _validators.Keys)
        {
            if (type == model.GetType())
            {
                var validationmethod =  _validators[type].GetType().GetMethod("Validate");
                return (ValidationResult)(validationmethod.Invoke(_validators[type], new[] { model }));
            }
        }
        return null;
    }
}