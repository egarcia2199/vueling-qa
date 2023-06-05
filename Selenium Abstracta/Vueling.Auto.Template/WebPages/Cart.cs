using Abstracta.Auto.Template.SetUp;
using Abstracta.Auto.Template.WebPages.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Abstracta.Auto.Template.WebPages
{
    public class Cart : CommonPage
    {
        public Cart(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();

        public HomePage hp;
        

        protected IWebElement FirstItem (string item1)
        {

           return WebDriver.FindElementByXPath($"//td[text()='" + item1 + "']");
           
        }

        protected IWebElement SecondItem(string item2)
        {

          return WebDriver.FindElementByXPath($"//td[text()='" + item2 + "']");
           
        }
        protected IWebElement btnCheckout
        {

            get { return WebDriver.FindElementByXPath("//strong[text()=' Checkout']"); }
        }


        protected IWebElement orderFirstName
        {

            get { return WebDriver.FindElementById("input-payment-firstname"); }
        }

        protected IWebElement orderLastName
        {

            get { return WebDriver.FindElementById("input-payment-lastname"); }
        }

        protected IWebElement orderPostcode
        {

            get { return WebDriver.FindElementById("input-payment-postcode"); }
        }

        protected IWebElement orderAddress
        {

            get { return WebDriver.FindElementById("input-payment-address-1"); }
        }

        protected IWebElement orderCity
        {

            get { return WebDriver.FindElementById("input-payment-city"); }
        }

        protected IWebElement orderCountry
        {

            get { return WebDriver.FindElementByXPath("//select[@id='input-payment-country']/option[@value='195']"); }
        }

        protected IWebElement orderRegion
        {

            get { return WebDriver.FindElementByXPath("//select[@id='input-payment-zone']/option[@value='2979']"); }
        }

        protected IWebElement orderNewAddress
        {

            get { return WebDriver.FindElementByXPath("//input[@value = 'new']"); }
        }

        protected IWebElement orderContinueDelivery
        {

            get { return WebDriver.FindElementById("button-shipping-address"); }
        }

        protected IWebElement orderContinue
        {

            get { return WebDriver.FindElementById("button-payment-address"); }
        }

        protected IWebElement orderContinuePayment
        {

            get { return WebDriver.FindElementById("button-payment-method"); }
        }

        protected IWebElement orderConfirm
        {

            get { return WebDriver.FindElementById("button-confirm"); }
        }

        protected IWebElement agreeTerms
        {

            get { return WebDriver.FindElementByXPath("//input[@value = '1']"); }
        }

        protected IWebElement AcceptPurchase
        {

            get { return WebDriver.FindElementByXPath("//a[text() = 'Continue']"); }
        }

        private IWebElement btnAccount
        {

            get { return WebDriver.FindElementByXPath("//a[text() = 'My Account']"); }
        }

        private IWebElement btnLogout
        {

            get { return WebDriver.FindElementByXPath("//a[text() = 'Logout']"); }
        }


        protected IWebElement btnDeleteItem(string itemName)
        {

            return WebDriver.FindElementByXPath("//table[@class='table table-bordered']//a[text()='" + itemName + "']/following::button[contains(@class, 'btn-danger')][1]"); 
        }




        public Cart DeleteItem(string itemName) {

            btnDeleteItem(itemName).Click();

            return this;
        }

        public Cart Buy()
        {
            
            btnCheckout.Click();
            orderNewAddress.Click();
            orderFirstName.SendKeys("Test");
            orderLastName.SendKeys("0001");
            orderAddress.SendKeys("Calle Prueba 1");
            orderPostcode.SendKeys("08000");
            orderCity.SendKeys("bcn");
            ScrollDownPage();
            orderCountry.Click();  
            orderRegion.Click();
            orderContinue.Click();
            ScrollDownPage();

            agreeTerms.Click();
            orderContinuePayment.Click();
            orderConfirm.Click();
            
            
            return this;
        }

        public void ScrollDownPage()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)WebDriver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");

        }
        


    }
}
