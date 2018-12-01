using System;
using NUnit.Framework;
using CHRSmoke.Initiate;

using CHRSmoke.Interaction;

using CHRSmoke.PageObjects.InstantImpact.Login;
using CHRSmoke.PageObjects.InstantImpact.Home;
using CHRSmoke.PageObjects.InstantImpact.PosOnDemand;
using CHRSmoke.PageObjects.InstantImpact.ItemConfiguration;
using CHRSmoke.PageObjects.InstantImpact.CheckOut;
using CHRSmoke.PageObjects.InstantImpact.OrderForm;
using CHRSmoke.PageObjects.InstantImpact.Confirmation;

namespace CHRSmoke.Tests.InstantImpact
{
    [TestFixture]
    [Parallelizable, Category("SMOKE")]
    public class IISmokeSearchPOS : Base
    {


        [Test]
        public void SmokeSearchPOS()
        {
            BrowserSetUp();
            Interactions action = new Interactions(Driver);
            LoginPage loginpage = new LoginPage(Driver);
            HomePage homepage = new HomePage(Driver);
            ItemSearchPage itemsearchpage = new ItemSearchPage(Driver);
            CreateDesignPage createdesignpage = new CreateDesignPage(Driver);
            OrderFormPage orderformpage = new OrderFormPage(Driver);
            ConfirmationPage confirmationpage = new ConfirmationPage(Driver);
            try
            {
                GetUrl("INSTANTIMPACT");
                loginpage.CorporationLogin();
                //select login type as corp supp.
                loginpage.SelectLoginType("Corp supp.");
                itemsearchpage.ValidateSearchPOS("CORP SUPP");
                homepage.Logout();
                loginpage.CorporationLogin();
                //select login type as Corp Dist
                loginpage.SelectLoginType("Corp Dist.");
                //validate search result
                itemsearchpage.ValidateSearchPOS("Corp Dist.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Search POS Failed :-" + e);
                Assert.Fail();
            }
        }

    }
}