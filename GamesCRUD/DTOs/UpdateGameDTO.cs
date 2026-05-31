namespace GamesCRUD.DTOs;

public record UpdateGameDTO
(
    int id,
    string name,
    decimal price
);