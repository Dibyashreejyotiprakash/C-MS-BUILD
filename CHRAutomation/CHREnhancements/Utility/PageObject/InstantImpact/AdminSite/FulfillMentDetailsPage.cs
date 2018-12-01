using System;
using OpenQA.Selenium;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using NUnit.Framework;

namespace CHREnhancements.PageObject.InstantImpact.AdminSite
{
    public class FulfillMentDetailsPage : Base
    {
        public static By FulfillmentDetailsHeader
        { get { return (By.XPath("//*[text()='Fulfillment - Item/SKU Details']")); } }

        public static By AllCorporationNames
        { get { return (By.XPath("(//*[@class='rcbList'])[1]/li")); } }

        public static By CorporationDropdown
        { get { return (By.XPath("//*[@id='ctl00_cphMain_rcbCorp_Arrow']")); } }

        Interactions action;
        public FulfillMentDetailsPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
        }

        //Verify Fulfillment Details Page
        public void VerifyFulfillmentDetailsPage()
        {
            try
            {
                action.WaitVisible(FulfillmentDetailsHeader);
                bool statusofheader = action.IsElementDisplayed(FulfillmentDetailsHeader);
                Console.WriteLine("Status of header is " + statusofheader);
                Assert.IsTrue(statusofheader);
            }
            catch(Exception e)
            {
                Console.WriteLine("Select corporation failed due to " + e);
                //Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Verify all Corporation name from drop down with Database
        public void VerifyCoroprationNameWithDatabase()
        {
            try
            {
                action.WaitVisible(CorporationDropdown);
                action.Click(CorporationDropdown);
                action.WaitTime(5);
                IList<IWebElement> corporationnamesinui = action.GetElements(AllCorporationNames);
                Console.WriteLine("Number of corp name in ui " + corporationnamesinui.Count);
                foreach (IWebElement obj in corporationnamesinui)
                {
                    Console.WriteLine("All corporations name in ui are " + obj.Text);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Select corporation failed due to " + e);
                //Closing browser
                Driver.Quit();
                throw e;
            }
        }

    }
}
