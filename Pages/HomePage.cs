using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPlaywright.Pages
{
    public class HomePage
    {
        private readonly IPage page;

        private ILocator txtSearch => page.GetByPlaceholder("Buscar productos, marcas y má");

        public HomePage(IPage page)
        {
            this.page = page;
        }

        public async Task navigateAsync()
        {
            await page.GotoAsync("https://www.mercadolibre.com.ar/");
        }

        public async Task searchProductAsync(string productName)
        {
            await txtSearch.FillAsync(productName);
            await page.Keyboard.PressAsync("Enter");
        }
    }
}
