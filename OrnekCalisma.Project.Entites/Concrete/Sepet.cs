using System;
using OrnekCalisma.Core;

namespace OrnekCalisma.Project.Entites.Concrete
{
    public class Sepet:IEntity
    {
        public int Id { get; set; }
        public int MusteriId { get; set; }
        public DateTime Tarih { get; set; }
    }
}
