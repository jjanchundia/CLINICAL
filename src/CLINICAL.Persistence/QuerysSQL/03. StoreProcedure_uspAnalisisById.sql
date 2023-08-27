
--PROCEDURE uspAnalisisList
CREATE or alter PROCEDURE uspAnalisisById
(
    @AnalisisId int
)
as 
begin 
    select AnalisisId, Name--, State, AuditCreateDate
     from Analisis where AnalisisId = @AnalisisId;
End
Go

exec uspAnalisisById 1
