namespace Proje_OOP.Entity
{
    public class Catogory
    {
        public int Id { get; set; } // bu bır propertydır
        // neden kullanılır verılerın dogrudan erişimi sınırlar daha güvenli hale getirir
        // sadece gerekli olan bilgilerin dışarı cıkmasına olanak tanır
        public string CatogeryName { get; set; }
    }
}
