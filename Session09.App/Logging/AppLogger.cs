namespace Session09.App.Logging;

// Part 2 - Q5: Singleton pattern.
public class AppLogger
{
    // 1) Private static field that holds the single instance (starts as null).
    private static AppLogger? _instance;

    // 2) Private constructor: nobody outside this class can call "new AppLogger()".
    private AppLogger()
    {
    }

    // 3) Public static method: creates the instance only on the FIRST call,
    //    then returns the same instance every time.
    public static AppLogger GetLogger()
    {
        if (_instance is null)
            _instance = new AppLogger();

        return _instance;
    }
}
