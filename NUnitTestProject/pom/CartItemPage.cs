using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace NUnitTestProject.pom
{
    class CartItemPage
    {
        public void DeleteItemFromCart(IWebDriver driver)
        {
            ProductListPage productListPage = new ProductListPage();
            productListPage.AddToCartLogIn(driver);
            int oldProdCount = driver.FindElements(By.ClassName("prod_name")).Count;
            driver.FindElements(By.ClassName("glyphicon-remove")).First().Click();
            Thread.Sleep(2000);
            int newProdCount = driver.FindElements(By.ClassName("prod_name")).Count;
            Assert.IsTrue(newProdCount < oldProdCount);
        }

        public IWebDriver PayForOrder(IWebDriver driver)
        {
            ProductListPage productListPage = new ProductListPage();
            productListPage.AddToCartLogIn(driver);
            Thread.Sleep(2000);
            driver.FindElement(By.Id("PayBtn")).Click();
            Thread.Sleep(2000);
            
            
            return driver;
        }
    }
}
