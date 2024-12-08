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
        List<BrowserRunnable> runnables = new List<BrowserRunnable>();
        runnables.Add(new BrowserRunnable("   Go back", () => { Bootstrap.GetApplication().DisplayEntities(); }));
        runnables.Add(new BrowserRunnable("   New record", () => { AddNewRecord(); }));
        switch(_entityName)
        {
            case "AuthorEntity":
                PrintAuthors(runnables);
                break;
        }
        if(runnables.Count == 0)
        {
            runnables.Add(new BrowserRunnable("No records found...", null));
        }
        new BrowserList(_entityName + "\n", runnables.ToArray()).Display();
    }

    public void PrintAuthors(List<BrowserRunnable> runnables)
    {
        foreach(var author in _context.Authors.ToList())
        {
            runnables.Add(new BrowserRunnable(String.Format("{0,-15} | {1,-15} | {2}", "Id", "FirstName", "LastName"), null));
            runnables.Add(new BrowserRunnable("---------------------------------------------", null));
            runnables.Add(new BrowserRunnable(String.Format("{0,-15} | {1,-15} | {2}", author.Id, author.FirstName, author.LastName), () => { AddNewRecord(); }));
        }
    }

    public void AddNewRecord()
    {
        
    }

    public void GoToTableList()
    {
        Bootstrap.GetApplication().DisplayEntities();
    }


}