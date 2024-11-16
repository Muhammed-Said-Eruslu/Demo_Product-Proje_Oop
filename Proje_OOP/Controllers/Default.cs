using Microsoft.AspNetCore.Mvc;
using Proje_OOP.Örnekler;

namespace Proje_OOP.Controllers
{

    public class Default : Controller // Controller sınıfından miras almış
    {
        void mesajlar() // mesajlar kısmı bırden fazla noktada yer alabilir
        {
            ViewBag.m1 = "Merhaba bu bir core projesı"; // ViewBag sayfaya yazdırır m1 de sağdakı değeri tutar
            ViewBag.m2 = "merhaba proje cok ıyı duruyor";
            ViewBag.m3 = "selamler";
        }
        int Topla() // basta erişim belirleyicisi vermedim default olarak private kup kilitli gozulur
        {
            int s1 = 20;
            int s2 = 30;
            int sonuc = s1 + s2;
            return sonuc; // void olmadığı için değer döndürmesi gerekir bi şekılde o değer donucek
        }
        int Cevre()
        {
            int kısa = 10;
            int uzun = 20;
            int c = 2 * (kısa + uzun);
            return c;
        }
        int Faktoriyel(int n)
        {
            int sonuc = 1;


            for (int i = 1; i <= n; i++)
            {
                sonuc *= i;
            }
            return sonuc;
        }
        string Cumle() // geriye değer donduren metotlarda gelen değeri değişkene atayabılırım
                       // ve tekrar kullana bılırım ama değer dondurmeyenlede olmaz
        {
            string c = "Said";
            return c;
        }
        void MesajListesi(string p)
        {
            ViewBag.v = p; // Console.WrilteLine'a benzer
        }
        void Kullanıcı(string userName)
        {
            ViewBag.k = userName;
        }
        int Topla(int sayı1, int sayı2)
        {
            int sonuc = sayı1 + sayı2;
            return sonuc;
        }
        long Faktoriyel(long n)
        {
            int f = 1;
            for (int i = 1; i <= n; i++)
            {
                f *= i;
            }
            return f;
        }
        public IActionResult Index() // IActionResult view gorunum dondurur
        {
            mesajlar(); // mesajları metot uzerinden çağırdım
            MesajListesi("Muhammed"); // bu metoda view bag kullanlımamasının sebebi bir değeri var yanı
            // parametresi var
            Kullanıcı("Eruslu");
            ViewBag.c = Topla(10, 20);
            return View();
        }
        public IActionResult Urunler()
        {
            mesajlar();
            ViewBag.t = Topla(); // view bag konrolör sırasında veri taşımak için kullanılrı
            // dinamik bir şekilde
            ViewBag.c = Cevre();
            ViewBag.f = Faktoriyel(5);
            Kullanıcı("Eruslu");
            ViewBag.fak2 = Faktoriyel(10);
            return View();

        }
        public IActionResult Musteriler()
        {
            ViewBag.g = Cumle();
            Kullanıcı("Eruslu");
            return View();
        }
        public IActionResult Deneme() // buna view ozellıgı eklersem parametre ısmını alır yanı deneme
        {
            Sehıler sehıler = new Sehıler(); // sehırler sınıfından nesne türettim
            sehıler.Ad = "Afyon"; // nesne aracılıyla propertylere değer atamsı yaptım
            sehıler.ID = 1;
            sehıler.Nufüs = 75000;
            sehıler.Ulke = "Türkyie";
            sehıler.Renk1 = "Kırmızı";
            sehıler.Renk2 = "Beyaz";
            ViewBag.v1 = sehıler.ID;
            ViewBag.v2 = sehıler.Ulke;
            ViewBag.v3 = sehıler.Ad; // ekrana yazdrımak ıcın
            ViewBag.v4 = sehıler.Nufüs;
            ViewBag.v5 = sehıler.Renk1;
            ViewBag.v6 = sehıler.Renk2;
            sehıler.ID = 2;
            sehıler.Ad = "İstabul";
            sehıler.Ulke = "Türkiye";
            sehıler.Nufüs = 14000000;
            sehıler.Renk1 = "Kırmızı";
            sehıler.Renk2 = "Beyaz";
            ViewBag.z1 = sehıler.ID;
            ViewBag.z2 = sehıler.Ulke;
            ViewBag.z3 = sehıler.Ad;
            ViewBag.z4 = sehıler.Nufüs;
            ViewBag.v5 = sehıler.Renk1;
            ViewBag.v6 = sehıler.Renk2;



            return View(); // geriye view döndürdüm
        }
    }
}
