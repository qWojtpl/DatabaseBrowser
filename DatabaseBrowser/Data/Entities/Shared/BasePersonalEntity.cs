namespace DatabaseManager.Data.Entities.Shared;

public abstract class BasePersonalEntity : BaseEntity
{
    
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    
}