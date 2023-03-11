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
public class CategoryController: ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CategoryController> _logger;

    public CategoryController(ILogger<CategoryController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResult<CategoryDto>>> GetPublishers(
        bool trackChanges,
        int pageIndex = 0,
        int pageSize = 10,
        string? filterQuery = null)
    {
        var categories = await ApiResult<CategoryDto>.CreateAsync(
            _unitOfWork.Categories.FindAll(trackChanges).Select(
                c => new CategoryDto()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                }),
            pageIndex,
            pageSize,
            filterQuery);

        return categories;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDto>> GetCategoryById(Guid id, bool trackChanges)
    {
        var entity = await _unitOfWork.Categories
            .FindByCondition(a => a.Id.Equals(id), trackChanges)
            .Select(c => new CategoryDto()
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            })
            .FirstOrDefaultAsync();
        
        if (entity == null)
            throw new NotFoundException();

        return entity;
    }
    
    [HttpPost]
    public ActionResult CreateCategory(CategoryDto category)
    {
        var entity = new Category
        {
            Name = category.Name,
            Description = category.Description,
        };

        _unitOfWork.Categories.Add(entity);
        _unitOfWork.Complete();
        _unitOfWork.Dispose();

        return Ok();
    }

    [HttpPut("{id:guid}")]
    public ActionResult UpdateCategory(CategoryDto category, Guid id)
    {
        var entity = _unitOfWork.Categories.FindById(id);

        if (entity == null)
            throw new NotFoundException();

        entity.Name = category.Name;
        entity.Description = category.Description;

        _unitOfWork.Categories.Update(entity);
        _unitOfWork.Complete();
        _unitOfWork.Dispose();

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public ActionResult DeleteCategory(Guid id)
    {
        var entity = _unitOfWork.Categories.FindById(id);

        if (entity == null)
            throw new NotFoundException();
        
        _unitOfWork.Categories.Remove(entity);
        _unitOfWork.Complete();
        _unitOfWork.Dispose();

        return Ok();
    }
}