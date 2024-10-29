# 📝 FeedbackScan

**This project contains a sample ASP.NET Core app. This app is an example of the article I produced for the Telerik Blog (telerik.com/blogs)**


This application analyzes customer feedback, identifying sentiment and core reasons for responses. Built with **ASP.NET Core**, it leverages **SQL Server** as the database and **OpenAI's GPT-4o mini model** for language analysis. 

## 🌟 Features

- 🔍 **Sentiment Analysis**: Automatically analyzes feedback to determine sentiment (positive, neutral, or negative).
- 🧠 **GPT-4o mini Model**: Powered by OpenAI to process and understand nuanced feedback.
- 📊 **Database Storage**: Uses SQL Server to store and organize feedback data securely.

## 🚀 Getting Started

### Prerequisites

- .NET SDK version 8.0 or later)
- SQL Server (Local server)
- OpenAI API Key (for GPT-4o mini access)

### 📥 Installation

1. **Clone this repository**:

   ```bash
   git clone https://github.com/zangassis/feedback-scan.git
   cd FeedbackScan
   ```

2. **Set up SQL Server**: Ensure you have an instance of SQL Server running and ready to connect.

3. **Run Database Migrations**:

   ```bash
   dotnet ef database update
   ```

4. **Run the Application**:

   ```bash
   dotnet run
   ```

## 🛠️ Project Structure

- **/Models** - Defines data models, including feedback structure.
- **/Data** - SQL Server database configuration and migrations.
- **/Endpoints** - API endpoints.

## 🤖 Technologies Used

- **ASP.NET Core** 🌐
- **SQL Server** 🗄️
- **OpenAI API** 🧠
- **Entity Framework Core** 📄

## ⚠️ Important Notes

- This application assumes your OpenAI API Key and SQL Server instance are secure. Avoid exposing sensitive information in your code.

## 📜 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
