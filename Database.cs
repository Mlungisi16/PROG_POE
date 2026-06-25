using Devart.Data.MySql;
using System.Collections.Generic;

namespace Cyber_Bot
{
    public class Database
    {
        string conn =
            "Server=localhost;Database=cyber_bot;User Id=root;Password=YOUR_PASSWORD;";

        public MySqlConnection Get()
        {
            return new MySqlConnection(conn);
        }

        public void AddTask(string title, string desc, string reminder)
        {
            using var c = Get();
            c.Open();

            var cmd = new MySqlCommand(
                "INSERT INTO tasks(title,description,reminder,status) VALUES(@t,@d,@r,'Pending')", c);

            cmd.Parameters.AddWithValue("@t", title);
            cmd.Parameters.AddWithValue("@d", desc);
            cmd.Parameters.AddWithValue("@r", reminder);

            cmd.ExecuteNonQuery();
        }

        public List<string> GetTasks()
        {
            List<string> list = new();

            using var c = Get();
            c.Open();

            var cmd = new MySqlCommand("SELECT * FROM tasks", c);
            var r = cmd.ExecuteReader();

            while (r.Read())
            {
                list.Add($"{r["id"]} | {r["title"]} | {r["description"]} | {r["status"]}");
            }

            return list;
        }

        public void DeleteTask(string id)
        {
            using var c = Get();
            c.Open();

            var cmd = new MySqlCommand("DELETE FROM tasks WHERE id=@id", c);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }

        public void CompleteTask(string id)
        {
            using var c = Get();
            c.Open();

            var cmd = new MySqlCommand("UPDATE tasks SET status='Completed' WHERE id=@id", c);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }
    }
}