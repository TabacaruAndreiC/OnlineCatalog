# Online Catalog

The Online Catalog is a software application designed to facilitate the management of a school's administrative tasks, such as managing students, teachers, classes, and other related information. This project provides a set of functionalities to perform basic operations like adding, updating, and retrieving data for students, teachers, and classes.

## Features

- Add, update, and delete students
- Add, update, and delete teachers
- Add, update, and delete classes
- Assign teachers to classes
- Generate unique random IDs for users

## Technologies Used

- Programming Language: C#
- Database: SQL Server
- Data Access: ADO.NET
- User Interface: Console Application

## Setup and Configuration

1. Clone the repository to your local machine.
2. Open the solution file `SchoolManagementSystem.sln` in Visual Studio.
3. Build the solution to restore NuGet packages.
4. Configure the database connection in the `DALHelper.cs` file located in the `DataAccessLayer` folder.
5. Run the project to start the School Management System.

## Database Schema

The database schema consists of the following tables:

- Users: Stores user information, including student and teacher details.
- Students: Stores student-specific information.
- Teachers: Stores teacher-specific information.
- Classes: Stores class information.
- Grades : Stores grades information
