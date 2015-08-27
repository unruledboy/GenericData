# GenericData
Schema based generic C/S data management without the need to write code

# What & Why?
Do you want to have some basic data entry and store in a remote server but you don't want to write tedious client / server code?

With this solution, you can simply define the data structure and you are good to go.

It uses ASP.NET Web API at server side to accept requests. You can write code to implement your own logic to process the data.

# Features

- Schema based, no code required
- C/S based, works over the internet
- Supports extension by custom data access and handler

Currently support the following data access:

- SQL Server

# To Do

- Generic Client App for data entry
- Offline / sync support

# How to use it?

To test:

1.  Simply create a new sql database called `Test`, or you can modify the connection string in "OverflowStack.GenericData.Services\App_Data\ServerConfig.xml" to use existing database.
2.  Run the SQL script file "Documents\SqlServer.sql", once again, if you want, you can modify corresponding database and table name.
3.  Run OverflowStack.GenericData.Services web application
4.  Run OverflowStack.GenericData.Test console application

You should be able to see a new record is created then updated.
