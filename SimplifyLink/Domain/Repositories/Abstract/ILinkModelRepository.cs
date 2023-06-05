using System;
using System.Linq;
using SimplifyLink.Domain.Entities;

namespace SimplifyLink.Domain.Repositories.Abstract
{
    public interface ILinkModelRepository
    {
        Task<IEnumerable<LinkModel>> GetLinksAsync(Guid UserId);
        Task AddLinkAsync(Guid userId, string link, string miniLink);
        Task UpTicketAsync(Guid urlId);
    }
}
