using ExcelDataReader;
using OpenQA.Selenium.DevTools.V121.CSS;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFirst
{
   class ExcelLib
    {
        public static  DataTable ExcelToDataTable(string fileName)
        {
            FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            //excelReader.IsFirstRowAsColumnNames = true;
            using(var rdr = ExcelReaderFactory.CreateOpenXmlReader(stream))
            {
                var conf = new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                };
                var ds = rdr.AsDataSet(conf);
                DataTableCollection table = ds.Tables;
                DataTable resultTable = table["Sheet1"];
                return resultTable;
            }
            
  
            
            //DataSet result = excelReader.AsDataSet();
           // DataTableCollection table = result.Tables;
            //DataTable resultTable = table["Sheet1"];
            //return resultTable;

        }

        static List<DataCollection> dataCol = new List<DataCollection> ();

        public static void  PopulateInCollection(string fileName)    
        {
            DataTable table = ExcelToDataTable(fileName);
            for (int row =1; row <= table.Rows.Count; row++)
            {
                for(int col=0;col<table.Columns.Count; col++)
                {
                    DataCollection dtTable = new DataCollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                        
                    };
                    string x = dtTable.colValue;
                    
                    dataCol.Add(dtTable);
                }
            }
        }

        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                string data = (from colData in dataCol
                               where colData.colName == columnName && colData.rowNumber == rowNumber
                               select colData.colValue).SingleOrDefault();
                return data.ToString();

            }
            catch(Exception ex)
            {
                return null;
            }
        }


    }
    public class DataCollection
    {
        public int rowNumber { get; set; }
        public string colName { get; set; }
        public string colValue { get; set; }

    }
}
