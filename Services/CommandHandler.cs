using System;
using static System.Console;

namespace TaskManager;
public class CommandHandler
{
    private readonly TaskTracker _taskTracker;

    public CommandHandler(TaskTracker taskTracker)
    {
        _taskTracker = taskTracker;
    }

    public void ExecuteCommand(string[] args)
    {
        string command = args[0].ToLower();

        switch (command)
        {
            case "add":
                _taskTracker.AddTask(args);
                break;
            case "update":
                _taskTracker.UpdateTask(int.Parse(args[1]), args[2]);
                break;
            case "delete":
                _taskTracker.DeleteTask(int.Parse(args[1]));
                break;
            case "inprogress":
                HandleMissingIdCommand(args);
                _taskTracker.MarkTaskAsInProgress(int.Parse(args[1]));
                break;
            case "complete":
                HandleMissingIdCommand(args);
                _taskTracker.MarkTaskAsCompleted(int.Parse(args[1]));
                break;
            case "list":
                HandleListCommand(args);
                break;
            case "help":
                ShowHelp();
                break;
            default:
                WriteLine("Invalid command. Type 'help' or '-h' for help.");
                break;
        }
    }

    private void HandleListCommand(string[] args)
    {
        if (args.Length == 1)
        {
            _taskTracker.ListAllTasks();
        }
        else
        {
            _taskTracker.ListTaskByStatus(args);
        }
    }

    private void HandleMissingIdCommand(string[] args)
    {
        if (args.Length != 2)
        {
            WriteLine("Invalid command. Type 'help' or '-h' for help.");
        }
    }

    private void ShowHelp()
    {
        WriteLine("Available commands:");
        WriteLine("add <description> - Add a new task");
        WriteLine("update <id> <description> - Update a task");
        WriteLine("delete <id> - Delete a task");
        WriteLine("inprogress <id> - Mark a task as in progress");
        WriteLine("complete <id> - Mark a task as completed");
        WriteLine("list - List all tasks");
        WriteLine("list <status> - List tasks by status");
        WriteLine("help - Show this help message");
    }
}