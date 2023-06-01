using Demoblaze.Auto.Template.SetUp;
using Demoblaze.Auto.Template.WebPages.Base;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;

namespace Demoblaze.Auto.Template.Webpages
{
    public class GoogleSearch : CommonPage
    {
        private IList<IWebElement> Links
        {
            get { return WebDriver.FindElementsByCssSelector("div .g h3"); }
        }
        private IWebElement Pagina2
        {
            get { return WebDriver.FindElementByCssSelector("#navcnt a[aria-label='Page 2']"); }
        }
        protected override IWebElement ApartadosBusqueda => throw new System.NotImplementedException();

        public GoogleSearch(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        public GoogleSearch SeleccionarLink(int link)
        {
            Jse2.ExecuteScript("arguments[0].click()", Links[link]);
            //act.Click(Links[link]).Build().Perform();
            return this;
        }

        public GoogleSearch SiguientePagina()
        {
            //act.MoveToElement(Pagina2).Build().Perform();
            Jse2.ExecuteScript("arguments[0].scrollIntoView()", Pagina2);
            Thread.Sleep(1000);
            Pagina2.Click();
            return this;
        }
    }
}
