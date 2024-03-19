using webapi.Models.Domain;
using webapi.Models.DTO;
using Ticket = webapi.Models.Domain.Ticket;
using AutoMapper;

namespace webapi.Mappings
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles() //transform objects DTO to Domain and vice and versa
        {
            CreateMap<Ticket, TicketDto>().ReverseMap();
            CreateMap<CreateTicketDto, Ticket>().ReverseMap();
            CreateMap<Result, ResultDto>().ReverseMap();
            CreateMap<TicketRandomDto, Ticket>().ReverseMap();
        }
    }
}
