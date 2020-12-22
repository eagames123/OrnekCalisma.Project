using System.Collections.Generic;
using OrnekCalisma.Project.DTO;

namespace OrnekCalisma.Project.Business.Abstract
{
    public interface ISepetService
    {
        int AddSepet(SepetDTO sepetDto);
        
        List<SepetDTO> GetSepet();
        
    }
}
