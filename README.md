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
















Step 3: Modify the SQL Script ({EntityNamePlural}Database.sql)
The template includes a SQL script. After performing the replacements in Step 2, this file will also have your new entity names.

Open the SQL Script: Locate and open the {EntityNamePlural}Database.sql file in your project.
Review and Adjust Data Types: Double-check that the SQL data types (NVARCHAR(255), FLOAT, INT, etc.) for your {PropertyXName} columns are appropriate for the data you intend to store.
Run in SSMS:
Open SQL Server Management Studio (SSMS).
Connect to your SQL Server instance (e.g., SHRAI\SQLEXPRESS).
Open the modified {EntityNamePlural}Database.sql file in SSMS.
Execute the script. This will create your new database and table.
Step 4: Build and Run Your Application
Build Solution: In Visual Studio, go to Build > Rebuild Solution.
Crucial: Check the "Output" window (usually at the bottom) for any errors. If there are errors, they will prevent the application from running. Fix them before proceeding. Common errors are often typos or incorrect type conversions.
Start Debugging: Click the green "Start" button (or press F5).
Your application should now launch, allowing you to add, edit, and delete your new entities (e.g., Cars, Cats, Persons) using the adapted interface and database.

Common Troubleshooting Tips:
"Invalid Column Name" (SQL Error): This almost always means there's a mismatch between the column names in your C# SqlHelper.cs queries and the actual column names in your SQL table. Double-check your SQL script and SqlHelper.cs.
"Cannot Convert Type..." (C# Error): You might have used the wrong Convert.To... method in SqlHelper.cs when reading from the database, or in your [EntityName]Dialog.cs when parsing text from the text boxes. Ensure float.TryParse for floats, int.TryParse for integers, etc.
"Debug Profile Does Not Exist": This is a Visual Studio configuration issue. Try Build > Clean Solution, then Build > Rebuild Solution. If it persists, close Visual Studio, delete the hidden .vs folder in your project's root directory, and reopen.
"Object Reference Not Set to an Instance of an Object": Often means a UI control (like a TextBox) isn't initialized, or you're trying to access a property on a null object. Check your InitializeComponent() and ensure objects are properly instantiated and assigned.
By following these steps, you'll be well-prepared to quickly adjust this template for your exam!

Absolutely — here’s a complete step-by-step guide to help you change every placeholder in your app and make it fully your own. This guide assumes you're starting from the placeholder version with names like EntityName, Property1Name, etc.

🧭 Step-by-Step Guide: Rename Everything in the App
Let’s say your app is for laptops. Here's how you'd replace everything properly:

🔁 1. Global Find & Replace (Ctrl + H)
In Visual Studio, press Ctrl + H (Find and Replace). Use the following table to change all placeholders.

Placeholder	Replace With (Laptop Example)
EntityName	Laptop
EntityNamePlural	Laptops
Property1Name	Model
Property1Type	string
Property2Name	MemorySize
Property2Type	float
Property3Name	Cores
Property3Type	int
EntityNamePluralDatabase	LaptopsDatabase
🔎 In the Find box, type the placeholder without brackets, e.g. EntityName. ✅ In the Replace with box, type e.g. Laptop, then press Replace All.

Do this for each item above.

📁 2. File Names (Optional but Recommended)
Rename these files accordingly in Solution Explorer:

Old File	New File
EntityName.cs	Laptop.cs
EntityNameDialog.cs	LaptopDialog.cs
EntityNameDialog.Designer.cs	LaptopDialog.Designer.cs
EntityNamePlural.sql	Laptops.sql
Right-click → Rename Update the class name inside the file as well

🖥️ 3. Adjust the SQL .sql File
Open Laptops.sql and ensure it matches:

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'LaptopsDatabase')
BEGIN
    CREATE DATABASE LaptopsDatabase;
END
GO

USE LaptopsDatabase;
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Laptops' AND xtype='U')
BEGIN
    CREATE TABLE Laptops (
        Id INT PRIMARY KEY IDENTITY(1,1),
        Model NVARCHAR(255) NOT NULL,
        MemorySize FLOAT NOT NULL,
        Cores INT NOT NULL
    );
END
GO
🧱 4. Adjust Laptop.cs (Model)
public class Laptop
{
    public int Id { get; set; }
    public string Model { get; set; }
    public float MemorySize { get; set; }
    public int Cores { get; set; }

    public Laptop(string model, float memorySize, int cores)
    {
        Model = model;
        MemorySize = memorySize;
        Cores = cores;
    }

    public override string ToString()
    {
        return $"{Model} ({MemorySize} GB, {Cores} Cores)";
    }
}
🧠 5. Adjust UI Labels/TextBoxes in LaptopDialog.Designer.cs
Rename controls and their labels:

Control Name	What to write
ModelTxtBox	TextBox for model
MemorySizeTxtBox	TextBox for memory
CoresTxtBox	TextBox for cores
DoneButton	Keep as is
Label text examples:

this.modelLbl.Text = "Model:";
this.memorysizeLbl.Text = "Memory Size (GB):";
this.coresLbl.Text = "Cores:";
🧩 6. Form1 Controls in Form1.Designer.cs
Make sure to update:

LaptopsListBox
AddLaptopButton
EditLaptopButton
DeleteLaptopButton
laptopsLbl
Update the Text of each button:

this.AddLaptopButton.Text = "Add Laptop";
this.EditLaptopButton.Text = "Edit Laptop";
this.DeleteLaptopButton.Text = "Delete Laptop";
this.laptopsLbl.Text = "Laptop List:";
this.Text = "Laptop Management";
🔗 7. Connection String in Form1.cs
Make sure the connection string matches the DB:

private string connectionString = "Server=YOUR_SERVER_NAME;Database=LaptopsDatabase;Integrated Security=True;TrustServerCertificate=True;";
Replace YOUR_SERVER_NAME with your SQL Server instance (e.g., SHRAI\\SQLEXPRESS).

✅ 8. Build & Run
Press Ctrl + Shift + B to build
Run your SQL script manually in SSMS or Visual Studio → SQL Server Object Explorer
Start the app
Add, edit, delete laptops ✅
🧼 Optional Cleanup Tips
Remove unused using statements (Ctrl + R, G)
Group files in folders (Models, Dialogs, etc.)
Add comments if needed

