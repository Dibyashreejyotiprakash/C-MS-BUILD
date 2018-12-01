using System;
using OpenQA.Selenium;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;

namespace CHREnhancements.PageObject.InstantImpact.Help
{
    class HelpPage : Base
    {
        public static By HelpHeader
        { get { return (By.XPath("//*[text()='Help'][2]")); } }

        public static By TrainingGuide
        { get { return (By.XPath("//*[@href='/iiassets/44/Documents/Instant Impact 4.0 Training Guide.pdf']")); } }

        public static By SearchFieldInHeader
        { get { return (By.XPath("//*[@id='txtSearch']")); } }

        Interactions action;
        public HelpPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
        }

        //Verify Help Page
        public void VerifyHelpPage()
        {
            try
            {
                action.WaitForPageToLoad();
                action.WaitVisible(HelpHeader);
                bool status_of_helpheder = action.IsElementDisplayed(HelpHeader);
                Console.WriteLine("Status of Help Header is " + status_of_helpheder);
                Assert.IsTrue(status_of_helpheder.Equals(true), status_of_helpheder + "Error msg -Help Header is not displaying");
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify Help Page failed due to: " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Verify seach Field
        public void VerifySeachFiled()
        {
            try
            {
                action.WaitVisible(SearchFieldInHeader);
                bool status = action.IsElementDisplayed(SearchFieldInHeader);
                Console.WriteLine("Status of search field is in Help page " + status);
                Assert.IsTrue(status);
            }
            catch (Exception e)
            {
                Console.WriteLine("VerifyHomePage failed due to: " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Click on Training Guides
        public void ClickOnTrainingGudes()
        {
            try
            {
                action.WaitForPageToLoad();
                action.WaitVisible(TrainingGuide);
                action.Click(TrainingGuide);
            }
            catch (Exception e)
            {
                Console.WriteLine("Click on Training guide failed due to: " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }
    }
}
