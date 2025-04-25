namespace ToDoTaskApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dgvAllTasks = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showTaskDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.completedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.ctrlShowTaskDetails1 = new ToDoTaskApp.ctrlShowTaskDetails();
            this.ctrlAddTask1 = new ToDoTaskApp.ctrlAddTask();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllTasks)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAllTasks
            // 
            this.dgvAllTasks.BackgroundColor = System.Drawing.Color.White;
            this.dgvAllTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllTasks.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvAllTasks.Location = new System.Drawing.Point(401, 69);
            this.dgvAllTasks.Name = "dgvAllTasks";
            this.dgvAllTasks.Size = new System.Drawing.Size(546, 403);
            this.dgvAllTasks.TabIndex = 10;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showTaskDetailsToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.setToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(212, 156);
            // 
            // showTaskDetailsToolStripMenuItem
            // 
            this.showTaskDetailsToolStripMenuItem.Image = global::ToDoTaskApp.Properties.Resources.project_plan;
            this.showTaskDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showTaskDetailsToolStripMenuItem.Name = "showTaskDetailsToolStripMenuItem";
            this.showTaskDetailsToolStripMenuItem.Size = new System.Drawing.Size(211, 38);
            this.showTaskDetailsToolStripMenuItem.Text = "Show Task Details";
            this.showTaskDetailsToolStripMenuItem.Click += new System.EventHandler(this.showTaskDetailsToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripMenuItem.Image")));
            this.editToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(211, 38);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem.Image")));
            this.deleteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(211, 38);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // setToolStripMenuItem
            // 
            this.setToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.completedToolStripMenuItem,
            this.cancelledToolStripMenuItem});
            this.setToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("setToolStripMenuItem.Image")));
            this.setToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.setToolStripMenuItem.Name = "setToolStripMenuItem";
            this.setToolStripMenuItem.Size = new System.Drawing.Size(211, 38);
            this.setToolStripMenuItem.Text = "Set Status";
            // 
            // completedToolStripMenuItem
            // 
            this.completedToolStripMenuItem.Image = global::ToDoTaskApp.Properties.Resources.checklist;
            this.completedToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.completedToolStripMenuItem.Name = "completedToolStripMenuItem";
            this.completedToolStripMenuItem.Size = new System.Drawing.Size(196, 38);
            this.completedToolStripMenuItem.Text = "Completed";
            this.completedToolStripMenuItem.Click += new System.EventHandler(this.completedToolStripMenuItem_Click);
            // 
            // cancelledToolStripMenuItem
            // 
            this.cancelledToolStripMenuItem.Image = global::ToDoTaskApp.Properties.Resources.clipboard__1_;
            this.cancelledToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cancelledToolStripMenuItem.Name = "cancelledToolStripMenuItem";
            this.cancelledToolStripMenuItem.Size = new System.Drawing.Size(196, 38);
            this.cancelledToolStripMenuItem.Text = "Cancelled";
            this.cancelledToolStripMenuItem.Click += new System.EventHandler(this.cancelledToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(401, 483);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Records:";
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.Location = new System.Drawing.Point(488, 484);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(29, 20);
            this.lblRecords.TabIndex = 14;
            this.lblRecords.Text = "##";
            // 
            // btnAddTask
            // 
            this.btnAddTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTask.Image = global::ToDoTaskApp.Properties.Resources.task;
            this.btnAddTask.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddTask.Location = new System.Drawing.Point(816, 12);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(130, 51);
            this.btnAddTask.TabIndex = 16;
            this.btnAddTask.Text = "Add Task";
            this.btnAddTask.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // ctrlShowTaskDetails1
            // 
            this.ctrlShowTaskDetails1.BackColor = System.Drawing.Color.White;
            this.ctrlShowTaskDetails1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ctrlShowTaskDetails1.Location = new System.Drawing.Point(13, 8);
            this.ctrlShowTaskDetails1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlShowTaskDetails1.Name = "ctrlShowTaskDetails1";
            this.ctrlShowTaskDetails1.Size = new System.Drawing.Size(381, 491);
            this.ctrlShowTaskDetails1.TabIndex = 15;
            // 
            // ctrlAddTask1
            // 
            this.ctrlAddTask1.BackColor = System.Drawing.Color.White;
            this.ctrlAddTask1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ctrlAddTask1.Location = new System.Drawing.Point(13, 12);
            this.ctrlAddTask1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlAddTask1.Name = "ctrlAddTask1";
            this.ctrlAddTask1.Size = new System.Drawing.Size(381, 491);
            this.ctrlAddTask1.TabIndex = 12;
            this.ctrlAddTask1.TaskSaved += new System.EventHandler(this.ctrlAddTask1_TaskSaved);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(958, 513);
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlAddTask1);
            this.Controls.Add(this.dgvAllTasks);
            this.Controls.Add(this.ctrlShowTaskDetails1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "To-Do Task";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllTasks)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvAllTasks;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setToolStripMenuItem;
        private ctrlAddTask ctrlAddTask1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.ToolStripMenuItem showTaskDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem completedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelledToolStripMenuItem;
        private ctrlShowTaskDetails ctrlShowTaskDetails1;
        private System.Windows.Forms.Button btnAddTask;
    }
}

