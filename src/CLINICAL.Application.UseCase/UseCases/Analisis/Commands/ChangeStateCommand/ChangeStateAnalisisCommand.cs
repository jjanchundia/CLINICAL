using CLINICAL.Application.UseCase.Commonds.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analisis.Commands.ChangeStateCommand
{
    public class ChangeStateAnalisisCommand: IRequest<BaseResponse<bool>>
    {
        public int AnalisisId { get; set; }
        public int State { get; set; }
    }
}