using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NopCommerce.Core.Extensions
{
    public static class Extensions
    {
        private static WebExecutionTool Browser => WebExecutionTool.Instance;

        public static void WaitForPageToLoad()
        {
            Browser.GetWebExecutionTool().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }
    }
}
