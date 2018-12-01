using System.Collections.Generic;
using System.IO;
using CHREnhancements.Initiate;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;
using System;

namespace CHREnhancements.Interaction
{
    public class Interactions : Base
    {

        public Interactions(IWebDriver Driver)
        {
            this.Driver = Driver;
        }

        #region WAIT
        //Wait for element exists
        public void WaitExists(By by, int timeOut = 300)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOut)).Until(ExpectedConditions.ElementExists(by));
        }
        //Wait for element to be visible
        public void WaitVisible(By by, int timeOut = 300)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOut)).Until(ExpectedConditions.ElementIsVisible(by));
       }
        public bool IsWaitVisible(By by, int timeOut = 300)
        {
            try
            {
                new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOut)).Until(ExpectedConditions.ElementIsVisible(by));
                return true;
            }
            catch
            {
                // do not need to catch exception
                return false;
            }
        }
        public void WaitWhileNotVisible(By by)
        {
            var stillExists = true;
            while (stillExists)
            {
                try
                {
                    WaitVisible(by, 1);
                }
                catch
                {
                    stillExists = false;
                }
            }
        }
        //Hard coded wait
        public void WaitTime(int seconds)
        {
            try { seconds = seconds * 1000; } catch { seconds = 1000; }
            Thread.Sleep(seconds);
        }
        //This will wait till the page to be loaded with deafault time
        public void WaitForPageToLoad()
        {

            IWait<IWebDriver> wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30.00));
            wait.Until(driver1 => ((IJavaScriptExecutor)Driver).ExecuteScript("return document.readyState").Equals("complete"));
        }
        //This will wait till the page to be loaded with customizable time
        public void WaitForPageToLoad(int timeinsec)
        {
            IWait<IWebDriver> wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeinsec + .00));
            wait.Until(driver1 => ((IJavaScriptExecutor)Driver).ExecuteScript("return document.readyState").Equals("complete"));

        }
        //This will wait until elemnet is clickable
        public IWebElement WaitUntilElementClickable(IWebElement element, int timeout)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element : '" + element + "' was not found in current context page.");
                throw;
            }
        }
        //This will wait for the timeout for element to be unattched from DOM
        public bool WaitUntilStalenessOfElement(IWebElement element, int timeinsec)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeinsec));
                return wait.Until(ExpectedConditions.StalenessOf(element));
            }
            catch
            {
                Console.WriteLine("Element is still not attached to current DOM");
                return false;
            }
        }
        #endregion

        #region ALERTS
        //Accept Alert
        public bool AcceptAlert()
        {
            try
            {
                IAlert alert = Driver.SwitchTo().Alert();
                alert.Accept();
                Console.Out.WriteLine("Alert Was Present");
                return true;
            }
            catch
            {
                Console.Out.WriteLine("No Alert Found");
                return false;
            }
        }

        //Dismiss Alert
        public bool DismissAlert()
        {
            try
            {
                IAlert alert = Driver.SwitchTo().Alert();
                alert.Dismiss();
                Console.Out.WriteLine("Alert Was Present");
                return true;
            }
            catch
            {
                Console.Out.WriteLine("No Alert Found");
                return false;
            }
        }

        //Retieves the text present in the Alert pop up
        public string GetAlertText()
        {
            try
            {
                IAlert alert = Driver.SwitchTo().Alert();
                var text = alert.Text.ToString();
                Console.Out.WriteLine("Alert Was Present");
                return text;
            }
            catch
            {
                Console.Out.WriteLine("No Alert Found");
                return null;
            }
        }

        #endregion

        #region TAKE SCREEN SHOT
        public void TakeScreenshots(string FunctionalityName)
        {
            try
            {
                string Dir = Path.GetDirectoryName(typeof(Base).Assembly.Location);
                Screenshot screenshot = Driver.TakeScreenshot();
                string filename_spclchar = FunctionalityName + DateTime.Now.ToString();
                Console.WriteLine(filename_spclchar);
                string filename = filename_spclchar.Replace("-", " ");
                string fullfilename = filename.Replace(":", " ");
                Console.WriteLine(fullfilename);
                screenshot.SaveAsFile(Dir + @"\Screenshots" + fullfilename + ".png", ScreenshotImageFormat.Png);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Failed to take to take screen shot due to " + e);
            }
        }
        #endregion

        #region CHECKBOX

        public void Check(By by)
        {
            if (!Driver.FindElement(by).Selected)
            {
                Driver.FindElement(by).Click();
            }

        }
        public void Check(By by, int timeinsecs)
        {

            WaitTime(timeinsecs);
            if (!Driver.FindElement(by).Selected)
            {
                Driver.FindElement(by).Click();
            }
        }
        public void CheckJavaScript(By by)
        {
            if (!Driver.FindElement(by).Selected)
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
                executor.ExecuteScript("arguments[0].click();", by);
            }

        }
        public void CheckJavaScript(By by, int timeinsecs)
        {
            if (!Driver.FindElement(by).Selected)
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
                executor.ExecuteScript("arguments[0].click();", by);
            }
        }
        public void Uncheck(By by)
        {
            if (Driver.FindElement(by).Selected)
            {
                Driver.FindElement(by).Click();
            }

        }
        public void Uncheck(By by, int timeinsecs)
        {
            if (Driver.FindElement(by).Selected)
            {
                Driver.FindElement(by).Click();
            }
        }
        public void UncheckJavaScript(By by)
        {
            if (Driver.FindElement(by).Selected)
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
                executor.ExecuteScript("arguments[0].click();", by);
            }

        }
        public void UncheckJavaScript(By by, int timeinsecs)
        {
            if (Driver.FindElement(by).Selected)
            {

                IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
                executor.ExecuteScript("arguments[0].click();", by);
            }
        }
        #endregion

        #region CLICK
        //Click
        public void Click(By by)
        {
            Driver.FindElement(by).Click();
        }
        //Click and wait
        public void Click(By by, int timeinsecs)
        {
            WaitTime(timeinsecs);
            Driver.FindElement(by).Click();
        }
        //Do click and wait
        public void ClickAndWait(By by, int timetowaitinsec)
        {
            Driver.FindElement(by).Click();
            WaitTime(timetowaitinsec);
        }
        //Double click
        public void DoubleClick(By by)
        {
            IWebElement element = Driver.FindElement(by);
            Actions action = new Actions(Driver);
            action.MoveToElement(element);
            action.DoubleClick();
            action.Build().Perform();
            WaitTime(4);
        }
        //Click and wait for page load
        public void ClickAndWaitForPageLoad(By elementLocator, int timeinsec)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeinsec));
                var element = Driver.FindElement(elementLocator);
                element.Click();
                wait.Until(ExpectedConditions.StalenessOf(element));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }
        //Do MouseHover on any element
        public void MouseOverOnElement(By Hoverby)
        {
            IWebElement elementToHover = Driver.FindElement(Hoverby);
            Actions hover = new Actions(Driver);
            hover.MoveToElement(elementToHover);
            hover.Perform();
        }
        //do MouseHover on any element and click
        public void MouseHoverAndClick(By Hoverby, By ClickBy)
        {
            IWebElement elementToHover = Driver.FindElement(Hoverby);
            Actions hover = new Actions(Driver);
            hover.MoveToElement(elementToHover);
            hover.Perform();
            Click(ClickBy);
        }
        //Mouse hover and click with wait time
        public void MouseHoverAndClick(By Hoverby, By ClickBy, int timeinsecs)
        {
            IWebElement elementToHover = Driver.FindElement(Hoverby);
            Actions hover = new Actions(Driver);
            hover.MoveToElement(elementToHover);
            hover.Perform();
            Click(ClickBy);
        }
        //Mouse Hover and click
        public void MouseHoverAndClick(By by)
        {
            IWebElement elementToHover = Driver.FindElement(by);
            Actions hover = new Actions(Driver);
            hover.MoveToElement(elementToHover);
            hover.Perform();
            Click(by);
        }
        //Mouse hove and click
        public void MouseHoverAndHoverClick(By by, int timeinsecs)
        {
            IWebElement elementToHover = Driver.FindElement(by);
            Actions hover = new Actions(Driver);
            hover.MoveToElement(elementToHover);
            hover.Perform();
            Click(by);
        }
        //Click with JavaScripts
        public void ClickJavaScript(By by)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("arguments[0].click();", by);
        }
        //Click with JavaSctipts
        public void ClickJavaScript(By by, int timeinsecs)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("arguments[0].click();", by);
        }

        #endregion

        #region ELEMENT
        //Get single element
        public IWebElement GetElement(By by)
        {
            return Driver.FindElement(by);
        }
        //Get single element
        public IWebElement GetElement(By by, int waittimeinsecs)
        {
            return Driver.FindElement(by);
        }
        //Get Multiple elements
        public IList<IWebElement> GetElements(By by)
        {
            return Driver.FindElements(by);
        }

        public IList<IWebElement> GetElements(By by, int waittimeinsecs)
        {
            return Driver.FindElements(by);
        }
        //Check element is displayed or not
        public bool IsElementDisplayed(By by)
        {
            try
            {
                bool displayed = Driver.FindElement(by).Displayed;
                return displayed;
            }
            catch
            {
                throw new Exception("ELEMENTNOTDISPLAYED");
                // throw new System.Exception("ELEMENTNOTDISPLAYED");
            }
        }
        // Element is enabled or not
        public bool IsElementEnabled(By by)
        {
            try
            {
                bool enabled = Driver.FindElement(by).Enabled;
                return enabled;
            }
            catch
            {
                throw new Exception("ELEMENTNOTENABLED");
            }
        }
        //Element is selected or not
        public bool IsElementSelected(By by)
        {
            try
            {
                bool selected = Driver.FindElement(by).Selected;
                return selected;
            }
            catch
            {
                throw new Exception("ELEMENTNOTSELECTED");
            }
        }
        //Check input box is empty or not
        public bool IsInputBoxEmpty(By by)
        {
            string textvalue = Driver.FindElement(by).GetAttribute("value");
            if (textvalue.Length == 0)
            { return true; }
            else return false;
        }
        //Check list is em[ty or not
        public bool IsListEmpty(By by)
        {
            IWebElement element = Driver.FindElement(by);
            SelectElement listBox = new SelectElement(element);
            IList<IWebElement> listOptions = listBox.Options;
            if (listOptions.Count > 0)
            { return false; }
            return true;
        }

        #endregion

        #region EXIST
        public bool IsElementPresent(By by)
        {
            try
            {
                Driver.FindElement(by);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IsElementPresent(By by, int waittimeinsecs)
        {
            try
            {
                WaitTime(waittimeinsecs);
                Driver.FindElement(by);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region GET

        //Get visible text
        public string GetText(By by)
        {
            return Driver.FindElement(by).Text;
        }
        //Get visible text
        public string GetText(By by, int waittimeinsec)
        {
            WaitTime(waittimeinsec);
            return Driver.FindElement(by).Text;
        }
        public void WindowHandle()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            WaitTime(15);
            Driver.Close();
            Driver.SwitchTo().Window(Driver.WindowHandles.First());
        }
        public string GetCurrentUrl()
        {
            return Driver.Url;
        }
        public string GetTextJavaScript(By by)
        {
            return ((IJavaScriptExecutor)Driver).ExecuteScript("return $(arguments[0]).text();", Driver.FindElement(by)).ToString();
        }
        public string GetTextJavaScript(By by, int timeinsec)
        {
            Driver.FindElement(by).Click();
            WaitExists(by);
            return ((IJavaScriptExecutor)Driver).ExecuteScript("return $(arguments[0]).text();", Driver.FindElement(by)).ToString();
        }
        public string GetAttribute(By by, string value)
        {
            return Driver.FindElement(by).GetAttribute(value);
        }

        #endregion

        #region NAVIGATION

        public void GoToURL(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }
        public void Back()
        {
            Driver.Navigate().Back();
        }
        public void Refresh()
        {
            Driver.Navigate().Refresh();
        }
        public void ScrollBy(int scroll)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript(" window.scrollBy(0, scroll);");

        }
        public string GetCurrentURL()
        {
            return Driver.Url;
        }
        #endregion

        #region RANDOM STRING GENERATOR

        //It will generate random string with given length
        public string StringGenerator(int requiredlength)
        {
            Random random = new Random();
            var chars = "ABCDEF";
            var result = new string(
                Enumerable.Repeat(chars, requiredlength)
                          .Select(s => s[random.Next(s.Length)])
                  .ToArray());

            return result;
        }

        #endregion

        #region SCROLL

        //Scroll upto element to be visible
        public void ScrollToViewElement(By by)
        {
            IWebElement element = Driver.FindElement(by);
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        //Scroll up to element to be visible
        public void ScrollToViewElement(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("arguments[0].scrolSlIntoView(true);", element);
        }
        //Scroll upto element to be visible
        public void ScrollToViewelement(By by)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("arguments[0].scrolSlIntoView(true);", by);
        }
        //Scroll to bottom of page
        public void ScrollToBottomOfPage()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollTo(0, document.body.clientHeight);");
        }
        //Scroll to top of page
        public void ScrollToTopOgPage()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollTo(0, 0)");
        }

        #endregion

        #region SELECT

        //Select By Text from Dropdown
        public void SelectByText(By by, string text)
        {
            new SelectElement(Driver.FindElement(by)).SelectByText(text);
        }
        //Select By Text from Drop down
        public void SelectByText(By by, string text, int timeinsec)
        {
            WaitExists(by, timeinsec);
            new SelectElement(Driver.FindElement(by)).SelectByText(text);
        }
        //Select By Value from Drop down
        public void SelectByValue(By by, string value)
        {
            new SelectElement(Driver.FindElement(by)).SelectByValue(value);
        }
        //Select By Value from Drop down
        public void SelectByValue(By by, string value, int timeinsec)
        {
            WaitExists(by, timeinsec);
            new SelectElement(Driver.FindElement(by)).SelectByValue(value);
        }
        //Select by Index from drop down
        public void SelectByIndex(By by, int index)
        {
            new SelectElement(Driver.FindElement(by)).SelectByIndex(index);
        }
        public void SelectByIndex(By by, int index, int timeinsec)
        {
            WaitExists(by, timeinsec);
            new SelectElement(Driver.FindElement(by)).SelectByIndex(index);
        }
        //Get selected options
        public string GetSelectedOption(By by)
        {
            string text = new SelectElement(Driver.FindElement(by)).SelectedOption.GetAttribute("text").ToString();
            return text;
        }
        //Returns all available options of dropdown list or ListBox as string separated by COMMA
        public string GetAvailableOptions(By by)
        {
            IWebElement element = Driver.FindElement(by);
            SelectElement select = new SelectElement(element);
            IList<IWebElement> allOptions = select.Options;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < allOptions.Count; i++)
            {
                if (allOptions.Count == 1)
                {
                    sb = sb.Append(allOptions[i].Text.Trim());
                    break;
                }
                else if (i == allOptions.Count - 1)
                {
                    sb = sb.Append(allOptions[i].Text.Trim());
                }
                else
                {
                    sb = sb.Append(allOptions[i].Text.Trim() + ",");
                }
            }
            string options = sb.ToString();
            return options;
        }
        //Verify Selected Option
        public bool VerifySelectedOption(By by, string text)
        {
            IList<IWebElement> moptions = new SelectElement(Driver.FindElement(by)).Options;
            foreach (IWebElement opt in moptions)
            {
                if (text.Contains(opt.Text))
                {
                    break;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        //get all options available from drop down
        public IList<string> GetAllOptions(By by)
        {
            IList<IWebElement> moptions = new SelectElement(Driver.FindElement(by)).Options;
            List<string> v = new List<string>();
            for (int i = 0; i <= moptions.Count - 1; i++)
            {
                v.Add(moptions[i].Text.ToString().Trim());
            }
            return v;
        }
        #endregion

        #region SENDKEYS

        public void Type(By by, string value)
        {
            Driver.FindElement(by).SendKeys(value);
        }
        public void Type(By by, string value, int waittimeinsecs)
        {
            WaitTime(waittimeinsecs);
            Driver.FindElement(by).SendKeys(value);
        }
        public void Clear(By by)
        {
            Driver.FindElement(by).Clear();
        }
        public void Clear(By by, int waittimeinsecs)
        {
            Driver.FindElement(by).Clear();
        }
        public void TypeClear(By by, string value)
        {
            var element = Driver.FindElement(by);
            element.Clear();
            element.SendKeys(value);
        }
        //Clear field
        public void TypeClear(By by, string value, int waittimeinsecs)
        {
            var element = Driver.FindElement(by);
            element.Clear();
            element.SendKeys(value);
        }
        //Ctrl+C and type
        public void SelectTextAndType(By by, string value)
        {
            Driver.FindElement(by).SendKeys(Keys.Control + "a");
            Driver.FindElement(by).SendKeys(value);
        }
        //Ctrl+C
        public void CopyData(By by)
        {
            Driver.FindElement(by).SendKeys(Keys.Control + "a");
            Driver.FindElement(by).SendKeys(Keys.Control + "c");
        }
        //Ctrl+V
        public void PasteData(By by)
        {
            Driver.FindElement(by).SendKeys(Keys.Control + "v");
        }

        #endregion

        #region VERIFY PAGE



        // It will verify the page with expected page name
        public void VerifyCurrentPage(string pagename, string expectedpagename)
        {
            try
            {
                string act_currenturl = Driver.Url;
                if (act_currenturl.Contains(expectedpagename))
                {
                    Console.WriteLine(pagename + "page verified successfully.");
                }
                else
                {
                    Assert.Fail();
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Failed to verify current page due to " + e);
            }
        }

        //Verify Title
        public void VerifyTitle(string title, int timeinsec)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeinsec));
            wait.Until(ExpectedConditions.TitleContains(title));
        }

        public void VerifyTitle(string title)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.TitleContains(title));
        }

        #endregion

    }
}



