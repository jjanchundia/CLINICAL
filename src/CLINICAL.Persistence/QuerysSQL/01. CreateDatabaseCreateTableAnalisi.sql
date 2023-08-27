
Create Database CLINICAL;

Create TABLE Analisis(
    AnalisisId int IDENTITY(1,1) primary key not null,
    Name VARCHAR(50),
    State int not null,
    AuditCreateDate datetime2(7) not null
)
Go
