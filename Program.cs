using System;
using System.Collections.Generic;

// DEVASA VE ŞİŞRİLMİŞ ARAYÜZ (ISP İhlali)
public interface IRepository<T>
{
    void Ekle(T entity);
    void Sil(int id);
    List<T> Listele();
    void RaporAl();
}

public class Product 
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

// Salt okunur sınıf, ihtiyacı olmayan Ekle ve Sil metotlarını zoraki implemente ediyor
public class ReadOnlyProductRepository : IRepository<Product>
{
    public List<Product> Listele()
    {
        Console.WriteLine("Ürünler listelendi (Salt Okunur).");
        return new List<Product>();
    }

    public void RaporAl()
    {
        Console.WriteLine("Ürün raporu alındı.");
    }

    public void Ekle(Product entity)
    {
        throw new NotImplementedException("HATA: Bu sınıfın ekleme yetkisi yoktur! (ISP İhlali)"); 
    }

    public void Sil(int id)
    {
        throw new NotImplementedException("HATA: Bu sınıfın silme yetkisi yoktur! (ISP İhlali)"); 
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== KÖTÜ KOD SENARYOSU ===");
        
        IRepository<Product> repo = new ReadOnlyProductRepository();
        repo.Listele(); 

        try 
        {
            repo.Ekle(new Product { Id = 1, Name = "Laptop" });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message); // ISP İhlali hatası ekrana basılacak
        }

        Console.ReadLine();
    }
}



// using System;
// using System.Collections.Generic;

// public class Product 
// {
//     public int Id { get; set; }
//     public string? Name { get; set; }
// }

// // ÇÖZÜM: Arayüzleri sorumluluklarına göre mantıksal parçalara ayırıyoruz (Interface Segregation)
// public interface IReadRepository<T>
// {
//     List<T> Listele();
// }

// public interface IWriteRepository<T>
// {
//     void Ekle(T entity);
//     void Sil(int id);
// }

// public interface IReportable
// {
//     void RaporAl();
// }

// // Salt okunur sınıfımız artık sadece ihtiyacı olan arayüzleri uygular!
// public class ReadOnlyProductRepository : IReadRepository<Product>, IReportable
// {
//     public List<Product> Listele()
//     {
//         Console.WriteLine("Ürünler başarıyla listelendi (Salt Okunur).");
//         return new List<Product>();
//     }

//     public void RaporAl()
//     {
//         Console.WriteLine("Ürün raporu başarıyla alındı.");
//     }
//     // Artık gereksiz Ekle ve Sil metotları yok, ortada NotImplementedException da yok!
// }

// // Hem okuma hem yazma yapabilen tam yetkili repository
// public class FullProductRepository : IReadRepository<Product>, IWriteRepository<Product>
// {
//     public List<Product> Listele()
//     {
//         Console.WriteLine("Ürünler listelendi.");
//         return new List<Product>();
//     }

//     public void Ekle(Product entity)
//     {
//         Console.WriteLine("Ürün veritabanına başarıyla eklendi.");
//     }

//     public void Sil(int id)
//     {
//         Console.WriteLine("Ürün veritabanından silindi.");
//     }
// }

// class Program
// {
//     static void Main(string[] args)
//     {
//         Console.WriteLine("=== İYİ KOD (ÇÖZÜM) SENARYOSU ===");

//         // Sadece okuma yapabilen nesne
//         IReadRepository<Product> readRepo = new ReadOnlyProductRepository();
//         readRepo.Listele();

//         // Tam yetkili nesne
//         IWriteRepository<Product> writeRepo = new FullProductRepository();
//         writeRepo.Ekle(new Product { Id = 1, Name = "Laptop" });

//         Console.ReadLine();
//     }
// }