using CLINICAL.Application.Dtos.Response;
using CLINICAL.Application.UseCase.Commonds.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analisis.Queries.GetByIdQuery
{
    public class GetAnalisisByIdQuery: IRequest<BaseResponse<GetAnalisisByIdResponseDto>>
    {
        public int Id { get; set; }
    }
}