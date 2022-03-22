# Asmx-WebService
ASMX Web Service in best practice. Here we implement 3-Tier architecture &amp; use database first approach

## Introduction
Hi I'm Khoirudin. Here we have developed ASMX web service as baseline. Due to it's just a baseline of ASMX web service, therefore we simply use simple database schema.
(User Table) -> Column : Id (uniqueidentifier), Name (varchar(100), Email (nvarchar(100), Phone(nvarchar(50) & Birthdate (datetime nullable). However all you guys able to modify the database schema as per requirement.

## Project Layers
The 3-Tier architecture has minimal 3 different project within solution such as Presentation Layer (AsmxWebService), Business Logic Layer (Business) & Data Access Layer (data).

### Data (Layer)
In order to communicate with SQL Server Database. We'll perform database first also in here. You have to install EntityFramework via Nuget Package, unless our application unale to access the data.

### Business (Layer)
Once we've create Data Layer in previous, we have to create business layer to perform several logic. For example, if we'll customize unique id based on subsequent sequence, we can put the logic here or perhaps anything logic while performing CRUD. Don't forget to add project reference of Data Layer on this layer.

### Presentation (Layer)
This is main layer will interact to client / user. Once data and business layer were done. We have to add project references to this layer. Either business or data. Actually, we will send or retrieve data here by communicating with business layer. But, since our models are stored in data layer, then we have to add reference as well.

Important : We have to install Entity Framework and paste the connection string from Data Layer
