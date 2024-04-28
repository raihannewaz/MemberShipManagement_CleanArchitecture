
use master
create database MembershipManageDb
GO

use MembershipManageDb
go

Create Table Members
(
MemberId int primary key identity(1,1),
FirstName varchar(50),
LastName varchar(50),
Email varchar(150),
PhoneNo varchar(11),
DOB Date,
ProfileImageUrl varchar(Max),
AccountCreateDate date,
IsActive bit
)
go

CREATE TABLE Addresses (
    AddressId INT PRIMARY KEY Identity(1,1),
    AddressType varchar(20),
    HouseNo varchar(100),
    City varchar(15),
    Region varchar(15),
    PostOffice varchar(15),
    PostalCode varchar(15),
    Country varchar(20),
    MemberId int FOREIGN KEY REFERENCES Members(MemberId)
);
Go



CREATE TABLE Documents (
    DocumentId INT PRIMARY KEY Identity(1,1),
    DocumentType NVARCHAR(15),
    DocumentUrl NVARCHAR(MAX),
    MemberId INT FOREIGN KEY REFERENCES Members(MemberId)
);
Go


create table Packages(
PackageId int Primary key identity(1,1),
PackageName varchar(30),
PackageType Varchar(20),
Duration int,
PackagePrice decimal,
IsActive bit
)
GO

CREATE TABLE Memberships (
    MembershipId INT PRIMARY KEY IDENTITY(1,1),
    MemberId INT FOREIGN KEY REFERENCES Members(MemberId),
    PackageId INT FOREIGN KEY REFERENCES Packages(PackageId),
    StartDate DATE,
    EndDate DATE,
    Quantity INT,
    TotalInstallment INT,
    InstallmentAmount DECIMAL(18,2)
);



create table Payments(
PaymentId int primary key identity(1,1),
MembershipId int foreign key references Memberships(MembershipId),
PaymentDate Datetime,
AdvanceInstallMent int,
PaidAmmount decimal
)
go

create table DuePayments(
DuePaymentId int primary key identity(1,1),
MembershipId int foreign key references Memberships(MembershipId),
DueDate datetime,
Amount decimal
)

go

SELECT* From Members
SELECT * From Addresses
select * from Documents
select * from Packages
SELECT* From Members
select * from Memberships
select * from Payments
select * from DuePayments


Insert into Addresses Values('rn','16, nn','ctg','ctg','ctg','1211','aa',1)

insert into DuePayments values(1,'2024-04-19',105),
							(1,'2024-04-20',105),
							(1,'2024-04-21',105)



