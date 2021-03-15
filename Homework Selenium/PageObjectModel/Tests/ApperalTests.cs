using Homework_Selenium.PageObjectModel.Pages;
using Homework_Selenium.PageObjectModel.Pages.Apperal;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Selenium.PageObjectModel.Tests
{
    class ApperalTests : BaseTest
    {

        [Test]
        public void Task2()
        {
            HomePage homePage = new HomePage(driver);
            homePage.NavigateToHomePage();

            Apparel apparel = homePage.NavigateToRandomApparel();

            apparel.ClickRandomBrand();
            apparel.SortByPopularity();
            apparel.ChooseLowestPriceItem();
            apparel.AddToCart();
           Assert.IsTrue(apparel.IsCorrectItemAddedToTheShoppingCart());
        }

        

    }
}
