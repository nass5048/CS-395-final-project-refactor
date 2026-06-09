using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_395_final_project_refactor;

public class TaskManager

{

    private List<TaskItem> tasks = new List<TaskItem>();

    private int nextId = 1;

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

        bool found = false;

        for (int i = 0; i < tasks.Count; i++)

        {

            if (tasks[i].Id == id)

            {

                tasks[i].Completed = true;

                tasks[i].CompletedAt = DateTime.Now;

                Console.WriteLine("Completed task: " + tasks[i].Title);

                found = true;

            }

        }

        if (!found)

        {

            Console.WriteLine("Task not found");

        }

    }

    public void PrintAllTasks()

    {

        Console.WriteLine("=== ALL TASKS ===");

        foreach (var t in tasks)

        {

            Console.WriteLine(t.ToString());

        }

    }

    public void PrintCompleted()

    {

        Console.WriteLine("=== COMPLETED TASKS ===");

        foreach (var t in tasks)

        {

            if (t.Completed)

            {

                Console.WriteLine(t.ToString());

            }

        }

    }

    public void PrintPending()

    {

        Console.WriteLine("=== PENDING TASKS ===");

        foreach (var t in tasks)

        {

            if (!t.Completed)

            {

                Console.WriteLine(t.ToString());

            }

        }

    }

    public void RemoveTask(int id)

    {

        bool removed = false;

        for (int i = 0; i < tasks.Count; i++)

        {

            if (tasks[i].Id == id)

            {

                Console.WriteLine("Removing task: " + tasks[i]);

                tasks.RemoveAt(i);

                removed = true;

                break;

            }

        }

        if (!removed)

        {

            Console.WriteLine("Task not found");

        }

    }

    public void EditTask(int id, string newTitle, string newDesc)

    {

        bool found = false;

        foreach (var t in tasks)

        {

            if (t.Id == id)

            {

                if (newTitle != null && newTitle != "")

                {

                    t.Title = newTitle;

                }

                if (newDesc != null)

                {

                    t.Description = newDesc;

                }

                Console.WriteLine("Edited task: " + id);

                found = true;

            }

        }

        if (!found)

        {

            Console.WriteLine("Task not found");

        }

    }

    public void PrintTaskDetails(int id)

    {

        foreach (var t in tasks)

        {

            if (t.Id == id)

            {

                Console.WriteLine("=== TASK DETAILS ===");

                Console.WriteLine("ID: " + t.Id);

                Console.WriteLine("Title: " + t.Title);

                Console.WriteLine("Description: " + t.Description);

                Console.WriteLine("Completed: " + t.Completed);

                Console.WriteLine("Created: " + t.CreatedAt);

                Console.WriteLine("Completed At: " + t.CompletedAt);

                return;

            }

        }

        Console.WriteLine("Task not found");

    }

    public void SearchTasks(string keyword)

    {

        Console.WriteLine("=== SEARCH RESULTS ===");

        foreach (var t in tasks)

        {

            if (t.Title.Contains(keyword) || t.Description.Contains(keyword))

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

