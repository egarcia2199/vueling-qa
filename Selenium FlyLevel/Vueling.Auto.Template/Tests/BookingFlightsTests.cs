using Flylevel.Auto.Template.SetUp;
using Flylevel.Auto.Template.WebPages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flylevel.Auto.Template.Tests
{
    class BookingFlightsTests : TestSetCleanBase
    {

        [TestCase, Order(1)]
        public void BuySimpleFlight()
        {
            checkinPage = new Checkin(setUpWebDriver);
            checkinPage.BookingFlight();

        }

        [TestCase, Order(2)]
        public void BuyFlight_BCN_SCL()
        {
            checkinPage = new Checkin(setUpWebDriver);

            checkinPage.BookingFlight_BCN_SCL();
            checkinPage.SelectMonth("septiembre");
        }

    }
}
