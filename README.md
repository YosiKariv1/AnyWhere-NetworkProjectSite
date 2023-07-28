# AnyWhere - Network Project Site

## Description

AnyWhere is a web-based application that simulates the operations of a travel agency. It was developed using the MVC design pattern and utilizes technologies such as C#, Entity Framework, Bootstrap 5, and jQuery 3.6.1. The application facilitates the management of flight bookings and users.

## Project Preview

![ללא שם](https://github.com/YosiKariv1/AquariumSimulator/assets/93153387/28639b1e-38f3-44ce-aa94-033f31c23b75)

## Installation/Setup Instructions

1. Download the project files from [this link](https://drive.google.com/drive/folders/1kNfYUXQvYOAkUFTHVw8bJGqTVReb3ZOy?usp=sharing).
2. Set up the Microsoft SQL Server and create the required tables (see 'Database Setup' below).
3. Open the solution in Visual Studio or any compatible IDE.
4. Run the application.

## Database Setup

### Users

Create the `UsersDB` table:

```sql
CREATE TABLE [dbo].[UsersDB] (
    [Email]     NVARCHAR (50) NOT NULL,
    [Id]        INT           NOT NULL,
    [FirstName] NVARCHAR (10) NOT NULL,
    [LastName]  NVARCHAR (10) NOT NULL,
    [Password]  NVARCHAR (10) NOT NULL,
    CONSTRAINT [PK_dbo.UsersDB] PRIMARY KEY CLUSTERED ([Email] ASC)
);
```
Add the admin user:

```sql
INSERT INTO [dbo].[UsersDB] ([Email], [Id], [FirstName], [LastName], [Password]) VALUES (N'Admin@AnyWhere.com', 1, N'Admin', N'Admin', N'/admin')
```

### Flights
Create the FlightsDB table:

```sql
CREATE TABLE [dbo].[FlightsDB] (
    [f_Id]        INT           NOT NULL,
    [Company]     VARCHAR (255) NULL,
    [From]        VARCHAR (255) NULL,
    [To]          VARCHAR (255) NULL,
    [Depart]      VARCHAR (255) NULL,
    [Time_Depart] VARCHAR(50)   NULL,
    [Return]      VARCHAR (255) NULL,
    [Time_Return] VARCHAR (255) NULL,
    [Stops]       INT           NULL,
    [isLowCost]   BIT           NULL,
    [Sits]        INT           NULL,
    [TicketPrice] DECIMAL (18)  NULL, 
    CONSTRAINT [PK_FlightsDB] PRIMARY KEY ([f_Id])
);
```

### Bookings
Create the BooksDB table:
```sql
CREATE TABLE [dbo].[BooksDB] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [User_id] INT NOT NULL,
    [Flight_id] INT NOT NULL,
    [FirstName] NVARCHAR(50) NOT NULL,
    [LastName] NVARCHAR(50) NOT NULL,
    [Email] NVARCHAR(255) NOT NULL,
    [Company] NVARCHAR(50) NULL,
    [From] NVARCHAR(50) NOT NULL,
    [To] NVARCHAR(50) NOT NULL,
    [Depart] NVARCHAR(50) NOT NULL,
    [Time_Depart] NVARCHAR(50) NOT NULL,
    [Return] NVARCHAR(50) NOT NULL,
    [Time_Return] NVARCHAR(50) NOT NULL,
    [Stops] INT NOT NULL,
    [isLowCost] BIT NOT NULL,
    [CardNumber] NVARCHAR(50) NOT NULL,
    [ExpirationDate] NVARCHAR(50) NOT NULL,
    [SecurityCode] NVARCHAR(50) NOT NULL,
    [WantToStore] BIT NOT NULL,
    [NumberOfTickets] INT NOT NULL,
    [TotalPrice] DECIMAL(10,2) NOT NULL
);
```

### Project Structure
- Models: Users, Flights, Booking
- Controllers: HomeController, FlightsController, BookingController, AdminController

### Technologies Used
- C#
- MVC
- Entity Framework
- Bootstrap 5
- jQuery 3.6.1
- Microsoft SQL Server

### Contact Information
- LinkedIn - Yosi Kariv
- Email - Yosi277@gmail.com
