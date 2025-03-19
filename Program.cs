using GraphQlBooks.GraphQL;
using GraphQlBooks.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddGraphQLServer()
            .AddQueryType<Query>()
            .AddType<BookType>()
            .AddInterfaceType<IReadingMaterials>()
            .AddMutationType<Mutation>()
            .AddSubscriptionType<Subscription>();


        builder.Services.AddInMemorySubscriptions();

        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");

        app.MapGraphQL();
        
        //protocol for subscription
        app.UseWebSockets();

        app.Run();
    }
}