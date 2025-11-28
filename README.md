# Distributed Ad Platform

This project is a .NET-based distributed system designed to manage advertisements and subscribers. It showcases the interaction between multiple services, including a web application, a web API, and a desktop client.

## ✨ Features

*   **Ad Management**: Create and view advertisements.
*   **Subscriber Management**: Add, update, and remove subscribers through a dedicated API and a desktop UI.
*   **System-to-System Communication**: The AdSystem communicates with the SubscriberSystem to keep data synchronized.
*   **Distributed Architecture**: Demonstrates a decoupled architecture with separate services for different business domains.

## 🚀 Getting Started

### Prerequisites

*   [.NET SDK](https://dotnet.microsoft.com/download)
*   [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or SQL Server Express)

### Installation & Setup

1.  **Clone the repository:**
    ```bash
    git clone https://github.com/your-username/distributed-ad-platform.git
    cd distributed-ad-platform
    ```

2.  **Database Configuration:**
    *   The `AdSystem` and `SubscriberSystem` projects each have their own database.
    *   Update the connection strings in `AdSystem/appsettings.json` and `SubscriberSystem/appsettings.json` to point to your local SQL Server instance.

    Example `appsettings.json`:
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=your_server_name;Database=AdsDb;Trusted_Connection=True;MultipleActiveResultSets=true"
      }
    }
    ```

3.  **Apply Entity Framework Migrations:**
    *   Open a terminal for each project (`AdSystem` and `SubscriberSystem`) and run the following command to create the database schemas:
    ```bash
    dotnet ef database update
    ```

### Running the Applications

1.  **Start the Subscriber API:**
    *   Navigate to the `SubscriberSystem` directory and run the application.
    ```bash
    cd SubscriberSystem
    dotnet run
    ```
    The API will be available at the URL specified in the terminal output (e.g., `https://localhost:7025`).

2.  **Start the AdSystem Web App:**
    *   In a new terminal, navigate to the `AdSystem` directory and run the application.
    ```bash
    cd AdSystem
    dotnet run
    ```
    The web application will be available at its specified URL (e.g., `https://localhost:7294`).

3.  **Launch the Windows UI Client:**
    *   In another new terminal, navigate to the `SubscriberSystem.WindowsUI` directory and run the application.
    ```bash
    cd SubscriberSystem.WindowsUI
    dotnet run
    ```

## 🏗️ Project Structure

The solution is organized into three main projects:

*   **`AdSystem/`**: An ASP.NET Core MVC application for managing ads and advertisers. It serves as the primary web interface.
*   **`SubscriberSystem/`**: An ASP.NET Core Web API that manages subscriber data, acting as the central service for subscriber information.
*   **`SubscriberSystem.WindowsUI/`**: A Windows Forms application that provides a desktop client for interacting with the `SubscriberSystem` API.

## 🛠️ Technologies Used

*   **.NET**
*   **ASP.NET Core MVC**
*   **ASP.NET Core Web API**
*   **Entity Framework Core**
*   **Windows Forms**
*   **SQL Server**

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a pull request or open an issue if you have any suggestions or find any bugs.

1.  Fork the Project
2.  Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3.  Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4.  Push to the Branch (`git push origin feature/AmazingFeature`)
5.  Open a Pull Request

## 📄 License

This project is licensed under the MIT License. See the `LICENSE` file for more information.
