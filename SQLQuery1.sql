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

SELECT * From Addresses

CREATE TABLE Document (
    DocumentId INT PRIMARY KEY Identity(1,1),
    DocumentType NVARCHAR(15),
    DocumentUrl NVARCHAR(MAX),
    MemberId INT FOREIGN KEY REFERENCES Members(MemberId)
);
Go






select* from Members

Insert into members Values('rn','nn','da@c.com','01524215321','1996-02-05','',GETDATE(),0)