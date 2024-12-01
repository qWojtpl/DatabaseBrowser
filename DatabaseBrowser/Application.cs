using System.Reflection;
using DatabaseManager.Data;
using DatabaseManager.Browser;

namespace DatabaseManager;

public class Application
{

    private AppDbContext _context;

    public void Start()
    {
        _context = new AppDbContext();
        _context.Database.EnsureCreated();
        DisplayEntities();
    }

    public void DisplayEntities()
    {
        List<BrowserRunnable> runnables = new List<BrowserRunnable>();
        
        foreach (var property in _context.GetType().GetProperties(BindingFlags.DeclaredOnly | 
                                                                  BindingFlags.Instance | 
                                                                  BindingFlags.Public))
        {
            EntityHandler handler = new EntityHandler(_context, property.PropertyType);
            runnables.Add(new BrowserRunnable(property.Name, handler.Handle));
        }

        if (runnables.Count > 0)
        {
            new BrowserList("Tables: \n", runnables.ToArray()).Display();
        }
        else
        {
            Console.WriteLine("No tables found.");
        }
        
    }
    
}