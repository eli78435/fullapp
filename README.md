# Thor & Loki Application

## Overview
This project consists of two main components:
- **Thor**: The backend logic implemented in ASP.NET Core.
- **Loki**: The frontend application built with React.

## Prerequisites
Before running the application, you need to set up a MySQL database.

## Database Setup

1. **Run a MySQL container using Docker**:
    ```sh
    docker run -p 3306:3306 --name some-mysql -e MYSQL_ROOT_PASSWORD=my-secret-pw -d mysql:latest

This command creates a MySQL database container with the root password set to my-secret-pw.

2. **Log in to MySQL:**:
    ```sh
    // Enter your password (my-secret-pw) when prompted.
    mysql -u root -p

## Setting Up the Database Schema (Entity Framework Code First)
1. **Navigate to the Thor directory**:
    ```sh
    cd Thor

2. **Ensure Entity Framework tools are installed**:   
    Ensure Entity Framework tools are installed:
    ```sh
    dotnet tool install --global dotnet-ef

3. **Apply Migrations to Generate the Database Schema**:
    Run the following command to create the database schema based on your models:
    ```sh
    dotnet ef database update
    ```
    This will apply the latest migrations and generate the necessary tables in thor_db.

## Running the Application

- **Backend (Thor)**:

	Navigate to the Thor directory:
    ````
    cd Thor
    ````

    Install dependencies (if needed):
    ````
    dotnet restore
    ````

    Run the backend:
    ````
    dotnet run
    ````

- **Frontend (Loki)**
    Navigate to the Loki directory:
    ```    
    cd Loki
    ```
        
    Install dependencies:
    ````
    npm install
    ````

    Start the frontend application:
    ````
    npm start
    ````

## Configuration
Ensure that the backend is configured to connect to the MySQL database. Update the connection string in the backend configuration file (appsettings.json or environment variables) with your database details.

Example appsettings.json:
````
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=thor_db;User=root;Password=my-secret-pw;"
  }
}
````