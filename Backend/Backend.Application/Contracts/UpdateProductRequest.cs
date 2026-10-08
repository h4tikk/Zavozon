namespace Backend.Application.Contracts;

public record UpdateProductRequest(
    string Title,
    string? Description,
    long Price,
    string ImagePath);