using TestTask.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using TestTask.Models;
using TestTask.Data;

namespace TestTask.Services.Implementations;

public class AuthorView{}

public class AuthorService : IAuthorService
{
    private readonly ApplicationDbContext _dbContext;
    public AuthorService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Author> GetAuthor()
    {
        int AuthorOfLongestTitle = await _dbContext.Books.OrderByDescending(book => book.Title.Length)
                                                   .Select(book => book.AuthorId)
                                                   .FirstAsync();
        return await _dbContext.Authors
            .OrderBy(author => author.Id)
            .Where(author => author.Id.Equals(AuthorOfLongestTitle))
            .FirstAsync();
    }

    public async Task<List<Author>> GetAuthors()
    {
        return await _dbContext.Authors
            .Where(author => author.Books.Count(book => book.PublishDate.Year > 2015) % 2 == 0)
            .Where(author => author.Books.Count(book => book.PublishDate.Year > 2015) > 0)
            .ToListAsync();
    }
}