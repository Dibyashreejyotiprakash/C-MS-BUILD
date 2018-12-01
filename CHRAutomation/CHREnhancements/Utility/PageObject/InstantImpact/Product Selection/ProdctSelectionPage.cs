using System;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace CHREnhancements.PageObject.InstantImpact.Product_Selection
{
    public class ProdctSelectionPage : Base
    {
        public static By SelectProductDetailsHeader
        { get { return (By.XPath("//*[text()='Select Product Details'][1]")); } }

        public static By Cancel
        { get { return (By.Id("Body_lnkBtnCancel")); } }

        public static By Quantity
        { get { return (By.XPath("//*[@name='ctl00$Body$qtyText1']")); } }

        public static By Frame
        { get { return (By.XPath("//*[@class='rwWindowContent']")); } }

        public static By FrameYes
        { get { return (By.XPath("//*[@class='boxes']/a[1]")); } }

        public static By SearchHeader
        { get { return (By.Id("Body_lblSearchHeader")); } }

        public static By Back
        { get { return (By.XPath("//*[@id='Body_lnkBtnCancel']")); } }

        public static By Yes
        { get { return (By.XPath("//*[@class='boxes']/a[1]")); } }

        public static By ItemTypeDropdown
        { get { return (By.XPath("//*[@name='ctl00$Body$ItemTypeDropDownList1']")); } }

        public static By SelectOneItem
        { get { return (By.XPath("//*[@class='rcbList']/li[text()='Die-Cut A-Frame Table Tent']")); } }

        public static By NoBtn
        { get { return (By.XPath("//*[@id='Body_btnNo1']")); } }

        public static By AddToCart
        { get { return (By.XPath("//*[@id='Body_btnAddToCart']")); } }

        public static By YesBtn
        { get { return (By.XPath("//*[@id='Body_btnYes1']")); } }

        public static By TemplateIdLabel
        { get { return (By.XPath("(//*[text()='Template # : 114916'])[2]")); } }

        public static By ItemTypevalidationMsg
        { get { return (By.XPath("//*[text()='Item Type is required']")); } }

        public static By QuantityValidationMsg
        { get { return (By.XPath("//*[text()='Quantity is required']")); } }

        

        Interactions action;
        public ProdctSelectionPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
        }


        //Verify Select Product Details Page
        public void VerifySelectProductDetailsPage()
        {
            try
            {
                action.WaitForPageToLoad();
                action.WaitVisible(SelectProductDetailsHeader);
                bool status = action.IsElementDisplayed(SelectProductDetailsHeader);
                Console.WriteLine("Status of Product Deatils Header is " + status);

            }
            catch (Exception e)
            {
                Console.WriteLine("Verify Select Product page failed due to : " + e);
            }
        }

        //Select Item Type
        public void SelectItemType()
        {
            try
            {
                action.WaitVisible(ItemTypeDropdown);
                action.Click(ItemTypeDropdown);
                action.WaitVisible(SelectOneItem);
                action.Click(SelectOneItem);
            }
            catch (Exception e)
            {
                Console.WriteLine("Select item type failed due to : " + e);
                throw e;
            }
        }

        //Validate without giving Item type
        public void ValidateItemType()
        {
            try
            {
                action.WaitVisible(AddToCart);
                action.Click(AddToCart);
                bool statusofitemtypevalidation = action.IsElementDisplayed(ItemTypevalidationMsg);
                if(statusofitemtypevalidation == true)
                {
                    string validationmessage = action.GetText(ItemTypevalidationMsg);
                    Console.WriteLine("Item type validation message is " + validationmessage);
                }
                else
                {
                    Assert.Fail();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Validate Item Type failed due to : " + e);
                throw e;
            }
        }

        //Validate without giving Item type
        public void ValidateQuatity()
        {
            try
            {
                action.WaitVisible(ItemTypeDropdown);
                action.Click(ItemTypeDropdown);
                action.Click(SelectOneItem);
                action.WaitVisible(AddToCart);
                action.Click(AddToCart);
                bool statusofquantityvalidation = action.IsElementDisplayed(QuantityValidationMsg);
                if (statusofquantityvalidation == true)
                {
                    string validationmessage = action.GetText(ItemTypevalidationMsg);
                    Console.WriteLine("Quantity field validation message is " + validationmessage);
                }
                else
                {
                    Assert.Fail();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Validate Quatity field failed due to : " + e);
                throw e;
            }
        }

        //Cancel
        public void CancelSelectProductDetails()
        {
            try
            {
                action.Click(Cancel);
                action.WaitVisible(FrameYes);
                action.Click(FrameYes);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cancel Select Product Details failed due to : " + e);
            }
        }

        //Qauntity
        public void GiveQuantity(string quantity)
        {
            try
            {
                action.WaitVisible(Quantity);
                action.Type(Quantity,quantity);
                action.WaitTime(20);
            }
            catch (Exception e)
            {
                Console.WriteLine("Give quantity failed due to : " + e);
            }
        }

        //Click on No in Select Product Details Page
        public void ClickOnNo()
        {
            try
            {
                action.WaitVisible(NoBtn);
                action.ScrollToViewElement(NoBtn);
                action.Click(NoBtn);
                action.WaitTime(5);
            }
            catch (Exception e)
            {
                Console.WriteLine("Click on NoS failed due to : " + e);
            }
        }

        //Click on Back
        public void ClickOnBack()
        {
            try
            {
                action.WaitVisible(Back);
                action.Click(Back);
            }
            catch (Exception e)
            {
                Console.WriteLine("Click on back failed due to : " + e);
            }
        }

        //Click on Yes From Back
        public void ClickYesFromBack()
        {
            try
            {
                action.WaitVisible(Yes);
                action.Click(Yes);
            }
            catch (Exception e)
            {
                Console.WriteLine("Click on yes from back failed due to : " + e);
            }
        }

        //Click on AddToCart
        public void ClickOnAddToKart()
        {
            try
            {
                action.WaitVisible(AddToCart);
                action.Click(AddToCart);
            }
            catch (Exception e)
            {
                Console.WriteLine("Click on yes from back failed due to : " + e);
            }
        }

        //Verify Template id is no more visible after click on No
        public void VerifyTemplateidIsNoTVisible()
        {
            try
            {
                action.WaitVisible(YesBtn);
                action.Click(YesBtn);
                action.Click(NoBtn);
                bool statusoftemplateidlabel = action.IsElementDisplayed(TemplateIdLabel);
                if (!statusoftemplateidlabel)
                {
                    Console.WriteLine("Template id label is no more visible.");
                }
                else
                {
                    Assert.Fail();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("VerifyTemplateidIsNoTVisible failed due to : " + e);
                action.TakeScreenshots("Template Id Visibility");
            }
        }
    }
}