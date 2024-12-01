namespace DatabaseManager.Browser;

public class BrowserList
{

    private readonly BrowserRunnable[] _runnables;
    private readonly string _prefix;
    
    public BrowserList(String prefix, params BrowserRunnable[] runnables)
    {
        _prefix = prefix;
        _runnables = runnables;
    }

    public void Display()
    {
        ConsoleKey key;
        int option = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            Console.WriteLine(_prefix);
            int i = 0;
            foreach (BrowserRunnable runnable in _runnables)
            {
                if (i == option)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                Console.WriteLine((i++ + 1) + ". " + runnable.Text);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            key = Console.ReadKey(true).Key;
            if (key.Equals(ConsoleKey.Enter))
            {
                _runnables[option].Action.Invoke();
                break;
            } else if (key.Equals(ConsoleKey.DownArrow))
            {
                option++;
                if (option == _runnables.Length)
                {
                    option = 0;
                }
            } else if (key.Equals(ConsoleKey.UpArrow))
            {
                option--;
                if (option == -1)
                {
                    option = _runnables.Length - 1;
                }
            }
        } while(true);
    }
    
}