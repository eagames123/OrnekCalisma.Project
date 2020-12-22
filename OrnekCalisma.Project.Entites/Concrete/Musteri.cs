using OrnekCalisma.Core;

namespace OrnekCalisma.Project.Entites.Concrete
{
    public class Musteri:IEntity
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Sehir { get; set; }
    }
}
