# Data Dashboard

> A UI/UX dashboard using Blazor Client, Chart.js and .Net Core API.

## Scope

Data Dashboard is a web based application using hexagonal/onion style architecture that displays readable data of customer and ordering trends based on queries from a PostgreSQL database.

Chart.js is a third party library incorporated that allows data to be rendered in the form of bar, pie, and line charts to analyze relevant data from the web API.

The API is a .Net Core library that contains detailed error logging, action method response codes, and Swagger documentation for easy client side testing.

## Development Tools

This application was developed using:

1. Blazor Client (WASM)
2. Chart.js
3. ASP.Net Core 3.1
4. PostgreSQL database
5. Dapper ORM

## Setup

To run the application, clone or download the repository then run `npm i` inside the NgDashboard directory to import any missing dependencies required for the project.

Make sure you are using the .Net Core SDK 2.0 or grater with `dotnet --version`.

After doing so, startup the API by typing the following commands:

- In the DashboardApi directory, type `dotnet run`.
- The Client project will automatically launch with the API.

Then open a browser and navigate to `http://localhost:5001` where the client application should be running.
