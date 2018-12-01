using System;
using System.Collections.Generic;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace CHREnhancements.PageObject.InstantImpact.HelpAndResources
{
    public class ViewFiles : Base
    {
        public static By ListOfPdf
        { get { return (By.XPath("//tbody/tr/td[1]/a")); } }

        public static By SingleLink
        { get { return (By.XPath("//*[@class='GenericLink'][1]")); } }

        Interactions action;
        public ViewFiles(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
        }
        //Verify Pdf Files
        public void VerifyFiles()
        {
            try
            {
                IList<IWebElement> files = action.GetElements(ListOfPdf);
                Console.WriteLine("Number of templates present in a page is " + files.Count);
                for (int i = 0; i < files.Count; i++)
                {
                    Console.WriteLine("Design name is " + files[i].Text);
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify files failed due to " + e);
                Driver.Quit();
                throw e;
            }
        }

        //Click on link and verify files
        public void ClickOnPdfLink()
        {
            try
            {
                action.Click(SingleLink);
            }
            catch(Exception e)
            {
                Console.WriteLine("Click on pdf links failed due to " + e);
                Driver.Quit();
                throw e;
            }
        }
    }
}
