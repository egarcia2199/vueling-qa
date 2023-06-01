using Demoblaze.Auto.Template.SetUp;
using Demoblaze.Auto.Template.WebPages.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Demoblaze.Auto.Template.WebPages
{
    public class LogIn : CommonPage
    {

        public LogIn(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();

        protected IWebElement btnSubmitLogin
        {

            get { return WebDriver.FindElementByXPath("//button[text() = 'Log in']"); }
        }

        private IWebElement fieldUsername
        {

            get { return WebDriver.FindElementById("loginusername"); }
        }


        private IWebElement fieldPassword
        {

            get { return WebDriver.FindElementById("loginpassword"); }
        }

    

        public LogIn LoginUser(string username)
        {

            fieldUsername.SendKeys(username);
            fieldPassword.SendKeys("1");
            btnSubmitLogin.Click();
    
            return this;
            
        }


    }
}
