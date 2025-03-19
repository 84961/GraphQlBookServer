namespace GraphQlBooks.Models;

public class BookReview
{
    public int ReviewId { get; set; }

    public int Rating { get; set; }

    public string Description { get; set; }
    public DateTime? ReviewDate { get; set; }
    
    public string User { get; set; }
}
