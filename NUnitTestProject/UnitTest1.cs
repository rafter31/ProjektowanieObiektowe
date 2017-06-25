using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnitTestProject.pom;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace NUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver = new FirefoxDriver();
        [TestMethod]
        public void LogInUser()
        {
            LogInPage page = new LogInPage();
            IWebDriver result =  page.LogInUser(driver, "admin@admin.pl", "qw12QW!@");
            var userName= result.FindElement(By.Id("UserMail")).Text;
            Assert.AreEqual(userName, "Hello admin@admin.pl!");
            driver.Quit();

        }
        [TestMethod]
        public void LogOutUser()
        {
            LogInPage page = new LogInPage();
            page.LogOutUser(driver);
            string result = driver.FindElement(By.Id("loginLink")).Text;
            Assert.AreEqual(result, "Log in");
            driver.Quit();

        }
        [TestMethod]
        public void AddToCartLogIn()
        {
            ProductListPage page = new ProductListPage();
            page.AddToCartLogIn(driver);
            driver.Quit();
        }
        [TestMethod]
        public void AddToCartNotLogIn()
        {
            ProductListPage page = new ProductListPage();
            page.AddToCartNotLogIn(driver);
            var text = driver.FindElement(By.ClassName("alert-danger")).Text;
            Assert.AreEqual(text, "Musisz być zalogowany");
            driver.Quit();
        }

        [TestMethod]
        public void DeleteItemFromCart()
        {
            CartItemPage page = new CartItemPage();
            page.DeleteItemFromCart(driver);
            driver.Quit();
        }
        [TestMethod]
        public void PayForOrder()
        {
            CartItemPage page = new CartItemPage();
            page.PayForOrder(driver);
            var result = driver.FindElements(By.ClassName("alert-success")).First().Text;
            Assert.AreEqual(result, "Twoja wpłata została pomyślnie zaksiegowana");
            driver.Quit();
        }
    }
}
