using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;

namespace LIB
{
    public class ExcelHelper
    {
        public static DataTable RenderDataTableFromExcel(Stream excelFileStream)
        {
            using (excelFileStream)
            {
                IWorkbook workbook = new HSSFWorkbook(excelFileStream);

                ISheet sheet = workbook.GetSheetAt(0);//取第一个表 

                DataTable table = new DataTable();

                IRow headerRow = sheet.GetRow(0);//第一行为标题行 
                int cellCount = headerRow.LastCellNum;//LastCellNum = PhysicalNumberOfCells 
                int rowCount = sheet.LastRowNum;//LastRowNum = PhysicalNumberOfRows - 1 

                //handling header. 
                for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                {
                    DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                    table.Columns.Add(column);
                }

                for (int i = (sheet.FirstRowNum + 1); i <= rowCount; i++)
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null)
                        break;

                    if (row != null)
                    {
                        if (row.GetCell(0) == null)
                        {
                            break;
                        }
                        if (row.GetCell(0).ToString().Trim() == "")
                        {
                            break;
                        }
                        DataRow dataRow = table.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            if (row.GetCell(j) != null)
                                dataRow[j] = row.GetCell(j).ToString();
                        }
                        table.Rows.Add(dataRow);
                    }
                }
                workbook = null;
                sheet = null;
                return table;

            }

        }
        public static DataTable RenderDataTableFromExcel2007(Stream excelFileStream)
        {
            DataTable table = new DataTable();
            try
            {
                using (excelFileStream)
                {
                    IWorkbook workbook = new XSSFWorkbook(excelFileStream);

                    ISheet sheet = workbook.GetSheetAt(0);//取第一个表 

                    IRow headerRow = sheet.GetRow(0);//第一行为标题行 
                    int cellCount = headerRow.LastCellNum;//LastCellNum = PhysicalNumberOfCells 
                    int rowCount = sheet.LastRowNum;//LastRowNum = PhysicalNumberOfRows - 1 

                    //handling header. 
                    for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                    {
                        string columnname = headerRow.GetCell(i).StringCellValue;
                        if (columnname == "")
                            continue;
                        DataColumn column = new DataColumn(columnname);
                        table.Columns.Add(column);
                    }

                    for (int i = (sheet.FirstRowNum + 1); i <= rowCount; i++)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null)
                            break;
                        if (row.FirstCellNum < 0)
                        {
                            continue;
                        }
                        else if (row.GetCell(row.FirstCellNum).ToString().Trim() == "")
                        {
                            continue;
                        }

                        DataRow dataRow = table.NewRow();

                        if (row != null)
                        {
                            for (int j = row.FirstCellNum; j < cellCount; j++)
                            {
                                if (row.GetCell(j) != null)
                                {
                                    switch (row.GetCell(j).CellType)
                                    { //空数据类型处理
                                        case CellType.Blank:
                                            dataRow[j] = "";
                                            break;
                                        case CellType.String:
                                            dataRow[j] = row.GetCell(j).StringCellValue;
                                            break;
                                        case CellType.Numeric: //数字类型  
                                            if (HSSFDateUtil.IsCellDateFormatted(row.GetCell(j)))
                                            {
                                                dataRow[j] = row.GetCell(j).DateCellValue;
                                            }
                                            else
                                            {
                                                dataRow[j] = row.GetCell(j).NumericCellValue;
                                            }
                                            break;
                                        case CellType.Formula:
                                            dataRow[j] = row.GetCell(j).NumericCellValue;
                                            break;
                                        default:
                                            dataRow[j] = "";
                                            break;
                                    }
                                }
                            }
                        }

                        table.Rows.Add(dataRow);
                    }
                    workbook = null;
                    sheet = null;
                    return table;

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }
        //读取本地文件Excel的标题
        public static DataTable RenderDataTableFormExcelHeader2007(string filePath)
        {

            DataTable table = new DataTable();
            try
            {
                IWorkbook workbook;
                using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    workbook = new XSSFWorkbook(file);
                }

                ISheet sheet = workbook.GetSheetAt(0);//取第一个表 

                IRow headerRow = sheet.GetRow(0);//第一行为标题行 
                int cellCount = headerRow.LastCellNum;//LastCellNum = PhysicalNumberOfCells 
                int rowCount = sheet.LastRowNum;//LastRowNum = PhysicalNumberOfRows - 1 

                for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                {
                    string colName = headerRow.GetCell(i).StringCellValue;
                    if (colName == "")
                        continue;
                    DataColumn column = new DataColumn(colName);
                    table.Columns.Add(column);
                }

                for (int i = 1; i <= 1; i++)
                {
                    IRow row = sheet.GetRow(i);
                    DataRow dataRow = table.NewRow();

                    if (row != null)
                    {
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            if (row.GetCell(j) != null)
                                dataRow[j] = "";
                        }
                    }

                    table.Rows.Add(dataRow);
                }

                workbook = null;
                sheet = null;
                return table;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }
    }
}
