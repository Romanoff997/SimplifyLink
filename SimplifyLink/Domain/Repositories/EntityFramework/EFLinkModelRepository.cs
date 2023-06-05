using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimplifyLink.Domain.Repositories.Abstract;
using SimplifyLink.Domain.Entities;
using static Google.Rpc.Help.Types;
using System.Net.Sockets;

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
            return context.LinkEntity.Where(x=>x.UserId==id);
        }

        public async Task AddLink(Guid userId, string link, string miniLink)
        {
            await context.LinkEntity.AddAsync(new LinkModel() { UserId = userId, Url = link, MinUrl = miniLink });
            context.SaveChanges();
        }

        public async Task UpTicket( Guid urlId)
        {
            LinkModel currLink = await context.LinkEntity.FirstOrDefaultAsync(x => x.Id == urlId);
            currLink.Ticket++;
            context.LinkEntity.Update(currLink);
            await context.SaveChangesAsync();
        }

    }
}
