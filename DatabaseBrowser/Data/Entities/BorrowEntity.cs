using DatabaseManager.Data.Entities.Shared;

namespace DatabaseManager.Data.Entities;

public class BorrowEntity : BaseEntity
{
    
    public ClientEntity? Client { get; set; }
    public BookEntity? Book { get; set; }
    public DateTime? BorrowDate { get; set; }
    
}