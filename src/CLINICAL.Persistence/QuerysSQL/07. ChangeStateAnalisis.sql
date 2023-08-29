
--select * from analisis

create or alter procedure ChangeStateAnalisis
(
    @AnalisisId int,
    @State int
)
as 
begin 
    update Analisis set [State] = @State
    where AnalisisId = @AnalisisId
End
Go

