using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Identity;
using WebApi2.Data;

namespace WebApi2.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ScrapManagerController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly ILogger<ScrapManagerController> _logger;
        private readonly ScrapOnlineContext _dbContext;
        public ScrapManagerController(UserManager<ApplicationUser> userManager, ILogger<ScrapManagerController> logger, ScrapOnlineContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
            this._userManager = userManager;
        }

        [HttpGet]
        public async Task<List<ScrapCategories>> Get()
        {
            List<ScrapCategories> lstObj = await _dbContext.ScrapCategories.ToListAsync();
            return lstObj;
        }

        [HttpPost]
        [Authorize]
        public async void Create()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
        }
    }
}
