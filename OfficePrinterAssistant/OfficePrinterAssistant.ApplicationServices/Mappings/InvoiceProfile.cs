using AutoMapper;
using OfficePrinterAssistant.ApplicationServices.API.Domain.InvoiceRequests;
using OfficePrinterAssistant.ApplicationServices.API.Domain.Models;
using OfficePrinterAssistant.DataAccess.Entities;

namespace OfficePrinterAssistant.ApplicationServices.Mappings
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            this.CreateMap<UpdateInvoiceRequest, Invoice>()
              .ForMember(x => x.CreateDate, y => y.MapFrom(z => z.CreateDate))
              .ForMember(x => x.PaymentDate, y => y.MapFrom(z => z.PaymentDate))
              .ForMember(x => x.PaymentMethod, y => y.MapFrom(z => z.PaymentMethod));

            this.CreateMap<AddInvoiceRequest, Invoice>()
                .ForMember(x => x.CreateDate, y => y.MapFrom(z => z.CreateDate))
                .ForMember(x => x.PaymentDate, y => y.MapFrom(z => z.PaymentDate))
                .ForMember(x => x.PaymentMethod, y => y.MapFrom(z => z.PaymentMethod));

            this.CreateMap<Invoice, InvoiceDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.CreateDate, y => y.MapFrom(z => z.CreateDate))
                .ForMember(x => x.PaymentDate, y => y.MapFrom(z => z.PaymentDate))
                .ForMember(x => x.PaymentMethod, y => y.MapFrom(z => z.PaymentMethod))
                .ForMember(x => x.InvoiceDetailsList, y => y.MapFrom(z => z.InvoiceDetails));
        }
    }
}
