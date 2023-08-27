
--Crear registro
CREATE or alter PROCEDURE DelAnalisis
(
    @AnalisisId int
)
as 
begin 
    delete from Analisis 
    where AnalisisId = @AnalisisId
End
Go

--exec UpdAnalisis 1, 'Prueba Analisis'

--select * from Analisis
