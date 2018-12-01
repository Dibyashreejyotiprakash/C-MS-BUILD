using System;
using CHRSmoke.Initiate;
using CHRSmoke.Interaction;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;

namespace CHRSmoke.PageObjects.InstantImpact.ShoppingCart
{
    public class ShoppingCartPage : Base
    {

        public By imgLoading { get { return By.XPath("//img[@src='/Content/Images/loading.gif']"); } }
        public By lblNumberOfCartItems { get { return By.XPath("//div[@class='cartItemNumber']/span"); } }
        public By btnFedExGroup { get { return By.XPath("//input[@id='ctl00_Body_shipMethodList_ctl00_twoDayShipRadioButton']"); } }
        public By lnkClearShoppingCart { get { return By.XPath("(//a[ text()='Clear Shopping Cart'])[1]"); } }
        public By rwTable { get { return By.XPath("//table[@class='rwTable']"); } }
        public By btnYes { get { return (By.XPath("//*[@class='btn GenericRedButton']/span/span[text()='Yes']")); } }
        public By btnCheckout { get { return By.XPath("//input[@id='ctl00_Body_bottomContToCheckOutBtn']"); } }
        public By btnCreditCard { get { return By.XPath("//div[@id='paymentMethodContainer']/span[2]"); } }


        IWebDriver Driver;
        public ShoppingCartPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            //PageFactory.InitElements(Driver, this);
        }

        //Delete items from cart
        public void ClearItemFromCart()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                action.WaitWhileNotVisible(imgLoading);
                action.WaitForPageToLoad(60);
                string itemsInCart = action.GetText(lblNumberOfCartItems).ToString();
                int itemsInCarts = Int32.Parse(itemsInCart);
                if (itemsInCarts > 0)
                {
                    action.WaitVisible(lblNumberOfCartItems,300);
                    action.Click(lblNumberOfCartItems);
                    action.WaitWhileNotVisible(imgLoading);
                    action.WaitForPageToLoad(60);
                    action.WaitVisible(btnFedExGroup, 300);
                    action.ScrollToViewElement(btnFedExGroup);
                    action.WaitVisible(lnkClearShoppingCart, 300);
                    action.Click(lnkClearShoppingCart, 300);
                    action.WaitVisible(rwTable, 300);
                    if (action.IsElementPresent(btnYes))
                    {
                        action.WaitVisible(btnYes, 300);
                        action.Click(btnYes);
                        action.WaitWhileNotVisible(imgLoading);
                        action.WaitForPageToLoad(60);
                    }
                    else
                    {
                        Console.WriteLine("YES button is NOT Visible");
                    }
                }
                else
                {
                    // Console.WriteLine("No Items available  in Cart");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Cart is NOT clear " + e);
                throw e;
            }
        }



        //click on checkout btn
        public void ContinueToCheckout()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                action.WaitVisible(btnFedExGroup,300);
                action.ScrollToViewElement(btnFedExGroup);
                if (action.IsElementEnabled(btnCheckout))
                {
                    action.WaitVisible(btnCheckout, 300);
                    action.Click(btnCheckout);
                    action.WaitWhileNotVisible(imgLoading);
                    action.WaitForPageToLoad();
                }
                else
                {
                    Console.WriteLine("Checkout Button is not enable/present");
                }

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        //Check If Items are deleted from Cart

        public bool IsItemDeletedFromCart()
        {
            Interactions action = new Interactions(Driver);
            bool isCartCleared = false;
            try
            {
                string itemsInCartAfterDelete = action.GetText(lblNumberOfCartItems).ToString();
                int itemsInCartsAfterDelete = Int32.Parse(itemsInCartAfterDelete);
                if (itemsInCartsAfterDelete == 0)
                {
                    isCartCleared = true;
                }
                else
                {
                    isCartCleared = false;
                }

                return isCartCleared;
            }

            catch (TimeoutException e)
            {
                throw e; 
            }
            
        }

        

       

    }
}