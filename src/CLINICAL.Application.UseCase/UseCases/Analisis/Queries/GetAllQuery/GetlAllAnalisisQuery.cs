using CLINICAL.Application.Dtos.Response;
using CLINICAL.Application.UseCase.Commonds.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analisis.Queries.GetAllQuery
{
    //Instaciamos interfaz de MediatR
    //Devolvemos un BaseResponse, un IEnumerable 
    public class GetlAllAnalisisQuery:IRequest<BaseResponse<IEnumerable<GetAllAnalisisResponseDto>>>
    {

    }
}