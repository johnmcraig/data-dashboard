# Trend Dashboard
A dashboard UI using Angular with .Net Web API back-end

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
To download the application, clone the repository then run `npm i` to download any missing dependancies required for the project.
