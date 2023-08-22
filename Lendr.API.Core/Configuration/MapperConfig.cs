using AutoMapper;
using Lendr.API.Data;
using Lendr.API.Core.DTO.Borrower;
using Lendr.API.Core.DTO.CivilStatus;
using Lendr.API.Core.DTO.User;
using Lendr.API.Core.Models;

namespace Lendr.API.Core.Configuration
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
            CreateMap<Borrower, GetBorrowerDto>().ReverseMap();
            CreateMap<Borrower, CreateBorrowerDto>().ReverseMap();
            CreateMap<ApiUser,ApiUserDto>().ReverseMap();
        }
    }
}
