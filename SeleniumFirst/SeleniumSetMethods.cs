using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;

namespace SeleniumFirst
{
    public static class SeleniumSetMethods
    {
        /// <summary>
        /// 
        /// enter text
        /// </summary>
        /// <param name=""></param>
        /// <param name="value"></param>
        public static void EnterText(this IWebElement element, string value)
        {
            element.SendKeys(value);
        }
        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="element"></param>

        public static void Clicks(this IWebElement element)
        {
            element.Click();
        }

        public static void SelectDropDown(this IWebElement element, string value)
        {
           
                new SelectElement(element).SelectByText(value);
           
        }

        public static void SelectCheckBox(this IWebElement element, string value)
        {
            
                new SelectElement(element).SelectByText(value);
            
        }
    }
}
