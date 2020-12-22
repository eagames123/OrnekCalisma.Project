using OrnekCalisma.Core;

namespace OrnekCalisma.Project.Entites.Concrete
{
    public class SepetUrun:IEntity
    {
        public int Id { get; set; }
        public int SepetId { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }
    }
}
