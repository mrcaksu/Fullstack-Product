import { Product } from "./types";

const BASE = process.env.NEXT_PUBLIC_API_BASE_URL!;
if (!BASE) throw new Error("NEXT_PUBLIC_API_BASE_URL tanımlı değil.");

// TÜM ÜRÜNLERİ GETİR
export async function getProducts(): Promise<Product[]> {
  const res = await fetch(`${BASE}/api/Products/Get-All-Products`, { cache: "no-store" });
  if (!res.ok) throw new Error("Ürünler alınamadı.");
  return res.json();
}

// ID'YE GÖRE ÜRÜN GETİR
export async function getProductById(id: string): Promise<Product> {
  const res = await fetch(`${BASE}/api/Products/Get-Product/${id}`, { cache: "no-store" });
  if (!res.ok) throw new Error("Ürün bulunamadı.");
  return res.json();
}

// YENİ ÜRÜN EKLE
export async function createProduct(input: { name: string; price: number }): Promise<Product> {
  const res = await fetch(`${BASE}/api/Products/add-product`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(input),
  });
  if (!res.ok) throw new Error(await res.text());
  return res.json();
}

// ÜRÜN GÜNCELLE
export async function updateProduct(id: string, input: { name: string; description?: string; price: number }): Promise<Product> {
  const res = await fetch(`${BASE}/api/Products/Update-Product/${id}`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ req: input }),
  });
  if (!res.ok) throw new Error("Ürün güncellenemedi.");
  return res.json();
}

// ÜRÜN SİL
export async function deleteProduct(id: string): Promise<void> {
  const res = await fetch(`${BASE}/api/Products/Remove-Product/${id}`, { method: "DELETE" });
  if (!res.ok) throw new Error("Ürün silinemedi.");
}
