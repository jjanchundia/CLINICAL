
--PROCEDURE uspAnalisisList
CREATE or alter PROCEDURE uspAnalisisList
as 
begin 
    select AnalisisId, Name, State, AuditCreateDate
     from Analisis;
End
Go

exec uspAnalisisList
