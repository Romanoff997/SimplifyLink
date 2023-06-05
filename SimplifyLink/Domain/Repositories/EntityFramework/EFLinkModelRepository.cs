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

        public async Task<IEnumerable<LinkModel>> GetLinksAsync(Guid id)
        {
            return await context.LinkEntity.Where(x=>x.UserId==id).ToListAsync();
        }

        public async Task AddLinkAsync(Guid userId, string link, string miniLink)
        {
            await context.LinkEntity.AddAsync(new LinkModel() { UserId = userId, Url = link, MinUrl = miniLink });
            context.SaveChanges();
        }

        public async Task UpTicketAsync( Guid urlId)
        {
            LinkModel currLink = await context.LinkEntity.FirstOrDefaultAsync(x => x.Id == urlId);
            if (currLink != null)
            {
                currLink.Ticket++;
                context.LinkEntity.Update(currLink);
                await context.SaveChangesAsync();
            }
        }

    }
}
