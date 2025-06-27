// Code Attribution
// OpenAI. 2025. ChatGPT (Version 4). [Large language model]. Available at: https://chatgpt.com/share/685ed63f-bbe0-8012-bd3b-c4c56bd077ea [Accessed: 24 June 2025]

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CyberBotGUI
{
    public class ActivityLogger : Form
    {
        private static Queue<string> activityLog = new Queue<string>();
        private ListBox logListBox;

        public ActivityLogger()
        {
            this.Text = "Activity Log";
            this.Width = 400;
            this.Height = 300;

            logListBox = new ListBox
            {
                Dock = DockStyle.Fill
            };

            foreach (var item in activityLog)
            {
                logListBox.Items.Add(item);
            }

            this.Controls.Add(logListBox);
        }

        public static void Log(string action)
        {
            string timestampedAction = $"[{DateTime.Now:HH:mm:ss}] {action}";

            if (activityLog.Count >= 10)
                activityLog.Dequeue();

            activityLog.Enqueue(timestampedAction);
        }
    }
}
