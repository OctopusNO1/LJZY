using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LJZY.BLL.LQGL;
using Newtonsoft.Json;
using System.IO;
using System.Data;
using LJZY.WEB.Common;
using LJZY.MODEL;

namespace LJZY.WEB.Controllers
{
    /// <summary>
    /// SBGLController 的摘要说明
    /// </summary>
    public class SBGLController : IHttpHandler
    {
        LQ_SBGLBLL sbglBLL = new LQ_SBGLBLL();
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request["action"];
            switch (action)
            {
                //车辆表格数据
                case "SB_CLDataGrid": SB_CLDataGrid(context); break;
                //地化分析表格数据
                case "SB_DHFXDataGrid": SB_DHFXDataGrid(context); break;
                //工程参数仪表格数据
                case "SB_GCCSYDataGrid": SB_GCCSYDataGrid(context); break;
                //卫星表格数据
                case "SB_WXDataGrid": SB_WXDataGrid(context); break;
                //综合仪表格数据
                case "SB_ZHYDataGrid": SB_ZHYDataGrid(context); break;
                //钻时仪表格数据
                case "SB_ZSYDataGrid": SB_ZSYDataGrid(context); break;
                //地质房 库房 住房表格数据
                case "LQ_FWDataGrid": LQ_FWDataGrid(context); break;

                //车辆设备excel预览
                case "PreviewExcel_CL":
                    PreviewExcel_CL(context); break;
                //车辆设备excel导入
                case "ImportExcel_CL":
                    ImportExcel_CL(context); break;
                //钻时仪设备excel预览
                case "PreviewExcel_ZSY":
                    PreviewExcel_ZSY(context); break;
                //钻时仪设备excel导入
                case "ImportExcel_ZSY":
                    ImportExcel_ZSY(context); break;
                //地化设备excel预览
                case "PreviewExcel_DHFX":
                    PreviewExcel_DHFX(context); break;
                //地化设备excel导入
                case "ImportExcel_DHFX":
                    ImportExcel_DHFX(context); break;
                //工程参数仪excel预览
                case "PreviewExcel_GCCSY":
                    PreviewExcel_GCCSY(context); break;
                //工程参数仪excel导入
                case "ImportExcel_GCCSY":
                    ImportExcel_GCCSY(context); break;
                //综合仪设备excel预览
                case "PreviewExcel_ZHY":
                    PreviewExcel_ZHY(context); break;
                //综合仪设备excel导入
                case "ImportExcel_ZHY":
                    ImportExcel_ZHY(context); break;
                //卫星设备excel预览
                case "PreviewExcel_WX":
                    PreviewExcel_WX(context); break;
                //卫星设备excel导入 
                case "ImportExcel_WX":
                    ImportExcel_WX(context); break;
                //地质房 库房 住房excel预览
                case "PreviewExcel_FW":
                    PreviewExcel_FW(context); break;
                //地质房 库房 住房excel导入
                case "ImportExcel_FW":
                    ImportExcel_FW(context); break;


            }
        }

        private void SB_CLDataGrid(HttpContext context)
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
                dic = sbglBLL.SB_CLDataGrid(strSql, rows, page);
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

        private void SB_DHFXDataGrid(HttpContext context)
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
                dic = sbglBLL.SB_DHFXDataGrid(strSql, rows, page);
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

        private void SB_GCCSYDataGrid(HttpContext context)
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
                dic = sbglBLL.SB_GCCSYDataGrid(strSql, rows, page);
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

        private void SB_WXDataGrid(HttpContext context)
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
                dic = sbglBLL.SB_WXDataGrid(strSql, rows, page);
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

        private void SB_ZHYDataGrid(HttpContext context)
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
                dic = sbglBLL.SB_ZHYDataGrid(strSql, rows, page);
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

        private void SB_ZSYDataGrid(HttpContext context)
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
                dic = sbglBLL.SB_ZSYDataGrid(strSql, rows, page);
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

        private void LQ_FWDataGrid(HttpContext context)
        {
            string json = "";
            try
            {
                int rows = Convert.ToInt32(context.Request["rows"]);//页面数据条数
                int page = Convert.ToInt32(context.Request["page"]);//页面页码
                string fl = context.Request["fl"];
                switch (fl)
                {
                    case "0":
                        fl = "地质房";
                        break;
                    case "1":
                        fl = "库房";
                        break;
                    case "2":
                        fl = "住房";
                        break;
                }
                string strWhere = context.Request["strWhere"] ?? "";//搜索条件
                string strSql = " AND FL='" + fl + "'";
                if (strWhere.Trim() != "")
                {
                    strSql += strWhere;
                }
                Dictionary<string, object> dic = new Dictionary<string, object>();
                //获取表格数据
                dic = sbglBLL.FW_DataGrid(strSql, rows, page);
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

        #region--------------------车辆导入-------------------------
        private void PreviewExcel_CL(HttpContext context)
        {
            string json = "";
            try
            {
                HttpPostedFile file = context.Request.Files["FileUpload"];//获取上传的文件
                var filePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Upload/ExcelFile"), file.FileName);
                string directoryName = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                }
                file.SaveAs(filePath);//保存文件到指定目录下
                DataTable dt = NPOIHelper.ExcelToDataTable(filePath, true);
                dt.Columns["序号"].ColumnName = "TROW";
                dt.Columns["单位名称"].ColumnName = "DW";
                dt.Columns["设备名称"].ColumnName = "SBMC";
                dt.Columns["规格型号"].ColumnName = "GGXH";
                dt.Columns["生产厂家"].ColumnName = "SCCJ";
                dt.Columns["国别"].ColumnName = "GB";
                dt.Columns["出厂日期"].ColumnName = "CCRQ";
                dt.Columns["出厂编号"].ColumnName = "CCBH";
                dt.Columns["投产日期"].ColumnName = "TCRQ";
                dt.Columns["折旧年限"].ColumnName = "ZJNX";
                dt.Columns["燃料分类"].ColumnName = "RLFL";
                dt.Columns["设备状况"].ColumnName = "SBZK";
                dt.Columns["使用地点"].ColumnName = "SBSZWZ";
                dt.Columns["大修情况"].ColumnName = "DXQK";
                dt.Columns["备注"].ColumnName = "BZ";
                if (!dt.Columns.Contains("ID"))
                {
                    dt.Columns.Add("ID");
                }

                List<LQ_SB_CL> list = new List<LQ_SB_CL>();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        LQ_SB_CL cl = new LQ_SB_CL();
                        cl.DW = dt.Rows[i]["DW"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");//替换字符串中的\r\n\t,避免json格式化出错
                        cl.SBMC = dt.Rows[i]["SBMC"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        cl.GGXH = dt.Rows[i]["GGXH"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        cl.SCCJ = dt.Rows[i]["SCCJ"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        cl.GB = dt.Rows[i]["GB"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        cl.CCRQ_GD = dt.Rows[i]["CCRQ"].ToString().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        cl.CCBH = dt.Rows[i]["CCBH"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        cl.TCRQ_GD = dt.Rows[i]["TCRQ"].ToString().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        cl.ZJNX = 0;
                        if (!string.IsNullOrEmpty(dt.Rows[i]["ZJNX"].ToString()))
                        {
                            cl.ZJNX = Convert.ToInt32(dt.Rows[i]["ZJNX"]);
                        }
                        cl.RLFL = dt.Rows[i]["RLFL"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        cl.SBZK = dt.Rows[i]["SBZK"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        cl.SBSZWZ = dt.Rows[i]["SBSZWZ"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        cl.DXQK = dt.Rows[i]["DXQK"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        cl.BZ = dt.Rows[i]["BZ"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        cl.ID = dt.Rows[i]["ID"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        list.Add(cl);
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

        public void ImportExcel_CL(HttpContext context)
        {
            string json = "";
            string Data = context.Request["Data"];//获取传进来的json字符串
            List<LQ_SB_CL> list = JsonConvert.DeserializeObject<List<LQ_SB_CL>>(Data);//json反序列化
            json = Add_CL(list, context);//执行添加操作
            json = JsonConvert.SerializeObject(json);
            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        public string Add_CL(List<LQ_SB_CL> SB_CL, HttpContext context)
        {
            string json = "";
            try
            {
                int error = 0;//错误数
                int number = 0;//记录成功数        
                for (int i = 0; i < SB_CL.Count; i++)
                {
                    if (sbglBLL.CheckCL(SB_CL[i].ID) > 0)
                    {

                        if (sbglBLL.Update_CL(SB_CL[i]) == false)
                        {
                            error += 1;
                            continue;
                        }

                        number += 1;
                    }
                    else
                    {
                        //SB_CL[i].ID = Guid.NewGuid().ToString().ToUpper();
                        if (sbglBLL.Add_CL(SB_CL[i]) == false)
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
        #endregion

        #region-------------------卫星导入-------------------------
        private void PreviewExcel_WX(HttpContext context)
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
                dt.Columns["单位名称"].ColumnName = "DW";
                dt.Columns["设备名称"].ColumnName = "SBMC";
                dt.Columns["规格型号"].ColumnName = "GGXH";
                dt.Columns["生产厂家"].ColumnName = "SCCJ";
                dt.Columns["国别"].ColumnName = "GB";
                dt.Columns["出厂日期"].ColumnName = "CCRQ";
                dt.Columns["出厂编号"].ColumnName = "CCBH";
                dt.Columns["投产日期"].ColumnName = "TCRQ";
                dt.Columns["资产编号"].ColumnName = "ZCBH";
                dt.Columns["自编号"].ColumnName = "ZBH";
                dt.Columns["安装地点"].ColumnName = "SBSZWZ";
                dt.Columns["设备状况"].ColumnName = "SBZK";
                dt.Columns["备注"].ColumnName = "BZ";
                if (!dt.Columns.Contains("ID"))
                {
                    dt.Columns.Add("ID");
                }

                List<LQ_SB_WX> list = new List<LQ_SB_WX>();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        LQ_SB_WX wx = new LQ_SB_WX();

                        wx.DW = dt.Rows[i]["DW"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        wx.SBMC = dt.Rows[i]["SBMC"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        wx.GGXH = dt.Rows[i]["GGXH"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        wx.SCCJ = dt.Rows[i]["SCCJ"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        wx.GB = dt.Rows[i]["GB"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        wx.CCRQ_GD = dt.Rows[i]["CCRQ"].ToString().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        wx.CCBH = dt.Rows[i]["CCBH"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        wx.TCRQ_GD = dt.Rows[i]["TCRQ"].ToString().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        wx.ZCBH = dt.Rows[i]["ZCBH"].ToString().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        wx.ZBH = dt.Rows[i]["ZBH"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        wx.SBSZWZ = dt.Rows[i]["SBSZWZ"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        wx.SBZK = dt.Rows[i]["SBZK"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        wx.BZ = dt.Rows[i]["BZ"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        wx.ID = dt.Rows[i]["ID"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        list.Add(wx);
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

        public void ImportExcel_WX(HttpContext context)
        {
            string json = "";
            string Data = context.Request["Data"];
            List<LQ_SB_WX> list = JsonConvert.DeserializeObject<List<LQ_SB_WX>>(Data);
            json = Add_WX(list, context);
            json = JsonConvert.SerializeObject(json);
            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        public string Add_WX(List<LQ_SB_WX> SB_WX, HttpContext context)
        {
            string json = "";
            try
            {
                int error = 0;//错误数
                int number = 0;//记录成功数        
                for (int i = 0; i < SB_WX.Count; i++)
                {
                    if (sbglBLL.CheckWX(SB_WX[i].ID) > 0)
                    {

                        if (sbglBLL.Update_WX(SB_WX[i]) == false)
                        {
                            error += 1;
                            continue;
                        }

                        number += 1;
                    }
                    else
                    {
                        //SB_WX[i].ID = Guid.NewGuid().ToString().ToUpper();
                        if (sbglBLL.Add_WX(SB_WX[i]) == false)
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

        #endregion

        #region-------------------钻时仪导入-------------------------
        private void PreviewExcel_ZSY(HttpContext context)
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
                dt.Columns["设备名称"].ColumnName = "SBMC";
                dt.Columns["规格型号"].ColumnName = "GGXH";
                dt.Columns["生产厂家"].ColumnName = "SCCJ";
                dt.Columns["国别"].ColumnName = "GB";
                dt.Columns["出厂日期"].ColumnName = "CCRQ";
                dt.Columns["出厂编号"].ColumnName = "CCBH";
                dt.Columns["投产日期"].ColumnName = "TCRQ";
                dt.Columns["设备现编号"].ColumnName = "SBXBH";
                dt.Columns["设备自编号"].ColumnName = "SBZBH";
                dt.Columns["设备状况"].ColumnName = "SBZK";
                dt.Columns["所属单位"].ColumnName = "DW";
                dt.Columns["设备所在位置"].ColumnName = "SBSZWZ";
                dt.Columns["大修时间"].ColumnName = "DXSJ";
                dt.Columns["备注"].ColumnName = "BZ";
                if (!dt.Columns.Contains("ID"))
                {
                    dt.Columns.Add("ID");
                }

                List<LQ_SB_ZSY> list = new List<LQ_SB_ZSY>();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        LQ_SB_ZSY zsy = new LQ_SB_ZSY();

                        zsy.SBMC = dt.Rows[i]["SBMC"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        zsy.GGXH = dt.Rows[i]["GGXH"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        zsy.SCCJ = dt.Rows[i]["SCCJ"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        zsy.GB = dt.Rows[i]["GB"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        zsy.CCRQ_GD = dt.Rows[i]["CCRQ"].ToString().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        zsy.CCBH = dt.Rows[i]["CCBH"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        zsy.TCRQ_GD = dt.Rows[i]["TCRQ"].ToString().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        zsy.SBXBH = dt.Rows[i]["SBXBH"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        zsy.SBZBH = dt.Rows[i]["SBZBH"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        zsy.SBZK = dt.Rows[i]["SBZK"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        zsy.DW = dt.Rows[i]["DW"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        zsy.SBSZWZ = dt.Rows[i]["SBSZWZ"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        zsy.DXSJ_GD = dt.Rows[i]["DXSJ"].ToString().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        zsy.BZ = dt.Rows[i]["BZ"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        zsy.ID = dt.Rows[i]["ID"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");


                        list.Add(zsy);
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

        public void ImportExcel_ZSY(HttpContext context)
        {
            string json = "";
            string Data = context.Request["Data"];
            List<LQ_SB_ZSY> list = JsonConvert.DeserializeObject<List<LQ_SB_ZSY>>(Data);
            json = Add_ZSY(list, context);
            json = JsonConvert.SerializeObject(json);
            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        public string Add_ZSY(List<LQ_SB_ZSY> SB_ZSY, HttpContext context)
        {
            string json = "";
            try
            {
                int error = 0;//错误数
                int number = 0;//记录成功数        
                for (int i = 0; i < SB_ZSY.Count; i++)
                {
                    if (sbglBLL.CheckZSY(SB_ZSY[i].ID) > 0)
                    {

                        if (sbglBLL.Update_ZSY(SB_ZSY[i]) == false)
                        {
                            error += 1;
                            continue;
                        }

                        number += 1;
                    }
                    else
                    {
                        //SB_ZSY[i].ID = Guid.NewGuid().ToString().ToUpper();
                        if (sbglBLL.Add_ZSY(SB_ZSY[i]) == false)
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

        #endregion

        #region-------------------工程参数仪导入-------------------------
        private void PreviewExcel_GCCSY(HttpContext context)
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
                dt.Columns["设备名称"].ColumnName = "SBMC";
                dt.Columns["规格型号"].ColumnName = "GGXH";
                dt.Columns["生产厂家"].ColumnName = "SCCJ";
                dt.Columns["国别"].ColumnName = "GB";
                dt.Columns["出厂日期"].ColumnName = "CCRQ";
                dt.Columns["出厂编号"].ColumnName = "CCBH";
                dt.Columns["投产日期"].ColumnName = "TCRQ";
                dt.Columns["设备现编号"].ColumnName = "SBXBH";
                dt.Columns["设备自编号"].ColumnName = "SBZBH";
                dt.Columns["设备状况"].ColumnName = "SBZK";
                dt.Columns["所属单位"].ColumnName = "DW";
                dt.Columns["设备所在位置"].ColumnName = "SBSZWZ";
                dt.Columns["大修时间"].ColumnName = "DXSJ";
                dt.Columns["备注"].ColumnName = "BZ";
                if (!dt.Columns.Contains("ID"))
                {
                    if (!dt.Columns.Contains("ID"))
                    {
                        dt.Columns.Add("ID");
                    }
                }

                List<LQ_SB_GCCSY> list = new List<LQ_SB_GCCSY>();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        LQ_SB_GCCSY gccsy = new LQ_SB_GCCSY();


                        gccsy.SBMC = dt.Rows[i]["SBMC"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        gccsy.GGXH = dt.Rows[i]["GGXH"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        gccsy.SCCJ = dt.Rows[i]["SCCJ"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        gccsy.GB = dt.Rows[i]["GB"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        gccsy.CCRQ_GD = dt.Rows[i]["CCRQ"].ToString().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        gccsy.CCBH = dt.Rows[i]["CCBH"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        gccsy.TCRQ_GD = dt.Rows[i]["TCRQ"].ToString().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        gccsy.SBXBH = dt.Rows[i]["SBXBH"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        gccsy.SBZBH = dt.Rows[i]["SBZBH"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        gccsy.SBZK = dt.Rows[i]["SBZK"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        gccsy.DW = dt.Rows[i]["DW"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        gccsy.SBSZWZ = dt.Rows[i]["SBSZWZ"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        gccsy.DXSJ_GD = dt.Rows[i]["DXSJ"].ToString().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        gccsy.BZ = dt.Rows[i]["BZ"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        gccsy.ID = dt.Rows[i]["ID"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        list.Add(gccsy);
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

        public void ImportExcel_GCCSY(HttpContext context)
        {
            string json = "";
            string Data = context.Request["Data"];
            List<LQ_SB_GCCSY> list = JsonConvert.DeserializeObject<List<LQ_SB_GCCSY>>(Data);
            json = Add_GCCSY(list, context);
            json = JsonConvert.SerializeObject(json);
            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        public string Add_GCCSY(List<LQ_SB_GCCSY> SB_GCCSY, HttpContext context)
        {
            string json = "";
            try
            {
                int error = 0;//错误数
                int number = 0;//记录成功数        
                for (int i = 0; i < SB_GCCSY.Count; i++)
                {
                    if (sbglBLL.CheckGCCSY(SB_GCCSY[i].ID) > 0)
                    {

                        if (sbglBLL.Update_GCCSY(SB_GCCSY[i]) == false)
                        {
                            error += 1;
                            continue;
                        }

                        number += 1;
                    }
                    else
                    {
                        //SB_GCCSY[i].ID = Guid.NewGuid().ToString().ToUpper();
                        if (sbglBLL.Add_GCCSY(SB_GCCSY[i]) == false)
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

        #endregion

        #region-------------------地化分析仪导入-------------------------
        private void PreviewExcel_DHFX(HttpContext context)
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
                dt.Columns["单位名称"].ColumnName = "DW";
                dt.Columns["设备名称"].ColumnName = "SBMC";
                dt.Columns["规格型号"].ColumnName = "GGXH";
                dt.Columns["生产厂家"].ColumnName = "SCCJ";
                dt.Columns["国别"].ColumnName = "GB";
                dt.Columns["出厂日期"].ColumnName = "CCRQ";
                dt.Columns["出厂编号"].ColumnName = "CCBH";
                dt.Columns["投产日期"].ColumnName = "TCRQ";
                dt.Columns["自编号"].ColumnName = "ZBH";
                dt.Columns["安装地点"].ColumnName = "SBSZWZ";
                dt.Columns["设备状况"].ColumnName = "SBZK";
                dt.Columns["所属单位"].ColumnName = "SSDW";
                dt.Columns["备注"].ColumnName = "BZ";
                if (!dt.Columns.Contains("ID"))
                {
                    dt.Columns.Add("ID");
                }

                List<LQ_SB_DHFX> list = new List<LQ_SB_DHFX>();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        LQ_SB_DHFX dhfx = new LQ_SB_DHFX();

                        dhfx.DW = dt.Rows[i]["DW"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        dhfx.SBMC = dt.Rows[i]["SBMC"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        dhfx.GGXH = dt.Rows[i]["GGXH"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        dhfx.SCCJ = dt.Rows[i]["SCCJ"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        dhfx.GB = dt.Rows[i]["GB"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        dhfx.CCRQ_GD = dt.Rows[i]["CCRQ"].ToString().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        dhfx.CCBH = dt.Rows[i]["CCBH"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        dhfx.TCRQ_GD = dt.Rows[i]["TCRQ"].ToString().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        dhfx.ZBH = dt.Rows[i]["ZBH"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        dhfx.SBSZWZ = dt.Rows[i]["SBSZWZ"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        dhfx.SBZK = dt.Rows[i]["SBZK"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        dhfx.SSDW = dt.Rows[i]["SSDW"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        dhfx.BZ = dt.Rows[i]["BZ"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        dhfx.ID = dt.Rows[i]["ID"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        list.Add(dhfx);
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

        public void ImportExcel_DHFX(HttpContext context)
        {
            string json = "";
            string Data = context.Request["Data"];
            List<LQ_SB_DHFX> list = JsonConvert.DeserializeObject<List<LQ_SB_DHFX>>(Data);
            json = Add_DHFX(list, context);
            json = JsonConvert.SerializeObject(json);
            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        public string Add_DHFX(List<LQ_SB_DHFX> SB_DHFX, HttpContext context)
        {
            string json = "";
            LQ_SB_DHFX model = new LQ_SB_DHFX();
            try
            {
                int error = 0;//错误数
                int number = 0;//记录成功数        
                for (int i = 0; i < SB_DHFX.Count; i++)
                {
                    if (sbglBLL.CheckDHFX(SB_DHFX[i].ID) > 0)
                    {

                        if (sbglBLL.Update_DHFX(SB_DHFX[i]) == false)
                        {
                            error += 1;
                            continue;
                        }

                        number += 1;
                    }
                    else
                    {
                        //SB_DHFX[i].ID = Guid.NewGuid().ToString().ToUpper();
                        if (sbglBLL.Add_DHFX(SB_DHFX[i]) == false)
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

        #endregion

        #region-------------------综合仪导入-------------------------
        private void PreviewExcel_ZHY(HttpContext context)
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
                dt.Columns["单位名称"].ColumnName = "DW";
                dt.Columns["设备名称"].ColumnName = "SBMC";
                dt.Columns["所属小队"].ColumnName = "SSXD";
                dt.Columns["资质"].ColumnName = "ZZ";
                dt.Columns["规格型号"].ColumnName = "GGXH";
                dt.Columns["生产厂家"].ColumnName = "SCCJ";
                dt.Columns["国别"].ColumnName = "GB";
                dt.Columns["出厂日期"].ColumnName = "CCRQ";
                dt.Columns["出厂编号"].ColumnName = "CCBH";
                dt.Columns["投产日期"].ColumnName = "TCRQ";
                dt.Columns["设备现编号"].ColumnName = "SBXBH";
                dt.Columns["设备自编号"].ColumnName = "SBZBH";
                dt.Columns["色谱型号"].ColumnName = "SP";
                dt.Columns["色谱分析周期"].ColumnName = "SPFXZQ";
                dt.Columns["设备状况"].ColumnName = "SBZK";
                dt.Columns["所属单位"].ColumnName = "SSDW";
                dt.Columns["设备所在位置"].ColumnName = "SBSZWZ";
                dt.Columns["大修时间"].ColumnName = "DXSJ";
                dt.Columns["硫化氢探头"].ColumnName = "LHQTT";
                dt.Columns["硫化氢年检"].ColumnName = "LHQNJ";
                dt.Columns["气体标样"].ColumnName = "QTBY";
                dt.Columns["备注"].ColumnName = "BZ";
                if (!dt.Columns.Contains("ID"))
                {
                    dt.Columns.Add("ID");
                }

                List<LQ_SB_ZHY> list = new List<LQ_SB_ZHY>();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        LQ_SB_ZHY zhy = new LQ_SB_ZHY();

                        zhy.DW = dt.Rows[i]["DW"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        zhy.SBMC = dt.Rows[i]["SBMC"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        zhy.SSXD = dt.Rows[i]["SSXD"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        zhy.ZZ = dt.Rows[i]["ZZ"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        zhy.GGXH = dt.Rows[i]["GGXH"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        zhy.SCCJ = dt.Rows[i]["SCCJ"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        zhy.GB = dt.Rows[i]["GB"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        zhy.CCRQ_GD = dt.Rows[i]["CCRQ"].ToString().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        zhy.CCBH = dt.Rows[i]["CCBH"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        zhy.TCRQ_GD = dt.Rows[i]["TCRQ"].ToString().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        zhy.SBXBH = dt.Rows[i]["SBXBH"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        zhy.SBZBH = dt.Rows[i]["SBZBH"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        zhy.SP = dt.Rows[i]["SP"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        zhy.SPFXZQ = 0;
                        if (!string.IsNullOrEmpty(dt.Rows[i]["SPFXZQ"].ToString()))
                        {
                            zhy.SPFXZQ = Convert.ToDecimal(dt.Rows[i]["SPFXZQ"]);
                        }

                        zhy.SBZK = dt.Rows[i]["SBZK"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", ""); ;
                        zhy.SSDW = dt.Rows[i]["SSDW"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", ""); ;
                        zhy.SBSZWZ = dt.Rows[i]["SBSZWZ"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", ""); ;
                        zhy.DXSJ_GD = dt.Rows[i]["DXSJ"].ToString().Replace("\r", "").Replace("\n", "").Replace("\t", ""); ;
                        zhy.LHQTT = dt.Rows[i]["LHQTT"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", ""); ;
                        zhy.LHQNJ = dt.Rows[i]["LHQNJ"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", ""); ;
                        zhy.QTBY = dt.Rows[i]["QTBY"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", ""); ;
                        zhy.BZ = dt.Rows[i]["BZ"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", ""); ;
                        zhy.ID = dt.Rows[i]["ID"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", ""); ;


                        list.Add(zhy);
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

        public void ImportExcel_ZHY(HttpContext context)
        {
            string json = "";
            string Data = context.Request["Data"];
            List<LQ_SB_ZHY> list = JsonConvert.DeserializeObject<List<LQ_SB_ZHY>>(Data);
            json = Add_ZHY(list, context);
            json = JsonConvert.SerializeObject(json);
            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        public string Add_ZHY(List<LQ_SB_ZHY> SB_ZSY, HttpContext context)
        {
            string json = "";
            try
            {
                int error = 0;//错误数
                int number = 0;//记录成功数        
                for (int i = 0; i < SB_ZSY.Count; i++)
                {
                    if (sbglBLL.CheckZHY(SB_ZSY[i].ID) > 0)
                    {

                        if (sbglBLL.Update_ZHY(SB_ZSY[i]) == false)
                        {
                            error += 1;
                            continue;
                        }

                        number += 1;
                    }
                    else
                    {
                        //SB_ZSY[i].ID = Guid.NewGuid().ToString().ToUpper();
                        if (sbglBLL.Add_ZHY(SB_ZSY[i]) == false)
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

        #endregion

        #region--------------------房屋导入--------------------------------------
        private void PreviewExcel_FW(HttpContext context)
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
                dt.Columns["项目部"].ColumnName = "LJFGS";
                dt.Columns["编号"].ColumnName = "CCBH";
                dt.Columns["型号"].ColumnName = "GGXH";
                dt.Columns["状况"].ColumnName = "SBZK";
                dt.Columns["所在位置"].ColumnName = "SBSZWZ";
                dt.Columns["备注"].ColumnName = "BZ";
                if (!dt.Columns.Contains("ID"))
                {
                    dt.Columns.Add("ID");
                }


                List<LQ_FW> list = new List<LQ_FW>();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        LQ_FW fw = new LQ_FW();

                        fw.LJFGS = dt.Rows[i]["LJFGS"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        fw.CCBH = dt.Rows[i]["CCBH"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        fw.GGXH = dt.Rows[i]["GGXH"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        fw.SBZK = dt.Rows[i]["SBZK"].ToString().Trim().Replace("\t", "");
                        fw.SBSZWZ = dt.Rows[i]["SBSZWZ"].ToString().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        fw.BZ = dt.Rows[i]["BZ"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        fw.ID = dt.Rows[i]["ID"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        list.Add(fw);
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

        public void ImportExcel_FW(HttpContext context)
        {
            string json = "";
            string Data = context.Request["Data"];
            List<LQ_FW> list = JsonConvert.DeserializeObject<List<LQ_FW>>(Data);
            json = Add_FW(list, context);
            json = JsonConvert.SerializeObject(json);
            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        public string Add_FW(List<LQ_FW> SB_FW, HttpContext context)
        {
            string json = "";
            try
            {
                string fl = context.Request["fl"];
                switch (fl)
                {
                    case "0":
                        fl = "地质房";
                        break;
                    case "1":
                        fl = "库房";
                        break;
                    case "2":
                        fl = "住房";
                        break;
                }
                int error = 0;//错误数
                int number = 0;//记录成功数        
                for (int i = 0; i < SB_FW.Count; i++)
                {
                    if (sbglBLL.CheckFW(SB_FW[i].ID, fl) > 0)
                    {

                        if (sbglBLL.Update_FW(SB_FW[i], fl) == false)
                        {
                            error += 1;
                            continue;
                        }

                        number += 1;
                    }
                    else
                    {
                        //SB_FW[i].ID = Guid.NewGuid().ToString().ToUpper();
                        SB_FW[i].TJRQ = DateTime.Now;
                        SB_FW[i].TJR = CFunctions.getUserId(context);
                        SB_FW[i].FL = fl;
                        if (sbglBLL.Add_FW(SB_FW[i]) == false)
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
        #endregion



        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}