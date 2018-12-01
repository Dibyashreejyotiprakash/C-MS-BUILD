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
using CHREnhancements.PageObject.InstantImpact.Share;
using CHREnhancements.PageObject.InstantImpact.Gmail;

namespace CHREnhancements.Tests.June2018.Sprint_2.Share_Externally
{
    [TestFixture]
    [Parallelizable, Category("IIEnhancements")]
    public class _6826_ShareSaveDesignFromWorkCenter : Base
    {
        Interactions action;
        LoginPage loginpage;
        HomePage homepage;
        ProjectsPage projectspage;
        CreateDesignPage createdesignpage;
        POS_On_Demand posondemand;
        ProdctSelectionPage productselectionpage;
        ShareTemplatePage sharetemplatepage;
        LoginGmailPage logingmailpage;
        [Test]
        [TestCaseSource(typeof(Base), "BrowserToRunWith")]
        public void ShareTemplateExternally(string browsername)
        {
            BrowserSetUp(browsername);
            loginpage = new LoginPage(Driver);
            action = new Interactions(Driver);
            homepage = new HomePage(Driver);
            projectspage = new ProjectsPage(Driver);
            createdesignpage = new CreateDesignPage(Driver);
            posondemand = new POS_On_Demand(Driver);
            productselectionpage = new ProdctSelectionPage(Driver);
            sharetemplatepage = new ShareTemplatePage(Driver);
            logingmailpage = new LoginGmailPage(Driver);
            try
            {
                Testdata.DatabaseValues();
                action.GoToURL(Testdata.url);
                loginpage.LoginToApplication(Testdata.username, Testdata.password);
                homepage.VerifyHomePage();
                projectspage.ClickOnShare();
                sharetemplatepage.ShareTemplate(Testdata.mailun);
                action.GoToURL(Testdata.mailurl);
                action.WaitForPageToLoad();
                logingmailpage.LoginToGmail(Testdata.mailun, Testdata.mailpwd);
                logingmailpage.VerifyMailBySender();
                logingmailpage.ClickOnLink();
                Driver.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine("Share template externally failed due to " + e);
                Assert.Fail();
            }
        }
    }
}