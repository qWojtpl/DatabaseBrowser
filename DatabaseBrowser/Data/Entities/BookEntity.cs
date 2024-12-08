using DatabaseManager.Data.Entities.Shared;

namespace DatabaseManager.Data.Entities;

public class BookEntity : BaseEntity
{
    
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int? NumberOfPages { get; set; }
    public int? Year { get; set; }
    public List<AuthorEntity?> Authors { get; set; } = new();
    
    public BookEntity(){}
    
    public BookEntity(Dictionary<string, string> args)
    {
        Id = int.Parse(args["Id"]);
        Title = args["Title"];
        Description = args["Description"];
        NumberOfPages = int.Parse(args["NumberOfPages"]);
        Year = int.Parse(args["Year"]);
    }
    
}