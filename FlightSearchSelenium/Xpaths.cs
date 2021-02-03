using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSearchSelenium
{
    public class Xpaths
    {
        public string WebSiteUrl => "https://www.turna.com/";
        public string LanguageButton => "/html/body/header/nav/div[2]/ul/li[1]/label";
        public string EnglishLanguageButton => "/html/body/header/nav/div[2]/ul/li[1]/form/ul/li[2]/a";
        public string ElementFrom => "/html/body/div[2]/section[2]/form/div[1]/div/div[2]/div[1]/div[1]/input[1]";
        public string ElementTo => "/html/body/div[2]/section[2]/form/div[1]/div/div[2]/div[1]/div[3]/input[1]";
        public string ElementDepartureDate => "/html/body/div[2]/section[2]/form/div[1]/div/div[2]/div[2]/div[1]/input[1]";
        public string MonthText => "/html/body/div[18]/div[1]/div/div/span[1]";
        public string ArrowIcon => "/html/body/div[18]/div[2]/div/a";

        public string SearchButton => "/html/body/div[2]/section[2]/form/div[1]/div/div[2]/div[3]";
        public string DepartureDate => "/html/body/div[18]/div[1]/table/tbody/tr/td/a[contains(text()," ;
        public string FlightPriceElements =>
            "/html/body/div[2]/div[7]/div[2]/div[3]/div/div/div[1]/span[@class='money-val']";
        public string FlightCompanyElements =>
            "/html/body/div[2]/div[7]/div[2]/div[3]/div/div/div/span[@class = 'airline-name']";
        public string FlightTimeElements => "/html/body/div[2]/div[7]/div[2]/div[3]/div/div/div[2]/div[1]/strong";


    }
}

//+day + ")]"