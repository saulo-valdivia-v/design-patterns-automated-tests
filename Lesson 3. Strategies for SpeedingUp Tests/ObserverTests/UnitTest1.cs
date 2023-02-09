using ObserverTests.Decorator;
using ObserverTests.Observer;
using OpenQA.Selenium;
using System.Diagnostics;

namespace ObserverTests
{
    [TestClass]
    [ExecutionBrowser(Browser.Chrome, BrowserBehavior.ReuseIfStarted)]
    public class UnitTest1 : BaseTest
    {
        private static Driver _driver;
        private static string _purchaseEmail;
        private static string _purchaseOrderNumber;
        private static Stopwatch _stopwatch;

        [ClassInitialize]
        public static void ClassInitialize()
        {
            _driver = new LoggingDriver(new Decorator.WebDriver());
            _driver.Start(Browser.Chrome);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _driver.Quit();
        }

        private void AddRocketToShoppingCart()
        {
            var addToCartFalcon9 = _driver.FindElement(By.CssSelector("[data-product_id*='28']"));
            addToCartFalcon9.Click();
            Thread.Sleep(5000);
            var viewCartButton = _driver.FindElement(By.CssSelector("[class*='added_to_cart wc-forward']"));
            viewCartButton.Click();
        }

        private void ApplyCoupon()
        {
            var couponCodeTextField = _driver.FindElement(By.Id("coupon_code"));
            couponCodeTextField.TypeText("happybirthday");
            var applyCouponButton = _driver.FindElement(By.CssSelector("[value*='Apply coupon']"));
            applyCouponButton.Click();
            //Thread.Sleep(5000);
            _driver.WaitForAjax();
            var messageAlert = _driver.FindElement(By.CssSelector("[class*='woocommerce-message']"));
            Assert.AreEqual("Coupon code applied successfully.", messageAlert.Text);
        }

        private void IncreaseProductQuantity()
        {
            var quantityBox = _driver.FindElement(By.CssSelector("[class*='input-text qty text']"));
            quantityBox.TypeText("2");
            //Thread.Sleep(5000);
            _driver.WaitForAjax();
            var updateCart = _driver.FindElement(By.CssSelector("[value*='Update cart']"));
            updateCart.Click();
            //Thread.Sleep(5000);
            _driver.WaitForAjax();
            var totalSpan = _driver.FindElement(By.XPath("//*[@class='order-total']//span"));
            Assert.AreEqual("114.00€", totalSpan.Text);
        }

        private void Login()
        {
            Debug.WriteLine($"Login Start: {_stopwatch.Elapsed.TotalSeconds}");
            Thread.Sleep(5000);
            var userName = _driver.FindElement(By.Id("username"));
            userName.TypeText("xander.yasumu");
            var password = _driver.FindElement(By.Id("password"));
            password.TypeText("b3r6FshqbPQwAnT");
            var loginButton = _driver.FindElement(By.XPath("//button[@name='login']"));
            loginButton.Click();

            Debug.WriteLine($"Login End: {_stopwatch.Elapsed.TotalSeconds}");
        }

        [TestMethod]
        [ExecutionBrowser(Browser.Chrome, BrowserBehavior.ReuseIfStarted)]
        public void TestMethod1()
        {
            _driver.GoToURL("http://demos.bellatrix.solutions/");

            AddRocketToShoppingCart();

            ApplyCoupon();

            IncreaseProductQuantity();

            var proceedToCheckout = _driver.FindElement(By.CssSelector("[class*='checkout-button button alt wc-forward']"));
            proceedToCheckout.Click();

            _driver.WaitUntilPageLoadsCompletely();

            var billingFirstName = _driver.FindElement(By.Id("billing_first_name"));
            billingFirstName.TypeText("Saulo");
            var billingLastName = _driver.FindElement(By.Id("billing_last_name"));
            billingLastName.TypeText("Valdivia");
            var billingCompany = _driver.FindElement(By.Id("billing_company"));
            billingCompany.TypeText("Space Flowers");
            var billingCountryWrapper = _driver.FindElement(By.Id("select2-billing_country-container"));
            billingCountryWrapper.Click();
            var billingCountryFilter = _driver.FindElement(By.ClassName("select2-search__field"));
            billingCountryFilter.TypeText("Germany");
            var germanyOption = _driver.FindElement(By.XPath("//*[contains(text(),'Germany')]"));
            germanyOption.Click();
            var billingAddress1 = _driver.FindElement(By.Id("billing_address_1"));
            billingAddress1.TypeText("1 Willi Brandt Avenue Tiergarten");
            var billingAddress2 = _driver.FindElement(By.Id("billing_address_2"));
            billingAddress2.TypeText("Lützowplatz 17");
            var billingCity = _driver.FindElement(By.Id("billing_city"));
            billingCity.TypeText("Berlin");
            var billingZip = _driver.FindElement(By.Id("billing_postcode"));
            billingZip.TypeText("10115");
            var billingPhone = _driver.FindElement(By.Id("billing_phone"));
            billingPhone.TypeText("+00498888999281");
            var billingEmail = _driver.FindElement(By.Id("billing_email"));
            billingEmail.TypeText("info@berlinspaceflowers.com");
            _purchaseEmail = "info@berlinspaceflowers.com";
            Thread.Sleep(5000);

            var placeOrderButton = _driver.FindElement(By.Id("place_order"));
            placeOrderButton.Click();

            //Thread.Sleep(10000);
            _driver.WaitForAjax();
            //_driver.WaitUntilPageLoadsCompletely();
            var receivedMessage = _driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/main/article/header/h1"));
            Assert.AreEqual("Order received", receivedMessage.Text);
        }
    }
}