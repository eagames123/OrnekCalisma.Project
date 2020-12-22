using System.Collections.Generic;
using OrnekCalisma.Project.DTO;

namespace OrnekCalisma.Core
{
    public interface IDbOrnekConnection
    {
        int Add(MusteriDTO musteriDto);

        int AddSepet(SepetDTO sepetDto);

        int AddSepetUrun(SepetUrunDTO speteUrunDto);
        
        List<MusteriDTO> GetList();

        List<SepetDTO> GetListSepet();
        
        List<SepetUrunDTO> GetListSepetUrun();

        List<MusteriDTO> GetLastItems(int deger);
        
    }
}
