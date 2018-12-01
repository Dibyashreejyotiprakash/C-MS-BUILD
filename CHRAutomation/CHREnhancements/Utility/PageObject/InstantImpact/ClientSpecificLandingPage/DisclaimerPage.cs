using CHREnhancements.Interaction;
using System;
using System.Collections.Generic;
using CHREnhancements.Initiate;
using OpenQA.Selenium;
using System.Web;
using OpenQA.Selenium.Support.PageObjects;

namespace CHREnhancements.PageObject.InstantImpact.ClientSpecificLandingPage
{
    public class DisclaimerPage : Base
    {
        public static By CorporationDropDown
        { get { return (By.XPath("//*[@id='ddlCorporation']")); } }

        public static By DistributorsDropDown
        { get { return (By.XPath("//*[@id='ddlDistributer']")); } }

        public static By Loginbtn
        { get { return (By.XPath("//*[@id='btnLogin']")); } }

        public static By PosOnDemandtab
        { get { return (By.XPath("//*[@href='/Search/ItemSearch.aspx']")); } }

        public static By SearchInputField
        { get { return (By.XPath("//*[@id='Body_txtSearch']")); } }

        public static By SearchBtn
        { get { return (By.XPath("//*[@id='ctl00_Body_btnSearch']")); } }

        public static By SearchResult
        { get { return (By.XPath("//*[@id='Body_lblItemCount']/b")); } }

        public static By ListOfCorporatios
        { get { return (By.XPath("//*[@id='ddlCorporation']/option")); } }

        public static By Distributors
        { get { return (By.XPath("//*[@id='ddlDistributer']")); } }

        public static By ListOfDistributors
        { get { return (By.XPath("//*[@id='ddlDistributer']/option")); } }

        public static By DisclaimerBtn
        { get { return (By.XPath("//*[contains(@id,'btnAccept')]")); } }

        Interactions action;
        public DisclaimerPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
        }

        //Select Corporation
        public void SelectCorporation()
        {
            try
            {
                action.SelectByText(CorporationDropDown, "Instant Impact 4.0 Demo Corp (Dist.)");
            }
            catch (Exception e)
            {
                Console.WriteLine("Select Corporation failed due to " + e);
                throw e;
            }
        }
        //Select Distribution
        public void SelectDistributor()
        {
            try
            {
                action.SelectByText(DistributorsDropDown, "Chicago Beverage Systems");
            }
            catch (Exception e)
            {
                Console.WriteLine("Select Distributor failed due to " + e);
                throw e;
            }
        }

        public void ClickonLogin()
        {
            try
            {
                action.Click(Loginbtn);
            }
            catch (Exception e)
            {
                Console.WriteLine("Click on Login button failed due to " + e);
                throw e;
            }
        }

        public void ClickOnPosOnDemand()
        {
            try
            {
                action.Click(PosOnDemandtab);
            }
            catch (Exception e)
            {
                Console.WriteLine("Click On Pos On Demand button failed due to " + e);
                throw e;
            }
        }

        public void SearchTemplate()
        {
            try
            {
                action.Type(SearchInputField, "March");
                action.Click(SearchBtn);
                action.WaitTime(5);
                string searchresult_march = action.GetText(SearchResult);
                Console.WriteLine("No. of templates are " + searchresult_march);
                action.Clear(SearchInputField);
                action.WaitTime(5);
                action.Type(SearchInputField, "July");
                action.Click(SearchBtn);
                action.WaitTime(5);
                string searchresult_july = action.GetText(SearchResult);
                Console.WriteLine("No. of templates are " + searchresult_july);
                action.Clear(SearchInputField);
                action.Type(SearchInputField, "March July");
                action.Click(SearchBtn);
                string searchresult_marchjuly = action.GetText(SearchResult);
                Console.WriteLine("No. of templates are " + searchresult_marchjuly);
            }
            catch (Exception e)
            {
                Console.WriteLine("Search Template failed due to " + e);
                throw e;
            }
        }

        public void VerifyDisclaimerPage()
        {
            try
            {

                action.WaitVisible(CorporationDropDown);
                action.Click(CorporationDropDown);
                IList<IWebElement> corporations = action.GetElements(ListOfCorporatios);
                int totalcorporations = corporations.Count;
                for (int i = 1; i < totalcorporations; i++)
                {
                    action.SelectByIndex(CorporationDropDown, i);
                    try
                    {
                        //Wait.WaitVisible(Distributors);
                        action.Click(Distributors);
                        IList<IWebElement> distributors = action.GetElements(ListOfDistributors);
                        int totaldistributors = distributors.Count;
                        for (int j = 1; j < totaldistributors; j++)
                        {
                            action.SelectByIndex(Distributors, j);
                            action.Click(Loginbtn);
                            action.WaitForPageToLoad();
                            action.Click(DisclaimerBtn);
                            action.WaitForPageToLoad();
                            action.Back();
                            action.Back();
                            action.WaitForPageToLoad();
                        }
                    }
                    catch (Exception e)
                    {
                        action.WaitVisible(Loginbtn);
                        action.Click(Loginbtn);
                        action.Click(DisclaimerBtn);
                        Console.Write("Select distributors failed due to " + e);
                    }
                    finally
                    {
                        action.WaitForPageToLoad();
                        action.Back();
                        action.Back();
                        action.WaitForPageToLoad();
                    }

                }

            }
            catch (Exception e)
            {

                Console.WriteLine("Verify corporate distributors failed due to " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }
    }
}