using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplifyLink.Domain.Repositories.Abstract;
using SimplifyLink.Domain.Repositories.EntityFramework;

namespace SimplifyLink.Domain.Repositories
{
    public class DataManager
    {
        public ILinkModelRepository LinkRepository { get; set; }

        public DataManager(ILinkModelRepository linkRepository)
        {
            LinkRepository = linkRepository;
        }
    }
}
