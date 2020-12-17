
using LJZY.MODEL;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace LJZY.WEB.Common
{
    public class NPOIHelper
    {
        public static DataTable ExcelToDataTable(string filePath, bool isColumnName)
        {
            DataTable dataTable = null;
            FileStream fs = null;
            DataColumn column = null;
            DataRow dataRow = null;
            IWorkbook workbook = null;
            ISheet sheet = null;
            IRow row = null;
            ICell cell = null;
            int startRow = 0;

            try
            {
                using (fs = File.OpenRead(filePath))
                {
                    // 2007版本  
                    if (filePath.IndexOf(".xlsx") > 0)
                        workbook = new XSSFWorkbook(fs);
                    // 2003版本  
                    else if (filePath.IndexOf(".xls") > 0)
                        workbook = new HSSFWorkbook(fs);

                    if (workbook != null)
                    {
                        sheet = workbook.GetSheetAt(0); //读取第一个sheet，当然也可以循环读取每个sheet 

                        int cellCounts = sheet.GetRow(0).LastCellNum;   //设置最后一列隐藏列为不隐藏
                        sheet.SetColumnHidden(cellCounts - 1, false);

                        dataTable = new DataTable();
                        if (sheet != null)
                        {
                            int rowCount = sheet.LastRowNum;    //总行数-1  

                            // 根据第一行，构建datatable的键
                            if (rowCount > 0)
                            {
                                IRow firstRow = sheet.GetRow(0);//第一行  
                                int cellCount = firstRow.LastCellNum;//列数  

                                // 构建datatable的列  
                                if (isColumnName)
                                {
                                    startRow = 1;//如果第一行是列名，则从第二行开始读取  
                                    for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                                    {
                                        cell = firstRow.GetCell(i);
                                        if (cell != null)
                                        {
                                            if (cell.StringCellValue != null)
                                            {
                                                column = new DataColumn(cell.StringCellValue);
                                                dataTable.Columns.Add(column);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                                    {
                                        column = new DataColumn("column" + (i + 1));
                                        dataTable.Columns.Add(column);
                                    }
                                }

                                // 根据第二行之后的内容，填充行内的值  
                                for (int i = startRow; i <= rowCount; ++i)
                                {
                                    row = sheet.GetRow(i);
                                    if (row == null)
                                        continue;

                                    dataRow = dataTable.NewRow();
                                    for (int j = row.FirstCellNum; j < cellCount; ++j)
                                    {
                                        cell = row.GetCell(j);
                                        if (cell == null)
                                        {
                                            dataRow[j] = "";
                                        }
                                        else
                                        {
                                            //CellType(Unknown = -1,Numeric = 0,String = 1,Formula = 2,Blank = 3,Boolean = 4,Error = 5,)  
                                            switch (cell.CellType)
                                            {
                                                // 空
                                                case CellType.Blank:
                                                    dataRow[j] = "";
                                                    break;
                                                // 数字
                                                case CellType.Numeric:
                                                    // 日期
                                                    if (HSSFDateUtil.IsCellDateFormatted(row.GetCell(j)))
                                                    {
                                                        dataRow[j] = row.GetCell(j).DateCellValue.ToString("yyyy-MM-dd");
                                                    }
                                                    // 数字
                                                    else
                                                    {
                                                        dataRow[j] = row.GetCell(j).NumericCellValue;
                                                    }
                                                    break;
                                                // 字符串
                                                case CellType.String:
                                                    dataRow[j] = cell.StringCellValue;
                                                    break;
                                            }


                                        }
                                    }
                                    dataTable.Rows.Add(dataRow);
                                }
                            }
                        }
                    }
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                if (fs != null)
                {
                    fs.Close();
                }
                return null;
            }
        }

        /// <summary>
        /// 将excel文件内容读取到DataTable数据表中
        /// </summary>
        /// <param name="fileName">文件完整路径名</param>
        /// <param name="sheetName">指定读取excel工作薄sheet的名称</param>
        /// <param name="isFirstRowColumn">第一行是否是DataTable的列名：true=是，false=否</param>
        /// <returns>DataTable数据表</returns>
        public static DataTable ReadExcelToDataTable(string fileName, string sheetName = null, bool isFirstRowColumn = true)
        {
            //定义要返回的datatable对象
            DataTable data = new DataTable();
            //excel工作表
            NPOI.SS.UserModel.ISheet sheet = null;
            //数据开始行(排除标题行)
            int startRow = 0;
            try
            {
                if (!File.Exists(fileName))
                {
                    return null;
                }
                //根据指定路径读取文件
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                //根据文件流创建excel数据结构
                NPOI.SS.UserModel.IWorkbook workbook = NPOI.SS.UserModel.WorkbookFactory.Create(fs);
                //IWorkbook workbook = new HSSFWorkbook(fs);
                //如果有指定工作表名称
                if (!string.IsNullOrEmpty(sheetName))
                {
                    sheet = workbook.GetSheet(sheetName);
                    //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                    if (sheet == null)
                    {
                        sheet = workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    //如果没有指定的sheetName，则尝试获取第一个sheet
                    sheet = workbook.GetSheetAt(0);
                }
                if (sheet != null)
                {
                    NPOI.SS.UserModel.IRow firstRow = sheet.GetRow(0);
                    //一行最后一个cell的编号 即总的列数
                    int cellCount = firstRow.LastCellNum;
                    //如果第一行是标题列名
                    if (isFirstRowColumn)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            NPOI.SS.UserModel.ICell cell = firstRow.GetCell(i);
                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue;
                                if (cellValue != null)
                                {
                                    DataColumn column = new DataColumn(cellValue);
                                    data.Columns.Add(column);
                                }
                            }
                        }
                        startRow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;
                    }
                    //最后一列的标号
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        NPOI.SS.UserModel.IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是null　　　　　　　

                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                                dataRow[j] = row.GetCell(j).ToString();
                        }
                        data.Rows.Add(dataRow);
                    }
                }
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 将json转换为DataTable
        /// </summary>
        /// <param name="strJson">得到的json</param>
        /// <returns></returns>
        public static DataTable JsonToDataTable(string strJson)
        {
            //转换json格式
            strJson = strJson.Replace(",\"", "*\"").Replace("\":", "\"#").ToString();
            //取出表名   
            var rg = new Regex(@"(?<={)[^:]+(?=:\[)", RegexOptions.IgnoreCase);
            string strName = rg.Match(strJson).Value;
            DataTable tb = null;
            //去除表名   
            strJson = strJson.Substring(strJson.IndexOf("[") + 1);
            strJson = strJson.Substring(0, strJson.IndexOf("]"));

            //获取数据   
            rg = new Regex(@"(?<={)[^}]+(?=})");
            MatchCollection mc = rg.Matches(strJson);
            for (int i = 0; i < mc.Count; i++)
            {
                string strRow = mc[i].Value;
                string[] strRows = strRow.Split('*');

                //创建表   
                if (tb == null)
                {
                    tb = new DataTable();
                    tb.TableName = strName;
                    foreach (string str in strRows)
                    {
                        var dc = new DataColumn();
                        string[] strCell = str.Split('#');

                        if (strCell[0].Substring(0, 1) == "\"")
                        {
                            int a = strCell[0].Length;
                            dc.ColumnName = strCell[0].Substring(1, a - 2);
                        }
                        else
                        {
                            dc.ColumnName = strCell[0];
                        }
                        tb.Columns.Add(dc);
                    }
                    tb.AcceptChanges();
                }

                //增加内容   
                DataRow dr = tb.NewRow();
                for (int r = 0; r < strRows.Length; r++)
                {
                    try
                    {
                        string a = strRows[r].Split('#')[1].Trim();
                        if (a.Equals("null"))
                        {
                            dr[r] = "";
                        }
                        else
                        {
                            dr[r] = strRows[r].Split('#')[1].Trim().Replace("，", ",").Replace("：", ":").Replace("\"", "");
                        }
                    }
                    catch (Exception e)
                    {

                        throw e;
                    }
                }
                tb.Rows.Add(dr);
                tb.AcceptChanges();
            }

            try
            {
                if (tb != null)
                {
                    return tb;
                }
                else
                {
                    throw new Exception("解析错误");
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// 将json转换为DataTable
        /// </summary>
        /// <param name="strJson">得到的json</param>
        /// <returns></returns>
        public static DataTable JsonToDT(string strJson)
        {
            //转换json格式
            strJson = strJson.Replace(",\"", "*\"").Replace("\":", "\"#").ToString();
            //取出表名   
            var rg = new Regex(@"(?<={)[^:]+(?=:\[)", RegexOptions.IgnoreCase);
            string strName = rg.Match(strJson).Value;
            DataTable tb = null;
            //去除表名   
            strJson = strJson.Substring(strJson.IndexOf("[") + 1);
            strJson = strJson.Substring(0, strJson.IndexOf("]"));

            //获取数据   
            rg = new Regex(@"(?<={)[^}]+(?=})");
            MatchCollection mc = rg.Matches(strJson);
            for (int i = 0; i < mc.Count; i++)
            {
                string strRow = mc[i].Value;
                string[] strRows = strRow.Split('*');

                //创建表   
                if (tb == null)
                {
                    tb = new DataTable();
                    tb.TableName = strName;
                    foreach (string str in strRows)
                    {
                        var dc = new DataColumn();
                        string[] strCell = str.Split('#');

                        if (strCell[0].Substring(0, 1) == "\"")
                        {
                            int a = strCell[0].Length;
                            dc.ColumnName = strCell[0].Substring(1, a - 2);
                        }
                        else
                        {
                            dc.ColumnName = strCell[0];
                        }
                        tb.Columns.Add(dc);
                    }
                    tb.AcceptChanges();
                }

                //增加内容   
                DataRow dr = tb.NewRow();
                for (int r = 0; r < strRows.Length; r++)
                {
                    dr[r] = strRows[r].Split('#')[1].Trim().Replace("，", ",").Replace("：", ":").Replace("\"", "");
                }
                tb.Rows.Add(dr);
                tb.AcceptChanges();
            }

            return tb;
        }


        public static DataTable ListToTable<T>(List<T> list, bool isStoreDB = true)
        {
            Type tp = typeof(T);
            PropertyInfo[] proInfos = tp.GetProperties();
            DataTable dt = new DataTable();
            foreach (var item in proInfos)
            {
                dt.Columns.Add(item.Name, item.PropertyType); //添加列明及对应类型  
            }
            foreach (var item in list)
            {
                DataRow dr = dt.NewRow();
                foreach (var proInfo in proInfos)
                {
                    object obj = proInfo.GetValue(item, null);
                    if (obj == null)
                    {
                        continue;
                    }
                    //if (obj != null)  
                    // {  
                    if (isStoreDB && proInfo.PropertyType == typeof(DateTime) && Convert.ToDateTime(obj) < Convert.ToDateTime("1753-01-01"))
                    {
                        continue;
                    }
                    // dr[proInfo.Name] = proInfo.GetValue(item);  
                    dr[proInfo.Name] = obj;
                    // }  
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }



        /// <summary>
        /// 创建工作簿自适应格式
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="dt"></param>
        public static void CreateSheet(DataTable dt, Stream excelStream)
        {
            try
            {
                HSSFWorkbook workbook = new HSSFWorkbook();
                MemoryStream ms = new MemoryStream();

                string dtName = dt.TableName;
                //创建一个名称为Payment的工作表
                ISheet paymentSheet = workbook.CreateSheet(dtName);
                IDataFormat dataFormat = workbook.CreateDataFormat();
                ICellStyle cellStyle = workbook.CreateCellStyle();
                cellStyle.DataFormat = dataFormat.GetFormat("yyyy-MM-dd");



                //数据源
                DataTable tbPayment = dt;



                //头部标题
                IRow paymentHeaderRow = paymentSheet.CreateRow(0);


                //循环添加标题
                foreach (DataColumn column in tbPayment.Columns)
                    paymentHeaderRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);


                // 内容
                int paymentRowIndex = 1;

                foreach (DataRow row in tbPayment.Rows)
                {
                    IRow newRow = paymentSheet.CreateRow(paymentRowIndex);


                    //循环添加列的对应内容
                    foreach (DataColumn column in tbPayment.Columns)
                    {

                        if (column.DataType.Name == "DateTime" && !string.IsNullOrEmpty(row[column].ToString()))
                        {

                            newRow.CreateCell(column.Ordinal).SetCellValue(DateTime.Parse(row[column].ToString()).ToString("yyyy-MM-dd"));
                        }
                        else
                        {
                            newRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                        }


                    }

                    paymentRowIndex++;


                }

                int cellCount = paymentSheet.GetRow(0).LastCellNum;//设置最后一列为隐藏列(隐藏ID)
                paymentSheet.SetColumnHidden(cellCount - 1, true);


                //列宽自适应，只对英文和数字有效
                for (int i = 0; i <= dt.Rows.Count; i++)
                {
                    paymentSheet.AutoSizeColumn(i);
                }
                //获取当前列的宽度，然后对比本列的长度，取最大值
                for (int columnNum = 0; columnNum <= dt.Columns.Count; columnNum++)
                {
                    int columnWidth = paymentSheet.GetColumnWidth(columnNum) / 256;
                    for (int rowNum = 1; rowNum <= paymentSheet.LastRowNum; rowNum++)
                    {
                        IRow currentRow;
                        //当前行未被使用过
                        if (paymentSheet.GetRow(rowNum) == null)
                        {
                            currentRow = paymentSheet.CreateRow(rowNum);
                        }
                        else
                        {
                            currentRow = paymentSheet.GetRow(rowNum);
                        }

                        if (currentRow.GetCell(columnNum) != null)
                        {
                            ICell currentCell = currentRow.GetCell(columnNum);
                            int length = Encoding.Default.GetBytes(currentCell.ToString()).Length;
                            if (columnWidth < length + 1)
                            {
                                columnWidth = length + 1;
                            }
                        }
                    }
                    paymentSheet.SetColumnWidth(columnNum, columnWidth * 256);


                }


                //将表内容写入流 通知浏览器下载
                SaveExcelFile(workbook, excelStream);
            }
            catch (Exception ex)
            {

                throw;
            }

        }


        /// <summary>
        /// 生产动态Excel表格生成
        /// </summary>
        /// <param name="memoryStream"></param>
        public static void ExcelCreate_SCDT(Stream memoryStream, List<LQ_SCDT> list)
        {


            HSSFWorkbook workbook = new HSSFWorkbook();

            ISheet sheet = workbook.CreateSheet();
            //创建单元格设置对象
            ICellStyle cellStyle = workbook.CreateCellStyle();

            //设置水平、垂直居中
            cellStyle.WrapText = true;
            cellStyle.Alignment = HorizontalAlignment.Center;
            cellStyle.VerticalAlignment = VerticalAlignment.Center;
            //单元格填充颜色
            cellStyle.FillForegroundColor = HSSFColor.White.Index;
            cellStyle.FillPattern = FillPattern.SolidForeground;
            //设置边框
            cellStyle.BorderBottom = BorderStyle.Thin;
            cellStyle.BorderLeft = BorderStyle.Thin;
            cellStyle.BorderRight = BorderStyle.Thin;
            cellStyle.BorderTop = BorderStyle.Thin;

            //创建设置字体对象
            IFont font = workbook.CreateFont();
            font.FontHeightInPoints = 10;//设置字体大小
            font.Boldweight = short.MaxValue; //加粗
            font.FontName = "宋体";
            cellStyle.SetFont(font);

            //初始化坐标点   (a起始行  b结束行 c起始列 d结束列)
            int a = 0;
            int b = 0;
            int c = 0;
            int d = 0;
            int locateH = a;
            int locateF = b;

            //创建Excel行和单元格
            for (int i = 0; i < 2; i++)
            {
                IRow newRow = sheet.CreateRow(i);
                for (int j = 0; j < 20; j++)
                {
                    newRow.CreateCell(j);
                }
            }
            #region 表头样式
            a = 0;
            b = 0;
            c = 0;
            d = 18;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列

            for (int j = c; j < d + 1; j++)
            {
                sheet.GetRow(a).GetCell(j).CellStyle = cellStyle;
            }
            sheet.GetRow(a).GetCell(c).SetCellValue("录井生产动态");//录井生产动态

            a = 1;
            b = a;
            d = 0;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("辖区项目部");//辖区项目部

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("序号");//序号

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("编号");//编号

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("仪器");//仪器

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("井号");//井号

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("井队号");//井队号

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("现动态");//现动态

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("设计井深m");//设计井深

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("当日井深m");//当日井深

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("开钻日期");//开钻日期

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("预计完井日期");//预计完井日期

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("后续井位");//后续井位

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("后续井队号");//后续井队号

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("井队动态");//井队动态

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("后续井位");//后续井位

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("井别");//井别

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("隶属");//隶属

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("状态");//状态

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("备注");//状态

            #endregion
            a = b + 1;
            b = a;




            for (int i = 0; i < list.Count; i++)
            {
                int listNum = 0;
                c = 0;
                d = c;
                //if (list[i].ItemList.Count > 0)
                //{
                //    listNum += list[i].ItemList.Count;
                //}
                //else
                //{
                //	listNum += 1;
                //}

                locateH = a;
                locateF = listNum + locateH - 1;
                //a = locateH;
                b = locateF;

                for (int x = locateH; x < locateF + 1; x++)
                {
                    IRow newRow = sheet.CreateRow(x);
                    for (int y = 0; y < 19; y++)
                    {
                        newRow.CreateCell(y);
                    }
                }



                sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                                                                         //i跨行样式
                for (int j = a; j < b + 1; j++)
                {
                    sheet.GetRow(j).GetCell(c).CellStyle = cellStyle;
                }
                sheet.GetRow(a).GetCell(c).SetCellValue(list[i].XQXMB);
                a = locateH;
                b = locateH;
                c = d + 1;
                d = c;
                //for (int m = 0; m < list[i].ItemList.Count; m++)
                //{

                //    string str = "";
                //    str = (m + 1).ToString();
                //    sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                //    sheet.GetRow(a + m).GetCell(c).CellStyle = cellStyle;
                //    sheet.GetRow(a + m).GetCell(c).SetCellValue(str);//字段循环

                //    sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                //    sheet.GetRow(a + m).GetCell(c + 1).CellStyle = cellStyle;
                //    sheet.GetRow(a + m).GetCell(c + 1).SetCellValue(list[i].ItemList[m].DWZBH);//队伍自编号

                //    sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                //    sheet.GetRow(a + m).GetCell(c + 2).CellStyle = cellStyle;
                //    sheet.GetRow(a + m).GetCell(c + 2).SetCellValue(list[i].ItemList[m].LJYQXH);//仪器

                //    sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                //    sheet.GetRow(a + m).GetCell(c + 3).CellStyle = cellStyle;
                //    sheet.GetRow(a + m).GetCell(c + 3).SetCellValue(list[i].ItemList[m].ZJH);//井号

                //    sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                //    sheet.GetRow(a + m).GetCell(c + 4).CellStyle = cellStyle;
                //    sheet.GetRow(a + m).GetCell(c + 4).SetCellValue(list[i].ItemList[m].LJDH);//录井队号

                //    sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                //    sheet.GetRow(a + m).GetCell(c + 5).CellStyle = cellStyle;
                //    sheet.GetRow(a + m).GetCell(c + 5).SetCellValue(list[i].ItemList[m].XDT);//现动态

                //    sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                //    sheet.GetRow(a + m).GetCell(c + 6).CellStyle = cellStyle;
                //    sheet.GetRow(a + m).GetCell(c + 6).SetCellValue(list[i].ItemList[m].SJJS.ToString());//设计井深

                //    sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                //    sheet.GetRow(a + m).GetCell(c + 7).CellStyle = cellStyle;
                //    sheet.GetRow(a + m).GetCell(c + 7).SetCellValue(list[i].ItemList[m].DRJS);//当日井深

                //    sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                //    sheet.GetRow(a + m).GetCell(c + 8).CellStyle = cellStyle;
                //    sheet.GetRow(a + m).GetCell(c + 8).SetCellValue(list[i].ItemList[m].KZRQ);//开钻日期

                //    sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                //    sheet.GetRow(a + m).GetCell(c + 9).CellStyle = cellStyle;
                //    sheet.GetRow(a + m).GetCell(c + 9).SetCellValue(list[i].ItemList[m].YJWJRQ);//完钻日期

                //    sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                //    sheet.GetRow(a + m).GetCell(c + 10).CellStyle = cellStyle;
                //    sheet.GetRow(a + m).GetCell(c + 10).SetCellValue(list[i].ItemList[m].HXJW);//后续井位

                //    sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                //    sheet.GetRow(a + m).GetCell(c + 11).CellStyle = cellStyle;
                //    sheet.GetRow(a + m).GetCell(c + 11).SetCellValue(list[i].ItemList[m].HXJDH);//后续井队号

                //    sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                //    sheet.GetRow(a + m).GetCell(c + 12).CellStyle = cellStyle;
                //    sheet.GetRow(a + m).GetCell(c + 12).SetCellValue(list[i].ItemList[m].SGZT);//井队动态

                //    sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                //    sheet.GetRow(a + m).GetCell(c + 13).CellStyle = cellStyle;
                //    sheet.GetRow(a + m).GetCell(c + 13).SetCellValue(list[i].ItemList[m].HXJW);//后续井位

                //    sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                //    sheet.GetRow(a + m).GetCell(c + 14).CellStyle = cellStyle;
                //    sheet.GetRow(a + m).GetCell(c + 14).SetCellValue(list[i].ItemList[m].JB);//井别

                //    sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                //    sheet.GetRow(a + m).GetCell(c + 15).CellStyle = cellStyle;
                //    sheet.GetRow(a + m).GetCell(c + 15).SetCellValue(list[i].ItemList[m].LJFGS);//隶属单位

                //    sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                //    sheet.GetRow(a + m).GetCell(c + 16).CellStyle = cellStyle;
                //    sheet.GetRow(a + m).GetCell(c + 16).SetCellValue(list[i].ItemList[m].DQZT);//状态

                //    sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                //    sheet.GetRow(a + m).GetCell(c + 17).CellStyle = cellStyle;
                //    sheet.GetRow(a + m).GetCell(c + 17).SetCellValue(list[i].ItemList[m].BZ);//备注

                //}



                a = locateF + 1;
                b = a;
            }

            sheet.GetRow(0).Height = 200 * 5;//行高
            sheet.GetRow(1).Height = 200 * 4;//行高
            sheet.SetColumnWidth(0, (int)(18 * 256));//列宽
            sheet.SetColumnWidth(3, (int)(12 * 256));//列宽
            sheet.SetColumnWidth(4, (int)(15 * 256));//列宽
            sheet.SetColumnWidth(9, (int)(18 * 256));//列宽
            sheet.SetColumnWidth(10, (int)(18 * 256));//列宽
            sheet.SetColumnWidth(18, (int)(20 * 256));//列宽
            workbook.Write(memoryStream);//写入Excel

        }

        /// <summary>
        /// 人员设备Excel生成
        /// </summary>
        /// <param name="memoryStream"></param>
        /// <param name="dic"></param>
        public static void ExcelCreate_RYSB(Stream memoryStream, LQ_RSList dic)
        {


            HSSFWorkbook workbook = new HSSFWorkbook();

            ISheet sheet = workbook.CreateSheet();
            //创建单元格设置对象
            ICellStyle cellStyle = workbook.CreateCellStyle();
            ICellStyle cellStyle_left = workbook.CreateCellStyle();

            //设置水平、垂直居中
            cellStyle.WrapText = true;
            cellStyle.Alignment = HorizontalAlignment.Center;
            cellStyle.VerticalAlignment = VerticalAlignment.Center;

            cellStyle_left.WrapText = true;
            cellStyle_left.Alignment = HorizontalAlignment.Left;
            cellStyle_left.VerticalAlignment = VerticalAlignment.Center;
            //单元格填充颜色
            cellStyle.FillForegroundColor = HSSFColor.White.Index;
            cellStyle.FillPattern = FillPattern.SolidForeground;

            cellStyle_left.FillForegroundColor = HSSFColor.White.Index;
            cellStyle_left.FillPattern = FillPattern.SolidForeground;
            //设置边框
            cellStyle.BorderBottom = BorderStyle.Thin;
            cellStyle.BorderLeft = BorderStyle.Thin;
            cellStyle.BorderRight = BorderStyle.Thin;
            cellStyle.BorderTop = BorderStyle.Thin;

            cellStyle_left.BorderBottom = BorderStyle.Thin;
            cellStyle_left.BorderLeft = BorderStyle.Thin;
            cellStyle_left.BorderRight = BorderStyle.Thin;
            cellStyle_left.BorderTop = BorderStyle.Thin;
            //创建设置字体对象
            IFont font = workbook.CreateFont();
            font.FontHeightInPoints = 10;//设置字体大小
            font.Boldweight = short.MaxValue; //加粗
            font.FontName = "宋体";
            cellStyle.SetFont(font);

            cellStyle_left.SetFont(font);

            //初始化坐标点   (a起始行  b结束行 c起始列 d结束列)
            int a = 0;
            int b = 0;
            int c = 0;
            int d = 0;
            int locateH = a;
            int locateF = b;

            //创建Excel行和单元格
            for (int i = 0; i < 3; i++)
            {
                IRow newRow = sheet.CreateRow(i);
                for (int j = 0; j < 22; j++)
                {
                    newRow.CreateCell(j);
                }
            }
            #region 表头样式
            a = 0;
            b = 0;
            c = 0;
            d = 21;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列

            //for (int j = c; j < d + 1; j++)
            //{
            //    sheet.GetRow ( a ).GetCell ( j ).CellStyle = cellStyle;
            //}
            sheet.GetRow(a).GetCell(c).SetCellValue("人员及设备动态表");//人员及设备动态表

            a = 1;
            b = a;
            d = 1;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            //for (int j = c; j < d + 1; j++)
            //{
            //    sheet.GetRow ( a ).GetCell ( j ).CellStyle = cellStyle;
            //}
            sheet.GetRow(a).GetCell(c).SetCellValue("总人数:");//区块

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            //sheet.GetRow ( a ).GetCell ( c ).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue(0);//序号

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                                                                     // sheet.GetRow ( a ).GetCell ( c ).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("前线:");//编号

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                                                                     // sheet.GetRow ( a ).GetCell ( c ).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue(0);//仪器

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            //sheet.GetRow ( a ).GetCell ( c ).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("轮休:");//井号

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                                                                     // sheet.GetRow ( a ).GetCell ( c ).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue(0);//井队号

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                                                                     // sheet.GetRow ( a ).GetCell ( c ).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("后勤:");//井动态

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            //sheet.GetRow ( a ).GetCell ( c ).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue(0);//设计井深

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            //sheet.GetRow ( a ).GetCell ( c ).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("外借:");//当日井深

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            //sheet.GetRow ( a ).GetCell ( c ).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue(0);//开钻日期

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            //sheet.GetRow ( a ).GetCell ( c ).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("培  训:");//预计完井日期

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            //sheet.GetRow ( a ).GetCell ( c ).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue(0);//后续井位

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            //sheet.GetRow ( a ).GetCell ( c ).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("病事假:");//后续井队号

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            //sheet.GetRow ( a ).GetCell ( c ).CellStyle = cellStyle;//基本样式            
            sheet.GetRow(a).GetCell(c).SetCellValue(0);//井队动态

            c = d + 1;
            d = d + 7;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            //sheet.GetRow ( a ).GetCell ( c ).CellStyle = cellStyle;//基本样式            
            sheet.GetRow(a).GetCell(c).SetCellValue("");//井队动态
                                                        //i跨行样式
                                                        //j跨列样式
            for (int j = 0; j < 22; j++)
            {
                for (int i = locateH; i < 2; i++)
                {
                    sheet.GetRow(i).GetCell(j).CellStyle = cellStyle;
                }
            }
            a = b + 1;
            b = a;
            c = 0;
            d = c;

            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("序号");//序号

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("自编号");//自编号

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("队号");//队号

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("仪器型号");//仪器型号

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("正录井");//正录井

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("钻井队");//钻井队

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("设备状态");//设备状态

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("待录井");//待录井

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("地质师");//地质师

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("地质助理");//地质助理

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("工程师");//工程师

            c = d + 1;
            d = d + 3;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                                                                     //j跨列样式
            for (int j = c; j < d + 1; j++)
            {
                sheet.GetRow(a).GetCell(j).CellStyle = cellStyle;
            }
            sheet.GetRow(a).GetCell(c).SetCellValue("操 作 员");//操 作 员

            c = d + 1;
            d = d + 4;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                                                                     //j跨列样式
            for (int j = c; j < d + 1; j++)
            {
                sheet.GetRow(a).GetCell(j).CellStyle = cellStyle;
            }
            sheet.GetRow(a).GetCell(c).SetCellValue("地 质 工");//地 质 工

            c = d + 1;
            d = d + 2;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            //j跨列样式
            for (int j = c; j < d + 1; j++)
            {
                sheet.GetRow(a).GetCell(j).CellStyle = cellStyle;
            }
            sheet.GetRow(a).GetCell(c).SetCellValue("住房");//住房

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("地质房");//地质房

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;//基本样式
            sheet.GetRow(a).GetCell(c).SetCellValue("设备所在地");//设备所在地

            #endregion
            a = b + 1;
            b = a;
            List<LQ_RYSB> List = new List<LQ_RYSB>();
            List = dic.List;

            int listNum = 0;
            c = 0;
            d = c;
            if (List.Count > 0)
            {
                listNum += List.Count;
            }
            else
            {
                listNum += 1;
            }

            locateH = a;
            locateF = listNum + locateH;
            //a = locateH;
            b = locateF;

            for (int x = locateH; x < locateF + 1; x++)
            {
                IRow newRow = sheet.CreateRow(x);
                for (int y = 0; y < 22; y++)
                {
                    newRow.CreateCell(y);
                }
            }



            a = locateH;
            b = locateH;
            c = 0;
            d = c;
            for (int m = 0; m < List.Count; m++)
            {
                sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;
                sheet.GetRow(a).GetCell(c).SetCellValue(List[m].TROW);//序号

                sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                sheet.GetRow(a).GetCell(c + 1).CellStyle = cellStyle;
                sheet.GetRow(a).GetCell(c + 1).SetCellValue(List[m].DWZBH);//队伍自编号

                sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                sheet.GetRow(a).GetCell(c + 2).CellStyle = cellStyle;
                sheet.GetRow(a).GetCell(c + 2).SetCellValue(List[m].LJDH);//录井队号

                sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                sheet.GetRow(a).GetCell(c + 3).CellStyle = cellStyle;
                sheet.GetRow(a).GetCell(c + 3).SetCellValue(List[m].LJYQXH);//仪器型号

                sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                sheet.GetRow(a).GetCell(c + 4).CellStyle = cellStyle;
                sheet.GetRow(a).GetCell(c + 4).SetCellValue(List[m].JH);//录井号

                sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                sheet.GetRow(a).GetCell(c + 5).CellStyle = cellStyle;
                sheet.GetRow(a).GetCell(c + 5).SetCellValue(List[m].SGDH);//钻井队

                sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                sheet.GetRow(a).GetCell(c + 6).CellStyle = cellStyle;
                sheet.GetRow(a).GetCell(c + 6).SetCellValue(List[m].DQZT);//设备状态

                sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                sheet.GetRow(a).GetCell(c + 7).CellStyle = cellStyle;
                sheet.GetRow(a).GetCell(c + 7).SetCellValue(List[m].HXJW);//待录井

                string strDzs = "";
                if (List[m].DzsList.Count > 0)
                {
                    strDzs = List[m].DzsList[0].XM;
                }
                sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                sheet.GetRow(a).GetCell(c + 8).CellStyle = cellStyle;
                sheet.GetRow(a).GetCell(c + 8).SetCellValue(strDzs);//地质师
                string strDzzl = "";
                if (List[m].DzzlList.Count > 0)
                {
                    strDzzl = List[m].DzzlList[0].XM;
                }
                sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                sheet.GetRow(a).GetCell(c + 9).CellStyle = cellStyle;
                sheet.GetRow(a).GetCell(c + 9).SetCellValue(strDzzl);//地质助理
                string strGcs = "";
                if (List[m].GcsList.Count > 0)
                {
                    strGcs = List[m].GcsList[0].XM;
                }
                sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                sheet.GetRow(a).GetCell(c + 10).CellStyle = cellStyle;
                sheet.GetRow(a).GetCell(c + 10).SetCellValue(strGcs);//工程师
                string strCZY0 = "";
                string strCZY1 = "";
                string strCZY2 = "";

                for (int i = 0; i < List[m].CzyList.Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            strCZY0 = List[m].CzyList[0].XM;
                            break;
                        case 1:
                            strCZY1 = List[m].CzyList[1].XM;
                            break;
                        case 2:
                            strCZY2 = List[m].CzyList[2].XM;
                            break;
                    }
                }
                sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                sheet.GetRow(a).GetCell(c + 11).CellStyle = cellStyle;
                sheet.GetRow(a).GetCell(c + 11).SetCellValue(strCZY0);//操作员

                sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                sheet.GetRow(a).GetCell(c + 12).CellStyle = cellStyle;
                sheet.GetRow(a).GetCell(c + 12).SetCellValue(strCZY1);//操作员

                sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                sheet.GetRow(a).GetCell(c + 13).CellStyle = cellStyle;
                sheet.GetRow(a).GetCell(c + 13).SetCellValue(strCZY2);//操作员

                string strDzg0 = "";
                string strDzg1 = "";
                string strDzg2 = "";
                string strDzg3 = "";

                for (int i = 0; i < List[m].DzgList.Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            strDzg0 = List[m].DzgList[0].XM;
                            break;
                        case 1:
                            strDzg1 = List[m].DzgList[1].XM;
                            break;
                        case 2:
                            strDzg2 = List[m].DzgList[2].XM;
                            break;
                        case 3:
                            strDzg3 = List[m].DzgList[3].XM;
                            break;
                    }
                }

                sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                sheet.GetRow(a).GetCell(c + 14).CellStyle = cellStyle;
                sheet.GetRow(a).GetCell(c + 14).SetCellValue(strDzg0);//地质工

                sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                sheet.GetRow(a).GetCell(c + 15).CellStyle = cellStyle;
                sheet.GetRow(a).GetCell(c + 15).SetCellValue(strDzg1);//地质工

                sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                sheet.GetRow(a).GetCell(c + 16).CellStyle = cellStyle;
                sheet.GetRow(a).GetCell(c + 16).SetCellValue(strDzg2);//地质工

                sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                sheet.GetRow(a).GetCell(c + 17).CellStyle = cellStyle;
                sheet.GetRow(a).GetCell(c + 17).SetCellValue(strDzg3);//地质工

                string strZf0 = "";
                string strZf1 = "";

                for (int i = 0; i < List[m].ZfList.Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            strZf0 = List[m].ZfList[0].CCBH;
                            break;
                        case 1:
                            strZf1 = List[m].ZfList[1].CCBH;
                            break;
                    }
                }

                sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                sheet.GetRow(a).GetCell(c + 18).CellStyle = cellStyle;
                sheet.GetRow(a).GetCell(c + 18).SetCellValue(strZf0);//住房

                sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                sheet.GetRow(a).GetCell(c + 19).CellStyle = cellStyle;
                sheet.GetRow(a).GetCell(c + 19).SetCellValue(strZf1);//住房

                string strDzf0 = "";

                if (List[m].DzfList.Count > 0)
                {
                    strDzf0 = List[m].DzfList[0].CCBH;
                }

                sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                sheet.GetRow(a).GetCell(c + 20).CellStyle = cellStyle;
                sheet.GetRow(a).GetCell(c + 20).SetCellValue(strDzf0);//地质房

                sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                sheet.GetRow(a).GetCell(c + 21).CellStyle = cellStyle;
                sheet.GetRow(a).GetCell(c + 21).SetCellValue(List[m].SBSZD);//所在位置

                a = b + 1;
                b = a;
            }

            a = b;

            c = 0;
            d = c;
            locateH = a;
            locateF = a;
            for (int x = locateH; x < locateF + 100; x++)
            {
                IRow newRow = sheet.CreateRow(x);
                for (int y = 0; y < 22; y++)
                {
                    newRow.CreateCell(y);
                }
            }
            LQ_RYSBCount ListCount = new LQ_RYSBCount();
            ListCount = dic.ListCount;

            d = 2;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                                                                     //j跨列样式
            for (int j = c; j < d + 1; j++)
            {
                sheet.GetRow(a).GetCell(j).CellStyle = cellStyle;
            }
            sheet.GetRow(a).GetCell(c).SetCellValue("合计");//合计

            //c = d + 1;
            //d = c;
            //sheet.AddMergedRegion ( new CellRangeAddress ( a, b, c, d ) ); //起始行  结束行 起始列 结束列
            //sheet.GetRow ( a ).GetCell ( c ).CellStyle = cellStyle;
            //sheet.GetRow ( a ).GetCell ( c ).SetCellValue ( ListCount.DWZBHCount );//队伍自编号

            //c = d + 1;
            //d = c;
            //sheet.AddMergedRegion ( new CellRangeAddress ( a, b, c, d ) ); //起始行  结束行 起始列 结束列
            //sheet.GetRow ( a ).GetCell ( c ).CellStyle = cellStyle;
            //sheet.GetRow ( a ).GetCell ( c ).SetCellValue ( ListCount.LJDHCount );//录井队号
            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;
            sheet.GetRow(a).GetCell(c).SetCellValue(ListCount.LJYQXHCount);//仪器型号
            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;
            sheet.GetRow(a).GetCell(c).SetCellValue(ListCount.ZJHCount);//录井号
            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;
            sheet.GetRow(a).GetCell(c).SetCellValue(ListCount.SGDHCount);//钻井队
            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;
            sheet.GetRow(a).GetCell(c).SetCellValue(ListCount.DQZTCount);//设备状态
            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;
            sheet.GetRow(a).GetCell(c).SetCellValue(ListCount.HXJWCount);//待录井

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;
            sheet.GetRow(a).GetCell(c).SetCellValue(ListCount.DzsListCount);//地质师
            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;
            sheet.GetRow(a).GetCell(c).SetCellValue(ListCount.DzzlListCount);//地质助理
            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;
            sheet.GetRow(a).GetCell(c).SetCellValue(ListCount.GcsListCount);//工程师
            c = d + 1;
            d = d + 3;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                                                                     //j跨列样式
            for (int j = c; j < d + 1; j++)
            {
                sheet.GetRow(a).GetCell(j).CellStyle = cellStyle;
            }
            sheet.GetRow(a).GetCell(c).SetCellValue(ListCount.CzyListCount);//操作员
            c = d + 1;
            d = d + 4;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                                                                     //j跨列样式
            for (int j = c; j < d + 1; j++)
            {
                sheet.GetRow(a).GetCell(j).CellStyle = cellStyle;
            }
            sheet.GetRow(a).GetCell(c).SetCellValue(ListCount.DzgListCount);//地质工
            c = d + 1;
            d = d + 2;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                                                                     //j跨列样式
            for (int j = c; j < d + 1; j++)
            {
                sheet.GetRow(a).GetCell(j).CellStyle = cellStyle;
            }
            sheet.GetRow(a).GetCell(c).SetCellValue(ListCount.ZfListCount);//住房

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;
            sheet.GetRow(a).GetCell(c).SetCellValue(ListCount.DzfListCount);//地质房              

            c = d + 1;
            d = c;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            sheet.GetRow(a).GetCell(c).CellStyle = cellStyle;
            sheet.GetRow(a).GetCell(c).SetCellValue(ListCount.ZJHCount);//所在位置


            #region 领导
            a = b + 1;
            b = a;
            c = 0;
            d = c + 2;

            locateH = a;
            locateF = b;
            for (int x = locateH; x < locateH + 100; x++)
            {
                IRow newRow = sheet.CreateRow(x);
                for (int y = 0; y < 22; y++)
                {
                    newRow.CreateCell(y);
                }
            }

            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                                                                     //j跨列样式
            for (int j = c; j < d + 1; j++)
            {
                sheet.GetRow(a).GetCell(j).CellStyle = cellStyle;
            }
            sheet.GetRow(a).GetCell(c).SetCellValue("领 导:");//领 导

            c = d + 1;
            d = d + 8;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                                                                     //j跨列样式
            for (int j = c; j < d + 1; j++)
            {
                sheet.GetRow(a).GetCell(j).CellStyle = cellStyle;
            }
            sheet.GetRow(a).GetCell(c).SetCellValue("");//

            //c = d + 1;
            //d = d + 3;
            //sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            //                                                         //j跨列样式
            //for (int j = c; j < d + 1; j++)
            //{
            //    sheet.GetRow(a).GetCell(j).CellStyle = cellStyle;
            //}
            //sheet.GetRow(a).GetCell(c).SetCellValue("");//
            #endregion

            #region 基 地 轮 休 人 员
            c = d + 1;
            d = d + 11;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                                                                     //j跨列样式
            for (int j = c; j < d + 1; j++)
            {
                sheet.GetRow(a).GetCell(j).CellStyle = cellStyle;
            }
            sheet.GetRow(a).GetCell(c).SetCellValue("基 地 轮 休 人 员");//

            a = b + 1;
            b = a;
            c = 0;
            d = 10;
            locateH = a;
            locateF = a + 2;

            for (int j = c; j < d + 1; j++)
            {
                sheet.AddMergedRegion(new CellRangeAddress(a, b, j, j)); //起始行  结束行 起始列 结束列
                sheet.GetRow(a).GetCell(j).CellStyle = cellStyle;
                sheet.GetRow(a).GetCell(j).SetCellValue("");//
            }

            #endregion

            #region 责任师

            a = b + 1;
            b = a;
            c = 0;
            d = c + 2;

            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                                                                     //j跨列样式
            for (int j = c; j < d + 1; j++)
            {
                sheet.GetRow(a).GetCell(j).CellStyle = cellStyle;
            }
            sheet.GetRow(a).GetCell(c).SetCellValue("责任师:");//领 导

            c = d + 1;
            d = d + 8;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                                                                     //j跨列样式
            for (int j = c; j < d + 1; j++)
            {
                sheet.GetRow(a).GetCell(j).CellStyle = cellStyle;
            }
            sheet.GetRow(a).GetCell(c).SetCellValue("");//


            a = b + 1;
            b = a;
            c = 0;
            d = 10;

            for (int j = c; j < d + 1; j++)
            {
                sheet.AddMergedRegion(new CellRangeAddress(a, b, j, j)); //起始行  结束行 起始列 结束列
                sheet.GetRow(a).GetCell(j).CellStyle = cellStyle;
                sheet.GetRow(a).GetCell(j).SetCellValue("");//
            }

            #endregion

            #region 地质师

            a = locateH;
            b = locateF;
            c = d + 1;
            d = c;

            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                                                                     //i跨行样式
            for (int j = a; j < b + 1; j++)
            {
                sheet.GetRow(j).GetCell(c).CellStyle = cellStyle;
            }
            sheet.GetRow(a).GetCell(c).SetCellValue("地质师");

            c = d + 1;
            d = d + 10;
            for (int i = a; i < b + 1; i++)
            {
                for (int j = c; j < d + 1; j++)
                {
                    sheet.AddMergedRegion(new CellRangeAddress(i, i, j, j)); //起始行  结束行 起始列 结束列
                    sheet.GetRow(i).GetCell(j).CellStyle = cellStyle;
                    sheet.GetRow(i).GetCell(j).SetCellValue("");//
                }
            }

            #endregion

            //#region 经管员

            a = b + 1;
            b = a;
            c = 0;
            d = c + 2;
            locateH = a;
            locateF = a + 2;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                                                                     //j跨列样式
            for (int j = c; j < d + 1; j++)
            {
                sheet.GetRow(a).GetCell(j).CellStyle = cellStyle;
            }
            sheet.GetRow(a).GetCell(c).SetCellValue("经管员:");//领 导

            c = d + 1;
            d = d + 8;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                                                                     //j跨列样式
            for (int j = c; j < d + 1; j++)
            {
                sheet.GetRow(a).GetCell(j).CellStyle = cellStyle;
            }
            sheet.GetRow(a).GetCell(c).SetCellValue("");//


            a = b + 1;
            b = a;
            c = 0;
            d = 10;

            for (int j = c; j < d + 1; j++)
            {
                sheet.AddMergedRegion(new CellRangeAddress(a, b, j, j)); //起始行  结束行 起始列 结束列
                sheet.GetRow(a).GetCell(j).CellStyle = cellStyle;
                sheet.GetRow(a).GetCell(j).SetCellValue("");//
            }

            a = b + 1;
            b = a;
            c = 0;
            d = c + 2;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                                                                     //j跨列样式
            for (int j = c; j < d + 1; j++)
            {
                sheet.GetRow(a).GetCell(j).CellStyle = cellStyle;
            }
            sheet.GetRow(a).GetCell(c).SetCellValue("设备管理和设计:");//领 导

            c = d + 1;
            d = d + 8;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                                                                     //j跨列样式
            for (int j = c; j < d + 1; j++)
            {
                sheet.GetRow(a).GetCell(j).CellStyle = cellStyle;
            }
            sheet.GetRow(a).GetCell(c).SetCellValue("");//

            #region 工程师

            a = locateH;
            b = locateF;
            c = d + 1;
            d = c;

            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                                                                     //i跨行样式
            for (int j = a; j < b + 1; j++)
            {
                sheet.GetRow(j).GetCell(c).CellStyle = cellStyle;
            }
            sheet.GetRow(a).GetCell(c).SetCellValue("工程师");

            c = d + 1;
            d = d + 10;
            for (int i = a; i < b + 1; i++)
            {
                for (int j = c; j < d + 1; j++)
                {
                    sheet.AddMergedRegion(new CellRangeAddress(i, i, j, j)); //起始行  结束行 起始列 结束列
                    sheet.GetRow(i).GetCell(j).CellStyle = cellStyle;
                    sheet.GetRow(i).GetCell(j).SetCellValue("");//
                }
            }

            #endregion

            #region 设备管理和设计	
            a = b + 1;
            b = a;
            c = 0;
            d = 10;
            locateH = a;
            locateF = a + 4;
            for (int i = a; i < b + 1; i++)
            {
                for (int j = c; j < d + 1; j++)
                {
                    sheet.AddMergedRegion(new CellRangeAddress(i, i, j, j)); //起始行  结束行 起始列 结束列
                    sheet.GetRow(i).GetCell(j).CellStyle = cellStyle;
                    sheet.GetRow(i).GetCell(j).SetCellValue("");//
                }
            }


            #endregion

            a = b + 1;
            b = a;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            for (int j = c; j < d + 1; j++)
            {
                sheet.GetRow(a).GetCell(j).CellStyle = cellStyle;
            }
            sheet.GetRow(a).GetCell(c).SetCellValue("厂区停放设备");//               

            a = b + 1;
            b = a;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            for (int j = c; j < d + 1; j++)
            {
                sheet.GetRow(a).GetCell(j).CellStyle = cellStyle_left;
            }
            sheet.GetRow(a).GetCell(c).SetCellValue("住房:(共 间:大 、小 )");//            

            a = b + 1;
            b = a;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            for (int j = c; j < d + 1; j++)
            {
                sheet.GetRow(a).GetCell(j).CellStyle = cellStyle;
            }
            sheet.GetRow(a).GetCell(c).SetCellValue(" ");//         

            a = b + 1;
            b = a;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            for (int j = c; j < d + 1; j++)
            {
                sheet.GetRow(a).GetCell(j).CellStyle = cellStyle;
            }
            sheet.GetRow(a).GetCell(c).SetCellValue(" ");//   


            #region 操作员

            a = locateH;
            b = locateF;
            c = d + 1;
            d = c;

            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                                                                     //i跨行样式
            for (int j = a; j < b + 1; j++)
            {
                sheet.GetRow(j).GetCell(c).CellStyle = cellStyle;
            }
            sheet.GetRow(a).GetCell(c).SetCellValue("操作员");

            c = d + 1;
            d = d + 10;
            for (int i = a; i < b + 1; i++)
            {
                for (int j = c; j < d + 1; j++)
                {
                    sheet.AddMergedRegion(new CellRangeAddress(i, i, j, j)); //起始行  结束行 起始列 结束列
                    sheet.GetRow(i).GetCell(j).CellStyle = cellStyle;
                    sheet.GetRow(i).GetCell(j).SetCellValue("");//
                }
            }

            #endregion


            #region 地质房	
            a = b + 1;
            b = a;
            c = 0;
            d = 10;
            locateH = a;
            locateF = a;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            for (int j = c; j < d + 1; j++)
            {
                sheet.GetRow(a).GetCell(j).CellStyle = cellStyle_left;
            }
            sheet.GetRow(a).GetCell(c).SetCellValue("地质房:(共 间:大 、小 )");//     

            #endregion

            #region 实习生

            a = locateH;
            b = locateF;
            c = d + 1;
            d = c;

            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                                                                     //i跨行样式
            for (int j = a; j < b + 1; j++)
            {
                sheet.GetRow(j).GetCell(c).CellStyle = cellStyle;
            }
            sheet.GetRow(a).GetCell(c).SetCellValue("实习生");

            c = d + 1;
            d = d + 10;
            for (int i = a; i < b + 1; i++)
            {
                for (int j = c; j < d + 1; j++)
                {
                    sheet.AddMergedRegion(new CellRangeAddress(i, i, j, j)); //起始行  结束行 起始列 结束列
                    sheet.GetRow(i).GetCell(j).CellStyle = cellStyle;
                    sheet.GetRow(i).GetCell(j).SetCellValue("");//
                }
            }

            #endregion

            #region 地质房	
            a = b + 1;
            b = a;
            c = 0;
            d = 10;
            locateH = a;
            locateF = a + 1;
            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
            for (int j = c; j < d + 1; j++)
            {
                sheet.GetRow(a).GetCell(j).CellStyle = cellStyle;
            }
            sheet.GetRow(a).GetCell(c).SetCellValue("");//     

            #endregion

            #region 开发

            a = b + 1;
            b = a;
            c = 0;
            d = c;

            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                                                                     //i跨行样式
            for (int j = a; j < b + 1; j++)
            {
                sheet.GetRow(j).GetCell(c).CellStyle = cellStyle;
            }
            sheet.GetRow(a).GetCell(c).SetCellValue("开发");

            c = d + 1;
            d = d + 10;
            for (int i = a; i < b + 1; i++)
            {
                for (int j = c; j < d + 1; j++)
                {
                    sheet.AddMergedRegion(new CellRangeAddress(i, i, j, j)); //起始行  结束行 起始列 结束列
                    sheet.GetRow(i).GetCell(j).CellStyle = cellStyle;
                    sheet.GetRow(i).GetCell(j).SetCellValue("");//
                }
            }

            #endregion

            #region 地质工

            a = locateH;
            b = locateF;
            c = d + 1;
            d = c;

            sheet.AddMergedRegion(new CellRangeAddress(a, b, c, d)); //起始行  结束行 起始列 结束列
                                                                     //i跨行样式
            for (int j = a; j < b + 1; j++)
            {
                sheet.GetRow(j).GetCell(c).CellStyle = cellStyle;
            }
            sheet.GetRow(a).GetCell(c).SetCellValue("地质工");

            c = d + 1;
            d = d + 10;
            for (int i = a; i < b + 1; i++)
            {
                for (int j = c; j < d + 1; j++)
                {
                    sheet.AddMergedRegion(new CellRangeAddress(i, i, j, j)); //起始行  结束行 起始列 结束列
                    sheet.GetRow(i).GetCell(j).CellStyle = cellStyle;
                    sheet.GetRow(i).GetCell(j).SetCellValue("");//
                }
            }

            #endregion

            sheet.GetRow(0).Height = 200 * 5;//行高
            sheet.GetRow(2).Height = 200 * 4;//行高
            sheet.SetColumnWidth(3, (int)(18 * 256));//列宽
            sheet.SetColumnWidth(4, (int)(12 * 256));//列宽
            sheet.SetColumnWidth(21, (int)(15 * 256));//列宽
                                                      //sheet.SetColumnWidth ( 9, (int)( 18 * 256 ) );//列宽
                                                      //sheet.SetColumnWidth ( 10, (int)( 18 * 256 ) );//列宽
                                                      //sheet.SetColumnWidth ( 18, (int)( 20 * 256 ) );//列宽
            workbook.Write(memoryStream);//写入Excel

        }
        public static void SaveExcelFile(HSSFWorkbook excelWorkBook, Stream excelStream)
        {
            try
            {
                excelWorkBook.Write(excelStream);
            }
            catch (Exception)
            {

            }
            finally
            {

            }
        }

        #region 导出
        //==================================================
        /// <summary>
        /// ExportExcel（使用NPOI的方式）
        /// </summary>
        /// <param name="DT"></param>
        public static void ExportExcel(DataTable DT, string TemplateName, int sheetIndex, int rowIndex, string[] strArry)
        {
            try
            {
                HSSFWorkbook hssfworkbookDown;
                string modelExlPath = System.Web.HttpContext.Current.Server.MapPath("~/Template/" + TemplateName + ".xls");//模板路径
                if (File.Exists(modelExlPath) == false)//模板不存在
                {
                    return;
                }
                using (FileStream file = new FileStream(modelExlPath, FileMode.Open, FileAccess.Read))
                {
                    hssfworkbookDown = new HSSFWorkbook(file);
                    file.Close();
                }
                if (DT.Rows.Count > 0)
                {
                    WriterExcel(hssfworkbookDown, DT, sheetIndex, rowIndex, strArry);//写数据到模板

                    string filename = DateTime.Now.ToString(TemplateName + "yyyyMMdd") + ".xls";//文件名称
                    string strFilePath = System.Web.HttpContext.Current.Server.MapPath("~/Export");//输出路径
                    if (Directory.Exists(strFilePath) == false)
                    {
                        Directory.CreateDirectory(strFilePath);
                    }
                    strFilePath = strFilePath + "\\" + filename;
                    FileStream files = new FileStream(strFilePath, FileMode.Create);
                    hssfworkbookDown.Write(files);
                    files.Close();

                    string url = "~/Export/" + filename;
                    MyFileHelper.WriteFile(url);//下载到本地

                    if (File.Exists(strFilePath) == false)//附件生成失败
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        /// <summary>
        /// WriterExcel 第二个参数为sheet下标,第三个参数为模板数据起始行
        /// </summary>
        /// <param name="hssfworkbookDown">工作簿</param>
        /// <param name="DT"></param>
        /// <param name="sheetIndex">sheet页</param>
        /// <param name="rowIndex">数据起始行数</param>
        /// <param name="strArry">对应的dataTable列名</param>
        public static void WriterExcel(HSSFWorkbook hssfworkbookDown, DataTable DT, int sheetIndex, int rowIndex, string[] strArry)
        {
            try
            {
                #region 设置单元格样式
                //字体
                HSSFFont fontS9 = (HSSFFont)hssfworkbookDown.CreateFont();
                fontS9.FontName = "Arial";
                fontS9.FontHeightInPoints = 10;
                fontS9.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Normal;

                HSSFFont fontS_red = (HSSFFont)hssfworkbookDown.CreateFont();
                fontS_red.FontName = "微软雅黑";
                fontS_red.FontHeightInPoints = 10;
                fontS_red.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Normal;
                fontS_red.Color = NPOI.HSSF.Util.HSSFColor.OliveGreen.Red.Index;
                //表格
                ICellStyle TableS9 = (ICellStyle)hssfworkbookDown.CreateCellStyle();
                TableS9.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                TableS9.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                TableS9.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                TableS9.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                TableS9.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;//水平居中
                TableS9.WrapText = true;
                TableS9.SetFont(fontS9);

                ICellStyle TableS_red = (ICellStyle)hssfworkbookDown.CreateCellStyle();
                TableS_red.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                TableS_red.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                TableS_red.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                TableS_red.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                TableS_red.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;//水平居中
                TableS_red.WrapText = true;
                TableS_red.SetFont(fontS_red);
                #endregion

                #region sheet页设置
                HSSFSheet sheet = (HSSFSheet)hssfworkbookDown.GetSheetAt(sheetIndex);
                hssfworkbookDown.SetSheetHidden(sheetIndex, false);
                hssfworkbookDown.SetActiveSheet(sheetIndex);
                #endregion

                for (int j = 0; j < DT.Rows.Count; j++)
                {
                    HSSFRow dataRow = (HSSFRow)sheet.CreateRow(j + rowIndex);
                    for (int i = 0; i < strArry.Length; i++)
                    {
                        dataRow.CreateCell(i);
                        string colName = strArry[i];
                        dataRow.Cells[i].SetCellValue(DT.Rows[j][colName].ToString());
                        dataRow.Cells[i].CellStyle = TableS9;
                    }
                    //if (DT.Rows[j]["Tunnellingprojectname"].ToString().Contains("(维修)"))
                    //{
                    //    for (int i = 0; i < strArry.Length; i++)//循环列，添加样式
                    //    {
                    //        dataRow.Cells[i].CellStyle = TableS_red;
                    //    }
                    //}
                    //else
                    //{
                    //    for (int i = 0; i < strArry.Length; i++)//循环列，添加样式
                    //    {
                    //        dataRow.Cells[i].CellStyle = TableS9;
                    //    }
                    //}
                }
                //设定第一行，第一列的单元格选中
                //sheet.SetActiveCell(0, 0);
            }
            catch (Exception ex)
            {

            }
        }
        //=================================================== 
        #endregion

        #region 导入
        /// <summary>
        /// 保存Excel文件
        /// <para>Excel的导入导出都会在服务器生成一个文件</para>
        /// <para>路径：UpFiles/ExcelFiles</para>
        /// </summary>
        /// <param name="file">传入的文件对象</param>
        /// <returns>如果保存成功则返回文件的位置;如果保存失败则返回空</returns>
        public static string SaveExcelFile(HttpPostedFile file)
        {
            try
            {
                var fileName = file.FileName.Insert(file.FileName.LastIndexOf('.'), "-" + DateTime.Now.ToString("yyyyMMddHHmmssfff"));
                var filePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Template/ExcelFiles"), fileName);
                string directoryName = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                }
                file.SaveAs(filePath);
                return filePath;
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
		/// Excel导入成Datable
		/// </summary>
		/// <param name="file"></param>
		/// <returns></returns>
		public static DataTable ExcelToTable(string file)
        {
            DataTable dt = new DataTable();
            IWorkbook workbook;
            string fileExt = Path.GetExtension(file).ToLower();
            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                //XSSFWorkbook 适用XLSX格式，HSSFWorkbook 适用XLS格式
                if (fileExt == ".xlsx") { workbook = new XSSFWorkbook(fs); } else if (fileExt == ".xls") { workbook = new HSSFWorkbook(fs); } else { workbook = null; }
                if (workbook == null) { return null; }
                ISheet sheet = workbook.GetSheetAt(0);

                //表头  
                IRow header = sheet.GetRow(sheet.FirstRowNum);
                List<int> columns = new List<int>();
                for (int i = 0; i < header.LastCellNum; i++)
                {
                    object obj = GetValueType(header.GetCell(i));
                    if (obj == null || obj.ToString() == string.Empty)
                    {
                        dt.Columns.Add(new DataColumn("Columns" + i.ToString()));
                    }
                    else
                        dt.Columns.Add(new DataColumn(obj.ToString()));
                    columns.Add(i);
                }
                //数据  
                for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
                {
                    DataRow dr = dt.NewRow();
                    bool hasValue = false;
                    foreach (int j in columns)
                    {
                        dr[j] = GetValueType(sheet.GetRow(i).GetCell(j));
                        if (dr[j] != null && dr[j].ToString() != string.Empty)
                        {
                            hasValue = true;
                        }
                    }
                    if (hasValue)
                    {
                        dt.Rows.Add(dr);
                    }
                }
            }
            return dt;
        }

        /// <summary>
		/// 获取单元格类型
		/// </summary>
		/// <param name="cell"></param>
		/// <returns></returns>
		private static object GetValueType(ICell cell)
        {
            if (cell == null)
                return null;
            switch (cell.CellType)
            {
                case CellType.Blank: //BLANK:  
                    return null;
                case CellType.Boolean: //BOOLEAN:  
                    return cell.BooleanCellValue;
                case CellType.Numeric: //NUMERIC:  
                    return cell.NumericCellValue;
                case CellType.String: //STRING:  
                    return cell.StringCellValue;
                case CellType.Error: //ERROR:  
                    return cell.ErrorCellValue;
                case CellType.Formula: //FORMULA:  
                default:
                    return "=" + cell.CellFormula;
            }
        }
        #endregion

    }
}