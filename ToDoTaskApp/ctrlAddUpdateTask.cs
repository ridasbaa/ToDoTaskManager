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
using ToDoTaskModels;

namespace ToDoTaskApp
{
    public partial class ctrlAddTask : UserControl
    {

        public enum enMode {AddNew = 1, Update = 2};
        public enMode Mode = enMode.AddNew;

        public event EventHandler TaskSaved;
        private clsTask _task;

        public bool labelIDVisible { set { labelID.Visible = value; } }
        public bool lblTaskIDVisible { set { lblTaskID.Visible = value; } }

        public ctrlAddTask()
        {
            InitializeComponent();
            dtpDeadLine.MinDate = DateTime.Today;
            dtpDeadLine.Value = DateTime.Today;
        }

        private void _ResetDefaultValues()
        {

            gbAddTask.Text = "Add Task";
            txtTitle.Text = string.Empty;
            txtDescription.Text = string.Empty;

            dtpDeadLine.MinDate = DateTime.Today;
            dtpDeadLine.Value = DateTime.Today;

            cbPriority.SelectedIndex = -1;
            lblTaskID.Visible = false;
            labelID.Visible = false;
        }

        public void LoadInfo(int TaskID)
        {
            _ResetDefaultValues();
            _task = clsTask.Find(TaskID);
            if (_task == null)
            {
                MessageBox.Show($"No Task with ID {TaskID} was Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Mode = enMode.Update;
            _LoadData();
        }

        private void _LoadData()
        {
            lblTaskID.Visible = true;
            labelID.Visible = true;
            lblTaskID.Text = _task.ID.ToString();
            txtTitle.Text = _task.Title;
            txtDescription.Text = _task.Description;
            dtpDeadLine.Value = _task.DeadLine < DateTime.Today ? DateTime.Today : _task.DeadLine;
            cbPriority.SelectedIndex = (int)_task.Priority == 4 ? -1 : (int)_task.Priority;
            gbAddTask.Text = "Edit Task";
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "This field cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtTitle, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid, put the mouse on the red icon to see the error", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (Mode == enMode.AddNew)
            {

                ToDoTaskBusinessLayer.clsTask Task = new ToDoTaskBusinessLayer.clsTask(new TaskDTO(0, txtTitle.Text, txtDescription.Text, dtpDeadLine.Value,
                cbPriority.Text == "" ? (TaskDTO.enPriority)3 : (TaskDTO.enPriority)cbPriority.SelectedIndex, TaskDTO.enStatus.Pending, DateTime.Now));

                if (Task.Save())
                {
                    lblTaskID.Text = Task.ID.ToString();
                    MessageBox.Show("Task Added Successfully", "Task Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _ResetDefaultValues();
                    TaskSaved?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Error : Task was not Added Successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (Mode == enMode.Update)
            {
                _task.Title = txtTitle.Text;
                _task.Description = txtDescription.Text;
                _task.DeadLine = dtpDeadLine.Value;
                _task.Priority = cbPriority.Text == "" ? (clsTask.enPriority)3 : (clsTask.enPriority)cbPriority.SelectedIndex;

                if (_task.Save())
                {
                    lblTaskID.Text = _task.ID.ToString();
                    MessageBox.Show("Task Added Successfully", "Task Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _ResetDefaultValues();
                    TaskSaved?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Error : Task was not Added Successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void RefreshControl()
        {
            _ResetDefaultValues();
        }

    }





}
