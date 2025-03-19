namespace GraphQlBooks.Models;

public class Magazine : IReadingMaterials, IThings
{
    public string Name { get; set; }
    public BookGenre Genre { get; set; }
    public int IssueNo { get; set; }
}