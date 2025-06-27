// Code Attribution
// OpenAI. 2025. ChatGPT (Version 4). [Large language model]. Available at: https://chatgpt.com/share/685ed5bc-cb40-8012-9e61-7289a398ed8f [Accessed: 22 June 2025]

using System;
using System.Collections.Generic;
using System.Speech.Synthesis;

namespace CyberBotGUI
{
    public class ChatBotEngine
    {
        private Action<string> output;
        private SpeechSynthesizer synthesizer;
        private string userInterest = "";
        private static Random rand = new Random();

        private List<string> phishingTips = new List<string>
        {
            "Check the sender's email address carefully—scammers mimic real companies.",
            "Avoid clicking links in unsolicited emails—navigate directly to the website.",
            "Always verify strange messages from 'banks' or 'support'.",
            "Phishing emails often create urgency—pause before you act."
        };

        public ChatBotEngine(Action<string> outputMethod, SpeechSynthesizer speaker)
        {
            output = outputMethod;
            synthesizer = speaker;
        }

        public void ProcessInput(string input)
        {
            string lower = input.ToLower();

            if (lower.Contains("interested in"))
            {
                userInterest = input.Substring(lower.IndexOf("interested in") + 13).Trim();
                Respond($"Great! I'll remember that you're interested in {userInterest}.");
                return;
            }

            if (lower.Contains("remind me") && !string.IsNullOrEmpty(userInterest))
            {
                Respond($"Since you're interested in {userInterest}, remember to keep privacy settings updated.");
                return;
            }

            if (DetectSentiment(lower)) return;
            if (HandleKeywords(lower)) return;

            Respond("I’m not sure I understand. Want to rephrase or ask something else?");
        }

        private bool DetectSentiment(string input)
        {
            if (input.Contains("worried") || input.Contains("scared"))
            {
                Respond("It's okay to feel that way. Let’s focus on how you can protect yourself online.");
                return true;
            }

            if (input.Contains("confused") || input.Contains("frustrated"))
            {
                Respond("Cybersecurity can be tricky. I’ll do my best to guide you step-by-step.");
                return true;
            }

            return false;
        }

        private bool HandleKeywords(string input)
        {
            if (input.Contains("password"))
            {
                Respond("Strong passwords matter. Use 12+ characters with symbols and avoid dictionary words.");
                return true;
            }

            if (input.Contains("privacy"))
            {
                Respond("Limit data sharing. Review app permissions and enable 2FA where possible.");
                return true;
            }

            if (input.Contains("phishing"))
            {
                Respond(phishingTips[rand.Next(phishingTips.Count)]);
                return true;
            }

            if (input.Contains("what have you done") || input.Contains("activity log"))
            {
                Respond("Use the Activity Log button to see your latest actions.");
                return true;
            }

            return false;
        }

        private void Respond(string message)
        {
            output($"CyberBot: {message}");
            synthesizer.SpeakAsync(message);
        }
    }
}