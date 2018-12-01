using System;
using CHREnhancements.Initiate;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using CHREnhancements.Interaction;
using System.Collections;
using NUnit.Framework;

namespace CHREnhancements.PageObject.InstantImpact.CreateDesign
{
    public class CreateDesignPage : Base
    {
        public static By CreateDesignHeader
        { get { return (By.XPath("//h1[contains(text(),'Create Your Design')]")); } }

        public static By CreateDesignCancel
        { get { return (By.XPath("//*[text()='Cancel']")); } }

        public static By CancelDesignPopup
        { get { return (By.XPath("//*[contains(@id,'confirm1521')]")); } }

        public static By CancelDesignPopupOk
        { get { return (By.XPath("//*[@class='rwOkBtn'][1]")); } }

        public static By CancelDesignPopupCancel
        { get { return (By.XPath("//*[@value='Cancel']")); } }

        public static By PreviewChanges
        { get { return (By.Id("Body_repaintImageTopButton")); } }

        public static By SaveDesign
        { get { return (By.XPath("//i[contains(text(),'save')]")); } }

        public static By ExistingDesignNameMsg
        { get { return (By.XPath("//*[text()='Design name exists, please re-try.']")); } }

        public static By ViewProof
        { get { return (By.Id("Body_lnkDownload")); } }

        public static By ChooesLayOut
        { get { return (By.Id("Body_ddlChooseLayout")); } }

        public static By ChooseDrinkOne
        { get { return (By.Id("Body_ddlChooseDrinkOne")); } }

        public static By PriceOne
        { get { return (By.Id("Body_txtQTPrice One")); } }

        public static By ChooseDrinkTwo
        { get { return (By.Id("Body_ddlChooseDrinkTwo")); } }

        public static By PriceTwo
        { get { return (By.Id("Body_txtQTPrice Two")); } }

        public static By ChooseDrinkThree
        { get { return (By.Id("Body_ddlChooseDrinkThree")); } }

        public static By PriceThree
        { get { return (By.Id("Body_txtQTPrice Three")); } }

        public static By PreviewImage
        { get { return (By.Id("imgProof")); } }

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

        public static By SaveDeisgnPopup
        { get { return (By.Id("ctl00_Body_rwSaveDesignModal_C")); } }

        public static By YesInOverWritePopup
        { get { return (By.XPath("//*[@id='ctl00_Body_rwSelectAlternate_C_btnAccept']")); } }

        public static By NoInOverWritePopup
        { get { return (By.XPath("//*[@id='ctl00_Body_rwSelectAlternate_C_btnDeny']")); } }

        public static By YesFromCancelCreateDesignPopup
        { get { return (By.XPath("(//*[@class='btn GenericRedButton'])[1]")); } }

        public static By NoFromCancelCreateDesignPopup
        { get { return (By.XPath("(//*[@class='btn GenericRedButton'])[2]")); } }

        public static By NoFromNext
        { get { return (By.XPath("//*[@class='btn GenericRedButton']/span/span[text()='No']")); } }

        public static By YesFromNext
        { get { return (By.XPath("//*[@class='btn GenericRedButton']/span/span[text()='Yes']")); } }

        public static By Loader
        { get { return (By.XPath("//*[@src='/Content/Images/loading.gif']")); } }

        public static By MyProject
        { get { return (By.Id("MyProjectsHeader")); } }

        public static By OverwriteFromEdit
        { get { return (By.XPath("//*[@id='ctl00_Body_rwSelectOption_C_btnOverwrite']")); } }

        public static By SaveAsNewFromEdit
        { get { return (By.XPath("//*[@id='ctl00_Body_rwSelectOption_C_btnSaveAsNew']")); } }

        public static By ReflectedTemplateId
        { get { return (By.XPath("//*[@id='Body_lblTemplateID']/b")); } }

        public static By NoFromCancel
        { get { return (By.XPath("//*[@class='boxes']/a[2]")); } }

        public static By Price
        { get { return (By.XPath("//*[@id='Body_txtQTPrice___livespell_proxy']")); } }

        public static By Message
        { get { return (By.XPath("//*[@id='Body_txtQMMessage']")); } }

        public static By Accont
        { get { return (By.XPath("//*[@id='Body_txtQMAccount']")); } }

        Interactions action;
        public CreateDesignPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
        }


        //Verify Create Design Page
        public void VerifyCreateDesignPage()
        {
            try
            {
                action.WaitForPageToLoad();
                action.WaitVisible(CreateDesignHeader);
                bool status_of_createdesignlogo = action.IsElementDisplayed(CreateDesignHeader);
                Console.WriteLine("Status of create design header is " + status_of_createdesignlogo);
                Console.WriteLine("Status of create design header is " + status_of_createdesignlogo);
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify Create design page failed due to : " + e);
                throw e;
            }

        }

        //Verify Spell Check Functionality
        public void VerifySpellCheck()
        {
            try
            {
                action.WaitVisible(Price);
                action.Type(Price,"pacificcc");
                IWebElement element = Driver.FindElement(By.XPath("//*[@id='Body_txtQTPrice___livespell_proxy']"));
                //action.MoveToElement(element).SendKeys(Keys.ArrowRight).Perform();
                //action.MoveToElement(element).SendKeys(Keys.ArrowRight).Perform();
                //action.MoveToElement(element).SendKeys(Keys.Shift + Keys.F10);
                //action.MoveToElement(element).ContextClick().Perform();
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify Spell check failed due to : " + e);
                throw e;
            }
        }

        //Verify Banned Words
        public static ArrayList list = new ArrayList();
        public static IList GetListOfBannedWords()
        {
            try
            {
                list.Add("March Madness");
                list.Add("Irish Car Bomb");
                list.Add("Taco Tuesday");
                list.Add("Back to School");
                list.Add("Dark 'N' Stormy");
                list.Add("Marilyn Monroe");
                list.Add("Coca-Cola");
                list.Add("Starburst");
                list.Add("Skittles");
                list.Add("NFL");
                list.Add("MLB");
                list.Add("NBA");
                list.Add("Olympics");
                list.Add("World Cup");
                Console.WriteLine("List of banned words is " + list.Count);
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine("List is empty failed due to " + e);
                throw e;
            }
        }

        //Verify Banned Words for Price Field
        public void VerifyBannedWordsForPrice()
        {
            try
            {
                action.WaitVisible(Price);
                for (int i = 0; i < list.Count; i++)
                {
                    string fullbannedword = (string)(list[i]);
                    string bannedword = fullbannedword.ToLower();
                    Console.WriteLine(bannedword);
                    action.Type(Price,bannedword);
                    VerifyPreviewChanges();
                    action.WaitForPageToLoad();
                    action.Clear(Price);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify banned words for Price field failed due to " + e);
                throw e;
            }
        }

        //Verify Banned Words for Message
        public void VerifyBannedWordsForMessage()
        {
            try
            {
                action.WaitVisible(Message);
                for (int i = 0; i < list.Count; i++)
                {
                    string fullbannedword = (string)(list[i]);
                    string bannedword = fullbannedword.ToLower();
                    Console.WriteLine(bannedword);
                    action.Type(Message,bannedword);
                    VerifyPreviewChanges();
                    action.WaitForPageToLoad();
                    action.Clear(Message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify banned words for Price field failed due to " + e);
                throw e;
            }
        }


        //Verify Banned Words for Account
        public void VerifyBannedWordsForAccount()
        {
            try
            {
                action.WaitVisible(Accont);
                for (int i = 0; i < list.Count; i++)
                {
                    string fullbannedword = (string)(list[i]);
                    string bannedword = fullbannedword.ToLower();
                    Console.WriteLine(bannedword);
                    action.Type(Message,bannedword);
                    VerifyPreviewChanges();
                    action.WaitForPageToLoad();
                    action.Clear(Accont);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify banned words for Price field failed due to " + e);
                throw e;
            }
        }

        //Verify Template-Id in Create Design page
        public void VerifyTemplateIdInCreateDesignPage(string original_templateid)
        {
            try
            {
                string templateid_in_createdesignpage = action.GetText(ReflectedTemplateId);
                Console.WriteLine("Template id is in Create Design Page " + templateid_in_createdesignpage);
                bool match = original_templateid.Equals(templateid_in_createdesignpage);
                Console.WriteLine("Status of matching two id is " + match);
                Assert.IsTrue(match);
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify Template Id In Create Design Page failed due to : " + e);
                throw e;
            }
        }

        //Verify Banned Words in Create Design Page
        public void VerifBannedWordInCreateDesignPage(string newbannedword)
        {
            try
            {
                action.WaitVisible(Message);
                action.Type(Message,newbannedword);

            }
            catch (Exception e)
            {
                Console.WriteLine("Verify banned word in create design page failed due to : " + e);
                throw e;
            }
        }



        //Click on Preview Changes
        public void VerifyPreviewChanges()
        {
            try
            {
                action.WaitVisible(PreviewChanges);
                action.Click(PreviewChanges);
                action.WaitVisible(SaveDesign);
            }
            catch (Exception e)
            {
                Console.WriteLine("Preview Changes failed due to : " + e);
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

        //Click on Save on Save Design Popup
        public void ClickOnSaveInSaveDesignPopup()
        {
            try
            {
                action.WaitVisible(YesSaveInSaveDesignPopup);
                action.Click(YesSaveInSaveDesignPopup);

            }
            catch (Exception e)
            {
                Console.WriteLine("Click on Save failed due to : " + e);
                throw e;
            }
        }


        //Click on View Proof
        public void VerifyViewProof()
        {
            try
            {
                action.WaitVisible(ViewProof);
                action.Click(ViewProof);
            }
            catch (Exception e)
            {
                Console.WriteLine("View proof failed due to : " + e);
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
                action.Type(DesignNameField,designnanme);
                action.WaitVisible(SaveDesignNameYes);
                action.Click(SaveDesignNameYes);
                //action.WaitVisible(SaveDesignNameConfirmMsg);
                //String msg = action.GetText(SaveDesignNameConfirmMsg);
                //Console.WriteLine("Confirmation msg after successfully saving the design name " + msg);

            }
            catch (Exception e)
            {
                Console.WriteLine("Verify Design name failed due to : " + e);
                throw e;
            }

        }

        public void navigateToWorkCenterFromCreateDesinPage()
        {
            try
            {
                action.GoToURL("http://ii4.uat.brandmuscle.net/Account/MyProjectsPage.aspx");
            }
            catch(Exception e)
            {
                Console.WriteLine("Navigate To WorkCenter From CreateDesinPage failed due to : " + e);
                throw e;
            }
        }


        //Verify Max Length for Design Name
        public void VerifyDesignNameWithMaxLength()
        {
            try
            {
                string designname = action.StringGenerator(150);
                action.WaitVisible(DesignNameField);
                action.Type(DesignNameField,designname);
                int lenghth_of_designname = designname.Length;
                Console.WriteLine("Length of design name is " + lenghth_of_designname);
                Assert.AreEqual(150, lenghth_of_designname);
                Console.WriteLine("Maximum field length for Design Name meets requirement..");
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify Max Length For Account Name failed due to " + e);
                Assert.Fail();
            }
        }

        //Click on NextStep
        public void ClickOnNextStep()
        {
            try
            {
                action.WaitVisible(NextStep);
                action.Click(NextStep);
                //test.Pass("Click on next step passed.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Cancel Design name pop-up failed due to : " + e);
                throw e;
            }
        }

        //Click on Cancel in Create Deisgn page
        public void ClickOnCancel()
        {
            try
            {
                action.ScrollToViewElement(CreateDesignCancel);
                action.WaitVisible(CreateDesignCancel);
                action.Click(CreateDesignCancel);
            }
            catch (Exception e)
            {
                Console.Write("Click On Cancel failed due to " + e);
                throw e;
            }
        }

        //Click on No  in Cancel in Create Deisgn page
        public void ClickOnNoCancel()
        {
            try
            {
                action.WaitVisible(NoFromCancel);
                action.Click(NoFromCancel);
            }
            catch (Exception e)
            {
                Console.Write("Click On Cancel failed due to " + e);
                throw e;
            }
        }



        //OverWrite Save Design name from Edit in Create Deisgn page
        public void OverWriteExistingNameWithYes()
        {
            try
            {
                action.WaitVisible(SaveDesign);
                action.Click(SaveDesign);
                action.WaitVisible(YesSaveInSaveDesignPopup);
                action.Click(YesSaveInSaveDesignPopup);
                action.Click(YesInOverWritePopup);
            }
            catch (Exception e)
            {
                Console.Write("Click On Save failed due to " + e);
                throw e;
            }
        }

        //OverWrite Save Design name from Edit in Create Deisgn page
        public void NewDesignNameFromPos()
        {
            try
            {
                action.WaitVisible(SaveDesign);
                action.Click(SaveDesign);

            }
            catch (Exception e)
            {
                Console.Write("Click On Save failed due to " + e);
                throw e;
            }
        }

        //Click on No on OverWrite popup in Create Deisgn page
        public void ClickOnNoInOverWritePopup()
        {
            try
            {
                action.WaitVisible(NoInOverWritePopup);
                action.Click(NoInOverWritePopup);
            }
            catch (Exception e)
            {
                Console.Write("Click On no failed due to " + e);
                throw e;
            }
        }

        //Clear Text field in save design name
        public void ClearTextInSaveDesignPopup()
        {
            try
            {
                action.WaitVisible(DesignNameField);
                action.Type(DesignNameField,Keys.Control + "a");
                action.Type(DesignNameField,Keys.Clear);
            }
            catch (Exception e)
            {
                Console.Write("Clear Text In Save DesignPopup failed due to " + e);
                throw e;
            }
        }

        //Click on No on Confirmation popup in Create Deisgn page after click on Next Step
        public void ClickOnNoFromNextStep()
        {
            try
            {
                action.WaitVisible(NoFromNext);
                action.Click(NoFromNext);
            }
            catch (Exception e)
            {
                Console.Write("Click On no failed due to " + e);
                throw e;
            }
        }

        //Click on Next Step and Yes in Prompt
        public void ClickOnYesFromNextStep()
        {
            try
            {
                action.WaitVisible(YesFromNext);
                action.Click(YesFromNext);
            }
            catch (Exception e)
            {
                Console.Write("Click On Yes failed due to " + e);
                throw e;
            }
        }

        //Negative Cases for Edit
        public void CancelCreatedesign()
        {
            try
            {
                action.Click(CreateDesignCancel);
                action.WaitVisible(CancelDesignPopupOk);
                action.Click(CancelDesignPopupOk);
                Assert.IsTrue(action.IsElementDisplayed(CancelDesignPopupOk));
            }
            catch (Exception e)
            {
                Console.WriteLine("Cancel Createdesign failed due to : " + e);
                throw e;
            }
        }

        //Negative Cases for Save
        public void CancelSaveDesignName(string name)
        {
            try
            {
                if (action.IsElementEnabled(SaveDesign))
                {
                    action.Click(SaveDesign);
                    bool status_of_save_button = action.IsElementEnabled(SaveDesignNameYes);
                    Console.WriteLine("Status of save design button is " + status_of_save_button);
                    action.WaitVisible(SaveDeisgnPopup);
                    String designnanme = name + DateTime.Now.ToString();
                    action.Type(DesignNameField,designnanme);
                    action.Click(SaveDesignNameNo);
                }
                else
                {
                    Console.WriteLine("Cancel SaveDesign Name failed.");
                }
                if (action.IsElementDisplayed(CreateDesignHeader))
                {
                    Console.Write("Create Design page is opened.");
                }
                else
                {
                    Console.Write("Navigating to Create Design page failed.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Cancel Save DesignName failed due to : " + e);
                throw e;
            }
        }

        //Checking Visiblity of SaveDesign and ViewProof button.
        public void VerifySaveDesignViewProof()
        {
            try
            {
                bool status_viewproof_before = action.IsElementDisplayed(ViewProof);
                Console.WriteLine("Status of view proof before cliking on Preview changes " + status_viewproof_before);
                action.WaitVisible(PreviewChanges);
                VerifyPreviewChanges();
                action.WaitVisible(ViewProof);
                bool status_viewproof_after = action.IsElementDisplayed(ViewProof);
                Console.WriteLine("Status of view proof after cliking on Preview changes " + status_viewproof_after);
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify SaveDesign ViewProof failed due to : " + e);
                throw e;
            }
        }

        //Verify Alert Msg for Existing Design
        public void VerifyExistingDesignAlertMsg()
        {
            try
            {
                action.Click(SaveDesign);
                action.WaitVisible(SaveDeisgnPopup);
                action.WaitVisible(DesignNameField);
                action.Type(DesignNameField,"suresh");
                string alert_msg = action.GetText(ExistingDesignNameMsg);
                Console.WriteLine("For existing design alert msg is " + alert_msg);
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify Existing Design Alert Msg failed due to : " + e);
                throw e;
            }
        }

        //Click on OverWriteFromEdit
        public void OverWriteFromEdit()
        {
            try
            {
                action.Click(OverwriteFromEdit);
            }
            catch (Exception e)
            {
                Console.WriteLine("Over Write From Edit failed due to : " + e);
                throw e;
            }
        }

        //Click on SaveAsNewFromEdit
        public void SaveasNewFromEdit()
        {
            try
            {
                action.WaitVisible(SaveAsNewFromEdit);
                action.Click(SaveAsNewFromEdit);
            }
            catch (Exception e)
            {
                Console.WriteLine("Over Write From Edit failed due to : " + e);
                throw e;
            }
        }

        //Verify Confirmation Message
        public void VerifyConfirmationMsg()
        {
            try
            {
                action.WaitVisible(SaveDesignNameConfirmMsg);
                String msg = action.GetText(SaveDesignNameConfirmMsg);
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify Confirmation Msg failed due to : " + e);
                throw e;
            }
        }

        //Give New Design name in Save Design Popup from edit
        public void SaveDesignWithNewName(string name)
        {
            try
            {
                string designnanme = name + DateTime.Now.ToString();
                action.WaitVisible(DesignNameField);
                action.Type(DesignNameField,designnanme);
                action.WaitVisible(SaveDesignNameYes);
                action.Click(SaveDesignNameYes);
            }
            catch (Exception e)
            {
                Console.WriteLine("Save Design With New Name failed due to : " + e);
                throw e;
            }
        }

        //Give the Existing design name
        public void GiveExistingName(string name)
        {
            try
            {
                action.WaitVisible(DesignNameField);
                action.Type(DesignNameField,name);
            }
            catch (Exception e)
            {
                Console.WriteLine("Give Existing Name failed due to : " + e);
                throw e;
            }
        }

        //Give the Existence of Save DesignPopup
        public void VerifyExistenceOfSaveDesignPopup()
        {
            try
            {
                action.WaitVisible(SaveDeisgnPopup);
                bool status_of_savedesignpopup = action.IsElementDisplayed(SaveDeisgnPopup);
                Console.WriteLine("Status of save design popup is " + status_of_savedesignpopup);
            }
            catch (Exception e)
            {
                Console.WriteLine("Give Existing Name failed due to : " + e);
                throw e;
            }
        }
    }
}