using DataAccessLayer.CustomerDbContext;
using ModelAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Interfaces
{
    public interface ICustomerServices
    {
        List<Customer> GetCustomers();
        bool AddCustomer(CustomerModel customerModel);
        Customer GetById(int Id);
        bool UpdateCustomer(CustomerModel customerModel);
        bool DeleteCustomer(int Id);
    }
}
