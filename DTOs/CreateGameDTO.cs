namespace GamesCRUD.DTOs;

public record CreateGameDTO
(
    int id,
    int genreId,
    string name,
    decimal price
    );