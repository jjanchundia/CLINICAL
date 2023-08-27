using CLINICAL.Application.UseCase.Commonds.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analisis.Commands.UpdateCommand
{
    public class UpdateAnalisisCommand : IRequest<BaseResponse<bool>>
    {
        public int AnalisisId { get; set; }
        public string? Name { get; set; }
    }
}