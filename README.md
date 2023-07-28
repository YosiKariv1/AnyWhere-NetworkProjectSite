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
