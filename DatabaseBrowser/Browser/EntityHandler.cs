using DatabaseManager.Data;

namespace DatabaseManager.Browser;

public class EntityHandler
{

    private readonly AppDbContext _context;
    private readonly Type _entityType;
    private readonly string _entityName;
    
    public EntityHandler(AppDbContext context, Type entityType)
    {
        _context = context;
        _entityType = entityType.GenericTypeArguments[0];
        _entityName = _entityType.Name;
    }

    public void Handle()
    {
        switch(_entityName)
        {
            case "AuthorEntity":
                HandleAuthors();
                break;
        }

    }

    public void HandleAuthors()
    {
        List<BrowserRunnable> runnables = new List<BrowserRunnable>();
        foreach(var author in _context.Authors.ToList())
        {
            runnables.Add(new BrowserRunnable(author.Id.ToString(), () => { }));
        }
        if(runnables.Count > 0)
        {
            new BrowserList(_entityName + "\n", runnables.ToArray()).Display();
        } else
        {
            new BrowserList(_entityName + "\n", new BrowserRunnable("No records found...", GoToTableList)).Display();
        }
    }

    public void GoToTableList()
    {
        Bootstrap.GetApplication().DisplayEntities();
    }


}