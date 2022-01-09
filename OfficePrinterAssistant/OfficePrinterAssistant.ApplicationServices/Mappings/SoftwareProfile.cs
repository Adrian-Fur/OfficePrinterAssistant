using AutoMapper;
using OfficePrinterAssistant.ApplicationServices.API.Domain.Models;
using OfficePrinterAssistant.ApplicationServices.API.Domain.SoftwareRequests;
using OfficePrinterAssistant.DataAccess.Entities;

namespace OfficePrinterAssistant.ApplicationServices.Mappings
{
    public class SoftwareProfile : Profile
    {
        public SoftwareProfile()
        {
            this.CreateMap<AddSoftwareRequest, DataAccess.Entities.Software>()
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.LicenseNumber, y => y.MapFrom(z => z.LicenseNumber))
            .ForMember(x => x.MonthlyFee, y => y.MapFrom(z => z.MonthlyFee));

            this.CreateMap<UpdateSoftwareRequest, DataAccess.Entities.Software>()
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.LicenseNumber, y => y.MapFrom(z => z.LicenseNumber))
            .ForMember(x => x.MonthlyFee, y => y.MapFrom(z => z.MonthlyFee));

            this.CreateMap<OfficePrinterAssistant.DataAccess.Entities.Software, SoftwareDto>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.LicenseNumber, y => y.MapFrom(z => z.LicenseNumber))
            .ForMember(x => x.MonthlyFee, y => y.MapFrom(z => z.MonthlyFee));
        }
    }
}
