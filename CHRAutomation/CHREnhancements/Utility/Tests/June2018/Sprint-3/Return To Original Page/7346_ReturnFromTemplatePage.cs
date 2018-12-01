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

namespace CHREnhancements.Tests.June2018.Sprint_3.Return_To_Original_Page
{
    [TestFixture]
    [Parallelizable, Category("IIEnhancements")]
    public class _7346_ReturnFromTemplatePage : Base
    {
        Interactions action;
        LoginPage loginpage;
        HomePage homepage;
        ProjectsPage projectspage;
        CreateDesignPage createdesignpage;
        POS_On_Demand posondemand;
        ProdctSelectionPage productselectionpage;
        [Test]
        [TestCaseSource(typeof(Base), "BrowserToRunWith")]
        public void BackFromTemplatePage(string browsername)
        {
            BrowserSetUp(browsername);
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
                action.GoToURL(Testdata.url);
                loginpage.LoginToApplication(Testdata.username, Testdata.password);
                homepage.ClickOnPosOnDemand();
                posondemand.SelectTemplate(Testdata.templateid);
                posondemand.ClickOnBack();
                Driver.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine("Back from template page is failed due to " + e);
                Assert.Fail();
            }
        }
    }
}