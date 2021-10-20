using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.EntityFrameworkCore;

namespace DeliveryOrders.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            ViewData["orderNumber"] = 0;
        }

        public void OnPost()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder
                   .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ordersappdb;Trusted_Connection=True;")
                   .Options;
            using (ApplicationContext context = new ApplicationContext(options))
            {

                OrderTable table = new OrderTable
                {
                    SenderCity = Request.Form["senderCity"],
                    SenderAdress = Request.Form["senderAdress"],
                    RecieverCity = Request.Form["recipientCity"],
                    RecieverAdress = Request.Form["recipientAdress"],
                    Weight = Convert.ToDouble(Request.Form["weight"]),
                    Date = Convert.ToDateTime(Request.Form["date"])
                };
                context.Orders.Add(table);
                context.SaveChanges();
                ViewData["orderNumber"] = table.Id;
            }
        }
    }
}
