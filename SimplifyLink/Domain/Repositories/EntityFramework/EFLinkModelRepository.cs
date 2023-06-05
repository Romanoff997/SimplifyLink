using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimplifyLink.Domain.Repositories.Abstract;
using SimplifyLink.Domain.Entities;

namespace SimplifyLink.Domain.Repositories.EntityFramework
{
    public class EFLinkModelRepository : ILinkModelRepository
    {
        private readonly MyDbContext context;
        public EFLinkModelRepository(MyDbContext context)
        {
            this.context = context;
        }

        public IQueryable<LinkModel> GetLinks(Guid id)
        {
            return context.LinkEntity.Where(x=>x.Id==id);
        }

        public void AddLink(Guid userId, string link, string miniLink)
        {
            context.LinkEntity.AddAsync(new LinkModel() { UserId = userId, Url = link, MinUrl = miniLink });
            context.SaveChanges();
        }

    }
}
