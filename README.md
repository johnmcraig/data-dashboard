# Trend Dashboard
A dashboard UI using Angular and Chart.js with .Net Core Web API back-end

## Usage
Trend Dashbaord is a web based application with a heavy UI/UX emphisis using Angular that displays readable data of financial and ordering trends (hince the name) based on queries from a PostreSQL database.

Chart.js is a third party library incorporated that allows necessary data to be rendered in the form of bar, pie, and line charts to analyze relevant data from a web API.

The API is a .Net Core 2.1 library that contains a way to seed mock data through seed classes that is querried then pages the database of all the customers, orders, and the applications server status. 

## Development Tools
This application was developed using:
1. Angular 6 with @angular/cli version of 1.6
2. Chart.js
3. ASP.Net Core 2.1 with Entity Framework Core as the ORM.
4. PostgreSQL database.

## Setup
To run the application, clone or downlaod the repository then run `npm i` inside the NgDashboard directory to import any missing dependancies required for the project.

Make sure you are using the .Net Core SDK 2.0 or grater with `dotnet --version`. 

After doing so, startup the API and the Angular SPA by typing the following commands: 
- In the Dashboard.API directory, type `dotnet run`.
- In the NgDashboard directory, type `ng serve`.

Then open a browser at navigate to `http://localhost:4200` where the application should be running.
