using CLINICAL.Application.UseCase.Commonds.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analisis.Commands.CreateCommand
{
    public class CreateAnalisisCommand: IRequest<BaseResponse<bool>>
    {
        public string? Name { get; set; }
    }
}