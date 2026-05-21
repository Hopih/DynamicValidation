namespace Reflexion;

public class CreateUserRequest
{
    public string Login { get; set; } = "";
    public string Password { get; set; } = "";
    public int Age { get; set; }
}

public class CreateProductRequest
{
    public string Title { get; set; } = "";
    public decimal Price { get; set; }
}

public class CreateOrderRequest
{
    public int UserId { get; set; }
    public List<int> ProductIds { get; set; } = new();
}
