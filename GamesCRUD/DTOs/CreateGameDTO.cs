namespace GamesCRUD.DTOs;

public record CreateGameDTO
(
    int id,
    string name,
    decimal price
    );