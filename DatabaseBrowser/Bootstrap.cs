namespace DatabaseManager;

public static class Bootstrap
{

    private static Application? _application;
    
    
    public static void Main(string[] args)
    {
        GetApplication().Start();
    }

    public static Application GetApplication()
    {
        if (_application == null)
        {
            _application = new Application();
        }
        return _application;
    }
    
}