using AutoMapper;
using CLINICAL.Application.Dtos.Response;
using CLINICAL.Application.Interface.Interface;
using CLINICAL.Application.UseCase.Commonds.Bases;
using CLINICAL.Application.UseCase.UseCases.Analisis.Commands.UpdateCommand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.UseCase.UseCases.Analisis.Commands.DeleteCommand
{
    public class DeleteAnalisisHandler: IRequestHandler<DeleteAnalisisCommand, BaseResponse<bool>>
    {
        //private readonly IAnalisisRepository _analisisRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        //public DeleteAnalisisHandler(IAnalisisRepository analisisRepository, IMapper mapper)
        public DeleteAnalisisHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(DeleteAnalisisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                //Mapeamos entidad.

                //response.Data = await _analisisRepository.AnalisisRemove(request.AnalisisId);
                response.Data = await _unitOfWork.Analisis.ExecuteAsync("DelAnalisis", new { request.AnalisisId });

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa!!!";

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