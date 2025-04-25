using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoTaskDataAccessLayer;
using ToDoTaskModels;
namespace ToDoTaskBusinessLayer
{
    public class clsTask
    {
        public TaskDTO TDTO { get { return new TaskDTO(this.ID, this.Title, this.Description, this.DeadLine,
                                                       (TaskDTO.enPriority)this.Priority, (TaskDTO.enStatus)this.Status, this.CreatedAt); } }

        public enum enMode { AddNew, Update}
        public enMode Mode = enMode.AddNew;
        public enum enPriority { Low = 0, Medium = 1, High = 2, NonSpecified = 3 };
        public enum enStatus { Pending = 0, Completed = 1, Cancelled = 2 };

        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
        public enPriority Priority { get; set; }
        public enStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public clsTask(TaskDTO TDTO, enMode mode = enMode.AddNew)
        {
            this.ID = TDTO.ID;
            this.Title = TDTO.Title;
            this.Description = TDTO.Description;
            this.DeadLine = TDTO.DeadLine;
            this.Priority = (clsTask.enPriority)TDTO.Priority;
            this.Status = (clsTask.enStatus)TDTO.Status;
            this.CreatedAt = TDTO.CreatedAt;
            Mode = mode;
        }

        public static List<TaskDTO> GetAllTasks()
        {
            return TaskData.GetAllTasks();
        }

        public static clsTask Find(int id)
        {
            TaskDTO TDTO = TaskData.GetTaskByID(id);

            if (TDTO != null)
            {
                return new clsTask(TDTO, enMode.Update);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewTask()
        {
            this.ID = TaskData.AddNewTask(TDTO); 

            return this.ID != -1;
        }

        private bool _UpdateTask()
        {
            return TaskData.UpdateTask(TDTO);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTask())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    case enMode.Update:
                    return _UpdateTask();
            }
            return false;
        }

        public static bool DeleteTask(int id)
        {
            return TaskData.DeleteTask(id);
        }

        public static bool UpdateStatus(int TaskID, int Status)
        {
            return TaskData.UpdateStatus(TaskID, Status);
        }


    }
}
