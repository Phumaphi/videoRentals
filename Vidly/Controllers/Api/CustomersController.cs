using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using Vidly.Dtos;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private readonly VidlyDbContext _vidlyDbContext;

        public CustomersController()
        {
            var vidlyDbContext = new VidlyDbContext();
            _vidlyDbContext = vidlyDbContext;
        }
        //Get /api/customers
        public IHttpActionResult  GetCustomers()
        {

            var customers = _vidlyDbContext.Customers
                .Include(c=>c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer,CustomerDto>);
            if (customers!=null)
            {
                
                return Ok(customers);
            }

            return BadRequest("no customers at the moment!");
        }
        // Get/api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _vidlyDbContext.Customers.SingleOrDefault(c => c.Id==id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }
        //Post/api/customers
        [HttpPost]
        public IHttpActionResult PostCustomer(CustomerDto customerDto)
        {
           
            if (!ModelState.IsValid && customerDto==null)
            {
                return BadRequest();


            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _vidlyDbContext.Customers.Add(customer);
            _vidlyDbContext.SaveChanges();
            customerDto.Id = customer.Id;


            return Created(new Uri(Request.RequestUri+"/"+customer.Id), customerDto);
        }
        //put/api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var upDateCustomer = _vidlyDbContext.Customers.Single(c => c.Id == id);
            if (upDateCustomer == null)
                return BadRequest();
            Mapper.Map(customerDto, upDateCustomer);
          
            _vidlyDbContext.SaveChanges();
            return Ok();
        }
        //Delete/api/customerDto/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {

            var customer = _vidlyDbContext.Customers.Single(c => c.Id == id);
            if (customer == null)
                return BadRequest();

            _vidlyDbContext.Customers.Remove(customer);
            _vidlyDbContext.SaveChanges();
            return Ok();
        }
    }
}
