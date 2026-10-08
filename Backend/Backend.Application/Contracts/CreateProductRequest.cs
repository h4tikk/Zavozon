namespace Backend.Application.Contracts;

public record CreateProductRequest(string Title,
    string? Description,
    long Price,
    int Stock,
    string ImagePath);