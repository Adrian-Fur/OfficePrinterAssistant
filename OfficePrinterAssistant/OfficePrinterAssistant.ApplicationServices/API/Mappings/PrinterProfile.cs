using AutoMapper;
using OfficePrinterAssistant.ApplicationServices.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.ApplicationServices.API.Mappings
{
    public class PrinterProfile : Profile
    {
        public PrinterProfile()
        {
            this.CreateMap<OfficePrinterAssistant.DataAccess.Entities.Printer, Printer>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Mark, y => y.MapFrom(z => z.Mark))
                .ForMember(x => x.Model, y => y.MapFrom(z => z.Model));
        }
    }
}
