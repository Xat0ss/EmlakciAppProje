namespace EmlakciAppProje
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    public class EvYonetimi
    {
        private List<KiralikEv> kiralikEvler = new List<KiralikEv>();
        private List<SatilikEv> satilikEvler = new List<SatilikEv>();

        public void YeniEvGirisi()
        {
            Console.WriteLine("1-Kiralik Ev mi 2-Satilik Ev mi?");
            string secim = Console.ReadLine().ToLower();

            switch (secim)
            {
                case "1":
                    KiralikEvBilgileriGir();
                    break;
                case "2":
                    SatilikEvBilgileriGir();
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim.");
                    break;
            }
        }

        private void KiralikEvBilgileriGir()
        {
            KiralikEv ev = new KiralikEv();
            Console.WriteLine("Evin oda sayısını girin:");
            ev.OdaSayisi = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Evin kat numarasını girin:");
            ev.KatNumarasi = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Evin alanını girin:");
            ev.Alan = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Evin kira bedelini girin:");
            ev.KiraBedeli = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Evin depozito miktarını girin:");
            ev.Depozito = Convert.ToDecimal(Console.ReadLine());

            kiralikEvler.Add(ev);
        }

        private void SatilikEvBilgileriGir()
        {
            SatilikEv ev = new SatilikEv();
            Console.WriteLine("Evin oda sayısını girin:");
            ev.OdaSayisi = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Evin kat numarasını girin:");
            ev.KatNumarasi = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Evin alanını girin:");
            ev.Alan = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Evin fiyatını girin:");
            ev.Fiyat = Convert.ToDecimal(Console.ReadLine());

            satilikEvler.Add(ev);
        }

        public void EvleriDosyayaKaydet()
        {
            using (StreamWriter writer = new StreamWriter("evler.txt", true))
            {
                foreach (var ev in kiralikEvler)
                {
                    writer.WriteLine($"Kiralik Ev | Oda Sayisi: {ev.OdaSayisi}, Kat Numarasi: {ev.KatNumarasi}, Alan: {ev.Alan}, Kira Bedeli: {ev.KiraBedeli}, Depozito: {ev.Depozito}");
                }

                foreach (var ev in satilikEvler)
                {
                    writer.WriteLine($"Satilik Ev | Oda Sayisi: {ev.OdaSayisi}, Kat Numarasi: {ev.KatNumarasi}, Alan: {ev.Alan}, Fiyat: {ev.Fiyat}");
                }
            }
        }

        public void KayitliEvleriGoruntule()
        {
            if (!File.Exists("evler.txt"))
            {
                Console.WriteLine("Kayıtlı ev bulunmamaktadır.");
                return;
            }


            string[] lines = File.ReadAllLines("evler.txt");
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            EvYonetimi evYonetimi = new EvYonetimi();

            while (true)
            {
                Console.WriteLine("1. Yeni Ev Girişi");
                Console.WriteLine("2. Evleri Dosyaya Kaydet");
                Console.WriteLine("3. Kayıtlı Evleri Görüntüle");
                Console.WriteLine("4. Çıkış");
                Console.Write("Seçiminiz: ");

                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        evYonetimi.YeniEvGirisi();
                        break;
                    case "2":
                        evYonetimi.EvleriDosyayaKaydet();
                        Console.WriteLine("Evler dosyaya kaydedildi.");
                        break;
                    case "3":
                        evYonetimi.KayitliEvleriGoruntule();
                        break;
                    case "4":
                        Console.WriteLine("Programdan çıkılıyor...");
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}