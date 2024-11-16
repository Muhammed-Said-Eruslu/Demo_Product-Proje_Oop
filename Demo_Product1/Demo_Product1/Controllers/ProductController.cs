using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Demo_Product1.Controllers
{
    public class ProductController : Controller
    {
        ProductManager productManager = new ProductManager(new EfProductDal()); // ıs katmanını kullanmak ıcın ve t olarak sınıf alır
        public IActionResult Index()
        {
            // bu actıon urunlerı lısteler ve lıstelediklerini view a yanı ındexcshtml e gonderırır
            var values = productManager.TGetList(); 
            return View(values);
        }
        [HttpGet] // ürün ekleme formunu gostermek ıcın yanı kullanıcıdan bılgı alınacak formu gostermek ıcın calısır bır ıslem yapmaz
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost] // gonderme ıslemı kullanıcı formu doldurup gonderdiğinde bu metot calısır
        public IActionResult AddProduct(Product p)
        {
            ProductValidator validationRules = new ProductValidator(); //ProductValidator sınıfı kullanılarak yenı bır kural olsururuz
            FluentValidation.Results.ValidationResult result1 = validationRules.Validate(p); // kontrol yapılacak sınıfının nesnesi verilir
            if(result1.IsValid) // ısValid yanı kontrol dogruysa
            { 
            productManager.TInsert(p); // Product tablosuna p dekı değeri ekler 
            return RedirectToAction("Index"); // ve urunlerın listelendiği ındexe gider
            }
            else
            {
              foreach(var item in result1.Errors) // gecerlı değilse alınacak mesajlar
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }        
        public IActionResult DeleteProduct(int id) // ıd ye gore sılme ıslemı
        {
            var value = productManager.GetById(id); // ıd sı bu metot ıle bulunur
            productManager.TDelete(value); // value ye atanmıs adı sılınır
            return RedirectToAction("Index"); // ve tekrar ındex sayfasına yonlendırır
        }
        [HttpGet] // bır tıklama ıslemı oldugunda 
        public IActionResult UpdateProduct(int id)
        {
            var value = productManager.GetById(id); // productManager'dan GetById metodunu kullanarak ıd den gelen değeri alır ve update producta aktrılır
            return View(value);
        }
        [HttpPost] // bir form ıstedıgı oldugunda calısır
        public IActionResult UpdateProduct(Product p)
        {
            productManager.TUpdate(p); // p den gelen değeri gunceller
            return RedirectToAction("Index"); // kullanıcı updateProductan sonra guncellemeye basınca ındex sayfasına yonlendırır baska bır actıon a yonlendırır
        }
    }
}
