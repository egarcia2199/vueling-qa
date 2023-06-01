using Demoblaze.Auto.Template.SetUp;
using Demoblaze.Auto.Template.WebPages.Base;
using OpenQA.Selenium;
using System.Threading;

namespace Demoblaze.Auto.Template.Webpages
{
    public class GooglePage : CommonPage
    {

        //Define WebElements by: Id, CssSelector or XPath
        private IWebElement Buscador
        {
            get { return WebDriver.FindElementById("lst-ib"); }
        }

        //Todo buscar elemento
        //private IWebElement BuscarButton => throw new System.NotImplementedException();
        private IWebElement BuscarButton
        {
            get { return WebDriver.FindElementByCssSelector("input[name='btnK']"); }
        }

        protected override IWebElement ApartadosBusqueda => throw new System.NotImplementedException();

        //Constructor
        public GooglePage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {

        }

        //Define functions and actions 

        public GooglePage Busqueda(string busqueda, string busqueda2)
        {
            Thread.Sleep(2000);
            Buscador.SendKeys(busqueda);
            Thread.Sleep(1000);
            Buscador.Clear();
            Thread.Sleep(1000);
            act.SendKeys(Buscador, busqueda2).Build().Perform();
            Thread.Sleep(1000);
            Buscador.SendKeys(Keys.Return);
            return this;
        }
    }
}
