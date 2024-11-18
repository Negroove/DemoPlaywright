using DemoPlaywright.Utils;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPlaywright.Pages
{
    public class SearchResultsPage
    {
        private readonly IPage page;

        #region Componentes 
        private ILocator ResultsList => page.Locator("//section[@class='ui-search-results ui-search-results--without-disclaimer']");
        private ILocator ProductTitles => page.Locator("//section[@class='ui-search-results ui-search-results--without-disclaimer']//h2");
        #endregion

        public SearchResultsPage(IPage page)
        {
            this.page = page;
        }

        // Verificar si los resultados son visibles
        public async Task<bool> AreResultsVisibleAsync()
        {
            await WaitUtils.WaitForElementVisibleAsync(ResultsList);
            return await ResultsList.IsVisibleAsync();
        }

        // Obtener todos los títulos de los productos
        public async Task<List<string>> GetAllProductTitlesAsync()
        {
            // Recuperar todas las líneas de texto dentro de los elementos seleccionados
            var titles = await ProductTitles.AllInnerTextsAsync();
            return new List<string>(titles); // Convertir a una lista si es necesario
        }

    }
}
