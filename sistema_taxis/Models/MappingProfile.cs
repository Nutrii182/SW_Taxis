using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_taxis.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Chofer, ChoferDto>()
                .ForMember(x => x.Unidades, y => y.MapFrom(z => z.UnidadLink.Select(a => a.Unidad).ToList()))
                .ForMember(x => x.TipoSangre, y => y.MapFrom(z => z.TipoSangre))
                .ForMember(x => x.Status, y => y.MapFrom(z => z.Status))
                .ForMember(x => x.Pagos, y => y.MapFrom(z => z.PagoList));
            CreateMap<ChoferUnidad, ChoferUnidadDto>();
            CreateMap<Unidad, UnidadDto>();
            CreateMap<TipoSangre, TipoSangreDto>();
            CreateMap<Status, StatusDto>();
            CreateMap<Pago, PagoDto>();
        }
    }
}
