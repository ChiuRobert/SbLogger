<h1 align="center">C# Logger</h1>

<p align="center">
  This is a logging system meant to ease debugging in a C# projects.
  Can also be used in Unity projects.
</p>

### Usage

<p>
In order to use the Logger you need to add the .dll file and import the necessary libraries depending on the case:

```C#
using SbLogger;
using SbLogger.Filter;
using SbLogger.Format;
using SbLogger.Handlers;
using SbLogger.Levels;
```

</p>

### Declaring a logger

Assuming you have a class called **Program**, creating a Logger can be done this way:

```C#
private static readonly SLogger LOGGER = SLogger.GetLogger(nameof(Program));
```

This will automatically create a Logger that will save all the logs into a file having the following path **StreamingAssets/Logs/Log.txt** and that's using a level filter that saves **ALL** logs.

In order to change the path of the file the logger will write at simply use:

```C#
private static string LOGGER_PATH = "./Log.txt";
private static readonly SLogger LOGGER = SLogger.GetLogger(nameof(Program), LOGGER_PATH);
```

This will create a logger that will save all the logs into a file called **Log.txt** created in the **root** folder.


### Using a logger

Assuming you've created a logger into a class called **Program** inside a method called **LoggerTest**, using it can be done the following ways:

Simply logging an INFO message:

```C#
LOGGER.Log(Level.INFO, "This is an INFO level message.");
```

Where the default logging levels are:

```yaml
ALL (highest value)
SEVERE 
WARNING
INFO
CONFIG
FINE 
OFF (lowest value)
```

The **OFF** level can be used to turn off logging, and the **ALL** level can be used to enable logging of all messages.

Creating a custom level is possible by extending **Level** like this:

```C#
class AwesomeLevel : Level
{
    public static readonly Level AWESOME = new AwesomeLevel("AWESOME", 9001);

    public AwesomeLevel(string name, int level) : base(name, level) { }
}
```

You will then be able to log using the name **AWESOME** and the level **9001** will be checked in the filter against the existing logging level.
The new logging level can be used this way:

```C#
LOGGER.Log(AwesomeLevel.AWESOME, "This is an AWESOME message");
```

Logging info with multiple objects or exceptions can be done the following way:

```C#
int energyUsedThisTurn = 42;
int energyLeft = 12;

LOGGER.Log(Level.WARNING, "The amount of energy used this turn",
new Param[]
{
    new Param { Name = nameof(energyUsedThisTurn), Value = energyUsedThisTurn },
    new Param { Name = nameof(energyLeft), Value = energyLeft }
});

LOGGER.Log(Level.SEVERE, "Error at creating file", new FileNotFoundException()); // equivalent to LOGGER.Log(Level.SEVERE, "Error at creating file", exception);
```

Note: The objects saved inside Param can be of any type including custom objects.

Assuming you want to change the logging level from **ALL** to **INFO** so only logs with a level of at least **INFO** to be logged you can do the following:

```C#
LOGGER.Filter = new LevelFilter(Level.INFO);
```

Checking if a level can be logged can be done so:

```C#
bool canLogConfig = LOGGER.IsLoggable(Level.CONFIG);
```

Getting the minimum level that can be logged can be done so:

```C#
Level levelToLog = LOGGER.GetLevel();
```


If you want to create your own Handler that will, for example, write the logs to the console instead of the file, you may do so by extending the **Handler** class like this:

```C#
class ConsoleHandler : Handler
{
    /// <summary>
    /// Default constructor.
    /// It initializes a LevelFilter and a DefaultFormatter
    /// </summary>
    public ConsoleHandler() : this(new LevelFilter(), new DefaultFormatter()) { }

    /// <summary>
    /// Construct a ConsoleHandler given the specific Filter and the Formatter
    /// </summary>
    /// <param name="filter">Log filter</param>
    /// <param name="formatter">Log formatter</param>
    public ConsoleHandler(IFilter filter, Formatter formatter)
    {
        Filter = filter;
        Formatter = formatter;
    }

    /// <summary>
    /// Writes a LogRecord to the console.
    /// </summary>
    /// <param name="record">Description of the log event</param>
    public override void Write(LogRecord record)
    {
        if (Filter.IsLoggable(record))
        {
            Console.WriteLine(Formatter.Format(record));
        }
    }
}
```

You may apply your new Handler like this:

```C#
LOGGER.Handler = new ConsoleHandler();
```

If you want to change the way your logs are being formatted, simply extend the **Formatter** and override its method.


### Output of a logger

The output of all the logs written above is the following:

```XML
[28-03-2020 18:45:40] INFO - Program(58):LoggerTest - This is an INFO level message.
[28-03-2020 18:45:40] AWESOME - Program(59):LoggerTest - This is an AWESOME message
[28-03-2020 18:45:40] WARNING - Program(64):LoggerTest - The amount of energy used this turn. Parameters: { energyUsedThisTurn = 42, energyLeft = 12 }
[28-03-2020 18:45:40] SEVERE - Program(71):LoggerTest - Error at creating file. Failed with ERROR: Unable to find the specified file.
```

The default format that the logger is using is giving the following information:

```XML
[dd-MM-yyyy HH:mm:ss] Level - ClassName(LineNumber):MethodName - Message
```

[![Download API](https://img.shields.io/badge/download-API-blue?style=for-the-badge)](https://github.com/ChiuRobert/SbLogger/releases/latest/download/SbLogger.dll)