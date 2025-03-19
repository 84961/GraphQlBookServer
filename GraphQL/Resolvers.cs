using GraphQlBooks.Models;

namespace GraphQlBooks.GraphQL;

public class Resolvers
{
    public String GetFormattedDate([Parent] Book e)
    {
        return e.PublishDate?.ToShortDateString() ?? "No publish date";
    }
}
