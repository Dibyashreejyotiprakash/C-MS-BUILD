using System;
using OpenQA.Selenium;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;

namespace CHREnhancements.PageObject.InstantImpact.Profile
{
    public class ProfilePage : Base
    {
        public static By SearchFieldInHeader
        { get { return (By.XPath("//*[@id='txtSearch']")); } }

        public static By ProfileHeader
        { get { return (By.XPath("//*[@class='row no-gutters standardHeader']")); } }

        Interactions action;
        public ProfilePage(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
        }

        //Verify seach Field
        public void VerifySeachFiled()
        {
            try
            {
                action.WaitVisible(SearchFieldInHeader);
                bool status = action.IsElementDisplayed(SearchFieldInHeader);
                Console.WriteLine("Status of search field in Profile page " + status);
                Assert.IsTrue(status);
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify Search Field failed due to: " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Verify Profile page
        public void VerifyProfilePage()
        {
            try
            {
                action.WaitVisible(ProfileHeader);
                bool statusofprofile = action.IsElementDisplayed(ProfileHeader);
                Console.WriteLine("Status of profile header is " + statusofprofile);
                Assert.IsTrue(statusofprofile);
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify Profile page failed due to: " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }
    }
}
