# SOLID Prensipleri: Interface Segregation Principle (ISP) - Grup 4

Bu proje, nesne yönelimli programlamada SOLID prensiplerinin 4. maddesi olan **Arayüz Ayrımı Prensibi (Interface Segregation Principle - ISP)** konusunu ve C# üzerindeki pratik uygulamasını anlatmak amacıyla hazırlanmıştır.

---

## 📌 1. Sunum Akışı ve Günlük Hayattan Analoji (3 Aşamalı Kural)

### 1. Aşama: Analoji (Günlük Hayattan Örnek)
> *"İstemciler (sınıflar), kullanmadıkları metotlara veya arayüzlere bağımlı olmaya zorlanmamalıdır."*

* **Örnek:** Çok fonksiyonlu (All-in-One) bir ofis cihazı düşünelim: Üzerinde **Yazıcı**, **Tarayıcı**, **Fotokopi** ve **Faks** özellikleri olsun.
* Eğer biz tek bir devasa arayüz (`ICokFonksiyonluCihaz`) tanımlayıp içine `Yazdir()`, `Tara()`, `FotokopiCek()` ve `FaksGonder()` metotlarını koyarsak; sadece basit çıktı almak isteyen ucuz bir **"Ev Tipi Yazıcı"** bu arayüzü uyguladığında faks çekemeyeceği için `FaksGonder()` metodunda hata vermek (`NotImplementedException`) zorunda kalır.
* **Doğru Yaklaşım (ISP):** Cihaz yeteneklerini `IYazici`, `ITarayici`, `IFaks` gibi amaca yönelik küçük arayüzlere bölmektir. Böylece ev tipi yazıcı yalnızca `IYazici` arayüzünü alır; hiçbir gereksiz yükümlülüğe katlanmaz.

---

### 2. Aşama: Problemin Gösterimi (Kötü Kod)
`Program.cs` dosyasının ilk yarısında yer alan kötü senaryo incelendiğinde:
* `IRepository<T>` arayüzü içine `Ekle()`, `Sil()`, `Listele()` ve `RaporAl()` metotları tek bir şişirilmiş arayüzde (Fat/Polluted Interface) toplanmıştır.
* Amacı sadece veri listelemek olan `ReadOnlyProductRepository` (Salt Okunur Ürün Deposu), bu arayüzü uyguladığı için istemediği halde `Ekle()` ve `Sil()` metotlarını yazmak zorunda bırakılmıştır.
* Bu durum sınıfın içinde `throw new NotImplementedException(...)` yazılmasına yol açar.
* **Buradaki Sorun Nedir?**
  1. **Yanıltıcı Arayüz (Broken Contract):** Geliştirici kod yazarken intellisense'de `repo.Ekle(...)` metodunu görür. Metot var gibi görünür fakat çalışma zamanında (Runtime) uygulama çöker.
  2. **Gereksiz Bağımlılık:** Sınıf yapamayacağı işlerin sorumluluğunu taşır.

---

### 3. Aşama: Çözümün Gösterimi (İyi Kod - Refactoring)
`Program.cs` dosyasının alt kısmında yer alan çözüm senaryosunda:
* Devasa `IRepository` arayüzü mantıksal sorumluluklarına göre parçalanmıştır:
  * `IReadRepository<T>` -> `Listele()`
  * `IWriteRepository<T>` -> `Ekle()`, `Sil()`
  * `IReportable` -> `RaporAl()`
* Artık `ReadOnlyProductRepository` sadece `IReadRepository<Product>` ve `IReportable` arayüzlerini uygular.
* `FullProductRepository` ise hem `IReadRepository<Product>` hem de `IWriteRepository<Product>` arayüzlerini uygulayarak tam yetkili çalışır.
* **Kazanımlar:**
  * Derleme zamanı (compile-time) tip güvenliği sağlandı.
  * `NotImplementedException` fırlatma riski tamamen ortadan kalktı.

---

## 🚀 Projeyi Çalıştırma Rehberi

Sınıf arkadaşlarımızın ve hocamızın projeyi kendi bilgisayarlarında klonlayıp çalıştırması için adımlar:

### 1. Depoyu Klonlayın:
```bash
git clone https://github.com/kkenanfy/ISP.git
cd ISP
```

### 2. Projeyi Derleyin ve Çalıştırın:
```bash
dotnet run
```

> **Not:** `Program.cs` dosyasında varsayılan olarak **Kötü Kod** senaryosu aktiftir. Çalıştırdığınızda ISP ihlalinden kaynaklanan `NotImplementedException` hatasının nasıl yakalandığını görebilirsiniz. **İyi Kod** senaryosunu incelemek için dosyanın altındaki yorum satırlarını aktif hale getirebilirsiniz.

---

## 🎤 Sunum Sırasında Savunulacak Mimari Noktalar (Ezberden Kaçınma)
1. **Neden Arayüzleri Böldük?** Tek bir büyük arayüz yerine amaca odaklı küçük arayüzler oluşturarak sınıfların sadece kendi görevlerini yapmasını sağladık.
2. **LSP ile İlişkisi:** Bir alt sınıf, üst arayüzün tüm sözleşmesini yerine getiremiyorsa (NotImplemented fırlatıyorsa) bu aynı zamanda Liskov İkame Prensibi'ne (LSP) de darbe vurur. ISP uygulandığında LSP de doğal olarak korunmuş olur.
3. **Esneklik:** Yarın bir gün sadece loglama veya sadece arama yeteneği getirmek istediğimizde yeni bir küçük arayüz tanımlayıp sisteme kolayca entegre edebiliriz.
