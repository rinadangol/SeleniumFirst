using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;

namespace SeleniumFirst
{
    class PageObjectTest
    {
        public PageObjectTest()
            {
            PageFactory.InitElements(PropertiesCollection.driver, this);
            }

        [FindsBy(How = How.ClassName, Using = "form-select")]
        public IWebElement DropDownFormSelect { get; set; }

        //[FindsBy(How = How.Id, Using = "search-query")]
        //public IWebElement SearchQuery { get; set; }

        IWebElement SearchQuery => PropertiesCollection.driver.FindElement(By.Id("search-query"));

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-secondary']")]
        public IWebElement SearchBtn { get; set; }

        public void FilterResultList(string dropdownItem, string itemName)
        {
            SearchQuery.EnterText(itemName);
            DropDownFormSelect.SelectDropDown(dropdownItem);
            SearchBtn.Clicks();         
            //SeleniumSetMethods.EnterText(SearchQuery, "hammer");
           // SeleniumSetMethods.SelectDropDown(DropDownFormSelect, "Name (A - Z)");
            //SeleniumSetMethods.Click(SearchBtn);
        }
    }
}
