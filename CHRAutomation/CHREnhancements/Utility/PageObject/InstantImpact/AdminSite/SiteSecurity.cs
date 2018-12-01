using System;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using CHREnhancements.Utility.TestdataUtilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace CHREnhancements.PageObject.InstantImpact.AdminSite
{
    public class SiteSecurity : Base
    {
        public static By ReadOnlyCreditcard
        { get { return (By.XPath("//*[@id='cphMain_cphMain_cblRoleList_5']")); } }

        public static By UpdateUser
        { get { return (By.XPath("//*[@id='cphMain_cphMain_btnSaveUser']")); } }

        public static By SelectUser
        { get { return (By.XPath("//*[@name='ctl00$ctl00$cphMain$cphMain$SelectedUserEditor']")); } }

        Interactions action;
        public SiteSecurity(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
        }

        public void VerifySiteSecurityPage()
        {
            try
            {
                action.VerifyCurrentPage("Site Security Page", "SiteSecurity.aspx");
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify Site Security Page failed due to " + e);
                throw e;
            }
        }

        //Click on CreidtCardReadOnly
        public void ClickOnCreditCradReadOnly()
        {
            try
            {
                action.ScrollToViewelement(ReadOnlyCreditcard);
                action.Click(ReadOnlyCreditcard);
            }
            catch(Exception e)
            {
                Console.WriteLine("Click on Creidt Card Read Only failed due to " + e);
                throw e;
            }
        }

        //CLick on UpdateUser
        public void Updateuser()
        {
            try
            {
                IWebElement selectuser = Driver.FindElement(By.XPath("//*[@name='ctl00$ctl00$cphMain$cphMain$SelectedUserEditor']"));
                selectuser.SendKeys("Jyoti, Dibyashree (Dibyashree.Jyoti@brandmuscle.com)");
                selectuser.SendKeys(Keys.Enter);
                action.Click(ReadOnlyCreditcard);
                action.ScrollToViewElement(UpdateUser);
                action.Click(UpdateUser);
            }
            catch(Exception e)
            {
                Console.WriteLine("Click on Update User failed due to " + e);
                throw e;
            }
        }

    }
}