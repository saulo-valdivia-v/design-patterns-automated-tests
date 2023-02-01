using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringFlackyTests
{
    public class Refactor1
    {
        private static IWebDriver _driver;
        private static string _purchaseEmail;
        private static string _purchaseOrderNumber;

        private IWebElement WaitAndFindElement(By by)
        {
            var webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            return webDriverWait.Until(ExpectedConditions.ElementExists(by));
        }

        private ReadOnlyCollection<IWebElement> WaitAndFindElements(By by)
        {
            var webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            return webDriverWait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
        }

        private void WaitToBeClickable(By by)
        {
            var webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            webDriverWait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        // Setup
        public Refactor1()
        {
            _driver = new ChromeDriver(Environment.CurrentDirectory);
        }

        // Teardown
        public void Dispose()
        {
            _driver.Quit();
        }

        [Fact]
        public void CompletePurchaseSuccessfully_WhenNewClient()
        {
            _driver.Navigate().GoToUrl("https://demos.bellatrix.solutions/");
            var addToCartFalcon9 = WaitAndFindElement(By.CssSelector("[data-product_id*='28']"));
            addToCartFalcon9.Click();
            //Thread.Sleep(5000);
            var viewCartButton = WaitAndFindElement(By.CssSelector("[class*='added_to_cart wc-forward']"));
            viewCartButton.Click();

            var couponCodeTextField = WaitAndFindElement(By.Id("coupon_code"));
            couponCodeTextField.Clear();
            couponCodeTextField.SendKeys("happybirthday");
            var applyCouponButton = WaitAndFindElement(By.CssSelector("[value*='Apply coupon']"));
            applyCouponButton.Click();
            //Thread.Sleep(5000);            
            var messageAlert = WaitAndFindElement(By.CssSelector("[class*='woocommerce-message']"));
            Assert.Equal("Coupon code applied successfully.", messageAlert.Text);


            WaitToBeClickable(By.CssSelector("[value*='Apply coupon']"));
            Thread.Sleep(1000);
            WaitToBeClickable(By.CssSelector("[value*='Apply coupon']"));
            Thread.Sleep(1000);
            WaitToBeClickable(By.CssSelector("[value*='Apply coupon']"));
            Thread.Sleep(1000);
            WaitToBeClickable(By.CssSelector("[value*='Apply coupon']"));
            var quantityBox = WaitAndFindElement(By.CssSelector("[class*='input-text qty text']"));
            WaitToBeClickable(By.CssSelector("[class*='input-text qty text']"));
            quantityBox.Clear();
            //Thread.Sleep(5000);
            quantityBox.SendKeys("2");

            //Thread.Sleep(5000);
            WaitToBeClickable(By.CssSelector("[value*='Update cart']"));
            var updateCart = WaitAndFindElement(By.CssSelector("[value*='Update cart']"));            
            updateCart.Click();
            Thread.Sleep(5000);

            var totalSpan = WaitAndFindElement(By.XPath("//*[@class='order-total']//span"));
            Assert.Equal("114.00€", totalSpan.Text);

            var proceedToCheckout = WaitAndFindElement(By.CssSelector("[class*='checkout-button button alt wc-forward']"));
            proceedToCheckout.Click();

            var billingFirstName = WaitAndFindElement(By.Id("billing_first_name"));
            billingFirstName.SendKeys("Saulo");
            var billingLastName = WaitAndFindElement(By.Id("billing_last_name"));
            billingLastName.SendKeys("Valdivia");
            var billingCompany = WaitAndFindElement(By.Id("billing_company"));
            billingCompany.SendKeys("Space Flowers");
            var billingCountryWrapper = WaitAndFindElement(By.Id("select2-billing_country-container"));
            billingCountryWrapper.Click();
            var billingCountryFilter = WaitAndFindElement(By.ClassName("select2-search__field"));
            billingCountryFilter.SendKeys("Germany");
            var germanyOption = WaitAndFindElement(By.XPath("//*[contains(text(),'Germany')]"));
            germanyOption.Click();
            var billingAddress1 = WaitAndFindElement(By.Id("billing_address_1"));
            billingAddress1.SendKeys("1 Willi Brandt Avenue Tiergarten");
            var billingAddress2 = WaitAndFindElement(By.Id("billing_address_2"));
            billingAddress2.SendKeys("Lützowplatz 17");
            var billingCity = WaitAndFindElement(By.Id("billing_city"));
            billingCity.SendKeys("Berlin");
            var billingZip = WaitAndFindElement(By.Id("billing_postcode"));
            billingZip.Clear();
            billingZip.SendKeys("10115");
            var billingPhone = WaitAndFindElement(By.Id("billing_phone"));
            billingPhone.SendKeys("+00498888999281");
            var billingEmail = WaitAndFindElement(By.Id("billing_email"));
            billingEmail.SendKeys("info@berlinspaceflowers.com");
            _purchaseEmail = "info@berlinspaceflowers.com";
            //Thread.Sleep(5000);
            
            var placeOrderButton = WaitAndFindElement(By.Id("place_order"));
            WaitToBeClickable(By.Id("place_order"));
            Thread.Sleep(1000);
            WaitToBeClickable(By.Id("place_order"));
            Thread.Sleep(1000);
            WaitToBeClickable(By.Id("place_order"));
            placeOrderButton.Click();

            Thread.Sleep(10000);
            var receivedMessage = WaitAndFindElement(By.XPath("/html/body/div[1]/div[2]/div/div/main/article/header/h1"));
            Assert.Equal("Order received", receivedMessage.Text);
        }

        private void AddRocketToShoppingCart()
        {
            var addToCartFalcon9 = WaitAndFindElement(By.CssSelector("[data-product_id*='28']"));
            addToCartFalcon9.Click();
            Thread.Sleep(5000);
            var viewCartButton = WaitAndFindElement(By.CssSelector("[class*='added_to_cart wc-forward']"));
            viewCartButton.Click();
        }

        private void ApplyCoupon()
        {
            var couponCodeTextField = WaitAndFindElement(By.Id("coupon_code"));
            couponCodeTextField.Clear();
            couponCodeTextField.SendKeys("happybirthday");
            var applyCouponButton = WaitAndFindElement(By.CssSelector("[value*='Apply coupon']"));
            applyCouponButton.Click();
            Thread.Sleep(5000);
            var messageAlert = WaitAndFindElement(By.CssSelector("[class*='woocommerce-message']"));
            Assert.Equal("Coupon code applied successfully.", messageAlert.Text);
        }

        private void IncreaseProductQuantity()
        {
            var quantityBox = WaitAndFindElement(By.CssSelector("[class*='input-text qty text']"));
            quantityBox.Clear();
            Thread.Sleep(500);
            quantityBox.SendKeys("2");
            Thread.Sleep(5000);
            var updateCart = WaitAndFindElement(By.CssSelector("[value*='Update cart']"));
            updateCart.Click();
            Thread.Sleep(5000);
            var totalSpan = WaitAndFindElement(By.XPath("//*[@class='order-total']//span"));
            Assert.Equal("114.00€", totalSpan.Text);
        }

        private void Login()
        {
            Thread.Sleep(5000);
            var userName = WaitAndFindElement(By.Id("username"));
            userName.SendKeys("xander.yasumu");
            var password = WaitAndFindElement(By.Id("password"));
            password.SendKeys("b3r6FshqbPQwAnT");
            var loginButton = WaitAndFindElement(By.XPath("//button[@name='login']"));
            loginButton.Click();
        }

        [Fact]
        public void CompletePurchaseSuccessfully_WhenExistingClient()
        {
            _driver.Navigate().GoToUrl("http://demos.bellatrix.solutions/");

            AddRocketToShoppingCart();

            ApplyCoupon();

            IncreaseProductQuantity();

            var proceedToCheckout = WaitAndFindElement(By.CssSelector("[class*='checkout-button button alt wc-forward']"));
            proceedToCheckout.Click();

            var loginHereLink = WaitAndFindElement(By.LinkText("Click here to login"));
            loginHereLink.Click();
            Login();

            Thread.Sleep(5000);
            var placeOrderButton = WaitAndFindElement(By.Id("place_order"));
            placeOrderButton.Click();

            Thread.Sleep(10000);
            var receivedMessage = WaitAndFindElement(By.XPath("//h1"));
            Assert.Equal("Order received", receivedMessage.Text);

            var orderNumber = WaitAndFindElement(By.XPath("//*[@id='post-7']/div/div/div/ul/li[1]/strong"));
            _purchaseOrderNumber = orderNumber.Text;
        }

        [Fact]
        public void CorrectOrderDataDisplayed_WhenNavigateToMyAccountOrderSection()
        {
            _driver.Navigate().GoToUrl("http://demos.bellatrix.solutions/");

            var myAccountLink = WaitAndFindElement(By.LinkText("My account"));
            myAccountLink.Click();
            var userName = WaitAndFindElement(By.Id("username"));
            userName.SendKeys("xander.yasumu");
            var password = WaitAndFindElement(By.Id("password"));
            password.SendKeys("b3r6FshqbPQwAnT");
            var loginButton = WaitAndFindElement(By.XPath("//button[@name='login']"));
            loginButton.Click();

            Thread.Sleep(5000);
            var orders = WaitAndFindElement(By.LinkText("Orders"));
            orders.Click();

            Thread.Sleep(5000);
            var viewButtons = WaitAndFindElements(By.LinkText("View"));
            viewButtons[0].Click();
            Thread.Sleep(5000);

            var orderName = WaitAndFindElement(By.XPath("//h1"));
            string expectedMessage = $"Order #{_purchaseOrderNumber}";
            Assert.Equal(expectedMessage, orderName.Text);
        }
    }
}
