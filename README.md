# 🧩 Full Stack Product Management App
> 🧠 Basit ürün ekleme ve listeleme işlevlerini içeren full stack uygulama.  
> Backend .NET 8 Web API, frontend Next.js 14 App Router ile geliştirilmiştir.

---

## 🎯 Proje Amacı
Bu proje, **ürün yönetimi için CRUD tabanlı basit bir sistem** geliştirerek Full Stack Developer yetkinliklerini ölçmeyi amaçlar.  
Kullanıcılar, web arayüzü üzerinden ürün ekleyebilir ve mevcut ürünleri listeleyebilir.

---
## 🚀 Hızlı Başlangıç (Quick Start)
# 1️⃣ Backend
cd backend/src/Api
dotnet restore
dotnet ef database update
dotnet run

# 2️⃣ Frontend
cd frontend
npm install
npm run dev


### 📦 Genel Bakış
Backend, **monolitik 3 katmanlı mimari** ile oluşturulmuştur:

| Katman | Açıklama |
|--------|-----------|
| **API** | Controller’lar, endpoint tanımları, Swagger UI |
| **Application** | Servis katmanı (iş mantığı ve DTO’lar) |
| **Infrastructure** | EF Core, Repository, DbContext |
| **Domain** | Entity tanımları (örnek: `Product`) |

---

### 🧰 Kullanılan Teknolojiler
- **.NET 8 Web API**
- **Entity Framework Core (PostgreSQL provider)**
- **Swagger / Swashbuckle**
- **Dependency Injection**
- **Async / Await destekli repository deseni**
- **C# 12 Record & DTO Pattern**

---

### 🧠 Endpoint’ler

| HTTP | Endpoint | Açıklama |
|------|-----------|----------|
| `GET` | `/api/Products/Get-All` | Tüm ürünleri döner |
| `POST` | `/api/Products/Add-Product` | Yeni ürün ekler |

---

⚙️ Kurulum ve Çalıştırma
|------|-----------|----------|
sudo service postgresql start
psql -U postgres
CREATE DATABASE products;


Backend Bağımlılıklarını Yükle ve Migration Uygula
|------|-----------|----------|
cd backend/src/Api
dotnet restore
dotnet ef database update
dotnet run

Çalışma
|------|-----------|----------|
Uygulama http://localhost:5249 adresinde çalışır.
Swagger dokümantasyonu: http://localhost:5249/swagger

| Metot                            | Ortalama Gecikme | İşlem Süresi | Durum |
| -------------------------------- | ---------------- | ------------ | ----- |
| `GET /api/Products/Get-All`      | ~15 ms           | < 30 ms      | ✅     |
| `POST /api/Products/Add-Product` | ~25 ms           | < 50 ms      | ✅     |
| PostgreSQL Bağlantı Süresi       | ~10 ms           | -            | ✅     |
| EF Core Migration Süresi         | ~120 ms          | -            | ✅     |


💻 Frontend – Next.js 14 (App Router + TypeScript)
|------|-----------|----------||------|-----------|----------|
### 🧰 Kullanılan Teknolojiler

- **Next.js 14 (App Router yapısı)**
- **React 18**
- **TypeScript 5**
- **TailwindCSS 3.4**
- **Fetch API (Backend entegrasyonu)**


### 🧭 Sayfalar
**| Yol             | Açıklama                                  |**
| --------------- | ----------------------------------------- |
**| `/products`     | Backend’den ürünleri listeleyen ana sayfa |**
**| `/products/new` | Yeni ürün ekleme formu                    |**

## 🌐 Ortam Değişkenleri
**NEXT_PUBLIC_API_BASE_URL=http://localhost:5249**
frontend/
├── app/
│   ├── layout.tsx
│   ├── globals.css
│   ├── products/
│   │   ├── page.tsx
│   │   └── new/page.tsx
│
├── components/
│   └── products/
│       ├── ProductTable.tsx
│       ├── ProductRow.tsx
│       └── ProductForm.tsx
│
├── lib/
│   ├── api.ts
│   └── types.ts
│
└── .env.example

### Frontend Kurulum
cd frontend
npm install
npm run dev

### Frontend Çalışma Metikleri
| İşlem            | Ortalama Süre | Açıklama                        |
| ---------------- | ------------- | ------------------------------- |
| `GET /products`  | ~50 ms        | Backend’den veri alma           |
| `POST /products` | ~60 ms        | Ürün ekleme isteği              |
| Build Süresi     | ~3 s          | TypeScript + Tailwind derlemesi |
| Sayfa Yükleme    | ~1.2 s        | SSR destekli render             |
| UI Rendering     | < 100 ms      | React 18 concurrent rendering   |

### Genel Proje Özellikleri
✅ Ürün listeleme ve ekleme işlemleri
✅ Swagger ile backend API dokümantasyonu
✅ TailwindCSS ile responsive, modern tasarım
✅ TypeScript tip güvenliği
✅ Clean architecture ve açık bağımlılıklar
✅ .env tabanlı yapılandırma (12 Factor App)
✅ Tek depoda backend + frontend (monorepo yaklaşımı)

## 🧱 Proje Yapısı
Fullstack-Product/
├── backend/
│   ├── src/
│   │   ├── Api/
│   │   ├── Application/
│   │   ├── Infrastructure/
│   │   └── Domain/
│   └── .gitignore
│
├── frontend/
│   ├── app/
│   ├── components/
│   ├── lib/
│   └── .env.example
│
└── README.md

