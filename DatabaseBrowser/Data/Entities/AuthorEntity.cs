using DatabaseManager.Data.Entities.Shared;

namespace DatabaseManager.Data.Entities;

public class AuthorEntity : BasePersonalEntity
{
    
    public List<BookEntity?> Books { get; set; } = new();

    public AuthorEntity(){}
    
    public AuthorEntity(Dictionary<string, string> args)
    {
        Id = int.Parse(args["Id"]);
        FirstName = args["FirstName"];
        LastName = args["LastName"];
    }
    
}