# Cyber_Bot – Cybersecurity Awareness Chatbot

## 📌 Project Overview
Cyber_Bot is a WPF-based cybersecurity chatbot designed to educate users about online safety while providing interactive features such as task management, quizzes, and activity tracking.

---

## 🚀 Features

### 💬 Chatbot (NLP Simulation)
- Detects keywords using simple string matching
- Responds to cybersecurity topics like:
  - Password safety
  - Phishing
  - Privacy
  - Scams
- Learns basic user memory (name, preferences)

---

### 📌 Task Manager (MySQL Database)
- Add cybersecurity tasks
- Store tasks in MySQL database
- View all tasks
- Mark tasks as completed
- Delete tasks
- Includes optional reminders

---

### 🎮 Cybersecurity Quiz
- 10+ cybersecurity questions
- Multiple choice + True/False
- Real-time feedback
- Score tracking
- Final performance message

---

### 📜 Activity Log
- Tracks all system actions
- Logs:
  - Tasks added/removed/completed
  - Quiz activity
  - NLP detections
- Displays last 10 actions

---

## 🧠 Technologies Used
- C#
- WPF (Windows Presentation Foundation)
- MySQL Database
- ADO.NET (MySQL Connector)
- Basic NLP simulation (keyword detection)

---

## 🗄️ Database Setup
Run the following SQL script:

```sql
CREATE DATABASE cyber_bot;

USE cyber_bot;

CREATE TABLE tasks (
    id INT AUTO_INCREMENT PRIMARY KEY,
    title VARCHAR(255),
    description TEXT,
    reminder VARCHAR(100),
    status VARCHAR(50) DEFAULT 'Pending'
);
