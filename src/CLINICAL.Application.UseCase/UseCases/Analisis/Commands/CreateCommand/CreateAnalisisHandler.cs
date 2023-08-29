using AutoMapper;
using CLINICAL.Application.Interface.Interface;
using CLINICAL.Application.UseCase.Commonds.Bases;
using MediatR;
using Entity = CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.UseCases.Analisis.Commands.CreateCommand
{
    public class CreateAnalisisHandler: IRequestHandler<CreateAnalisisCommand, BaseResponse<bool>>
    {
        //private readonly IAnalisisRepository _analisisRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        //public CreateAnalisisHandler(IAnalisisRepository analisisRepository, IMapper mapper)
        public CreateAnalisisHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            //_analisisRepository = analisisRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(CreateAnalisisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                //Mapeamos entidad.
                var analisis = _mapper.Map<Entity.Analisis>(request);

                //response.Data = await _analisisRepository.AnalisisRegister(analisis);
                //response.Data = await _unitOfWork.Analisis.ExecuteAsync("InsCreateAnalisis", request);Correcto o el de abajo igual funciona
                var parameter = new { analisis.Name };
                response.Data = await _unitOfWork.Analisis.ExecuteAsync("InsCreateAnalisis", parameter);
                //await _analisisRepository.AnalisisRegister(request);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Se registró correctamente!!!";

                    return response;
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