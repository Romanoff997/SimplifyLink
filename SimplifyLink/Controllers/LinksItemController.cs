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

namespace SimplifyLink.Controllers
{
    public class LinksItemController: Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly DataManager _dataManager;
        private readonly IMapingService _mapper;
        private static readonly string _projectId = "your-project-id";
        //https://example.page.link/summer-sale
        private static readonly string PackageName = "https://example.page.link/summer-sale"; // Замените на имя пакета вашего приложения Android
        public LinksItemController(UserManager<IdentityUser> userManager, DataManager dataManager, MappingServiceNative mapper)
        {
            _userManager = userManager;
            _dataManager = dataManager;
            _mapper = mapper;
        }

        [HttpPost]
        public string CreateDynamicLink(string url)
        {



            var dynamicLink = new DynamicLink(link, PackageName)
            {
                AndroidInfo = _projectId,
            };

            var shortLink = dynamicLink.GetShortLinkAsync().Result;

            return shortLink.ToString();
        }


        [HttpGet]
        public IActionResult Index()
        {
            var userId = Guid.Parse(_userManager.GetUserId(User));
            IQueryable<LinkModel> Links = _dataManager.LinkRepository.GetLinks(userId);
            IQueryable<LinkViewModel> LinksView = _mapper.GetLinkViews(Links);//_mapper.Map<LinkViewModel>(Links); 
            return View(LinksView);

        }
        [HttpPost]
        public IActionResult Index(IQueryable<LinkViewModel> LinksView)
        {
            return View(LinksView);
        }
        [HttpPost]
        public IActionResult AddLink (IFormCollection form)
        {
            var userId = Guid.Parse(_userManager.GetUserId(User));
            string df = form["message"];
            var aaf = CreateDynamicLink(df);
            //_dataManager.LinkRepository.AddLink(userId, link.Url, link.MinUrl);
            return RedirectToAction("Index");

        }

    }
}
