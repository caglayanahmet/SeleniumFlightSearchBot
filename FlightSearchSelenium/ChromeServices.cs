using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FlightSearchSelenium
{
    public static class ChromeServices
    {
        public static void ClickElement(IWebDriver driver, string xPath)
        {
            var button = driver.FindElement(By.XPath(xPath));
            button.Click();
            Thread.Sleep(500);
        }

        public static void ClickElement(IWebDriver driver, string xPath, string day)
        {
            var button = driver.FindElement(By.XPath("/html/body/div[18]/div[1]/table/tbody/tr/td/a[contains(text()," + day + ")]"));
            button.Click();
            Thread.Sleep(500);
        }

        public static void ClickAndSendKey(IWebDriver driver, string xPath, string text)
        {
            var inputArea = driver.FindElement(By.XPath(xPath));
            inputArea.Click();
            inputArea.Clear();
            inputArea.SendKeys(text);
            Thread.Sleep(100);
            inputArea.SendKeys(Keys.Tab);
            Thread.Sleep(400);
        }

        public static void ScrollThreeTimes(IWebDriver driver)
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,950);");
            Thread.Sleep(1500);
            js.ExecuteScript("window.scrollBy(0,950);");
            Thread.Sleep(1500);
            js.ExecuteScript("window.scrollBy(0,950);");
        }

        public static void SelectDateFromDatePicker(IWebDriver driver ,string xPathMonthText, string month, string xPathArrow)
        {
            while (true)
            {
                string monthText = driver.FindElement(By.XPath(xPathMonthText)).Text;
                if (monthText == month)
                {
                    break;
                }
                driver.FindElement(By.XPath(xPathArrow)).Click();
            }
            Thread.Sleep(500);
        }

        public static ReadOnlyCollection<IWebElement> PopulateFlightCollections(IWebDriver driver, string xpath)
        {
            ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.XPath(xpath));
            return elements;
        }

        
    }
}
