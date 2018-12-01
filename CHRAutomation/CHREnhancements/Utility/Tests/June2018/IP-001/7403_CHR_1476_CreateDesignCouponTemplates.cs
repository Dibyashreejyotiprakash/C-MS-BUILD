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
    public class _7403_CHR_1476_CreateDesignCouponTemplates : Base
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
        [TestCaseSource(typeof(Base), "BrowserToRunWith")]
        public void Savetemplate(string browsername)
        {
            BrowserSetUp(browsername);
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
                homepage.ClickOnProjects();
                couponmakerpage.ClickOnCoupnMaker();
                couponmkareitemsearchpage.SearchCouponTemplate("119173");
                couponmkareitemsearchpage.SelectTemplate();
                couponmkareitemsearchpage.ClickOnCareteYourOwnDesign();
                couponmakercreatedesignpage.SelectCouponType();
                couponmakercreatedesignpage.SelectDates();
                couponmakercreatedesignpage.ClickOnStates();
                couponmakercreatedesignpage.SelectStates();
                couponmakercreatedesignpage.ClickOnReviewOrder();
                couponmakercreatedesignpage.GetPromoCode();
                couponmakercreatedesignpage.ClickOnPreview();
                couponmakercreatedesignpage.ClickOnBuyNow();
                productselectionpage.VerifySelectProductDetailsPage();
            }
            catch(Exception e)
            {
                Console.WriteLine("Savetemplate failed due to " + e);
                Assert.Fail();
            }
        }

    }
}