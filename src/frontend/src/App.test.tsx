import { render, screen } from "@testing-library/react";
import { expect, test } from "vitest";
import App from "./App";

test("identifies the project and clearly states that business features are unavailable", () => {
  render(<App />);

  expect(
    screen.getByRole("heading", { level: 1, name: "Tienda Web Configurable" }),
  ).toBeInTheDocument();
  expect(screen.getByText(/funcionalidades de negocio todavía/)).toBeVisible();
});
