// Code Attribution
// OpenAI. 2025. ChatGPT (Version 4). [Large language model]. Available at: https://chatgpt.com/share/685ed565-7dc8-8012-8155-8034c6d0241c [Accessed: 22 June 2025]

using System;
using System.Windows.Forms;
using System.Speech.Synthesis;
using CyberbotGUI;

namespace CyberBotGUI
{
    static class Program
    {
        public static SpeechSynthesizer synthesizer = new SpeechSynthesizer();

        [STAThread]
        static void Main()
        {
            Console.WriteLine(@"
 _____ ___ ___ _____  _____  _____  _____  _____  ____   _____     _____ 
/     \\  |  //  _  \/   __\/  _  \/  _  \/  _  \/    \ <___  \   /  _  \
|  |--| |   | |  _  <|   __||  _  <|  _  <|  |  |\-  -/  /  __/ _ |  |  |
\_____/ \___/ \_____/\_____/\__|\_/\_____/\_____/ |__|  <_____|<_>\_____/

                      [  CYBERBOT 2.0 ACTIVATED  ]

");
            synthesizer.SpeakAsync("Welcome to Cyberbot 2.0, your cybersecurity assistant.");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}