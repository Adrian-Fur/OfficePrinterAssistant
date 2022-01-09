using AutoMapper;
using OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceDetailsRequests;
using OfficePrinterAssistant.DataAccess.Entities;

namespace OfficePrinterAssistant.ApplicationServices.Mappings
{
    public class InvoiceDetailsProfile : Profile
    {
        public InvoiceDetailsProfile()
        {
            this.CreateMap<UpdateInvoiceDetailsRequest, DataAccess.Entities.InvoiceDetails>()
               .ForMember(x => x.PrinterFee, y => y.MapFrom(z => z.PrinterFee))
               .ForMember(x => x.ExtensionsFee, y => y.MapFrom(z => z.ExtensionsFee))
               .ForMember(x => x.SoftwareFee, y => y.MapFrom(z => z.SoftwareFee));

            this.CreateMap<AddInvoiceDetailsRequest, DataAccess.Entities.InvoiceDetails>()
                .ForMember(x => x.PrinterFee, y => y.MapFrom(z => z.PrinterFee))
                .ForMember(x => x.ExtensionsFee, y => y.MapFrom(z => z.ExtensionsFee))
                .ForMember(x => x.SoftwareFee, y => y.MapFrom(z => z.SoftwareFee));

            this.CreateMap<InvoiceDetails, OfficePrinterAssistant.ApplicationServices.API.Domain.Models.InvoiceDetailsDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.PrinterFee, y => y.MapFrom(z => z.PrinterFee))
                .ForMember(x => x.ExtensionsFee, y => y.MapFrom(z => z.ExtensionsFee))
                .ForMember(x => x.SoftwareFee, y => y.MapFrom(z => z.SoftwareFee));
        }
    }
}
