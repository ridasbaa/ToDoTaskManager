using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoTaskModels
{
    public class TaskDTO
    {
        public enum enPriority { Low = 0, Medium = 1, High = 2, NonSpecified = 3 };
        public enum enStatus { Pending = 0, Completed = 1, Cancelled = 2 };

        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
        public enPriority Priority { get; set; }
        public enStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public TaskDTO(int id, string title, string Desc, DateTime DeadLine, enPriority priority, enStatus status, DateTime CreatedAt)
        {
            this.ID = id;
            this.Title = title;
            this.Description = Desc;
            this.DeadLine = DeadLine;
            this.Priority = priority;
            this.Status = status;
            this.CreatedAt = CreatedAt;
        }

    }
}
