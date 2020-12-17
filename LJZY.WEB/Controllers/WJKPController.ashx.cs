using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LJZY.MODEL;
using LJZY.BLL.LQGL;
using Newtonsoft.Json;
using System.IO;
using LJZY.WEB.Common;
using System.Data;
using System.Runtime.Serialization.Json;
using System.Text;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace LJZY.WEB.Controllers
{
    /// <summary>
    /// WJKPController 的摘要说明
    /// </summary>
    public class WJKPController : IHttpHandler
    {
        private static string DB_KLRB = System.Configuration.ConfigurationManager.AppSettings["DB_KLRB"];
        private static string T_01 = System.Configuration.ConfigurationManager.AppSettings["T_01"];
        private static string T_61 = System.Configuration.ConfigurationManager.AppSettings["T_61"];
        //private static string dtName1 = DB_KLRB + T_01;
        private static string dtName1 = T_01;
        LQ_WJKPBLL wjkpBLL = new LQ_WJKPBLL();

        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request["action"];
            switch (action)
            {
                //点击二级目录查询表格数据
                case "WJKP_DataGrid": WJKP_DataGrid(context); break;
                ////人员日志查询
                //case "SJRZ_DataGrid": SJRZ_DataGrid(context); break;
                //完井统计信息修改
                case "WJKP_Update": WJKP_Update(context); break;
                ////人员信息删除
                //case "WJKP_Delete": WJKP_Delete(context); break;
                //预览excel
                case "PreviewExcel": PreviewExcel(context); break;
                ////首页
                //case "WJKP_Home": WJKP_Home(context); break;
                ////尾页
                //case "WJKP_End": WJKP_End(context); break;
                ////上一页
                //case "WJKP_Up": WJKP_Up(context); break;
                ////下一页
                //case "WJKP_Down": WJKP_Down(context); break;
                ////导入
                case "ImportExcel":
                    ImportExcel(context); break;
                //case "insertNDJZ":
                //    //年度结转
                //    insertNDJZ(context); break;
                //case "FileUpload":
                //    FileUpload(context); break;
            }
        }


        private void WJKP_Update(HttpContext context)
        {
            string json = "";
            try
            {
                LQ_WJKP _WJKP = new LQ_WJKP();
                _WJKP.AJSJ01_JH = context.Request["AJSJ01_JH"];
                _WJKP.AJSJ01_JB = context.Request["AJSJ01_JB"];
                _WJKP.AJSJ01_JX = context.Request["AJSJ01_JX"];
                _WJKP.AJSJ01_SJZZBX = context.Request["AJSJ01_SJZZBX"];
                _WJKP.AJSJ01_SJHZBY = context.Request["AJSJ01_SJHZBY"];
                _WJKP.AJSJ01_SS = context.Request["AJSJ01_SS"];
                _WJKP.AJSJ01_ZTMD = context.Request["AJSJ01_ZTMD"];
                _WJKP.AJSJ01_GZWZ = context.Request["AJSJ01_GZWZ"];
                _WJKP.AJSJ01_DLWZ = context.Request["AJSJ01_DLWZ"];
                _WJKP.AJSJ01_CXWZ = context.Request["AJSJ01_CXWZ"];
                _WJKP.AJSJ01_DMHB = context.Request["AJSJ01_DMHB"];
                _WJKP.AJSJ01_SJJS = context.Request["AJSJ01_SJJS"];
                _WJKP.AJSJ01_SJMDC = context.Request["AJSJ01_SJMDC"];

                //_WJKP.ADLJ01_BXHB = context.Request["ADLJ01_BXHB"];
                //_WJKP.ADLJ01_SGDW = context.Request["ADLJ01_SGDW"];
                //_WJKP.ADLJ01_SGDH = context.Request["ADLJ01_SGDH"];
                //_WJKP.ADLJ01_KZRQ = context.Request["ADLJ01_KZRQ"];
                //_WJKP.ADLJ01_WZRQ = context.Request["ADLJ01_WZRQ"];
                //_WJKP.ADLJ01_WJRQ = context.Request["ADLJ01_WJRQ"];
                //_WJKP.ADLJ01_WZJS = context.Request["ADLJ01_WZJS"];
                //_WJKP.ADLJ01_WZCS = context.Request["ADLJ01_WZCS"];
                //_WJKP.ADLJ01_WZCW = context.Request["ADLJ01_WZCW"];
                //_WJKP.ADLJ01_WJFF = context.Request["ADLJ01_WJFF"];

                if (wjkpBLL.Update(_WJKP))
                {
                    json = "{\"IsSuccess\":\"true\",\"Message\":\"修改成功！\"}";
                }
                else
                {
                    json = "{\"IsSuccess\":\"false\",\"Message\":\"修改失败！\"}";
                }


            }
            catch (Exception e)
            {
                json = "{\"IsSuccess\":\"false\",\"Message\":\"数据异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }



        public void FileUpload(HttpContext context)
        {
            string json = "";
            HttpFileCollection files = context.Request.Files;
            try
            {
                for (int i = 0; i < files.Count; i++)
                {
                    string fileUrl = "";
                    FileHelp fileHelp = new FileHelp();

                    string url = "../Upload/ZJIMG/";
                    string urlPath = "../../Upload/ZJIMG/";
                    string fileName = Guid.NewGuid().ToString().ToUpper() + files[i].FileName;
                    string strUrl = fileHelp.FileCreateDirectory(url, fileName);
                    fileUrl = urlPath + fileName;
                    files[i].SaveAs(strUrl);
                    //获取多文件名列表
                    json = "{\"IsSuccess\":\"true\",\"Message\":\" 上传成功！ \",\"FileName\":" + JsonConvert.SerializeObject(fileUrl) + "}";
                }




            }
            catch (Exception e)
            {

                json = "{\"IsSuccess\":\"false\",\"Message\":\" 获取数据出现异常！ \"}";
            }



            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }



        //private void insertNDJZ(HttpContext context)
        //{
        //    string json = "";
        //    try
        //    {
        //        string ID = context.Request["ID"];
        //        LQ_WJKP _WJKP = new LQ_WJKP();
        //        _WJKP.NDJZ = DateTime.Now.Year.ToString();
        //        if (wjkpBLL.ADDNDJZ(_WJKP, ID))
        //        {
        //            json = "{\"IsSuccess\":\"true\",\"Message\":\"修改成功！\"}";
        //        }
        //        else
        //        {
        //            json = "{\"IsSuccess\":\"false\",\"Message\":\"数据异常！\"}";
        //        }


        //    }
        //    catch (Exception e)
        //    {
        //        json = "{\"IsSuccess\":\"false\",\"Message\":\"数据异常！\"}";
        //        throw;
        //    }
        //    context.Response.ContentType = "application/json";
        //    //返回JSON结果
        //    context.Response.Clear();
        //    context.Response.Write(json);
        //    HttpContext.Current.ApplicationInstance.CompleteRequest();
        //}


        //private void WJKP_Delete(HttpContext context)
        //{
        //    string json = "";
        //    try
        //    {
        //        string ID = context.Request["ID"] ?? ""; //井ID

        //        if (wjkpBLL.Del(ID))
        //        {
        //            json = "{\"IsSuccess\":\"true\",\"Message\":\"删除成功！\"}";
        //        }
        //        else
        //        {
        //            json = "{\"IsSuccess\":\"false\",\"Message\":\"删除失败！\"}";
        //        }
        //        //json = JsonConvert.SerializeObject(json);
        //    }
        //    catch (Exception e)
        //    {
        //        json = "{\"IsSuccess\":\"false\",\"Message\":\"数据异常！\"}";
        //    }

        //    context.Response.ContentType = "application/json";
        //    //返回JSON结果
        //    context.Response.Clear();
        //    context.Response.Write(json);
        //    HttpContext.Current.ApplicationInstance.CompleteRequest();

        //}

        /// <summary>
        /// 完井统计信息分页查询
        /// </summary>
        /// <param name="context"></param>
        private void WJKP_DataGrid(HttpContext context)
        {
            string json = "";
            try
            {
                int rows = Convert.ToInt32(context.Request["rows"]);//页面数据条数
                int page = Convert.ToInt32(context.Request["page"]);//页面页码
                string strWhere = context.Request["strWhere"] ?? "";//搜索条件
                string strSql = "";
                if (strWhere.Trim() != "")
                {
                    strSql += strWhere;
                }
                Dictionary<string, object> dic = new Dictionary<string, object>();
                //获取表格数据
                dic = wjkpBLL.WJKPDataGrid(strSql, rows, page);
                json = JsonConvert.SerializeObject(dic);
            }
            catch (Exception e)
            {
                json = "{\"IsSuccess\":\"false\",\"Message\":\"数据异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }


        /// <summary>
        /// 员工日志分页查询
        /// </summary>
        /// <param name="context"></param>
        //private void SJRZ_DataGrid(HttpContext context)
        //{
        //    string json = "";
        //    try
        //    {
        //        int rows = Convert.ToInt32(context.Request["rows"]);//页面数据条数
        //        int page = Convert.ToInt32(context.Request["page"]);//页面页码
        //        string strWhere = context.Request["strWhere"] ?? "";//搜索条件
        //        string strSql = "";
        //        if (strWhere.Trim() != "")
        //        {
        //            strSql += strWhere;
        //        }
        //        Dictionary<string, object> dic = new Dictionary<string, object>();
        //        //获取表格数据
        //        dic = wjkpBLL.SJRZDataGrid(dtName1, strSql, rows, page);
        //        json = JsonConvert.SerializeObject(dic);
        //    }
        //    catch (Exception e)
        //    {
        //        json = "{\"IsSuccess\":\"false\",\"Message\":\"数据异常！\"}";
        //    }

        //    context.Response.ContentType = "application/json";
        //    //返回JSON结果
        //    context.Response.Clear();
        //    context.Response.Write(json);
        //    HttpContext.Current.ApplicationInstance.CompleteRequest();

        //}



        //private void WJKP_Home(HttpContext context)
        //{
        //    string json = "";
        //    try
        //    {
        //        string RYBH = context.Request["RYBH"];
        //        int TROW = 1; //首页序号
        //        List<LQ_WJKP> list = wjkpBLL.WJKPInfo(TROW); //首页单井设计信息
        //        LQ_WJKP model = new LQ_WJKP();

        //        if (list.Count > 0)
        //        {
        //            model = list[0];
        //        }

        //        json = JsonConvert.SerializeObject(model);
        //    }
        //    catch (Exception e)
        //    {
        //        json = " ";
        //    }

        //    context.Response.ContentType = "application/json";
        //    //返回JSON结果
        //    context.Response.Clear();
        //    context.Response.Write(json);
        //    HttpContext.Current.ApplicationInstance.CompleteRequest();

        //}


        //private void WJKP_End(HttpContext context)
        //{
        //    string json = "";
        //    try
        //    {

        //        string RYBH = context.Request["RYBH"];
        //        List<LQ_WJKP> list = new List<LQ_WJKP>();
        //        LQ_WJKP model = new LQ_WJKP();

        //        int TROW = wjkpBLL.COUNT_List(); //获取尾页序号
        //        if (TROW > 0)
        //        {
        //            list = wjkpBLL.WJKPInfo(TROW);
        //        }

        //        if (list.Count > 0)
        //        {
        //            model = list[0];
        //        }

        //        json = JsonConvert.SerializeObject(model);
        //    }
        //    catch (Exception e)
        //    {
        //        json = "{\"IsSuccess\":\"false\",\"Message\":\"数据异常！\"}";
        //    }

        //    context.Response.ContentType = "application/json";
        //    //返回JSON结果
        //    context.Response.Clear();
        //    context.Response.Write(json);
        //    HttpContext.Current.ApplicationInstance.CompleteRequest();

        //}


        //private void WJKP_Up(HttpContext context)
        //{
        //    string json = "";
        //    try
        //    {
        //        string RYBH = context.Request["RYBH"];
        //        List<LQ_WJKP> list_BH = new List<LQ_WJKP>();
        //        List<LQ_WJKP> list_TROW = new List<LQ_WJKP>();
        //        LQ_WJKP model = new LQ_WJKP();
        //        string ID = context.Request["ID"];  //井号
        //        int TROW = 1; //起始页序号

        //        list_BH = wjkpBLL.WJKPInfo_BH(ID);//当前页面信息
        //        if (list_BH.Count > 0)
        //        {
        //            int row = list_BH[0].TROW;
        //            row = row - 1;
        //            if (row > 0)
        //            {
        //                TROW = row; //上页序号
        //            }

        //        }

        //        list_TROW = wjkpBLL.WJKPInfo(TROW);

        //        if (list_TROW.Count > 0)
        //        {
        //            model = list_TROW[0];
        //        }
        //        json = JsonConvert.SerializeObject(model);
        //    }
        //    catch (Exception e)
        //    {
        //        json = "{\"IsSuccess\":\"false\",\"Message\":\"数据异常！\"}";
        //    }

        //    context.Response.ContentType = "application/json";
        //    //返回JSON结果
        //    context.Response.Clear();
        //    context.Response.Write(json);
        //    HttpContext.Current.ApplicationInstance.CompleteRequest();

        //}


        //private void WJKP_Down(HttpContext context)
        //{
        //    string json = "";
        //    try
        //    {
        //        string RYBH = context.Request["RYBH"];
        //        string ID = context.Request["ID"];//井号
        //        int TROW = wjkpBLL.COUNT_List();//当前页序号
        //        List<LQ_WJKP> list_BH = new List<LQ_WJKP>();
        //        List<LQ_WJKP> list_TROW = new List<LQ_WJKP>();
        //        LQ_WJKP model = new LQ_WJKP();
        //        list_BH = wjkpBLL.WJKPInfo_BH(ID);//当前页面信息
        //        if (list_BH.Count > 0)
        //        {
        //            int row = list_BH[0].TROW;
        //            row = row + 1;
        //            if (row < TROW)
        //            {
        //                TROW = row;  //下页序号
        //            }

        //        }
        //        list_TROW = wjkpBLL.WJKPInfo(TROW); //通过序号获取下页信息

        //        if (list_TROW.Count > 0)
        //        {
        //            model = list_TROW[0];
        //        }
        //        json = JsonConvert.SerializeObject(model);
        //    }
        //    catch (Exception e)
        //    {
        //        json = "{\"IsSuccess\":\"false\",\"Message\":\"数据异常！\"}";
        //    }

        //    context.Response.ContentType = "application/json";
        //    //返回JSON结果
        //    context.Response.Clear();
        //    context.Response.Write(json);
        //    HttpContext.Current.ApplicationInstance.CompleteRequest();

        //}


        // 导入Excel，并预览
        private void PreviewExcel(HttpContext context)
        {
            string json = "";
            try
            {
                HttpPostedFile file = context.Request.Files["FileUpload"];
                var filePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Upload/ExcelFile"), file.FileName);
                string directoryName = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                }
                file.SaveAs(filePath);

                // 读取Excel（数据类型）到DataTable
                DataTable dt = NPOIHelper.ExcelToDataTable(filePath, true);

                // 声明DataTable的列名（Excel内为中文——现在为英文）
                dt.Columns["AJSJ01井号"].ColumnName = "AJSJ01_JH";
                dt.Columns["AJSJ01井别"].ColumnName = "AJSJ01_JB";
                dt.Columns["AJSJ01井型"].ColumnName = "AJSJ01_JX";
                dt.Columns["AJSJ01纵坐标"].ColumnName = "AJSJ01_SJZZBX";
                dt.Columns["AJSJ01横坐标"].ColumnName = "AJSJ01_SJHZBY";
                dt.Columns["AJSJ01水深"].ColumnName = "AJSJ01_SS";
                dt.Columns["AJSJ01评价目的"].ColumnName = "AJSJ01_ZTMD";
                dt.Columns["AJSJ01构造位置"].ColumnName = "AJSJ01_GZWZ";
                dt.Columns["AJSJ01地理位置"].ColumnName = "AJSJ01_DLWZ";
                dt.Columns["AJSJ01测线位置"].ColumnName = "AJSJ01_CXWZ";
                dt.Columns["AJSJ01地面海拔"].ColumnName = "AJSJ01_DMHB";
                dt.Columns["AJSJ01设计井深"].ColumnName = "AJSJ01_SJJS";
                dt.Columns["AJSJ01主要目的层"].ColumnName = "AJSJ01_SJMDC";
                //if (!dt.Columns.Contains("AJSJ01_ID"))
                //{
                //    dt.Columns.Add("AJSJ01_ID");
                //}

                dt.Columns["ADLJ01补心海拔"].ColumnName = "ADLJ01_BXHB";
                dt.Columns["ADLJ01施工单位"].ColumnName = "ADLJ01_SGDW";
                dt.Columns["ADLJ01施工队号"].ColumnName = "ADLJ01_SGDH";
                dt.Columns["ADLJ01开钻日期"].ColumnName = "ADLJ01_KZRQ";
                dt.Columns["ADLJ01完钻日期"].ColumnName = "ADLJ01_WZRQ";
                dt.Columns["ADLJ01完井日期"].ColumnName = "ADLJ01_WJRQ";
                dt.Columns["ADLJ01完钻井深"].ColumnName = "ADLJ01_WZJS";
                dt.Columns["ADLJ01完钻垂深"].ColumnName = "ADLJ01_WZCS";
                dt.Columns["ADLJ01完钻层位"].ColumnName = "ADLJ01_WZCW";
                dt.Columns["ADLJ01完井方法"].ColumnName = "ADLJ01_WJFF";

                // 将DataTable数据放入model（数据类型） list
                List<LQ_WJKP> list = new List<LQ_WJKP>();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        LQ_WJKP ry = new LQ_WJKP();
                        ry.AJSJ01_JH = dt.Rows[i]["AJSJ01_JH"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        ry.AJSJ01_JB = dt.Rows[i]["AJSJ01_JB"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        ry.AJSJ01_JX = dt.Rows[i]["AJSJ01_JX"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        ry.AJSJ01_SJZZBX = dt.Rows[i]["AJSJ01_SJZZBX"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        ry.AJSJ01_SJHZBY = dt.Rows[i]["AJSJ01_SJHZBY"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        ry.AJSJ01_SS = dt.Rows[i]["AJSJ01_SS"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        ry.AJSJ01_ZTMD = dt.Rows[i]["AJSJ01_ZTMD"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        ry.AJSJ01_GZWZ = dt.Rows[i]["AJSJ01_GZWZ"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        ry.AJSJ01_DLWZ = dt.Rows[i]["AJSJ01_DLWZ"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        ry.AJSJ01_CXWZ = dt.Rows[i]["AJSJ01_CXWZ"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        ry.AJSJ01_DMHB = dt.Rows[i]["AJSJ01_DMHB"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        ry.AJSJ01_SJJS = dt.Rows[i]["AJSJ01_SJJS"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        ry.AJSJ01_SJMDC = dt.Rows[i]["AJSJ01_SJMDC"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");

                        ry.ADLJ01_BXHB = dt.Rows[i]["ADLJ01_BXHB"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        ry.ADLJ01_SGDW = dt.Rows[i]["ADLJ01_SGDW"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        ry.ADLJ01_SGDH = dt.Rows[i]["ADLJ01_SGDH"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        ry.ADLJ01_KZRQ = dt.Rows[i]["ADLJ01_KZRQ"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        ry.ADLJ01_WZRQ = dt.Rows[i]["ADLJ01_WZRQ"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        ry.ADLJ01_WJRQ = dt.Rows[i]["ADLJ01_WJRQ"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        ry.ADLJ01_WZJS = dt.Rows[i]["ADLJ01_WZJS"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        ry.ADLJ01_WZCS = dt.Rows[i]["ADLJ01_WZCS"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        ry.ADLJ01_WZCW = dt.Rows[i]["ADLJ01_WZCW"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        ry.ADLJ01_WJFF = dt.Rows[i]["ADLJ01_WJFF"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");

                        list.Add(ry);
                    }
                }

                if (list != null)
                {
                    string ss = JsonConvert.SerializeObject(list);
                    json = "{IsSuccess:'true',Message:'" + ss + "'}";
                }
                else
                {
                    json = "{IsSuccess:'false',Message:'错误'}";
                }


            }
            catch (Exception e)
            {
                json = "{IsSuccess:'false',Message:'错误'}";
            }
            context.Response.Write(json);
            context.ApplicationInstance.CompleteRequest();

        }


        /// <summary>
        /// 导入Excel
        /// </summary>
        /// <param name="context"></param>
        public void ImportExcel(HttpContext context)
        {
            string json = "";
            string Data = context.Request["Data"];
            List<LQ_WJKP> list = JsonConvert.DeserializeObject<List<LQ_WJKP>>(Data);
            json = Add(list, context);
            json = JsonConvert.SerializeObject(json);
            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        /// <summary>
        /// 添加完井卡片
        /// </summary>
        /// <param name="vaList"></param>
        /// <returns></returns>
        public string Add(List<LQ_WJKP> WJKP, HttpContext context)
        {
            string json = "";
            LQ_WJKP model = new LQ_WJKP();
            try
            {
                int error = 0;//错误数
                int number = 0;//记录成功数
                foreach (LQ_WJKP item in WJKP)
                {
                    model.AJSJ01_JH = item.AJSJ01_JH;
                    model.AJSJ01_JB = item.AJSJ01_JB;
                    model.AJSJ01_JX = item.AJSJ01_JX;
                    model.AJSJ01_SJZZBX = item.AJSJ01_SJZZBX;
                    model.AJSJ01_SJHZBY = item.AJSJ01_SJHZBY;
                    model.AJSJ01_SS = item.AJSJ01_SS;
                    model.AJSJ01_ZTMD = item.AJSJ01_ZTMD;
                    model.AJSJ01_GZWZ = item.AJSJ01_GZWZ;
                    model.AJSJ01_DLWZ = item.AJSJ01_DLWZ;
                    model.AJSJ01_CXWZ = item.AJSJ01_CXWZ;
                    model.AJSJ01_DMHB = item.AJSJ01_DMHB;
                    model.AJSJ01_SJJS = item.AJSJ01_SJJS;
                    model.AJSJ01_SJMDC = item.AJSJ01_SJMDC;
                    //model.RYZT = "待派";
                    //model.TJR = CFunctions.getUserId(context);

                    // 检查完井井号是否存在
                    if (wjkpBLL.CheckRY(model.AJSJ01_JH) > 0)    // 存在就修改
                    {
                        if (wjkpBLL.Update(model) == false)
                        {
                            error += 1;
                            continue;
                        }
                        number += 1;
                    }   
                    else
                    {   // 不存在就添加
                        //model.AJSJ01_ID = Guid.NewGuid().ToString().ToUpper();    // 生成的这个ID类似序列号
                        model.AJSJ01_ID = model.AJSJ01_JH + ":1666:0";  // ID=JH+？？
                        if (wjkpBLL.Add(model) == false)
                        {
                            error += 1;
                            continue;
                        }
                        number += 1;
                    }

                }

                if (error > 0)
                {
                    json = "{\"IsSuccess\":\"true\",\"Message\":\"" + number + "条数据导入成功," + error + "条数据导入失败!\"}";
                }
                else
                {
                    json = "{\"IsSuccess\":\"true\",\"Message\":\"导入成功！\"}";
                }
            }
            catch (Exception ex)
            {
                json = "{\"IsSuccess\":\"false\",\"Message\":\"请验证导入文件是否正确！\"}";
            }

            return json;
        }




        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}