using System.ComponentModel;
using System.Text;
using DatabaseManager.Data;
using DatabaseManager.Data.Entities;
using DatabaseManager.Data.Entities.Shared;

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
                PrintEntities(runnables, _context.Authors.ToList());
                break;
            case "BookEntity":
                PrintEntities(runnables, _context.Books.ToList());
                break;
            case "BorrowEntity":
                PrintEntities(runnables, _context.Borrows.ToList());
                break;
            case "ClientEntity":
                PrintEntities(runnables, _context.Clients.ToList());
                break;
        }
        if(runnables.Count == 0)
        {
            runnables.Add(new BrowserRunnable("No records found...", null));
        }
        new BrowserList(_entityName + "\n", runnables.ToArray()).Display();
    }

    public void PrintEntities<T>(List<BrowserRunnable> runnables, List<T> entities)
    {
        bool headerBuilt = false;
        StringBuilder headerBuilder = new StringBuilder();
        foreach(var entity in entities)
        {
            StringBuilder valueBuilder = new StringBuilder();
            int total = entity.GetType().GetProperties().Length;
            int i = 0;
            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(entity))
            {
                if (prop.PropertyType != typeof(int) && prop.PropertyType != typeof(string))
                {
                    i++;
                    continue;
                }
                string name = prop.Name;
                object value = prop.GetValue(entity).ToString();
                if (i != total - 1)
                {
                    valueBuilder.Append($"{value, -15} | ");
                }
                else
                {
                    valueBuilder.Append($"{value}");
                }
                if (!headerBuilt)
                {
                    if (i != total - 1)
                    {
                        headerBuilder.Append($"{name, -15} | ");
                    }
                    else
                    {
                        headerBuilder.Append($"{name}");
                    }
                }
                i++;
            }
            if (!headerBuilt)
            {
                headerBuilt = true;
                runnables.Add(new BrowserRunnable(headerBuilder.ToString(), null));
            }
            runnables.Add(new BrowserRunnable("---------------------------------------------", null));
            runnables.Add(new BrowserRunnable(valueBuilder.ToString(), null));

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