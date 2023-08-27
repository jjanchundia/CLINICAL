using AutoMapper;
using CLINICAL.Application.Dtos.Response;
using CLINICAL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.UseCase.Mappings
{
    //De AutoMapper - Profile
    public class AnalisisMappingProfile:Profile
    {
        public AnalisisMappingProfile()
        {
            //Mapeo de entidad
            //Cuando el State de la tabla sea == 1, va a mapear el StateAnalisis como Activo/Inactivo
            CreateMap<Analisis, GetAllAnalisisResponseDto>()
                .ForMember(x=>x.StateAnalisis, x=>x.MapFrom(y=>y.State == 1 ? "Activo" : "Inactivo"))
                .ReverseMap();

            CreateMap<Analisis, GetAnalisisByIdResponseDto>()
                .ReverseMap();
        }
    }
}