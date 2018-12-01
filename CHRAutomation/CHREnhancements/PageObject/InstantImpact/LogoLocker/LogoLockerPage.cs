using System;
using OpenQA.Selenium;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;

namespace CHREnhancements.PageObject.InstantImpact.LogoLocker
{
    public class LogoLockerPage : Base
    {
        public static By Accountname
        { get { return (By.XPath("//*[@id='Body_txtAccountName']")); } }

        public static By LogoLocker
        { get { return (By.XPath("//*[@id='Body_btnUploadLogoLockerPanel']")); } }

        public static By UploadNewLogo
        { get { return (By.XPath("//*[@id='Body_btnUploadLogoLockerPanel']")); } }

        public static By SearchFieldInHeader
        { get { return (By.XPath("//*[@id='txtSearch']")); } }

        public static By Search
        { get { return (By.XPath("//*[@id='Body_txtSearch']")); } }

        public static By SearchBtn
        { get { return (By.XPath("//*[@id='ctl00_Body_btnSearch']")); } }

        public static By AccountsName
        { get { return (By.XPath("//*[@id='ctl00_Body_radGrdLogoLocker_ctl00__0']/td[2]")); } }

        Interactions action;
        public LogoLockerPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
        }

        //Click on UpLoad New Logo
        public void ClickOnUplaodNewLogo()
        {
            try
            {
                action.ScrollToViewElement(UploadNewLogo);
                action.WaitVisible(UploadNewLogo);
                action.Click(UploadNewLogo);
            }
            catch(Exception e)
            {
                Console.WriteLine("Click on Upload new logo failed due to " + e);
                Assert.Fail();
            }
        }

        //Verify Max Length for Account Name
        public void VerifyAccountNameWithMaxLength()
        {
            try
            {
                string accountname = action.StringGenerator(100); 
                action.WaitVisible(Accountname);
                action.Type(Accountname,accountname);
                int lenghth_of_accountname = accountname.Length;
                Console.WriteLine("Length of account name is " + lenghth_of_accountname);
                Assert.AreEqual(100, lenghth_of_accountname);
                Console.WriteLine("Maximum field length for Account Name meets requirement..");
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify Max Length For Account Name failed due to " + e);
                Assert.Fail();
            }
        }

        //Verify seach Field
        public void VerifySeachFiled()
        {
            try
            {
                action.WaitVisible(SearchFieldInHeader);
                bool status = action.IsElementDisplayed(SearchFieldInHeader);
                Console.WriteLine("Status of search field in Logo Maker page " + status);
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

        //Verfiy search logo in Logo locker
        public void VerifySearchLogoWithAccountname()
        {
            try
            {
                action.WaitVisible(AccountsName);
                string accountname = action.GetText(AccountsName);
                action.WaitVisible(Search);
                action.Type(Search,accountname);
                action.Click(SearchBtn);
                IWebElement actualname = Driver.FindElement(By.XPath("//*[@id='Body_txtSearch']"));
                string actualaccontname = actualname.GetAttribute("value");
                Assert.IsTrue(actualaccontname.Contains(accountname), actualaccontname + "Searched logo is not there in grid");
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify Search with account name failed due to: " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }
    }
}
