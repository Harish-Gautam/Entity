using BussinessAccessLayer.Interfaces;
using DataAccessLayer.CustomerDbContext;
using ModelAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Implimantation
{
    public class CustomerServices : ICustomerServices
    {
        Customer_ManagementEntities db = new Customer_ManagementEntities();

        public bool AddCustomer(CustomerModel customerModel)
        {
            Customer customer = new Customer();
            customer.Name = customerModel.Name;
            customer.Phone = customerModel.Phone;
            customer.Salary = customerModel.Salary;
            customer.City = customerModel.City;
            db.Customers.Add(customer);
            int result = db.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;   
            }

        }

        public bool DeleteCustomer(int Id)
        {
            var data = db.Customers.Where(model => model.Id == Id).FirstOrDefault();
            if (data != null)
            {
                db.Customers.Remove(data);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Customer GetById(int Id)
        {
            var result = db.Customers.Where(model => model.Id == Id).FirstOrDefault();
            Customer customer = new Customer();
            if (result != null)
            {
                customer.Id = result.Id;
                customer.Name = result.Name;
                customer.Phone = result.Phone;
                customer.Salary = result.Salary;
                customer.City = result.City;
            }
            return customer;

        }

        public List<Customer> GetCustomers()
        {

            var result = db.Customers.ToList();
            return result;

        }

        public bool UpdateCustomer(CustomerModel customerModel)
        {
            Customer customer = new Customer();
            customer.Id = customerModel.Id;
            customer.Name = customerModel.Name;
            customer.Salary = customerModel.Salary;
            customer.City = customerModel.City;
            customer.Phone = customerModel.Phone;
           
            if (customer !=null)
            {
                db.Entry(customer).State = EntityState.Modified;
                int result = db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            }
        }
}
