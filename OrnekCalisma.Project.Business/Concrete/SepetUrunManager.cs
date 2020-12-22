using System.Collections.Generic;
using OrnekCalisma.Core;
using OrnekCalisma.Project.Business.Abstract;
using OrnekCalisma.Project.DTO;

namespace OrnekCalisma.Project.Business.Concrete
{
    public class SepetUrunManager:ISepetUrunService
    {
        private readonly IDbOrnekConnection _dbOrnekConntion;

        public SepetUrunManager(IDbOrnekConnection dbOrnekConntion)
        {
            _dbOrnekConntion = dbOrnekConntion;
        }
        
        public int AddSepetUrun(SepetUrunDTO sepetUrunDto)
        {
            int sonuc = _dbOrnekConntion.AddSepetUrun(sepetUrunDto);
            
            return 1;
        }

        public List<SepetUrunDTO> GetAllSepeturun()
        {
            List<SepetUrunDTO> list = _dbOrnekConntion.GetListSepetUrun();
            
            return list;
        }
    }
}
