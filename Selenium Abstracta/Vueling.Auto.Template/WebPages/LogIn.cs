using Abstracta.Auto.Template.SetUp;
using Abstracta.Auto.Template.WebPages.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Abstracta.Auto.Template.WebPages
{
    public class LogIn : CommonPage
    {

        public LogIn(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();

        private IWebElement btnSubmitLogin
        {

            get { return WebDriver.FindElementByXPath("//input[@type='submit'] "); }
        }

        private IWebElement fieldUsername
        {

            get { return WebDriver.FindElementById("input-email"); }
        }


        private IWebElement fieldPassword
        {

            get { return WebDriver.FindElementById("input-password"); }
        }

    

        public LogIn LoginUser(string username)
        {

            fieldUsername.SendKeys(username);
            fieldPassword.SendKeys("1234");
            Thread.Sleep(500);
            btnSubmitLogin.Click();
    
            return this;
            
        }


    }
}
