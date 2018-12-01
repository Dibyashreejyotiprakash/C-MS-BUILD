using System;
using System.Collections.Generic;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace CHREnhancements.PageObject.InstantImpact.ClientSpecificLandingPage
{
    class SelectCorporateDistributionPage : Base
    {
        public static By Email
        { get { return (By.Id("UserName")); } }

        public static By Password
        { get { return (By.Id("Password")); } }

        public static By LoginButton
        { get { return (By.Id("btnLogin")); } }

        public static By CorporationDropDown
        { get { return (By.XPath("//*[@id='ddlCorporation']")); } }

        public static By ListOfCorporatios
        { get { return (By.XPath("//*[@id='ddlCorporation']/option")); } }

        public static By Distributors
        { get { return (By.XPath("//*[@id='ddlDistributer']")); } }

        public static By ListOfDistributors
        { get { return (By.XPath("//*[@id='ddlDistributer']/option")); } }

        public static By Login
        { get { return (By.XPath("//*[@id='btnLogin']")); } }

        Interactions action;
        public SelectCorporateDistributionPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
        }

        public void VerifyCorporateDistributors()
        {
            try
            {
                action.WaitVisible(CorporationDropDown);
                action.Click(CorporationDropDown);
                IList<IWebElement> corporations = action.GetElements(ListOfCorporatios);
                int totalcorporations = corporations.Count;
                for(int i=1;i< totalcorporations; i++)
                {
                    action.SelectByIndex(CorporationDropDown,i);
                    try
                    {
                        //Wait.WaitVisible(Distributors);
                        action.Click(Distributors);
                        IList<IWebElement> distributors = action.GetElements(ListOfDistributors);
                        int totaldistributors = distributors.Count;
                        for(int j=1;j<totaldistributors;j++)
                        {
                            action.SelectByIndex(Distributors,j);
                            action.Click(Login);
                            action.WaitForPageToLoad();
                            action.Back();
                        }
                    }
                    catch(Exception e)
                    {
                        action.WaitVisible(Login);
                        action.Click(Login);
                        Console.Write("Select distributors failed due to " + e);
                    }
                    finally
                    {
                        action.WaitForPageToLoad();
                        action.Back();
                    }
                    
                }
                
            }
            catch(Exception e)
            {
                
                Console.WriteLine("Verify corporate distributors failed due to " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }


        //Verify Market Specifc landing page for Corp.300 and its two distributors.
        public void VerifyMarketSpceficLandingPageForCorp300()
        {
            try
            {
                action.WaitVisible(CorporationDropDown);
                action.SelectByIndex(CorporationDropDown,14);
                action.WaitVisible(Distributors);
                action.Click(Distributors);
                for (int j = 1; j < 2; j++)
                {
                    action.SelectByIndex(Distributors, j);
                    action.Click(Login);
                    action.WaitForPageToLoad();
                    action.Back();
                }

            }
            catch(Exception e)
            {
                Console.WriteLine("Verify market specific landing page failed due to " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        public void LoginWithDifferentCredentials(string useranme, string password)
        {
            try
            {
                try
                {
                    action.Type(Email, useranme);
                    action.Type(Password, password);
                    action.Click(LoginButton);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Login faled due to " + e);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Login failed due to " + e);
            }
        }

    }
}
