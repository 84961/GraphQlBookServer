using GraphQlBooks.Models;
using HotChocolate.Subscriptions;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Mutation
{
    public Book AddBook(BookInput input)
    {
        // Read all current books
        string fileName = "Database/books.json";
        string jsonString = File.ReadAllText(fileName);
        var books = JsonSerializer.Deserialize<List<Book>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new JsonStringEnumConverter() } })!;

        // Create a new book based on the input
        var rand = new Random();

        var book = new Book();
        book.BookId = rand.Next(1000, 10000);
        book.Name = input.Name;
        book.Genre = input.Genre;
        book.Pages = input.Pages;
        book.Price = input.Price;
        book.PublishDate = input.PublishDate;

        // Add the new book to the books list and save to the file
        books.Add(book);
        var json = JsonSerializer.Serialize(books);
        File.WriteAllText(fileName, json);

        // Return the newly created book
        return book;
    }

    public Book AddBookWithSubscription(BookInput input, [Service] ITopicEventSender sender)
    {
        // Read all current books
        string fileName = "Database/books.json";
        string jsonString = File.ReadAllText(fileName);
        var books = JsonSerializer.Deserialize<List<Book>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new JsonStringEnumConverter() } })!;

        // Create a new book based on the input
        var rand = new Random();

        var book = new Book();
        book.BookId = rand.Next(1000, 10000);
        book.Name = input.Name;
        book.Genre = input.Genre;
        book.Pages = input.Pages;
        book.Price = input.Price;
        book.PublishDate = input.PublishDate;

        // Add the new book to the books list and save to the file
        books.Add(book);
        var json = JsonSerializer.Serialize(books);
        File.WriteAllText(fileName, json);

        // Send subscription notification about the new book
        sender.SendAsync("BookAdded", book);

        // Return the newly created book
        return book;
    }

    public Book UpdateBook(int bookId, BookInput input)
    {
        // Read all current books
        string fileName = "Database/books.json";
        string jsonString = File.ReadAllText(fileName);
        var books = JsonSerializer.Deserialize<List<Book>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new JsonStringEnumConverter() } })!;

        // Find the book to update
        var book = books.FirstOrDefault(b => b.BookId == bookId);
        if (book == null)
        {
            throw new Exception("Book not found");
        }

        // Update the book properties
        book.Name = input.Name;
        book.Genre = input.Genre;
        book.Pages = input.Pages;
        book.Price = input.Price;
        book.PublishDate = input.PublishDate;

        // Save the updated books list to the file
        var json = JsonSerializer.Serialize(books);
        File.WriteAllText(fileName, json);

        // Return the updated book
        return book;
    }

    public bool DeleteBook(int bookId)
    {
        // Read all current books
        string fileName = "Database/books.json";
        string jsonString = File.ReadAllText(fileName);
        var books = JsonSerializer.Deserialize<List<Book>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new JsonStringEnumConverter() } })!;

        // Find the book to delete
        var book = books.FirstOrDefault(b => b.BookId == bookId);
        if (book == null)
        {
            throw new Exception("Book not found");
        }

        // Remove the book from the list
        books.Remove(book);

        // Save the updated books list to the file
        var json = JsonSerializer.Serialize(books);
        File.WriteAllText(fileName, json);

        // Return true to indicate the book was deleted
        return true;
    }
}
