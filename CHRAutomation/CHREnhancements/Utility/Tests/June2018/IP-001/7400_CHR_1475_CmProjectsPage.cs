using System;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using CHREnhancements.PageObject.InstantImpact.Home;
using CHREnhancements.PageObject.InstantImpact.Login;
using CHREnhancements.Utility.TestdataUtilities;
using CHREnhancements.PageObject.InstantImpact.ItemSearchPage;
using CHREnhancements.PageObject.InstantImpact.CouponMaker;
using NUnit.Framework;
namespace CHREnhancements.Tests.June2018.IP_001
{
    [TestFixture]
    [Parallelizable]
    public class _7400_CHR_1475_CmProjectsPage : Base
    {
        Interactions action;
        LoginPage loginpage;
        HomePage homepage;
        CouponMakerPage couponmakerpage;
        POS_On_Demand posondemand;
        CouponMakerCreateDesignPage couponmakercreatedesignpage;
        CouponMakerProjectsPage couponmakerprojectspage;
        [Test]
        [TestCaseSource(typeof(Base), "BrowserToRunWith")]
        public void VerifyCmProjectsPage(string browsername)
        {
            BrowserSetUp(browsername);
            loginpage = new LoginPage(Driver);
            action = new Interactions(Driver);
            homepage = new HomePage(Driver);
            couponmakerpage = new CouponMakerPage(Driver);
            posondemand = new POS_On_Demand(Driver);
            couponmakercreatedesignpage = new CouponMakerCreateDesignPage(Driver);
            couponmakerprojectspage = new CouponMakerProjectsPage(Driver);
            try
            {
                Testdata.DatabaseValues();
                action.GoToURL(Testdata.url);
                loginpage.LoginToApplication(Testdata.cmusername, Testdata.cmpassword);
                homepage.ClickOnProjects();
                couponmakerprojectspage.VerifyLinks();
                couponmakerprojectspage.ClickOnEdit();
                action.Back();
                couponmakerprojectspage.ClickOnPreview();
                couponmakerprojectspage.ClickOnAccounts();
                Driver.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify coupon maker projects page failed due to " + e);
                Assert.Fail();
            }
        }
    }
}