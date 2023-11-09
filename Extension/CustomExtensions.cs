using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace November2023SpecFlowPOM.Extension
{
    public class CustomExtensions
    {

        public static class WebDriverExtensions
        {
            private static readonly TimeSpan DefaultWaitTime = TimeSpan.FromSeconds(60);

            public static void WaitForAlertBy(IWebDriver driver)
            {
                new WebDriverWait(driver, DefaultWaitTime).Until(ExpectedConditions.AlertIsPresent());
            }

            public static void WaitForElementBy(IWebDriver driver, By by)
            {
                new WebDriverWait(driver, DefaultWaitTime).Until(ExpectedConditions.ElementIsVisible(by));
            }

            public static void WaitForElementTextBy(IWebDriver driver, By by, string text)
            {
                new WebDriverWait(driver, DefaultWaitTime).Until(
                    ExpectedConditions.TextToBePresentInElementLocated(by, text));
            }

            public static void WaitForElementByWithoutSeleniumExtras(IWebDriver driver, By by)
            {
                new WebDriverWait(driver, DefaultWaitTime).Until(d => d.FindElement(by));
            }

            public static void SelectFromDropDownByText(IWebElement element, string text)
            {
                SelectElement select = new SelectElement(element);
                select.SelectByText(text);
            }

            public static void SelectFromDropDownByIndex(IWebElement element, int index)
            {
                SelectElement select = new SelectElement(element);
                select.SelectByIndex(index);
            }

            public static void SelectFromDropDownByValue(IWebElement element, string value)
            {
                SelectElement select = new SelectElement(element);
                select.SelectByValue(value);
            }

            public static IJavaScriptExecutor ScrollIntoViewAndClickViaJs(IWebDriver driver, IWebElement element)
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView(true); arguments[0].click();", element);
                return js;
            }

            public static void ScrollAndClickUsingActions(IWebDriver driver, IWebElement element)
            {
                GetActions(driver).MoveToElement(element).Click().Perform();
            }

            public static void ScrollIntoViewUsingActions(IWebDriver driver, IWebElement element)
            {
                GetActions(driver).MoveToElement(element).Perform();
            }

            public static void MoveToElementUsingActions(IWebDriver driver, IWebElement element)
            {
                GetActions(driver).MoveToElement(element).Perform();
                Thread.Sleep(TimeSpan
                    .FromSeconds(2)); // Consider replacing Thread.Sleep with a more efficient waiting strategy.
            }

            public static IAlert ClickOnAlertPopups(IWebDriver driver)
            {
                return driver.SwitchTo().Alert();
            }

            private static Actions GetActions(IWebDriver driver)
            {
                return new Actions(driver);

            }


        }
    }


}