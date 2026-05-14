namespace MediaJournal.Api.Models;

public class Game
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public GameGenre? Genre { get; set; }
    public int GenreId { get; set; }
    public string? Platform { get; set; }
    public decimal Score { get; set; }
    public DateOnly CompletionDate { get; set; }
}
