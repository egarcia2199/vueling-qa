using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Demoblaze.Auto.Template.SetUp;
using Demoblaze.Auto.Template.WebPages.Base;
using Demoblaze.Auto.Template.Common;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using Demoblaze.Auto.Template.Tests;

namespace Demoblaze.Auto.Template.WebPages
{
    public class HomePage : CommonPage
    {
        public HomePage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();


        public string itemLaptop = "MacBook air";
        public string itemPhone = "Nexus 6";
        public string itemMonitor = "ASUS Full HD";


        private IWebElement btnHome {

            get { return WebDriver.FindElementByXPath("//a[text() = 'Home ']"); } }

        private IWebElement btnContact {

            get { return WebDriver.FindElementByXPath("//a[text() = 'Contact us']"); } }

        private IWebElement btnAboutUs {

            get { return WebDriver.FindElementByXPath("//a[text() = 'About us']"); } }

        private IWebElement btnCart {

            get { return WebDriver.FindElementById("cartur"); } }

        private IWebElement btnLogin {

            get { return WebDriver.FindElementById("login2"); } }

        private IWebElement btnLogout
        {

            get { return WebDriver.FindElementById("logout2"); }
        }

        private IWebElement btnSignup {

            get { return WebDriver.FindElementById("signin2"); } }


        private IWebElement catLaptops {

            get { return WebDriver.FindElementByXPath("//a[text() = 'Laptops']"); } }

        private IWebElement catPhones
        {

            get { return WebDriver.FindElementByXPath("//a[text() = 'Phones']"); }
        }

        private IWebElement catMonitors
        {

            get { return WebDriver.FindElementByXPath("//a[text() = 'Monitors']"); }
        }


        private IWebElement LaptopItem {

            get { return WebDriver.FindElementByXPath("//a[text() = '"+itemLaptop+"']"); } }

        private IWebElement PhoneItem
        {

            get { return WebDriver.FindElementByXPath("//a[text() = '" + itemPhone + "']"); }
        }

        private IWebElement MonitorItem
        {

            get { return WebDriver.FindElementByXPath("//a[text() = '" + itemMonitor + "']"); }
        }

        private IWebElement NameOfUser
        {

            get { return WebDriver.FindElementById("nameofuser"); }
        }

        protected By _NameOfUser
        {

            get { return By.Id("nameofuser"); }
        }


        private IWebElement AddToCart {

            get { return WebDriver.FindElementByXPath("//a[text() = 'Add to cart']"); }
        }

        public HomePage GoToHomePage()
        {
            btnHome.Click();
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
         public HomePage GoToLoginPage()
        {
       
            btnLogin.Click();
            return this;

        }

        

        public HomePage ClickCategoryLaptops()
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsVisible(_NameOfUser));
          //  Assert.AreEqual(NameOfUser.Text,"Welcome " + hpt.username1 +"");
            catLaptops.Click();

            return this;

        }

        public HomePage ClickCategoryPhones()
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsVisible(_NameOfUser));
         //   Assert.AreEqual(NameOfUser.Text, "Welcome " + hpt.username2 +"");
            catPhones.Click();

            return this;

        }

        public HomePage ClickCategoryMonitors()
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsVisible(_NameOfUser));
        //    Assert.AreEqual(NameOfUser.Text, "Welcome " + hpt.username3 + "");
            catMonitors.Click();

            return this;

        }


        public HomePage SelectLaptop()
        {
            LaptopItem.Click();
            AddToCart.Click();
            btnCart.Click();
            return this;
        }

        public HomePage SelectPhone()
        {
            PhoneItem.Click();
            AddToCart.Click();
            btnCart.Click();
            return this;
        }

        public HomePage SelectMonitor()
        {
            MonitorItem.Click();
            AddToCart.Click();
            btnCart.Click();
            return this;
        }

        public HomePage GoToCart()
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsVisible(_NameOfUser));
            btnCart.Click();
            return this;
        }

        public HomePage LogOut()
        {
            btnLogout.Click();
            return this;
        }

    }
}
