using LibraryManagementApp.ApiResponse;
using LibraryManagementApp.Contracts.RepositoryContracts;
using LibraryManagementApp.Domain;
using LibraryManagementApp.Dtos;
using LibraryManagementApp.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
   private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<BookController> _logger;

    public BookController(ILogger<BookController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResult<BookDto>>> GetBooks(
        bool trackChanges,
        int pageIndex = 0,
        int pageSize = 10,
        string? filterQuery = null)
    {
        var books = await ApiResult<BookDto>.CreateAsync(
            _unitOfWork.Books.FindAll(trackChanges).Select(
                b => new BookDto()
                {
                    Id = b.Id,
                    Title = b.Title,
                    CopyrightNotice = b.CopyrightNotice,
                    ISBN = b.ISBN,
                    AuthorName = b.Author.FirstName,
                    PageLength = b.PageLength,
                    Language = b.Language,
                    ReleaseYear = b.ReleaseYear
                }),
            pageIndex,
            pageSize,
            filterQuery);

        return books;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<BookDto>> GetBookById(Guid id, bool trackChanges)
    {
        var entity = await _unitOfWork.Books
            .FindByCondition(a => a.Id.Equals(id), trackChanges)
            .Select(b => new BookDto()
            {
                Id = b.Id,
                Title = b.Title,
                CopyrightNotice = b.CopyrightNotice,
                ISBN = b.ISBN,
                AuthorName = b.Author.FirstName,
                PageLength = b.PageLength,
                Language = b.Language,
                ReleaseYear = b.ReleaseYear
            })
            .FirstOrDefaultAsync();
        
        if (entity == null)
            throw new NotFoundException();

        return entity;
    }
    
    [HttpPost]
    public ActionResult CreateBook(BookDto book)
    {
        var author = _unitOfWork.Authors.FindById(book.AuthourId);
        var entity = new Book
        {
            Title = book.Title,
            CopyrightNotice = book.CopyrightNotice,
            ISBN = book.ISBN,
            AuthorId = author.Id,
            PageLength = book.PageLength,
            Language = book.Language,
            ReleaseYear = book.ReleaseYear
        };

        _unitOfWork.Books.Add(entity);
        _unitOfWork.Complete();
        _unitOfWork.Dispose();

        return Ok();
    }

    [HttpPut("{id:guid}")]
    public ActionResult UpdateBook(BookDto book, Guid id)
    {
        var entity = _unitOfWork.Books.FindById(id);

        if (entity == null)
            throw new NotFoundException();

        entity.Title = book.Title;
        entity.CopyrightNotice = book.CopyrightNotice;
        entity.ISBN = book.ISBN;
        entity.PageLength = book.PageLength;
        entity.Language = book.Language;
        entity.ReleaseYear = book.ReleaseYear;
        

        _unitOfWork.Books.Update(entity);
        _unitOfWork.Complete();
        _unitOfWork.Dispose();

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public ActionResult DeleteBook(Guid id)
    {
        var entity = _unitOfWork.Books.FindById(id);

        if (entity == null)
            throw new NotFoundException();
        
        _unitOfWork.Books.Remove(entity);
        _unitOfWork.Complete();
        _unitOfWork.Dispose();

        return Ok();
    }
}