using AutoMapper;
using OfficePrinterAssistant.ApplicationServices.API.Domain.Models;

namespace OfficePrinterAssistant.ApplicationServices.Mappings
{
    public class SoftwareProfile : Profile
    {
        public SoftwareProfile()
        {
            this.CreateMap<OfficePrinterAssistant.DataAccess.Entities.Software, SoftwareDto> ()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.LicenseNumber, y => y.MapFrom(z => z.LicenseNumber))
            .ForMember(x => x.PrinterId, y => y.MapFrom(z => z.LicenseNumber));
        }

    }
}
