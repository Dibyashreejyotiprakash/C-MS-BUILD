using System;
using System.Configuration;
using CHRSmoke.Initiate;
using CHRSmoke.Interaction;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;

namespace CHRSmoke.PageObjects.InstantImpact.Login
{
    public class LoginPage : Base
    {

        public By loginUserName { get { return By.XPath(("//input[@id='UserName']")); } }
        public By loginPassword { get { return By.Id("Password"); } }
        public By loginButton { get { return By.Id("btnLogin"); } }
        public By lnkLougout { get { return By.Id("lbLogout"); } }
        public By ddlCorporation { get { return By.XPath("//select[@id='ddlCorporation']"); } }
        public By ddlDistributor { get { return By.XPath("//select[@id='ddlDistributer']"); } }
        public By btnAccept { get { return By.XPath("//input[@id='Body_btnAccept']"); } }
        public By imgDiageo { get { return By.XPath("//img[@id='imgCorporationLogo']"); } }


        
        Interactions action;
        public LoginPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            action = new Interactions(Driver);
            //PageFactory.InitElements(Driver, this);
        }

        //Login to application as corporation
        public void CorporationLogin()
        {
            string LOGIN = ConfigurationManager.AppSettings["LOGIN"].ToString().Trim();
            if (LOGIN == "CONFIG")
            {
                
                action.TypeClear(loginUserName, ConfigurationManager.AppSettings["USERNAME"].ToString().Trim(), Driver);
                action.TypeClear(loginPassword, ConfigurationManager.AppSettings["PASSWORD"].ToString().Trim(), Driver);
                //action.Type(loginUserName, ConfigurationManager.AppSettings["USERNAME"].ToString().Trim());
                //action.Type(loginPassword, ConfigurationManager.AppSettings["PASSWORD"].ToString().Trim());
                action.Click(loginButton);
                action.WaitForPageToLoad();
            }

        }

        //Get currunt page URL
        public string GetCurrentPageURL()
        {
            try
            {
                string CurrerntPageURL = Driver.Url;
                return CurrerntPageURL;
            }
            catch (Exception e)
            {
                Console.WriteLine("Get current page url method failed: Error-" + e);
                throw e;
            }
        }

        //verify current page
        public bool IsLoginSuccess()
        {
            string urlParts = "Default.aspx";
            Interactions action = new Interactions(Driver);
            bool success = true;
            action.Click(imgDiageo);
            // Driver.Navigate().Back();
            string url = GetCurrentPageURL();
            success = url.Contains(urlParts);
            //Console.WriteLine(url);
            return success;
        }

        //click on browser back button
        public bool ClickOnBrowserBackAndForwardButtonAndVerifyLogin()
        {
            try
            {
                bool IsDefoultPageExist = true;

                string UrlBeforeClickingBackBtn = GetCurrentPageURL();
                //click on browser back button
                Driver.Navigate().Back();
                action.WaitForPageToLoad();
                string UrlAfteClickingBackBtn = GetCurrentPageURL();
                Assert.IsTrue(UrlAfteClickingBackBtn.Contains(UrlBeforeClickingBackBtn));
                Console.WriteLine("Defoult Login Page Exists after clicking on Browser Back Btn");
                string UrlBeforeClickingForwardBtn = GetCurrentPageURL();
                Driver.Navigate().Forward();
                string UrlAfterClickingForwardBtn = GetCurrentPageURL();
                Assert.IsTrue(UrlBeforeClickingForwardBtn.Contains(UrlAfterClickingForwardBtn));
                Console.WriteLine("Defoult Login Page Exists after clicking on Browser Forward Btn");
                return IsDefoultPageExist;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //accept EULA
        public void AcceptEULA()
        {
            try
            {
                try
                {
                    if (action.IsElementPresent(btnAccept))
                    {
                        action.ScrollToBottomOfPage();
                        action.Click(btnAccept);
                        action.WaitForPageToLoad();
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine("Page is not present due to " + e);
                }
                
            }
            catch (Exception e)
            {
                
                Console.WriteLine("Accept EULA failed due to " + e);
                throw e;
            }
        }

        //select corporation/supplier
        public void LoginWithSupplier()
        {
            try
            {             
                if (action.IsElementPresent(ddlCorporation))
                {
                    action.SelectByText(ddlCorporation, "Demo Supplier (QA)");
                    if (action.IsElementPresent(ddlDistributor))
                    {
                        action.SelectByText(ddlDistributor, "Demo Dist. Market #1 (QA)");
                    }
                    else
                    {
                        action.Click(loginButton);
                        action.WaitTime(2);
                        action.WaitForPageToLoad();
                        try
                        {
                            AcceptEULA();
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("Disclaimer Page is not present ");
                        }
                        
                    }
                }
                else
                {
                    Assert.Fail();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Select Corp Supplier failed due to " + e);
                throw e;
            }
        }


        //select corporation/Distributer
        public void LoginWithDistributor()
        {
            try
            {

                if (action.IsElementPresent(ddlCorporation))
                {
                    action.SelectByText(ddlCorporation, "Demo Distributor (QA)");
                    if (action.IsElementPresent(ddlDistributor))
                    {
                        action.SelectByText(ddlDistributor, "Demo Dist. Market #1 (QA)");
                        action.Click(loginButton);
                        action.WaitForPageToLoad();
                        try
                        {
                            AcceptEULA();
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("Disclaimer Page is not present"+e);
                        }
                       
                    }
                    else
                    {
                        {
                            action.Click(loginButton);
                            try
                            {
                                AcceptEULA();
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine("Disclaimer Page is not present"+e);
                            }
                        }
                    }
                }
                else
                {
                    Assert.Fail();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Select Corp Distributor failed due to " + e);
                throw e;
            }
        }

        public void SelectLoginType(string LoginType)
        {
            try
            {
                if (LoginType.Contains("Corp Dist."))
                {
                    LoginWithDistributor();
                }
                else
                {
                    LoginWithSupplier();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Select Login Type failed due to " + e);
                throw e;
            }
        }
    }
}