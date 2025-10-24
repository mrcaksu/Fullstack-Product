'"use client";'
import { Product } from "@/lib/types";

export default function ProductRow({ p }: { p: Product }) {
  return (
    <tr className="border-b last:border-none">
      <td className="p-2 font-mono text-[11px]">{p.id}</td>
      <td className="p-2">{p.name}</td>
      <td className="p-2">{p.description}</td>
      <td className="p-2">{p.price}</td>
      <td className="p-2 text-gray-500 text-sm">{new Date(p.createdTime).toLocaleString()}</td>
    </tr>
  );
}
