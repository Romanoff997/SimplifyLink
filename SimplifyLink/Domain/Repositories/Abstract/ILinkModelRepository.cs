using System;
using System.Linq;
using SimplifyLink.Domain.Entities;

namespace SimplifyLink.Domain.Repositories.Abstract
{
    public interface ILinkModelRepository
    {
        IQueryable<LinkModel> GetLinks (Guid UserId);
        Task AddLink(Guid userId, string link, string miniLink);
        Task UpTicket(Guid urlId);
    }
}
