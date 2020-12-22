using System.Collections.Generic;
using OrnekCalisma.Project.DTO;

namespace OrnekCalisma.Project.Business.Abstract
{
    public interface ISepetUrunService
    {
        int AddSepetUrun(SepetUrunDTO sepetUrunDto);
        
        List<SepetUrunDTO> GetAllSepeturun();
        
    }
}
