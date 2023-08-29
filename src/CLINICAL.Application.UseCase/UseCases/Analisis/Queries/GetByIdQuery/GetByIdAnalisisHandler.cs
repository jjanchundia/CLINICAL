using AutoMapper;
using CLINICAL.Application.Dtos.Response;
using CLINICAL.Application.Interface.Interface;
using CLINICAL.Application.UseCase.Commonds.Bases;
using CLINICAL.Application.UseCase.UseCases.Analisis.Queries.GetAllQuery;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analisis.Queries.GetByIdQuery
{
    public class GetByIdAnalisisHandler : IRequestHandler<GetAnalisisByIdQuery, BaseResponse<GetAnalisisByIdResponseDto>>
    {
        //private readonly IAnalisisRepository _analisisRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetByIdAnalisisHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            //_analisisRepository = analisisRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetAnalisisByIdResponseDto>> Handle(GetAnalisisByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetAnalisisByIdResponseDto>();

            try
            {
                var analisis = await _unitOfWork.Analisis.GetByIdAsync("uspAnalisisById", new { AnalisisId = request.Id });
                if (analisis is null)
                {
                    response.IsSuccess = true;
                    response.Message = "No se encontraron registros";

                    return response;
                }

                response.IsSuccess = true;
                //Mapeamos GetAnalisisByIdResponseDto con la entidad analisis del repositorio.
                response.Data = _mapper.Map<GetAnalisisByIdResponseDto>(analisis);
                response.Message = "Consulta Exitosa!!!";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }
    }
}