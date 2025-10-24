import type { ButtonHTMLAttributes } from "react";

export default function Button({ className = "", ...rest }: ButtonHTMLAttributes<HTMLButtonElement>) {
  return (
    <button
      className={`rounded px-4 py-2 border text-sm transition hover:bg-gray-100 disabled:opacity-60 ${className}`}
      {...rest}
    />
  );
}