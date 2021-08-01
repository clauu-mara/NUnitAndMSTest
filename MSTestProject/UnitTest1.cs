using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MSTestProject
{
    [TestClass]
    public class UnitTest1
    {
        static IWebDriver webDriver ;
        
        [TestInitialize]
        public void Before()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("http://qa2.dev.evozon.com/");
        }

        public string  GetTitle()
        {
           string title= webDriver.Title;
            return title;
        }


        public void SelectMyAccountMenu(string accountMenu)
        {
            IWebElement accountElement = webDriver.FindElement(By.CssSelector(".account-cart-wrapper > a"));
            accountElement.Click();
            IList<IWebElement> menuElements = webDriver.FindElements(By.CssSelector("#header-account>.links>ul li"));
            menuElements.First(item => item.Text == accountMenu).Click();

        }


        [TestMethod]
        public void TestMethod_Title()
        {
            GetTitle().Should().Be("Madison Island");
        }


        [TestMethod]
        public void TestMethod_AccountMenu()
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
            
            /*SelectMyAccountMenu(MyAccountMenu.MyAccount);
            SelectMyAccountMenu(MyAccountMenu.MyWishlist);
            SelectMyAccountMenu(MyAccountMenu.MyCart);
            SelectMyAccountMenu(MyAccountMenu.Checkout);
            SelectMyAccountMenu(MyAccountMenu.Register);
            SelectMyAccountMenu(MyAccountMenu.Login);*/
        }

        [TestCleanup]
        public void After()
        {
            webDriver.Quit();
        }
    }
}
