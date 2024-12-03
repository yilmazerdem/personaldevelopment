namespace visaApp.Models
{
    public class VizeBasvuru
    {
        public Guid BasvuruId { get; set; }
        public string Uyruk { get; set; }
        public string BasvuruUlke { get; set; }
        public string BasvuruSehir { get; set; }
        public string VizeTuru { get; set; }
        public string KonaklamaninAnaHedefi { get; set; }
        public string PasaportAldigiUlke { get; set; }
        public string PasaportTipi { get; set; }
        public string PasaportNumarasi { get; set; }
        public DateTime VerilisTarihi { get; set; }
        public DateTime SonKullanmaTarihi { get; set; }
        public string SeyahatSebebi { get; set; }
        public string SeyahatAmaci { get; set; }
        public string SeyahatIlgiliEkBilgiler { get; set; }
    }
}
