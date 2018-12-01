using System;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using CHREnhancements.PageObject.InstantImpact.Home;
using CHREnhancements.PageObject.InstantImpact.Login;
using CHREnhancements.Utility.TestdataUtilities;
using CHREnhancements.PageObject.InstantImpact.ItemSearchPage;
using CHREnhancements.PageObject.InstantImpact.CouponMaker;
using CHREnhancements.PageObject.InstantImpact.Product_Selection;
using NUnit.Framework;


namespace CHREnhancements.Tests.August_2018
{
    [TestFixture]
    [Parallelizable, Category("IIEnhancements")]
    public class _8429_CHR_2070_OverwritingSavedDesignsAcrossItemTypes : Base
    {
        Interactions action;
        LoginPage loginpage;
        HomePage homepage;
        CouponMakerPage couponmakerpage;
        POS_On_Demand posondemand;
        CouponMakerCreateDesignPage couponmakercreatedesignpage;
        ProdctSelectionPage productselectionpage;
        CouponMakerItemSearchPage couponmkareitemsearchpage;
        [Test]
        public void VerifyOverWriteSaveDesign()
        {
            BrowserSetUp();
            action = new Interactions(Driver);
            loginpage = new LoginPage(Driver);
            action = new Interactions(Driver);
            homepage = new HomePage(Driver);
            couponmakerpage = new CouponMakerPage(Driver);
            posondemand = new POS_On_Demand(Driver);
            couponmakercreatedesignpage = new CouponMakerCreateDesignPage(Driver);
            productselectionpage = new ProdctSelectionPage(Driver);
            couponmkareitemsearchpage = new CouponMakerItemSearchPage(Driver);
            try
            {
                Testdata.DatabaseValues();
                action.GoToURL(Testdata.url);
                loginpage.LoginToApplication(Testdata.cmusername, Testdata.cmpassword);
                homepage.ClickOnProjects();
                homepage.ClickOnCouponMaker();
                couponmakerpage.ClickOnCoupnMaker();
                couponmkareitemsearchpage.SearchCouponTemplate("119173");
                couponmkareitemsearchpage.SelectTemplate();
                couponmkareitemsearchpage.ClickOnCareteYourOwnDesign();
                couponmakercreatedesignpage.SelectCouponType();
                couponmakercreatedesignpage.SelectDates();
                couponmakercreatedesignpage.ClickOnStates();
                couponmakercreatedesignpage.SelectStates();
                couponmakercreatedesignpage.ClickOnReviewOrder();
                couponmakercreatedesignpage.ClickOnPreview();
                couponmakercreatedesignpage.ClickOnSave();
                couponmakercreatedesignpage.VerifySaveDesign(Testdata.templatename);
                action.Back();
                action.Back();
                couponmkareitemsearchpage.SelectTemplate();
                couponmkareitemsearchpage.ClickOnCareteYourOwnDesign();
                couponmakercreatedesignpage.SelectCouponType();
                couponmakercreatedesignpage.SelectDates();
                couponmakercreatedesignpage.ClickOnStates();
                couponmakercreatedesignpage.SelectStates();
                couponmakercreatedesignpage.ClickOnReviewOrder();
                couponmakercreatedesignpage.ClickOnSave();
                couponmakercreatedesignpage.VerifySaveDesign(Testdata.templatename);
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify Over Write Save Design failed due to " + e);
                Assert.Fail();
            }
        }
    }
}