using static System.Console;

namespace TaskManager;
public class Program
{
    public static void Main(string[] args)
    {
        TaskTracker taskTracker = new TaskTracker();
        taskTracker.LoadTasks();

        CommandHandler commandHandler = new CommandHandler(taskTracker);

        if (args.Length == 0 || args[0] == "help" || args[0] == "-h")
        {
            StartInteractiveMode(commandHandler);
        }
        else
        {
            commandHandler.ExecuteCommand(args);
        }
    }

    private static void StartInteractiveMode(CommandHandler commandHandler)
    {
        WriteLine("Entering interactive mode. Type 'exit' to quit.");
        while (true)
        {
            WriteLine(">");
            string input = ReadLine();
            if (string.IsNullOrWhiteSpace(input)) continue;

            string[] inputArgs = input.Split(' ');
            if (inputArgs[0].ToLower() == "exit") break;

            commandHandler.ExecuteCommand(inputArgs);
        }
    }
}