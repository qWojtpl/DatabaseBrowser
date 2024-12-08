using System.Reflection;
using System.Runtime.InteropServices;
using DatabaseManager.Data;
using DatabaseManager.Browser;

namespace DatabaseManager;

public class Application
{

    private AppDbContext _context;
    public AppDbContext Context { get => _context; }

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
            EntityHandler handler = new EntityHandler(property.PropertyType);
            runnables.Add(new BrowserRunnable(property.Name, handler.Handle));
        }

        if (runnables.Count > 0)
        {
            new BrowserList(true, "Tables: \n", runnables.ToArray()).Display();
        }
        else
        {
            Console.WriteLine("No tables found.");
        }
        
    }
    
    [DllImport("User32.dll", CharSet = CharSet.Unicode)]
    public static extern int MessageBox(IntPtr h, string m, string c, int type);
    
}