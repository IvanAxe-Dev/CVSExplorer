using AutoMapper;
using CSVExplorer.Core.Domain.Entities;
using CSVExplorer.Core.DTOs;

namespace CSVExplorer.Core.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.ToDateTime(TimeOnly.MinValue)));

            CreateMap<UserDto, User>()
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.DateOfBirth)));

            CreateMap<User, UserResponseDto>();
            CreateMap<UserResponseDto, User>();
        }
    }
}