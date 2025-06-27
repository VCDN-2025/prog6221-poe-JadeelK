// Code Attribution
// OpenAI. 2025. ChatGPT (Version 4). [Large language model]. Available at: https://chatgpt.com/share/685ed585-ed90-8012-a6d1-93756c661af9 [Accessed: 22 June 2025]

using System;
using System.Windows.Forms;

namespace CyberBotGUI
{
    public partial class MainForm : Form
    {
        private ChatBotEngine botEngine;

        public MainForm()
        {
            InitializeComponent();
            botEngine = new ChatBotEngine(UpdateChat, Program.synthesizer);
        }

        private void InitializeComponent()
        {
            this.Text = "CyberBot 2.0";
            this.Width = 800;
            this.Height = 600;

            Label lblTitle = new Label
            {
                Text = "CyberBot 2.0",
                Font = new System.Drawing.Font("Consolas", 18F),
                Dock = DockStyle.Top,
                Height = 40,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };

            txtOutput = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Dock = DockStyle.Top,
                Height = 300
            };

            txtInput = new TextBox
            {
                Dock = DockStyle.Top,
                Text = "Type your message here...",
                ForeColor = System.Drawing.Color.Gray
            };

            txtInput.GotFocus += (s, e) =>
            {
                if (txtInput.Text == "Type your message here...")
                {
                    txtInput.Text = "";
                    txtInput.ForeColor = System.Drawing.Color.Black;
                }
            };

            txtInput.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtInput.Text))
                {
                    txtInput.Text = "Type your message here...";
                    txtInput.ForeColor = System.Drawing.Color.Gray;
                }
            };

            Button btnSend = new Button
            {
                Text = "Send",
                Dock = DockStyle.Top
            };
            btnSend.Click += BtnSend_Click;

            FlowLayoutPanel panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                Height = 100
            };

            Button btnTasks = new Button { Text = "Tasks", Width = 100 };
            Button btnQuiz = new Button { Text = "Quiz", Width = 100 };
            Button btnLog = new Button { Text = "Activity Log", Width = 120 };

            btnTasks.Click += (s, e) => new TaskManager().ShowDialog();
            btnQuiz.Click += (s, e) => new QuizEngine().ShowDialog();
            btnLog.Click += (s, e) => new ActivityLogger().ShowDialog();

            panel.Controls.AddRange(new Control[] { btnTasks, btnQuiz, btnLog });

            this.Controls.Add(panel);
            this.Controls.Add(btnSend);
            this.Controls.Add(txtInput);
            this.Controls.Add(txtOutput);
            this.Controls.Add(lblTitle);
        }

        private TextBox txtInput;
        private TextBox txtOutput;

        private void BtnSend_Click(object sender, EventArgs e)
        {
            string userInput = txtInput.Text.Trim();
            if (!string.IsNullOrWhiteSpace(userInput) && userInput != "Type your message here...")
            {
                UpdateChat("You: " + userInput);
                botEngine.ProcessInput(userInput);
                txtInput.Clear();
            }
        }

        private void UpdateChat(string message)
        {
            txtOutput.AppendText(message + Environment.NewLine);
        }
    }
}
