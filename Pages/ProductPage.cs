using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DemoPlaywright.Pages
{
    public class ProductPage
    {
        private readonly IPage page;

        private ILocator ProductTitles => page.Locator("//section[@class='ui-search-results ui-search-results--without-disclaimer']//h2");
        
        public ProductPage ( IPage page)
        {
            this.page = page;
        }

        public async Task<List<string>> GetAllProductTitlesAsync()
        {
            return (List<string>)await ProductTitles.AllInnerTextsAsync();
        }

    }
}
