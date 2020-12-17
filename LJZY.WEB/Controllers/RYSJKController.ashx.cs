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
    /// RYSJKController 的摘要说明
    /// </summary>
    public class RYSJKController : IHttpHandler
    {
        private static string DB_KLRB = System.Configuration.ConfigurationManager.AppSettings["DB_KLRB"];
        private static string T_01 = System.Configuration.ConfigurationManager.AppSettings["T_01"];
        private static string T_61 = System.Configuration.ConfigurationManager.AppSettings["T_61"];
        private static string dtName1 = DB_KLRB + T_01;
        LQ_RYSJKBLL rysjkBLL = new LQ_RYSJKBLL();
        
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request["action"];
            switch (action)
            {
                //点击二级目录查询表格数据
                case "RYSJK_DataGrid": RYSJK_DataGrid(context); break;
                //人员日志查询
                case "SJRZ_DataGrid": SJRZ_DataGrid(context); break;
                //人员信息修改
                case "RYSJK_Update": RYSJK_Update(context); break;
                //人员信息删除
                case "RYSJK_Delete": RYSJK_Delete(context); break;
                //预览excel
                case "PreviewExcel": PreviewExcel(context); break;
                //首页
                case "RYSJK_Home": RYSJK_Home(context); break;
                //尾页
                case "RYSJK_End": RYSJK_End(context); break;
                //上一页
                case "RYSJK_Up": RYSJK_Up(context); break;
                //下一页
                case "RYSJK_Down": RYSJK_Down(context); break;
                    //导入
                case "ImportExcel":
                    ImportExcel(context);break;
                case "insertNDJZ":
                    //年度结转
                    insertNDJZ(context); break;
                case "FileUpload":
                    FileUpload(context); break;
                    
            }
        }


        private void RYSJK_Update(HttpContext context)
        {
            string json = "";
            try
            {
                LQ_RYSJK _RYSJK = new LQ_RYSJK();
                _RYSJK.ID = context.Request["ID"];
                _RYSJK.GW = context.Request["GW"];
                _RYSJK.RYBH = context.Request["RYBH"];
                _RYSJK.XM = context.Request["XM"];
                _RYSJK.LXDH = context.Request["LXDH"];
                _RYSJK.XB = context.Request["XB"];
                _RYSJK.NL = context.Request["NL"];
                _RYSJK.XL = context.Request["XL"];
                _RYSJK.JKZK = context.Request["JKZK"];
                _RYSJK.ZC = context.Request["ZC"];
                _RYSJK.NDSJTS = context.Request["NDSJTS"];
                _RYSJK.XMB = context.Request["XMB"];
                _RYSJK.RYZT = context.Request["RYZT"];
                _RYSJK.TJR = context.Request["TJR"];
                _RYSJK.BZ = context.Request["BZ"];
                _RYSJK.YGXZ = context.Request["YGXZ"];
                _RYSJK.SJJH = context.Request["SJJH"];
                if (!string.IsNullOrEmpty(context.Request["JSSJRQ"]))
                {
                    _RYSJK.JSSJRQ = Convert.ToDateTime(context.Request["JSSJRQ"]);
                }

                _RYSJK.GWXS = context.Request["GWXS"];
                LQ_JCZJSON _JCZJSON = new LQ_JCZJSON();
                _JCZJSON.ZJBH = context.Request["JCZBH"];
                _JCZJSON.YXQ = context.Request["JCZYXQ"];
                _JCZJSON.IMG = context.Request["JCZIMG"];

                string jsonStr1 = JsonConvert.SerializeObject(_JCZJSON);
                _RYSJK.JCZ =jsonStr1;
                LQ_SGZJSON _SGZJSON = new LQ_SGZJSON();
                _SGZJSON.ZJBH = context.Request["SGZBH"];
                _SGZJSON.YXQ = context.Request["SGZYXQ"];
                _SGZJSON.IMG = context.Request["SGZIMG"];
                string jsonStr2 = JsonConvert.SerializeObject(_SGZJSON);
                _RYSJK.SGZ = jsonStr2;
                LQ_HSEJSON _HSEJSON = new LQ_HSEJSON();
                _HSEJSON.ZJBH = context.Request["HSEBH"];
                _HSEJSON.YXQ = context.Request["HSEYXQ"];
                _HSEJSON.IMG = context.Request["HSEIMG"];
                string jsonStr3 = JsonConvert.SerializeObject(_HSEJSON);
                _RYSJK.HSE = jsonStr3;

                if (rysjkBLL.Update(_RYSJK))
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



        private void insertNDJZ(HttpContext context)
        {
            string json = "";
            try
            {
                string ID = context.Request["ID"];
                LQ_RYSJK _RYSJK = new LQ_RYSJK();
                _RYSJK.NDJZ = DateTime.Now.Year.ToString();
                if (rysjkBLL.ADDNDJZ(_RYSJK,ID))
                {
                    json = "{\"IsSuccess\":\"true\",\"Message\":\"修改成功！\"}";
                }
                else
                {
                    json = "{\"IsSuccess\":\"false\",\"Message\":\"数据异常！\"}";
                }
              

            }
            catch (Exception e)
            {
                json = "{\"IsSuccess\":\"false\",\"Message\":\"数据异常！\"}";
                throw;
            }
            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }



        private void RYSJK_Delete(HttpContext context)
        {
            string json = "";
            try
            {
                string ID = context.Request["ID"] ?? ""; //井号

                if (rysjkBLL.Del(ID))
                {
                    json = "{\"IsSuccess\":\"true\",\"Message\":\"删除成功！\"}";
                }
                else
                {
                    json = "{\"IsSuccess\":\"false\",\"Message\":\"删除失败！\"}";
                }
                //json = JsonConvert.SerializeObject(json);
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
        /// 员工信息分页查询
        /// </summary>
        /// <param name="context"></param>
        private void RYSJK_DataGrid(HttpContext context)
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
                dic = rysjkBLL.RYSJKDataGrid(strSql, rows, page);
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
        private void SJRZ_DataGrid(HttpContext context)
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
                dic = rysjkBLL.SJRZDataGrid(dtName1, strSql, rows, page);
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



        private void RYSJK_Home(HttpContext context)
        {
            string json = "";
            try
            {
                string RYBH = context.Request["RYBH"];
                int TROW = 1; //首页序号
                List<LQ_RYSJK> list = rysjkBLL.RYSJKInfo(TROW); //首页单井设计信息
                LQ_RYSJK model = new LQ_RYSJK();
               
                if (list.Count > 0)
                {
                    model = list[0];
                }

                json = JsonConvert.SerializeObject(model);
            }
            catch (Exception e)
            {
                json = " ";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }


        private void RYSJK_End(HttpContext context)
        {
            string json = "";
            try
            {

                string RYBH = context.Request["RYBH"];
                List<LQ_RYSJK> list = new List<LQ_RYSJK>();
                LQ_RYSJK model = new LQ_RYSJK();

                int TROW = rysjkBLL.COUNT_List(); //获取尾页序号
                if (TROW > 0)
                {
                    list = rysjkBLL.RYSJKInfo(TROW);
                }

                if (list.Count > 0)
                {
                    model = list[0];
                }

                json = JsonConvert.SerializeObject(model);
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


        private void RYSJK_Up(HttpContext context)
        {
            string json = "";
            try
            {
                string RYBH = context.Request["RYBH"];
                List<LQ_RYSJK> list_BH = new List<LQ_RYSJK>();
                List<LQ_RYSJK> list_TROW = new List<LQ_RYSJK>();
                LQ_RYSJK model = new LQ_RYSJK();
                string ID = context.Request["ID"];  //井号
                int TROW = 1; //起始页序号

                list_BH = rysjkBLL.RYSJKInfo_BH(ID);//当前页面信息
                if (list_BH.Count > 0)
                {
                    int row = list_BH[0].TROW;
                    row = row - 1;
                    if (row > 0)
                    {
                        TROW = row; //上页序号
                    }

                }

                list_TROW = rysjkBLL.RYSJKInfo(TROW);

                if (list_TROW.Count > 0)
                {
                    model = list_TROW[0];
                }
                json = JsonConvert.SerializeObject(model);
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


        private void RYSJK_Down(HttpContext context)
        {
            string json = "";
            try
            {
                string RYBH = context.Request["RYBH"];
                string ID = context.Request["ID"];//井号
                int TROW = rysjkBLL.COUNT_List();//当前页序号
                List<LQ_RYSJK> list_BH = new List<LQ_RYSJK>();
                List<LQ_RYSJK> list_TROW = new List<LQ_RYSJK>();
                LQ_RYSJK model = new LQ_RYSJK();
                list_BH = rysjkBLL.RYSJKInfo_BH(ID);//当前页面信息
                if (list_BH.Count > 0)
                {
                    int row = list_BH[0].TROW;
                    row = row + 1;
                    if (row < TROW)
                    {
                        TROW = row;  //下页序号
                    }

                }
                list_TROW = rysjkBLL.RYSJKInfo(TROW); //通过序号获取下页信息

                if (list_TROW.Count > 0)
                {
                    model = list_TROW[0];
                }
                json = JsonConvert.SerializeObject(model);
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
                DataTable dt = NPOIHelper.ExcelToDataTable(filePath, true);

                dt.Columns["所属项目部"].ColumnName = "XMB";
                dt.Columns["岗位类别"].ColumnName = "GW";
                dt.Columns["人员编号"].ColumnName = "RYBH";
                dt.Columns["姓名"].ColumnName = "XM";
                dt.Columns["联系电话"].ColumnName = "LXDH";
                dt.Columns["性别"].ColumnName = "XB";
                dt.Columns["年龄"].ColumnName = "NL";
                dt.Columns["学历"].ColumnName = "XL";
                dt.Columns["用工性质"].ColumnName = "YGXZ";
                dt.Columns["健康状况"].ColumnName = "JKZK";
                dt.Columns["职称"].ColumnName = "ZC";
                dt.Columns["岗位系数"].ColumnName = "GWXS";
                //dt.Columns["人员状态"].ColumnName = "RYZT";
                //dt.Columns["年度上井天数"].ColumnName = "NDSJTS";
                //dt.Columns["井控证"].ColumnName = "JCZ";
                //dt.Columns["安全环保健康证(HSE)"].ColumnName = "HSE";
                //dt.Columns["上岗证"].ColumnName = "SGZ";
                dt.Columns["备注"].ColumnName = "BZ";
                if (!dt.Columns.Contains("ID"))
                {
                    dt.Columns.Add("ID");
                }
                List<LQ_RYSJK> list = new List<LQ_RYSJK>();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        LQ_RYSJK ry = new LQ_RYSJK();
                        //ry.ID = Guid.NewGuid().ToString().ToUpper();
                        ry.XMB = dt.Rows[i]["XMB"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        ry.GW = dt.Rows[i]["GW"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        ry.RYBH = dt.Rows[i]["RYBH"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        ry.XM = dt.Rows[i]["XM"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        ry.LXDH = dt.Rows[i]["LXDH"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        ry.XB = dt.Rows[i]["XB"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        ry.NL = dt.Rows[i]["NL"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        ry.XL = dt.Rows[i]["XL"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        ry.YGXZ = dt.Rows[i]["YGXZ"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        ry.JKZK = dt.Rows[i]["JKZK"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        ry.ZC = dt.Rows[i]["ZC"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        ry.GWXS = dt.Rows[i]["GWXS"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        //ry.RYZT = dt.Rows[i]["RYZT"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        //ry.NDSJTS = dt.Rows[i]["NDSJTS"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        //ry.JCZ = dt.Rows[i]["JCZ"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        //ry.HSE = dt.Rows[i]["HSE"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        //ry.SGZ = dt.Rows[i]["SGZ"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        ry.BZ = dt.Rows[i]["BZ"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        ry.ID = dt.Rows[i]["ID"].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
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
            List<LQ_RYSJK> list = JsonConvert.DeserializeObject<List<LQ_RYSJK>>(Data);
            json = Add(list,context);
            json = JsonConvert.SerializeObject(json);
            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="vaList"></param>
        /// <returns></returns>
        public string Add(List<LQ_RYSJK> RYSJK, HttpContext context)
        {
            string json = "";
            LQ_RYSJK model = new LQ_RYSJK();
            try
            {
                int error = 0;//错误数
                int number = 0;//记录成功数
                foreach (LQ_RYSJK item in RYSJK)
                {
                    model.RYBH = item.RYBH;
                    model.GW = item.GW;
                    model.XM = item.XM;
                    model.LXDH = item.LXDH;
                    model.XB = item.XB;
                    model.NL = item.NL;
                    model.XL = item.XL;
                    model.YGXZ = item.YGXZ;
                    model.JKZK = item.JKZK;
                    model.ZC = item.ZC;
                    //model.JCZ = item.JCZ;
                    //model.SGZ = item.SGZ;
                   //model.NDSJTS = item.NDSJTS;
                    //model.HSE = item.HSE;
                    model.XMB = item.XMB;
                    model.RYZT = "待派";
                    model.GWXS = item.GWXS;
                    model.TJR = CFunctions.getUserId(context);
                    model.BZ = item.BZ;
                    if (rysjkBLL.CheckRY(model.RYBH) > 0)
                    {
                        
                        if (rysjkBLL.Update(model)==false)
                        {
                            error += 1;
                            continue;
                        }

                        number += 1;
                    }
                    else
                    {
                        //model.ID = Guid.NewGuid().ToString().ToUpper();
                        if (rysjkBLL.Add(model) == false)
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