using AutoMapper;
using SimplifyLink.Domain.Entities;
using SimplifyLink.Models;

namespace SimplifyLink.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap <LinkModel, LinkViewModel>();
        }
    }
}
