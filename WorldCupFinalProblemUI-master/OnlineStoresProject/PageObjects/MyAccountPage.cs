using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using WorldCupFinalProblemUI.Core;

namespace UI.PageObjects
{
    class MyAccountPage
    {
        private readonly IWebDriver driver = null;

        public MyAccountPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement Hello_txt => driver.FindElement(By.XPath("//p[contains(text(),'Hello')]"));

        public String getTextFromHelloTxt()
        {
            return Hello_txt.Text;
        }

    }
}
