.Net Core Quotes Web Application
Create a .Net Core MVC quotes web application with Razor Views and API endpoints with the following entities:

Quote
Data Fields Id: auto-incremented 
Text: the content of the quote, should allow Unicode 
CreatedAt: timestamp 
Author: quote author, linked to author entity

Methods

**getRandomQuote***, **getQuoteByAuthor**, **addQuote**, deleteQuote, updateQuote, **listQuotes**

Author
Data Fields

Id: auto-incremented

Name: author's name

CreatedAt: timestamp

Methods

addAuthor, deleteAuthor, UpdateAuthor, listAuthors

#Requirements
Razor Views
All CRUD functionalities should have a web interface and utilize web controllers
Please create a view that lists all quotes, this page should include a dropdown to filter quotes by author, it should also include a button that once clicked retrieves a random quote by calling the API
Please create a view that lists all authors, if an author name is clicked the quotes list page above should open showing only quotes by this author
API endpoints
You are required to create API controllers for all methods in the entities
*You are not required to use these endpoints in the views except for getRandomQuote as stated above

Database and Migrations MSSQL or SQLLite database should host the data, please use code-first migrations to create the database
Authentication Authors CRUD functionalities in the web-interface should require authentication with proper razor views *You do not need to have authentication in the API
Deliverables
Prototype: a live application link, you can use a free Azure account or AWS free tier
Source: a github link of the project source