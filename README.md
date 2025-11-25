# Distributed Ad Platform

A .NET-based solution demonstrating a distributed system for managing advertisements and subscribers.

## Components

The solution consists of three main projects:

1.  **AdSystem**: An ASP.NET Core MVC web application for creating and managing ads and advertisers. It communicates with the `SubscriberSystem` to sync subscriber data.
2.  **SubscriberSystem**: An ASP.NET Core Web API that provides endpoints for managing subscribers. It serves as the central hub for subscriber data.
3.  **SubscriberSystem.WindowsUI**: A Windows Forms desktop application that acts as a client for the `SubscriberSystem` API, allowing for direct interaction with subscriber data.

## Getting Started

### Prerequisites

*   .NET SDK
*   SQL Server (or SQL Server Express)

### Running the Application

1.  **Database Setup**:
    *   Each project (`AdSystem` and `SubscriberSystem`) is configured to use its own SQL Server database (`AdsDb` and `SubscriberDb` respectively).
    *   Update the connection strings in `AdSystem/appsettings.json` and `SubscriberSystem/appsettings.json` to point to your SQL Server instance.
    *   Run Entity Framework migrations to create the databases and tables. From each project's root directory, run:
        ```bash
        dotnet ef database update
        ```

2.  **Run the Backend Services**:
    *   Open a terminal and navigate to the `SubscriberSystem` directory. Run the project:
        ```bash
        cd SubscriberSystem
        dotnet run
        ```
        This will start the subscriber API, typically listening on `https://localhost:7025`.

    *   Open another terminal and navigate to the `AdSystem` directory. Run the project:
        ```bash
        cd AdSystem
        dotnet run
        ```
        This will start the main web application, typically available at `https://localhost:7294`.

3.  **Run the Desktop Client**:
    *   Navigate to the `SubscriberSystem.WindowsUI` directory and run the application:
        ```bash
        cd SubscriberSystem.WindowsUI
        dotnet run
        ```
        The desktop client will launch and connect to the `SubscriberSystem` API.

You can now use the `AdSystem` web interface to create ads and the `WindowsUI` client to manage subscribers. The systems will communicate in the background.