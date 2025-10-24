"use client";

import { Product } from "@/lib/types";
import Link from "next/link";
import Button from "@/components/ui/Button";
import ProductTable from "./ProductTable";

export default function ProductList({ products }: { products: Product[] }) {
  return (
    <main className="space-y-4">
      <div className="flex items-center justify-between">
        <h1>Ürünler</h1>
        <Link href="/products/new"><Button>Yeni Ürün</Button></Link>
      </div>
      <ProductTable items={products} />
    </main>
  );
}
