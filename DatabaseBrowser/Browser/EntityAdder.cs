using DatabaseManager.Data;
using DatabaseManager.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DatabaseManager.Browser;

public class EntityAdder
{
    
    private readonly AppDbContext _context = Bootstrap.GetApplication().Context;
    private readonly Type _entityType;
    private readonly string _entityName;
    private readonly EntityHandler _entityHandler;

    public EntityAdder(Type entityType, EntityHandler handler)
    {
        _entityType = entityType;
        _entityName = entityType.Name;
        _entityHandler = handler;
    }

    public void CreateNewEntity()
    {
        Console.Clear();
        switch (_entityName)
        {
            case "AuthorEntity":
                _context.Authors.Add(new AuthorEntity());
                break;
            case "BookEntity":
                _context.Books.Add(new BookEntity());
                break;
            case "BorrowEntity":
                _context.Borrows.Add(new BorrowEntity());
                break;
            case "ClientEntity":
                _context.Clients.Add(new ClientEntity());
                break;
        }
        _context.SaveChanges();
        _entityHandler.Handle();
    }
    
}