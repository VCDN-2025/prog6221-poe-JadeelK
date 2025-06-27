// Code Attribution
// OpenAI. 2025. ChatGPT (Version 4). [Large language model]. Available at: https://chatgpt.com/share/685ed5ea-0790-8012-b319-af5a1e31e1aa [Accessed: 23 June 2025]

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CyberBotGUI
{
    public class TaskManager : Form
    {
        private ListView taskListView;
        private static List<TaskItem> taskList = new List<TaskItem>();

        public TaskManager()
        {
            this.Text = "Task Assistant";
            this.Width = 500;
            this.Height = 400;

            taskListView = new ListView
            {
                Dock = DockStyle.Top,
                Height = 250,
                View = View.Details,
                FullRowSelect = true
            };
            taskListView.Columns.Add("Title", 150);
            taskListView.Columns.Add("Description", 200);
            taskListView.Columns.Add("Reminder", 100);

            Button btnAdd = new Button { Text = "Add Task", Dock = DockStyle.Top };
            btnAdd.Click += BtnAdd_Click;

            Button btnDelete = new Button { Text = "Delete Selected", Dock = DockStyle.Top };
            btnDelete.Click += BtnDelete_Click;

            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(taskListView);

            LoadTasks();
        }

        private void LoadTasks()
        {
            taskListView.Items.Clear();
            foreach (var task in taskList)
            {
                var item = new ListViewItem(task.Title);
                item.SubItems.Add(task.Description);
                item.SubItems.Add(task.ReminderDate.HasValue ? task.ReminderDate.Value.ToShortDateString() : "None");
                taskListView.Items.Add(item);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddTaskForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                taskList.Add(addForm.NewTask);
                ActivityLogger.Log($"Task added: '{addForm.NewTask.Title}'" +
                    (addForm.NewTask.ReminderDate.HasValue ? $" (Reminder set for {addForm.NewTask.ReminderDate.Value.ToShortDateString()})" : ""));
                LoadTasks();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (taskListView.SelectedIndices.Count > 0)
            {
                taskList.RemoveAt(taskListView.SelectedIndices[0]);
                ActivityLogger.Log("Task deleted.");
                LoadTasks();
            }
        }

        public class TaskItem
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime? ReminderDate { get; set; }
        }

        public class AddTaskForm : Form
        {
            public TaskItem NewTask { get; private set; }

            public AddTaskForm()
            {
                this.Text = "Add New Task";
                this.Width = 400;
                this.Height = 250;

                var titleBox = new TextBox { Text = "Task Title", Top = 10, Left = 20, Width = 340, ForeColor = System.Drawing.Color.Gray };
                var descBox = new TextBox { Text = "Task Description", Top = 50, Left = 20, Width = 340, ForeColor = System.Drawing.Color.Gray };

                titleBox.GotFocus += (s, e) =>
                {
                    if (titleBox.Text == "Task Title")
                    {
                        titleBox.Text = "";
                        titleBox.ForeColor = System.Drawing.Color.Black;
                    }
                };
                titleBox.LostFocus += (s, e) =>
                {
                    if (string.IsNullOrWhiteSpace(titleBox.Text))
                    {
                        titleBox.Text = "Task Title";
                        titleBox.ForeColor = System.Drawing.Color.Gray;
                    }
                };

                descBox.GotFocus += (s, e) =>
                {
                    if (descBox.Text == "Task Description")
                    {
                        descBox.Text = "";
                        descBox.ForeColor = System.Drawing.Color.Black;
                    }
                };
                descBox.LostFocus += (s, e) =>
                {
                    if (string.IsNullOrWhiteSpace(descBox.Text))
                    {
                        descBox.Text = "Task Description";
                        descBox.ForeColor = System.Drawing.Color.Gray;
                    }
                };

                var reminderPicker = new DateTimePicker { Format = DateTimePickerFormat.Short, Top = 90, Left = 20, Width = 150 };
                var reminderCheck = new CheckBox { Text = "Set Reminder", Top = 90, Left = 180 };

                var btnOK = new Button { Text = "Add", Top = 130, Left = 20 };
                btnOK.Click += (s, e) =>
                {
                    NewTask = new TaskItem
                    {
                        Title = titleBox.Text,
                        Description = descBox.Text,
                        ReminderDate = reminderCheck.Checked ? reminderPicker.Value : (DateTime?)null
                    };
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                };

                this.Controls.AddRange(new Control[] { titleBox, descBox, reminderPicker, reminderCheck, btnOK });
            }
        }
    }
}