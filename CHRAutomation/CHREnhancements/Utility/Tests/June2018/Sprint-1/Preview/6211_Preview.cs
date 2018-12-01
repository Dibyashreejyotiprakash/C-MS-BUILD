using System;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using CHREnhancements.PageObject.InstantImpact.Home;
using CHREnhancements.PageObject.InstantImpact.Login;
using CHREnhancements.PageObject.InstantImpact.Projects;
using CHREnhancements.Utility.TestdataUtilities;
using CHREnhancements.PageObject.InstantImpact.CreateDesign;
using NUnit.Framework;

namespace CHREnhancements.Tests.June2018.Sprint_1.Preview
{
    [TestFixture]
    [Parallelizable, Category("IIEnhancements")]
    public class _6211_Preview : Base
    {
        Interactions action;
        LoginPage loginpage;
        HomePage homepage;
        ProjectsPage projectspage;
        CreateDesignPage createdesignpage;
        [Test]
        [TestCaseSource(typeof(Base), "BrowserToRunWith")]
        public void PreviewTemplate(string browsername)
        {
            BrowserSetUp(browsername);
            loginpage = new LoginPage(Driver);
            action = new Interactions(Driver);
            homepage = new HomePage(Driver);
            projectspage = new ProjectsPage(Driver);
            createdesignpage = new CreateDesignPage(Driver);
            try
            {
                Testdata.DatabaseValues();
                action.GoToURL(Testdata.url);
                loginpage.LoginToApplication(Testdata.username, Testdata.password);
                homepage.VerifyHomePage();
                projectspage.ClickOnEdit();
                createdesignpage.VerifyPreviewChanges();
                Driver.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine("Preview template failed due to " + e);
                Assert.Fail();
            }
        }
    }
}