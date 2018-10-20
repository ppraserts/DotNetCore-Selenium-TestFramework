using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace TestFramework
{
    public class UnitTest1
    {
        [Fact]
        public void TestSearchGoogle()
        {
            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                driver.Navigate().GoToUrl(@"https://www.google.com");
                var txtSearch = driver.FindElement(By.Id("lst-ib"));
                var btnSearch = driver.FindElement(By.Name("btnK"));
                txtSearch.SendKeys("Selenium WebDriver");
                btnSearch.Submit();
                var firstResultTitle = driver.FindElement(By.XPath("//h3[1]"));
                Assert.Equal("Selenium WebDriver", firstResultTitle.Text.Trim());
            }
        }
    }
}
