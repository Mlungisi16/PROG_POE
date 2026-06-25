using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;

namespace Cyber_Bot
{
    public partial class MainWindow : Window
    {
        Database db = new Database();

        List<string> activityLog = new List<string>();

        int quizIndex = 0;
        int score = 0;

        List<string> quizQ = new List<string>()
        {
            "Phishing is: a) scam b) game c) app",
            "2FA means: a) authentication b) app c) file",
            "Passwords should be: a) strong b) short c) same",
            "Public WiFi is: true or false (safe?)",
            "Scammers lie online: true or false",
            "Clicking unknown links is safe: true or false",
            "VPN improves privacy: true or false",
            "Sharing passwords is safe: true or false",
            "Antivirus protects malware: true or false",
            "Cybersecurity is important: true or false"
        };

        List<string> quizA = new List<string>()
        {
            "a","a","a","false","true","false","true","false","true","true"
        };

        public MainWindow()
        {
            InitializeComponent();

            AddMessage("BOT", "Cyber Bot Online");
            Log("Bot started");
        }

        // ================= SEND =================
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string input = inputBox.Text.ToLower();

            if (input == "")
                return;

            AddMessage("YOU", input);

            string response = Handle(input);

            AddMessage("BOT", response);

            inputBox.Clear();
        }

        // ================= LOGIC =================
        private string Handle(string input)
        {
            // ADD TASK
            if (input.Contains("add task"))
            {
                db.AddTask("Cyber Task", input, "7 days");
                Log("Task added");
                return "Task added to database.";
            }

            // VIEW TASKS
            if (input.Contains("show tasks"))
            {
                Log("Viewed tasks");

                List<string> tasks = db.GetTasks();

                if (tasks.Count == 0)
                    return "No tasks found.";

                return string.Join("\n", tasks);
            }

            // DELETE TASK
            if (input.Contains("delete task"))
            {
                string id = GetNumber(input);
                db.DeleteTask(id);

                Log("Deleted task " + id);
                return "Task deleted.";
            }

            // COMPLETE TASK
            if (input.Contains("complete task"))
            {
                string id = GetNumber(input);
                db.CompleteTask(id);

                Log("Completed task " + id);
                return "Task completed.";
            }

            // QUIZ START
            if (input.Contains("quiz"))
            {
                quizIndex = 0;
                score = 0;

                Log("Quiz started");
                return quizQ[quizIndex];
            }

            // QUIZ ANSWER
            if (quizIndex < quizQ.Count)
            {
                if (input == "a" || input == "b" || input == "true" || input == "false")
                {
                    if (input == quizA[quizIndex])
                    {
                        score++;
                    }

                    quizIndex++;

                    if (quizIndex < quizQ.Count)
                        return quizQ[quizIndex];

                    Log("Quiz finished score " + score);
                    return "Quiz done! Score: " + score + "/10";
                }
            }

            // NLP SIMPLE
            if (input.Contains("password"))
                return "Use strong passwords.";

            if (input.Contains("phishing"))
                return "Be careful of fake emails.";

            if (input.Contains("privacy"))
                return "Enable 2FA.";

            // ACTIVITY LOG
            if (input.Contains("log"))
            {
                return string.Join("\n", activityLog);
            }

            return "Try: add task, show tasks, quiz";
        }

        // ================= HELPERS =================
        private string GetNumber(string text)
        {
            foreach (char c in text)
            {
                if (char.IsDigit(c))
                    return c.ToString();
            }
            return "0";
        }

        private void AddMessage(string sender, string msg)
        {
            chatBox.Document.Blocks.Add(
                new Paragraph(new Run(sender + ": " + msg))
            );
        }

        private void Log(string action)
        {
            activityLog.Add(DateTime.Now.ToString("T") + " - " + action);
        }
    }
}