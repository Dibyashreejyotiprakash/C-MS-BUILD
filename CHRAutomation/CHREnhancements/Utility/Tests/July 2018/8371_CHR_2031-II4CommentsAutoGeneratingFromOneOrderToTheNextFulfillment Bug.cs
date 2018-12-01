using System;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using CHREnhancements.PageObject.InstantImpact.Home;
using CHREnhancements.PageObject.InstantImpact.Login;
using CHREnhancements.PageObject.InstantImpact.Projects;
using CHREnhancements.PageObject.InstantImpact.ItemSearchPage;
using CHREnhancements.PageObject.InstantImpact.CreateDesign;
using CHREnhancements.PageObject.InstantImpact.Product_Selection;
using CHREnhancements.PageObject.InstantImpact.Shopping_Cart;
using CHREnhancements.PageObject.InstantImpact.CheckOut;
using CHREnhancements.PageObject.InstantImpact.Review;
using CHREnhancements.PageObject.InstantImpact.Confirmation;
using CHREnhancements.Utility.TestdataUtilities;
using NUnit.Framework;

namespace CHREnhancements.Tests.July_2018
{
    [TestFixture]
    [Parallelizable, Category("Enhancements")]
    public class _8371_CHR_2031_II4CommentsAutoGeneratingFromOneOrderToTheNextFulfillment_Bug : Base
    {
        Interactions action;
        LoginPage loginpage;
        HomePage homePage;
        ProjectsPage projectpage;
        POS_On_Demand posondemand;
        CreateDesignPage createdesignpage;
        ProdctSelectionPage productselectionpage;
        ShoppingCartPage shoppingcartpage;
        CheckOutPage checkoutpage;
        ReviewPage reviewpage;
        ConfirmationPage confirmationpage;
        Testdata testdata;
        [Test]
        [TestCaseSource(typeof(Base), "BrowserToRunWith")]
        public void VerifyFulfillmentBug(string browsername)
        {
            BrowserSetUp(browsername);
            loginpage = new LoginPage(Driver);
            testdata = new Testdata();
            action = new Interactions(Driver);
            homePage = new HomePage(Driver);
            posondemand = new POS_On_Demand(Driver);
            projectpage = new ProjectsPage(Driver);
            createdesignpage = new CreateDesignPage(Driver);
            productselectionpage = new ProdctSelectionPage(Driver);
            shoppingcartpage = new ShoppingCartPage(Driver);
            checkoutpage = new CheckOutPage(Driver);
            reviewpage = new ReviewPage(Driver);
            confirmationpage = new ConfirmationPage(Driver);
            try
            {
                Testdata.DatabaseValues();
                action.GoToURL(Testdata.url);
                loginpage.LoginToApplication(Testdata.username, Testdata.password);
                action.WaitForPageToLoad();
                homePage.VerifyHomePage();
                projectpage.ClickOnPosOnDemand();
                posondemand.SelectTemplate(Testdata.templateid);
                posondemand.ClickOnCreateYourDesign();
                createdesignpage.VerifyPreviewChanges();
                createdesignpage.ClickOnNextStep();
                createdesignpage.ClickOnNoFromNextStep();
                productselectionpage.SelectItemType();
                productselectionpage.GiveQuantity(Testdata.quantity);
                productselectionpage.ClickOnNo();
                productselectionpage.ClickOnAddToKart();
                action.WaitForPageToLoad();
                shoppingcartpage.ClickOnCheckOut();
                action.WaitForPageToLoad();
                checkoutpage.GiveFillingDetails("5434536");
                checkoutpage.GiveComments("Checking out");
                checkoutpage.ClickOnContinueReview();
                action.WaitForPageToLoad();
                reviewpage.ClickOnPlaceOrder();
                action.WaitForPageToLoad();
                confirmationpage.ClickOnReturnToSearchPage();
                action.WaitForPageToLoad();
                posondemand.SelectTemplate(Testdata.templateid);
                posondemand.ClickOnCreateYourDesign();
                createdesignpage.VerifyPreviewChanges();
                createdesignpage.ClickOnNextStep();
                createdesignpage.ClickOnNoFromNextStep();
                productselectionpage.SelectItemType();
                productselectionpage.GiveQuantity(Testdata.quantity);
                productselectionpage.ClickOnNo();
                productselectionpage.ClickOnAddToKart();
                action.WaitForPageToLoad();

            }
            catch(Exception e)
            {
                Console.WriteLine("Verify fullfilment bug failed due to " + e);
                Assert.Fail();
            }
        }
    }
}