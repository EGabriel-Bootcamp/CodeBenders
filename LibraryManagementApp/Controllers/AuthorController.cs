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
public class AuthorController: ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<AuthorController> _logger;

    public AuthorController(ILogger<AuthorController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResult<AuthorDto>>> GetAuthors(
        bool trackChanges,
        int pageIndex = 0,
        int pageSize = 10,
        string? filterQuery = null)
    {
        var authors = await ApiResult<AuthorDto>.CreateAsync(
            _unitOfWork.Authors.FindAll(trackChanges).Select(
                a => new AuthorDto()
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    PublisherName = a.Publisher.Name,
                    AvatarUrl = a.AvatarUrl
                }),
            pageIndex,
            pageSize,
            filterQuery);

        return authors;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorDto>> GetAuthorById(Guid id, bool trackChanges)
    {
        var entity = await _unitOfWork.Authors
            .FindByCondition(a => a.Id.Equals(id), trackChanges)
            .Select(a => new AuthorDto()
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                PublisherName = a.Publisher.Name,
                AvatarUrl = a.AvatarUrl
            })
            .FirstOrDefaultAsync();
        
        if (entity == null)
            throw new NotFoundException();

        return entity;
    }
    
    [HttpPost]
    public ActionResult CreateAuthor(AuthorDto author)
    {
        var entity = new Author
        {
            FirstName = author.FirstName,
            LastName = author.LastName,
            AvatarUrl = author.AvatarUrl,
            PublisherId = author.PublisherId
        };

        _unitOfWork.Authors.Add(entity);
        _unitOfWork.Complete();
        _unitOfWork.Dispose();

        return Ok();
    }

    [HttpPut("{id:guid}")]
    public ActionResult UpdateAuthor(AuthorDto author, Guid id)
    {
        var entity = _unitOfWork.Authors.FindById(id);

        if (entity == null)
            throw new NotFoundException();

        entity.FirstName = author.FirstName;
        entity.LastName = author.LastName;
        entity.AvatarUrl = author.AvatarUrl;
        entity.PublisherId = author.PublisherId;
        

        _unitOfWork.Authors.Update(entity);
        _unitOfWork.Complete();
        _unitOfWork.Dispose();

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public ActionResult DeleteAuthor(Guid id)
    {
        var entity = _unitOfWork.Authors.FindById(id);

        if (entity == null)
            throw new NotFoundException();
        
        _unitOfWork.Authors.Remove(entity);
        _unitOfWork.Complete();
        _unitOfWork.Dispose();

        return Ok();
    }
}