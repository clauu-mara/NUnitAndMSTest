using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NUnitTest
{
    [TestFixture]
    public class UnitTest1
    { 
        static IWebDriver webDriver;

        [SetUp]
        public void Setup()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("http://qa2.dev.evozon.com/");
        }

        public string GetTitle()
        {
            string title = webDriver.Title;
            return title;
        }

        public void SelectMyAccountMenu(string accountMenu)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            IWebElement accountElement = wait.Until(element =>  element.FindElement(By.CssSelector(".account-cart-wrapper > a")));
            accountElement.Click();

            IList<IWebElement> menuElements = wait.Until(element => element.FindElements(By.CssSelector("#header-account>.links>ul li")));
            menuElements.First(item => item.Text == accountMenu).Click();

        }

        [Test]
        public void GetTitleTest()
        {
            Assert.AreEqual("Madison Island", GetTitle());
           
        }

        [Test]
        public void AccountMenuTest()
        {
            SelectMyAccountMenu("My Account");
            webDriver.Navigate().Back();
            SelectMyAccountMenu("My Wishlist");
            webDriver.Navigate().Back();
            SelectMyAccountMenu("My Cart");
            webDriver.Navigate().Back();
            SelectMyAccountMenu("Checkout");
            webDriver.Navigate().Back();
            SelectMyAccountMenu("Register");
            webDriver.Navigate().Back();
            SelectMyAccountMenu("Log In");
            webDriver.Navigate().Back();

        }


        [TearDown]
        public void After()
        {
            webDriver.Quit();
        }
    }
}