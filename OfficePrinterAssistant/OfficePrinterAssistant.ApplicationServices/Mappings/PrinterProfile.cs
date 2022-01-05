using AutoMapper;
using OfficePrinterAssistant.ApplicationServices.API.Domain;
using OfficePrinterAssistant.ApplicationServices.API.Domain.PrinterRequests;
using OfficePrinterAssistant.DataAccess.Entities;

namespace OfficePrinterAssistant.ApplicationServices.API.Mappings
{
    public class PrinterProfile : Profile
    {
        public PrinterProfile()
        {
            this.CreateMap<UpdatePrinterRequest, DataAccess.Entities.Printer>()
                .ForMember(x => x.Mark, y => y.MapFrom(z => z.Mark))
                .ForMember(x => x.Model, y => y.MapFrom(z => z.Model))
                .ForMember(x => x.SerialNumber, y => y.MapFrom(z => z.SerialNumber))
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId));

            this.CreateMap<AddPrinterRequest, DataAccess.Entities.Printer>()
                .ForMember(x => x.Mark, y => y.MapFrom(z => z.Mark))
                .ForMember(x => x.Model, y => y.MapFrom(z => z.Model))
                .ForMember(x => x.SerialNumber, y => y.MapFrom(z => z.SerialNumber))
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId));

            this.CreateMap<Printer, OfficePrinterAssistant.ApplicationServices.API.Domain.Models.PrinterDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Mark, y => y.MapFrom(z => z.Mark))
                .ForMember(x => x.Model, y => y.MapFrom(z => z.Model));

        }
    }
}
