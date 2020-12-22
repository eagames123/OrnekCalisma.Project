using System;
using System.Collections.Generic;
using System.Linq;
using OrnekCalisma.Project.Business.Abstract;
using OrnekCalisma.Project.DTO;

namespace OrnekCalisma.Project.Utilities
{
    public class MusteriSepetUrunHelper
    {
        public readonly ISepetUrunService _sepetUrunService;

        public readonly IMusteriService _musteriService;

        public readonly ISepetService _sepetService;

        public MusteriSepetUrunHelper(ISepetUrunService sepetUrunService, IMusteriService musteriService, ISepetService sepetService)
        {
            _sepetUrunService = sepetUrunService;
            _musteriService = musteriService;
            _sepetService = sepetService;
        }

        Random random = new Random();
        
        public void Ekle(int musteriAdet, int sepetAdet)
        {
            #region Müşteri Ekleme

            int sonuc = 0;

            List<string> sehir = new List<string>()
                {"İstanul", "Ankara", "İzmir", "Bursa", "Manisa", "Trabzon", "Sakarya", "İzmit", "Muş", "Van"};

            for (int i = 0; i < musteriAdet; i++)
            {
                MusteriDTO musteriDto = new MusteriDTO();
                musteriDto.Ad = RandomString(8);
                musteriDto.Soyad = RandomString(10);
                musteriDto.Sehir = sehir[random.Next(0, 9)];
                sonuc = _musteriService.AddMusteri(musteriDto);
            }

            #endregion
            
            #region Sepet Ekleme

            List<MusteriDTO> list = new List<MusteriDTO>();

            list = _musteriService.LastItem(musteriAdet);

            int listcount = list.Count;

            SepetDTO sepetDto = new SepetDTO();

            for (int i = 0; i < sepetAdet; i++)
            {
                sepetDto.MusteriId = list[random.Next(0, list.Count)].Id;
                sepetDto.Tarih = DateTime.Now;
                _sepetService.AddSepet(sepetDto);
            }

            #endregion

            #region Sepet Ürün Ekleme

            List<SepetDTO> listSepet = new List<SepetDTO>();

            listSepet = _sepetService.GetSepet();

            int listSepetcount = list.Count;

            SepetUrunDTO sepetUrunDto = new SepetUrunDTO();

            foreach (var sepet in listSepet)
            {
                for (int i = 0; i < 5; i++)
                {
                    sepetUrunDto.SepetId = sepet.Id;
                    sepetUrunDto.Tutar = random.Next(100, 1000);
                    sepetUrunDto.Aciklama = RandomString(100);
                    _sepetUrunService.AddSepetUrun(sepetUrunDto);
                }
            }

            #endregion
        }
        
        public static string RandomString(int length)
        {
            Random random = new Random();
            
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
