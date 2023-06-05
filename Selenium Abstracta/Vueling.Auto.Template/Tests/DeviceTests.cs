using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstracta.Auto.Template.WebPages;
using Abstracta.Auto.Template.SetUp;
using System.Threading;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace Abstracta.Auto.Template.Tests
{
    [TestFixture]
    class DeviceTests : TestSetCleanBase
    {

        public string username1 = "test001@test.com";
        public string[] arrayCatDropDown = { "Desktops", "Laptops & Notebooks", "Components", "MP3 Players" };
        public string[] arrayCat = { "Tablets", "Software", "Phones & PDAs", "Cameras" };


        
          [TestCase, Order(1)]
          public void MakeSimpleOrder()
          {
              homePage = new HomePage(setUpWebDriver);
              login = new LogIn(setUpWebDriver);
              cartPage = new Cart(setUpWebDriver);
              categoriesPage = new Categories(setUpWebDriver);

              homePage.GoToLoginPage();
              login.LoginUser(username1);
              categoriesPage.EnterCategoryWithDropDown(arrayCatDropDown[0]);
              categoriesPage.BuyProduct("MacBook");
              cartPage.Buy();
              Thread.Sleep(1000);
              homePage.LogOut();

          }


          [TestCase, Order(2)]
          public void Order2Products()
          {
              homePage = new HomePage(setUpWebDriver);
              login = new LogIn(setUpWebDriver);
              cartPage = new Cart(setUpWebDriver);
              categoriesPage = new Categories(setUpWebDriver);

              homePage.GoToLoginPage();
              login.LoginUser(username1);
              categoriesPage.EnterCategoryWithDropDown(arrayCatDropDown[0]);
              categoriesPage.BuyProduct("MacBook");
              categoriesPage.EnterCategory(arrayCat[0]);
              categoriesPage.BuyProduct("Samsung Galaxy Tab 10.1");
              cartPage.Buy();

          }

          

        [TestCase, Order(3)]

        public void DeleteItems()
        {
            homePage = new HomePage(setUpWebDriver);
            login = new LogIn(setUpWebDriver);
            cartPage = new Cart(setUpWebDriver);
            categoriesPage = new Categories(setUpWebDriver);

            homePage.GoToLoginPage();
            login.LoginUser(username1);
            categoriesPage.EnterCategoryWithDropDown(arrayCatDropDown[0]);
            categoriesPage.BuyProduct("MacBook");
            categoriesPage.EnterCategoryWithDropDown(arrayCatDropDown[0]);
            categoriesPage.BuyProduct("iPhone");
            homePage.GoToCart();
            cartPage.DeleteItem("MacBook");

        }

        

        [TestCase, Order(4)]

        public void TestCheckSponsor()
        {
            homePage = new HomePage(setUpWebDriver);
            login = new LogIn(setUpWebDriver);
            cartPage = new Cart(setUpWebDriver);
            categoriesPage = new Categories(setUpWebDriver);

            homePage.GoToLoginPage();
            login.LoginUser(username1);
            homePage.GoToHomePage(); 
            homePage.CheckSponsor("Nintendo");

        }

    }
    
    

    
}
