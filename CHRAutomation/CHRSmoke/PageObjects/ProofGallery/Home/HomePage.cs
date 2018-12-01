using System;
using CHRSmoke.Initiate;
using OpenQA.Selenium;
using CHRSmoke.Interaction;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;


namespace CHRSmoke.PageObjects.ProofGallery.Home
{
    public class HomePage : Base
    {

        public static By CorporationDropDown
        { get { return (By.XPath("//*[@id='MainContent_ucSearch_ddlCorps']")); } }

        public static By YearDropDown
        { get { return (By.XPath("//*[@id='MainContent_ucSearch_ddlYear']")); } }

        public static By MonthDropDown
        { get { return (By.XPath("//*[@id='MainContent_ucSearch_ddlMonth']")); } }

        public static By DtNumber
        { get { return (By.XPath("//*[@id='MainContent_ucSearch_txtDTNumber']")); } }

        public static By GetProofsBtn
        { get { return (By.XPath("//*[@id='MainContent_btnGetProofs']")); } }

        public static By ResetBtn
        { get { return (By.XPath("//*[@id='MainContent_btnReset']")); } }
        

        public static By LogOut
        { get { return (By.XPath("//*[@href='Logout.aspx']")); } }


        IWebDriver Driver;
        public HomePage(IWebDriver Driver)
        {
            this.Driver = Driver;
            //PageFactory.InitElements(Driver, this);
        }

        public void ChcekStatusOfButton()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                bool statusofgetproofsbtn = action.IsElementEnabled(GetProofsBtn);
                Console.WriteLine("Status of Get Proofs button is " + statusofgetproofsbtn);

                bool statusofresetbtn = action.IsElementEnabled(ResetBtn);
                Console.WriteLine("Status of Get Proofs button is " + statusofresetbtn);

            }
            catch(Exception e)
            {
                Console.WriteLine("Chcek Status Of Button failed due to " + e);
                throw e;
            }
        }

        public void GetProofsWithoutFilterSearch()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                action.SelectByIndex(CorporationDropDown,0);
                action.SelectByIndex(YearDropDown, 2);
                action.SelectByIndex(MonthDropDown, 3);
                action.Click(GetProofsBtn);
            }
            catch(Exception e)
            {
                Console.WriteLine("Get Proofs Without Filter Search failed due to " + e);
                Console.WriteLine("No corporation is available");
                throw e;
            }
        }
        


        public void Logout()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                action.Click(LogOut);
                action.WaitForPageToLoad();
                string pageurl = action.GetCurrentUrl();
                if (pageurl.Contains("Login.aspx"))
                {
                    Console.WriteLine("Logged out successfully");
                }
                else
                {
                    Assert.Fail();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Logout failed due to " + e);
                throw e;
            }
            
        }
    }
}