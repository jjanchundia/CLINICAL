using CLINICAL.Application.UseCase.Commonds.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.UseCase.UseCases.Analisis.Commands.DeleteCommand
{
    public class DeleteAnalisisCommand: IRequest<BaseResponse<bool>>
    {
        public int AnalisisId { get; set; }
    }
}