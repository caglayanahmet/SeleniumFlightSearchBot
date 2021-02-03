using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Keys = OpenQA.Selenium.Keys;

namespace FlightSearchSelenium
{
    public partial class FlightSearch : Form
    {
        public FlightSearch()
        {
            InitializeComponent();
        }
       
        private Thread thread;
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            thread = new Thread(StartSearch);
            thread.Start();
        }
        
        private void StartSearch()
        {
            string departureCity = txtFrom.Text;
            string arrivalCity = txtTo.Text;
            string month = cmbMonth.Text;
            string day = cmbDay.Text;

            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            IWebDriver driver = new ChromeDriver(service);

            Xpaths xpaths = new Xpaths();
            driver.Navigate().GoToUrl(xpaths.WebSiteUrl);
            Thread.Sleep(2000);
            ChromeServices.ClickElement(driver,xpaths.LanguageButton);
            ChromeServices.ClickElement(driver, xpaths.EnglishLanguageButton);
            ChromeServices.ClickAndSendKey(driver,xpaths.ElementFrom,departureCity);
            ChromeServices.ClickAndSendKey(driver, xpaths.ElementTo,arrivalCity);
            ChromeServices.ClickElement(driver,xpaths.ElementDepartureDate);
            ChromeServices.SelectDateFromDatePicker(driver,xpaths.MonthText,month,xpaths.ArrowIcon);
            ChromeServices.ClickElement(driver,xpaths.DepartureDate,day);
            ChromeServices.ClickElement(driver,xpaths.SearchButton);
            Thread.Sleep(3000);
            ChromeServices.ScrollThreeTimes(driver);

            var flightPriceElements = ChromeServices.PopulateFlightCollections(driver, xpaths.FlightPriceElements);
            var flightCompanyElements = ChromeServices.PopulateFlightCollections(driver, xpaths.FlightCompanyElements);
            var flightTimeElements = ChromeServices.PopulateFlightCollections(driver, xpaths.FlightTimeElements);
            
            for (int i = 0; i < flightPriceElements.Count; i++)
            {
                listBox1.Items.Add( (i+1)+") company: "+ flightCompanyElements[i].Text + " time: " + flightTimeElements[i].Text + " price: " + flightPriceElements[i].Text);
                Thread.Sleep(100);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
