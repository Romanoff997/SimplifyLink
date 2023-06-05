using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SimplifyLink.Domain.Entities;
using SimplifyLink.Domain.Repositories;
using SimplifyLink.Models;
using SimplifyLink.Services.Interface;
using SimplifyLink.Services;
using SimplifyLink.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace SimplifyLink.Controllers
{
    public class LinksItemController: Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly DataManager _dataManager;
        private readonly IMapingService _mapper;
        private readonly IShortUrlService _shorter;
        public LinksItemController(UserManager<IdentityUser> userManager, DataManager dataManager, MappingServiceNative mapper)
        {
            _userManager = userManager;
            _dataManager = dataManager;
            _mapper = mapper;
            _shorter = new ShortUrlServiceNative();
        }


        [HttpGet]
        public IActionResult Index()
        {
            var userId = Guid.Parse(_userManager.GetUserId(User));
            IQueryable<LinkModel> Links = _dataManager.LinkRepository.GetLinks(userId);
            IQueryable<LinkViewModel> LinksView = _mapper.GetLinkViews(Links);//_mapper.Map<LinkViewModel>(Links); 
            List<LinkViewModel> mass = LinksView.ToList();
            return View(LinksView);

        }
        [HttpPost]
        public IActionResult Index(IQueryable<LinkViewModel> LinksView)
        {
            return View(LinksView);
        }
        [HttpPost]
        public async Task<IActionResult> AddLink (IFormCollection form)
        {
            var userId = Guid.Parse(_userManager.GetUserId(User));
            string longurl = form["message"];
             string result = "";
            await _shorter.GetShortUrl( (url) =>
            {
                _dataManager.LinkRepository.AddLink(userId, longurl, url);
                 RedirectToAction("Index");
            }, longurl);
            //var aaf = CreateDynamicLink(df);
            //_dataManager.LinkRepository.AddLink(userId, link.Url, link.MinUrl);
            return RedirectToAction("Index");

        }
        [HttpPost]
        public async Task<IActionResult> UpTiсket (IFormCollection form)
        {
            Guid id = Guid.Parse(form["IdLink"]);
            var userId = Guid.Parse(_userManager.GetUserId(User));
            if(id!=null)
                await _dataManager.LinkRepository.UpTicket(id);

            return RedirectToAction("Index");

        }

    }
}
