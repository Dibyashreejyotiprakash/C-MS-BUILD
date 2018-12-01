using System;
using System.Collections.Generic;
using System.Linq;
using CHREnhancements.Initiate;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using CHREnhancements.Interaction;

namespace CHREnhancements.PageObject.InstantImpact.Projects
{
    public class ProjectsPage : Base
    {
        public static By ProjectsHeader
        { get { return (By.XPath("//*[@class='row no-gutters standardHeader']")); } }

        public static By MyProject
        { get { return (By.XPath("//*[@href='/Account/MyProjectsPage.aspx']")); } }

        public static By SearchButton
        { get { return (By.XPath("//*[@name='ctl00$Body$btnSearch']")); } }

        public static By NextPage
        { get { return (By.XPath("//*[@value=' '][3]")); } }

        public static By SearchBox
        { get { return (By.XPath("//*[@id='Body_TxtSearch']")); } }

        public static By SelectAll
        { get { return (By.XPath("//*[contains(text(),'Select All')]")); } }

        public static By SelectNone
        { get { return (By.XPath("//*[contains(text(),'Select None')]")); } }

        public static By DeleteSelected
        { get { return (By.Id("Body_btnDeleteSelected")); } }

        public static By WithoutSelectDeleteAlert
        { get { return (By.XPath("//*[contains(text(),'Please select at least one')]")); } }

        public static By SortByDesignName
        { get { return (By.XPath("//*[@class='rgHeader'][4]/a")); } }

        public static By SortByTemplateId
        { get { return (By.XPath("//*[@class='t-font-icon rgIcon rgSortAscIcon']")); } }

        public static By SortByTemplateName
        { get { return (By.XPath("//*[@class='t-font-icon rgIcon rgSortAscIcon']")); } }

        public static By AllDesignName
        { get { return (By.XPath("//*[@class='TdDesignName']")); } }

        public static By FirstPreview
        { get { return (By.XPath("//*[@id='ctl00_Body_RadGridTemplate_ctl00_ctl04_lnkPreviewImageEnabled']")); } }

        public static By FirstTemplateRow
        { get { return (By.XPath("//tbody/tr[1]/td[1]")); } }

        public static By FirstCheckBox
        { get { return (By.XPath("//tbody/tr[1]/td[1]")); } }

        public static By FirstRow
        { get { return (By.XPath("//tbody/tr[1]/td[1]")); } }

        public static By SelectAllCheckBox
        { get { return (By.XPath("//thead/tr/th[1]")); } }

        public static By FirstDelete
        { get { return (By.XPath("(//*[text()=' Delete'])[1]")); } }

        public static By DeleteAlertPopup
        { get { return (By.XPath("//*[contains(@id,'confirm1522')]")); } }

        public static By DeleteAlertPopupMsg
        { get { return (By.XPath("//*[contains(text(),'Are you sure you want to delete')]")); } }

        public static By DeleteAlertPopupYes
        { get { return (By.XPath("//*[@class='boxes'][1]/a[1]")); } }

        public static By DeleteAlertPopupNo
        { get { return (By.XPath("//*[@class='boxes'][1]/a[2]")); } }

        public static By ConfirmationMsgPopup
        { get { return (By.XPath("//*[@id='ctl00_Body_ucMB_ucRadNotification_C_radNotifyTextWrapper']")); } }

        public static By SecondCheckBox
        { get { return (By.XPath("//tbody/tr[2]/td[1]")); } }

        public static By AllCheckBox
        { get { return (By.XPath("//tbody/tr/td[1]")); } }

        public static By FirstEdit
        { get { return (By.XPath("//*[@id='ctl00_Body_RadGridTemplate_ctl00_ctl04_lnkEdit']")); } }

        public static By ImageCoulmn
        { get { return (By.XPath("//*[@class='rgHeader'][1]")); } }

        public static By TemplateIdColumn
        { get { return (By.XPath("//*[@class='rgHeader'][5]")); } }

        public static By AddToKart
        { get { return (By.XPath("//*[@id='ctl00_Body_RadGridTemplate_ctl00_ctl04_lnkAddToCart']")); } }

        public static By YesAlertPopup
        { get { return (By.XPath("//*[@class='btn GenericRedButton'][1]")); } }

        public static By Share
        { get { return (By.XPath("//*[@id='ctl00_Body_RadGridTemplate_ctl00_ctl04_lnkShare']")); } }

        public static By PosOnDemand
        { get { return (By.XPath("//*[@class='MenuItems']/div/div/ul/li[2]")); } }

        public static By FirstDesignname
        { get { return (By.XPath("//tbody/tr[1]/td[5]")); } }

        public static By FirstTemplateName
        { get { return (By.XPath("//tbody/tr[1]/td[7]")); } }

        public static By BeforeTemplates
        { get { return (By.XPath("//tbody/tr/td[5]")); } }

        public static By TemplateId
        { get { return (By.XPath("//tbody/tr[1]/td[6]")); } }

        public static By AfterTemplates
        { get { return (By.XPath("//*[@class='rgSorted']")); } }

        public static By AddToCart
        { get { return (By.XPath("//*[@class='cartImage']")); } }

        public static By AllTemplateNames
        { get { return (By.XPath("//*[@class='caption description text-center']")); } }

        public static By Postemplate
        { get { return (By.XPath("//*[(@target='_self') and contains(text(),'POS Templates')]")); } }

        Interactions action;
        public ProjectsPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
        }

        //Verify Home page
        public void VerifyProjectsPage()
        {
            try
            {
                //Check the visiblity of My Project Header
                action.WaitVisible(ProjectsHeader, 30);
                bool status_of_myprojectheader = action.IsElementDisplayed(ProjectsHeader);
                Console.WriteLine("Status of logo is " + status_of_myprojectheader);

                //Check the status of SelectAll
                action.WaitVisible(SelectAll);
                bool status_of_selecteall = action.IsElementEnabled(ProjectsHeader);
                Console.WriteLine("Status of SelectAll is " + status_of_selecteall);

                //Check the status of SelectNone
                action.WaitVisible(SelectNone, 30);
                bool status_of_selectnone = action.IsElementEnabled(ProjectsHeader);
                Console.WriteLine("Status of SelectNone is " + status_of_selectnone);

                //Check the status of DeleteSelected
                action.WaitVisible(DeleteSelected, 30);
                bool status_of_deleteselected = action.IsElementEnabled(DeleteSelected);
                Console.WriteLine("Status of DeleteSelected is " + status_of_deleteselected);
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify home page failed due to : " + e);
                throw e;
            }
        }

        //Verify Template-Id In Craete Design Page
        public string GetTemplateId()
        {
            try
            {
                string templateid = action.GetText(TemplateId);
                Console.WriteLine("Original Template id is " + templateid);
                return templateid;
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify Template id in Create Design Page failed due to : " + e);
                throw e;
            }
        }

        //Delete Single Template
        public void DeleteSingleTemplate()
        {
            try
            {
                //Delete Single Template
                action.WaitVisible(FirstDelete, 20);
                action.Click(FirstDelete);
                action.Click(DeleteAlertPopupYes);
            }
            catch (Exception e)
            {
                Console.WriteLine("Delete Single Template failed due to : " + e);
                action.TakeScreenshots("ClickOnDelete");
                throw e;
            }

        }

        //Delete Multiple Templates
        public void DeleteMultipleTemplates()
        {
            try
            {
                action.Click(FirstCheckBox);
                action.WaitVisible(SecondCheckBox);
                action.Click(SecondCheckBox);
                action.Click(DeleteSelected);
                action.Click(DeleteAlertPopupYes);
            }
            catch (Exception e)
            {
                Console.WriteLine("Delete Multiple Template failed due to : " + e);
                throw e;
            }

        }

        //Delete All Templates
        public void DeleteAllTemplates()
        {
            try
            {
                action.Click(SelectAllCheckBox);
                action.Click(DeleteSelected);
                action.Click(DeleteAlertPopupYes);
            }
            catch (Exception e)
            {
                Console.WriteLine("Delete All Template failed due to : " + e);
                throw e;
            }
        }

        //Click on Edit Button.
        public void ClickOnEdit()
        {
            try
            {
                action.WaitVisible(FirstCheckBox, 20);
                action.Click(FirstEdit);
            }
            catch (Exception e)
            {
                Console.WriteLine("Click on edit failed due to : " + e);
                throw e;
            }
        }

        //Click on Preview Button
        public void ClickOnPreview()
        {
            try
            {
                action.Click(FirstPreview);
                action.WaitForPageToLoad();
            }
            catch (Exception e)
            {
                Console.WriteLine("Click on preview failed due to : " + e);
                throw e;
            }
        }

        //Verify Retired Template
        public void VerifyRetiredTemplate()
        {
            try
            {
                action.Click(FirstPreview);
                action.WaitForPageToLoad();
                action.WindowHandle();
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify Retired Template failed due to : " + e);
                throw e;
            }
        }

        //Verify Template Id In Create Design Page
        public string VerifyTemplateId()
        {
            try
            {
                string template_id = action.GetText(TemplateId);
                // Write the generic code to compare with other related pages(Create Design nad Shopping cart)
                return template_id;
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify Retired Template failed due to : " + e);
                throw e;
            }
        }

        //Click on DeleteSelected without Clicking on Checkbox
        public void ClickDeleteSelectWithoutCheck()
        {
            try
            {
                action.Click(DeleteSelected);
                action.WaitVisible(WithoutSelectDeleteAlert, 30);
                string msg = action.GetText(WithoutSelectDeleteAlert);
                Console.WriteLine("Message after click on DeleteSelected without selcting check box is " + msg);
            }
            catch (Exception e)
            {
                Console.WriteLine("Click Delete Select Without Check failed due to : " + e);
                throw e;
            }
        }

        //Negative Cases For Delete
        public void DismissPopupSingleTemplate()
        {
            try
            {
                action.Click(FirstCheckBox);
                action.Click(FirstDelete);
                action.Click(DeleteAlertPopupNo);
            }
            catch (Exception e)
            {
                Console.WriteLine("Click on Cancel button failed due to : " + e);
                throw e;
            }
        }
        public void DismissPopupMultipleTemplate()
        {
            try
            {
                action.Click(FirstCheckBox);
                action.Click(FirstCheckBox);
                action.Click(SecondCheckBox);
                action.Click(DeleteSelected);
                action.Click(DeleteAlertPopupNo);
            }
            catch (Exception e)
            {
                Console.WriteLine("Click on Cancel button failed due to : " + e);
                throw e;
            }
        }
        public void DismissPopupAllTemplate()
        {
            try
            {
                action.Click(SelectAllCheckBox);
                action.Click(DeleteSelected);
                action.Click(DeleteAlertPopupNo);
            }
            catch (Exception e)
            {
                Console.Write("Dismiss PopupAll Template failed due to : " + e);
                throw e;
            }
        }

        //Verify List of templates in Projects page
        public void VerifyListOfTemplates()
        {
            try
            {
                IList<IWebElement> templates = action.GetElements(BeforeTemplates);
                Console.WriteLine("Number of templates present in a page is " + templates.Count);
                for (int i = 0; i < templates.Count; i++)
                {
                    Console.WriteLine("Design name is " + templates[i].Text);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify List of Templates failed due to " + e);
                throw e;
            }
        }

        //Filter By Design name
        public void FilterByDeisgnName()
        {
            try
            {
                IList<IWebElement> templates = action.GetElements(BeforeTemplates);
                Console.WriteLine("Number of templates present in a page is " + templates.Count());
                for (int i = 0; i < templates.Count; i++)
                {
                    action.Type(SearchBox, templates[i].Text);
                    action.WaitVisible(SearchButton, 10);
                    action.Click(SearchButton);
                    action.Type(SearchBox, Keys.Control + "a");
                    action.Type(SearchBox, Keys.Clear);
                    action.Click(MyProject);
                    if (i == 0)
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Filter By Deisgn Name failed due to " + e);
                throw e;
            }
        }

        //Get The Existing design name
        public string GetExistingName()
        {
            try
            {
                action.WaitVisible(FirstDesignname, 30);
                string before_template = action.GetText(FirstDesignname);
                Console.WriteLine("Temaplate Design name is " + before_template);
                return before_template;
            }
            catch (Exception e)
            {
                Console.WriteLine("Get Existing Name failed due to : " + e);
                throw e;
            }
        }

        //Get The Existing Template Name
        public string GetTemplateName()
        {
            try
            {
                action.WaitVisible(FirstTemplateName, 30);
                string template_name = action.GetText(FirstTemplateName);
                Console.WriteLine("Temaplate Design name is " + template_name);
                return template_name;
            }
            catch (Exception e)
            {
                Console.WriteLine("Get Existing Name failed due to : " + e);
                throw e;
            }
        }

        //Verify Sorting By Design name
        public void VerifySortByDesignName()
        {
            try
            {
                //Before click on Sort by Design name
                IList<IWebElement> before_templates = action.GetElements(BeforeTemplates);
                Console.WriteLine("Design names before sorting..");
                foreach (IWebElement beforeclick in before_templates)
                {
                    Console.WriteLine(beforeclick.Text);
                }
                action.Click(SortByDesignName);
                //After click on Sort by Design name
                Console.WriteLine("Design names after sorting..");
                IList<IWebElement> after_templates = action.GetElements((AfterTemplates));
                foreach (IWebElement afterclick in after_templates)
                {
                    Console.WriteLine(afterclick.Text);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify Sort By Design Name failed due to " + e);
                throw e;
            }
        }

        //Share Templates
        public void ClickOnShare()
        {
            try
            {
                action.WaitVisible(Share, 30);
                action.Click(Share);
            }
            catch (Exception e)
            {
                Console.WriteLine("Click on share failed due to " + e);
                throw e;
            }
        }

        //Click on Add to Kart
        public void ClickOnAddtoKart()
        {
            try
            {
                try
                {
                    action.Click(AddToKart);
                    action.Click(YesAlertPopup);
                }
                catch(Exception e)
                {
                    Console.WriteLine("Add to Cart link is not there");
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Click on add to kart failed due to : " + e);
                throw e;
            }
        }

        //Click on POS On Demand Button
        public void ClickOnPosOnDemand()
        {
            try
            {
                action.ScrollToViewElement(Postemplate);
                action.WaitVisible(Postemplate, 30);
                action.Click(Postemplate);
            }
            catch (Exception e)
            {
                Console.WriteLine("ClickOnPosOnDemand failed due to : " + e);
                throw e;
            }
        }

        //Click on Shopping Cart
        public void ClickOnShoppingCart()
        {
            try
            {
                action.WaitVisible(AddToCart, 30);
                action.Click(AddToCart);
            }
            catch (Exception e)
            {
                Console.WriteLine("Click on shopping cart failed due to " + e);
                throw e;
            }
        }
        //Generate Random String
        public void GenerateRandomString(int requiredlength)
        {
            try
            {
                Random rnd = new Random();
                for (int i = 0; i <= requiredlength; i++)
                {
                    int r = rnd.Next(0, requiredlength);
                    action.Type(SearchBox, i.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Generate Random String failed due to " + e);
                throw e;
            }
        }
    }
}