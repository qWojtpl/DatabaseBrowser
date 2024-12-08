using DatabaseManager.Data.Entities.Shared;

namespace DatabaseManager.Data.Entities;

public class BookEntity : BaseEntity
{
    
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int? NumberOfPages { get; set; }
    public int? Year { get; set; }
    public List<AuthorEntity?> Authors { get; set; } = new();
    
}