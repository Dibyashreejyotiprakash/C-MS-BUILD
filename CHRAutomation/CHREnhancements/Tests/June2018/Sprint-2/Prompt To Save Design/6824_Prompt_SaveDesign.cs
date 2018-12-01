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

namespace CHREnhancements.Tests.June2018.Sprint_2.Prompt_To_Save_Design
{
    [TestFixture]
    [Parallelizable, Category("IIEnhancements")]
    public class _6824_Prompt_SaveDesign : Base
    {
        Interactions action;
        LoginPage loginpage;
        HomePage homepage;
        ProjectsPage projectspage;
        CreateDesignPage createdesignpage;
        POS_On_Demand posondemand;
        ProdctSelectionPage productselectionpage;
        [Test]
        public void VerifyPromptToSaveDesign()
        {
            BrowserSetUp();
            loginpage = new LoginPage(Driver);
            action = new Interactions(Driver);
            homepage = new HomePage(Driver);
            projectspage = new ProjectsPage(Driver);
            createdesignpage = new CreateDesignPage(Driver);
            posondemand = new POS_On_Demand(Driver);
            productselectionpage = new ProdctSelectionPage(Driver);
            try
            {
                Testdata.DatabaseValues();
                GetUrl("INSTANTIMPACT");
                loginpage.LoginToApplication(Testdata.username, Testdata.password);
                homepage.VerifyHomePage();
                projectspage.ClickOnEdit();
                createdesignpage.VerifyPreviewChanges();
                createdesignpage.ClickOnNextStep();
                createdesignpage.ClickOnYesFromNextStep();
                createdesignpage.ClearTextInSaveDesignPopup();
                createdesignpage.SaveDesignWithNewName(Testdata.templatename);
                productselectionpage.VerifySelectProductDetailsPage();
                Driver.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify prompt to save design failed due to " + e);
                Assert.Fail();
            }
        }
    }
}