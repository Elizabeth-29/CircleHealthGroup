using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using TechTalk.SpecFlow;
using Docker.DotNet.Models;
using com.sun.tools.javap;

namespace CircleHealthGroup.Utilities
{
    [Binding]
    public class Hooks1
    {
        public static IWebDriver driver;

        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}


