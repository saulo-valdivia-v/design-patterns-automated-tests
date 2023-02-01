using OpenQA.Selenium;
using RefactoringFlackyTests.Decorator;

namespace RefactoringFlackyTests
{
    public class DecoratorTest
    {
        private static Driver _driver;
        private static string _purchaseEmail;
        private static string _purchaseOrderNumber;

        // Setup
        public DecoratorTest()
        {
            _driver = new LoggingDriver(new Decorator.WebDriver());
            _driver.Start(Browser.Chrome);
        }

        // Teardown
        public void Dispose()
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
            Thread.Sleep(5000);
            var messageAlert = _driver.FindElement(By.CssSelector("[class*='woocommerce-message']"));
            Assert.Equal("Coupon code applied successfully.", messageAlert.Text);
        }

        private void IncreaseProductQuantity()
        {
            var quantityBox = _driver.FindElement(By.CssSelector("[class*='input-text qty text']"));
            quantityBox.TypeText("2");
            Thread.Sleep(5000);
            var updateCart = _driver.FindElement(By.CssSelector("[value*='Update cart']"));
            updateCart.Click();
            Thread.Sleep(5000);
            var totalSpan = _driver.FindElement(By.XPath("//*[@class='order-total']//span"));
            Assert.Equal("114.00€", totalSpan.Text);
        }

        private void Login()
        {
            Thread.Sleep(5000);
            var userName = _driver.FindElement(By.Id("username"));
            userName.TypeText("xander.yasumu");
            var password = _driver.FindElement(By.Id("password"));
            password.TypeText("b3r6FshqbPQwAnT");
            var loginButton = _driver.FindElement(By.XPath("//button[@name='login']"));
            loginButton.Click();
        }

        [Fact]
        public void CompletePurchaseSuccessfully_WhenNewClient()
        {
            _driver.GoToURL("http://demos.bellatrix.solutions/");

            AddRocketToShoppingCart();

            ApplyCoupon();

            IncreaseProductQuantity();

            var proceedToCheckout = _driver.FindElement(By.CssSelector("[class*='checkout-button button alt wc-forward']"));
            proceedToCheckout.Click();

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

            Thread.Sleep(10000);
            var receivedMessage = _driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/main/article/header/h1"));
            Assert.Equal("Order received", receivedMessage.Text);
        }
    }
}
