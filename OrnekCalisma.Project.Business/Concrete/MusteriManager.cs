using System.Collections.Generic;
using OrnekCalisma.Core;
using OrnekCalisma.Project.Business.Abstract;
using OrnekCalisma.Project.DTO;

namespace OrnekCalisma.Project.Business.Concrete
{
    public class MusteriManager : IMusteriService
    {
        private readonly IDbOrnekConnection _dbOrnekConntion;

        public MusteriManager(IDbOrnekConnection dbOrnekConntion)
        {
            _dbOrnekConntion = dbOrnekConntion;
        }

        public int AddMusteri(MusteriDTO musteriDTO)
        {
            int sonuc = _dbOrnekConntion.Add(musteriDTO);

            return 0;
        }

        public List<MusteriDTO> GetMusteri()
        {
            List<MusteriDTO> list = new List<MusteriDTO>();
            
            list = _dbOrnekConntion.GetList();
            
            return list;
        }

        public List<MusteriDTO> LastItem(int deger)
        {
            List<MusteriDTO> list = new List<MusteriDTO>();
            
            list = _dbOrnekConntion.GetLastItems(deger);
            
            return list;
        }
        
    }
}
