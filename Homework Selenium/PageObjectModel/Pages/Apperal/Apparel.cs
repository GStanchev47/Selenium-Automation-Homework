using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Selenium.PageObjectModel.Pages.Apperal
{
    class Apparel : BasePage
    {
        private static string expectedPageTitle = "Apparel";

        private string itemSelected;

        protected static readonly By BrandElements = By.XPath("//ul[@id=\"ranges_31_10\"]/li/label/input");

        protected static readonly By ImagesElements = By.XPath("//div[@class='ty-grid-list__image']");

        protected static readonly By LoadingAnimation = By.Id("ajax_loading_box");

        protected static readonly By ResetButton = By.XPath("//*[@id=\"product_filters_31\"]/div/div[3]/a");

        protected static readonly By SortButton = By.Id("sw_elm_sort_fields");

        protected static readonly By SortElements = By.XPath("//*[@id=\"elm_sort_fields\"]/li");

        protected static readonly By ContainsPopUpMessage = By.XPath("//button[@type='button' and contains(., \"product\")]");

        protected static readonly By LeftPriceSlider = By.XPath("//*[@id=\"slider_31_1_left\"]");

        protected static readonly By RightPriceSlider = By.Id("slider_31_1_right");

        protected static readonly By QuickViewButton = By.XPath("//*[@id=\"pagination_contents\"]/div[2]/div[1]/div/form/div[5]/div/a");

        protected static readonly By SelectedItem = By.XPath("//*[@id=\"product_main_info_form_ajax\"]/form/div[2]/h1/a/bdi");

        protected static readonly By AddToCartButton = By.XPath("//button[@type='submit' and contains(., \"cart\")]");

        protected static readonly By ModalCloseButton = By.XPath("//*[@class='cm-notification-close close']");

        protected static readonly By ShoppingCartButton = By.Id("sw_dropdown_8");

        protected static readonly By ItemInTheCart = By.XPath("//*[@id=\"dropdown_8\"]/div/div[1]/ul/li/div[2]/a");

        public Apparel(IWebDriver webDriver) : base(webDriver)
        {

        }

        public bool isApperalTitleCorrect()
        {
            return this.webDriver.FindElement(PageTitle).Text.Equals(expectedPageTitle);
        }


        public void ClickRandomBrand()
        {
            IList<IWebElement> elements = webDriver.FindElements(BrandElements);

            Random random = new Random();

            int randomIndex = random.Next(elements.Count);

            elements[randomIndex].Click();
            Wait.InvisibilityOfElement(webDriver, LoadingAnimation);

            elements = webDriver.FindElements(ImagesElements);

            if (elements.Count == 1)
            {
                webDriver.FindElement(ResetButton).Click();
                Wait.InvisibilityOfElement(webDriver, LoadingAnimation);
            }

        }

        public void SortByPopularity()
        {
            Wait.ElementToBeClickable(webDriver, SortButton); //Waiting for the Sort button to be clickable


            Wait.InvisibilityOfElement(webDriver, ContainsPopUpMessage); //Waiting for the Pop-up message to dissapear


            webDriver.FindElement(SortButton).Click();  //Clicking the Sort button

            IList<IWebElement> elements = webDriver.FindElements(SortElements);

            Wait.ElementToBeClickable(webDriver, SortElements);

            elements[elements.Count - 1].Click();

            
        }

        public void ChooseLowestPriceItem()
        {
            string lowest = webDriver.FindElement(LeftPriceSlider).GetAttribute("value");

            int lowestPrice = 1 + Int32.Parse(lowest);

            webDriver.FindElement(RightPriceSlider).Clear();
            webDriver.FindElement(RightPriceSlider).SendKeys("" + lowestPrice);

            Wait.VisibilityOfElement(webDriver, LoadingAnimation);
            Wait.InvisibilityOfElement(webDriver, LoadingAnimation);

            Actions actions = new Actions(webDriver);
            actions.MoveToElement(webDriver.FindElement(ImagesElements));


            Wait.ElementToBeClickable(webDriver, QuickViewButton);

            webDriver.FindElement(QuickViewButton).Click();
        }

        public void AddToCart()
        {
            Wait.VisibilityOfElement(webDriver, SelectedItem);
            itemSelected = webDriver.FindElement(SelectedItem).Text;

            Wait.ElementToBeClickable(webDriver, AddToCartButton);
            webDriver.FindElement(AddToCartButton).Click();

            webDriver.FindElement(ModalCloseButton).Click();

            webDriver.FindElement(ShoppingCartButton).Click();
        }

        public bool IsCorrectItemAddedToTheShoppingCart()
        {
            return webDriver.FindElement(ItemInTheCart).Text.Equals(itemSelected);
        }
    
    }
}
