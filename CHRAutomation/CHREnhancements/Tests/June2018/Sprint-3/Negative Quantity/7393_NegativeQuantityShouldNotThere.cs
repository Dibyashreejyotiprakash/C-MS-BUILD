using System;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using CHREnhancements.PageObject.InstantImpact.Home;
using CHREnhancements.PageObject.InstantImpact.Login;
using CHREnhancements.PageObject.InstantImpact.Projects;
using CHREnhancements.Utility.TestdataUtilities;
using CHREnhancements.PageObject.InstantImpact.ItemSearchPage;
using CHREnhancements.PageObject.InstantImpact.Product_Selection;
using NUnit.Framework;
using CHREnhancements.PageObject.InstantImpact.CreateDesign;
using CHREnhancements.PageObject.InstantImpact.Shopping_Cart;

namespace CHREnhancements.Tests.June2018.Sprint_3.Negative_Quantity
{
    [TestFixture]
    [Parallelizable, Category("IIEnhancements")]
    public class _7393_NegativeQuantityShouldNotThere : Base
    {
        Interactions action;
        LoginPage loginpage;
        HomePage homepage;
        ProjectsPage projectspage;
        CreateDesignPage createdesignpage;
        POS_On_Demand posondemand;
        ProdctSelectionPage productselectionpage;
        ShoppingCartPage shoppingkartpage;
        [Test]
        public void VerifyNoOfItemsInShoppingCart()
        {
            BrowserSetUp();
            loginpage = new LoginPage(Driver);
            action = new Interactions(Driver);
            homepage = new HomePage(Driver);
            projectspage = new ProjectsPage(Driver);
            createdesignpage = new CreateDesignPage(Driver);
            posondemand = new POS_On_Demand(Driver);
            productselectionpage = new ProdctSelectionPage(Driver);
            shoppingkartpage = new ShoppingCartPage(Driver);
            try
            {
                Testdata.DatabaseValues();
                action.GoToURL(Testdata.url);
                loginpage.LoginToApplication(Testdata.username, Testdata.password);
                homepage.VerifyHomePage();
                projectspage.ClickOnPosOnDemand();
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
                action.WaitForPageToLoad();
                shoppingkartpage.VerifyShoppingCartPage();
                shoppingkartpage.VerifyListOfItemWithShoppingCart();
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify No Of Items In ShoppingCart failed due to " + e);
                Assert.Fail();
            }
        }
    }
}