using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Abstracta.Auto.Template.SetUp;
using Abstracta.Auto.Template.WebPages.Base;
using Abstracta.Auto.Template.Common;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using Abstracta.Auto.Template.Tests;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace Abstracta.Auto.Template.WebPages
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

            get { return WebDriver.FindElementByXPath("//a[text() = 'Your Store']"); } }

        private IWebElement btnContact {

            get { return WebDriver.FindElementByXPath("//a[text() = 'Contact us']"); } }

        private IWebElement btnAboutUs {

            get { return WebDriver.FindElementByXPath("//a[text() = 'About us']"); } }

        private IWebElement btnCart
        {

            get { return WebDriver.FindElementByXPath("//span[text() = 'Shopping Cart']"); }
        }

        private IWebElement btnAccount
        {

            get { return WebDriver.FindElementByXPath("//a[text() = 'My Account']"); }
        }

        private IWebElement btnCheckConfig
        {

            get { return WebDriver.FindElementById("details-button"); }

        }

        private IWebElement btnCheckConfig2
        {

            get { return WebDriver.FindElementById("proceed-link"); }

        }

        private IWebElement btnLogout
        {

            get { return WebDriver.FindElementByXPath("//a[text() = 'Logout']"); }
        }



        private IWebElement logoSponsor(string sponsorName)
        {
            return WebDriver.FindElementByXPath("//*[@id='carousel0']/div/div[*]/img[@alt='" + sponsorName + "']");
        }


        protected IWebElement swiper
        {

            get { return WebDriver.FindElementByXPath("//div[@class='swiper-slide text-slide']"); }
        }


        public HomePage GoToHomePage()
        {

            btnHome.Click();

            return this;
        }


        public HomePage GoToLoginPage()
        {

            btnAccount.Click();
            btnCheckConfig.Click();
            btnCheckConfig2.Click();

            return this;

        }


        public HomePage GoToCart()
        {
            btnCart.Click();
            return this;
        }

        public HomePage LogOut()
        {
            btnAccount.Click();
            btnLogout.Click();
            return this;
        }

        

        public HomePage CheckSponsor(string sponsorName)
        {
            Assert.IsNotNull(logoSponsor(sponsorName));
            Console.WriteLine(sponsorName+" se encuentra en el swiper de sponsors");
            return this;
        }

    }
}
