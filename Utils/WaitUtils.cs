using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPlaywright.Utils
{
    public class WaitUtils
    {
        private const int DefaultTimeout = 30000; // son 30 seg


        // Espera a que un elemento este visible 
        public static async Task WaitForElementVisibleAsync(ILocator locator)
        {
            await locator.WaitForAsync(new LocatorWaitForOptions
            {
                State = WaitForSelectorState.Visible,
                Timeout = DefaultTimeout
            });
        }

        public static async Task WaitForElementEnabledAsync(ILocator locator)
        {
            await locator.WaitForAsync(new LocatorWaitForOptions
            {
                State = WaitForSelectorState.Attached,
                Timeout = DefaultTimeout
            });
            bool isEnabled = await locator.IsEnabledAsync();

            while (!isEnabled)
            {
                await Task.Delay(100);
                isEnabled = await locator.IsEnabledAsync();
            }
        }

    }
}
