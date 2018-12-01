using System;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using CHREnhancements.PageObject.InstantImpact.Home;
using CHREnhancements.PageObject.InstantImpact.Login;
using CHREnhancements.Utility.TestdataUtilities;
using CHREnhancements.PageObject.InstantImpact.Projects;
using CHREnhancements.PageObject.InstantImpact.ItemSearchPage;
using CHREnhancements.PageObject.InstantImpact.CreateDesign;
using NUnit.Framework;
using CHREnhancements.PageObject.InstantImpact.AddressList;

namespace CHREnhancements.Tests.June2018.IP_002
{
    [TestFixture]
    [Parallelizable, Category("IIEnhancements")]
    public class _7574_CHR_1461_MaxFiledLengthforDesignName : Base
    {
        Interactions action;
        LoginPage loginpage;
        HomePage homepage;
        ProjectsPage projectpage;
        POS_On_Demand posondemand;
        CreateDesignPage createdesignpage;
        [Test]
        [TestCaseSource(typeof(Base), "BrowserToRunWith")]
        public void VerifyMaxFiledInSaveDesignName(string browsername)
        {
            BrowserSetUp(browsername);
            loginpage = new LoginPage(Driver);
            action = new Interactions(Driver);
            homepage = new HomePage(Driver);
            projectpage = new ProjectsPage(Driver);
            posondemand = new POS_On_Demand(Driver);
            createdesignpage = new CreateDesignPage(Driver);
            try
            {
                Testdata.DatabaseValues();
                action.GoToURL(Testdata.url);
                loginpage.LoginToApplication(Testdata.username, Testdata.password);
                homepage.VerifyHomePage();
                projectpage.ClickOnPosOnDemand();
                posondemand.SelectTemplate(Testdata.templateid);
                posondemand.ClickOnCreateYourDesign();
                createdesignpage.VerifyCreateDesignPage();
                createdesignpage.VerifyPreviewChanges();
                createdesignpage.ClickOnNextStep();
                createdesignpage.ClickOnYesFromNextStep();
                createdesignpage.VerifyDesignNameWithMaxLength();
                Driver.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify max field length for save design name failed due to " + e);
                Assert.Fail();
            }
        }
    }
}