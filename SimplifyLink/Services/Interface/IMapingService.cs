using AutoMapper.QueryableExtensions;
using AutoMapper;
using SimplifyLink.Domain.Entities;
using SimplifyLink.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifyLink.Services.Interface
{
    public interface IMapingService
    {
        public IQueryable<LinkViewModel> GetLinkViews(IQueryable<LinkModel> Links);
    }
}
