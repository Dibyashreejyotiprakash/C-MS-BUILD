using System;
using CHRSmoke.Initiate;
using OpenQA.Selenium;
using CHRSmoke.Interaction;
using OpenQA.Selenium.Support.PageObjects;
using CHRSmoke.PageObjects.ProofGallery.Home;
using NUnit.Framework;

namespace CHRSmoke.PageObjects.ProofGallery.Login
{
    public class LoginPage : Base
    {
        public static By UserName
        { get { return (By.XPath("//*[@id='MainContent_Login1_UserName']")); } }

        public static By Password
        { get { return (By.XPath("//*[@id='MainContent_Login1_Password']")); } }

        public static By RememberMe
        { get { return (By.XPath("//*[@id='MainContent_Login1_RememberMe']")); } }

        public static By LoginBtn
        { get { return (By.XPath("//*[@id='MainContent_Login1_btnLogin']")); } }

        public static By RegisterLink
        { get { return (By.XPath("//*[@href='RequestAccess.aspx']")); } }

        public static By ForgotPasswordLink
        { get { return (By.XPath("//*[@href='ForgotPassword.aspx']")); } }

        public static By ChangePasswordLink
        { get { return (By.XPath("//*[@href='ChangePassword.aspx']")); } }

        HomePage homepage;
        public LoginPage(IWebDriver Driver)
        {
            this.Driver = Driver;

           // PageFactory.InitElements(Driver, this);
        }

        public void Login(string username, string password)
        {
            Interactions action = new Interactions(Driver);
            action.Type(UserName, username);
            action.Type(Password, password);
            action.Click(LoginBtn);
            action.WaitForPageToLoad();
            string pageurl = action.GetCurrentUrl();
            if (pageurl.Contains("Main.aspx"))
            {
                Console.WriteLine("Logged in successfully");
            }
            else
            {
                Assert.Fail();
            }
            
        }

        public void CheckAllLinks()
        {
            Interactions action = new Interactions(Driver);
            bool statusofloginbtn =action.IsElementEnabled(LoginBtn);
            Console.WriteLine("Status of login button" + statusofloginbtn);

            bool statusofregisterlink = action.IsElementEnabled(RegisterLink);
            Console.WriteLine("Status of register link" + statusofregisterlink);

            bool statusofforgotpassowrdlink = action.IsElementEnabled(ForgotPasswordLink);
            Console.WriteLine("Status of forgot password link" + statusofforgotpassowrdlink);

        }

    }
}