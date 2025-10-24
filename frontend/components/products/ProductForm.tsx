"use client";

import { useRouter } from "next/navigation";
import { useState } from "react";
import { createProduct } from "@/lib/api";
import Button from "@/components/ui/Button";
import Input from "@/components/ui/Input";
import FormField from "@/components/ui/FormField";

export default function ProductForm() {
  const router = useRouter();
  const [name, setName] = useState("");
  const [description, setDescription] = useState("");
  const [price, setPrice] = useState<string>("");
  const [error, setError] = useState<string | null>(null);
  const [loading, setLoading] = useState(false);

  async function onSubmit(e: React.FormEvent) {
    e.preventDefault();
    setError(null);
    setLoading(true);
    try {
      const payload = { name: name.trim(), description: description.trim(), price: Number(price) };
      if (!payload.name || isNaN(payload.price)) {
        throw new Error("Ad ve fiyat zorunludur");
      }
      await createProduct(payload);
      router.push("/products");
      router.refresh();
    } catch (err: any) {
      setError(err?.message ?? "Hata oluştu");
    } finally {
      setLoading(false);
    }
  }

  return (
    <form onSubmit={onSubmit} className="space-y-4 max-w-sm">
      <FormField label="Ürün Adı">
        <Input value={name} onChange={(e) => setName(e.target.value)} placeholder="Örn. Klavye" />
      </FormField>
      <FormField label="Ürün Açıklaması">
        <Input value={description} onChange={(e) => setDescription(e.target.value)} placeholder="Örn. Açıklama ekleyiniz" />
      </FormField>
      <FormField label="Fiyat">
        <Input type="number" value={price} onChange={(e) => setPrice(e.target.value)} placeholder="Örn. 1299.90" />
      </FormField>
      {error ? <p className="text-red-600 text-sm">{error}</p> : null}
      <Button type="submit" disabled={loading}>{loading ? "Kaydediliyor..." : "Kaydet"}</Button>
    </form>
  );
}
