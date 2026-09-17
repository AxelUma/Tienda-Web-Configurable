import { expect, test } from "@playwright/test";

test("the production build loads and explains its current scope", async ({ page }) => {
  await page.goto("/");
  await expect(page).toHaveTitle("Tienda Web Configurable");
  await expect(
    page.getByRole("heading", { level: 1, name: "Tienda Web Configurable" }),
  ).toBeVisible();
  await expect(page.getByText(/funcionalidades de negocio todavía/)).toBeVisible();
});
