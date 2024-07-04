using Microsoft.Extensions.Logging; //ILoggerProvider, ILogger, LogLevel

using static System.Console;

namespace Packt.Shared;

public class ConsoleLoggerProvider : ILoggerProvider
{
    public ILogger CreateLogger(string categoryName)
    {
        return new ConsoleLogger();
    }

    //If your logger uses unmanaged resources,
    //you can release the memory here
    public void Dispose() { }
}

public class ConsoleLogger : ILogger
{
    //If your user uses unmanaged resources, you can
    //return the class that implements IDisposable here
    public IDisposable BeginScope<TState>(TState state)
    {
        return null;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        //To avoid overloading, you can filter on the log level
        switch (logLevel)
        {
            case LogLevel.Trace:
            case LogLevel.Information:
            case LogLevel.None:
                return false;
            case LogLevel.Debug:
            case LogLevel.Warning:
            case LogLevel.Error:
            case LogLevel.Critical:
            default:
                return true;
        };
    }

    public void Log<TState>(LogLevel logLevel, 
        EventId eventId, TState state, Exception? exception,
        Func<TState, Exception, string> formatter)
    {
        if(eventId.Id == 20100)
        {
            //Log the level and event identifier
            Write($"Level: {logLevel}, Event ID: {eventId.Id}");

            //Only the output and event identifier
            if(state != null)
            {
                Write($", State: {state}");
            }

            if(exception != null)
            {
                Write($", Exception: {exception.Message}");
            }
            WriteLine();
        }
    }
}

