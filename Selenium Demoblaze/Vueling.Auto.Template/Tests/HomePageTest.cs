using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demoblaze.Auto.Template.WebPages;
using Demoblaze.Auto.Template.SetUp;

namespace Demoblaze.Auto.Template.Tests
{
    [TestFixture]
    class HomePageTest : TestSetCleanBase
    {

        public string username1 = "erictest01";
        public string username2 = "erictest02";
        public string username3 = "erictest03";
        public string username4 = "erictest04";
        public string username5 = "erictest05";

        [TestCase]
        public void BuyLaptop()
        {
            homePage = new HomePage(setUpWebDriver);
            login = new LogIn(setUpWebDriver);
            cartPage = new Cart(setUpWebDriver);
            homePage.GoToLoginPage();
            login.LoginUser(username1);
            homePage.ClickCategoryLaptops();
            homePage.SelectLaptop();
            cartPage.Buy();
            homePage.LogOut();
        }

        [TestCase]
        public void BuyPhone()
        {

            homePage = new HomePage(setUpWebDriver);
            login = new LogIn(setUpWebDriver);
            cartPage = new Cart(setUpWebDriver);
            homePage.GoToLoginPage();
            login.LoginUser(username2);
            homePage.ClickCategoryPhones();
            homePage.SelectPhone();
            cartPage.Buy();
            homePage.LogOut();
        }


        [TestCase]
        public void BuyMonitor()
        {
            homePage = new HomePage(setUpWebDriver);
            login = new LogIn(setUpWebDriver);
            cartPage = new Cart(setUpWebDriver);
            homePage.GoToLoginPage();
            login.LoginUser(username3);
            homePage.ClickCategoryMonitors();
            homePage.SelectMonitor();
            cartPage.Buy();
            homePage.LogOut();

        }

        //[TestCase]
        //public void Buy2Products()
        //{
        //    homePage = new HomePage(setUpWebDriver);
        //    login = new LogIn(setUpWebDriver);
        //    cartPage = new Cart(setUpWebDriver);
        //    homePage.GoToLoginPage();
        //    login.LoginUser(username4);
        //    homePage.ClickCategoryMonitors();
        //    homePage.SelectMonitor();
        //    homePage.GoToHomePage();
        //    homePage.ClickCategoryPhones();
        //    homePage.SelectPhone();
        //    homePage.GoToCart();
        //    homePage.LogOut();

        //}


        [TestCase]
        public void DeleteItems() { 

            homePage = new HomePage(setUpWebDriver);
            login = new LogIn(setUpWebDriver);
            cartPage = new Cart(setUpWebDriver);
            homePage.GoToLoginPage();
            login.LoginUser(username5);
            homePage.GoToCart();
            cartPage.DeleteItem("Sony xperia z5");
        }
    }
}
