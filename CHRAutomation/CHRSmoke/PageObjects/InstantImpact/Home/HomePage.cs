using System;
using System.Collections.Generic;
using CHRSmoke.Initiate;
using CHRSmoke.Interaction;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace CHRSmoke.PageObjects.InstantImpact.Home
{
    public class HomePage : Base
    {
        public By lstPrimaryMenu { get { return By.XPath("//div[@id='ctl00_RadMenu1']/ul/li/a/span[1]"); } }
        public By lstSubMenu { get { return By.XPath("//div[@id='ctl00_RadMenu1']/ul/li/div/ul/li/a/span"); } }
        public By imgPOSTemplates { get { return By.XPath("//a[(@target='_self') and contains(text(),'POS Templates')]"); } }
        public By lnkLougout { get { return By.XPath("//*[@id='lbLogout']"); } }
        public By lstMenu { get { return By.XPath("//div[@id='ctl00_RadMenu1']/ul/li"); } }


        IWebDriver Driver;
        public HomePage(IWebDriver Driver)
        {
            this.Driver = Driver;
            //PageFactory.InitElements(Driver, this);
        }

        public void SelectMenu(string MenuName)
        {
            Interactions action = new Interactions(Driver);
            try
            {
                string MenuNameUpper = MenuName.ToString().ToUpper();
                IList<IWebElement> lstMenus = action.GetElements(lstMenu);
                for (int i = 0; i < lstMenus.Count; i++)
                {
                    if (lstMenus[i].Text.ToString().ToUpper().Equals(MenuNameUpper))
                    {
                        lstMenus[i].Click();
                        action.WaitForPageToLoad(60);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Menu selection method failed Error : " + e);
                throw e;
            }
        }

        //select menu
        public void SelectMenuAndSubMenu(string MenuName, string SubMenu)
        {
            Interactions action = new Interactions(Driver);
            try
            {
                // IList<IWebElement> lstPrimaryMenu = action.GetElements(obj_InstantImpact.lstPrimaryMenu);

                IList<IWebElement> lstPrimaryMenus = action.GetElements(lstPrimaryMenu);
                for (int i = 0; i < lstPrimaryMenus.Count; i++)
                {
                    IList<IWebElement> lstPrimaryMenuss = action.GetElements(lstPrimaryMenu);

                    if (lstPrimaryMenus[i].Text.ToString().ToUpper().Equals(MenuName.ToUpper()))
                    {
                        action.HoverByJavaScript(lstPrimaryMenus[i]);
                        if (action.IsElementPresent(lstSubMenu))
                        {
                            SelectSubMenu(SubMenu);
                        }
                        else
                        {
                            lstPrimaryMenus[i].Click();
                        }
                        action.WaitForPageToLoad();
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("SelectMenuAndSubMenu method failed due to " + e);
                throw e;
            }
        }

        public void SelectSubMenu(string SubMenuName)
        {
            Interactions action = new Interactions(Driver);
            //IList<IWebElement> lstSubMenu = action.GetElements(obj_InstantImpact.lstSubMenu);
            try
            {
                IList<IWebElement> lstSubMenus = action.GetElements(lstSubMenu);
                action.WaitVisible(lstSubMenu);
                for (int i = 0; i < lstSubMenus.Count; i++)
                {
                    IList<IWebElement> lstSubMenuss = action.GetElements(lstSubMenu);
                    if (lstSubMenus[i].Text.ToString().ToUpper().Contains(SubMenuName.ToString().ToUpper()))
                    {
                        lstSubMenus[i].Click();
                        action.WaitForPageToLoad(60);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("SelectSubMenu method failed due to " +e);
                throw e;
            }
        }

        public void SelectMenuType(string DropDown)
        {
            try
            {
                Interactions action = new Interactions(Driver);
                if (DropDown.ToUpper().Contains("DROPDOWN"))
                {
                    SelectMenuAndSubMenu("POS ON DEMAND", "POS Templates");
                }
                else
                {
                    action.WaitVisible(imgPOSTemplates);
                    action.Click(imgPOSTemplates);
                    action.WaitForPageToLoad();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("SelectMenuType method failed due to " +e);
                throw e;
            }
            
        }

        //Logout
        public void Logout()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                // obj_InstantImpact.lnkLougout.ScrollToViewElement();            
                action.WaitTime(2);
                action.Click(lnkLougout);
                action.WaitTime(2);
                //Console.WriteLine("Logout method executed");
            }
            catch(Exception e)
            {
                Console.WriteLine("Logout method failed due to "+e);
                Console.WriteLine(e);
            }
        }
    }
}