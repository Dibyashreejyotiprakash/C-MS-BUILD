using NUnit.Framework;
using System;
using CHREnhancements.Initiate;
using CHREnhancements.PageObject.InstantImpact.Login;
using CHREnhancements.PageObject.InstantImpact.Home;
using CHREnhancements.Interaction;
using CHREnhancements.PageObject.InstantImpact.Projects;
using CHREnhancements.Utility.TestdataUtilities;


namespace CHREnhancements.Tests.June2018.Sprint_1.Delete
{
    [TestFixture]
    [Parallelizable, Category("IIEnhancements")]
    public class _6275_MultipleDelete : Base
    {
        Interactions action;
        LoginPage loginpage;
        HomePage homePage;
        ProjectsPage projectspage;
        Testdata testdata;
        [Test]
        public void MultipleDeleteelete()
        {
            BrowserSetUp();
            loginpage = new LoginPage(Driver);
            testdata = new Testdata();
            action = new Interactions(Driver);
            homePage = new HomePage(Driver);
            projectspage = new ProjectsPage(Driver);
            try
            {
                Testdata.DatabaseValues();
                GetUrl("INSTANTIMPACT");
                loginpage.LoginToApplication(Testdata.username, Testdata.password);
                action.WaitForPageToLoad();
                homePage.VerifyHomePage();
                projectspage.DeleteMultipleTemplates();
                Driver.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine("Multiple delete failed due to " + e);
                Assert.Fail();
            }
        }
    }
}
