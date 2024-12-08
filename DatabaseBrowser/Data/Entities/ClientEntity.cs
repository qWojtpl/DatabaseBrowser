using DatabaseManager.Data.Entities.Shared;

namespace DatabaseManager.Data.Entities;

public class ClientEntity : BasePersonalEntity
{
    
    public List<BorrowEntity?> Borrows { get; set; } = new();
    
}