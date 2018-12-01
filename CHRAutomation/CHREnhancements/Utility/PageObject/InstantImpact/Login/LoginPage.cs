using System;
using CHREnhancements.Initiate;
using NUnit.Framework;
using OpenQA.Selenium;
using CHREnhancements.Interaction;
using OpenQA.Selenium.Support.PageObjects;

namespace CHREnhancements.PageObject.InstantImpact.Login
{
    public class LoginPage : Base
    {
        public static By InstantImpactLogo
        { get { return (By.XPath("//*[contains(text(),'Instant Impact Login')]")); } }

        public static By Email
        { get { return (By.Id("UserName")); } }

        public static By Password
        { get { return (By.Id("Password")); } }

        public static By LoginButton
        { get { return (By.Id("btnLogin")); } }

        public static By CorporationDropdownList
        { get { return (By.XPath("//*[@id='ddlCorporation']")); } }

        Interactions action;
        public LoginPage(IWebDriver Driver)
        {
                this.Driver = Driver;
                PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
        }

        public void LoginWithCorpSupplier()
        {
            try
            {
                bool statusofcorporationdropdownlist = action.IsElementPresent(CorporationDropdownList);
                if (statusofcorporationdropdownlist == true)
                {
                    action.SelectByText(CorporationDropdownList, "Demo Supplier (QA)");
                }
                else
                {
                    Console.WriteLine("Corporation is not available");
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public void LoginToApplication(string email, string pwd)
        {
            try
            {
                ////Verify Title of Login page
                //string actual_title = Driver.Title;
                //Assert.IsTrue(actual_title.Contains("Instant Impact"), actual_title + "Error msg -Title does not contain Log in");

                ////Verify Logo visibilty
                //action.WaitVisible(InstantImpactLogo);
                //action.IsElementDisplayed(InstantImpactLogo);

                

                try
                {

                    //Login
                    action.Type(Email, email);
                    action.Type(Password, pwd);
                    action.Click(LoginButton);
                    action.WaitForPageToLoad();
                    bool statusofcorporationdropdownlist = action.IsElementPresent(CorporationDropdownList);
                    if (statusofcorporationdropdownlist == true)
                    {
                        action.SelectByText(CorporationDropdownList, "Demo Supplier (QA)");
                        action.Click(LoginButton);
                    }
                    else
                    {
                        Console.WriteLine("Corporation is not available");
                    }

                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("LoginToApplication failed due to: " + e);
                throw e;
            }

        }

    }
}