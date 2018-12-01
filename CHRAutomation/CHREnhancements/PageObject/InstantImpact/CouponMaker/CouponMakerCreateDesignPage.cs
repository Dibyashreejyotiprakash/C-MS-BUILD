using System;
using OpenQA.Selenium;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using OpenQA.Selenium.Support.PageObjects;

namespace CHREnhancements.PageObject.InstantImpact.CouponMaker
{
    class CouponMakerCreateDesignPage : Base
    {
        public static By CouponType
        { get { return (By.XPath("//*[@id='Body_coupons_CouponType_userControl_rblCouponTypes_0']")); } }

        public static By Date
        { get { return (By.XPath("//*[@class='rtsUL']//span[text()='Dates']")); } }

        public static By Startdate
        { get { return (By.XPath("//*[@id='ctl00_Body_coupons_Dates_userControl_txtStartDate_popupButton']")); } }

        public static By SelectStartDate
        { get { return (By.XPath("//*[text()='10'][1]")); } }

        public static By EndDate
        { get { return (By.XPath("//*[@id='ctl00_Body_coupons_Dates_userControl_txtExpirationDate_popupButton']")); } }

        public static By PreviewChanges
        { get { return (By.XPath("//*[@id='Body_coupons_btnRender']")); } }

        public static By PreviewImage
        { get { return (By.XPath("//*[@id='imgProof']")); } }

        public static By SelectEndDate
        { get { return (By.XPath("//*[text()='31'][1]")); } }

        public static By SelectDateHeader
        { get { return (By.XPath("//*[text()='Select the following dates:']")); } }

        public static By States
        { get { return (By.XPath("//*[@class='rtsUL']//span[text()='States']")); } }

        public static By Region
        { get { return (By.Id("Body_coupons_States_userControl_ddlPromoRegion")); } }

        public static By State
        { get { return (By.Id("Body_coupons_States_userControl_ddlPromoState")); } }

        public static By ReviewOrder
        { get { return (By.XPath("//*[@class='rtsUL']//span[text()='Review and Order']")); } }

        public static By PromoCode
        { get { return (By.XPath("//*[@id='lblPromoCode']")); } }

        public static By BuyNow
        { get { return (By.XPath("//*[@id='btnBuyNow']")); } }

        public static By SaveDesign
        { get { return (By.XPath("//i[contains(text(),'save')]")); } }

        public static By SaveDeisgnPopup
        { get { return (By.Id("ctl00_Body_rwSaveDesignModal_C")); } }

        public static By YesSaveInSaveDesignPopup
        { get { return (By.XPath("//*[@id='ctl00_Body_rwSaveDesignModal_C_btnDesignSave']")); } }

        public static By DesignNameField
        { get { return (By.XPath("//*[@id='ctl00_Body_rwSaveDesignModal_C_txtDesignName']")); } }

        public static By SaveDesignNameYes
        { get { return (By.XPath("//*[@id='ctl00_Body_rwSaveDesignModal_C_btnDesignSave']")); } }

        public static By SaveDesignNameNo
        { get { return (By.XPath("//*[@id='ctl00_Body_rwSaveDesignModal_C_btnCancelDesignSave']")); } }

        public static By SaveDesignNameConfirmMsg
        { get { return (By.Id("ctl00_Body_ucMBTwo_ucRadNotification_C_radNotifyTextWrapper")); } }

        public static By NextStep
        { get { return (By.Id("btnNextStep")); } }

        public static By YesInOverWritePopup
        { get { return (By.XPath("//*[@id='ctl00_Body_rwSelectAlternate_C_btnAccept']")); } }

        public static By NoInOverWritePopup
        { get { return (By.XPath("//*[@id='ctl00_Body_rwSelectAlternate_C_btnDeny']")); } }

        Interactions action;
        public CouponMakerCreateDesignPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
        }

        //Click on Select Type of Coupon 
        public void SelectCouponType()
        {
            try
            {
                action.WaitVisible(CouponType);
                action.Click(CouponType);
                action.WaitTime(20);
            }
            catch(Exception e)
            {
                Console.WriteLine("Select Coupon type failed due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Click on Preview
        public void ClickOnPreview()
        {
            try
            {
                action.WaitVisible(PreviewChanges);
                action.Click(PreviewChanges);
            }
            catch (Exception e)
            {
                Console.WriteLine("Click on preview failed due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Select Dates
        public void SelectDates()
        {
            try
            {     
                action.Click(Date);
                action.WaitVisible(Startdate);
                action.Click(Startdate);
                action.Click(SelectStartDate);
                action.Click(EndDate);
                action.Click(SelectEndDate);
                action.WaitTime(10);
            }
            catch(Exception e)
            {
                Console.WriteLine("Select Coupon type failed due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }      
        }

        //Click on States
        public void ClickOnStates()
        {
            try
            {
                action.WaitVisible(States);
                action.Click(States);
                action.WaitTime(20);
            }
            catch (Exception e)
            {
                Console.WriteLine("CLick on States failed due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Select States
        public void SelectStates()
        {
            try
            {
                action.SelectByIndex(Region,1);
                action.SelectByIndex(State, 2);
                action.WaitTime(30);

            }
            catch (Exception e)
            {
                Console.WriteLine("CLick on States failed due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Click on Review & Order
        public void ClickOnReviewOrder()
        {
            try
            {
                action.WaitVisible(ReviewOrder);
                action.Click(ReviewOrder);
                action.WaitTime(30);
            }
            catch (Exception e)
            {
                Console.WriteLine("Click on review & oreder failed due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Get Promo Code
        public void GetPromoCode()
        {
            try
            {
                action.WaitVisible(PromoCode);
                string promocode = action.GetText(PromoCode);
                Console.WriteLine("Promo code is " + promocode);
            }
            catch (Exception e)
            {
                Console.WriteLine("Get promo code failed due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Click on Save 
        public void ClickOnSave()
        {
            try
            {
                action.WaitVisible(SaveDesign);
                action.Click(SaveDesign);

            }
            catch (Exception e)
            {
                Console.WriteLine("Click on Save failed due to : " + e);
                throw e;
            }
        }

        //Clear Text field in save design name
        public void ClearTextInSaveDesignPopup()
        {
            try
            {
                action.WaitVisible(DesignNameField);
                action.Type(DesignNameField, Keys.Control + "a");
                action.Type(DesignNameField, Keys.Clear);
            }
            catch (Exception e)
            {
                Console.Write("Clear Text In Save DesignPopup failed due to " + e);
                throw e;
            }
        }

        //Give design name in Save Design Popup
        public void VerifySaveDesign(string name)
        {
            try
            {
                action.WaitVisible(SaveDesign);
                action.Click(SaveDesign);
                action.WaitVisible(SaveDeisgnPopup);
                ClearTextInSaveDesignPopup();
                string designnanme = name + DateTime.Now.ToString();
                action.Type(DesignNameField, designnanme);
                action.WaitVisible(SaveDesignNameYes);
                action.Click(SaveDesignNameYes);
                action.WaitVisible(SaveDesignNameConfirmMsg);
                String msg = action.GetText(SaveDesignNameConfirmMsg);
                Console.WriteLine("Confirmation msg after successfully saving the design name " + msg);

            }
            catch (Exception e)
            {
                Console.WriteLine("Verify Design name failed due to : " + e);
                throw e;
            }

        }

        //Click on Buy Now
        public void ClickOnBuyNow()
        {
            try
            {
                action.WaitVisible(BuyNow);
                action.Click(BuyNow);
            }
            catch (Exception e)
            {
                Console.WriteLine("Click on Buy Now failed due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }
    }
}
