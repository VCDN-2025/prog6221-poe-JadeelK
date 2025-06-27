CyberBot 2.0 – Cybersecurity Awareness Chatbot

CyberBot 2.0 is an interactive C# chatbot application built with Windows Forms. It helps users learn about cybersecurity through smart conversation, reminders, tasks, quizzes, and interactive features. The app includes voice responses, natural language processing simulation, and a full graphical user interface.


🛠 Setup Instructions

Requirements:
- Visual Studio 2022 or later
- .NET Framework 4.7.2 or higher
- Windows OS (required for System.Speech)

📁 How to Set Up:
1. Clone or download this repository.
2. Open the file in Visual Studio.
3. Restore any missing NuGet packages.
4. Set Program.cs as the startup file.
5. Press F5 to run the app.


💡 Features

🎨 GUI Components
- Chat Window with text input and speech output
- Buttons for:
  - Tasks: Add/view/manage cybersecurity tasks with optional reminders
  - Quiz: A 10-question cybersecurity mini-game
  - Activity Log: View recent user actions (tasks, reminders, quiz attempts)

🗣 Voice Interaction
- Uses System.Speech.Synthesis to speak responses aloud

🧠 NLP Simulation
- Basic keyword detection and simulated natural language understanding
- Can interpret sentences like:
  - "Can you remind me to update my password?"
  - "Add a task to enable 2FA"

📅 Task Assistant
- Add task titles, descriptions, and reminders
- View and delete tasks
- Track reminders in log

🧪 Cybersecurity Quiz
- Multiple-choice + true/false questions
- Score tracking and feedback

📜 Activity Log
- Keeps track of actions like:
  - Tasks added/deleted
  - Quiz results
  - NLP-recognized commands


🚀 Usage Examples

✅ Example 1: Add a Task

User: Add task to update antivirus
ChatBot: Task added! Would you like a reminder?

✅ Example 2: Set a Reminder via NLP
User: Can you remind me to check my privacy settings?
ChatBot: Reminder noted: ‘check my privacy settings’

✅ Example 3: Start the Quiz

Click on the “Quiz” button to launch the game.
Answer questions and receive instant feedback + final score.



🧾 Attribution

Some parts of this application (e.g. NLP handling, reminder system, quiz logic, GUI layout) were developed with research support and assistance from OpenAI ChatGPT.

See /docs/CyberBot_Code_Attributions.docx for full references.


📄 License

This project is for educational purposes and is not licensed for commercial use.



🙋‍♂ Author

Jadeel Kisten
Built for the PROG6221 module  
IIE Varsity College, Durban North
