using AutoMapper;

namespace SE.Mappings
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<DTO.DestinationDTO, Models.Destination>().ReverseMap();
        }
    }
}