using AutoMapper;
using Project.WebAPI.DTOs;
using Project.WebAPI.Models;

namespace Project.WebAPI.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Code, CodeDto>();
        }
    }
}
