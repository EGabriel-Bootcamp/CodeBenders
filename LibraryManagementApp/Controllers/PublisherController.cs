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
public class PublisherController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<PublisherController> _logger;

    public PublisherController(ILogger<PublisherController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResult<PublisherDto>>> GetPublishers(
        bool trackChanges,
        int pageIndex = 0,
        int pageSize = 10,
        string? filterQuery = null)
    {
        var publishers = await ApiResult<PublisherDto>.CreateAsync(
            _unitOfWork.Publishers.FindAll(trackChanges).Select(
                p => new PublisherDto()
                {
                    Id = p.Id,
                    Name = p.Name,
                    LogoUrl = p.LogoUrl,
                }),
            pageIndex,
            pageSize,
            filterQuery);

        return publishers;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PublisherDto>> GetPublisherById(Guid id, bool trackChanges)
    {
        var entity = await _unitOfWork.Publishers
            .FindByCondition(p => p.Id.Equals(id), trackChanges)
            .Select(p => new PublisherDto
            {
                Name = p.Name,
                LogoUrl = p.LogoUrl,
                TotalBooks = p.TotBooks,
                TotalAuthors = p.TotAuthors
            })
            .FirstOrDefaultAsync();
        
        if (entity == null)
            throw new NotFoundException();

        return entity;
    }
    
    [HttpPost]
    public ActionResult CreatePublisher(PublisherDto publisher)
    {
        var entity = new Publisher
        {
            Name = publisher.Name,
            LogoUrl = publisher.LogoUrl,
        };

        _unitOfWork.Publishers.Add(entity);
        _unitOfWork.Complete();
        _unitOfWork.Dispose();

        return Ok();
    }

    [HttpPut("{id:guid}")]
    public ActionResult UpdatePublisher(PublisherDto publisher, Guid id)
    {
        var entity = _unitOfWork.Publishers.FindById(id);

        if (entity == null)
            throw new NotFoundException();

        entity.Name = publisher.Name;
        entity.LogoUrl = publisher.LogoUrl;

        _unitOfWork.Publishers.Update(entity);
        _unitOfWork.Complete();
        _unitOfWork.Dispose();

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public ActionResult DeletePublisher(Guid id)
    {
        var entity = _unitOfWork.Publishers.FindById(id);

        if (entity == null)
            throw new NotFoundException();
        
        _unitOfWork.Publishers.Remove(entity);
        _unitOfWork.Complete();
        _unitOfWork.Dispose();

        return Ok();
    }
}