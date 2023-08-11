using AutoMapper;
using Lendr.API.DTO.Borrower;
using Lendr.API.DTO.CivilStatus;
using Lendr.API.Models;

namespace Lendr.API.Configuration
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<CivilStatus,CreateCivilStatusDto>().ReverseMap();
            CreateMap<CivilStatus,GetCivilStatusesDto>().ReverseMap();
            CreateMap<CivilStatus, CivilStatusDto>().ReverseMap();
            CreateMap<CivilStatus, UpdateCivilStatusDto>().ReverseMap();
            CreateMap<Borrower, BorrowerDto>().ReverseMap();
        }
    }
}
