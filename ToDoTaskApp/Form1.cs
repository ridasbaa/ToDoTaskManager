using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ToDoTaskBusinessLayer;
using ToDoTaskModels;

namespace ToDoTaskApp
{
    public partial class Form1 : Form
    {
        List<TaskDTO> AllTasks = new List<TaskDTO>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvAllTasks.RowTemplate.Height = 28;
            AllTasks = clsTask.GetAllTasks();
            dgvAllTasks.DataSource = AllTasks.Select(task => new { task.ID, task.Title, task.Status}).ToList();
            lblRecords.Text = AllTasks.Count.ToString();
            ctrlAddTask1.labelIDVisible = false;
            ctrlAddTask1.lblTaskIDVisible = false;

            dgvAllTasks.Columns[0].HeaderText = "Task ID";
            dgvAllTasks.Columns[0].Width = 100;

            dgvAllTasks.Columns[1].HeaderText = "Title";
            dgvAllTasks.Columns[1].Width = 303;

            dgvAllTasks.Columns[2].HeaderText = "Status";
            dgvAllTasks.Columns[2].Width = 100;
        }

        private void ctrlAddTask1_TaskSaved(object sender, EventArgs e)
        {
            Form1_Load(null, null);
        }

        private void showTaskDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ctrlAddTask1.Visible = false;
            ctrlShowTaskDetails1.Visible = true;
            ctrlShowTaskDetails1.LoadInfo((int)dgvAllTasks.CurrentRow.Cells[0].Value);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ctrlAddTask1.Visible = true;
            ctrlShowTaskDetails1.Visible = false;
            ctrlAddTask1.LoadInfo((int)dgvAllTasks.CurrentRow.Cells[0].Value);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Task", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            bool IsDeleted = clsTask.DeleteTask((int)dgvAllTasks.CurrentRow.Cells[0].Value);
            if (IsDeleted)
            {
                MessageBox.Show("Task Deleted Successfully", "Task Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctrlAddTask1.RefreshControl();
                Form1_Load(null, null);
            }
            else
            {
                MessageBox.Show("Task was not Deleted Successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            ctrlAddTask1.Visible = true;
            ctrlShowTaskDetails1.Visible = false;
            ctrlAddTask1.RefreshControl();
        }

        private void completedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to set this task as completed", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            bool IsUpdated = clsTask.UpdateStatus((int)dgvAllTasks.CurrentRow.Cells[0].Value, (int)clsTask.enStatus.Completed);
            if (IsUpdated)
            {
                MessageBox.Show("Task Completed successfully", "Task Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctrlShowTaskDetails1.Refresh();
                Form1_Load(null, null);
            }
            else
            {
                MessageBox.Show("Error : Staus was not updated successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cancelledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Cancel this Task", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            bool IsUpdated = clsTask.UpdateStatus((int)dgvAllTasks.CurrentRow.Cells[0].Value, (int)clsTask.enStatus.Cancelled);
            if (IsUpdated)
            {
                MessageBox.Show("Task Cancelled successfully", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctrlShowTaskDetails1.Refresh();
                Form1_Load(null, null);
            }
            else
            {
                MessageBox.Show("Error : Task was not Cancelled successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
