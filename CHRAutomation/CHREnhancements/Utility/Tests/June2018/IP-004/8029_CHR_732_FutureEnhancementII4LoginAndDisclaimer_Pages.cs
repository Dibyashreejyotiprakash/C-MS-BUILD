using System;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using CHREnhancements.PageObject.InstantImpact.ClientSpecificLandingPage;
using CHREnhancements.PageObject.InstantImpact.Login;
using CHREnhancements.Utility.TestdataUtilities;
using NUnit.Framework;

namespace CHREnhancements.Tests.June2018.IP_004
{
    [TestFixture]
    [Parallelizable, Category("Enhancements")]
    public class _8029_CHR_732_FutureEnhancementII4LoginAndDisclaimer_Pages : Base
    {
        Interactions action;
        LoginPage loginpage;
        DisclaimerPage disclaimerpage;
        [Test]
        [TestCaseSource(typeof(Base), "BrowserToRunWith")]
        public void VerifyDisclaimerPage(string browsername)
        {
            BrowserSetUp(browsername);
            loginpage = new LoginPage(Driver);
            action = new Interactions(Driver);
            disclaimerpage = new DisclaimerPage(Driver);
            try
            {
                Testdata.DatabaseValues();
                action.GoToURL(Testdata.url);
                loginpage.LoginToApplication("testadmin5@brandmuscle.com", "go2web");
                disclaimerpage.VerifyDisclaimerPage();
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify Disclaimer page failed due to " + e);
                Assert.Fail();
            }
        }
    }
}