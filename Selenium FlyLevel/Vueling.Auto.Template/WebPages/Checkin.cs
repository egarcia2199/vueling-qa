using Flylevel.Auto.Template.SetUp;
using Flylevel.Auto.Template.WebPages.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flylevel.Auto.Template.WebPages
{
    public class Checkin : CommonPage
    {

        public string cityOrigin = "Barcelona";
        public string cityDestination = "Santiago de Chile";
        public int dayOW = 3;
        public int dayRT = 12;
        public string orgMonth = "septiembre";

        public Checkin(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();

        protected IWebElement fieldOW
        {
         
            get { return WebDriver.FindElementByXPath("//div[@data-field='origin']"); }
        }

        protected IWebElement selectCityOW
        {
            
            get { return WebDriver.FindElementByXPath($"//div[@class='city' and text()='{cityOrigin}']"); }
        }

        protected IWebElement inputCityOW
        {

            get { return WebDriver.FindElementByXPath("//input[@placeholder='¿Desde dónde?']"); }
        }



        protected IWebElement fieldRT
        {

            get { return WebDriver.FindElementByXPath("//div[@data-field='destination']"); }
        }

        protected IWebElement selectCityRT
        {

            get { return WebDriver.FindElementByXPath($"//div[@class='city' and text()='{cityDestination}']"); }
        }

        protected IWebElement inputCityRT
        {

            get { return WebDriver.FindElementByXPath("//input[@placeholder='¿A dónde?']"); }
        }

        protected IWebElement selectTypedCityRT
        {
            get
            {  return WebDriver.FindElementByXPath("//div[@data-field='destination']//div[@class='city' and text()='"+cityDestination+"']"); }

        }

        protected IWebElement btnNextMonth
        {

            get {  return WebDriver.FindElementByClassName("datepicker__next-action"); }
            
        }

        private IWebElement firstDayAvailable
        {
            get { return WebDriver.FindElementByXPath("((//div[@class='datepicker__months']/section[1]//div[@class='datepicker__day is-available '])[1])"); }
        }
        private IWebElement ADT
        {
            get { return WebDriver.FindElementByXPath("//div[@data-field='adult']//div[@class='js-plus']"); }
        }

        private IWebElement CHD
        {
            get { return WebDriver.FindElementByXPath("//div[@data-field='child']//div[@class='js-plus']"); }
        }

        private IWebElement INF
        {
            get { return WebDriver.FindElementByXPath("//div[@data-field='infant']//div[@class='js-plus']"); }
        }

        protected IWebElement CalendarDayOW
        {

            get { return WebDriver.FindElementByXPath("//div[@class='day' and text()='"+dayOW+"']"); }
        }

        protected IWebElement CalendarDayRT
        {

            get { return WebDriver.FindElementByXPath("//div[@class='day' and text()='" + dayRT +"']"); }
        }


        protected IWebElement CheckPassengers
        {

            get { return WebDriver.FindElementByXPath("//button[text() = 'LISTO']"); }
        }

        protected IWebElement FindFlights
        {

            get { return WebDriver.FindElementById("searcher_submit_buttons"); }
        }



        public Checkin BookingFlight()
        {
            WebDriver.FindElement(By.Id("ensCloseBanner")).Click();
            Thread.Sleep(500);
            fieldOW.Click();
            inputCityOW.SendKeys(cityOrigin);
            selectCityOW.Click();
            
            fieldRT.Click();
            inputCityRT.SendKeys(cityDestination);
            selectTypedCityRT.Click();

            Thread.Sleep(500);
            CalendarDayOW.Click();
            CalendarDayRT.Click();

            CheckPassengers.Click();
            FindFlights.Click();

            return this;
        }


        public Checkin BookingFlight_BCN_SCL()
        {

            WebDriver.FindElement(By.Id("ensCloseBanner")).Click();
            Thread.Sleep(500);
            fieldOW.Click();
            inputCityOW.SendKeys(cityOrigin);
            selectCityOW.Click();

            fieldRT.Click();
            inputCityRT.SendKeys(cityDestination);
            selectTypedCityRT.Click();

            Thread.Sleep(500);

            SelectMonth(orgMonth);  
            firstDayAvailable.Click();

            CalendarDayRT.Click();

            ADT.Click();
            ADT.Click();
            CHD.Click();
            INF.Click();
            Thread.Sleep(1000);
            CheckPassengers.Click();
            FindFlights.Click();

            return this;
        }

        public Checkin SelectMonth(string month)
        {

            while (WebDriver.FindElementByXPath("//div[@class='datepicker__months']/section[1]//span[@class='month']").Text != orgMonth.ToUpper())
            {
                btnNextMonth.Click();
            }
            return this;

        }


    }
}
