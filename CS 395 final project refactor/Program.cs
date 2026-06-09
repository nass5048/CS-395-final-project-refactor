using CS_395_final_project_refactor;

namespace TaskManagerApp;

public class Program
{

    static void Main(string[] args)

    {

        User u = new User("Mike", "mike@example.com");

        u.AddTask("Clean room", "Vacuum and dust everything");

        u.AddTask("Study C#", "Finish refactoring assignment");

        u.AddTask("Buy groceries", "Milk, eggs, bread");

        u.PrintTasks();

        u.CompleteTask(2);

        u.PrintTasks();

        u.Manager.PrintCompleted();

        u.Manager.PrintPending();

        u.Manager.EditTask(1, "Clean entire room", "Vacuum, dust, mop");

        u.Manager.PrintTaskDetails(1);

        u.Manager.SearchTasks("Clean");

        u.Manager.SortTasksByTitle();

        u.PrintTasks();

        u.Manager.PrintStats();

        u.Manager.RemoveTask(3);

        u.PrintTasks();

        u.Manager.ClearAllTasks();

        u.PrintTasks();

    }

}
