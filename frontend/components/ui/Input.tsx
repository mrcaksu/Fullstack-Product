import type { InputHTMLAttributes } from "react";

export default function Input({ className = "", ...rest }: InputHTMLAttributes<HTMLInputElement>) {
  return (
    <input
      className={`border rounded px-3 py-2 w-full outline-none focus:ring ${className}`}
      {...rest}
    />
  );
}
