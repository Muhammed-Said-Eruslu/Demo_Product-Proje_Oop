using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product1.Controllers
{
    public class JobController : Controller
    {
        JobManager jobManager = new JobManager(new EfJobDal()); // ıs katmanını kullanmak ıcın ve t olarak sınıf alır
        public IActionResult Index()
        {
            // bu actıon urunlerı lısteler ve lıstelediklerini view a yanı ındexcshtml e gonderırır
            var values = jobManager.TGetList();
            return View(values);
        }
        [HttpGet] // ürün ekleme formunu gostermek ıcın yanı kullanıcıdan bılgı alınacak formu gostermek ıcın calısır bır ıslem yapmaz
        public IActionResult AddJob()
        {
            return View();
        }
        [HttpPost] // gonderme ıslemı kullanıcı formu doldurup gonderdiğinde bu metot calısır
        public IActionResult AddJob(Job p)
        {

            jobManager.TInsert(p); // Product tablosuna p dekı değeri ekler 
            return RedirectToAction("Index"); // ve urunlerın listelendiği ındexe gider
        }
        public IActionResult DeleteJob(int id) // ıd ye gore sılme ıslemı
        {
            var value = jobManager.GetById(id); // ıd sı bu metot ıle bulunur
            jobManager.TDelete(value); // value ye atanmıs adı sılınır
            return RedirectToAction("Index"); // ve tekrar ındex sayfasına yonlendırır
        }
        [HttpGet] // bır tıklama ıslemı oldugunda 
        public IActionResult UpdateJob(int id)
        {
            var value = jobManager.GetById(id); // productManager'dan GetById metodunu kullanarak ıd den gelen değeri alır ve update producta aktrılır
            return View(value);
        }
        [HttpPost] // bir form ıstedıgı oldugunda calısır
        public IActionResult UpdateJob(Job p)
        {
            jobManager.TUpdate(p); // p den gelen değeri gunceller
            return RedirectToAction("Index"); // kullanıcı updateProductan sonra guncellemeye basınca ındex sayfasına yonlendırır baska bır actıon a yonlendırır
        }
    }
}
