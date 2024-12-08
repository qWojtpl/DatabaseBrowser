using DatabaseManager.Data.Entities.Shared;

namespace DatabaseManager.Data.Entities;

public class ClientEntity : BasePersonalEntity
{
    
    public List<BorrowEntity?> Borrows { get; set; } = new();
    
    public ClientEntity(){}
    
    public ClientEntity(Dictionary<string, string> args)
    {
        Id = int.Parse(args["Id"]);
        FirstName = args["FirstName"];
        LastName = args["LastName"];
    }
    
}