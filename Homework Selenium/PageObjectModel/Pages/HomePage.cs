using Homework_Selenium.PageObjectModel.Pages.Apperal;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Selenium.PageObjectModel.Pages
{
    class HomePage : BasePage
    {
        private static string pageUrl = "https://demo.cs-cart.com/";

        private static string expectedStringTitle = "Hot deals";

        protected static readonly By HomePageTitle = By.XPath("//*[@id=\"tygh_main_container\"]/div[3]/div/div[2]/div/div[1]/h2");

        protected static readonly By Apparel = By.XPath("//*[@id=\"tygh_main_container\"]/div[2]/div/div[2]/div/div/ul/li[4]/a[2]");

        protected static readonly By Reviews = By.XPath("//*[@id=\"text_links_15\"]/li[3]/a");

        protected static readonly By PoundValute = By.XPath("//*[@id=\"currencies_2\"]/div[1]/a[3]");

        protected static readonly By USDValute = By.XPath("//*[@id=\"currencies_2\"]/div[1]/a[1]");

        protected static readonly By OurBlog = By.XPath("//*[@id=\"text_links_3\"]/li[1]");



        public HomePage(IWebDriver webDriver) : base(webDriver)
        {

        }

        public void NavigateToHomePage()
        {
            webDriver.Navigate().GoToUrl(pageUrl);
        }

        public MensClothing NavigateToMensClothing()
        {
            Actions actions = new Actions(webDriver);
            actions.MoveToElement(webDriver.FindElement(Apparel));
            actions.Build().Perform();

            IList<IWebElement> elements = webDriver.FindElements(By.XPath("//*[@id=\"tygh_main_container\"]/div[2]/div/div[2]/div/div/ul/li[4]/div/ul/li/a"));

            foreach (IWebElement element in elements)
            {
                if (element.Text == "Men's Clothing")
                {
                    element.Click();
                    break;
                }
            }

            return new MensClothing(webDriver);
            
        }

        public WomensClothing NavigateToWomensClothing()
        {
            Actions actions = new Actions(webDriver);
            actions.MoveToElement(webDriver.FindElement(Apparel));
            actions.Build().Perform();

            IList<IWebElement> elements = webDriver.FindElements(By.XPath("//*[@id=\"tygh_main_container\"]/div[2]/div/div[2]/div/div/ul/li[4]/div/ul/li/a"));

            foreach (IWebElement element in elements)
            {
                if (element.Text == "Women's Clothing")
                {
                    element.Click();
                    break;
                }
            }

            return new WomensClothing(webDriver);

        }

        public Shoes NavigateToShoes()
        {
            Actions actions = new Actions(webDriver);
            actions.MoveToElement(webDriver.FindElement(Apparel));
            actions.Build().Perform();

            IList<IWebElement> elements = webDriver.FindElements(By.XPath("//*[@id=\"tygh_main_container\"]/div[2]/div/div[2]/div/div/ul/li[4]/div/ul/li/a"));

            foreach (IWebElement element in elements)
            {
                if (element.Text == "Shoes")
                {
                    element.Click();
                    break;
                }
            }

            return new Shoes(webDriver);

        }

        public WatchesAndJewelry NavigateToWatchesAndJewelry()
        {
            Actions actions = new Actions(webDriver);
            actions.MoveToElement(webDriver.FindElement(Apparel));
            actions.Build().Perform();

            IList<IWebElement> elements = webDriver.FindElements(By.XPath("//*[@id=\"tygh_main_container\"]/div[2]/div/div[2]/div/div/ul/li[4]/div/ul/li/a"));

            foreach (IWebElement element in elements)
            {
                if (element.Text == "Watches & Jewelry")
                {
                    element.Click();
                    break;
                }
            }

            return new WatchesAndJewelry(webDriver);

        }

        public Apparel NavigateToRandomApparel()
        {
            Actions actions = new Actions(webDriver);
            Wait.ElementToBeClickable(webDriver, Apparel);
            actions.MoveToElement(webDriver.FindElement(Apparel));
            actions.Build().Perform();

            IList<IWebElement> elements = webDriver.FindElements(By.XPath("//*[@id=\"tygh_main_container\"]/div[2]/div/div[2]/div/div/ul/li[4]/div/ul/li/a"));

            Random random = new Random();
            int randomIndex = random.Next(elements.Count);

            if (elements[randomIndex].Text == "Men's Clothing")
            {
                NavigateToMensClothing();
            }

            else if (elements[randomIndex].Text == "Women's Clothing")
            {
                NavigateToWomensClothing();
            }

            else if (elements[randomIndex].Text == "Shoes")
            {
                NavigateToShoes();
            }

            else if (elements[randomIndex].Text == "Watches & Jewelry")
            {
                NavigateToWatchesAndJewelry();
            }

            return new Apparel(webDriver);
        }

        public bool IsTitleCorrect()
        {
           return this.webDriver.FindElement(HomePageTitle).Text.Equals(expectedStringTitle);
        }
    }
}
