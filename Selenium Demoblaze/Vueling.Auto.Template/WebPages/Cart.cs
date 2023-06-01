using Demoblaze.Auto.Template.SetUp;
using Demoblaze.Auto.Template.WebPages.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demoblaze.Auto.Template.WebPages
{
    public class Cart : CommonPage
    {
        public Cart(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();

        public HomePage hp;
        public string itemName;

        protected IWebElement CheckName
        {

            get { return WebDriver.FindElementByXPath("//tr[@class='success']/td[text()='" + itemName + "']/../td/a"); }
        }
        
    
        protected IWebElement btnOrder
        {

            get { return WebDriver.FindElementByXPath("//button[text() = 'Place Order']"); }
        }

        protected IWebElement orderName
        {

            get { return WebDriver.FindElementById("name"); }
        }

        protected IWebElement orderCountry
        {

            get { return WebDriver.FindElementById("country"); }
        }

        protected IWebElement orderCity
        {

            get { return WebDriver.FindElementById("city"); }
        }

        protected IWebElement orderCreditCard
        {

            get { return WebDriver.FindElementById("card"); }
        }


        protected IWebElement orderMonth
        {

            get { return WebDriver.FindElementById("month"); }
        }

        protected IWebElement orderYear
        {

            get { return WebDriver.FindElementById("year"); }
        }


        protected IWebElement orderPurchase
        {

            get { return WebDriver.FindElementByXPath("//button[text() = 'Purchase']"); }
        }

        protected IWebElement AcceptPurchase
        {

            get { return WebDriver.FindElementByXPath("//button[text() = 'OK']"); }
        }

       
        //public Cart CheckIfExists(string itemName)
        //{
        //    WebDriver.FindElementByXPath("//tr[@class='success']/td[text()='" + itemName + "']/../td/");
        //    Assert.AreEqual(itemName, hp.itemLaptop, "Coincide con el item de Laptop");
        //    Assert.AreEqual(itemName, hp.itemMonitor, "Coincide con el item de Monitor");
        //    Assert.AreEqual(itemName, hp.itemPhone, "Coincide con el item de Phone");
        //    return this;
        //}

        public Cart DeleteItem(string itemName) {

            WebDriver.FindElementByXPath("//tr[@class='success']/td[text()='" +itemName+ "']/../td/a").Click();

            return this;
        }

        public Cart Buy()
        {
            
            btnOrder.Click();
            orderName.SendKeys("Test");
            orderCountry.SendKeys("spn");
            orderCity.SendKeys("bcn");
            orderCreditCard.SendKeys("3243443242");
            orderMonth.SendKeys("06");
            orderYear.SendKeys("23");
            orderPurchase.Click();
            Thread.Sleep(1000);
            AcceptPurchase.Click();

            return this;
        }


    }
}
