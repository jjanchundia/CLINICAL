
--Crear registro
CREATE or alter PROCEDURE InsCreateAnalisis
(
    @Name VARCHAR(50)
)
as 
begin 
    insert into Analisis(Name, STATE, AuditCreateDate)
    values(@Name, 1, getdate())
End
Go