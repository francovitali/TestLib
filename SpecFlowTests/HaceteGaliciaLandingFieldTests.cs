using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowTests
{
    [Binding]
    public class HaceteGaliciaLandingFieldTests
    {
        private static IWebDriver webDriver;
        private const string landingUrl = "https://sacatutarjeta.bancogalicia.com.ar/landing";
        private const string nameFieldId = "Nombre";
        private const string femaleGenderFieldId = "SexoF";
        private const string valueAttributeName = "value";
        private const string checkedAttributeName = "checked";

        [BeforeFeature]
        public static void InitializeWebDriver()
        {
            webDriver = new ChromeDriver();
        }

        [AfterFeature]
        public static void CloseWebDriver()
        {
            webDriver.Close();
        }

        [Given(@"I navigate the landing")]
        public void GivenINavigateTheLanding()
        {
            webDriver.Url = landingUrl;
            webDriver.Navigate();            
        }

        [When(@"I write a number in the name field")]
        public void WhenIWriteANumberInTheNameField()
        {
            webDriver.FindElement(By.Id(nameFieldId)).SendKeys("666");
        }

        [Then(@"the field should be empty")]
        public void ThenTheFieldShouldBeEmpty()
        {
            string nameValue = webDriver.FindElement(By.Id(nameFieldId)).GetAttribute(valueAttributeName);

            Assert.AreEqual(String.Empty, nameValue);
        }

        [When(@"I write letters in the name field")]
        public void WhenIWriteLettersInTheNameField()
        {
            webDriver.FindElement(By.Id(nameFieldId)).SendKeys("Puchun");
        }

        [Then(@"the field should contain the letters")]
        public void ThenTheFieldShouldContainTheLetters()
        {
            string nameValue = webDriver.FindElement(By.Id(nameFieldId)).GetAttribute(valueAttributeName);

            Assert.AreEqual("Puchun", nameValue);
        }

        [When(@"I choose the female gender")]
        public void WhenIChooseTheFemaleGender()
        {
            webDriver
                .FindElement(By.Id(femaleGenderFieldId))
                .FindElement(By.XPath("./parent::*"))
                .Click();
        }

        [Then(@"the female gender should be checked")]
        public void ThenTheFieldShouldBeChecked()
        {
            string femaleGenderInputValue = webDriver.FindElement(By.Id(femaleGenderFieldId)).GetAttribute(checkedAttributeName);

            Assert.IsTrue(bool.Parse(femaleGenderInputValue));
        }
    }
}
