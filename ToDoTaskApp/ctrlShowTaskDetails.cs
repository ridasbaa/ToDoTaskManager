using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoTaskBusinessLayer;

namespace ToDoTaskApp
{
    public partial class ctrlShowTaskDetails : UserControl
    {
        int _TaskID = -1;
        public ctrlShowTaskDetails()
        {
            InitializeComponent();
        }

        public void LoadInfo(int TaskID)
        {
            _TaskID = TaskID;
            clsTask Task = clsTask.Find(TaskID);
            if (Task == null)
            {
                MessageBox.Show($"No Task with ID {TaskID} was Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblTaskID.Text = Task.ID.ToString();
            lblTitle.Text = Task.Title;
            lblDescription.Text = Task.Description == string.Empty ? "" : Task.Description;
            lblDeadLine.Text = Task.DeadLine.ToString();
            lblPriority.Text = Task.Priority.ToString();
            lblStatus.Text = Task.Status.ToString();
            lblCreatedAt.Text = Task.CreatedAt.ToString();

        }

        public void Refresh()
        {
            LoadInfo(_TaskID);
        }
    }
}
