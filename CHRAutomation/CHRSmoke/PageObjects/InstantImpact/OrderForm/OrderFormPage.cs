using System;
using CHRSmoke.Initiate;
using CHRSmoke.Interaction;
using OpenQA.Selenium;
using NUnit.Framework;
using CHRSmoke.PageObjects.InstantImpact.Home;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace CHRSmoke.PageObjects.InstantImpact.OrderForm
{
    public class OrderFormPage : Base
    {
        public By lnkOrderForm { get { return By.XPath("//*[@href='OnlineOrderForm/default.aspx']"); } }
        public By imgNewCustomOrder { get { return By.XPath("//input[@id='Body_NewOrderButton']"); } }
        public By txbNewAccountNo { get { return By.XPath("//input[@id='ctl00_Body_rtbNewAccountName']"); } }
        public By divJobtittle { get { return By.XPath("//tr[@class='rcbReadOnly']"); } }
        public By txbJobTittle { get { return By.XPath("//tr[@class='rcbReadOnly']/td[1]/input"); } }
        public By lstJobTittle { get { return By.XPath("//div[@id='ctl00_Body_rcbJobType_DropDown']/div/ul/li"); } }
        public By imgLoading { get { return By.XPath("//img[@src='/Content/Images/loading.gif']"); } }
        public By txbBillingNotes { get { return By.XPath("//textarea [@id='ctl00_Body_rtbBillingNotes']"); } }
        public By btnContinueToItem { get { return By.XPath("//span[@id='ctl00_Body_btnContinue']"); } }
        public By rushDate { get { return By.XPath("//span[@style='color:red']"); } }
        public By standardDate { get { return By.XPath("//span[@style='color:green']"); } }
        public By btnNextForMonth { get { return By.XPath("//a[@id='ctl00_Body_rdcJobCalendar_NN']"); } }
        public By imgSmallFormatPrint { get { return By.XPath("//a[@href='Print/PrintDetails1.aspx?type=1']/img"); } }
        public By lblSuccessOrderMsg { get { return By.XPath("//div[@id='Body_pnlSuccess']/div/div/h3/strong"); } }
        public By imgPoster1Side { get { return By.XPath("//input[@id='ctl00_Body_RadListView1_ctrl1_ImageButton1']"); } }
        public By txbOrderLineName { get { return By.XPath("//input[@id='ctl00_Body_txtJobLineName']"); } }
        public By ddlSize { get { return By.XPath("//*[@id='ctl00_Body_ddlSize']/table/tbody/tr/td[1]"); } }
        public By ddlPaper { get { return By.XPath("//input[@id='ctl00_Body_ddlMedia_Input']"); } }
        public By ddlLamination { get { return By.XPath("//input[@id='ctl00_Body_ddlLamination_Input']"); } }
        public By lstLamination { get { return By.XPath("//div[@id='ctl00_Body_ddlLamination_DropDown']/div/ul/li"); } }
        public By lstSize { get { return By.XPath("//div[@id='ctl00_Body_ddlSize_DropDown']/div/ul/li"); } }
        public By lstPaper { get { return By.XPath("//div[@id='ctl00_Body_ddlMedia_DropDown']/div/ul/li"); } }
        public By ddlMounting { get { return By.XPath("//input[@id='ctl00_Body_ddlMounting_Input']"); } }
        public By lstMounting { get { return By.XPath("//div[@id='ctl00_Body_ddlMounting_DropDown']/div/ul/li"); } }
        public By ddlAccessory { get { return By.XPath("//input[@id='ctl00_Body_ddlAccessory_Input']"); } }
        public By lstAccessory { get { return By.XPath("//div[@id='ctl00_Body_ddlAccessory_DropDown']/div/ul/li"); } }
        public By btnNextForOrderDetails { get { return By.XPath("//*[@id='ctl00_Body_btnNext']"); } }
        public By lblDueDate { get { return By.XPath("//span[@id='Body_CurrentOrderInfo_lblDueDate']"); } }
        public By imgAddNewNote { get { return By.XPath("//input[@id='ctl00_Body_JobLineNotes1_grdNotes_ctl00_ctl02_ctl00_AddNewRecordButton']"); } }
        public By textDivAddNewNote { get { return By.XPath("//div[@id='ctl00_Body_JobLineNotes1_grdNotes_ctl00_ctl02_ctl02_txtNotes']"); } }
        public By btnNoBrand { get { return By.XPath("//span[@id='ctl00_Body_btnNoBrands']/span"); } }
        public By txbAddNewNote { get { return By.XPath("//textarea[@id='ctl00_Body_JobLineNotes1_grdNotes_ctl00_ctl02_ctl02_txtNotesTextArea']"); } }
        public By btnCompleteOrder { get { return By.XPath("//span[@id='ctl00_Body_btnContinueTwo']/span"); } }
        public By btnSaveForAddNewNote { get { return By.XPath("//input[@id='ctl00_Body_JobLineNotes1_grdNotes_ctl00_ctl02_ctl02_btnUpdate_input']"); } }
        public By btnContinueToOrderSummary { get { return By.XPath("//span[@id='ctl00_Body_btnContinue']/span"); } }
        public By lblOrderNumber { get { return By.XPath("//div[@id='Body_pnlSuccess']/div/h4/strong"); } }
        public By LblOrderNumber { get { return By.XPath("//*[@id='Body_lblDtNumber']"); } }




        IWebDriver Driver;
        HomePage homepage;
        public OrderFormPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            //PageFactory.InitElements(Driver, this);
            homepage = new HomePage(Driver);
        }

        //select Order Form
        public void SelectOrderForm()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                if (action.IsElementPresent(lnkOrderForm))
                {
                    action.Click(lnkOrderForm);
                    action.WaitForPageToLoad();
                }
                else
                {
                    homepage.SelectMenu("Oreder form");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Select Order Form failed due to " + e);
                throw e;
            }
        }

        //Select rush date
        public void SelectRushDate()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                if (action.IsElementPresent(rushDate))
                {
                    IList<IWebElement> lstRushDate = action.GetElements(rushDate);
                    for (int i = 0; i < lstRushDate.Count; i++)
                    {
                        lstRushDate[1].Click();
                        break;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Select Rush Date due to " + e);
                throw e;

            }

        }

        //select Satandard date
        public void SelectStandardDate()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                if (action.IsElementPresent(standardDate))
                {
                    IList<IWebElement> lstStandardDate = action.GetElements(standardDate);
                    for (int j = 0; j < lstStandardDate.Count; j++)
                    {
                        lstStandardDate[1].Click();
                        break;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Select Standard Date due to " + e);
                throw e;
            }
        }

        public void SelectJobDueDate(string typeOfDueDate)
        {
            Interactions action = new Interactions(Driver);
            try
            {
                while (true)
                {
                    if (typeOfDueDate.ToUpper().Equals("RUSH DATE"))
                    {
                        if (action.IsElementPresent(rushDate))
                        {
                            SelectRushDate();
                            break;
                        }

                    }

                    else if (typeOfDueDate.ToUpper().Equals("STANDARD DATE"))
                    {
                        if (action.IsElementPresent(standardDate))
                        {
                            SelectStandardDate();
                            break;

                        }
                        else
                        {
                            //click on next calender button
                            action.Click(btnNextForMonth);

                        }
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("selection of due date failed Error: " + e);
                throw e;
            }

        }

        //fill job details for create new order
        public void FillOrderInformation()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                //click on 'create a new custom order' btn
                if (action.IsElementPresent(imgNewCustomOrder))
                {
                    action.Click(imgNewCustomOrder);
                }
                //enter exixsting account number
                // action.Type(obj_InstantImpact.txbExistingAccountNo, "1234456");
                //or
                if (action.IsElementPresent(txbNewAccountNo))
                {
                    action.Type(txbNewAccountNo, "testAccount");
                }
                if (action.IsElementPresent(divJobtittle))
                {
                    action.ScrollToViewElement(divJobtittle);
                    action.Click(txbJobTittle);
                    action.WaitVisible(lstJobTittle);
                    IList<IWebElement> lstjobTittles = action.GetElements(lstJobTittle);
                    for (int i = 0; i <= lstjobTittles.Count; i++)
                    {
                        lstjobTittles[1].Click();
                        action.WaitWhileNotVisible(imgLoading);
                        action.WaitTime(5);
                        break;
                    }
                }
                ////enter job tittle
                //action.Type(obj_InstantImpact.txbJobTittle, "testJobTittle");
                if (action.IsElementPresent(txbBillingNotes))
                {
                    //action.ScrollToViewelement(obj_InstantImpact.txbBillingNotes);
                    //enter billing notes
                    action.Type(txbBillingNotes, "testBillingNotes");
                }

                //scrool to to view continue to item btn
                action.ScrollToViewElement(btnContinueToItem);
                //select job due date
                SelectJobDueDate("standard date");
                //click on continue to items
                action.Click(btnContinueToItem);
                action.WaitForPageToLoad();
                action.WaitVisible(imgSmallFormatPrint);
            }
            catch (Exception e)
            {
                Console.WriteLine("Filling job dettails failled Error : " + e);
                throw e;
            }
        }

        //select small format print 
        public void SelectSmallFormatPrint()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                action.WaitVisible(imgSmallFormatPrint);
                action.ScrollToViewElement(imgSmallFormatPrint);
                action.Click(imgSmallFormatPrint);
                action.WaitWhileNotVisible(imgLoading);
            }
            catch (Exception e)
            {
                Console.WriteLine("Small print format selection failed Error :" + e);
                throw e;
            }
        }

        //selct width/Height
        public void SelectWidth_Height()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                action.Click(ddlSize);
                action.WaitTime(2);
                IList<IWebElement> lstWidth = action.GetElements(lstSize);
                for (int i = 0; i < lstWidth.Count; i++)
                {
                    if (lstWidth.Count >= 2)
                    {
                        lstWidth[2].Click();
                        action.WaitWhileNotVisible(imgLoading);
                        action.WaitTime(1);
                        break;
                    }
                    else
                    {
                        lstWidth[1].Click();
                        action.WaitWhileNotVisible(imgLoading);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Width/Height Selection failed Error : " + e);
                throw e;
            }
        }

        //select Paper
        public void SelectPaperOption()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                action.Click(ddlPaper);
                action.WaitTime(2);
                IList<IWebElement> lstPaperOption = action.GetElements(lstPaper);
                for (int i = 0; i < lstPaperOption.Count; i++)
                {
                    if (lstPaperOption.Count >= 2)
                    {
                        lstPaperOption[2].Click();
                        action.WaitWhileNotVisible(imgLoading);
                        break;
                    }
                    else
                    {
                        lstPaperOption[1].Click();
                        action.WaitWhileNotVisible(imgLoading);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Paper selection failed : " + e);
                throw e;
            }
        }

        //select Lamination
        public void SelectLamination()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                action.Click(ddlLamination);
                action.WaitTime(2);
                IList<IWebElement> lstLaminations = action.GetElements(lstLamination);
                for (int i = 0; i < lstLaminations.Count; i++)
                {
                    if (lstLaminations.Count >= 2)
                    {
                        lstLaminations[2].Click();
                        action.WaitWhileNotVisible(imgLoading);
                        break;
                    }
                    else
                    {
                        lstLaminations[1].Click();
                        action.WaitWhileNotVisible(imgLoading);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Select Lamination failed due to " + e);
                throw e;
            }
        }

        //select Mounting option
        public void SelectMountingOption()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                action.Click(ddlMounting);
                action.WaitTime(2);
                IList<IWebElement> lstMount = action.GetElements(lstMounting);
                for (int i = 0; i < lstMount.Count; i++)
                {
                    if (lstMount.Count >= 2)
                    {
                        lstMount[1].Click();
                        action.WaitWhileNotVisible(imgLoading);
                        break;
                    }
                    else
                    {
                        lstMount[1].Click();
                        action.WaitWhileNotVisible(imgLoading);
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Select Mounting Option failed due to " + e);
                throw e;
            }
        }

        //select accessory
        public void SelectAccessory()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                action.Click(ddlAccessory);
                action.WaitTime(1);
                if (action.IsElementPresent(lstAccessory))
                {
                    IList<IWebElement> lstAccessorys = action.GetElements(lstAccessory);
                    for (int i = 0; i < lstAccessorys.Count; i++)
                    {
                        if (lstAccessorys.Count >= 2)
                        {
                            lstAccessorys[1].Click();
                            action.WaitWhileNotVisible(imgLoading);
                            break;
                        }
                        else
                        {
                            lstAccessorys[2].Click();
                            action.WaitWhileNotVisible(imgLoading);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Select Accessory failed due to " + e);
                throw e;
            }
        }

        //fill orderItemFields
        public void FillOnlineOrderItemsFields()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                //Select print format for item
                SelectSmallFormatPrint();
                action.WaitWhileNotVisible(imgLoading);
                action.WaitForPageToLoad();
                action.ScrollToViewElement(imgPoster1Side);
                action.Click(imgPoster1Side);
                action.WaitWhileNotVisible(imgLoading);
                action.WaitForPageToLoad();
                action.ScrollToViewElement(txbOrderLineName);
                if (action.IsElementPresent(txbOrderLineName))
                {
                    action.Type(txbOrderLineName, "testOrderLine");
                }
                if (action.IsElementPresent(ddlSize))
                {
                    action.ScrollToViewElement(ddlSize);
                    SelectWidth_Height();
                }
                if (action.IsElementPresent(ddlPaper))
                {
                    action.ScrollToViewElement(ddlPaper);
                    SelectPaperOption();
                }
                
                if (action.IsElementPresent(ddlLamination))
                {
                    action.ScrollToViewElement(ddlLamination);
                    SelectLamination();
                }
                if (action.IsElementPresent(ddlMounting))
                {
                    action.ScrollToViewElement(ddlMounting);
                    SelectMountingOption();
                }
                if (action.IsElementPresent(ddlAccessory))
                {
                    action.ScrollToViewElement(ddlAccessory);
                    SelectAccessory();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Fill order items");
                throw e;
            }
        }

        //click on next button
        public void ClickOnNextButton()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                action.ScrollToBottomOfPage();
                // action.ScrollToViewElement(obj_InstantImpact.btnNextForOrderDetails);
                action.WaitTime(5);
                action.WaitVisible(btnNextForOrderDetails);
                action.Click(btnNextForOrderDetails);
                action.WaitWhileNotVisible(imgLoading);
                action.WaitForPageToLoad();
                // action.WaitVisible(obj_InstantImpact.lblDueDate);
            }
            catch (Exception e)
            {
                Console.WriteLine("Click On Next Button failed due to " + e);
                throw e;
            }
        }

        //Add new notes
        public void AddNewNote()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                if (action.IsElementPresent(imgAddNewNote))
                {
                    // action.ScrollToViewelement(obj_InstantImpact.imgAddNewNote);
                    action.ScrollToBottomOfPage();
                    action.Click(imgAddNewNote);
                    action.WaitWhileNotVisible(imgLoading);
                    action.WaitVisible(textDivAddNewNote);
                    action.Type(txbAddNewNote, "TestNote");
                    action.ScrollToViewElement(btnSaveForAddNewNote);
                    action.Click(btnSaveForAddNewNote);
                    action.WaitWhileNotVisible(imgLoading);
                    action.Click(btnNextForOrderDetails);
                    action.WaitWhileNotVisible(imgLoading);
                    action.WaitForPageToLoad();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Add New Note failed due to " + e);
                throw e;
            }
        }

        //select no brandmentions
        public void SelectNoBrand()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                action.ScrollToBottomOfPage();
                action.Click(btnNoBrand);
                action.WaitWhileNotVisible(imgLoading);
                action.WaitForPageToLoad();

            }
            catch (Exception e)
            {
                Console.WriteLine("Select No Brand failed due to " + e);
                throw e;
            }
        }

        //select continue to order summary
        public void ContinueToOrderSummary()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                action.ScrollToViewElement(btnContinueToOrderSummary);
                action.Click(btnContinueToOrderSummary);
                action.WaitWhileNotVisible(imgLoading);
                action.WaitVisible(btnCompleteOrder);
            }
            catch (Exception e)
            {
                Console.WriteLine("Continue To Order Summary failed due to " + e);
                throw e;
            }
        }

        //select complete order
        public void ClickOnCompleteOrder()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                action.Click(btnCompleteOrder);
                action.WaitForPageToLoad();
                // action.WaitVisible(obj_InstantImpact.divOrderSubmit);
            }
            catch (Exception e)
            {
                Console.WriteLine("Click On Complete Order failed due to " + e);
                throw e;
            }

        }

        //Get success order message
        public string GetSuccessOrderMsg()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                action.WaitVisible(lblSuccessOrderMsg);
                string OrderSuccessMsg = action.GetText(lblSuccessOrderMsg);
                // string OrderNumber = action.GetText(obj_InstantImpact.lblOrderNumber);
                //Console.WriteLine(OrderSuccessMsg);
                //Console.WriteLine(OrderNumber);
                return OrderSuccessMsg;
            }
            catch (Exception e)
            {
                Console.WriteLine("Get SuccessOrder Msg failed due to " + e);
                throw e;
            }

        }



        //Create a New custom order form
        public void CreateNewCustomOrder()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                //select Order Form
                SelectOrderForm();
                //fill job details
                FillOrderInformation();
                //fill order details
                FillOnlineOrderItemsFields();
                //click on next butto
                ClickOnNextButton();
                //add new notes
                AddNewNote();
                //select No Brand
                SelectNoBrand();
                //clcik on next button
                ClickOnNextButton();
                //select continue to order summary
                ContinueToOrderSummary();
                //click on complete order
                ClickOnCompleteOrder();
                //Get order success msg
                GetSuccessOrderMsg();
            }
            catch (Exception e)
            {
                Console.WriteLine("Create a new custom method failed Error:-" + e);
                throw e;
            }
        }

        //verify success order
        public void IsOrderSuccess()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                bool statusofordernumber = action.IsElementDisplayed(LblOrderNumber);
                if (statusofordernumber == true)
                {
                    string ordernumber = action.GetText(LblOrderNumber);
                    Console.WriteLine("Order Successfully placed with order Number is " + ordernumber);
                }
                else
                {
                    Console.WriteLine("Order process failed.");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("IsOrderSuccess failed due to " + e);
                throw e;
            }

        }
    }
}