# Amrit-Tulya-API
This is an API for SadGuru's Amrit Tulya - Tea Shop. 

It is built in .Net Core 3.1. This API is used to fetch/add/delete items from the Tea Inventory. 

This API uses EF Core as its ORM and MS SQL-Server for performing Database related operations.

Also, xUnit has been used for implementing unit tests.

This API is locally hosted on port 3000.

Check for the port while running the app. If the port is changed, you need to update the same into UI Project as well.

UI path - https://github.com/kothekarvikram5/Sadguru-Amrit-Tulya

## Set Up the Database.

Update Connection String of your Database (I used SQL Server 2014) in the appsettings.json file, under "ConnectionString->TeaShopDBConnection"

After Updating Connection String, run 'update-database' command in Package Manager Console(PM) in Visual Studio. This will set up the Database for our app.

## Deployment 
For Simple Deployment - goto ..\bin\Release\netcoreapp3.1

In the above path, you will find the published code for Windows OS, which you can directly deploy.

To configure this for other environments, again need to configure from the code.
