# Tims Diner Project


# How Its made

Tech used: C#, HTML, ASP.NET Core


Set up a data Library project in ASP.net Core. 

Create a SQL database SSDT (SQL server data tools Project)
Create 2 tables (order table, food table)

Food Table - keep track of the different food that someone can order
Order Table - Keeps track of the order and who orderd the food. 



 Post deploy scrit created
Created 5 Stored Procedures (CRUD)
Published the SQL Server Database Locally 
used Dapper for Data Access layer.


Use a SQL DB connection as well as 


Create Store Procedures for simple data entry. 
Created a models for Food and Orders. 

Exported DLL from a data library and used it the other .net projects.

### create DLL
- built the data library project in release mode 
- then in the bin/release folder for the project is should have the DLL that will be used in the other projects.

# Razor Pages Starter 
created a new Razor Pages
Added the data library DLL
set to Copy to output: copy always. 
added Dependency to the data library
Razor pages are MVVM Model-View-View Model (two way binding)

# Creating Data for Razor Pages starter



# API Starter

-created a new api project. 
- added a the DLL for the data library. Make sure to add the 3 references 
- added the connection strings to appsettings.json from to the local database TimsDinerDB 

## send data in the API starter
- send data two different ways
- sent back ain IActionResult
- sending the actucal type
- Added CRUD Operations to the API



## Optimizations

- Create a interface for FoodData.(IFoodData)
- Create a sqlFoodData model and implement the IFoodData interface. This allows for more that one database object. 
