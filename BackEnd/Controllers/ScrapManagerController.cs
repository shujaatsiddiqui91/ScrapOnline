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
using System.Linq;

namespace WebApi2.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ScrapManagerController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly ILogger<ScrapManagerController> _logger;
        private ScrapOnlineContext _dbContext;
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
        [Authorize(Policy = "RequireCustomerRole")]
        public async Task Create(OrderDetailsDTO obj)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            _dbContext = new ScrapOnlineContext();
            Clientorders coObj = new Clientorders() { Orderid =  new Random().Next(500,1000).ToString() + new Random().Next(1,500).ToString(), Status = 1, Userid = user.Id, Createdate = DateTime.Now };
            _dbContext.Clientorders.Add(coObj);
            if (coObj != null)
            {
                foreach (var item in obj.orderDetails)
                {
                    OrderDetails d = new OrderDetails();
                    d.Categoryid = item.categoryid;
                    d.OrderId = coObj.Orderid;
                    d.Quantity = item.quantity;
                    _dbContext.OrderDetails.Add(d);
                }
                _dbContext.SaveChanges();
            }
            else
                _dbContext.Dispose();
        }

        [HttpGet]
        [Authorize(Policy = "RequireCustomerRole")]
        public async Task<Object> GetOrdersList()
        {
            return null;
            // var user = await _userManager.GetUserAsync(HttpContext.User);
            // return _dbContext.Clientorders.Include(x => x.OrderDetails).
            //         Where(x => x.User == user).
            //         Select(x => x).ToList();
            // if (query != null)
            // {
            //     obj.orderid = int.Parse(query.First().Orderid);
            //     obj.createdate = Convert.ToDateTime(query.First().Createdate);
            //     foreach (var item in query.First().OrderDetails)
            //     {
            //         OrderDetail detailObj = new OrderDetail();
            //         detailObj.categoryid = 

            //     }

            //}
        }
    }
}
