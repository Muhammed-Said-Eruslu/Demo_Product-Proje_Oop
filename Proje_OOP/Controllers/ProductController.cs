using Microsoft.AspNetCore.Mvc;
using Proje_OOP.Entity;
using Proje_OOP.ProjeContext;

namespace Proje_OOP.Controllers
{
    public class ProductController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var values = context.Products.ToList(); // ToList ürün sınıfımda yer alan değeleri getir
            return View(values); // vaules dondur kı bunları view tarafında karşılaya bileyim
        }
        [HttpGet] // AddProduct bu metodun sayfa yuklendiği zaman calsımasını ıstıyorum 
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost] // sayfada post işlemi yapıldığı zaman bir butona tıklama gonderme işlemi yapıldığında
        public IActionResult AddProduct(Product p) // product ısımlı sınıftan p parametresi türettim
        {
            context.Add(p); // parametreden gelen değerleri kaydet
            context.SaveChanges(); // ekleme işlemi yaptıktan sonra veri tabanına kayıt eder
            return RedirectToAction("Index"); // beni bir actıon'a yonlendir ekleme işlemi yapıp ve değişlikleri kayıt ettıkten sonra benı Index'e yonlendir // => oylekı
        }
        public IActionResult DeleteProduct(int id) // ıd ye gore sılme işlemi
        {
            var value = context.Products.Where(x=> x.ID == id).FirstOrDefault(); // Where şart yazmak için kullanılan entitiy framwork şartı Id si benim dışardan gönderdiğim değer FirstOrDefault sadece bir değeri hafızaya almak için kullanılan metot
            context.Remove(value); // valueden gelen değeri sil
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var value = context.Products.Where(x=>x.ID== id).FirstOrDefault();
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product p)
        {
            var value = context.Products.Where(x => x.ID == p.ID).FirstOrDefault();
            value.Name = p.Name;
            value.Price = p.Price;
            value.Stock = p.Stock;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
