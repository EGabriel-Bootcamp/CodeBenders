using System.Linq.Dynamic.Core;
using System.Reflection;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementApp.ApiResponse;

public class ApiResult<T>
{
    /// <summary>
    /// Private constructor called by the CreateAsync method.
    /// </summary>
    private ApiResult(
        List<T> data,
        int count,
        int pageIndex,
        int pageSize,
        string? filterQuery)
    {
        Data = data;
        PageIndex = pageIndex;
        PageSize = pageSize;
        TotalCount = count;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        FilterQuery = filterQuery;
    }

    #region Methods

    /// <summary>
    /// Pages, sorts and/or filters a IQueryable source.
    /// </summary>
    /// <param name="source">An IQueryable source of generic 
    /// type</param>
    /// <param name="pageIndex">Zero-based current page index 
    /// (0 = first page)</param>
    /// <param name="pageSize">The actual size of 
    /// each page</param>
    /// <param name="filterQuery">The filtering query (value to
    /// lookup)</param>
    /// <returns>
    /// A object containing the IQueryable paged/sorted/filtered
    /// result 
    /// and all the relevant paging/sorting/filtering navigation
    /// info.
    /// </returns>
    public static async Task<ApiResult<T>> CreateAsync(
        IQueryable<T> source,
        int pageIndex,
        int pageSize,
        string? filterQuery = null)
    {
        if (!string.IsNullOrEmpty(filterQuery))
        {
            source = source.Where(filterQuery);
        }

        var count = await source.CountAsync();

        source = source
            .Skip(pageIndex * pageSize)
            .Take(pageSize);

#if DEBUG
        // retrieve the SQL query (for debug purposes)
        var sql = source.ToParametrizedSql();
#endif

        var data = await source.ToListAsync();

        return new ApiResult<T>(
            data,
            count,
            pageIndex,
            pageSize,
            filterQuery);
    }

    /// <summary>
    /// Checks if the given property name exists
    /// to protect against SQL injection attacks
    /// </summary>
    public static bool IsValidProperty(
        string propertyName,
        bool throwExceptionIfNotFound = true)
    {
        var prop = typeof(T).GetProperty(
            propertyName,
            BindingFlags.IgnoreCase |
            BindingFlags.Public |
            BindingFlags.Static |
            BindingFlags.Instance);
        if (prop == null && throwExceptionIfNotFound)
            throw new NotSupportedException($"ERROR: Property '{propertyName}' does not exist.");
        return prop != null;
    }

    #endregion

    #region Properties

    /// <summary>
    /// IQueryable data result to return.
    /// </summary>
    public List<T> Data { get; private set; }

    /// <summary>
    /// Zero-based index of current page.
    /// </summary>
    public int PageIndex { get; private set; }

    /// <summary>
    /// Number of items contained in each page.
    /// </summary>
    public int PageSize { get; private set; }

    /// <summary>
    /// Total items count
    /// </summary>
    public int TotalCount { get; private set; }

    /// <summary>
    /// Total pages count
    /// </summary>
    public int TotalPages { get; private set; }

    /// <summary>
    /// TRUE if the current page has a previous page,
    /// FALSE otherwise.
    /// </summary>
    public bool HasPreviousPage
    {
        get { return (PageIndex > 0); }
    }

    /// <summary>
    /// TRUE if the current page has a next page, FALSE otherwise.
    /// </summary>
    public bool HasNextPage
    {
        get { return ((PageIndex + 1) < TotalPages); }
    }
    
    
    /// <summary>
    /// Filter Query string 
    /// (to be used within the given FilterColumn)
    /// </summary>
    public string? FilterQuery { get; set; }

    #endregion
}