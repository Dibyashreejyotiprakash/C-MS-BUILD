using System;
using OpenQA.Selenium;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;

namespace CHREnhancements.PageObject.InstantImpact.AddressBook
{
    public class AddressBookPage : Base
    {
        public static By SearchFieldInHeader
        { get { return (By.XPath("//*[@id='txtSearch']")); } }

        Interactions action;
        public AddressBookPage(IWebDriver Driver)
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
                Console.WriteLine("Status of search field is in Address Book page " + status);
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
    }
}
