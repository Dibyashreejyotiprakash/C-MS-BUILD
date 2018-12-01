using System;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using CHREnhancements.PageObject.InstantImpact.Login;
using CHREnhancements.PageObject.InstantImpact.Home;
using CHREnhancements.PageObject.InstantImpact.Projects;
using CHREnhancements.PageObject.InstantImpact.ItemSearchPage;
using CHREnhancements.PageObject.InstantImpact.CreateDesign;
using CHREnhancements.PageObject.InstantImpact.Product_Selection;
using CHREnhancements.PageObject.InstantImpact.Shopping_Cart;
using CHREnhancements.Utility.TestdataUtilities;
using NUnit.Framework;

namespace CHREnhancements.Tests.June2018.IP_006
{
    [TestFixture]
    [Parallelizable, Category("IIEnhancements")]
    public class _8190_CHR_1924_II4CommentsAutoGenerating : Base
    {
        Interactions action;
        LoginPage loginpage;
        HomePage homepage;
        ProjectsPage projectpage;
        POS_On_Demand posondemand;
        CreateDesignPage createdesignpage;
        ProdctSelectionPage productselectionpage;
        ShoppingCartPage shoppingcartpage;
        [Test]
        [TestCaseSource(typeof(Base), "BrowserToRunWith")]
        public void VerifyPrepopulatedComments(string browsername)
        {
            BrowserSetUp(browsername);
            loginpage = new LoginPage(Driver);
            homepage = new HomePage(Driver);
            projectpage = new ProjectsPage(Driver);
            createdesignpage = new CreateDesignPage(Driver);
            action = new Interactions(Driver);
            posondemand = new POS_On_Demand(Driver);
            productselectionpage = new ProdctSelectionPage(Driver);
            shoppingcartpage = new ShoppingCartPage(Driver);
            try
            {
                Testdata.DatabaseValues();
                action.GoToURL(Testdata.url);
                loginpage.LoginToApplication(Testdata.username, Testdata.password);
                homepage.ClickOnPosOnDemand();
                posondemand.SelectTemplate(Testdata.templateid);
                posondemand.ClickOnCreateYourDesign();
                createdesignpage.VerifyPreviewChanges();
                createdesignpage.ClickOnNextStep();
                createdesignpage.ClickOnNoFromNextStep();
                productselectionpage.VerifySelectProductDetailsPage();
                productselectionpage.SelectItemType();
                productselectionpage.GiveQuantity(Testdata.quantity);
                productselectionpage.ClickOnNo();
                productselectionpage.ClickOnAddToKart();
                shoppingcartpage.ClickOnCheckOut();
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify Prepopulted Comments failed due to " + e);
                Assert.Fail();
            }
        }
    }
}