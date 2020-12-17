using CrystalDecisions.Shared;
using LJZY.BLL.LQGL;
using LJZY.MODEL;
using LJZY.WEB.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LJZY.WEB.Page.DownLoad
{
    public partial class DownLoad : System.Web.UI.Page
    {
        private static string DB_KLRB = System.Configuration.ConfigurationManager.AppSettings["DB_KLRB"];
        private static string T_01 = System.Configuration.ConfigurationManager.AppSettings["T_01"];
        private static string T_61 = System.Configuration.ConfigurationManager.AppSettings["T_61"];
        private static string dtName1 = DB_KLRB + T_01;
        private static string dtName61 = DB_KLRB + T_61;
        LQ_RYSJKBLL _RYSJKBLL = new LQ_RYSJKBLL();
        LQ_SBGLBLL _SBGLBLL = new LQ_SBGLBLL();
        LQ_LJXMBLL _LJXMBLL = new LQ_LJXMBLL();
        LQ_GCJDBLL _GCJDBLL = new LQ_GCJDBLL();
        LQ_WJKPBLL _WJKPBLL = new LQ_WJKPBLL();
        private HttpContext context = HttpContext.Current;

        string Source = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Source = Request.QueryString["Source"];//导出页面值				
                btn_down_Click(null, null);
            }
        }

        protected void btn_down_Click(object sender, EventArgs e)
        {

            switch (Source.Trim())
            {
                //完井统计信息导出
                case "OutExportExcel_WJKP":
                    OutExportExcel_WJKP();
                    break;
                //人员管理人员信息导出
                case "OutExportExcel":
                    OutExportExcel();
                    break;
                case "RYRZ_ExportExcel":
                    RYRZ_ExportExcel();
                    break;
                //人员管理子表导出
                case "OutExportExcel_RYZB":
                    OutExportExcel_RYZB();
                    break;
                //设备车辆导出
                case "OutExportExcel_SBCL":
                    OutExportExcel_SBCL();
                    break;
                //卫星
                case "OutExportExcel_SBWX":
                    OutExportExcel_SBWX();
                    break;
                //钻时仪
                case "OutExportExcel_SBZSY":
                    OutExportExcel_SBZSY();
                    break;
                //工程参数仪
                case "OutExportExcel_SBGCCSY":
                    OutExportExcel_SBGCCSY();
                    break;
                //地化分析
                case "OutExportExcel_SBDHFX":
                    OutExportExcel_SBDHFX();
                    break;
                //综合仪
                case "OutExportExcel_SBZHY":
                    OutExportExcel_SBZHY();
                    break;
                //房屋
                case "OutExportExcel_FW":
                    OutExportExcel_FW();
                    break;
                case "OutExportExcel_SCDT":
                    OutExportExcel_SCDT();
                    break;
                case "OutExportExcel_RYSB":
                    OutExportExcel_RYSB();
                    break;
                case "OutExportExcel_LJXM":
                    OutExportExcel_LJXM();
                    break;
                case "OutExportExcel_GCJD":
                    OutExportExcel_GCJD();
                    break;
                    
            }

        }

        // 完井统计信息导出
        private void OutExportExcel_WJKP()
        {
            // 读取报表
            //string reportPath = System.Windows.Forms.Application.StartupPath + "\\Reports\\CrystalReport1.rpt";   // 相对路径，在IIS
            string reportPath = "D:\\fileCode\\VSworkspace\\LJZY\\LJZY.WEB\\Reports\\CrystalReport1.rpt";
            CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc =
                        new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            rptDoc.Load(reportPath);

            // 传入指定的井号
            string JH = Request.QueryString["JH"];
            rptDoc.SetDatabaseLogon("KLLOGT", "123456");
            rptDoc.SetParameterValue("井号", JH);

            // 打印该井号的报表
            rptDoc.PrintToPrinter(1, false, 0, 0);
        }

        // 人员管理信息导出
        private void OutExportExcel()
        {

            string str = Request.QueryString["str"];
            try
            {
                if (str == "undefined")
                {
                    str = "";
                }
                DataTable dt = _RYSJKBLL.EXCEL_RYSJK(str);
                if (dt.Rows.Count > 0)
                {

                    dt.TableName = "人员信息表";
                    dt.Columns["XMB"].ColumnName = "所属项目部";
                    dt.Columns["GW"].ColumnName = "岗位类别";
                    dt.Columns["RYBH"].ColumnName = "人员编号";
                    dt.Columns["XM"].ColumnName = "姓名";
                    dt.Columns["LXDH"].ColumnName = "联系电话";
                    dt.Columns["XB"].ColumnName = "性别";
                    dt.Columns["NL"].ColumnName = "年龄";
                    dt.Columns["XL"].ColumnName = "学历";
                    dt.Columns["YGXZ"].ColumnName = "用工性质";
                    dt.Columns["JKZK"].ColumnName = "健康状况";
                    dt.Columns["ZC"].ColumnName = "职称";
                    dt.Columns["GWXS"].ColumnName = "岗位系数";
                    //dt.Columns["RYZT"].ColumnName = "人员状态";
                    //dt.Columns["NDSJTS"].ColumnName = "年度上井天数";
                    //dt.Columns["JCZ"].ColumnName = "井控证";
                    //dt.Columns["HSE"].ColumnName = "安全环保健康证(HSE)";
                    //dt.Columns["SGZ"].ColumnName = "上岗证";
                    dt.Columns["BZ"].ColumnName = "备注";
                    dt.Columns.Remove("RYZT");
                    dt.Columns.Remove("JCZ");
                    dt.Columns.Remove("HSE");
                    dt.Columns.Remove("SGZ");
                    dt.Columns.Remove("TJR");
                    dt.Columns.Remove("TJSJ");
                    dt.Columns.Remove("TROW");
                    dt.Columns.Remove("SJJH");
                    dt.Columns.Remove("KSSJRQ");
                    dt.Columns.Remove("JSSJRQ");
                    dt.Columns.Remove("NDSJTS");
                    Response.Clear();
                    Response.BufferOutput = false;
                    Response.Buffer = true;
                    Response.Charset = Encoding.UTF8.BodyName;
                    Response.ContentEncoding = System.Text.Encoding.UTF8;
                    string filename = HttpUtility.UrlEncode(DateTime.Now.ToString("人员信息表yyyyMMdd"));
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + filename + ".xls");
                    Response.ContentType = "application/vnd.ms-excel; charset=UTF-8";
                    NPOIHelper.CreateSheet(dt, Response.OutputStream);
                    Response.End();
                    Response.Close();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void RYRZ_ExportExcel()
        {

            try
            {
                string strSql = "";
                string str = Request.QueryString["str"];
                
                if (!string.IsNullOrEmpty(str))
                {
                    strSql += str;
                }
                LQ_SCDTBLL scdtBLL = new LQ_SCDTBLL();

                DataTable dt = _RYSJKBLL.EXCEL_SJRZ(strSql, dtName1);

                if (dt.Rows.Count > 0)
                {
                    string[] arr = new string[] { "TROW", "XM", "JH", "REPORT_TYPE", "KSSJRQ", "JSSJRQ", "SJTS", "LJSJTS", "GWXS", "JXS", "BZ" };
                    NPOIHelper.ExportExcel(dt, "上井日志", 0, 1, arr);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void OutExportExcel_RYZB()
        {

            string str = Request.QueryString["str"];
            try
            {
                if (str == "undefined")
                {
                    str = "";
                }
                DataTable dt = _RYSJKBLL.EXCEL_RYSJK(str);
                if (dt.Rows.Count > 0)
                {

                    dt.TableName = "人员信息子表";
                    dt.Columns["TROW"].ColumnName = "序号";
                    dt.Columns["XM"].ColumnName = "姓名";
                    dt.Columns["KSSJRQ"].ColumnName = "开始上井日期";
                    dt.Columns["JSSJRQ"].ColumnName = "结束上井日期";
                    dt.Columns["SJTS"].ColumnName = "上井天数";
                    dt.Columns["NDSJTS"].ColumnName = "年度上井天数";
                    dt.Columns.Remove("ID");
                    dt.Columns.Remove("RYBH");
                    dt.Columns.Remove("ZJH");
                    Response.Clear();
                    Response.BufferOutput = false;
                    Response.Buffer = true;
                    Response.Charset = Encoding.UTF8.BodyName;
                    Response.ContentEncoding = System.Text.Encoding.UTF8;
                    string filename = HttpUtility.UrlEncode(DateTime.Now.ToString("人员信息子表yyyyMMdd"));
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + filename + ".xls");
                    Response.ContentType = "application/vnd.ms-excel; charset=UTF-8";
                    NPOIHelper.CreateSheet(dt, Response.OutputStream);
                    Response.End();
                    Response.Close();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void OutExportExcel_SBCL()
        {

            string str = Request.QueryString["str"];
            try
            {
                if (str == "undefined")
                {
                    str = "";
                }
                DataTable dt = _SBGLBLL.Excel_CL(str);
                if (dt.Rows.Count > 0)
                {

                    dt.TableName = "车辆设备信息表";
                    dt.Columns["TROW"].ColumnName = "序号";
                    dt.Columns["DW"].ColumnName = "单位名称";
                    dt.Columns["SBMC"].ColumnName = "设备名称";
                    dt.Columns["GGXH"].ColumnName = "规格型号";
                    dt.Columns["SCCJ"].ColumnName = "生产厂家";
                    dt.Columns["GB"].ColumnName = "国别";
                    dt.Columns["CCRQ"].ColumnName = "出厂日期";
                    dt.Columns["CCBH"].ColumnName = "出厂编号";
                    dt.Columns["TCRQ"].ColumnName = "投产日期";
                    dt.Columns["ZJNX"].ColumnName = "折旧年限";
                    dt.Columns["RLFL"].ColumnName = "燃料分类";
                    dt.Columns["SBZK"].ColumnName = "设备状况";
                    dt.Columns["SBSZWZ"].ColumnName = "使用地点";
                    dt.Columns["DXQK"].ColumnName = "大修情况";
                    dt.Columns["BZ"].ColumnName = "备注";
                    Response.Clear();
                    Response.BufferOutput = false;
                    Response.Buffer = true;
                    Response.Charset = Encoding.UTF8.BodyName;
                    Response.ContentEncoding = System.Text.Encoding.UTF8;
                    string filename = HttpUtility.UrlEncode(DateTime.Now.ToString("车辆设备信息表yyyyMMdd"));
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + filename + ".xls");
                    Response.ContentType = "application/vnd.ms-excel; charset=UTF-8";
                    NPOIHelper.CreateSheet(dt, Response.OutputStream);
                    Response.End();
                    Response.Close();
                }
            }
            catch (Exception ex)
            {

                throw;
            }



        }

        private void OutExportExcel_SBWX()
        {

            string str = Request.QueryString["str"];
            try
            {
                if (str == "undefined")
                {
                    str = "";
                }
                DataTable dt = _SBGLBLL.Excel_WX(str);
                if (dt.Rows.Count > 0)
                {

                    dt.TableName = "卫星设备信息表";
                    dt.Columns["TROW"].ColumnName = "序号";
                    dt.Columns["DW"].ColumnName = "单位名称";
                    dt.Columns["SBMC"].ColumnName = "设备名称";
                    dt.Columns["GGXH"].ColumnName = "规格型号";
                    dt.Columns["SCCJ"].ColumnName = "生产厂家";
                    dt.Columns["GB"].ColumnName = "国别";
                    dt.Columns["CCRQ"].ColumnName = "出厂日期";
                    dt.Columns["CCBH"].ColumnName = "出厂编号";
                    dt.Columns["TCRQ"].ColumnName = "投产日期";
                    dt.Columns["ZCBH"].ColumnName = "资产编号";
                    dt.Columns["ZBH"].ColumnName = "自编号";
                    dt.Columns["SBSZWZ"].ColumnName = "安装地点";
                    dt.Columns["SBZK"].ColumnName = "设备状况";
                    dt.Columns["BZ"].ColumnName = "备注";
                    Response.Clear();
                    Response.BufferOutput = false;
                    Response.Buffer = true;
                    Response.Charset = Encoding.UTF8.BodyName;
                    Response.ContentEncoding = System.Text.Encoding.UTF8;
                    string filename = HttpUtility.UrlEncode(DateTime.Now.ToString("卫星设备信息表yyyyMMdd"));
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + filename + ".xls");
                    Response.ContentType = "application/vnd.ms-excel; charset=UTF-8";
                    NPOIHelper.CreateSheet(dt, Response.OutputStream);
                    Response.End();
                    Response.Close();
                }
            }
            catch (Exception ex)
            {

                throw;
            }



        }

        private void OutExportExcel_SBZSY()
        {

            string str = Request.QueryString["str"];
            try
            {
                if (str == "undefined")
                {
                    str = "";
                }
                DataTable dt = _SBGLBLL.Excel_ZSY(str);
                if (dt.Rows.Count > 0)
                {

                    dt.TableName = "钻时仪设备信息表";
                    dt.Columns["TROW"].ColumnName = "序号";
                    dt.Columns["SBMC"].ColumnName = "设备名称";
                    dt.Columns["GGXH"].ColumnName = "规格型号";
                    dt.Columns["SCCJ"].ColumnName = "生产厂家";
                    dt.Columns["GB"].ColumnName = "国别";
                    dt.Columns["CCRQ"].ColumnName = "出厂日期";
                    dt.Columns["CCBH"].ColumnName = "出厂编号";
                    dt.Columns["TCRQ"].ColumnName = "投产日期";
                    dt.Columns["SBXBH"].ColumnName = "设备现编号";
                    dt.Columns["SBZBH"].ColumnName = "设备自编号";
                    dt.Columns["SBZK"].ColumnName = "设备状况";
                    dt.Columns["DW"].ColumnName = "所属单位";
                    dt.Columns["SBSZWZ"].ColumnName = "设备所在位置";
                    dt.Columns["DXSJ"].ColumnName = "大修时间";
                    dt.Columns["BZ"].ColumnName = "备注";
                    Response.Clear();
                    Response.BufferOutput = false;
                    Response.Buffer = true;
                    Response.Charset = Encoding.UTF8.BodyName;
                    Response.ContentEncoding = System.Text.Encoding.UTF8;
                    string filename = HttpUtility.UrlEncode(DateTime.Now.ToString("钻时仪设备信息表yyyyMMdd"));
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + filename + ".xls");
                    Response.ContentType = "application/vnd.ms-excel; charset=UTF-8";
                    NPOIHelper.CreateSheet(dt, Response.OutputStream);
                    Response.End();
                    Response.Close();
                }
            }
            catch (Exception ex)
            {

                throw;
            }



        }

        private void OutExportExcel_SBGCCSY()
        {

            string str = Request.QueryString["str"];
            try
            {
                if (str == "undefined")
                {
                    str = "";
                }
                DataTable dt = _SBGLBLL.Excel_GCCSY(str);
                if (dt.Rows.Count > 0)
                {

                    dt.TableName = "工程参数仪设备信息表";
                    dt.Columns["TROW"].ColumnName = "序号";
                    dt.Columns["SBMC"].ColumnName = "设备名称";
                    dt.Columns["GGXH"].ColumnName = "规格型号";
                    dt.Columns["SCCJ"].ColumnName = "生产厂家";
                    dt.Columns["GB"].ColumnName = "国别";
                    dt.Columns["CCRQ"].ColumnName = "出厂日期";
                    dt.Columns["CCBH"].ColumnName = "出厂编号";
                    dt.Columns["TCRQ"].ColumnName = "投产日期";
                    dt.Columns["SBXBH"].ColumnName = "设备现编号";
                    dt.Columns["SBZBH"].ColumnName = "设备自编号";
                    dt.Columns["SBZK"].ColumnName = "设备状况";
                    dt.Columns["DW"].ColumnName = "所属单位";
                    dt.Columns["SBSZWZ"].ColumnName = "设备所在位置";
                    dt.Columns["DXSJ"].ColumnName = "大修时间";
                    dt.Columns["BZ"].ColumnName = "备注";
                    Response.Clear();
                    Response.BufferOutput = false;
                    Response.Buffer = true;
                    Response.Charset = Encoding.UTF8.BodyName;
                    Response.ContentEncoding = System.Text.Encoding.UTF8;
                    string filename = HttpUtility.UrlEncode(DateTime.Now.ToString("工程参数仪设备信息表yyyyMMdd"));
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + filename + ".xls");
                    Response.ContentType = "application/vnd.ms-excel; charset=UTF-8";
                    NPOIHelper.CreateSheet(dt, Response.OutputStream);
                    Response.End();
                    Response.Close();
                }
            }
            catch (Exception ex)
            {

                throw;
            }



        }

        private void OutExportExcel_SBDHFX()
        {

            string str = Request.QueryString["str"];
            try
            {
                if (str == "undefined")
                {
                    str = "";
                }
                DataTable dt = _SBGLBLL.Excel_DHFX(str);
                if (dt.Rows.Count > 0)
                {

                    dt.TableName = "地化分析设备信息表";
                    dt.Columns["TROW"].ColumnName = "序号";
                    dt.Columns["DW"].ColumnName = "单位名称";
                    dt.Columns["SBMC"].ColumnName = "设备名称";
                    dt.Columns["GGXH"].ColumnName = "规格型号";
                    dt.Columns["SCCJ"].ColumnName = "生产厂家";
                    dt.Columns["GB"].ColumnName = "国别";
                    dt.Columns["CCRQ"].ColumnName = "出厂日期";
                    dt.Columns["CCBH"].ColumnName = "出厂编号";
                    dt.Columns["TCRQ"].ColumnName = "投产日期";
                    dt.Columns["ZBH"].ColumnName = "自编号";
                    dt.Columns["SBSZWZ"].ColumnName = "安装地点";
                    dt.Columns["SBZK"].ColumnName = "设备状况";
                    dt.Columns["SSDW"].ColumnName = "所属单位";
                    dt.Columns["BZ"].ColumnName = "备注";
                    Response.Clear();
                    Response.BufferOutput = false;
                    Response.Buffer = true;
                    Response.Charset = Encoding.UTF8.BodyName;
                    Response.ContentEncoding = System.Text.Encoding.UTF8;
                    string filename = HttpUtility.UrlEncode(DateTime.Now.ToString("地化分析设备信息表yyyyMMdd"));
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + filename + ".xls");
                    Response.ContentType = "application/vnd.ms-excel; charset=UTF-8";
                    NPOIHelper.CreateSheet(dt, Response.OutputStream);
                    Response.End();
                    Response.Close();
                }
            }
            catch (Exception ex)
            {

                throw;
            }



        }

        private void OutExportExcel_SBZHY()
        {

            string str = Request.QueryString["str"];
            try
            {
                if (str == "undefined")
                {
                    str = "";
                }
                DataTable dt = _SBGLBLL.Excel_ZHY(str);
                if (dt.Rows.Count > 0)
                {
                    dt.TableName = "综合仪(气测)设备信息表";
                    dt.Columns["TROW"].ColumnName = "序号";
                    dt.Columns["DW"].ColumnName = "单位名称";
                    dt.Columns["SBMC"].ColumnName = "设备名称";
                    dt.Columns["SSXD"].ColumnName = "所属小队";
                    dt.Columns["ZZ"].ColumnName = "资质";
                    dt.Columns["GGXH"].ColumnName = "规格型号";
                    dt.Columns["SCCJ"].ColumnName = "生产厂家";
                    dt.Columns["GB"].ColumnName = "国别";
                    dt.Columns["CCRQ"].ColumnName = "出厂日期";
                    dt.Columns["CCBH"].ColumnName = "出厂编号";
                    dt.Columns["TCRQ"].ColumnName = "投产日期";
                    dt.Columns["SBXBH"].ColumnName = "设备现编号";
                    dt.Columns["SBZBH"].ColumnName = "设备自编号";
                    dt.Columns["SP"].ColumnName = "色谱型号";
                    dt.Columns["SPFXZQ"].ColumnName = "色谱分析周期";
                    dt.Columns["SBZK"].ColumnName = "设备状况";
                    dt.Columns["SSDW"].ColumnName = "所属单位";
                    dt.Columns["SBSZWZ"].ColumnName = "设备所在位置";
                    dt.Columns["DXSJ"].ColumnName = "大修时间";
                    dt.Columns["LHQTT"].ColumnName = "硫化氢探头";
                    dt.Columns["LHQNJ"].ColumnName = "硫化氢年检";
                    dt.Columns["QTBY"].ColumnName = "气体标样";
                    dt.Columns["BZ"].ColumnName = "备注";
                    Response.Clear();
                    Response.BufferOutput = false;
                    Response.Buffer = true;
                    Response.Charset = Encoding.UTF8.BodyName;
                    Response.ContentEncoding = System.Text.Encoding.UTF8;
                    string filename = HttpUtility.UrlEncode(DateTime.Now.ToString("综合仪(气测)设备信息表yyyyMMdd"));
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + filename + ".xls");
                    Response.ContentType = "application/vnd.ms-excel; charset=UTF-8";
                    NPOIHelper.CreateSheet(dt, Response.OutputStream);
                    Response.End();
                    Response.Close();
                }
            }
            catch (Exception ex)
            {

                throw;
            }



        }

        private void OutExportExcel_FW()
        {

            string str = Request.QueryString["str"];
            string fl = Request.QueryString["fl"];
            string name = "";
            switch (fl)
            {
                case "0":
                    fl = "地质房";
                    name = fl;
                    break;
                case "1":
                    fl = "库房";
                    name = fl;
                    break;
                case "2":
                    fl = "住房";
                    name = fl;
                    break;
            }
            try
            {
                if (str == "undefined")
                {
                    str = "";
                }
                DataTable dt = _SBGLBLL.Excel_FW(str, fl);
                if (dt.Rows.Count > 0)
                {

                    dt.TableName = "" + name + "信息表";
                    dt.Columns["TROW"].ColumnName = "序号";
                    dt.Columns["LJFGS"].ColumnName = "项目部";
                    dt.Columns["CCBH"].ColumnName = "编号";
                    dt.Columns["GGXH"].ColumnName = "型号";
                    dt.Columns["SBZK"].ColumnName = "状况";
                    dt.Columns["SBSZWZ"].ColumnName = "所在位置";
                    dt.Columns["BZ"].ColumnName = "备注";
                    dt.Columns.Remove("FL");
                    Response.Clear();
                    Response.BufferOutput = false;
                    Response.Buffer = true;
                    Response.Charset = Encoding.UTF8.BodyName;
                    Response.ContentEncoding = System.Text.Encoding.UTF8;
                    string filename = HttpUtility.UrlEncode(DateTime.Now.ToString("" + name + "信息表yyyyMMdd"));
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + filename + ".xls");
                    Response.ContentType = "application/vnd.ms-excel; charset=UTF-8";
                    NPOIHelper.CreateSheet(dt, Response.OutputStream);
                    Response.End();
                    Response.Close();
                }
            }
            catch (Exception ex)
            {

                throw;
            }



        }

        private void OutExportExcel_SCDT()
        {
            try
            {
                string LJFGS = Request.QueryString["LJFGS"];
                string Time = Request.QueryString["Time"];
                string strSql = "";
                if (!string.IsNullOrEmpty(LJFGS))
                {
                    strSql += string.Format(" AND L.LJFGS='{0}'", LJFGS);
                }
                LQ_SCDTBLL scdtBLL = new LQ_SCDTBLL();

                DataTable dt = scdtBLL.excelSCDT(Time, strSql, dtName1, dtName61);

                if (dt.Rows.Count > 0)
                {

                    string[] arr = new string[] { "XQXMB", "TROW", "DWZBH", "LJYQXH", "ZJH", "LJDH", "SGDH", "XDT", "SJJS", "DRJS", "KZRQ", "KZRQ", "YJWJRQ", "HXJW", "HXJDH", "HXJW", "REPORT_TYPE", "LJFGS", "DQZT", "BZ" };
                    NPOIHelper.ExportExcel(dt, "生产动态统计", 0, 1, arr);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void OutExportExcel_LJXM()
        {
            try
            {
                string strSql = "";
                string str = Request.QueryString["str"];
                string REPORT_TYPE = Request.QueryString["REPORT_TYPE"];
                if (!string.IsNullOrEmpty(REPORT_TYPE))
                {
                    strSql += " AND REPORT_TYPE='" + REPORT_TYPE + "' ";
                }
                if (!string.IsNullOrEmpty(str))
                {
                    strSql += str;
                }
                LQ_SCDTBLL scdtBLL = new LQ_SCDTBLL();

                DataTable dt = _LJXMBLL.LJXMData(strSql, dtName1, dtName61);

                if (dt.Rows.Count > 0)
                {
                    string[] arr = new string[] { "ZJH", "JH", "SC3", "SC2", "JX", "REPORT_TYPE", "LJFGS", "QK", "GJ", "SJJS", "JSSJJS", "SCFL", "SC1", "DRJS", "SGZT", "DZJDXM", "DZJDZJH", "DZJDSSGS", "LJDWZZ", "ZJJDXM", "ZJJDZJH", "ZJJDSSGS", "LJDH", "LJYQXH", "YQZZ", "DWZBH", "DZS", "STARSTART", "STARAZR", "STAREND", "STARCCR", "SGDW", "SGDH", "YJBASJ", "SJBASJ", "BQJL", "HQSJ", "DQZT", "CHOUXIYOU", "HXJW", "HXJDH", "JDDT", "LSDW", "XMBJWXX", "LJXL", "XQXMB", "PGZDTS" };
                    NPOIHelper.ExportExcel(dt, "录井项目", 0, 1, arr);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void OutExportExcel_GCJD()
        {
            try
            {
                string strSql = "";
                string str = Request.QueryString["str"];
                string REPORT_TYPE = Request.QueryString["REPORT_TYPE"];
                if (!string.IsNullOrEmpty(REPORT_TYPE))
                {
                    strSql += " AND REPORT_TYPE='" + REPORT_TYPE + "' ";
                }
                if (!string.IsNullOrEmpty(str))
                {
                    strSql += str;
                }
                LQ_SCDTBLL scdtBLL = new LQ_SCDTBLL();

                DataTable dt = _GCJDBLL.GCJDData(strSql, dtName1, dtName61);

                if (dt.Rows.Count > 0)
                {
                    string[] arr = new string[] { "ZJH", "JH", "SC3", "SC2", "LJXL", "SJJS", "DRJS", "JX", "REPORT_TYPE", "QK", "SGZT", "DZLJKSJS", "DZLJKSSJ", "YXLJKSJS", "YXLJKSSJ", "QCLJKSJS", "QCLJKSSJ", "ZHLJKSJS", "ZHLJKSSJ", "JSSJJS", "WZJS", "SJWZYZ", "WZYJ", "SJZZB", "SJHZB", "DMHB", "BXG", "SGDW", "SGDH", "SGDDH", "LJFGS", "LJDH", "KZRQ", "WZRQ", "GJRQ", "WJRQ", "ZYMDC", "ZYMDC", "WJFF", "DYNZDJS", "DENZDJS", "SFJJYQXS", "SFQX", "SFJSYQC", "SFCXGCFZ", "CXGCFZLX", "GCFZCLSJ", "SFXYCTG", "LJYQXH", "STARSTART", "STAREND", "SFBF", "BFLX", "YJWJRQ", "BZ" };
                    NPOIHelper.ExportExcel(dt, "工程进度", 0, 1, arr);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void OutExportExcel_RYSB()
        {
            try
            {
                string LJFGS = context.Request["LJFGS"];
                string Time = context.Request["Time"];
                string strSql = "";
                if (!string.IsNullOrEmpty(LJFGS))
                {
                    strSql += string.Format(" AND L.LJFGS='{0}'", LJFGS);
                }
                LQ_RYSBBLL rysbBLL = new LQ_RYSBBLL();
                LQ_RSList dic = new LQ_RSList();
                dic = rysbBLL.RYSB_List(Time, strSql, dtName1, dtName61);
                Response.Clear();
                Response.BufferOutput = false;
                Response.Buffer = true;
                Response.Charset = Encoding.UTF8.BodyName;
                Response.ContentEncoding = System.Text.Encoding.UTF8;
                string filename = HttpUtility.UrlEncode(DateTime.Now.ToString("人员设备动态信息表yyyyMMdd"));
                Response.AddHeader("Content-Disposition", "attachment;filename=" + filename + ".xls");
                Response.ContentType = "application/vnd.ms-excel; charset=UTF-8";
                NPOIHelper.ExcelCreate_RYSB(Response.OutputStream, dic);
                Response.End();
                Response.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}