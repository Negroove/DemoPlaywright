using Microsoft.Playwright.NUnit;
using DemoPlaywright.Pages;

namespace DemoPlaywright.Tests.Frontend;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
    [Test]
    public async Task ValidateSearchResultsContent()
    {
        var homePage = new HomePage(Page);
        await homePage.navigateAsync();
        await homePage.searchProductAsync("iPhone");

        var searchResultsPage = new SearchResultsPage(Page);
        Assert.IsTrue(await searchResultsPage.AreResultsVisibleAsync(), "Los resultados no son visibles.");
        var productTitles = await searchResultsPage.GetAllProductTitlesAsync();

        Assert.IsTrue(productTitles.All(title => title.Contains("iPhone", StringComparison.OrdinalIgnoreCase)),
                      "Algunos títulos no contienen la palabra 'iPhone'.");
    }
}
