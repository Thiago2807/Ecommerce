namespace ecommerce_core.Models;

public sealed class ResponseApp<T>
{
    public string Message { get; set; } = string.Empty;
    public bool Error { get; set; } = false;
    public T? Data { get; set; }
}
