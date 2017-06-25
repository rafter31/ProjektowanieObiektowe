using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace NUnitTestProject.pom
{
    class ProductListPage
    {
        public int AddToCart(IWebDriver driver)
        {
            driver.Url = "http://localhost:17386/Product";
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            driver.FindElements(By.ClassName("prod_image")).First().Click();
            driver.FindElement(By.Id("txtQuantity")).SendKeys("1");
            driver.FindElement(By.Id("AddToCartBtn")).Click();
            Thread.Sleep(2000);
            return driver.FindElements(By.ClassName("prod_name")).Count;     
        }

        public void AddToCartLogIn(IWebDriver driver)
        {
            LogInPage page = new LogInPage();
            page.LogInUser(driver, "admin@admin.pl", "qw12QW!@");

            Thread.Sleep(3000);
            int count = AddToCart(driver);
            Assert.IsTrue(count >= 1);
           
        }
        public IWebDriver AddToCartNotLogIn(IWebDriver driver)
        {         
            int count = AddToCart(driver);
            return driver;
            //Assert.IsFalse(count>=1);  
            //driver.Close();

        }
    }
}
