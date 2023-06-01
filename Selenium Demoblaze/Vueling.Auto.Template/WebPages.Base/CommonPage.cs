using Demoblaze.Auto.Template.SetUp;
using OpenQA.Selenium;

namespace Demoblaze.Auto.Template.WebPages.Base
{
    /* CommonPage will include WebElements and functionalities shared by all WebPages */
    public abstract class CommonPage : Page
    {
        //Abstract elements to call the same element with different call
        protected abstract IWebElement ApartadosBusqueda { get; }

        //define here common WebElements
        protected By ButtonElement
        {
            get { return By.CssSelector(""); }
        }
        protected IWebElement ButtonWebElement
        {
            get { return WebDriver.FindElement(ButtonElement); }
        }
        
        protected CommonPage(ISetUpWebDriver setUpWebDriver)
            : base(setUpWebDriver)
        {
        }

        public TcommonPage CommonFunction<TcommonPage>() where TcommonPage : CommonPage
        {
            ButtonWebElement.Click();
            return this as TcommonPage;
        }
    }
}
