using AutoMapper;
using CLINICAL.Application.Interface.Interface;
using CLINICAL.Application.UseCase.Commonds.Bases;
using CLINICAL.Application.UseCase.UseCases.Analisis.Commands.CreateCommand;
using MediatR;
using Entity = CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.UseCases.Analisis.Commands.ChangeStateCommand
{
    public class ChangeStateAnalisisHandler : IRequestHandler<ChangeStateAnalisisCommand, BaseResponse<bool>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ChangeStateAnalisisHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            //_analisisRepository = analisisRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(ChangeStateAnalisisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                //Mapeamos entidad.
                var analisis = _mapper.Map<Entity.Analisis>(request);

                var parameter = new { analisis.AnalisisId, analisis.State };
                response.Data = await _unitOfWork.Analisis.ExecuteAsync("ChangeStateAnalisis", parameter);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Se actualizó correctamente el State!!!";
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