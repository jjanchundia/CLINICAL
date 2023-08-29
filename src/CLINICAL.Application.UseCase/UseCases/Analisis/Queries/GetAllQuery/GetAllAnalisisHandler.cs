using AutoMapper;
using CLINICAL.Application.Dtos.Response;
using CLINICAL.Application.Interface.Interface;
using CLINICAL.Application.UseCase.Commonds.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analisis.Queries.GetAllQuery
{
    //Recibe IRequest y Response
    public class GetAllAnalisisHandler : IRequestHandler<GetlAllAnalisisQuery, BaseResponse<IEnumerable<GetAllAnalisisResponseDto>>>
    {
        //private readonly IUnitOfWork _analisisRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        //Anterior, sin IUnitOfWork
        //public GetAllAnalisisHandler(IUnitOfWork _unitOfWork, IMapper mapper)
        public GetAllAnalisisHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<GetAllAnalisisResponseDto>>> Handle(GetlAllAnalisisQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllAnalisisResponseDto>>();

            try
            {
                //var analisis = await _analisisRepository.ListAnalisis();
                var analisis = await _unitOfWork.Analisis.GetAllAsync("uspAnalisisList");
                if (analisis is not null)
                {
                    response.IsSuccess = true;
                    //Mapeamos GetAllAnalisisResponseDto con la entidad analisis del repositorio.
                    response.Data = _mapper.Map<IEnumerable<GetAllAnalisisResponseDto>>(analisis);
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }
    }
}