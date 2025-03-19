namespace GraphQlBooks.Models;

public interface IReadingMaterials
{
    string Name { get; set; }
    BookGenre Genre { get; set; }
}
