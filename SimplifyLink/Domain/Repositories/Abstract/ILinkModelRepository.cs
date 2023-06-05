using System;
using System.Linq;
using SimplifyLink.Domain.Entities;

namespace SimplifyLink.Domain.Repositories.Abstract
{
    public interface ILinkModelRepository
    {
        IQueryable<LinkModel> GetLinks (Guid UserId);
        void AddLink(Guid userId, string link, string miniLink);
    }
}
