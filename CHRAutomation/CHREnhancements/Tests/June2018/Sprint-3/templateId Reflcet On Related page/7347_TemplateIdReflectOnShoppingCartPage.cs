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

namespace CHREnhancements.Tests.June2018.Sprint_3.templateId_Reflcet_On_Related_page
{
    [TestFixture]
    [Parallelizable, Category("IIEnhancements")]
    public class _7347_TemplateIdReflectOnShoppingCartPage : Base
    {
        Interactions action;
        LoginPage loginpage;
        HomePage homepage;
        ProjectsPage projectspage;
        CreateDesignPage createdesignpage;
        POS_On_Demand posondemand;
        ProdctSelectionPage productselectionpage;
        ShoppingCartPage shoppingcartpage;
        [Test]
        public void VerifTemplateIdInShoppingCartPage()
        {
            BrowserSetUp();
            loginpage = new LoginPage(Driver);
            action = new Interactions(Driver);
            homepage = new HomePage(Driver);
            projectspage = new ProjectsPage(Driver);
            createdesignpage = new CreateDesignPage(Driver);
            posondemand = new POS_On_Demand(Driver);
            productselectionpage = new ProdctSelectionPage(Driver);
            shoppingcartpage = new ShoppingCartPage(Driver);
            try
            {
                Testdata.DatabaseValues();
                GetUrl("INSTANTIMPACT");
                loginpage.LoginToApplication(Testdata.username, Testdata.password);
                homepage.ClickOnPosOnDemand();
                posondemand.SelectTemplate(Testdata.templateid);
                string templateid_from_pos = posondemand.GetTemplateId();
                posondemand.ClickOnCreateYourDesign();
                createdesignpage.VerifyPreviewChanges();
                createdesignpage.ClickOnNextStep();
                createdesignpage.ClickOnNoFromNextStep();
                productselectionpage.VerifySelectProductDetailsPage();
                productselectionpage.SelectItemType();
                productselectionpage.GiveQuantity(Testdata.quantity);
                productselectionpage.ClickOnNo();
                productselectionpage.ClickOnAddToKart();
                //shoppingcartpage.VerifyTemplateIdInShoppingCartPage(templateid_from_pos);
            }
            catch (Exception e)
            {
                Console.WriteLine("Verif template id in shopping cart page failed due to " + e);
                Assert.Fail();
            }
        }
    }
}