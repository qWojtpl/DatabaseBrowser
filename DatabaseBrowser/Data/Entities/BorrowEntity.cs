using DatabaseManager.Data.Entities.Shared;

namespace DatabaseManager.Data.Entities;

public class BorrowEntity : BaseEntity
{
    
    public ClientEntity? Client { get; set; }
    public BookEntity? Book { get; set; }
    public DateTime? BorrowDate { get; set; }

    public BorrowEntity(){}
    
    public BorrowEntity(Dictionary<string, string> args)
    {
        Id = int.Parse(args["Id"]);
        Client = Bootstrap.GetApplication().Context.Clients.FirstOrDefault(n => n.Id == int.Parse(args["Client"]));
        Book = Bootstrap.GetApplication().Context.Books.FirstOrDefault(n => n.Id == int.Parse(args["Book"]));
        BorrowDate = DateTime.Parse(args["BorrowDate"]);
    }
    
}