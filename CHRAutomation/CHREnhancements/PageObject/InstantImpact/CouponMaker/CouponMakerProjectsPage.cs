using System;
using CHREnhancements.Interaction;
using OpenQA.Selenium;
using CHREnhancements.Initiate;
using System.Collections.Generic;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;

namespace CHREnhancements.PageObject.InstantImpact.CouponMaker
{
    class CouponMakerProjectsPage : Base
    {
        public static By PreviewLink
        { get { return (By.XPath("//*[@id='ctl00_Body_RadGridTemplate_ctl00_ctl04_lnkPreviewImageEnabled']")); } }

        public static By EditLink
        { get { return (By.XPath("//*[@id='ctl00_Body_RadGridTemplate_ctl00_ctl04_lnkEdit']")); } }

        public static By ShareLink
        { get { return (By.XPath("//*[@id='ctl00_Body_RadGridTemplate_ctl00_ctl04_lnkShare']")); } }

        public static By DeleteLink
        { get { return (By.XPath("//*[@id='ctl00_Body_RadGridTemplate_ctl00_ctl04_lnkDeleteDesignEnabled']")); } }

        public static By Account
        { get { return (By.XPath("//*[@href='/Account/MyAccountPage.aspx']")); } }

        public static By AccountProject
        { get { return (By.XPath("//*[@href='MyProjectsPage.aspx']")); } }

        Interactions action;
        public CouponMakerProjectsPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
        }

        // Verify All Links In Work Center
        public void VerifyLinks()
        {
            try
            {
                action.WaitVisible(PreviewLink);
                bool status_of_preview = action.IsElementEnabled(PreviewLink);
                Console.WriteLine("Status of Preview Link is " + status_of_preview);

                action.WaitVisible(EditLink);
                bool status_of_edit = action.IsElementEnabled(PreviewLink);
                Console.WriteLine("Status of Preview Link is " + status_of_edit);

                action.WaitVisible(ShareLink);
                bool status_of_sharelink = action.IsElementEnabled(PreviewLink);
                Console.WriteLine("Status of Preview Link is " + status_of_sharelink);

                action.WaitVisible(DeleteLink);
                bool status_of_delete = action.IsElementEnabled(PreviewLink);
                Console.WriteLine("Status of Preview Link is " + status_of_delete);
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify links projects page failed due to " + e);
                Assert.Fail();
            }           
        }

        //Click on Edit
        public void ClickOnEdit()
        {
            try
            {
                action.WaitVisible(EditLink);
                action.Click(EditLink);
            }
            catch(Exception e)
            {
                Console.WriteLine("Click on Edit failed due to " + e);
                Assert.Fail();
            }
        }

        //Click on Preview
        public void ClickOnPreview()
        {
            try
            {
                action.WaitVisible(PreviewLink);
                action.Click(PreviewLink);
            }
            catch(Exception e)
            {
                Console.WriteLine("Click on Preview failed due to " + e);
                Assert.Fail();
            }
        }

        //Click on Accounts
        public void ClickOnAccounts()
        {
            try
            {
                action.WaitVisible(Account);
                action.Click(Account);
            }
            catch(Exception e)
            {
                Console.WriteLine("Click on Preview failed due to " + e);
                Assert.Fail();
            }
        }

        //Click on Projects in Accounts Page
        public void ClickOnProjectsInACcounts()
        {
            try
            {
                action.WaitVisible(AccountProject);
                action.Click(AccountProject);
            }
            catch(Exception e)
            {
                Console.WriteLine("Click on Projects on Accounts page due to " + e);
                Assert.Fail();
            }
        }
    }
}
