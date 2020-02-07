using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        //data
        static List<Customer> cust = new List<Customer>()
        {
            new Customer{Name = "Mark shantiwell", Id = 1},
            new Customer{Name = "Peter Msimane", Id = 2}
        };
        CustomerViewModel customer = new CustomerViewModel()
        {
            Custom = cust
        };

        // GET: Customers
        public ActionResult Customers()
        {
           
            return View(customer);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
        
            var custom = customer.Custom.Find(x => x.Id == id);
            return View(custom);

        }

       
    }
}
