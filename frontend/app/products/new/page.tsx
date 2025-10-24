import ProductForm from "@/components/products/ProductForm";

export default function NewProductPage() {
  return (
    <main className="p-6 space-y-4">
      <h1 className="text-2xl font-semibold">Yeni Ürün Ekle</h1>
      <ProductForm />
    </main>
  );
}
