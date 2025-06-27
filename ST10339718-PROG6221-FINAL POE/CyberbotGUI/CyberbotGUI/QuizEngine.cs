// Code Attribution
// OpenAI. 2025. ChatGPT (Version 4). [Large language model]. Available at: https://chatgpt.com/share/685ed621-a7c8-8012-84da-a3a6df1acc6c [Accessed: 24 June 2025]

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CyberbotGUI;

namespace CyberBotGUI
{
    public class QuizEngine : Form
    {
        private List<Question> questions = new List<Question>();
        private int currentQuestion = 0;
        private int score = 0;

        private Label lblQuestion;
        private RadioButton[] options = new RadioButton[4];
        private Button btnNext;

        public QuizEngine()
        {
            this.Text = "Cybersecurity Quiz";
            this.Width = 600;
            this.Height = 350;

            lblQuestion = new Label { Top = 20, Left = 20, Width = 550, Height = 40 };
            for (int i = 0; i < 4; i++)
            {
                options[i] = new RadioButton { Top = 70 + i * 30, Left = 20, Width = 550 };
                this.Controls.Add(options[i]);
            }

            btnNext = new Button { Text = "Next", Top = 220, Left = 20 };
            btnNext.Click += BtnNext_Click;

            this.Controls.Add(lblQuestion);
            this.Controls.Add(btnNext);

            LoadQuestions();
            DisplayQuestion();
        }

        private void LoadQuestions()
        {
            questions.Add(new Question("What is phishing?", new[] {
                "A method to catch real fish",
                "Sending fake emails to steal information",
                "A password manager",
                "None of the above"
            }, 1));

            questions.Add(new Question("True or False: You should use the same password everywhere.", new[] {
                "True", "False", "", ""
            }, 1));

            questions.Add(new Question("What does 2FA stand for?", new[] {
                "Two-Factor Authentication",
                "Two-Factor Approval",
                "Fast Access",
                "None"
            }, 0));

            questions.Add(new Question("Which one is a strong password?", new[] {
                "123456", "password", "Z!p8m@2025!", "myname"
            }, 2));

            questions.Add(new Question("True or False: Public Wi-Fi is always safe to use.", new[] {
                "True", "False", "", ""
            }, 1));

            questions.Add(new Question("Which is a good practice?", new[] {
                "Click links from unknown sources",
                "Ignore software updates",
                "Use antivirus software",
                "Share your password"
            }, 2));

            questions.Add(new Question("What is social engineering?", new[] {
                "Engineering for social media",
                "Tricking people into giving info",
                "Building websites",
                "None"
            }, 1));

            questions.Add(new Question("True or False: Your birthdate makes a secure password.", new[] {
                "True", "False", "", ""
            }, 1));

            questions.Add(new Question("What should you do with suspicious emails?", new[] {
                "Reply to them",
                "Click all links",
                "Report them as phishing",
                "Delete your inbox"
            }, 2));

            questions.Add(new Question("Which is a benefit of using a password manager?", new[] {
                "You only need one strong password",
                "It tracks people online",
                "It makes passwords public",
                "None"
            }, 0));
        }

        private void DisplayQuestion()
        {
            if (currentQuestion < questions.Count)
            {
                lblQuestion.Text = $"Q{currentQuestion + 1}: {questions[currentQuestion].Text}";
                for (int i = 0; i < 4; i++)
                {
                    options[i].Text = questions[currentQuestion].Options[i];
                    options[i].Visible = !string.IsNullOrWhiteSpace(options[i].Text);
                    options[i].Checked = false;
                }
            }
            else
            {
                MessageBox.Show($"Quiz completed!\nYou scored {score}/{questions.Count}.\n" +
                    (score >= 7 ? "Great job! You're a cybersecurity pro!" : "Keep practicing! You're on the right path."),
                    "Quiz Result");

                ActivityLogger.Log($"Quiz completed. Score: {score}/{questions.Count}");
                this.Close();
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            var q = questions[currentQuestion];
            for (int i = 0; i < 4; i++)
            {
                if (options[i].Checked && i == q.CorrectIndex)
                {
                    score++;
                    MessageBox.Show("Correct! ✔", "Answer Feedback");
                    break;
                }
                else if (options[i].Checked)
                {
                    MessageBox.Show($"Incorrect ❌\nCorrect answer: {q.Options[q.CorrectIndex]}", "Answer Feedback");
                    break;
                }
            }

            currentQuestion++;
            DisplayQuestion();
        }

        private class Question
        {
            public string Text;
            public string[] Options;
            public int CorrectIndex;

            public Question(string text, string[] options, int correct)
            {
                Text = text;
                Options = options;
                CorrectIndex = correct;
            }
        }
    }
}
