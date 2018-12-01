using System;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace CHREnhancements.PageObject.InstantImpact.Confirmation
{
    public class ConfirmationPage : Base
    {
        public static By ReturnToSearchPageBtn
        { get { return (By.XPath("//*[text()='Return to Search Page']")); } }

        Interactions action;
        public ConfirmationPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
        }

        //Verify Confirmation page
        public void VerifyConfirmationPage()
        {
            try
            {
                string act_currenturl = Driver.Url;
                if (act_currenturl.Contains("Confirmation"))
                {
                    Console.WriteLine("Confirmation page verified successfully.");
                }
                else
                {
                    Assert.Fail();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify confirmation page failed due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Click on  ReturnToSearchPage
        public void ClickOnReturnToSearchPage()
        {
            try
            {
                action.WaitVisible(ReturnToSearchPageBtn);
                action.Click(ReturnToSearchPageBtn);
            }
            catch(Exception e)
            {
                Console.WriteLine("Click on return to serch page failed due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }
    }
}
