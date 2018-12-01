using System;
using CHREnhancements.Initiate;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using CHREnhancements.Interaction;

namespace CHREnhancements.PageObject.InstantImpact.Home
{
    public class HomePage : Base
    {
        public static By DiageoLogo
        { get { return (By.XPath("//*[@id='imgCorporationLogo']")); } }

        public static By MyProject
        { get { return (By.XPath("//*[@id='projectsPageLink']")); } }

        public static By YourAccount
        { get { return (By.XPath("//*[@href='/Account/MyAccountPage.aspx']")); } }

        public static By AccountsProjects
        { get { return (By.XPath("//*[@href='MyProjectsPage.aspx']")); } }

        public static By Help
        { get { return (By.XPath("//*[@class='MenuItems']/div/div/ul/li[6]")); } }

        public static By CouponMaker
        { get { return (By.XPath("//*[text()='Coupon Maker']")); } }

        public static By LogoLocker
        { get { return (By.XPath("//*[@href='MyLogoLocker.aspx']")); } }

        public static By Account
        { get { return (By.XPath("//*[@href='/Account/MyAccountPage.aspx']")); } }

        public static By AddressList
        { get { return (By.XPath("//*[@href='AddressLists.aspx']")); } }

        public static By SearchFieldInHeader
        { get { return (By.XPath("//*[@id='txtSearch']")); } }

        public static By ShoppingCartImage
        { get { return (By.XPath("//*[@class='cartImage']")); } }

        public static By FooterLogo
        { get { return (By.XPath("//*[@id='imgFooter']")); } }

        public static By HelpResourcesLink
        { get { return (By.XPath("//*[@href='/Help.aspx']")); } }

        public static By HelpHeader
        { get { return (By.XPath("//*[@class='row no-gutters standardHeader']")); } }

        public static By Postemplate
        { get { return (By.XPath("//*[(@target='_self') and contains(text(),'POS Templates')]")); } }

        public static By Upload
        { get { return (By.XPath("//*[@id='uploadname1']")); } }

        Interactions action;
        public HomePage(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
        }

        //Click on POS On Demand Button
        public void ClickOnPosOnDemand()
        {
            try
            {
                action.ScrollToViewElement(Postemplate);
                action.WaitVisible(Postemplate, 30);
                action.Click(Postemplate);
            }
            catch (Exception e)
            {
                Console.WriteLine("ClickOnPosOnDemand failed due to : " + e);
                throw e;
            }
        }


        //Verify Home Pages
        public void VerifyHomePage()
        {
            try
            {
                //Check the Title of Home page
                String actual_title = Driver.Title;
                Console.WriteLine("Title of the page is " + actual_title);

                //Check the Diageo Logo
                action.WaitVisible(DiageoLogo);
                bool status_of_logo = action.IsElementDisplayed(DiageoLogo);
                Console.WriteLine("Status of logo is " + status_of_logo);

                //Click on My Project Button
                bool status = action.IsElementDisplayed(MyProject);
                if (status)
                {
                    action.Click(MyProject);
                }
                else
                {
                    action.GoToURL("http://ii4.uat.brandmuscle.net/Account/MyProjectsPage.aspx");
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("VerifyHomePage failed due to: " + e);
                throw e;
            }
        }

        //Upload
        public void UploadDone()
        {
            try
            {
                action.WaitVisible(Upload);
                action.Type(Upload, "C:\\Users\\dibyashree.jyoti\\Desktop\\List_Of_Holiday_2018.pdf");
            }
            catch(Exception e)
            {

            }
        }

        //Verify seach Field
        public void VerifySeachFiled()
        {
            try
            {
                action.WaitVisible(SearchFieldInHeader);
                bool status = action.IsElementDisplayed(SearchFieldInHeader);
                Console.WriteLine("Status of search field is in Home page " + status);
                Assert.IsTrue(status);
            }
            catch (Exception e)
            {
                Console.WriteLine("VerifyHomePage failed due to: " + e);
                throw e;
            }
        }

        //verify Help & Resources link
        public void VerifyHelpLink()
        {
            try
            {
                action.WaitVisible(HelpResourcesLink);
                bool statusofhelplink = action.IsElementDisplayed(HelpResourcesLink);
                Console.WriteLine("Status of Help link is " + statusofhelplink);
                Assert.IsTrue(statusofhelplink);
                if (statusofhelplink)
                {
                    action.Click(HelpResourcesLink);
                    action.WaitForPageToLoad();
                    action.WaitVisible(HelpHeader);
                    bool statusofhelpheader = action.IsElementDisplayed(HelpHeader);
                    Console.WriteLine("Status of help header is " + statusofhelpheader);
                    Assert.IsTrue(statusofhelpheader);
                }
                else
                {
                    Assert.Fail();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("VerifyHomePage failed due to: " + e);
                throw e;
            }
        }

        //Verify Logo at footer
        public void VerifyLogoFooter()
        {
            try
            {
                action.WaitVisible(FooterLogo);
                bool status = action.IsElementDisplayed(FooterLogo);
                Console.WriteLine("Status of footer logo is in Home page " + status);
                Assert.IsTrue(status);
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify logo footer failed due to: " + e);
                throw e;
            }
        }

        //Click on Accounts
        public void AccountsToProjects()
        {
            try
            {
                action.Click(YourAccount);
                try
                {
                    action.Click(AccountsProjects);
                }
                catch(Exception e)
                {
                    Console.WriteLine("The feature is available for only Diageo");
                    Console.WriteLine("Pojects link is not present");
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Navigate from acconts to projects failed due to : " + e);
                throw e;
            }
        }

        //Click on Shopping Cart
        public void ClickOnShoppingCart()
        {
            try
            {
                action.WaitVisible(ShoppingCartImage);
                action.Click(ShoppingCartImage);
            }
            catch (Exception e)
            {
                Console.WriteLine("Navigate from acconts to projects failed due to : " + e);
                throw e;
            }
        }

        //Click on CouponMaker
        public void ClickOnCouponMaker()
        {
            try
            {
                action.WaitVisible(CouponMaker);
                action.Click(CouponMaker);
            }
            catch (Exception e)
            {
                Console.WriteLine("Navigate from acconts to projects failed due to : " + e);
                throw e;
            }
        }


        //Click on LogoLocker
        public void ClickOnLogoMaker()
        {
            try
            {
                action.WaitVisible(LogoLocker);
                action.Click(LogoLocker);
            }
            catch (Exception e)
            {
                Console.WriteLine("Navigate from acconts to projects failed due to : " + e);
                throw e;
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
            catch (Exception e)
            {
                Console.WriteLine("Click on help failed due to : " + e);
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
                throw e;
            }
        }

        //Click on Projects
        public void ClickOnProjects()
        {
            try
            {
                action.WaitVisible(MyProject);
                action.Click(MyProject);
            }
            catch (Exception e)
            {
                Console.WriteLine("Click on Projects failed due to : " + e);
                throw e;
            }
        }

        //Click on Address List
        public void ClickOnAdreessList()
        {
            try
            {
                action.WaitVisible(AddressList);
                action.Click(AddressList);
            }
            catch (Exception e)
            {
                Console.WriteLine("Click on Address List failed due to: " + e);
                throw e;
            }
        }

    }
}