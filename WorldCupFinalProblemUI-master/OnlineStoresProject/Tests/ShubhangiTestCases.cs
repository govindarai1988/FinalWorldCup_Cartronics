using System;
using System.Configuration;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using UI.PageObjects;
using WorldCupFinalProblemUI.Tests;
using RelevantCodes.ExtentReports;
using WorldCupFinalProblemUI.Core;
using WorldCupFinalProblemUI.TestDataAccess;

namespace WorldCupFinalProblemUI
{
    public class ShubhangiTestCases : BaseTest
    {


        [Test, Category("Smoke Test")]
        [Author("Cartronics Team", "gaurav677890@gmail.com")]
        public void TestCase1()
        {
            test.AssignAuthor("Cartronics Team");
            BrowserMethods.getDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            BrowserMethods.Goto(ConfigurationManager.AppSettings["url"]);
            test.Log(LogStatus.Info, "Opened Browser");
            BrowserMethods.getDriver.Manage().Window.Maximize();
            Assert.That(BrowserMethods.Title, Contains.Substring("Google"));
            var homePage = new HomePage(BrowserMethods.getDriver);
            homePage.clickOnDismissButton();
            homePage.clickOnMyAccountTab();
            var userData = ExcelDataAccess.GetTestData("LoginTest");
            homePage.loginToApplicationWithCredentials(userData.Username, userData.Password);
            var accountPage = new MyAccountPage(BrowserMethods.getDriver);
            Assert.That(accountPage.getTextFromHelloTxt, Contains.Substring(String.Format("Hello {0}", userData.Username)));
            test.Log(LogStatus.Info, "Successfully login to the application");
            test.Log(LogStatus.Pass, TestContext.CurrentContext.Test.MethodName + "Test Case passed");
        }
    }
}
