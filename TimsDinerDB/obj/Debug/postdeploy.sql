/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


if NOT EXISTS (SELECT * FROM dbo.Food)
begin 

   insert into dbo.Food(Title, [Description], Price)
   values('Cheeseburger Meal','A cheeseburger, fries, drink',5.95),
   ('Chilli Meal','Two Chilli dogs, fries, drink', 4.15),
   ('Vegan Meal','A large Salad and a water',5.95)
end
GO
