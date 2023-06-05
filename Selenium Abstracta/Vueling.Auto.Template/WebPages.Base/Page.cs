using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Abstracta.Auto.Template.SetUp;
using System;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Text.RegularExpressions;

namespace Abstracta.Auto.Template.WebPages.Base
{
    public class Page
    {
        private readonly int _waitTimeout;
        protected int WaitTimeout { get { return _waitTimeout; } }

        private readonly int _paymentTimeout;
        protected int PaymentTimeout { get { return _paymentTimeout; } }

        private readonly int _pageLoadTimeout;
        protected int PageLoadTimeout { get { return _pageLoadTimeout; } }

        protected readonly ISetUpWebDriver SetUpWebDriverFactory;
        protected readonly RemoteWebDriver WebDriver;
        protected IJavaScriptExecutor Jse2;
        protected Actions act;

        /* constructor of the Page which will be inherited by all other Pages */
        /* no additional setup of webDriver necessary for the other pages, they will inherit the contructor from Page */
        public Page(ISetUpWebDriver setUpWebDriver)
        {
            SetUpWebDriverFactory = setUpWebDriver;
            WebDriver = setUpWebDriver.GetSetUpWebDriver();
            Jse2 = (IJavaScriptExecutor)WebDriver;
            _waitTimeout = Convert.ToInt16(TestContext.Parameters["waitTimeout"]);
            _paymentTimeout = Convert.ToInt16(TestContext.Parameters["paymentTimeout"]);
            _pageLoadTimeout = Convert.ToInt16(TestContext.Parameters["pageLoadTimeout"]);
            act = new Actions(WebDriver);
        }

        public void CloseDriver()
        {
            SetUpWebDriverFactory.CloseWebDriver();
        }

        public string TakeScreenshot(string HTMLPath)
        {
            string screenshotPath;
            try
            {
                screenshotPath = ScreenShotCreator(HTMLPath);
            }
            catch (WebDriverException)
            {
                HTMLPath = null; // Do nothing
                screenshotPath = null;
            }
            catch (FileNotFoundException)
            {
                screenshotPath = ScreenShotCreator(HTMLPath);
            }
            return screenshotPath;
        }

        public string ScreenShotCreator(string HTMLPath)
        {
            string screenshotPath;

            string testName = Regex.Replace(TestContext.CurrentContext.Test.Name, "[\"():]", "_");
            if (!Directory.Exists(HTMLPath))
            {
                Directory.CreateDirectory(HTMLPath);
            }
            Console.WriteLine("Images path: {0}", HTMLPath);
            var screenshot = ((ITakesScreenshot)WebDriver).GetScreenshot();
            screenshotPath = HTMLPath + $@"\{DateTime.Now.ToString("d-M-yyyy HH-mm-ss")}_{testName}.png".ToString();
            screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
            TestContext.AddTestAttachment(HTMLPath + $@"\{DateTime.Now.ToString("d-M-yyyy HH-mm-ss")}_{testName}.png");

            return screenshotPath;
        }

        public bool IsElementDisplayed(IWebElement element)
        {
            try
            {
                if (element.Displayed == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        }

        public string GetCurrentUrl()
        {
            var url = WebDriver.Url;
            return url;
        }
    }
}
