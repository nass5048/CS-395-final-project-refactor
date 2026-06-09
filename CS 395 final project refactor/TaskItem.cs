using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_395_final_project_refactor;
public class TaskItem
{

    public int Id;

    public string Title;

    public string Description;

    public bool Completed;

    public DateTime CreatedAt;

    public DateTime? CompletedAt;

    public TaskItem(int id, string title, string description)

    {

        Id = id;

        Title = title;

        Description = description;

        Completed = false;

        CreatedAt = DateTime.Now;

        CompletedAt = null;

    }


    public override string ToString()

    {

        return $"[{Id}] {Title} - {(Completed ? "DONE" : "PENDING")} - Created: {CreatedAt}";

    }

}
