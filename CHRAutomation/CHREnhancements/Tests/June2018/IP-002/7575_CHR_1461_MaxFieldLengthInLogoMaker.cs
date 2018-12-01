using System;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using CHREnhancements.PageObject.InstantImpact.Home;
using CHREnhancements.PageObject.InstantImpact.Login;
using CHREnhancements.Utility.TestdataUtilities;
using CHREnhancements.PageObject.InstantImpact.LogoLocker;
using NUnit.Framework;

namespace CHREnhancements.Tests.June2018.IP_002
{
    [TestFixture]
    [Parallelizable, Category("")]
    public class _7575_CHR_1461_MaxFieldLengthInLogoMaker : Base
    {
        Interactions action;
        LoginPage loginpage;
        HomePage homepage;
        LogoLockerPage logolockerpage;
        [Test]
        public void VerifyMaxLengthInLogoLocker()
        {
            BrowserSetUp();
            loginpage = new LoginPage(Driver);
            action = new Interactions(Driver);
            homepage = new HomePage(Driver);
            logolockerpage = new LogoLockerPage(Driver);
            try
            {
                Testdata.DatabaseValues();
                action.GoToURL(Testdata.url);
                loginpage.LoginToApplication(Testdata.username, Testdata.password);
                homepage.ClickOnAccounts();
                homepage.ClickOnLogoMaker();
                action.WaitForPageToLoad();
                logolockerpage.ClickOnUplaodNewLogo();
                logolockerpage.VerifyAccountNameWithMaxLength();
                Driver.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify max field length for logo maker failed due to " + e);
                Assert.Fail();
            }
        }
    }
}