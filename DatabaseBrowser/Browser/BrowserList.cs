namespace DatabaseManager.Browser;

public class BrowserList
{

    private readonly BrowserRunnable[] _runnables;
    private readonly bool _counter;
    private readonly string _prefix;
    
    public BrowserList(String prefix, params BrowserRunnable[] runnables)
    {
        _prefix = prefix;
        _runnables = runnables;
        _counter = false;
    }

    public BrowserList(bool counter, String prefix, params BrowserRunnable[] runnables)
    {
        _prefix = prefix;
        _runnables = runnables;
        _counter = counter;
    }

    public void Display(int option = 0)
    {
        ConsoleKey key;
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
                Console.Write((_counter ? (i + 1) + ". " : " ") + runnable.Text);
                bool last = true;
                if (!runnable.Equals(_runnables.LastOrDefault()))
                {
                    last = false;
                    Console.Write("\n");
                }
                i++;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
                if (last)
                {
                    Console.Write("\n");
                }
            }
            key = Console.ReadKey(true).Key;
            if (key.Equals(ConsoleKey.DownArrow))
            {
                option++;
                if (option == _runnables.Length)
                {
                    option = 0;
                }
                Beep();
            } else if (key.Equals(ConsoleKey.UpArrow))
            {
                option--;
                if (option == -1)
                {
                    option = _runnables.Length - 1;
                }
                Beep();
            }
        } while(!key.Equals(ConsoleKey.Enter));

        Action? action = _runnables[option].Action;
        if (action != null)
        {
            action.Invoke();
            Beep();
        }
        else
        {
            Display(option);
        }
    }


    private void Beep()
    {
        ConsoleBeeper.Beep();
    }
    
}