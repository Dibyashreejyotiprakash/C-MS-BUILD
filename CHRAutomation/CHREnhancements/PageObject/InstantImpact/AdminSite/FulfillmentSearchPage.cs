using System;
using OpenQA.Selenium;
using CHREnhancements.Interaction;
using System.Collections.Generic;
using CHREnhancements.Initiate;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;

namespace CHREnhancements.PageObject.InstantImpact.AdminSite
{
    public class FulfillmentSearchPage : Base
    {

        public static By SearchHeader
        { get { return (By.XPath("//*[text()='Fulfillment - Fulfillment Search']")); } }

        public static By CorporationDropdown
        { get { return (By.XPath("//*[@id='ctl00_cphMain_rcbCorp_Arrow']")); } }

        public static By AllCorporationNames
        { get { return (By.XPath("(//*[@class='rcbList'])[1]/li")); } }

        public static By Fulfillment
        { get { return (By.XPath("(//*[text()='Fulfillment'])[1]")); } }

        public static By FulfillmentSearch
        { get { return (By.XPath("(//*[text()='Fulfillment Search'])[1]")); } }

        public static By Table
        { get { return (By.XPath("//*[@id='ctl00_cphMain_radGrdFulfillmentSearch']")); } }

        public static By Description
        { get { return (By.XPath("//*[text()='Description']")); } }

        public static By Coropration
        { get { return (By.XPath("(//*[text()='Corporation'])[2]")); } }

        public static By SKU
        { get { return (By.XPath("//*[text()='SKU(S)']")); } }

        public static By TypeName
        { get { return (By.XPath("//*[text()='Type Name']")); } }

        public static By Store
        { get { return (By.XPath("(//*[text()='Store'])[2]")); } }

        Interactions action;
        public FulfillmentSearchPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
        }

        //Verify Fulfillment Search
        public void VerifyFulfillmentSearchPage()
        {
            try
            {
                action.WaitVisible(SearchHeader);
                bool statusofsearchheader = action.IsElementDisplayed(SearchHeader);
                Console.WriteLine("Status of Fulfillment search header is " + statusofsearchheader);
                Assert.IsTrue(statusofsearchheader);
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify Fulfillment Search page failed due to " + e);
                //Closing browser
                Driver.Quit();
                throw e;
            }
        }

        
        //Verify all Corporation name from drop down with Database
        public void VerifyCoroprationNameWithDatabes()
        {
            try
            {
                action.WaitVisible(CorporationDropdown);
                action.Click(CorporationDropdown);
                IList<IWebElement> corporationnamesinui = action.GetElements(AllCorporationNames);
                Console.WriteLine("Number of corp name in ui " + corporationnamesinui.Count);
                foreach(IWebElement obj in corporationnamesinui)
                {
                    Console.WriteLine("All corporations name in ui are " + obj.Text);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Select corporation failed due to " + e);
                //Closing browser
                Driver.Quit();
                throw e;
            }
        }


        //Clicl on Fulfillment Search
        public void ClickOnFulfillmentSearch()
        {
            try
            {
                //Hover on InstantImpact
                action.WaitVisible(Fulfillment);
                action.MouseOverOnElement(Fulfillment);
                //Hover on Fulfillment Saerch
                action.WaitVisible(FulfillmentSearch);
                action.MouseHoverAndClick(FulfillmentSearch);
            }
            catch(Exception e)
            {
                Console.WriteLine("Click on Fulfillment search failed due to " + e);
                //Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //verify Sorting
        public void VerifySorting()
        {
            try
            {
                //Sort Description
                action.WaitVisible(Description);
                action.Click(Description);
                action.WaitTime(5);
                Console.WriteLine("Description srted.");

                //Sort Corporation
                action.WaitVisible(Coropration);
                action.Click(Coropration);
                action.WaitTime(5);
                Console.WriteLine("Corporation sorted.");

                //Sort Sku
                action.WaitVisible(SKU);
                action.Click(SKU);
                action.WaitTime(5);
                Console.WriteLine("Sku sorted.");

                //Sort Type name
                action.WaitVisible(TypeName);
                action.Click(TypeName);
                action.WaitTime(5);
                Console.WriteLine("Name sorted.");

                //Sort Store
                action.WaitVisible(Store);
                action.Click(Store);
                Console.WriteLine("Store sorted.");
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify Sorting failed due to " + e);
                //Closing browser
                Driver.Quit();
                throw e;
            }
        }
        
    }
}
