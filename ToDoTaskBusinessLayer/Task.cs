using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoTaskDataAccessLayer;

namespace ToDoTaskBusinessLayer
{
    public class Task
    {
        public TaskDTO TDTO { get { return new TaskDTO(this.ID, this.Title, this.Description, this.DeadLine,
                                                       (TaskDTO.enPriority)this.Priority, (TaskDTO.enStatus)this.Status, this.CreatedAt); } }

        public enum enMode { AddNew, Update}
        public enMode Mode = enMode.AddNew;
        public enum enPriority { Low = 1, Medium = 2, High = 3 };
        public enum enStatus { Pending = 1, Completed = 2, Cancelled = 3 };

        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
        public enPriority Priority { get; set; }
        public enStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public Task(TaskDTO TDTO, enMode mode = enMode.AddNew)
        {
            this.ID = TDTO.ID;
            this.Title = TDTO.Title;
            this.Description = TDTO.Description;
            this.DeadLine = TDTO.DeadLine;
            this.Priority = (Task.enPriority)TDTO.Priority;
            this.Status = (Task.enStatus)TDTO.Status;
            this.CreatedAt = TDTO.CreatedAt;
            Mode = mode;
        }

        public static List<TaskDTO> GetAllTasks()
        {
            return TaskData.GetAllTasks();
        }

        public static TaskDTO GetTaskByID(int id)
        {
            return TaskData.GetTaskByID(id);
        }

        private bool _AddNewTask()
        {
            this.ID = TaskData.AddNewTask(NewTask); 

            return this.ID != -1;
        }





    }
}
