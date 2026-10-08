namespace Backend.Application.Contracts;

public record CreatePickUpPointRequest(
    string Name,
    string? Description,
    int X,
    int Y,
    int Z);

    
