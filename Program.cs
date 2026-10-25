using System;
using System.Collections.Generic;

namespace ISP_KotuKod
{
    class Urun
    {
        public int Id { get; set; }
        public string Ad { get; set; }
    }

    interface IRepository
    {
        void Ekle(Urun urun);
        void Sil(int id);
        List<Urun> Listele();
        void RaporAl();
    }

    // Bu sinif sadece okuma yapacak ama Ekle ve Sil'i de yazmak zorunda
    class OkumaRepository : IRepository
    {
        List<Urun> urunler = new List<Urun>();

        public OkumaRepository()
        {
            urunler.Add(new Urun { Id = 1, Ad = "Laptop" });
            urunler.Add(new Urun { Id = 2, Ad = "Mouse" });
        }

        public List<Urun> Listele()
        {
            Console.WriteLine("Urunler listelendi.");
            return urunler;
        }

        public void RaporAl()
        {
            Console.WriteLine("Rapor alindi. Toplam urun: " + urunler.Count);
        }

        public void Ekle(Urun urun)
        {
            throw new NotImplementedException();
        }

        public void Sil(int id)
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- KOTU KOD ---");

            IRepository repo = new OkumaRepository();
            repo.Listele();
            repo.RaporAl();

            Console.WriteLine("Ürün Ekleniyor...");
            repo.Ekle(new Urun { Id = 3, Ad = "Klavye" });

            Console.ReadLine();
        }
    }
}




// namespace ISP_IyiKod
// {
//     class Urun
//     {
//         public int Id { get; set; }
//         public string Ad { get; set; }
//     }

//     interface IOkunabilir
//     {
//         List<Urun> Listele();
//         void RaporAl();
//     }

//     // Yazma isleri burada
//     interface IYazilabilir
//     {
//         void Ekle(Urun urun);
//         void Sil(int id);
//     }

//     // Bu sinif sadece okuma yapiyor
//     class OkumaRepository : IOkunabilir
//     {
//         List<Urun> urunler = new List<Urun>();

//         public OkumaRepository()
//         {
//             urunler.Add(new Urun { Id = 1, Ad = "Laptop" });
//             urunler.Add(new Urun { Id = 2, Ad = "Mouse" });
//         }

//         public List<Urun> Listele()
//         {
//             Console.WriteLine("Urunler listelendi.");
//             return urunler;
//         }

//         public void RaporAl()
//         {
//             Console.WriteLine("Rapor alindi. Toplam urun: " + urunler.Count);
//         }
//     }

//     // Bu sinif hem okuyor hem yaziyor
//     class TamRepository : IOkunabilir, IYazilabilir
//     {
//         List<Urun> urunler = new List<Urun>();

//         public TamRepository()
//         {
//             urunler.Add(new Urun { Id = 1, Ad = "Laptop" });
//             urunler.Add(new Urun { Id = 2, Ad = "Mouse" });
//         }

//         public List<Urun> Listele()
//         {
//             Console.WriteLine("Urunler listelendi.");
//             return urunler;
//         }

//         public void RaporAl()
//         {
//             Console.WriteLine("Rapor alindi. Toplam urun: " + urunler.Count);
//         }

//         public void Ekle(Urun urun)
//         {
//             urunler.Add(urun);
//             Console.WriteLine(urun.Ad + " eklendi.");
//         }

//         public void Sil(int id)
//         {
//             for (int i = 0; i < urunler.Count; i++)
//             {
//                 if (urunler[i].Id == id)
//                 {
//                     Console.WriteLine(urunler[i].Ad + " silindi.");
//                     urunler.RemoveAt(i);
//                     break;
//                 }
//             }
//         }
//     }

//     class Program
//     {
//         static void Main()
//         {
//             Console.WriteLine("--- IYI KOD ---");

//             // Sadece okuma yapan sinif
//             IOkunabilir okuma = new OkumaRepository();
//             okuma.Listele();
//             okuma.RaporAl();

//             Console.WriteLine();

//             // Hem okuyan hem yazan sinif
//             TamRepository tam = new TamRepository();
//             tam.Ekle(new Urun { Id = 3, Ad = "Klavye" });
//             tam.Sil(1);
//             tam.RaporAl();

//             Console.ReadLine();
//         }
//     }
// }