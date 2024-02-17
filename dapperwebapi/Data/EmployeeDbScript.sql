create database EmployeDb
use employedb

CREATE TABLE Company (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Address NVARCHAR(255),
	Country NVARCHAR(100)
);
GO
CREATE TABLE Employee (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Age INT NOT NULL,
    Position NVARCHAR(100),
    CompanyId INT NOT NULL,
    CONSTRAINT FK_Employee_Company FOREIGN KEY (CompanyId) REFERENCES Company(Id)
);
GO
insert into Company (Name , Address , Country) values
('Cognizant', 'gurgaon', 'India'),
('Accenture', 'bangalore', 'India'),
('Tcs', 'Hyderabad', 'India')

go

INSERT INTO Employee (Name, Age, Position, CompanyId) VALUES
('John', 30, 'Hr', 1),
('Petter', 35, 'Admin', 2),
('Ramesh', 40, 'Maneger', 3),
('Naheem', 38, 'Developer', 1), 
('Saytender', 40, 'Exacutive', 1), 
('VIkash', 35, 'SR.Developer', 2),  
('Nitin', 37, 'Maneger', 2), 
('Amit', 42, 'Admin', 3);

go


CREATE PROCEDURE [dbo].[sp_CompanyByEmployeeId] @Id int
AS
SELECT c.Id, c.Name, c.Address, c.Country
FROM Company c JOIN Employee e ON c.Id = e.CompanyId
Where e.Id = @Id

go

select * from Company
select * from Employee