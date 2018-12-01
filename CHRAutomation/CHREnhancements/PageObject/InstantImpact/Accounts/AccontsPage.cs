using System;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace CHREnhancements.PageObject.InstantImpact.Accounts
{
    public class AccontsPage : Base
    {
        public static By SearchFieldInHeader
        { get { return (By.XPath("//*[@id='txtSearch']")); } }

        public static By Account
        { get { return (By.XPath("//*[@href='/Account/MyAccountPage.aspx']")); } }

        public static By Help
        { get { return (By.XPath("//*[@class='MenuItems']/div/div/ul/li[6]")); } }

        public static By Profile
        { get { return (By.XPath("//*[@href='Profile.aspx']")); } }

        public static By Reports
        { get { return (By.XPath("//*[@href='Reports.aspx']")); } }

        public static By AddressBook
        { get { return (By.XPath("//*[@href='AddressBook.aspx']")); } }

        public static By AddressList
        { get { return (By.XPath("//*[@href='AddressLists.aspx']")); } }

        public static By LogoMaker
        { get { return (By.XPath("//*[@href='MyLogoLocker.aspx']")); } }

        Interactions action;
        public AccontsPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
        }

        //Verify Accounts Page
        public void VerifyAccountsPage()
        {
            try
            {
                action.VerifyCurrentPage("Accounts page","MyAccountPage");
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify Accounts page failed due to " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Verify search Field
        public void VerifySeachFiled()
        {
            try
            {
                action.WaitVisible(SearchFieldInHeader);
                bool status = action.IsElementDisplayed(SearchFieldInHeader);
                Console.WriteLine("Status of search field in Accounts page " + status);
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

        //Click on Help Button.
        public void ClickOnHelp()
        {
            try
            {
                action.WaitVisible(Help);
                action.Click(Help);
            }
            catch (Exception e)
            {
                Console.WriteLine("Click on help failed due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Click on Address Book.
        public void ClickOnAddressBook()
        {
            try
            {
                action.WaitVisible(AddressBook);
                action.Click(AddressBook);
            }
            catch (Exception e)
            {
                Console.WriteLine("Click on Address Book due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Click on Profile
        public void ClickOnProfile()
        {
            try
            {
                action.WaitVisible(Profile);
                action.Click(Profile);
            }
            catch (Exception e)
            {
                Console.WriteLine("Click on profile failed due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Click on Reports
        public void ClickOnReports()
        {
            try
            {
                action.WaitVisible(Reports);
                action.Click(Reports);
            }
            catch (Exception e)
            {
                Console.WriteLine("Click on reports failed due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Click on Help Button.
        public void ClickOnAddressList()
        {
            try
            {
                action.WaitVisible(AddressList);
                action.Click(AddressList);
            }
            catch (Exception e)
            {
                Console.WriteLine("Click on help failed due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Click on Logo Maker.
        public void ClickOnLogoLocker()
        {
            try
            {
                action.WaitVisible(LogoMaker);
                action.Click(LogoMaker);
            }
            catch (Exception e)
            {
                Console.WriteLine("Click on Logo maker due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }
    }
}