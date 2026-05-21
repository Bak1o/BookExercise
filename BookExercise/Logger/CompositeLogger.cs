namespace BookExercise.Logger;
public class CompositeLogger : Logger
{
    private readonly FileLogger _fileLogger;
    private readonly ConsoleLogger _consoleLogger;
    public CompositeLogger()
    {
        _fileLogger = new FileLogger();
        _consoleLogger = new ConsoleLogger();
    }
    public CompositeLogger(FileLogger fileLogger, ConsoleLogger consoleLogger)
    {
        _fileLogger = fileLogger;
        _consoleLogger = consoleLogger;
    }

    public override void Log(string message)
    {
        _fileLogger.Log(message);
        _consoleLogger.Log(message);
    }
}
