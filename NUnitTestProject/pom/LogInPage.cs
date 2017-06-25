using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace NUnitTestProject.pom
{
    class LogInPage
    {

        public IWebDriver LogInUser(IWebDriver driver,string email, string password)
        {
            driver.Url = "http://localhost:17386/Account/Login";
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            driver.FindElement(By.Id("Email")).SendKeys(email);
            driver.FindElement(By.Id("Password")).SendKeys(password);
            driver.FindElement(By.Id("LogInBtn")).Click();
            return driver;


        }
        public IWebDriver LogOutUser(IWebDriver driver)
        {
            LogInUser(driver,"admin@admin.pl", "qw12QW!@");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("LogOffBtn")).Click();
            return driver;


        }
      

    }
}
