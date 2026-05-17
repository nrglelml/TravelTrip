# 🌍 Travel Trip - Dinamik Tatil & Seyahat Blogu

Travel Trip, seyahatseverlerin rotaları inceleyebileceği, deneyimlerini yorumlar aracılığıyla paylaşabileceği, yöneticilerin ise tüm web sitesi içeriğini dinamik bir panel üzerinden kontrol edebileceği **ASP.NET MVC** tabanlı bir web uygulamasıdır. 

M&Y Yazılım Eğitim Akademi Danışmanlık bünyesinde, **Murat Yücedağ** mentörlüğünde geliştirilmiştir.

---

## 🚀 Öne Çıkan Özellikler

### 👤 Kullanıcı Tarafı (Frontend)
* **Dinamik Blog Listesi:** Popüler seyahat rotalarının, resimlerin ve detaylı açıklamaların listelenmesi.
* **Akıllı Yorum Sistemi:** Her blog yazısının altında kullanıcıların etkileşime girebileceği, PRG (Post-Redirect-Get) deseniyle güçlendirilmiş güvenli yorum alanı.
* **Yan Menü (Sidebar) Bileşenleri:** Sitede en son paylaşılan bloglar ve en son yapılan kullanıcı yorumlarının dinamik listelenmesi.
* **İletişim Formu:** Ziyaretçilerin admin paneline doğrudan düşen mesajlar gönderebilmesi.

### 🔐 Yönetim Paneli (Admin)
* **Güvenli Giriş Paneli:** FormsAuthentication ve Session mimarisiyle korunan yetkilendirme sistemi.
* **Gelişmiş Görsel Yönetimi:** Benzersiz `Guid` tanımlamaları ile sunucuya dosya yükleme (File Upload) veya URL yoluyla hibrit görsel ekleme/güncelleme desteği.
* **Uzantı Kısıtlaması:** Güvenlik ve performans için sadece `.jpg`, `.jpeg` ve `.png` formatlarına izin veren dosya doğrulama kontrolü.
* **İçerik Yönetimi (CRUD):** Blog yazıları, yorumlar, iletişim mesajları ve "Hakkımızda" sayfasının anlık olarak güncellenmesi veya silinmesi.

---

## 🛠️ Teknik Altyapı ve Teknolojiler

* **Framework:** ASP.NET MVC 5 (C#)
* **ORM / Veri Yönetimi:** Entity Framework (Code First Yaklaşımı)
* **Veritabanı:** Microsoft SQL Server
* **Arayüz Tasarımı:** Bootstrap, HTML5, CSS3 (Flexbox), Google Fonts (Poppins)
* **Kütüphaneler:** jQuery, SweetAlert2 (Kullanıcı dostu pop-up bildirimler)

---

## 📸 Ekran Görüntüleri

| Ana Sayfa / Blog Listesi | Admin Yönetim Paneli |
<img width="592" height="847" alt="image" src="https://github.com/user-attachments/assets/e140290e-8be6-4358-bb8d-23fc402113c9" />
<img width="1065" height="832" alt="image" src="https://github.com/user-attachments/assets/d85ec693-ef9f-44ee-8668-f6b41efcbdea" />
<img width="1280" height="577" alt="image" src="https://github.com/user-attachments/assets/b6c2f970-ecef-4de9-8d67-94b748f068a5" />

---

## 💻 Kurulum ve Çalıştırma

Projeyi yerel bilgisayarınızda çalıştırmak için aşağıdaki adımları takip edebilirsiniz:

1. **Projeyi Klonlayın:**
   ```bash
   git clone [https://github.com/nrglelml/TravelTrip.git]
   Bağlantı Adresini Düzenleyin:
Web.config dosyası içerisindeki connectionString alanını kendi yerel SQL Server bilgilerinize göre güncelleyin:

2. **Bağlantı Adresini Düzenleyin:**
Web.config dosyası içerisindeki connectionString alanını kendi yerel SQL Server bilgilerinize göre güncelleyin:
<connectionStrings>
  <add name="Context" connectionString="data source=YOUR_SERVER_NAME;initial catalog=TravelTripDb;integrated security=true;" providerName="System.Data.SqlClient" />
</connectionStrings>
3. **Veritabanı Oluşturun:**
   Tablolar:
   <img width="674" height="406" alt="image" src="https://github.com/user-attachments/assets/e679cb17-4f49-4840-9edf-143fb2f9708a" />
   <img width="702" height="336" alt="image" src="https://github.com/user-attachments/assets/870b0b35-aaee-437d-a726-0b28e4a30b97" />
   <img width="613" height="258" alt="image" src="https://github.com/user-attachments/assets/df9e44f4-b521-479c-a18f-f52a852dc6d5" />
   <img width="656" height="280" alt="image" src="https://github.com/user-attachments/assets/d9dd6ab5-d0c3-4c0a-b479-63a7a8c45463" />
   <img width="720" height="294" alt="image" src="https://github.com/user-attachments/assets/dc71e86a-84b8-48f7-bdb8-10f31ef1cf35" />
   <img width="699" height="318" alt="image" src="https://github.com/user-attachments/assets/48cbc8df-a0c0-429e-b2f3-36bbfe260de7" />
   <img width="666" height="809" alt="image" src="https://github.com/user-attachments/assets/2a65c333-9a08-4b1e-91c1-d0259e0218c9" />
   Package Manager Console ekranını açın ve Code First migration işlemlerini tetikleyin
       Update-Database
5. **Projeyi Çalıştırın
    Visual Studio üzerinden F5 tuşuna basarak projeyi ayağa kaldırabilirsiniz.
