using System.Collections.Generic;
using OrnekCalisma.Core;
using OrnekCalisma.Project.Business.Abstract;
using OrnekCalisma.Project.DTO;

namespace OrnekCalisma.Project.Business.Concrete
{
    public class SepetManager:ISepetService
    {
        private readonly IDbOrnekConnection _dbOrnekConntion;

        public SepetManager(IDbOrnekConnection dbOrnekConntion)
        {
            _dbOrnekConntion = dbOrnekConntion;
        }

        public int AddSepet(SepetDTO sepet)
        {
          int sonuc = _dbOrnekConntion.AddSepet(sepet);
            
          return 0;
        }

        public List<SepetDTO> GetSepet()
        {
            List<SepetDTO> list = new List<SepetDTO>();
            
            list = _dbOrnekConntion.GetListSepet();
            
            return list;
        }
        
    }
}
