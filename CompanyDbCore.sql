CREATE DATABASE CompanyDb

USE CompanyDb

CREATE TABLE Department(Id INT PRIMARY KEY IDENTITY, DepartmentName VARCHAR(100));

CREATE TABLE Employee (Id INT PRIMARY KEY IDENTITY, FirstName VARCHAR(100), LastName VARCHAR(100), Email VARCHAR(255), DepartmentId INT);

ALTER TABLE Employee ADD CONSTRAINT FK_Department_Employee FOREIGN KEY(DepartmentId) REFERENCES Department(Id);

CREATE TABLE Laptop(Id INT PRIMARY KEY, BrandName VARCHAR(200), EmployeeId INT)

ALTER TABLE Laptop ADD CONSTRAINT FK_Employee_Laptop FOREIGN KEY(EmployeeId) REFERENCES Employee(Id)

CREATE TABLE Project(Id INT PRIMARY KEY IDENTITY, ProjectName VARCHAR(100), Duration INT NOT NULL);

CREATE TABLE EmployeeProject (Id INT PRIMARY KEY IDENTITY, EmployeeId INT, ProjectId INT);
ALTER TABLE EmployeeProject ADD CONSTRAINT FK_Employee_EmployeeProject FOREIGN KEY(EmployeeId) REFERENCES Employee(Id)
ALTER TABLE EmployeeProject ADD CONSTRAINT FK_Project_EmployeeProject FOREIGN KEY(ProjectId) REFERENCES Project(Id)


--ALTER TABLE EmployeeProject ADD Id INT PRIMARY KEY IDENTITY 
ALTER TABLE EmployeeProject
  ADD CONSTRAINT UQ_EmployeeProject UNIQUE(EmployeeId, ProjectId);

--DROP TABLE  EmployeeProject;
--DROP TABLE  Project;
--DROP TABLE  Employee;
--DROP TABLE  Department;
--DROP TABLE Laptop;

INSERT INTO Department Values('GTD');
INSERT INTO Department Values('DT');

INSERT INTO Employee Values('Kailash','Sharma', 'k@gmail.com',1);
INSERT INTO Employee Values('Sailash','Sharma', 's@gmail.com',1);
INSERT INTO Employee Values('Ramesh','Kumar', 'rk@gmail.com',2);
INSERT INTO Employee Values('Kiku','Sharma', 'ks@gmail.com',2);
INSERT INTO Employee Values('Raj','Varma', 'rv@gmail.com',1);

INSERT INTO Laptop VALUES(101,'Dell',1);
INSERT INTO Laptop VALUES(102,'Hp',2);
INSERT INTO Laptop VALUES(103,'Asus',3);
INSERT INTO Laptop VALUES(104,'Dell',4);
INSERT INTO Laptop VALUES(105,'Hp',5);


INSERT INTO Project VALUES('Project siksha', 180);
INSERT INTO Project VALUES('Project study', 180);
INSERT INTO Project VALUES('Project qurantine', 21);

INSERT INTO EmployeeProject VALUES(1,1);
INSERT INTO EmployeeProject VALUES(1,2);
INSERT INTO EmployeeProject VALUES(2,1);
INSERT INTO EmployeeProject VALUES(3,3);

INSERT INTO EmployeeProject VALUES(4,2);

INSERT INTO EmployeeProject VALUES(5,1);


SELECT * FROM Project;
SELECT * FROM Employee;
SELECT * FROM EmployeeProject;
SELECT * FROM Employee;
SELECT * FROM Department;
SELECT * FROM Laptop


--3rd
SELECT Id, BrandName FROM Laptop;
SELECT Laptop.Id AS LaptopId, BrandName, (FirstName+ ' ' +LastName) AS Ownername FROM Laptop, Employee WHERE Laptop.EmployeeId = Employee.Id

--4th
SELECT e.FirstName, e.LastName, e.Email, e.DepartmentId, d.DepartmentName, l.BrandName as LaptopBrand 
FROM Employee e 
JOIN Department d ON e.DepartmentId = d.Id
JOIN Laptop l ON l.EmployeeId = e.Id
WHERE e.Id = 1

--5th
SELECT d.Id, d.DepartmentName,  (FirstName+ ' ' +LastName) AS Employeename, l.Id AS LaptopId, BrandName 
FROM Department d
JOIN Employee e ON e.DepartmentId = d.Id
JOIN Laptop l ON l.EmployeeId = e.Id
WHERE d.Id = 2

--6th
SELECT l.Id, l.BrandName, e.Id AS EmployeeId, (FirstName+ ' ' +LastName) AS Employeename, d.Id AS DepartmentId, d.DepartmentName 
FROM Laptop l
JOIN Employee e ON e.Id = l.EmployeeId
JOIN Department d ON d.Id = e.Id
WHERE l.Id = 102