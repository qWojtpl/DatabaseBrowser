using DatabaseManager.Data.Entities.Shared;

namespace DatabaseManager.Data.Entities;

public class AuthorEntity : BasePersonalEntity
{
    
    public List<BookEntity?> Books { get; set; } = new();
    
}