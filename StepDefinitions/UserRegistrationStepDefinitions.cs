using November2023SpecFlowPOM.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace November2023SpecFlowPOM.StepDefinitions
{
    [Binding]
    public sealed class UserRegistrationStepDefinitions : DriverHelper
    {


        [Given(@"I navigate to AutoExerciseHomePage url")]
        public void GivenINavigateToAutoExerciseHomePageUrl()
        {
            Driver.Navigate().GoToUrl(Environments.AutoHomeUrl);
        }

        [Then(@"I verify that <New User Signup!> is visible")]
        public void ThenIVerifyThatNewUserSignupIsVisible()
        {
            IWebElement NewUserSignupMsg = Driver.FindElement(By.XPath("//h2[contains(text(),'New User Signup!')]"));
            Assert.IsTrue(NewUserSignupMsg.Displayed, "New User Signup! is not visible");
        }

        [When(@"I enter '([^']*)' and '([^']*)'")]
        public void WhenIEnterAnd(string name, string email)
        {
            IWebElement NameField = Driver.FindElement(By.XPath("//input[@data-qa='signup-name']"));
            NameField.SendKeys(name);

            IWebElement EmailField = Driver.FindElement(By.XPath("//input[@data-qa='signup-email']"));
            EmailField.SendKeys(email);
        }

        [When(@"I click the '([^']*)' button")]
        public void WhenIClickTheButton(string signup)
        {
            IWebElement SignupButton = Driver.FindElement(By.XPath($"//button[@data-qa='{signup}-button']"));
            SignupButton.Click();
        }

        [Then(@"I verify that '([^']*)' is visible")]
        public void ThenIVerifyThatIsVisible(string text)
        {
            var headerText = Driver.FindElement(By.XPath("//b[contains(text(),'Enter Account Information')]"));
            Assert.True(headerText.Text.Equals(text));
        }

        [When(@"I fill in the details:")]
        public void WhenIFillInTheDetails(Table table)
        {
            foreach (TableRow row in table.Rows)
            {

                foreach (string value in row.Values)

                {
                    var genderRadiobutton = Driver.FindElement(By.CssSelector("#id_gender1"));
                    genderRadiobutton.Click();
                    var Password = Driver.FindElement(By.CssSelector("#password"));
                    IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
                    js.ExecuteScript("arguments[0].scrollIntoView(true);", Password);
                    Password.SendKeys("quickfix");

                    var dayDropDown = Driver.FindElement(By.XPath("//select[@id='days']"));
                    var monthDropDown = Driver.FindElement(By.CssSelector("#months"));
                    var yearDropDown = Driver.FindElement(By.XPath("//select[@id='years']"));
                    new SelectElement(dayDropDown).SelectByText("1");
                    new SelectElement(monthDropDown).SelectByText("July");
                    new SelectElement(yearDropDown).SelectByText("1932");
                   
                }
            }
        }


        [When(@"I select the checkbox <'([^']*)'> and <'([^']*)'>")]
        public void WhenISelectTheCheckboxAnd(string SNL, string ROL)
        {
            var SignupNewsLetter = Driver.FindElement(By.Id("newsletter"));
            SignupNewsLetter.Click();

            var ReceiveOfferLetter = Driver.FindElement(By.XPath("//label[contains(text(),'Receive special offers from our partners!')]"));
            ReceiveOfferLetter.Click();

        }


        [When(@"I fill in the following details:")]
        public void WhenIFillInTheFollowingDetails(Table table)
        {

            foreach (TableRow row in table.Rows)
            {

                foreach (string value in row.Values)

                {
                    var firstName = Driver.FindElement(By.CssSelector("#first_name"));
                    firstName.SendKeys("David");

                    var lastName = Driver.FindElement(By.XPath("//input[@id='last_name']"));
                    lastName.SendKeys("Oye");

                    var Company = Driver.FindElement(By.XPath("//input[@id='company']"));
                    Company.SendKeys("Amazon");

                    var AddressLocator = Driver.FindElement(By.CssSelector("#address1"));
                    AddressLocator.SendKeys("37, Northampton Road");

                    var CountryLocator = Driver.FindElement(By.CssSelector("#country"));
                    CountryLocator.SendKeys("France");

                    var CityLocator = Driver.FindElement(By.XPath("//input[@id='city']"));
                    CityLocator.SendKeys("Paris");

                    var ZipCodeLocator = Driver.FindElement(By.CssSelector("#zipcode"));
                    ZipCodeLocator.SendKeys("236553-7616218");

                    var MobileNumber = Driver.FindElement(By.CssSelector("#mobile_number"));
                    MobileNumber.SendKeys("7237238389139");

                    var CreateAccountBtn = Driver.FindElement(
                    By.XPath("//button[contains(text(),'Create Account')]"));
                    CreateAccountBtn.Click();

                }

        
            }   
        }
    
    }
}