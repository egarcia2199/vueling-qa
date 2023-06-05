using Abstracta.Auto.Template.Common;
using Abstracta.Auto.Template.SetUp;
using Abstracta.Auto.Template.WebPages;
using Abstracta.Auto.Template.WebPages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Abstracta.Auto.Template.WebPages
{
    public class Categories : CommonPage
    {

        public Categories(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();


        protected IWebElement ProductName(string prodName)
        {

            return WebDriver.FindElementByXPath("//h4/a[text()='" + prodName+"']"); 
        }


        private IWebElement btnAddToCart
        {

            get { return WebDriver.FindElementById("button-cart"); }
        }

        private IWebElement btnCart
        {

            get { return WebDriver.FindElementById("cart-total"); }
        }

    

        private IWebElement SuccessBuy
        {

            get { return WebDriver.FindElementByXPath($"//div[@class='alert alert-success alert-dismissible']"); }
        }

        protected By _SuccessBuy
        {

            get { return By.XPath("//div[@class='alert alert-success alert-dismissible']"); }
        }


        public Categories EnterCategoryWithDropDown(string cat)
        {
            WebDriver.FindElementByXPath("//a[text() = '" + cat + "']").Click();
            WebDriver.FindElementByXPath("//a[text() = 'Show All " + cat + "']").Click();
            
            return this;
        }

        public Categories EnterCategory(string cat)
        {
            WebDriver.FindElementByXPath("//a[text() = '" + cat + "']").Click();

            return this;
        }


        public Categories BuyProduct(string prodName)
        {
            ProductName(prodName).Click();
            btnAddToCart.Click();
            //new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsVisible(_SuccessBuy));
            btnCart.Click();

            return this;

        }


        

    }
}
