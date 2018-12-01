using System;
using NUnit.Framework;
using CHRSmoke.Initiate;
using CHRSmoke.Interaction;
using CHRSmoke.PageObjects.InstantImpact.Login;
using CHRSmoke.PageObjects.InstantImpact.Home;
using CHRSmoke.PageObjects.InstantImpact.PosOnDemand;
using CHRSmoke.PageObjects.InstantImpact.ItemConfiguration;
using CHRSmoke.PageObjects.InstantImpact.OrderForm;
using CHRSmoke.PageObjects.InstantImpact.Confirmation;
using CHRSmoke.PageObjects.InstantImpact.CheckOut;

namespace CHRSmoke.Tests.InstantImpact
{
    [TestFixture]
    [Parallelizable, Category("SMOKE")]
    public class IISmokeLoginLogoutForSupplierWithDistributor : Base
    {
        [Test]
        public void SmokeLoginLogoutForSupplierWithDistributor()
        {
            BrowserSetUp();
            Interactions action = new Interactions(Driver);
            LoginPage loginpage = new LoginPage(Driver);
            HomePage homepage = new HomePage(Driver);
            ItemSearchPage itemsearchpage = new ItemSearchPage(Driver);
            CreateDesignPage createdesignpage = new CreateDesignPage(Driver);
            CheckOutPage chekoutpage = new CheckOutPage(Driver);
            OrderFormPage orderformpage = new OrderFormPage(Driver);
            try
            {
                GetUrl("INSTANTIMPACT");
                loginpage.CorporationLogin();
                loginpage.SelectLoginType("Corp Dist.");
                Assert.IsTrue(loginpage.IsLoginSuccess());
                homepage.Logout();
                bool IsDefoultLoginPageExist = loginpage.ClickOnBrowserBackAndForwardButtonAndVerifyLogin();
                Assert.IsTrue(IsDefoultLoginPageExist);
            }
            catch (Exception e)
            {
                Console.WriteLine("Login Failed  :-" + e);
                Assert.Fail();
            }
        }
    }
}