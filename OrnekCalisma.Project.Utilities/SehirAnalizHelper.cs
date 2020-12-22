using System.Collections.Generic;
using System.Data.SqlClient;
using OrnekCalisma.Core;
using OrnekCalisma.Project.Business.Abstract;
using OrnekCalisma.Project.DTO;

namespace OrnekCalisma.Project.Utilities
{
    public class SehirAnalizHelper
    {        
        public readonly IMusteriService _musteriService;

        public readonly ISepetService _sepetService;

        public readonly ISepetUrunService _sepetUrunService;

        public SehirAnalizHelper(IMusteriService musteriService, ISepetService sepetService, ISepetUrunService sepetUrunService)
        {
            _musteriService = musteriService;
            _sepetService = sepetService;
            _sepetUrunService = sepetUrunService;
        }
        
        public List<SehirAnalizDTO> AnalizYap()
        {
            List<SehirAnalizDTO> data = new List<SehirAnalizDTO>();

            string query = $"SELECT m.[Sehir],COUNT(s.Id) toplam ,SUM(su.Tutar) tutar FROM[OrnekDb].[dbo].[Musteri] m " +
                           $"LEFT JOIN[OrnekDb].[dbo].[Sepet] s on s.MusteriId = m.Id " +
                           $"LEFT JOIN[OrnekDb].[dbo].[SepetUrun] su on su.SepetId = s.Id " +
                           $"GROUP BY m.[Sehir] " +
                           $"ORDER BY COUNT(s.Id) desc";

            using (SqlConnection connection = new SqlConnection(DatabaseHelper.connection))
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    data.Add(new SehirAnalizDTO()
                    {
                        SehirAdi = reader[0].ToString(),
                        urunAdeti= reader[1].ToString() ,
                        ToplamFiyat = reader[2].ToString() + " TL "
                    });
                }
                reader.Close();
            }
            return data;
        }

        
    }
}
