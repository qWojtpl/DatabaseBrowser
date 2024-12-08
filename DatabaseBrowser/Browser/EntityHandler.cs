using System.ComponentModel;
using System.Text;
using DatabaseManager.Data;
using DatabaseManager.Data.Entities;
using DatabaseManager.Data.Entities.Shared;
using Microsoft.EntityFrameworkCore;

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
        runnables.Add(new BrowserRunnable("  Go back", GoToTableList));
        runnables.Add(new BrowserRunnable("  New record", AddNewRecord));
        switch(_entityName)
        {
            case "AuthorEntity":
                PrintEntities(runnables, _context.Authors.ToList());
                break;
            case "BookEntity":
                PrintEntities(runnables, _context.Books.ToList());
                break;
            case "BorrowEntity":
                PrintEntities(runnables, _context.Borrows
                    .Include(n => n.Book)
                    .Include(n => n.Client)
                    .ToList());
                break;
            case "ClientEntity":
                PrintEntities(runnables, _context.Clients.ToList());
                break;
        }
        if(runnables.Count == 2)
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
            if (entity == null)
            {
                continue;
            }
            StringBuilder valueBuilder = new StringBuilder();
            int total = entity.GetType().GetProperties().Length;
            int i = 0;
            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(entity))
            {
                string name = prop.Name;
                object? value = prop.GetValue(entity);
                if (prop.PropertyType.Name.StartsWith("List"))
                {
                    i++;
                    continue;   
                }
                if (value == null)
                {
                    value = "NULL";
                }
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
                StringBuilder divider = new StringBuilder();
                for (int j = 0; j < total; j++)
                {
                    divider.Append("---------------");
                }
                runnables.Add(new BrowserRunnable(divider.ToString(), null));
            }
            runnables.Add(new BrowserRunnable(valueBuilder.ToString(), null, () => { DeleteRecord<T>(entity); }));
        }
    }

    private void AddNewRecord()
    {
        new EntityAdder(_context, _entityType, this).CreateNewEntity();
    }

    private void DeleteRecord<T>(T entity)
    {
        try
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }
        catch (Exception)
        {
            Application.MessageBox((IntPtr) 0, "Entity is protected due to relation!", "Error", 0);
        }
        ConsoleBeeper.Beep();
        Handle();
    }

    private void GoToTableList()
    {
        Bootstrap.GetApplication().DisplayEntities();
    }


}