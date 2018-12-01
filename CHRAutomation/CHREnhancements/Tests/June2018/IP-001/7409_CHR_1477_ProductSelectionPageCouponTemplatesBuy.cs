using System;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using CHREnhancements.PageObject.InstantImpact.Home;
using CHREnhancements.PageObject.InstantImpact.Login;
using CHREnhancements.Utility.TestdataUtilities;
using CHREnhancements.PageObject.InstantImpact.CouponMaker;
using CHREnhancements.PageObject.InstantImpact.Product_Selection;
using NUnit.Framework;

namespace CHREnhancements.Tests.June2018.IP_001
{
    [TestFixture]
    [Parallelizable]
    public class _7409_CHR_1477_ProductSelectionPageCouponTemplatesBuy : Base
    {
        Interactions action;
        LoginPage loginpage;
        HomePage homepage;
        CouponMakerPage couponmakerpage;
        CouponMakerProjectsPage couponmakerprojectpage;
        CouponMakerCreateDesignPage couponmakercreatedesignpage;
        CouponMakerItemSearchPage couponmkareitemsearchpage;
        ProdctSelectionPage productselectionpage;
        [Test]
        public void CouponBuy()
        {
            BrowserSetUp();
            loginpage = new LoginPage(Driver);
            action = new Interactions(Driver);
            homepage = new HomePage(Driver);
            couponmakerpage = new CouponMakerPage(Driver);
            couponmakerprojectpage = new CouponMakerProjectsPage(Driver);
            couponmakercreatedesignpage = new CouponMakerCreateDesignPage(Driver);
            couponmkareitemsearchpage = new CouponMakerItemSearchPage(Driver);
            productselectionpage = new ProdctSelectionPage(Driver);
            try
            {
                Testdata.DatabaseValues();
                action.GoToURL(Testdata.url);
                loginpage.LoginToApplication(Testdata.cmusername, Testdata.cmpassword);
                homepage.VerifyHomePage();
                couponmakerprojectpage.ClickOnEdit();
                couponmakercreatedesignpage.SelectCouponType();
                couponmakercreatedesignpage.SelectDates();
                couponmakercreatedesignpage.SelectStates();
                couponmakercreatedesignpage.ClickOnPreview();
                couponmakercreatedesignpage.ClickOnBuyNow();
            }
            catch (Exception e)
            {
                Console.Write("Coupon Buy failed due to " + e);
                Assert.Fail();
            }
        }
    }
}