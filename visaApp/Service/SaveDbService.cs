using Npgsql;
using Microsoft.Extensions.Configuration;
using visaApp.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace visaApp.Service
{
    public interface ISaveDbService
    {
        Task<bool> SaveDbServicelog();
    }
    public class SaveDbService(IConfiguration _configuration, VizeBasvuru basvuru) : ISaveDbService
    {
        public async Task<bool> SaveDbServicelog()
        {


            using var connection = new NpgsqlConnection(_configuration.GetConnectionString("postgre_test"));
            await connection.OpenAsync();

            var sql = @"
                    INSERT INTO vize_basvuru (
                        uyruk, 
                        basvuru_ulke, 
                        basvuru_sehir, 
                        vize_turu, 
                        konaklamanin_ana_hedefi,
                        pasaport_aldigi_ulke, 
                        pasaport_tipi, 
                        pasaport_numarasi, 
                        verilis_tarihi,
                        son_kullanma_tarihi, 
                        seyahat_sebebi, 
                        seyahat_amaci, 
                        seyahat_ilgili_ek_bilgiler
                    ) VALUES (
                        @uyruk, 
                        @basvuruUlke, 
                        @basvuruSehir, 
                        @vizeTuru, 
                        @konaklamaninAnaHedefi,
                        @pasaportAldigiUlke, 
                        @pasaportTipi, 
                        @pasaportNumarasi, 
                        @verilisTarihi,
                        @sonKullanmaTarihi, 
                        @seyahatSebebi, 
                        @seyahatAmaci, 
                        @seyahatIlgiliEkBilgiler
                    )";

            using (var cmd = new NpgsqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("uyruk", basvuru.Uyruk);
                cmd.Parameters.AddWithValue("basvuruUlke", basvuru.BasvuruUlke);
                cmd.Parameters.AddWithValue("basvuruSehir", basvuru.BasvuruSehir);
                cmd.Parameters.AddWithValue("vizeTuru", basvuru.VizeTuru);
                cmd.Parameters.AddWithValue("konaklamaninAnaHedefi", basvuru.KonaklamaninAnaHedefi);
                cmd.Parameters.AddWithValue("pasaportAldigiUlke", basvuru.PasaportAldigiUlke);
                cmd.Parameters.AddWithValue("pasaportTipi", basvuru.PasaportTipi);
                cmd.Parameters.AddWithValue("pasaportNumarasi", basvuru.PasaportNumarasi);
                cmd.Parameters.AddWithValue("verilisTarihi", basvuru.VerilisTarihi);
                cmd.Parameters.AddWithValue("sonKullanmaTarihi", basvuru.SonKullanmaTarihi);
                cmd.Parameters.AddWithValue("seyahatSebebi", basvuru.SeyahatSebebi);
                cmd.Parameters.AddWithValue("seyahatAmaci", basvuru.SeyahatAmaci);
                cmd.Parameters.AddWithValue("seyahatIlgiliEkBilgiler",
                    basvuru.SeyahatIlgiliEkBilgiler ?? (object)DBNull.Value);

                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                if (rowsAffected < 1)
                    throw new Exception("Kayıt edilemedi.");

                return rowsAffected > 0;


            }

        }
    }
}
