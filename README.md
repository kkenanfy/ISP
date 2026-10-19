# Grup 4 - Arayüz Ayrımı Prensibi (Interface Segregation Principle - ISP) 

Bu proje, Isparta Uygulamalı Bilimler Üniversitesi Bilgisayar Programcılığı bölümü ders kapsamındaki sunum için C# ile hazırlanmıştır. Projede SOLID prensiplerinden biri olan **Interface Segregation Principle (ISP)** kuralının ihlal edilmesi (Kötü Kod) ve bu sorunun arayüzlerin parçalanmasıyla nasıl çözülmesi gerektiği (İyi Kod) gösterilmektedir.

## Proje İçeriği
* **Kötü Kod Senaryosu:** Devasa bir `IRepository` arayüzünün salt okunur bir sınıfa uygulanması sonucunda ortaya çıkan `NotImplementedException` hatasını gösterir.
* **İyi Kod Senaryosu:** Arayüzlerin sorumluluklarına göre (`IReadRepository`, `IWriteRepository`, `IReportable`) ayrılarak sınıfların sadece ihtiyaç duydukları metotları uygulamasını sağlar.

## Proje Nasıl Çalıştırılır?
1. Bilgisayarınızda **.NET SDK**'nın kurulu olduğundan emin olun.
2. Bu projeyi bilgisayarınıza klonlayın (`git clone` ile) veya ZIP olarak indirin.
3. Proje klasörünü terminalde veya Visual Studio Code içerisinde açın.
4. Projeyi çalıştırmak için terminale şu komutu yazın:
   ```bash
   dotnet run
   ```

> **Not:** `Program.cs` dosyasında varsayılan olarak **Kötü Kod** senaryosu aktiftir. Çalıştırdığınızda ISP ihlalinden kaynaklanan `NotImplementedException` hatasının nasıl yakalandığını görebilirsiniz. **İyi Kod** senaryosunu incelemek için dosyanın altındaki yorum satırlarını aktif hale getirebilirsiniz.
