using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using OrnekCalisma.Project.DTO;

namespace OrnekCalisma.Core
{
    public class DbOrnekConnection : IDbOrnekConnection
    {
        #region müşteri
        public int Add(MusteriDTO musteriDto)
        {
            int result = 0;

            string query = "INSERT INTO[dbo].[Musteri]([Ad],[Soyad],[Sehir]) VALUES(@Ad,@Soyad,@Sehir)";

            using (SqlConnection connection = new SqlConnection(DatabaseHelper.connection))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Ad", musteriDto.Ad);
                command.Parameters.AddWithValue("@Soyad", musteriDto.Ad);
                command.Parameters.AddWithValue("@Sehir", musteriDto.Sehir);
                connection.Open();
                result = Convert.ToInt32(command.ExecuteScalar());
            }

            return result;
        }
        
        public List<MusteriDTO> GetList()
        {
            int result = 0;
            List<MusteriDTO> data = new List<MusteriDTO>();

            string query = "SELECT [Id],[Ad],[Soyad],[Sehir]FROM[OrnekDb].[dbo].[Musteri]";

            using (SqlConnection connection = new SqlConnection(DatabaseHelper.connection))
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    data.Add(new MusteriDTO()
                    {
                        Id = Convert.ToInt32(reader[0]),
                        Ad = reader[1].ToString(),
                        Soyad = reader[2].ToString(),
                        Sehir = reader[0].ToString()
                    });
                }
                reader.Close();
            }
            return data;
        }

        public List<MusteriDTO> GetLastItems(int deger)
        {
            int result = 0;
            List<MusteriDTO> data = new List<MusteriDTO>();

            string query = "SELECT TOP (@deger) [Id],[Ad],[Soyad],[Sehir]FROM[OrnekDb].[dbo].[Musteri] order by Id desc";

            using (SqlConnection connection = new SqlConnection(DatabaseHelper.connection))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@deger", deger);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    data.Add(new MusteriDTO()
                    {
                        Id = Convert.ToInt32(reader[0])
                    });
                }
                reader.Close();
            }
            return data;
        }
        #endregion

        #region Sepet
        public int AddSepet(SepetDTO sepetDto)
        {
            int result = 0;

            string query = "INSERT INTO[dbo].[Sepet]([MusteriId],[Tarih]) VALUES(@MusteriId,@Tarih)";

            using (SqlConnection connection = new SqlConnection(DatabaseHelper.connection))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MusteriId", sepetDto.MusteriId);
                command.Parameters.AddWithValue("@Tarih", sepetDto.Tarih);
                connection.Open();
                result = Convert.ToInt32(command.ExecuteScalar());
            }

            return result;
        }
        
        public List<SepetDTO> GetListSepet()
        {
            int result = 0;
            List<SepetDTO> data = new List<SepetDTO>();

            string query = "SELECT [Id],[MusteriId],[Tarih]FROM[OrnekDb].[dbo].[Sepet]";

            using (SqlConnection connection = new SqlConnection(DatabaseHelper.connection))
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    data.Add(new SepetDTO()
                    {
                        Id = Convert.ToInt32(reader[0]),
                        MusteriId = Convert.ToInt32(reader[1]),
                        Tarih = (DateTime)(reader[2])
                    });
                }
                reader.Close();
            }
            return data;
        }
        #endregion

        #region SepetUrun
        public int AddSepetUrun(SepetUrunDTO sepetUrunDto)
        {
            int result = 0;

            string query = "INSERT INTO[dbo].[SepetUrun]([SepetId],[Tutar],[Aciklama]) VALUES(@SepetId,@Tutar,@Aciklama)";

            using (SqlConnection connection = new SqlConnection(DatabaseHelper.connection))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SepetId", sepetUrunDto.SepetId);
                command.Parameters.AddWithValue("@Tutar", sepetUrunDto.Tutar);
                command.Parameters.AddWithValue("@Aciklama", sepetUrunDto.Aciklama);
                connection.Open();
                result = Convert.ToInt32(command.ExecuteScalar());
            }

            return result;
        }

        public List<SepetUrunDTO> GetListSepetUrun()
        {
            int result = 0;
            List<SepetUrunDTO> data = new List<SepetUrunDTO>();

            string query = "SELECT TOP (1000) [Id],[SepetId],[Tutar],[Aciklama]FROM[OrnekDb].[dbo].[SepetUrun]";

            using (SqlConnection connection = new SqlConnection(DatabaseHelper.connection))
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    data.Add(new SepetUrunDTO()
                    {
                        Id = Convert.ToInt32(reader[0]),
                        SepetId = Convert.ToInt32(reader[1]),
                        Tutar = Convert.ToInt32(reader[2]),
                        Aciklama = reader[3].ToString()
                    });
                }
                reader.Close();
            }
            return data;
        }
        #endregion
        
    }
}
