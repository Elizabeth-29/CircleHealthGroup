using CircleHealthGroup.Utilities;
using Docker.DotNet.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircleHealthGroup.PageObject
{
    internal class KneeReplacementAppointment
    {
        
        public KneeReplacementAppointment()
        {
            driver = Hooks1.driver;
          
        }
        IWebDriver driver;
        IWebElement CookiesPopup => driver.FindElement(By.XPath("//*[@id=\"CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll\"]"));
        IWebElement BookAppointment => driver.FindElement(By.XPath("/html/body/header/div/nav/div[1]/div[1]/div[1]/a[3]/span/span[3]"));
        IWebElement TreatmentType => driver.FindElement(By.XPath("//*[@id=\"treatment\"]"));
        IWebElement Location => driver.FindElement(By.XPath("//*[@id=\"location\"]"));
        IWebElement Search => driver.FindElement(By.XPath("//*[@id=\"digital-doorway\"]/div[2]/div/form/div/button"));
        IWebElement SelectDate => driver.FindElement(By.CssSelector("#datepicker > div:nth-child(1) > div > div.vc-pane-container > div.vc-pane-layout > div > div.vc-weeks > div.vc-day.id-2023-10-13.day-13.day-from-end-19.weekday-6.weekday-position-5.weekday-ordinal-2.weekday-ordinal-from-end-3.week-3.week-from-end-4.in-month.vc-day-box-center-center"));
        IWebElement ConsultantsResult => driver.FindElement(By.XPath("//*[@id=\"digital-doorway\"]/div[3]/div/div/div/div[2]/div[1]"));

        

        //Methods
        public void NavigateToWebsite()
        {
            driver.Navigate().GoToUrl("https://www.circlehealthgroup.co.uk/");
        }

        public void ClickOnCookiesPopup()
        {
            CookiesPopup.Click();
        }
        public void ClickOnBookAppointment()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2))
            {
                PollingInterval = TimeSpan.FromMilliseconds(300),
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            //wait.IgnoreExceptionTypes(typeof(ElementNotInteractableException));
            
            wait.Until(d => {
                
                BookAppointment.Click();
                return true;
            });
          
        }
        public void EnterTreatmentType(string treatmenttype)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2))
            {
                PollingInterval = TimeSpan.FromMilliseconds(300),
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            TreatmentType.SendKeys(treatmenttype);
            wait.Until(d => {
                IWebElement dropdown = driver.FindElement(By.LinkText(treatmenttype));
                dropdown.Click();
                return true;
            });

        }
        
        public void EnterLocation()
        {
            Location.SendKeys("Leicester, UK");
            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.ClassName("pac-item")).Click();

        }
        public void ClickOnSearch()
        {
            Search.Click();
        }
        public void ClickOnSelectDate()
        {
            SelectDate.Click();
        }

        public bool IsConsultantsResultDisplayed()
        {
            return ConsultantsResult.Displayed;
        }

       
    }

}
