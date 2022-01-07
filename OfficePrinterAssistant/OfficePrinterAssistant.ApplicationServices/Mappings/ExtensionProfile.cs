using AutoMapper;
using OfficePrinterAssistant.ApplicationServices.API.Domain.ExtensionRequests;
using OfficePrinterAssistant.ApplicationServices.API.Domain.Models;
using OfficePrinterAssistant.DataAccess.Entities;

namespace OfficePrinterAssistant.ApplicationServices.API.Mappings
{
    public class ExtensionProfile : Profile
    {
        public ExtensionProfile()
        {
            this.CreateMap<UpdateExtensionRequest, Extension>()
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.SerialNumber, y => y.MapFrom(z => z.SerialNumber));

            this.CreateMap<AddExtensionRequest, Extension>()
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.SerialNumber, y => y.MapFrom(z => z.SerialNumber));

            this.CreateMap<OfficePrinterAssistant.DataAccess.Entities.Extension, ExtensionDto>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.SerialNumber, y => y.MapFrom(z => z.SerialNumber));
        }
    }
}
