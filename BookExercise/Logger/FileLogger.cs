namespace BookExercise.Logger;
public class FileLogger : Logger
{
    public override void Log(string message)
    {
        File.AppendAllText("Log.txt", message + Environment.NewLine);
    }
}
