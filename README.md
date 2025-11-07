# 🩺 Sağlık Asistanım

**Sağlık Asistanım**, kullanıcıların kişisel sağlık verilerini kolayca takip etmelerini, yapay zeka destekli analizlerle bu verileri anlamlandırmalarını ve sağlık durumları hakkında haftalık/aylık raporlar almalarını sağlayan modern bir mobil sağlık uygulamasıdır.

---

## 🧭 Proje Amacı

Bu proje, **kronik hastalıkların yönetimini kolaylaştırmayı** ve **sağlıklı yaşam bilincini artırmayı** hedeflemektedir.  
Kullanıcılar; tansiyon, kan şekeri, kilo, nabız gibi hayati ölçümlerini düzenli olarak kaydedebilirler.  
Yapay zeka algoritmaları bu verileri analiz ederek anormallikleri tespit eder, trendleri belirler ve kullanıcıya özel geri bildirimler sunar.

> ⚠️ **Not:** Bu uygulama profesyonel tıbbi tavsiye, teşhis veya tedavinin yerini almaz. Kullanıcıların her zaman bir sağlık uzmanına danışması teşvik edilir.

---

## ✨ Temel Özellikler

### 🔹 Kapsamlı Veri Takibi
- 🩸 **Tansiyon*
- 🍬 **Kan Şekeri**
- ⚖️ **Kilo ve Vücut Kitle İndeksi (VKİ)**
- 💧 *(Gelecekte eklenecek: Uyku, adım sayısı, su tüketimi vb.)*

### 🤖 Yapay Zeka Destekli Analiz
- Girilen verilere dayanarak kişiselleştirilmiş sağlık içgörüleri oluşturur.  
- Riskli eğilimler veya ani değişiklikler için uyarı sistemi sağlar.  
- AI tabanlı veri özetleme ve tahminleme özellikleri içerir.

### 📊 Raporlama
- Haftalık ve aylık sağlık özet raporları oluşturur.  
- 📧 Raporları doktor veya yakınlarla paylaşabilme.  
- 🗓️ Otomatik aylık rapor e-postası gönderimi.

### 🧬 Kan Tahlili Yorumlama
- 🧾 **Kan testi sonuçlarını (PDF veya fotoğraf olarak)** yükleme desteği.  
- 🧠 AI destekli ön değerlendirme (referans aralıklarına göre analiz).  
- 📈 Test sonuçlarının zaman içindeki değişimini grafiklerle takip etme.

---

## 🛠️ Kullanılan Teknolojiler

| Teknoloji | Açıklama |
|------------|-----------|
| ⚙️ **ASP.NET Core Web API** | Backend servisleri |
| 🧩 **Entity Framework Core** | ORM katmanı |
| 🗄️ **Microsoft SQL Server** | Veritabanı yönetimi |
| 🔄 **AutoMapper** | DTO ↔ Entity dönüşümleri |
| 🧠 **MediatR (CQRS)** | Komut/Sorgu yapısı |
| 🪵 **Serilog** | Loglama sistemi |
| ✅ **FluentValidation** | Veri doğrulama altyapısı |
| ⏰ **Hangfire (Planlanıyor)** | Zamanlanmış görevler (otomatik e-posta) |
| 🧬 **Custom AI Service** | Yapay zeka analizleri |

---

## 👥 Kullanıcı Rolleri

| Rol | Açıklama |
|-----|-----------|
| 👑 **Admin** | Kullanıcı ve sistem yönetimi |
| 🙍‍♂️ **User** | Sağlık verilerini takip eden son kullanıcı |
| 🩺 **Doktor** *(Gelecekte eklenecek)* | Kullanıcı raporlarını görüntüleyip analiz edebilir |

---

## 💾 Veritabanı

- **SQL Server** kullanılmaktadır.  
- **Entity Framework Core** ile Code-First yaklaşımı benimsenmiştir.  
- Migration işlemleriyle veritabanı otomatik oluşturulur.

### ⚙️ Katman Görevleri

| Katman | Açıklama |
|--------|-----------|
| **Domain** | Saf iş kuralları ve temel varlıklar burada bulunur. Framework bağımlılığı yoktur. |
| **Application** | İş mantığı, CQRS komut/sorgu yapısı, servis arabirimleri ve DTO’lar burada yer alır. |
| **Infrastructure** | Veri erişimi (EF Core), kimlik doğrulama, loglama, caching, e-posta gibi dış bağımlılıklar bu katmanda uygulanır. |
| **API (Presentation)** | HTTP endpoint’leri, controller’lar, middleware’ler ve kullanıcıya sunulan arabirim burada bulunur. |

---

### 🧠 Clean Architecture Avantajları

- ✅ Katmanlar arası **gevşek bağlılık (Low Coupling)**  
- ✅ Kolay **test edilebilirlik (Unit & Integration Test)**  
- ✅ Yeni teknolojilere kolay **adaptasyon**  
- ✅ Net **sorumluluk ayrımı (Separation of Concerns)**  
- ✅ Bakımı ve genişletilmesi kolay bir yapı

---

### 🧩 Kullanılan Mimari Bileşenler

| Bileşen | Amaç |
|----------|------|
| **CQRS + MediatR** | Komut ve sorguların ayrılmasıyla temiz iş akışı sağlar. |
| **FluentValidation** | Giriş doğrulama kurallarını merkezi bir yerde toplar. |
| **AutoMapper** | DTO ↔ Entity dönüşümlerini kolaylaştırır. |
| **Serilog** | Detaylı ve yapılandırılabilir loglama sağlar. |
| **EF Core** | Veritabanı işlemlerinde ORM desteği sunar. |
| **JWT + Identity** | Güvenli kimlik doğrulama altyapısı oluşturur. |
| **Caching (Redis / Memory)** | Performans optimizasyonu sağlar. |

Proje **Clean Architecture** prensipleri ile tasarlanmıştır.

