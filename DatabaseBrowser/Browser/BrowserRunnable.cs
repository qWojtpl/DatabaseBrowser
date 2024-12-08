namespace DatabaseManager.Browser;

public class BrowserRunnable
{

    public string Text { get; private set; }
    public Action? Action { get; private set; }
    
    public BrowserRunnable(String text, Action? action)
    {
        Text = text;
        Action = action;
    }
    
}