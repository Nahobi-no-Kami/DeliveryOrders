using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DeliveryOrders.Pages
{

    
    public class OrdersModel : PageModel
    {
  

        private readonly ILogger<OrdersModel> _logger;

        public OrdersModel(ILogger<OrdersModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder
            .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ordersappdb;Trusted_Connection=True;")
            .Options;

            using (ApplicationContext context = new ApplicationContext(options))
            {
                List<OrderTable> listOfOrders = new List<OrderTable>();
                foreach (var data in context.Orders)
                {
                    listOfOrders.Add(data);
                }
                ViewData["listOfOrders"] = listOfOrders;
            }
        }
    }
}
