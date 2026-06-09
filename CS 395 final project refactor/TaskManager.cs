using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CS_395_final_project_refactor;

public class TaskManager

{

    private List<TaskItem> tasks = new List<TaskItem>();

    private int nextId = 1;

    public int GetTaskIndex(int id)
    {
        int index = -1;

        for (int i = 0; i < tasks.Count; i++)
        {

            if (tasks[i].Id == id)
            {
                index = i;
                return index;
            }
        }

        return index;
    }

    public void AddNewTask(string title, string description)
    {

        if (title == null || title == "")

        {

            Console.WriteLine("Error: title empty");

            return;

        }

        if (description == null)

        {

            description = "";

        }

        TaskItem t = new TaskItem(nextId, title, description);

        tasks.Add(t);

        nextId++;

        Console.WriteLine("Added task: " + title);

    }

    public void MarkTaskAsDone(int id)
    {

        int index = GetTaskIndex(id);

        if (index != -1)
        {
            tasks[index].MarkAsCompleted();

            Console.WriteLine("Completed task: " + tasks[index].Title);
        }
        else
        {

            Console.WriteLine("Task not found");

        }

    }

    public void PrintTasks(Func<TaskItem, bool>? action = null)
    {
        foreach (var t in tasks)

        {
            if (action == null || action(t))
            {
                Console.WriteLine(t.ToString());
            }

        }
    }

    public void PrintAllTasks()
    {

        Console.WriteLine("=== ALL TASKS ===");

        PrintTasks();

    }

    public void PrintCompleted()
    {

        Console.WriteLine("=== COMPLETED TASKS ===");

        PrintTasks(t => t.Completed);

    }

    public void PrintPending()
    {

        Console.WriteLine("=== PENDING TASKS ===");

        PrintTasks(t => !t.Completed);

    }

    public void RemoveTask(int id)
    {
        int index = GetTaskIndex(id);
        if (index != -1)
        {
            Console.WriteLine("Removing task: " + tasks[index]);

            tasks.RemoveAt(index);
        }
        else
        {

            Console.WriteLine("Task not found");

        }

    }

    public void EditTask(int id, string newTitle, string newDesc)
    {
        int index = GetTaskIndex(id);

        if (index != -1)
        {
            if (newTitle != null && newTitle != "")
            {
                tasks[index].Title = newTitle;
            }

            if (newDesc != null)
            {
                tasks[index].Description = newDesc;
            }

            Console.WriteLine("Edited task: " + id);
        } 
        else
        {

            Console.WriteLine("Task not found");

        }

    }

    public void PrintTaskDetails(int id)
    {
        int index = GetTaskIndex(id);

        if (index != -1)
        {
            tasks[index].PrintDetails();
            return;
        }

        Console.WriteLine("Task not found");

    }

    public void SearchTasks(string keyword)
    {

        Console.WriteLine("=== SEARCH RESULTS ===");

        foreach (var t in tasks)

        {

            if (t.Title.ToLower().Contains(keyword.ToLower()) || t.Description.ToLower().Contains(keyword.ToLower()))

            {

                Console.WriteLine(t.ToString());

            }

        }

    }

    public void SortTasksByDate()
    {

        tasks = tasks.OrderBy(t => t.CreatedAt).ToList();

        Console.WriteLine("Tasks sorted by date");

    }

    public void SortTasksByTitle()
    {

        tasks = tasks.OrderBy(t => t.Title).ToList();

        Console.WriteLine("Tasks sorted by title");

    }

    public void ClearAllTasks()
    {

        Console.WriteLine("Clearing all tasks...");

        tasks.Clear();

        nextId = 1;

    }

    public void PrintStats()
    {

        int total = tasks.Count;

        int done = tasks.Count(t => t.Completed);

        int pending = total - done;

        Console.WriteLine("=== STATS ===");

        Console.WriteLine("Total: " + total);

        Console.WriteLine("Completed: " + done);

        Console.WriteLine("Pending: " + pending);

    }

}

