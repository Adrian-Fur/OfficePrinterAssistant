using AutoMapper;
using OfficePrinterAssistant.ApplicationServices.API.Domain.UserRequests;
using OfficePrinterAssistant.DataAccess.Entities;

namespace OfficePrinterAssistant.ApplicationServices.API.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            this.CreateMap<UpdateUserRequest, DataAccess.Entities.User>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
                .ForMember(x => x.Password, y => y.MapFrom(z => z.Password));

            this.CreateMap<AddUserRequest, DataAccess.Entities.User>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
                .ForMember(x => x.Password, y =>y.MapFrom(z => z.Password));

            this.CreateMap<User, OfficePrinterAssistant.ApplicationServices.API.Domain.Models.UserDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
                .ForMember(x => x.Printers, y => y.MapFrom(z => z.PrintersList));

        }
    }
}
