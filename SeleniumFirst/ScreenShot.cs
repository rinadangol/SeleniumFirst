using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFirst
{
    public class ScreenShot
    {
        public RemoteWebDriver Driver { get; set; }

        //public static void TakeSnapShot(WebDriver driver, String fileWithPath) throws Exception

        public MediaEntityModelProvider CaptureScreenShotAndReturnModel(string Name)
        {
            var screenShot = ((ITakesScreenshot)Driver).GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenShot).Build();
        }
    }
}
