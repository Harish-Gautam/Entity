using BussinessAccessLayer.Implimantation;
using BussinessAccessLayer.Interfaces;
using DataAccessLayer.CustomerDbContext;
using ModelAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerServices _icustomerServices;
        public HomeController()
        {
            _icustomerServices = new CustomerServices();
        }
        public HomeController(ICustomerServices icustomerservices)
        {
            _icustomerServices = icustomerservices;
        }
        public ActionResult Index()
        {
            var result = _icustomerServices.GetCustomers();
            if (result != null)
            {
                return View(result);
            }
            else
            {
                ViewBag.errerMassage = "Record not faund !!";
                return View(ViewBag.errerMassage);
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CustomerModel model)
        {
            bool check = _icustomerServices.AddCustomer(model);
            if (check)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Massage = "Your data is not inserted";
                return View(ViewBag.Massage);
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _icustomerServices.GetById(id);
            if (data != null)
            {
                return View(data);
            }
            else
            {
                ViewBag.Massage = "Record not faund";
                return View();
            }
        }
        [HttpPost]
        public ActionResult Edit(CustomerModel customerModel)
        {
                
                if (_icustomerServices.UpdateCustomer(customerModel))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Massage = "data has been not updated";
                }
            
            return View();
        }
        public ActionResult Delete(int Id)
        {
            var data = _icustomerServices.DeleteCustomer(Id);
            if (data != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.massage = "Recor has been not exist";
                return View();
            }
        }
    }

}