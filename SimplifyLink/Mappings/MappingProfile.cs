using AutoMapper;
using SimplifyLink.Domain.Entities;
using SimplifyLink.Models;

namespace SimplifyLink.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap <IQueryable<LinkViewModel>, IQueryable<LinkModel> >();
            CreateMap <LinkModel, LinkViewModel>();
        }
    }
}
