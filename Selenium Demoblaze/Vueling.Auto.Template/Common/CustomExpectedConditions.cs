using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace Demoblaze.Auto.Template.Common
{
    class CustomExpectedConditions
    {
        /// <summary>
        /// An expectation for checking an element is hidden
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>True if it is hidden, false otherwise.</returns>
        public static Func<IWebDriver, bool> ElementIsHidden(IWebElement element)
        {
            return (driver) =>
            {
                    return !element.Displayed;   
            };
        }

        /// <summary>
        /// Function to allow javascript to run suggest/autocomplete features
        /// </summary>
        public static Func<IWebDriver, bool> ElementIsSuggested(By by, string name)
        {
            return (driver) =>
            {
                try
                {
                    return driver.FindElement(by).Text.Contains(name);
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }  
            };
        }

        public static Func<IWebDriver, bool> JQueryStopped()
        {
            return (driver) =>
            {
                var j2e = (IJavaScriptExecutor)driver;
                return (bool) j2e.ExecuteScript("return jQuery.active == 0");
            };
        }

        /// <summary>
        /// An expectation for checking an element is visible 
        /// </summary>
        /// <param name="locator">The element identifier.</param>
        /// <returns>The <see cref="IWebElement"/> once it is visible.</returns>
        public static Func<IWebDriver, IWebElement> ElementIsVisible(By locator)
        {
            return (webDriver) =>
            {
                try
                {
                    return ElementIfVisible(webDriver.FindElement(locator));
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
                catch(NoSuchElementException)
                {
                    return null;
                }
            };
        }

        //Prueba
        public static Func<IWebDriver, IWebElement> ElementIsClickable(By locator)
        {
            return (webDriver) =>
            {
                var element = ElementIfVisible(webDriver.FindElement(locator));
                try
                {
                    if (element != null && element.Enabled)
                    {
                        return element;
                    } else
                    {
                        return null;
                    }
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }

        /// <summary>
        /// An expectation for checking that an element is either invisible or not present on the DOM.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <returns><see langword="true"/> if the element is not displayed; otherwise, <see langword="false"/>.</returns>

        public static Func<IWebDriver, bool> InvisibilityOfElementLocated(By locator)
        {
            return (driver) =>
            {
                try
                {
                    var element = driver.FindElement(locator);
                    return !element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    // Returns true because the element is not present in DOM. The
                    // try block checks if the element is present but is invisible.
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    // Returns true because stale element reference implies that element
                    // is no longer visible.
                    return true;
                }
            };
        }

        private static IWebElement ElementIfVisible(IWebElement webElement)
        {
            return webElement.Displayed ? webElement : null;
        }

    }
}
