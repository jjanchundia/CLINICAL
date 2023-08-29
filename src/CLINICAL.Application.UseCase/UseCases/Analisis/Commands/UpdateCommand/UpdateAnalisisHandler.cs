using AutoMapper;
using CLINICAL.Application.Interface.Interface;
using CLINICAL.Application.UseCase.Commonds.Bases;
using FluentValidation.Results;
using MediatR;
using Entity = CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.UseCases.Analisis.Commands.UpdateCommand
{
    public class UpdateAnalisisHandler : IRequestHandler<UpdateAnalisisCommand, BaseResponse<bool>>
    {
        //private readonly IAnalisisRepository _analisisRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        //public UpdateAnalisisHandler(IAnalisisRepository analisisRepository, IMapper mapper)
        public UpdateAnalisisHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            //_analisisRepository = analisisRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateAnalisisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                //Mapeamos entidad.
                var analisis = _mapper.Map<Entity.Analisis>(request);
                var parameters = new
                {
                    AnalisisId = analisis.AnalisisId,
                    Name = analisis.Name,
                };

                //response.Data = await _analisisRepository.AnalisisUpdate(analisis);
                response.Data = await _unitOfWork.Analisis.ExecuteAsync("UpdAnalisis", parameters);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Se actualizó correctamente!!!";

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