create database MembershipManageDb

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
Insert into Addresses Values('rn','16, nn','ctg','ctg','ctg','1211','aa',1)



CREATE TABLE Document (
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



create table Memberships (
MembershipId int primary key identity(1,1),
MemberId int Foreign key references Members(MemberId),
PackageId int foreign key references Packages(PackageId),
StartDate date,
EndDate date,
Quantity int,
TotalInstallment int,
InstallmentAmount decimal(18,2)
)
GO

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

select* from Members
SELECT * From Addresses
select * from Documents
select * from Packages
select * from Memberships
select * from Payments


