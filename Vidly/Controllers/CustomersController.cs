using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Services.Description;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
       
        private readonly VidlyDbContext _vidlyDbContext;
        public CustomersController()
        {
            _vidlyDbContext = new VidlyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _vidlyDbContext.Dispose();
        }

        // GET: Index
        public ActionResult Index()
        {
            var customerviewmodel = new CustomerViewModel
            {
                Custom = _vidlyDbContext.Customers.Include(c=>c.MembershipType).ToList()
            };
            
            return View(customerviewmodel);
        }

        // GET: Index/Details/5
        public ActionResult Details(int id)
        {
        
            var custom = _vidlyDbContext.Customers.FirstOrDefault(c=>c.Id==id);
            if (custom == null) return HttpNotFound($"this id {id} you pass is not in the system");
            return View( custom);

        }

        private List<Customer> GetCustomers()
        {
            return new List<Customer>()
            {
                new Customer{Name = "Mark shantiwell", Id = 1},
                new Customer{Name = "Peter Msimane", Id = 2}
            };
        }
    }
}
