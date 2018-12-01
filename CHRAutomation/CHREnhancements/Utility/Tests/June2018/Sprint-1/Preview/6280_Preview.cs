using System;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using CHREnhancements.PageObject.InstantImpact.Home;
using CHREnhancements.PageObject.InstantImpact.Login;
using CHREnhancements.PageObject.InstantImpact.Projects;
using CHREnhancements.Utility.TestdataUtilities;
using NUnit.Framework;

namespace CHREnhancements.Tests.June2018.Sprint_1.Preview
{
    [TestFixture]
    [Parallelizable, Category("IIEnhancements")]
    public class _6280_Preview : Base
    {
        Interactions action;
        LoginPage loginpage;
        HomePage homepage;
        ProjectsPage projectspage;
        [Test]
        [TestCaseSource(typeof(Base), "BrowserToRunWith")]
        public void PreviewRetiredTemplate(string browsername)
        {
            BrowserSetUp(browsername);
            loginpage = new LoginPage(Driver);
            action = new Interactions(Driver);
            homepage = new HomePage(Driver);
            projectspage = new ProjectsPage(Driver);
            try
            {
                Testdata.DatabaseValues();
                action.GoToURL(Testdata.url);
                loginpage.LoginToApplication(Testdata.username, Testdata.password);
                homepage.VerifyHomePage();
                projectspage.ClickOnPreview();
                Driver.Quit();
            }
            catch (Exception e)
            {
                Console.Write("Preview retired template failed due to " + e);
                Assert.Fail();
            }
        }
    }
}