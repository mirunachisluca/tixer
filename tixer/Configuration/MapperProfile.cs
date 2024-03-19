using AutoMapper;
using Tixer.DTOs;
using Tixer.Models;

namespace Tixer.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Ticket, TicketDto>();
            CreateMap<TicketToInsertDto, Ticket>();
            CreateMap<TicketToUpdateDto, Ticket>();
        }
    }
}
