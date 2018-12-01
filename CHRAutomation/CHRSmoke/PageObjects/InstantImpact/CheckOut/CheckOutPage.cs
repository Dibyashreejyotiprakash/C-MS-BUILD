using System;
using CHRSmoke.Initiate;
using CHRSmoke.Interaction;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using CHRSmoke.PageObjects.InstantImpact.ShoppingCart;
using CHRSmoke.PageObjects.InstantImpact.Home;
using CHRSmoke.PageObjects.InstantImpact.PosOnDemand;
using CHRSmoke.PageObjects.InstantImpact.ItemConfiguration;
using CHRSmoke.PageObjects.InstantImpact.ProductSelection;
using CHRSmoke.PageObjects.InstantImpact.Account;

using System.Collections.Generic;
using NUnit.Framework;

namespace CHRSmoke.PageObjects.InstantImpact.CheckOut
{
    public class CheckOutPage : Base
    {
        public By btnCreateYourDesign { get { return By.XPath("//input[@id='Body_btnProductDesign']"); } }
        public By btnOrderNow { get { return By.XPath("//input[@id='Body_btnOrderNow']"); } }
        public By imgLoading { get { return By.XPath("//img[@src='/Content/Images/loading.gif']"); } }
        public By btnReturnToHomePage { get { return By.XPath("//div[@id='ctl00_Body_radAjaxPanel']/div/a[2]"); } }
        public By btnInvoice { get { return By.XPath("//div[@id='paymentMethodContainer']/span[1]"); } }
        public By divDesignTrackerAccount { get { return By.XPath("//div[@id='ctl00_Body_desTrackAccComboBox']"); } }
        public By txbDesignTrackerAccount { get { return By.XPath("//input[@id='ctl00_Body_desTrackAccComboBox_Input']"); } }
        public By lstDesignTrackerAccount { get { return By.XPath("//ul[@class='rcbList']/li"); } }
        public By txbPO { get { return By.XPath("//input[@id='ctl00_Body_shopCartItemsListView_ctrl0_ucBP_104']"); } }
        public By txbComment { get { return By.XPath("//textarea[@id='Body_tbComments']"); } }
        public By btnContinueToReview { get { return By.XPath("//input[@id='ctl00_Body_bottomContToCheckOutBtn']"); } }
        public By btnPlaceOrder { get { return By.XPath("//input[@id='Body_bottomContToCheckOutBtn']"); } }
        public By lblPlacedOrder { get { return By.XPath("//div[@id='ctl00_Body_radAjaxPanel']/div/h1"); } }
        public By lblConfirmationNumber { get { return By.XPath("//div[@id='ctl00_Body_radAjaxPanel']/div/h3[1]"); } }
        public By btnCreditCard { get { return By.XPath("//div[@id='paymentMethodContainer']/span[2]"); } }
        public By divCreditCardSelection { get { return By.XPath("//div[@id='ctl00_Body_rcbCreditCard']"); } }
        public By ddlCreditCardSelection { get { return By.XPath("//input[@id='ctl00_Body_rcbCreditCard_Input']"); } }
        public By lstCreditCardSelection { get { return By.XPath("//div[@id='ctl00_Body_rcbCreditCard_DropDown']/div/ul/li"); } }
        public By divDTaccount { get { return By.XPath("//div[@id='Body_yourAccPanel']"); } }
        public By ddlDTaccount { get { return By.XPath("//input[@id='ctl00_Body_desTrackAccComboBox_Input']"); } }
        public By lstDTaccount { get { return By.XPath("//div[@id='ctl00_Body_desTrackAccComboBox_DropDown']/div/ul/li"); } }


        ShoppingCartPage shoppingcartpage;
        HomePage homepage;
        ItemSearchPage itemsearchpage;
        CreateDesignPage createdesignpage;
        ProductSelectionPage productselectionpage;
        AccountPage accountPage;
        public CheckOutPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            homepage = new HomePage(Driver);
            shoppingcartpage = new ShoppingCartPage(Driver);
            itemsearchpage = new ItemSearchPage(Driver);
            createdesignpage = new CreateDesignPage(Driver);
            productselectionpage = new ProductSelectionPage(Driver);
            accountPage  = new AccountPage(Driver);
        }

        public void TemplateCreationAndCheckout()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                if (action.IsElementPresent(btnCreateYourDesign))
                {
                    //Create your design
                    createdesignpage.CreateAndSaveYourDesign();
                }
                else if (action.IsElementPresent(btnOrderNow))
                {
                    //click on order now btn
                    action.Click(btnOrderNow);
                    action.WaitForPageToLoad();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Template checkout failed Error : " + e);
                throw e;
            }
        }

        //payment by invoice
        public void PaymentThroughInvoice()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                if (action.IsElementEnabled(btnInvoice))
                {
                    //click on invoice payment option
                    action.Click(btnInvoice);
                    if (action.IsElementEnabled(divDesignTrackerAccount))
                    {
                        action.Click(txbDesignTrackerAccount);
                        action.WaitVisible(lstDesignTrackerAccount);
                        IList<IWebElement> lstDesignTrackerAccounts = action.GetElements(lstDesignTrackerAccount);
                        for (int i = 0; i < lstDesignTrackerAccounts.Count; i++)
                        {
                            lstDesignTrackerAccounts[1].Click();
                            action.WaitTime(2);
                            action.WaitWhileNotVisible(imgLoading);
                            break;
                        }
                        if (action.IsElementPresent(txbPO))
                        {
                            action.ScrollToViewElement(txbPO);
                            //enter PO number
                            action.Type(txbPO, "12345");

                        }
                        if (action.IsElementPresent(txbComment))
                        {
                            //enter comment
                            action.ScrollToViewElement(txbComment);
                            action.Type(txbComment, "TestComment");

                        }
                        if (action.IsElementPresent(btnContinueToReview))
                        {
                            //click on continue btn
                            action.ScrollToViewElement(btnContinueToReview);
                            action.Click(btnContinueToReview);
                            action.WaitWhileNotVisible(imgLoading);
                            action.WaitForPageToLoad(60);

                        }
                        if (action.IsElementPresent(btnPlaceOrder))
                        {
                            action.ScrollToViewElement(btnPlaceOrder);
                            //click on  place order btn
                            action.Click(btnPlaceOrder);
                            action.WaitWhileNotVisible(imgLoading);
                            action.WaitForPageToLoad();

                        }
                        string orderSuccessMsg = action.GetText(lblPlacedOrder).ToString();
                        string orderConfirmationNo = action.GetText(lblConfirmationNumber).ToString();
                        Assert.IsTrue(orderSuccessMsg.Contains("Your Order Has Been Placed."));
                        Console.WriteLine(orderSuccessMsg);
                        Assert.IsTrue(orderConfirmationNo.Contains("THANK YOU FOR YOU ORDER. YOUR ORDER CONFIRMATION NUMBER IS"));
                        Console.WriteLine(orderConfirmationNo);
                        action.Click(btnReturnToHomePage);
                        action.WaitForPageToLoad();

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Invoice method is not ebanle/present" + e);
                throw e;
            }
        }

        //select payment method
        public void SelectPaymentMethod(string PaymentMethodName)
        {
            Interactions action = new Interactions(Driver);
            try
            {
                if (PaymentMethodName.ToUpper().Contains("CREDIT CARD"))
                {
                    PaymentThroughCreditCard();

                }
                else
                {
                    PaymentThroughInvoice();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("There is some issue while selecting Payment method :" + e);
                throw e;
            }
        }

        //credit card selection
        public void CreditcardSelection()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                if (action.IsElementPresent(divCreditCardSelection))
                {
                    action.WaitVisible(ddlCreditCardSelection,300);
                    action.Click(ddlCreditCardSelection);
                    action.WaitTime(1);
                    action.WaitUntilElementClickable(ddlCreditCardSelection, 1);
                    IList<IWebElement> lstCreditCardSelecetion = action.GetElements(lstCreditCardSelection);
                    for (int i = 0; i < lstCreditCardSelecetion.Count; i++)
                    {
                        action.WaitTime(2);
                        lstCreditCardSelecetion[0].Click();
                        action.WaitWhileNotVisible(imgLoading);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Credit card Selection failed due to " + e);
                throw e;
            }
        }
        //Design Tracker Account Selection
        public void DTAccountSelection()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                if (action.IsElementPresent(divDTaccount))
                {
                    action.WaitVisible(ddlDTaccount,300);
                    action.Click(ddlDTaccount);
                    action.WaitTime(1);
                    IList<IWebElement> lstDTAccount = action.GetElements(lstDTaccount);
                    for (int i = 0; i < lstDTAccount.Count; i++)
                    {
                        action.WaitTime(2);
                        lstDTAccount[1].Click();
                        action.WaitWhileNotVisible(imgLoading);
                        break;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("DT Account Selection failed due to " + e);
                throw e;
            }

        }

        public void TypeComment()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                //type comment
                action.ScrollToBottomOfPage();
                action.WaitVisible(txbComment,300);
                action.Type(txbComment, "TestComment");
            }
            catch (Exception e)
            {
                Console.WriteLine("Type Comment failed due to " + e);
                throw e;
            }
        }

        //click on continue to review btn
        public void ClickOnContinueToReview()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                action.WaitVisible(btnContinueToReview, 300);
                //click on continue to review btn
                action.Click(btnContinueToReview);
                action.WaitWhileNotVisible(imgLoading);
            }
            catch (Exception e)
            {
                Console.WriteLine("Click On Continue To Review failed due to " +e);
                throw e;
            }
        }

        //place order
        public void ClickOnPlaceOrderBtn()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                if (action.IsElementPresent(btnPlaceOrder))
                {
                    action.WaitVisible(btnPlaceOrder, 300);
                    action.ScrollToViewElement(btnPlaceOrder);
                    //click on  place order btn
                    action.Click(btnPlaceOrder);
                    action.WaitWhileNotVisible(imgLoading);
                    action.WaitForPageToLoad();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Click On Place Order Btn failed due to " +e);
                throw e;
            }

        }

        //payment through credit card
        public void PaymentThroughCreditCard()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                if (action.IsElementEnabled(btnCreditCard))
                {
                    action.WaitVisible(btnCreditCard,300);
                    //click on credit card button
                    action.Click(btnCreditCard);
                    //credit card selection
                    CreditcardSelection();
                    //DT account selection
                    DTAccountSelection();
                    //type comment
                    TypeComment();
                    //select continueto review
                    ClickOnContinueToReview();
                    //place order
                    ClickOnPlaceOrderBtn();

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Payment Through Credit Card failed due to " + e);
                throw e;
            }
        }


        public void NonVariableTemplateCheckout()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                //Clear items from the cart
                shoppingcartpage.ClearItemFromCart();
                //check if cart is clered 
                bool isItemDeletedFromCart = shoppingcartpage.IsItemDeletedFromCart();
                if (!isItemDeletedFromCart)
                { throw new Exception("Item NOT deleted Successfully"); }
                homepage.SelectMenuType("Dropdown");
                //SelectMenuType("POS Templates");
                //Search template
                itemsearchpage.SearchItem("130722");  
                //select searched template
                itemsearchpage.SelectSearchItem();
                //Template checkout
                TemplateCreationAndCheckout();
                //Add to cart
                productselectionpage.AddToCart1();
                //AddToCart("nonvariable template");
                //click on checkout btn
                shoppingcartpage.ContinueToCheckout();
                action.WaitWhileNotVisible(imgLoading);
                action.WaitForPageToLoad(60);
                //select payment method
                SelectPaymentMethod("INVOICE");

            }
            catch (Exception e)
            {
                Console.WriteLine("Non Variable template checkout failed Error : " + e);
                throw e;
            }
        }


        //Add credit card 

        //variable template credit card checkout
        public void VariableTemplateCreditCardCheckout()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                accountPage.SetCreditCard();
                homepage.SelectMenuType("Dropdown");
                try
                {
                    itemsearchpage.SearchItem("130719");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Template not found"+e);
                    throw e;
                }

                //select searched template
                itemsearchpage.SelectSearchItem();
                itemsearchpage.ClickOnCreateYourDesignButton();
                createdesignpage.SaveDesign();
                productselectionpage.AddToCart1();
                shoppingcartpage.ContinueToCheckout();
                SelectPaymentMethod("Credit Card");
            }
            catch (Exception e)
            {
                Console.WriteLine("Variable Template Credit Card Checkout Failed : " + e);
                throw e;
            }
        }
    }
}