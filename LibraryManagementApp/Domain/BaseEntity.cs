namespace LibraryManagementApp.Domain;

public class BaseEntity
{
    public BaseEntity()
    {
        
    }

    public BaseEntity(Guid id, DateTime createdOn)
    {
        Id = new Guid();
        CreatedOn = createdOn;
    }
    
    public Guid Id { get; init; }
    public DateTime CreatedOn { get; init; }
    public Guid CreatedBy { get; init; }
    public DateTime ModifiedOn { get; set; }
    public Guid ModifiedBy { get; set; }
    public DateTime DeletedOn { get; init; }
    public Guid DeletedBy { get; init; }
}