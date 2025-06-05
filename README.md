# Laptops.Final

![image](https://github.com/user-attachments/assets/565696e0-69ea-4dbc-a1ec-46d5e5aa2835)

-- Create the database again
CREATE DATABASE Laptops;
GO

-- Use the newly created database
USE Laptops;
GO



-- Create the table
CREATE TABLE Laptops (
    Id INT IDENTITY PRIMARY KEY,   -- Auto-incremented ID
    Model NVARCHAR(100),           -- Model of the laptop
    ReleaseYear INT,               -- Release year
    MemorySize INT,                -- Memory size in GB
    Cores INT                      -- Number of cores
);
GO



SELECT * FROM Laptops;
GO

Set up the C# Project in Visual Studio Create a New C# Windows Forms App (.NET Framework) project in Visual Studio. Choose the "Windows Forms App (.NET Framework)" template. Name your project LashaMurgvaLominadzeShraieri.Quiz3 to match the namespaces. Ensure the target .NET Framework is 4.7.2 or later (or whatever you initially used). Add NuGet Package: In Visual Studio, right-click your project in Solution
![image](https://github.com/user-attachments/assets/2677ae83-84a4-465a-954c-225d75586f60)
![image](https://github.com/user-attachments/assets/0880adfe-6144-4862-9a86-a96c0604d31f)

SQLEXPRESS

PCName\SQLEXPRESS

CREATE DATABASE CarDatabase; GO

USE CarDatabase; GO

CREATE TABLE Cars ( Id INT PRIMARY KEY IDENTITY(1,1), Model NVARCHAR(255) NOT NULL, Weight FLOAT NOT NULL, Speed INT NOT NULL ); GO

To see the cars: USE CarDatabase; SELECT * FROM Cars;

