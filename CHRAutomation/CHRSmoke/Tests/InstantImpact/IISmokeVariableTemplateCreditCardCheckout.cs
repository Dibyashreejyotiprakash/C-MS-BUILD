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
    public class IISmokeVariableTemplateCreditCardCheckout : Base
    {
        [Test]
        public void SmokeVariableTemplateCreditCardCheckout()
        {
            BrowserSetUp();

            Interactions action = new Interactions(Driver);
            LoginPage loginpage = new LoginPage(Driver);
            HomePage homepage = new HomePage(Driver);
            ItemSearchPage itemsearchpage = new ItemSearchPage(Driver);
            CreateDesignPage createdesignpage = new CreateDesignPage(Driver);
            CheckOutPage chekoutpage = new CheckOutPage(Driver);
            OrderFormPage orderformpage = new OrderFormPage(Driver);

            ConfirmationPage confirmationpage = new ConfirmationPage(Driver);
            try
            {

                GetUrl("INSTANTIMPACT");
                loginpage.CorporationLogin();
                loginpage.SelectLoginType("Corp Dist.");
                chekoutpage.VariableTemplateCreditCardCheckout();
                bool orderStatus = confirmationpage.IsOrderPlace();
                Assert.IsTrue(orderStatus);
            }
            catch (Exception e)
            {
                Console.WriteLine("Credit Card Checkout Failled : " + e);
                Assert.Fail();
            }
        }

    }
}