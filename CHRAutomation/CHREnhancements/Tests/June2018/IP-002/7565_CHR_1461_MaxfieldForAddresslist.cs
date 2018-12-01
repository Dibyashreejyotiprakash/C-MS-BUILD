using System;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using CHREnhancements.PageObject.InstantImpact.Home;
using CHREnhancements.PageObject.InstantImpact.Login;
using CHREnhancements.Utility.TestdataUtilities;
using NUnit.Framework;
using CHREnhancements.PageObject.InstantImpact.AddressList;

namespace CHREnhancements.Tests.June2018.IP_002
{
    [TestFixture]
    [Parallelizable, Category("")]
    public class _7565_CHR_1461_MaxfieldForAddresslist : Base
    {
        Interactions action;
        LoginPage loginpage;
        HomePage homepage;
        AddressListPage addresslistpage;
        [Test]
        public void VerifyMaxFiled()
        {
            BrowserSetUp();
            loginpage = new LoginPage(Driver);
            action = new Interactions(Driver);
            homepage = new HomePage(Driver);
            addresslistpage = new AddressListPage(Driver);
            try
            {
                Testdata.DatabaseValues();
                action.GoToURL(Testdata.url);
                loginpage.LoginToApplication(Testdata.username, Testdata.password);
                homepage.ClickOnAccounts();
                homepage.ClickOnAdreessList();
                addresslistpage.ClickOnImportAdressList();
                addresslistpage.VerifyListnameMaxlength();
                Driver.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify max field length for address list failed due to " + e);
                Assert.Fail();
            }
        }
    }
}