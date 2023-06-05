using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using System.Reflection;

namespace Abstracta.Auto.Template.SetUp
{
    public class SetUpWebDriver : ISetUpWebDriver
    {
        private static RemoteWebDriver webDriver;
        private static string browser = TestContext.Parameters["browser"];
        private static string targetURL = TestContext.Parameters["targetUrl"];

        public RemoteWebDriver GetSetUpWebDriver()
        {

            if (TestContext.Parameters.Count == 0)
            {
                Exception ex = new Exception("Configuration file not set up / found");
                throw ex;
            }

            if (webDriver != null)
            {
                return webDriver;
            }

            switch (browser)
            {
                case "Chrome":
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("maxSession=1");
                    webDriver = new RemoteWebDriver(
                        new Uri("http://192.168.13.35:4444/wd/hub"),
                        chromeOptions.ToCapabilities(),
                        TimeSpan.FromSeconds(Convert.ToDouble(TestContext.Parameters["pageLoadTimeout"])));
                    break;
                case "Firefox":
                    FirefoxOptions firefoxOptions = new FirefoxOptions();
                    webDriver = new RemoteWebDriver(
                        new Uri(""),
                        firefoxOptions.ToCapabilities(),
                        TimeSpan.FromSeconds(Convert.ToDouble(TestContext.Parameters["pageLoadTimeout"])));
                    break;
                case "IE":
                    InternetExplorerOptions ieOptions = new InternetExplorerOptions();
                    webDriver = new RemoteWebDriver(
                        new Uri(""),
                        ieOptions.ToCapabilities(),
                        TimeSpan.FromSeconds(Convert.ToDouble(TestContext.Parameters["pageLoadTimeout"])));
                    break;
                case "ChromeLocal":
                    webDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                        new ChromeOptions(),
                        TimeSpan.FromSeconds(Convert.ToDouble(TestContext.Parameters["pageLoadTimeout"])));
                    break;
                case "FirefoxLocal":
                    webDriver = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                        new FirefoxOptions(),
                        TimeSpan.FromSeconds(Convert.ToDouble(TestContext.Parameters["pageLoadTimeout"])));
                    break;
                case "IELocal":
                    webDriver = new InternetExplorerDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                        new InternetExplorerOptions(),
                        TimeSpan.FromSeconds(Convert.ToDouble(TestContext.Parameters["pageLoadTimeout"])));
                    break;
                default:
                    throw new Exception("Browser not configured");
            }

            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(Convert.ToDouble(TestContext.Parameters["pageLoadTimeout"]));
            webDriver.Manage().Window.Maximize();
            GoTo(targetURL);

            return webDriver;
        }

        public void GoTo(string url)
        {
            webDriver.Url = url;
        }


        public void CloseWebDriver()
        {   
            webDriver.Quit();
            if (HasQuit(webDriver) == false)
            {
                webDriver = null;
            }
            else
            {
                //WebDriver quit correctly
            }
        }

        public bool HasQuit(RemoteWebDriver webDriver)
        {
            try
            {
                if (webDriver.SessionId.ToString().Contains("null"))
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Session: {0}", webDriver.SessionId.ToString());
                    return false;
                }
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }
    }
}
