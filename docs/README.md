# GoSupplyChallenge

The goal of this training is to develop a web API using Dapper with SQL queries or stored procedures to retrieve the data.
Some technologies and patterns used are:
API Restfull, Authentication, and Authorization with JWTbearer, DDD, DI, AutoMapper, Repository Pattern, xUnit, and .NET 6
Clean Code and Solid.
### Requirements for API: 
1. Insert students  
2. Return the students of a province.  
3. Group (LINQ) to get the number of students per teacher.
### Requirements for Database: 
(A complete procedure, with parameters, body, etc... will work)
1. Get the different provinces to which the students belong and the number of students in each province (SQL).  

[Procedure Solution](https://github.com/Haliam/GoSupplyChallenge/blob/dev/docs/Database/04%20GetNumberStudentsByProvinceProcedure.txt)

2. Get the province that has more students in the course (course as parameter) and
how this procedure would be executed in sqlserver?

[Procedure Solution](https://github.com/Haliam/GoSupplyChallenge/blob/dev/docs/Database/05%20GetProvinceWithMostStudentsByCourseProcedure.txt)

### Some pending developments: 
Add Sql Query Builder as SqlKata or using Dapper for build queries.
Implement Validation Rules
Globar error handling
Create custom errors for Error Handling
Saving logs in database 
Sensitive information management with encryption