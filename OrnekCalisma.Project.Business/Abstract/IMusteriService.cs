using System.Collections.Generic;
using OrnekCalisma.Project.DTO;

namespace OrnekCalisma.Project.Business.Abstract
{
    public interface IMusteriService
    {
        int AddMusteri(MusteriDTO musteriDTO);
        
        List<MusteriDTO> LastItem(int deger);
    }
}
