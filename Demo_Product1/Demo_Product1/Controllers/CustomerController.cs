using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product1.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        public IActionResult Index()
        {
            var values = customerManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCustomer()
        { 
            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer c)
        {
            CustomerValidator validationRules = new CustomerValidator(); //ProductValidator sınıfı kullanılarak yenı bır kural olsururuz
            FluentValidation.Results.ValidationResult result1 = validationRules.Validate(c); // kontrol yapılacak sınıfının nesnesi verilir
            if (result1.IsValid) // ısValid yanı kontrol dogruysa
            {
                customerManager.TInsert(c);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result1.Errors) // gecerlı değilse alınacak mesajlar
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult DeleteCustomer(int id)
        {
            var value = customerManager.GetById(id);
            customerManager.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            var value = customerManager.GetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateCustomer(Customer c)
        {
            customerManager.TUpdate(c);
            return RedirectToAction("Index");
        }
    }
}
