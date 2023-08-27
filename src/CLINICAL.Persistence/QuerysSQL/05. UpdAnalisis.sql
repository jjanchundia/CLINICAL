
--Crear registro
CREATE or alter PROCEDURE UpdAnalisis
(
    @AnalisisId int,
    @Name VARCHAR(50)
)
as 
begin 
    update Analisis set Name = @Name
    where AnalisisId = @AnalisisId
End
Go

--exec UpdAnalisis 1, 'Prueba Analisis'

--select * from Analisis
