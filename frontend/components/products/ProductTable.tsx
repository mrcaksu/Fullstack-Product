import { Product } from "@/lib/types";
import ProductRow from "./ProductRow";

export default function ProductTable({ items }: { items: Product[] }) {
  if (!items.length) return <p className="text-gray-600">Henüz ürün yok.</p>;
  return (
    <table className="shadow-sm">
      <thead className="bg-gray-50">
        <tr className="text-left">
          <th className="p-2">ID</th>
          <th className="p-2">Ad</th>
          <th className="p-2">Açıklama</th>
          <th className="p-2">Fiyat</th>
          <th className="p-2">Oluşturulma Tarihi</th>
        </tr>
      </thead>
      <tbody>{items.map((p) => <ProductRow key={p.id} p={p} />)}</tbody>
    </table>
  );
}
