using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LJZY.MODEL;
using LJZY.BLL.LQGL;
using Newtonsoft.Json;
using System.IO;
using System.Data;
using LJZY.WEB.Common;

namespace LJZY.WEB.Controllers
{
    /// <summary>
    /// DJCHYAQHSEController 的摘要说明
    /// </summary>
    public class DJCHYAQHSEController : IHttpHandler
    {
        LQ_DJCHYAQHSEBLL djchyaqhseBLL = new LQ_DJCHYAQHSEBLL();
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request["action"];
            switch (action)
            {
                //点击二级目录查询表格数据
                case "DJCHYAQSHE_DataGrid": DJCHYAQSHE_DataGrid(context);break;
                    //导入预览
                case "PreviewExcel_DJCHYAHSE":
                    PreviewExcel_DJCHYAHSE(context); break;
                    //导入
                case "ImportExcel_DJCHYAHSE":
                    ImportExcel_DJCHYAHSE(context);break;


            }
        }



        private void DJCHYAQSHE_DataGrid(HttpContext context)
        {
            string json = "";
            try
            {
                int rows = Convert.ToInt32(context.Request["rows"]);//页面数据条数
                int page = Convert.ToInt32(context.Request["page"]);//页面页码
                string type = context.Request["type"];
                //switch (type)
                //{
                //    case "0":
                //        type = "单井策划";
                //        break;
                //    case "1":
                //        type = "单井应急预案";
                //        break;
                //    case "2":
                //        type = "QSHE作业计划书";
                //        break;
                //}
                string strWhere = context.Request["strWhere"] ?? "";//搜索条件
                string strTree = context.Request["strTree"];//二级目录菜单条件
                string Ptype = djchyaqhseBLL.Ptype(strTree);
                string strSql = "";
                if (Ptype != "")
                {
                    strSql += " And " + Ptype + "='" + strTree + "'";
                }
                if (strWhere.Trim() != "")
                {
                    strSql += strWhere;
                }
                Dictionary<string, object> dic = new Dictionary<string, object>();
                //获取表格数据
                dic = djchyaqhseBLL.DJCHYAQSHEDataGrid(type,strSql, rows, page);
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


        private void PreviewExcel_DJCHYAHSE(HttpContext context)
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
                DataTable dt = NPOIHelper.ExcelToDataTable(filePath, true);

                dt.Columns["序号"].ColumnName = "TROW";
                dt.Columns["地区"].ColumnName = "SC2";
                dt.Columns["区块"].ColumnName = "QK";
                dt.Columns["井别"].ColumnName = "REPORT_TYPE";
                dt.Columns["井型"].ColumnName = "JX";
                dt.Columns["井号"].ColumnName = "ZJH";
                dt.Columns["甲方单位"].ColumnName = "SC3";
                dt.Columns["录井项目部"].ColumnName = "LJFGS";
                dt.Columns["编制人"].ColumnName = "BZR";
                dt.Columns["编制日期"].ColumnName = "BZRQ";
                dt.Columns["备注"].ColumnName = "BZ";
              
                if (!dt.Columns.Contains("ID"))
                {
                    dt.Columns.Add("ID");
                }

                List<LQ_DJCHYAQHSE> list = new List<LQ_DJCHYAQHSE>();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        LQ_DJCHYAQHSE model = new LQ_DJCHYAQHSE();
                        model.SC2 = dt.Rows[i]["SC2"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        model.QK = dt.Rows[i]["QK"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        model.REPORT_TYPE = dt.Rows[i]["REPORT_TYPE"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        model.JX = dt.Rows[i]["JX"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        model.ZJH = dt.Rows[i]["ZJH"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        model.SC3 = dt.Rows[i]["SC3"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        model.LJFGS = dt.Rows[i]["LJFGS"].ToString().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        model.BZR = dt.Rows[i]["BZR"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        model.BZRQ_DG = dt.Rows[i]["BZRQ"].ToString().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        model.BZ = dt.Rows[i]["BZ"].ToString().Replace("\r", "").Replace("\n", "").Replace("\t", "");         
                        model.ID = dt.Rows[i]["ID"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        list.Add(model);
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

        public void ImportExcel_DJCHYAHSE(HttpContext context)
        {
            string json = "";
            string Data = context.Request["Data"];
            List<LQ_DJCHYAQHSE> list = JsonConvert.DeserializeObject<List<LQ_DJCHYAQHSE>>(Data);
            json = Add_DJCHYAHSE(list, context);
            json = JsonConvert.SerializeObject(json);
            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        public string Add_DJCHYAHSE(List<LQ_DJCHYAQHSE> DJCHYAHSE, HttpContext context)
        {
            string json = "";
            try
            {
                string type = context.Request["type"];
                //switch (type)
                //{
                //    case "0":
                //        type = "单井策划";
                //        break;
                //    case "1":
                //        type = "单井应急预案";
                //        break;
                //    case "2":
                //        type = "QSHE作业计划书";
                //        break;
                //}
                int error = 0;//错误数
                int number = 0;//记录成功数        
                for (int i = 0; i < DJCHYAHSE.Count; i++)
                {
                    if (djchyaqhseBLL.CheckDJCHYAHSE(DJCHYAHSE[i].ID,type) > 0)
                    {

                        if (djchyaqhseBLL.Update(DJCHYAHSE[i],type) == false)
                        {
                            error += 1;
                            continue;
                        }

                        number += 1;
                    }
                    else
                    {

                        DJCHYAHSE[i].TJR = CFunctions.getUserId(context);
                        DJCHYAHSE[i].FL = type;
                        if (djchyaqhseBLL.Add(DJCHYAHSE[i]) == false)
                        {
                            error += 1;
                            continue;
                        }
                        number += 1;
                    }
                }

                if (error > 0)
                {
                    json = "{\"IsSuccess\":\"false\",\"Message\":\"" + number + "条数据导入成功," + error + "条数据导入失败!\"}";
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