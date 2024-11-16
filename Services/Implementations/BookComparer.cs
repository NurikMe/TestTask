using TestTask.Models;

namespace TestTask.Services.Implementations;

public class BookComparer : IEqualityComparer<Book>
{
    public bool Equals(Book? x, Book? y){
        if (x is null || y is null) return false;
        return x.Author.Equals(y.Author) &&
               x.AuthorId == y.AuthorId &&
               x.Id == y.Id &&
               x.Price == y.Price &&
               x.PublishDate == y.PublishDate &&
               x.QuantityPublished == y.QuantityPublished &&
               x.Title == y.Title;
    }

    public int GetHashCode(Book x){
        return x.AuthorId.GetHashCode() | 
               x.Id.GetHashCode() | 
               x.Price.GetHashCode() | 
               x.PublishDate.GetHashCode();
    }
}

public static class AuthorExtension{
    public static bool Equals(this Author x, Author y){
        return x.Id == y.Id &&
               x.Name == y.Name &&
               x.Surname == y.Name;
    }
}  