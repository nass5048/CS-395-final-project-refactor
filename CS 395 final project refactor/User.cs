using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_395_final_project_refactor;
public class User

{

    private string Username;

    private string Email;

    public TaskManager Manager;

    public User(string username, string email)

    {

        Username = username;

        Email = email;

        Manager = new TaskManager();

    }

    public void AddTask(string title, string desc)

    {

        Manager.AddNewTask(title, desc);

    }

    public void CompleteTask(int id)

    {

        Manager.MarkTaskAsDone(id);

    }

    public void PrintTasks()

    {

        Console.WriteLine("=== TASKS FOR USER: " + Username + " ===");

        Manager.PrintAllTasks();

    }

}
