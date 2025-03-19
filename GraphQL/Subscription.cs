using GraphQlBooks.Models;

namespace GraphQlBooks.GraphQL;

public class Subscription
{
    [Subscribe]
    public Book BookAdded([EventMessage] Book newBook) => newBook;
}