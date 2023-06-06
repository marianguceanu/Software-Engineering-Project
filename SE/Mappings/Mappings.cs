using AutoMapper;

namespace SE.Mappings
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<DTO.Destination.DestinationDTO, Models.Destination>().ReverseMap();
            CreateMap<DTO.User.AddLoginDTO, Models.User>().ReverseMap();
            CreateMap<DTO.User.AdminDestinationDTO, Models.Destination>().ReverseMap();
        }
    }
}