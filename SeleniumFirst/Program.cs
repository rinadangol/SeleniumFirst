using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace SeleniumFirst
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            
      
            
        }

        [SetUp]
        public void Initialize()
        {
            PropertiesCollection.driver = new ChromeDriver();
            PropertiesCollection.driver.Navigate().GoToUrl("https://practicesoftwaretesting.com/#/");
            Console.WriteLine("Go to url");
        }

        [Test]
        public void NextTest()
        {
            Console.WriteLine("next Test");
            string ActualWebTitle = PropertiesCollection.driver.Title;
            string expectedWebTitle = "Practice Software Testing  Toolshop - v5.0";
            //bool isEqual = Assert.(ActualWebTitle, expectedWebTitle);
             //StringAssert.AreEqualIgnoringCase(ActualWebTitle, expectedWebTitle);
            bool x = AssertionResult.Equals(expectedWebTitle, ActualWebTitle);
            if(x==false)
            { 
                TakeScreenShotDefaultImageFormat();
            }
            
        }

        [Test]
        public void ExecuteTest()
        {
            PropertiesCollection.driver.Manage().Window.Maximize();
            Thread.Sleep(3000);

            ExcelLib.PopulateInCollection(@"C:\Users\rinad\OneDrive\Desktop\Rina\Data.xlsx");


            
            //initiallize the page by calling its reference
            PageObjectTest page = new PageObjectTest();
            //page.FilterResultList("Name (A - Z)" , "hammer");
            page.FilterResultList(ExcelLib.ReadData(1,"dropdown"), ExcelLib.ReadData(1,"searchtext"));
            /*
            page.DropDownFormSelect.SendKeys("Name (A - Z)");
            page.SearchQuery.SendKeys("hammer");
            page.SearchBtn.Click();
            */

            /*
            //drop down
            SeleniumSetMethods.SelectDropDown(PropertyType.ClassName, "form-select");
            string a = SeleniumGetMethods.GetTextDropDownList("form-select", PropertyType.ClassName);

            //enter textype
            SeleniumSetMethods.EnterText("search-query", "hammer", PropertyType.Id);
            string b = SeleniumGetMethods.GetText("search-query", PropertyType.Id);
            //string a = SeleniumGetMethods.GetText("search-query", "Id");
            //Console.WriteLine("The value from SearchTextArea is " + SeleniumGetMethods.GetText("search-query", "Id"));
            Thread.Sleep(3000);
            //click
            SeleniumSetMethods.Click("//button[@class='btn btn-secondary']", PropertyType.XPath);
            Thread.Sleep(3000);
            */
            var element = PropertiesCollection.driver.FindElement(By.XPath("//*[contains(text(),'toilet')]"));
            Actions actions = new Actions(PropertiesCollection.driver);
            actions.MoveToElement(element);
            actions.Perform();

            Thread.Sleep(3000);

            
            PropertiesCollection.driver.FindElement(By.XPath("//*[contains(text(),' ForgeFlex Tools')]")).Click();

            
           



             IList<IWebElement> list = PropertiesCollection.driver.FindElements(By.XPath("//*[@class='card-title']"));

            for (int i = 0; i < list.Count;i++)
            {
                string x = list[i].Text;
                Console.WriteLine(x);
            }

        }

        [TearDown]
        public void CleanUp()
        {
            
            PropertiesCollection.driver.Close();
            Console.WriteLine("close browser");
        }

        public void TakeScreenShotDefaultImageFormat()
        {
          
                var screenshot = ((ITakesScreenshot)PropertiesCollection.driver).GetScreenshot();

            //string Directory =             string Filename = "\\error
            int x = 1;
            string fileExtension = ".Png";
            string path = "C:\\ScreenShots\\apple";
            string completepath = "C:\\ScreenShots\\apple" + x + fileExtension;





            while (File.Exists(completepath))
            {
                x++;
                completepath = (path+x+".png");
                
            }
            screenshot.SaveAsFile(completepath);
                
               



        
        }
     
    }
}
