using System;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using CHREnhancements.PageObject.InstantImpact.Projects;

namespace CHREnhancements.PageObject.InstantImpact.ItemSearchPage
{
    class POS_On_Demand : Base
    {
        public static By MyProject
        { get { return (By.XPath("//*[@href='/Account/MyProjectsPage.aspx']")); } }

        public static By AnyTemplate
        { get { return (By.XPath("//*[@href='/POS/ItemDetails.aspx?tid=130725']")); } }

        public static By CreateYourDesign
        { get { return (By.XPath("//*[@id='Body_btnProductDesign']")); } }

        public static By SearchTemplate
        { get { return (By.XPath("//*[@id='Body_txtSearch']")); } }

        public static By PosOnDemandHeader
        { get { return (By.XPath("//*[@class='fullConfig itemConfigPage']/h1")); } }

        public static By Back
        { get { return (By.XPath("//*[@id='Body_lnkBack']")); } }

        public static By TemplateIdInTemplatePage
        { get { return (By.XPath("//*[text()='Template # 114916']")); } }

        public static By TemplateName
        { get { return (By.XPath("//*[text()='Ketel One F18 Flow Portrait']")); } }

        public static By SearchField
        { get { return (By.XPath("//*[@id='Body_txtSearch']")); } }

        public static By SearchButton
        { get { return (By.XPath("//*[@id='ctl00_Body_btnSearch']")); } }

        public static By TemplateNameInTemplatePage
        { get { return (By.XPath("//*[text()='Ketel One F18 Flow Portrait']")); } }

        public static By NoOfTemplate
        { get { return (By.XPath("//*[@id='Body_lblItemCount']/b")); } }

        public static By Postemplate
        { get { return (By.XPath("//*[(@target='_self') and contains(text(),'POS Templates')]")); } }

        Interactions action;
        public POS_On_Demand(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
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

        //Verify Item Search Page
        public void VerifyItemSearchPage()
        {
            try
            {
                action.VerifyCurrentPage("Item Search Page", "ItemSearch.aspx");
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify Item Search Page failed due to " + e);
            }
        }

        public static string substring_templatename = null;
        //Search Template Name in search Bar
        public void SearchByTemplateName()
        {
            ProjectsPage proj = new ProjectsPage(Driver);
            try
            {
                string substring_templatename = proj.GetTemplateName();
                Console.WriteLine("Template name is " + substring_templatename);

            }
            catch (Exception e)
            {
                Console.WriteLine("Searc by template name failed due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }
        //Click on any Template
        public void SelectTemplate(string templateid)
        {
            try
            {
                action.Type(SearchField, templateid);
                action.Type(SearchField, Keys.Enter);
                action.WaitTime(5);
                action.Click(SearchButton);
                action.WaitTime(5);
                action.WaitVisible(AnyTemplate);
                action.Click(AnyTemplate);           
            }
            catch (Exception e)
            {
                Console.WriteLine("Pos on demand failed due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Select only Template
        public void SelectOnlyTemplate()
        {
            try
            {
                action.ScrollToViewElement(AnyTemplate);
                action.Click(AnyTemplate);
            }
            catch (Exception e)
            {
                Console.WriteLine("Select onle template failed due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        public string templatename;
        //Get Template Name from template Name
        public void GetTemplateName()
        {
            try
            {
                action.WaitTime(10);
                action.WaitVisible(TemplateNameInTemplatePage);
                string templatename = action.GetText(TemplateNameInTemplatePage);
                Console.WriteLine("Template name is " + templatename);
                action.Back();
                action.WaitVisible(SearchField);
                action.Type(SearchField,templatename);
                action.Click(SearchButton);
            }
            catch(Exception e)
            {
                Console.WriteLine("Get Template Name failed due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Capture Template Name
        public void CaptureTemplateName()
        {
            try
            {
                action.WaitVisible(TemplateName);
                string templatename=action.GetText(TemplateName);
                Console.WriteLine("Captured template name is " + templatename);
                string[] substring_templatenames = templatename.Split(' ');
                substring_templatename = substring_templatenames[0];
                Console.WriteLine("Substring template name is " + substring_templatename);
            }
            catch (Exception e)
            {
                Console.WriteLine("Capture template name failed due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Capture Template Name
        public void SearchTemplateSubstring()
        {
            try
            {
                action.WaitVisible(SearchField);
                action.Type(SearchField,substring_templatename);
                action.Click(SearchButton);
            }
            catch (Exception e)
            {
                Console.WriteLine("Search template substring failed due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Click on CreateYourDesign Click
        public void ClickOnCreateYourDesign()
        {
            try
            {
                action.ScrollToViewElement(CreateYourDesign);
                action.WaitVisible(CreateYourDesign);
                action.Click(CreateYourDesign);
            }
            catch (Exception e)
            {
                Console.WriteLine("Click on Create Your Design failed due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Click on Back
        public void ClickOnBack()
        {
            try
            {
                action.ScrollToViewElement(Back);
                action.WaitVisible(Back);
                action.Click(Back);
            }
            catch (Exception e)
            {
                Console.WriteLine("Click on back failed due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Verify Pos On Demand
        public void VerifyPosOnDemand()
        {
            try
            {
                action.WaitForPageToLoad();
                action.WaitVisible(PosOnDemandHeader);
            }
            catch(Exception e)
            {
                Console.WriteLine("Pos on demand failed due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Verify Template-Id In Template From Pos
        public string GetTemplateId()
        {
            try
            {
                string templateid = action.GetText(TemplateIdInTemplatePage);
                Console.WriteLine("Original Template id in pos " + templateid);
                return templateid;
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify Template id in Create Design Page failed due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Verify Text Search Comming Correctly
        public void VerifySearch()
        {
            try
            {
                action.Type(SearchField, "July");
                action.Click(SearchButton);
                string nooftemplateusingjuly = action.GetText(NoOfTemplate);
                Console.WriteLine("Search result of template using july " + nooftemplateusingjuly);
                action.Clear(SearchField);
                action.WaitTime(5);
                action.Type(SearchField, "March");
                action.Click(SearchButton);
                string nooftemplateusingmarch = action.GetText(NoOfTemplate);
                Console.WriteLine("Search result of template using march " + nooftemplateusingmarch);
                action.Clear(SearchField);
                action.WaitTime(5);
                action.Type(SearchField, "MarchJuly");
                action.Click(SearchButton);
                string nooftemplateusingmarchjuly = action.GetText(NoOfTemplate);
                Console.WriteLine("Search result of template using march " + nooftemplateusingmarchjuly);
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify Search failed due to " + e);
                throw e;
            }
        }
    }
}
