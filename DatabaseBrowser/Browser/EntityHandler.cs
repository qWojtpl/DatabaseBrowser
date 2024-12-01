using DatabaseManager.Data;
using DatabaseManager.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseManager.Browser;

public class EntityHandler
{

    private readonly AppDbContext _context;
    private readonly Type _entityType;
    
    public EntityHandler(AppDbContext context, Type entityType)
    {
        _context = context;
        _entityType = entityType;
    }

    public void Handle()
    {
        Console.WriteLine("Handling " + _entityType.GenericTypeArguments[0].Name);
    }

}