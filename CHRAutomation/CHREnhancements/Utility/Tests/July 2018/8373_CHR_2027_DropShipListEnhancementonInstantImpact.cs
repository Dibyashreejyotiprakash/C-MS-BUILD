using System;
using NUnit.Framework;
using CHREnhancements.Initiate;
using CHREnhancements.PageObject.InstantImpact.Login;
using CHREnhancements.PageObject.InstantImpact.Home;
using CHREnhancements.Interaction;
using CHREnhancements.PageObject.InstantImpact.Projects;
using CHREnhancements.PageObject.InstantImpact.Accounts;
using CHREnhancements.PageObject.InstantImpact.AddressList;
using CHREnhancements.PageObject.InstantImpact.ImportAddressListPage;
using CHREnhancements.Utility.TestdataUtilities;

namespace CHREnhancements.Tests.July_2018
{
    [TestFixture]
    [Parallelizable, Category("IIEnhancements")]
    public class _8373_CHR_2027_DropShipListEnhancementonInstantImpact : Base
    {
        Interactions action;
        LoginPage loginpage;
        HomePage homePage;
        ProjectsPage projectspage;
        AccontsPage accountpage;
        AddressListPage addresslistpage;
        ImportAddressListPage importaddresslistpage;
        Testdata testdata;
        [Test]
        [TestCaseSource(typeof(Base), "BrowserToRunWith")]
        public void VerifyDropShip(string browsername)
        {

            BrowserSetUp(browsername);
            loginpage = new LoginPage(Driver);
            testdata = new Testdata();
            action = new Interactions(Driver);
            homePage = new HomePage(Driver);
            projectspage = new ProjectsPage(Driver);
            accountpage = new AccontsPage(Driver);
            addresslistpage = new AddressListPage(Driver);
            importaddresslistpage = new ImportAddressListPage(Driver);
            try
            {
                Testdata.DatabaseValues();
                action.GoToURL(Testdata.url);
                loginpage.LoginToApplication(Testdata.username, Testdata.password);
                action.WaitForPageToLoad();
                homePage.VerifyHomePage();
                homePage.ClickOnAccounts();
                action.WaitForPageToLoad();
                accountpage.ClickOnAddressList();
                action.WaitForPageToLoad();
                addresslistpage.VerifyAddressListPage();
                addresslistpage.ClickOnImportAdressList();
                action.WaitForPageToLoad();
                addresslistpage.UploadNewAddressList();
                addresslistpage.DownloadTemplateFile();
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify DropShip failed due to " + e);
                Assert.Fail();
            }
        }
    }
}