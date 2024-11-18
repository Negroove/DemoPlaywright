using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;


namespace DemoPlaywright.Tests.Frontend;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
    [Test]
    public async Task MyTest()
    {
        await Page.GetByPlaceholder("Search").ClickAsync();
        await Page.GetByPlaceholder("Search").FillAsync("iphone");
        await Page.GetByRole(AriaRole.Button, new() { Name = "" }).ClickAsync();
        await Page.GetByText("iPhone", new() { Exact = true }).ClickAsync();
    }

    [SetUp]
    public async Task OpenBrowser()
    {
        await Page.GotoAsync("https://opencart.abstracta.us/");

    }
}
