# AnyWhere - Network Project Site

## Description

AnyWhere is a web-based application that simulates the operations of a travel agency. It was developed using the MVC design pattern and utilizes technologies such as C#, Entity Framework, Bootstrap 5, and jQuery 3.6.1. The application facilitates the management of flight bookings and users.

## Project Preview

![Project Preview](Image-URL) <!-- Replace "Image-URL" with the actual URL of your image -->

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
-- Add the admin user:

```sql
INSERT INTO [dbo].[UsersDB] ([Email], [Id], [FirstName], [LastName], [Password]) VALUES (N'Admin@AnyWhere.com', 1, N'Admin', N'Admin', N'/admin')

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
