namespace DatabaseManager.Browser;

public static class ConsoleBeeper
{

    public static void Beep()
    {
        new Thread(() =>
        {
            Console.Beep(2000, 200);
        }).Start();
    }
    
}