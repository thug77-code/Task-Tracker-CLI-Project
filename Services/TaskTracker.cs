using System;
using System.Text.Json;
using static System.Console;

namespace TaskManager
{

    public class TaskTracker
    {
        List<Task> taskList = new List<Task>();

        public void AddTask(string[] newTask)
        {
            string taskDescription = string.Join(" ", newTask.Skip(1));
            if (string.IsNullOrWhiteSpace(taskDescription))
            {
                Console.WriteLine("Task description could not be empty");
                return;
            }

            var task = CreateTask(taskDescription);
            taskList.Add(task);
            SaveTasks();

            WriteLine($"Task added successfully with ID: {task.Id}");
        }

        public void UpdateTask(string idInput, string newDescription)
        {
            if (!int.TryParse(idInput, out int id))
            {
                Console.WriteLine("Invalid task ID format.");
                return;
            }
            if (string.IsNullOrWhiteSpace(newDescription))
            {
                WriteLine("Task description could not be empty");
                return;
            }

            var task = taskList.FirstOrDefault(x => x.Id == id);
            if (task == null)
            {
                WriteLine("Task not found");
                return;
            }

            task.Description = newDescription;
            SaveTasks();

            WriteLine("Task successfully updated");
        }

        public void DeleteTask(string idInput)
        {
            if (!int.TryParse(idInput, out int id))
            {
                WriteLine("Task description could not be empty");
                return;
            }
            var task = taskList.FirstOrDefault(x => x.Id == id);
            if (task == null)
            {
                WriteLine("Task not found");
                return;
            }

            taskList.Remove(task);
            SaveTasks();

            WriteLine("Task successfully deleted");
        }

        public void MarkTaskAsInProgress(string idInput)
        {
            if (!int.TryParse(idInput, out int id))
            {
                WriteLine("Task description could not be empty");
                return;
            }
            var task = taskList.FirstOrDefault(x => x.Id == id);
            if (task == null)
            {
                WriteLine("Task not found");
                return;
            }

            task.Status = "In Progress";
            SaveTasks();

            WriteLine("Task successfully marked as In Progress");
        }

        public void MarkTaskAsCompleted(string idInput)
        {
            if (!int.TryParse(idInput, out int id))
            {
                WriteLine("Task description could not be empty");
                return;
            }
            var task = taskList.FirstOrDefault(x => x.Id == id);
            if (task == null)
            {
                WriteLine("Task not found");
                return;
            }

            task.Status = "Done";
            SaveTasks();

            WriteLine("Task successfully marked as Done");
        }

        public void ListAllTasks()
        {
            foreach (var task in taskList)
            {
                WriteLine($"{task.Id} - {task.Description} - {task.Status}");
            }
        }

        public void ListTaskByStatus(string[] args)
        {
            bool isDone = args.Contains("done");
            bool isInProgress = args.Contains("progress");
            bool istoDo = args.Contains("to do");

            if (isDone)
            {
                foreach (var task in taskList.Where(t => t.Status == "Done"))
                {
                    WriteLine($"Task ID: {task.Id}, Description: {task.Description}, Status: {task.Status}");
                }
            }

            if (isInProgress)
            {
                foreach (var task in taskList.Where(t => t.Status == "In Progress"))
                {
                    WriteLine($"Task ID: {task.Id}, Description: {task.Description}, Status: {task.Status}");
                }
            }

            if (istoDo)
            {
                foreach (var task in taskList.Where(t => t.Status == "To Do"))
                {
                    WriteLine($"Task ID: {task.Id}, Description: {task.Description}, Status: {task.Status}");
                }
            }
        }


        private void SaveTasks()
        {
            string jsonString = JsonSerializer.Serialize(taskList);
            File.WriteAllText("tasks.json", jsonString);
        }

        public void LoadTasks()
        {
            if (File.Exists("tasks.json"))
            {
                string jsonString = File.ReadAllText("tasks.json");
                taskList = JsonSerializer.Deserialize<List<Task>>(jsonString);
            }
        }

        private Task CreateTask(string description)
        {
            return new Task
            {
                Description = description,
                Id = taskList.Count + 1
            };
        }
    }
}
