using System;
using OpenQA.Selenium;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using OpenQA.Selenium.Support.PageObjects;

namespace CHREnhancements.PageObject.BMAdmin
{
    public class ItemGatingUserGroup : Base
    {
        public static By CorporationDropDown
        { get { return (By.XPath("//*[@id='ctl00_cphMain_rcbCorporation_Input']")); } }

        public static By DistributorDropDown
        { get { return (By.XPath("//*[@id='ctl00_cphMain_rcbDistributor_Input']")); } }

        public static By UserGroup
        { get { return (By.XPath("//*[@id='ctl00_cphMain_rcbUserGroups_Input']")); } }

        public static By GroupNameLabel
        { get { return (By.XPath("//*[text()='GROUP NAME']")); } }

        public static By CorporationDropDownValue
        { get { return (By.XPath("//*[text()=' - Instant Impact 4.0 Demo Corp (Dist.)']")); } }

        Interactions action;
        public ItemGatingUserGroup(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
        }

        //Verify Item Gating user group page
        public void VerifyItemGatingPage()
        {
            try
            {
                action.VerifyCurrentPage("Item Gating Page ", "ItemGatingUserGroup.aspx");
                Console.WriteLine("Item Gating Page is verified");
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify Item Gating page failed due to " + e);
                throw e;
            }
        }

        //Create New User Group
        public void CreateNewUserGroup()
        {
            try
            {
                
                action.Type(CorporationDropDown,"300");
                //action.Click(CorporationDropDown);
                //Driver.FindElement(CorporationDropDown).SendKeys(Keys.ArrowDown)
                action.Type(UserGroup, Keys.ArrowDown);
                action.Type(UserGroup, Keys.ArrowDown);
                action.ScrollToViewElement(CorporationDropDownValue);
                action.Click(CorporationDropDownValue);
                //action.Type(DistributorDropDown, "Chicago Beverage Systems");
                //action.Type(UserGroup, Keys.ArrowDown + Keys.Enter);
                //action.WaitVisible(GroupNameLabel);
                
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify Item Gating page failed due to " + e);
                throw e;
            }
        }


    }
}