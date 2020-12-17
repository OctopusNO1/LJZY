using LJZY.BLL.ColumnBLL;
using LJZY.BLL.LQGL;
using LJZY.MODEL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LJZY.WEB.Controllers
{
    /// <summary>
    /// ColumnListController 的摘要说明
    /// </summary>
    public class ColumnListController : IHttpHandler
    {
        ColumnBLL colBLL = new ColumnBLL();

        public static List<Category> catelist = new List<Category> { new Category { CODE = "ZJH", NAME = "井号" } };

        public static List<Category> catelist_sb = new List<Category> { new Category { CODE = "SBMC", NAME = "设备名称" } };

        public static List<Category> catelist_fw = new List<Category> { new Category { CODE = "LJFGS", NAME = "项目部" } };

        public static List<Category> catelist_ry = new List<Category> { new Category { CODE = "XM", NAME = "姓名" } };

        public static List<Category> catelist_ryzb = new List<Category> { new Category { CODE = "XM", NAME = "姓名" } };


        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request["action"];
            switch (action)
            {
                //甲方单位下拉列表
                case "List_SC3":
                    List_SC3(context);
                    break;
                //地区下拉列表
                case "List_SC2":
                    List_SC2(context);
                    break;
                //井型下拉列表
                case "List_JX":
                    List_JX(context);
                    break;
                //井别下拉列表
                case "List_TYPE":
                    List_TYPE(context);
                    break;
                //区块下拉列表
                case "List_QK":
                    List_QK(context);
                    break;
                //录井项目部下拉列表
                case "List_LJFGS":
                    List_LJFGS(context);
                    break;
                //国家下拉数据
                case "List_GJ":
                    List_GJ(context);
                    break;
                //市场类型下拉数据
                case "List_SCFL":
                    List_SCFL(context);
                    break;
                //一级市场下拉数据
                case "List_SC1":
                    List_SC1(context);
                    break;
                //辖区项目部下拉数据
                case "List_XQXMB":
                    List_XQXMB(context);
                    break;
                //地质监督所属公司下拉数据
                case "List_DZJDSSGS":
                    List_DZJDSSGS(context);
                    break;
                //钻井监督所属公司下拉数据
                case "List_ZJJDSSGS":
                    List_ZJJDSSGS(context);
                    break;
                //录井队号下拉数据
                case "List_LJDH":
                    List_LJDH(context);
                    break;
                //设备型号下拉数据
                case "List_LJYQXH":
                    List_LJYQXH(context);
                    break;
                //当前状态下拉数据
                case "List_DQZT":
                    List_DQZT(context);
                    break;
                //稠油/稀油下拉数据
                case "List_CHOUXIYOU":
                    List_CHOUXIYOU(context);
                    break;
                //后续井位下拉数据
                case "List_HXJW":
                    List_HXJW(context);
                    break;
                //后续井队号下拉数据
                case "List_HXJDH":
                    List_HXJDH(context);
                    break;
                //井队动态下拉数据
                case "List_JDDT":
                    List_JDDT(context);
                    break;
                //隶属单位下拉数据
                case "List_LSDW":
                    List_LSDW(context);
                    break;
                //项目部井位信息下拉数据
                case "List_XMBJWXX":
                    List_XMBJWXX(context);
                    break;
                //录井系列下拉数据
                case "List_LJXL":
                    List_LJXL(context);
                    break;
                //字段下拉列表
                case "Column_List":
                    Column_List(context);
                    break;
                //运算符号下拉列表
                case "Symbol_List":
                    Symbol_List(context);
                    break;
                //二级目录树列表
                case "EJML_List":
                    EJML_List(context);
                    break;
                //年度下拉列表
                case "YL":
                    YL(context);
                    break;
                //单井设计下拉条件字段
                case "DJSJ_ZD":
                    DJSJ_ZD(context);
                    break;
                //录井项目下拉条件字段
                case "LJXM_ZD":
                    LJXM_ZD(context);
                    break;
                //工程进度下拉条件字段
                case "GCJD_ZD":
                    GCJD_ZD(context);
                    break;
                //单井策划应急预案QHSE作业计划书下拉条件字段
                case "DJCHYAQHSE_ZD":
                    DJCHYAQHSE_ZD(context);
                    break;
                //人员管理下拉条件字段
                case "RYGL_ZD":
                    RYGL_ZD(context);
                    break;
                //车辆设备下拉条件字段
                case "CL_ZD":
                    CL_ZD(context);
                    break;
                //卫星设备下拉条件字段
                case "WX_ZD":
                    WX_ZD(context);
                    break;
                //钻时仪设备下拉条件字段
                case "ZSY_ZD":
                    ZSY_ZD(context);
                    break;
                //工程参数仪设备下拉条件字段
                case "GCCSY_ZD":
                    GCCSY_ZD(context);
                    break;
                //地化分析设备下拉条件字段
                case "DHFX_ZD":
                    GCCSY_ZD(context);
                    break;
                //综合仪设备下拉条件字段
                case "ZHY_ZD":
                    ZHY_ZD(context);
                    break;
                //房屋下拉条件字段
                case "FW_ZD":
                    FW_ZD(context);
                    break;
                //设备管理选择字段
                case "getZD_SBGL":
                    getZD_SBGL(context);
                    break;
                //房屋选择字段
                case "getZD_FW":
                    getZD_FW(context);
                    break;
                case "getZD_RYGL":
                    getZD_RYGL(context);
                    break;

                case "getZD_RYGLZB":
                    getZD_RYGLZB(context);
                    break;

                //设计上传_井型下拉列表
                case "JX_UpList":
                    JX_UpList(context);
                    break;
                //设计上传_井别下拉列表
                case "TYPE_UpList":
                    TYPE_UpList(context);
                    break;
                //施工单位下拉数据
                case "List_SGDW":
                    List_SGDW(context);
                    break;
                //施工队号下拉数据
                case "List_SGDH":
                    List_SGDH(context);
                    break;
                //性别
                case "List_XB":
                    List_XB(context);
                    break;
                //学历
                case "List_XL":
                    List_XL(context);
                    break;
                //用工性质
                case "List_YGXZ":
                    List_YGXZ(context);
                    break;
                //健康状况
                case "List_JKZK":
                    List_JKZK(context);
                    break;
                //职称
                case "List_ZC":
                    List_ZC(context);
                    break;
                //人员状态
                case "List_RYZT":
                    List_RYZT(context);
                    break;
                //岗位类别
                case "List_GWLB":
                    List_GWLB(context);
                    break;
                //派工岗位
                case "List_XMBGW":
                    List_XMBGW(context);
                    break;
                //人员条件下拉列表
                case "List_RYTJ":
                    List_RYTJ(context);
                    break;
                //设备分类下拉列表
                case "List_SBFL":
                    List_SBFL(context);
                    break;
                //设备条件下拉列表
                case "List_SBTJ":
                    List_SBTJ(context);
                    break;
                //完井方法
                case "List_WJFF":
                    List_WJFF(context);
                    break;
                //工程复杂类型
                case "List_GCFZLX":
                    List_GCFZLX(context);
                    break;
                //中停类型下拉列表
                case "List_ZTLX":
                    List_ZTLX(context);
                    break;
                //报废类型下拉列表
                case "List_BFLX":
                    List_BFLX(context);
                    break;
                //设备型号下拉列表
                case "List_SBXH":
                    List_SBXH(context);
                    break;


            }

        }


        /// <summary>
        /// 甲方单位下拉列表
        /// </summary>
        /// <param name="context"></param>
        private void List_SC3(HttpContext context)
        {
            string json = "";
            try
            {
                List<Sys_Dictionary> list = new List<Sys_Dictionary>();
                list = colBLL.List_SC3();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"Code\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 地区下拉列表
        /// </summary>
        /// <param name="context"></param>
        private void List_SC2(HttpContext context)
        {
            string json = "";
            try
            {
                List<Sys_Dictionary> list = new List<Sys_Dictionary>();
                list = colBLL.List_SC2();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"NAME\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 井型下拉列表
        /// </summary>
        /// <param name="context"></param>
        private void List_JX(HttpContext context)
        {
            string json = "";
            try
            {
                List<Sys_Dictionary> list = new List<Sys_Dictionary>();
                list = colBLL.List_JX();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }
        /// <summary>
        /// 井别下拉列表
        /// </summary>
        /// <param name="context"></param>
        private void List_TYPE(HttpContext context)
        {
            string json = "";
            try
            {
                List<Sys_Dictionary> list = new List<Sys_Dictionary>();
                list = colBLL.List_TYPE();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }
        /// <summary>
        /// 区块下拉列表
        /// </summary>
        /// <param name="context"></param>
        private void List_QK(HttpContext context)
        {
            string json = "";
            try
            {
                List<Sys_Dictionary> list = new List<Sys_Dictionary>();
                list = colBLL.List_QK();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 录井项目部下拉列表
        /// </summary>
        /// <param name="context"></param>
        private void List_LJFGS(HttpContext context)
        {
            string json = "";
            try
            {
                List<Sys_Dictionary> list = new List<Sys_Dictionary>();
                list = colBLL.List_LJFGS();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 国家下拉列表
        /// </summary>
        /// <param name="context"></param>
        private void List_GJ(HttpContext context)
        {
            string json = "";
            try
            {
                List<Sys_Dictionary> list = new List<Sys_Dictionary>();
                list = colBLL.List_GJ();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 市场类型下拉列表
        /// </summary>
        /// <param name="context"></param>
        private void List_SCFL(HttpContext context)
        {
            string json = "";
            try
            {
                List<Sys_Dictionary> list = new List<Sys_Dictionary>();
                list = colBLL.List_SCFL();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 一级市场下拉数据
        /// </summary>
        /// <param name="context"></param>
        private void List_SC1(HttpContext context)
        {
            string json = "";
            try
            {
                List<Sys_Dictionary> list = new List<Sys_Dictionary>();
                list = colBLL.List_SC1();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 辖区项目部下拉列表
        /// </summary>
        /// <param name="context"></param>
        private void List_XQXMB(HttpContext context)
        {
            string json = "";
            try
            {
                List<Sys_Dictionary> list = new List<Sys_Dictionary>();
                list = colBLL.List_XQXMB();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 地质监督所属公司下拉数据
        /// </summary>
        /// <param name="context"></param>
        private void List_DZJDSSGS(HttpContext context)
        {
            string json = "";
            try
            {
                List<Sys_Dictionary> list = new List<Sys_Dictionary>();

                list = colBLL.List_DZJDSSGS();
                if (list.Count == 0)
                {
                    Sys_Dictionary model = new Sys_Dictionary();
                    model.NAME = "暂无数据";
                    model.CODE = "暂无数据";
                    list.Add(model);
                }

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        ///  钻井监督所属公司下拉数据
        /// </summary>
        /// <param name="context"></param>
        private void List_ZJJDSSGS(HttpContext context)
        {
            string json = "";
            try
            {
                List<Sys_Dictionary> list = new List<Sys_Dictionary>();
                list = colBLL.List_ZJJDSSGS();
                if (list.Count == 0)
                {
                    Sys_Dictionary model = new Sys_Dictionary();
                    model.NAME = "暂无数据";
                    model.CODE = "暂无数据";
                    list.Add(model);
                }
                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 录井队号下拉数据
        /// </summary>
        /// <param name="context"></param>
        private void List_LJDH(HttpContext context)
        {
            string json = "";
            try
            {
                List<Sys_Dictionary> list = new List<Sys_Dictionary>();
                list = colBLL.List_LJDH();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 设备型号下拉数据
        /// </summary>
        /// <param name="context"></param>
        private void List_LJYQXH(HttpContext context)
        {
            string json = "";
            try
            {
                List<Sys_Dictionary> list = new List<Sys_Dictionary>();
                list = colBLL.List_LJYQXH();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();


        }

        /// <summary>
        /// 当前状态下拉数据
        /// </summary>
        /// <param name="context"></param>
        private void List_DQZT(HttpContext context)
        {
            string json = "";
            try
            {
                List<Sys_Dictionary> list = new List<Sys_Dictionary>();
                list = colBLL.List_DQZT();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 稠油/稀油下拉数据
        /// </summary>
        /// <param name="context"></param>
        private void List_CHOUXIYOU(HttpContext context)
        {
            string json = "";
            try
            {
                List<Sys_Dictionary> list = new List<Sys_Dictionary>();
                list = colBLL.List_CHOUXIYOU();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 后续井位下拉数据
        /// </summary>
        /// <param name="context"></param>
        private void List_HXJW(HttpContext context)
        {
            string json = "";
            try
            {
                List<Sys_Dictionary> list = new List<Sys_Dictionary>();
                list = colBLL.List_HXJW();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 后续井队号下拉数据
        /// </summary>
        /// <param name="context"></param>
        private void List_HXJDH(HttpContext context)
        {
            string json = "";
            try
            {
                List<Sys_Dictionary> list = new List<Sys_Dictionary>();
                list = colBLL.List_HXJDH();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 井队动态下拉数据
        /// </summary>
        /// <param name="context"></param>
        private void List_JDDT(HttpContext context)
        {
            string json = "";
            try
            {
                List<Sys_Dictionary> list = new List<Sys_Dictionary>();
                list = colBLL.List_JDDT();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 隶属单位下拉数据
        /// </summary>
        /// <param name="context"></param>
        private void List_LSDW(HttpContext context)
        {
            string json = "";
            try
            {
                List<Sys_Dictionary> list = new List<Sys_Dictionary>();
                list = colBLL.List_LSDW();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 项目部井位信息下拉数据
        /// </summary>
        /// <param name="context"></param>
        private void List_XMBJWXX(HttpContext context)
        {
            string json = "";
            try
            {
                List<Sys_Dictionary> list = new List<Sys_Dictionary>();
                list = colBLL.List_XMBJWXX();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 录井系列下拉数据
        /// </summary>
        /// <param name="context"></param>
        private void List_LJXL(HttpContext context)
        {
            string json = "";
            try
            {
                List<Sys_Dictionary> list = new List<Sys_Dictionary>();
                list = colBLL.List_LJXL();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 施工单位下拉数据
        /// </summary>
        /// <param name="context"></param>
        private void List_SGDW(HttpContext context)
        {
            string json = "";
            try
            {
                List<Sys_Dictionary> list = new List<Sys_Dictionary>();
                list = colBLL.List_SGDW();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 施工队号下拉数据
        /// </summary>
        /// <param name="context"></param>
        private void List_SGDH(HttpContext context)
        {
            string json = "";
            try
            {
                List<Sys_Dictionary> list = new List<Sys_Dictionary>();
                list = colBLL.List_SGDH();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 二级目录菜单
        /// </summary>
        /// <param name="context"></param>
        private void EJML_List(HttpContext context)
        {
            string json = "";
            try
            {
                List<LQ_EJML> list = new List<LQ_EJML>();
                list = colBLL.EJMLList();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }


        /// <summary>
        /// 字段下拉列表
        /// </summary>
        /// <param name="context"></param>
        private void Column_List(HttpContext context)
        {
            string json = "";
            try
            {
                List<Category> list = DJSJ_CategoryList();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 运算符号下拉列表
        /// </summary>
        /// <param name="context"></param>
        private void Symbol_List(HttpContext context)
        {
            string json = "";
            try
            {
                List<Category> list = SymbolList();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 设计上传-井型下拉列表
        /// </summary>
        /// <param name="context"></param>
        private void JX_UpList(HttpContext context)
        {
            string json = "";
            try
            {
                List<Category> list = JX_List();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 设计上传-井别下拉列表
        /// </summary>
        /// <param name="context"></param>
        private void TYPE_UpList(HttpContext context)
        {
            string json = "";
            try
            {
                List<Category> list = TYPE_List();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 人员条件列表
        /// </summary>
        /// <param name="context"></param>
        private void List_RYTJ(HttpContext context)
        {
            string json = "";
            try
            {
                List<Category> list = RYTJ_List();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 设备分类列表
        /// </summary>
        /// <param name="context"></param>
        private void List_SBFL(HttpContext context)
        {
            string json = "";
            try
            {
                List<Category> list = SBFL_List();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 设备条件下拉列表
        /// </summary>
        /// <param name="context"></param>
        private void List_SBTJ(HttpContext context)
        {
            string json = "";
            try
            {
                List<Category> list = SBTJ_List();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 完井方法列表
        /// </summary>
        /// <param name="context"></param>
        private void List_WJFF(HttpContext context)
        {
            string json = "";
            try
            {
                List<Category> list = WJFF_List();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 工程复杂类型
        /// </summary>
        /// <param name="context"></param>
        private void List_GCFZLX(HttpContext context)
        {
            string json = "";
            try
            {
                List<Category> list = GCFZLX_List();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 报废类型列表
        /// </summary>
        /// <param name="context"></param>
        private void List_BFLX(HttpContext context)
        {
            string json = "";
            try
            {
                List<Category> list = BFLX_List();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 中停类型下拉列表
        /// </summary>
        /// <param name="context"></param>
        private void List_ZTLX(HttpContext context)
        {
            string json = "";
            try
            {
                List<Category> list = ZTLX_List();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// 设备型号下拉列表
        /// </summary>
        /// <param name="context"></param>
        private void List_SBXH(HttpContext context)
        {
            string json = "";
            try
            {
                List<Category> list = SBXH_List();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"CODE\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        ///	完井方法列表
        /// </summary>
        /// <returns></returns>
        public List<Category> WJFF_List()
        {

            List<Category> categories = new List<Category>{
                                            new Category{ CODE="套管完井",NAME="套管完井"},
                                            new Category{ CODE="筛管完井",NAME="筛管完井"},
                                            new Category{ CODE="尾管完井",NAME="尾管完井"},
                                            new Category{ CODE="事故完井",NAME="事故完井"},
                                            new Category{ CODE="后期裸眼",NAME="后期裸眼"},
                                            new Category{ CODE="先期裸眼",NAME="先期裸眼"}
                                        };
            return categories;

        }

        /// <summary>
        /// 工程复杂类型列表
        /// </summary>
        /// <returns></returns>
        public List<Category> GCFZLX_List()
        {

            List<Category> categories = new List<Category>{
                                            new Category{ CODE="井漏",NAME="井漏"},
                                            new Category{ CODE="溢流",NAME="溢流"},
                                            new Category{ CODE="钻具刺",NAME="钻具刺"},
                                            new Category{ CODE="钻头磨损",NAME="钻头磨损"},
                                            new Category{ CODE="泵刺",NAME="泵刺"},
                                            new Category{ CODE="钻具断",NAME="钻具断"},
                                            new Category{ CODE="遇阻卡",NAME="遇阻卡"},
                                            new Category{ CODE="硫化氢",NAME="硫化氢"},
                                            new Category{ CODE="其他",NAME="其他"}
                                        };
            return categories;

        }

        /// <summary>
        /// 报废类型列表
        /// </summary>
        /// <returns></returns>
        public List<Category> BFLX_List()
        {

            List<Category> categories = new List<Category>{
                                            new Category{ CODE="地质报废",NAME="地质报废"},
                                            new Category{ CODE="工程报废",NAME="工程报废"}
                                        };
            return categories;

        }

        /// <summary>
        /// 中停类型
        /// </summary>
        /// <returns></returns>
        public List<Category> ZTLX_List()
        {

            List<Category> categories = new List<Category>{
                                            new Category{ CODE="冬休",NAME="冬休"},
                                            new Category{ CODE="等设备",NAME="等设备"},
                                            new Category{ CODE="同平台井",NAME="同平台井"}
                                        };
            return categories;

        }

        /// <summary>
        /// 设备型号
        /// </summary>
        /// <returns></returns>
        public List<Category> SBXH_List()
        {

            List<Category> categories = new List<Category>{
                                            new Category{ CODE="DLS-405F",NAME="DLS-405F"},
                                            new Category{ CODE="DLS-405快",NAME="DLS-405快"}
                                        };
            return categories;

        }

        //public List<Category> Status_List()
        //{

        //	List<Category> categories = new List<Category>{
        //									new Category{ CODE="预探井",NAME="预探井"},
        //									new Category{ CODE="评价井",NAME="评价井"},
        //									new Category{ CODE="开发井",NAME="开发井"}
        //								};
        //	return categories;

        //}

        /// <summary>
        /// 单井设计字段下拉列表
        /// </summary>
        /// <returns></returns>
        public List<Category> DJSJ_CategoryList()
        {

            List<Category> categories = new List<Category>{
                                            new Category{ CODE="ZJH",NAME="井号"},
                                            new Category{ CODE="SC3",NAME="甲方单位"},
                                            new Category{ CODE="SC2",NAME="地区"},
                                            new Category{ CODE="QK",NAME="区块"},
                                            new Category{ CODE="REPORT_TYPE",NAME="井别"},
                                            new Category{ CODE="JX",NAME="井型"},
                                            new Category{ CODE="JH",NAME="井筒号"},
                                            //new Category{ CODE="LJXL",NAME="录井系列"},
                                            new Category{ CODE="SJJS",NAME="设计井深"},
                                            new Category{ CODE="JSSJJS",NAME="加深设计井深"},
                                            new Category{ CODE="WZJS",NAME="完钻井深"},
                                            new Category{ CODE="DLWZ",NAME="地理位置"},
                                            new Category{ CODE="GZWZ",NAME="构造位置"},
                                            new Category{ CODE="CXWZ",NAME="测线位置"},
                                            new Category{ CODE="SJZZBB",NAME="设计纵坐标(北京)"},
                                            new Category{ CODE="SJHZBB",NAME="设计横坐标(北京)"},
                                            new Category{ CODE="SJZZBX",NAME="设计纵坐标(西安)"},
                                            new Category{ CODE="SJHZBX",NAME="设计横坐标(西安)"},
                                            new Category{ CODE="SJZZB",NAME="实测纵坐标"},
                                            new Category{ CODE="SJHZB",NAME="实测横坐标"},
                                            new Category{ CODE="DMHB",NAME="地面海拔"},
                                            new Category{ CODE="BXG",NAME="补心高"},
                                            new Category{ CODE="ZYMDC",NAME="目的层"},
                                            new Category{ CODE="SJR",NAME="设计人"},
                                            new Category{ CODE="SPR",NAME="审批人"},
                                            new Category{ CODE="SJRQ",NAME="设计日期"},
                                            new Category{ CODE="SPRQ",NAME="审批日期"},
                                            //new Category{ CODE="TJRQ",NAME="添加时间"},
                                            new Category{ CODE="BZ",NAME="备注"},
                                            new Category{ CODE="LJFGS",NAME="录井项目部"}
                                            //new Category{ CODE="BZR",NAME="编制人"},
                                            //new Category{ CODE="BZRQ",NAME="编制日期"}
                                        };
            return categories;

        }

        /// <summary>
        /// 录井项目条件下拉字段
        /// </summary>
        /// <returns></returns>
        public List<Category> LJXM_CategoryList()
        {

            List<Category> categories = new List<Category>{
                                            new Category{ CODE="ZJH",NAME="井号"},
                                            new Category{ CODE="SC3",NAME="甲方单位"},
                                            new Category{ CODE="SC2",NAME="地区"},
                                            new Category{ CODE="QK",NAME="区块"},
                                            new Category{ CODE="REPORT_TYPE",NAME="井别"},
                                            new Category{ CODE="JX",NAME="井型"},
                                            new Category{ CODE="JH",NAME="井筒号"},
                                            new Category{ CODE="LJXL",NAME="录井系列"},
                                            new Category{ CODE="SJJS",NAME="设计井深"},
                                            new Category{ CODE="JSSJJS",NAME="加深设计井深"},
                                            new Category{ CODE="SCFL",NAME="市场类型"},
                                            new Category{ CODE="GJ",NAME="国家"},
                                            new Category{ CODE="SC1",NAME="一级市场"},
                                            new Category{ CODE="DZJDXM",NAME="地质监督姓名"},
                                            new Category{ CODE="DZJDZJH",NAME="地质监督证件号"},
                                            new Category{ CODE="DZJDSSGS",NAME="地质监督所属公司"},
                                            new Category{ CODE="ZJJDXM",NAME="钻井监督姓名"},
                                            new Category{ CODE="ZJJDZJH",NAME="钻井监督证件号"},
                                            new Category{ CODE="ZJJDSSGS",NAME="钻井监督所属公司"},
                                            new Category{ CODE="LJFGS",NAME="录井项目部"},
                                            new Category{ CODE="LJDWZZ",NAME="录井资质"},
                                            new Category{ CODE="LJDH",NAME="录井队号"},
                                            new Category{ CODE="LJYQXH",NAME="设备型号"},
                                            new Category{ CODE="YQZZ",NAME="仪器资质"},
                                            new Category{ CODE="DWZBH",NAME="队伍自编号"},
                                            new Category{ CODE="DZS",NAME="地质师"},
                                            new Category{ CODE="STARSTART",NAME="装卫星时间"},
                                            new Category{ CODE="STARAZR",NAME="安装卫星人"},
                                            new Category{ CODE="STAREND",NAME="拆卫星时间"},
                                            new Category{ CODE="STARCCR",NAME="拆卫星人"},
                                            new Category{ CODE="SGDW",NAME="施工单位"},
                                            new Category{ CODE="SGDH",NAME="施工队号"},
                                            new Category{ CODE="YJBASJ",NAME="预计搬安时间"},
                                            new Category{ CODE="SJBASJ",NAME="实际搬安时间"},
                                            new Category{ CODE="BQJL",NAME="搬迁距离"},
                                            new Category{ CODE="HQSJ",NAME="回迁时间"},
                                            new Category{ CODE="DQZT",NAME="当前状态"},
                                            new Category{ CODE="CHOUXIYOU",NAME="稠油/稀油"},
                                            new Category{ CODE="HXJW",NAME="后续井位"},
                                            new Category{ CODE="HXJDH",NAME="后续井队号"},
                                            new Category{ CODE="JDDT",NAME="井队动态"},
                                            new Category{ CODE="LSDW",NAME="隶属单位"},
                                            new Category{ CODE="XMBJWXX",NAME="项目部井位信息"},
                                            new Category{ CODE="PGZDTS",NAME="派工重点提示"},
                                            new Category{ CODE="BZ",NAME="备注"},
                                            new Category{ CODE="DRJS",NAME="当前井深"},
                                            new Category{ CODE="SGZT",NAME="当前动态"}
                                        };
            return categories;

        }

        /// <summary>
        /// 录井项目统计条件下拉字段
        /// </summary>
        /// <returns></returns>
        public List<Category> WJKP_CategoryList()
        {

            List<Category> categories = new List<Category>{
                                            new Category{ CODE="ZJH",NAME="井号"},
                                            new Category{ CODE="SC3",NAME="甲方单位"},
                                            new Category{ CODE="SC2",NAME="地区"},
                                            new Category{ CODE="QK",NAME="区块"},
                                            new Category{ CODE="REPORT_TYPE",NAME="井别"},
                                            new Category{ CODE="JX",NAME="井型"},
                                            new Category{ CODE="JH",NAME="井筒号"},
                                            new Category{ CODE="LJXL",NAME="录井系列"},
                                            new Category{ CODE="SJJS",NAME="设计井深"},
                                            new Category{ CODE="JSSJJS",NAME="加深设计井深"},
                                            new Category{ CODE="SCFL",NAME="市场类型"},
                                            new Category{ CODE="GJ",NAME="国家"},
                                            new Category{ CODE="SC1",NAME="一级市场"},
                                            new Category{ CODE="DZJDXM",NAME="地质监督姓名"},
                                            new Category{ CODE="DZJDZJH",NAME="地质监督证件号"},
                                            new Category{ CODE="DZJDSSGS",NAME="地质监督所属公司"},
                                            new Category{ CODE="ZJJDXM",NAME="钻井监督姓名"},
                                            new Category{ CODE="ZJJDZJH",NAME="钻井监督证件号"},
                                            new Category{ CODE="ZJJDSSGS",NAME="钻井监督所属公司"},
                                            new Category{ CODE="LJFGS",NAME="录井项目部"},
                                            new Category{ CODE="LJDWZZ",NAME="录井资质"},
                                            new Category{ CODE="LJDH",NAME="录井队号"},
                                            new Category{ CODE="LJYQXH",NAME="设备型号"},
                                            new Category{ CODE="YQZZ",NAME="仪器资质"},
                                            new Category{ CODE="DWZBH",NAME="队伍自编号"},
                                            new Category{ CODE="DZS",NAME="地质师"},
                                            new Category{ CODE="STARSTART",NAME="装卫星时间"},
                                            new Category{ CODE="STARAZR",NAME="安装卫星人"},
                                            new Category{ CODE="STAREND",NAME="拆卫星时间"},
                                            new Category{ CODE="STARCCR",NAME="拆卫星人"},
                                            new Category{ CODE="SGDW",NAME="施工单位"},
                                            new Category{ CODE="SGDH",NAME="施工队号"},
                                            new Category{ CODE="YJBASJ",NAME="预计搬安时间"},
                                            new Category{ CODE="SJBASJ",NAME="实际搬安时间"},
                                            new Category{ CODE="BQJL",NAME="搬迁距离"},
                                            new Category{ CODE="HQSJ",NAME="回迁时间"},
                                            new Category{ CODE="DQZT",NAME="当前状态"},
                                            new Category{ CODE="CHOUXIYOU",NAME="稠油/稀油"},
                                            new Category{ CODE="HXJW",NAME="后续井位"},
                                            new Category{ CODE="HXJDH",NAME="后续井队号"},
                                            new Category{ CODE="JDDT",NAME="井队动态"},
                                            new Category{ CODE="LSDW",NAME="隶属单位"},
                                            new Category{ CODE="XMBJWXX",NAME="项目部井位信息"},
                                            new Category{ CODE="PGZDTS",NAME="派工重点提示"},
                                            new Category{ CODE="BZ",NAME="备注"},
                                            new Category{ CODE="DRJS",NAME="当前井深"},
                                            new Category{ CODE="SGZT",NAME="当前动态"}
                                        };
            return categories;

        }

        /// <summary>
        /// 工程进度条件下拉字段
        /// </summary>
        /// <returns></returns>
        public List<Category> GCJD_CategoryList()
        {

            List<Category> categories = new List<Category>{
                                            new Category{ CODE="ZJH",NAME="井号"},
                                            new Category{ CODE="SC3",NAME="甲方单位"},
                                            new Category{ CODE="SC2",NAME="地区"},
                                            new Category{ CODE="QK",NAME="区块"},
                                            new Category{ CODE="REPORT_TYPE",NAME="井别"},
                                            new Category{ CODE="JX",NAME="井型"},
                                            new Category{ CODE="JH",NAME="井筒号"},
                                            new Category{ CODE="LJXL",NAME="录井系列"},
                                            new Category{ CODE="DZLJKSJS",NAME="地质录井开始井深"},
                                            new Category{ CODE="DZLJKSSJ",NAME="地质录井开始时间"},
                                            new Category{ CODE="YXLJKSJS",NAME="岩屑录井开始井深"},
                                            new Category{ CODE="YXLJKSSJ",NAME="岩屑录井开始时间"},
                                            new Category{ CODE="QCLJKSJS",NAME="气测录井开始井深"},
                                            new Category{ CODE="QCLJKSSJ",NAME="气测录井开始时间"},
                                            new Category{ CODE="ZHLJKSJS",NAME="综合录井开始井深"},
                                            new Category{ CODE="ZHLJKSSJ",NAME="综合录井开始时间"},
                                            new Category{ CODE="SJJS",NAME="设计井深"},
                                            new Category{ CODE="JSSJJS",NAME="加深设计井深"},
                                            new Category{ CODE="WZJS",NAME="完钻井深"},
                                            new Category{ CODE="SJZZB",NAME="实测纵坐标"},
                                            new Category{ CODE="SJHZB",NAME="实测横坐标"},
                                            new Category{ CODE="DMHB",NAME="地面海拔"},
                                            new Category{ CODE="BXG",NAME="补心高"},
                                            new Category{ CODE="SGDW",NAME="施工单位"},
                                            new Category{ CODE="SGDH",NAME="施工队号"},
                                            new Category{ CODE="LJFGS",NAME="录井项目部"},
                                            new Category{ CODE="LJDH",NAME="录井队号"},
                                            new Category{ CODE="LJYQXH",NAME="设备型号"},
                                            new Category{ CODE="KZRQ",NAME="开钻日期"},
                                            new Category{ CODE="WZRQ",NAME="完钻日期"},
                                            new Category{ CODE="GJRQ",NAME="固井日期"},
                                            new Category{ CODE="WJRQ",NAME="完井日期"},
                                            new Category{ CODE="ZYMDC",NAME="主要目的层"},
                                            new Category{ CODE="WZCW",NAME="完钻层位"},
                                            new Category{ CODE="WJFF",NAME="完井方法"},
                                            new Category{ CODE="DYNZDJS",NAME="分支点（第一年）井深"},
                                            new Category{ CODE="DENZDJS",NAME="第二年钻达井深"},
                                            new Category{ CODE="SFJJYQXS",NAME="是否见汽油"},
                                            new Category{ CODE="SFQX",NAME="是否取心"},
                                            new Category{ CODE="SFJSYQC",NAME="解释油气层否"},
                                            new Category{ CODE="SFCXGCFZ",NAME="是否出现工程复杂"},
                                            new Category{ CODE="CXGCFZLX",NAME="出现工程复杂类型"},
                                            new Category{ CODE="GCFZCLSJ",NAME="工程复杂处理时间"},
                                            new Category{ CODE="SFXYCTG",NAME="下油套否"},
                                            new Category{ CODE="SJWZYZ",NAME="设计完钻原则"},
                                            new Category{ CODE="WZYJ",NAME="完钻依据"},
                                            new Category{ CODE="SFBF",NAME="是否报废"},
                                            new Category{ CODE="BFLX",NAME="报废类型"},
                                            new Category{ CODE="STARSTART",NAME="装卫星时间"},
                                            new Category{ CODE="STAREND",NAME="拆卫星时间"},
                                            new Category{ CODE="ZTLX",NAME="中停类型"},
                                            new Category{ CODE="BZ",NAME="备注"},
                                            new Category{ CODE="DRJS",NAME="当前井深"},
                                            new Category{ CODE="SGZT",NAME="当前动态"}
                                        };
            return categories;

        }

        /// <summary>
        /// 单井策划应急预案QHSE作业计划书下拉字段
        /// </summary>
        /// <returns></returns>
        public List<Category> DJCHYAQHSE_CategoryList()
        {
            List<Category> categories = new List<Category>{
                                            new Category{ CODE="ZJH",NAME="井号"},
                                            new Category{ CODE="SC3",NAME="甲方单位"},
                                            new Category{ CODE="SC2",NAME="地区"},
                                            new Category{ CODE="QK",NAME="区块"},
                                            new Category{ CODE="REPORT_TYPE",NAME="井别"},
                                            new Category{ CODE="JX",NAME="井型"},
                                            new Category{ CODE="JH",NAME="井筒号"},
                                            new Category{ CODE="BZR",NAME="编制人"},
                                            new Category{ CODE="BZRQ",NAME="编制日期"},
                                            new Category{ CODE="BZ",NAME="编制日期"}
                                        };
            return categories;
        }


        public List<Category> RYGL_CategoryList()
        {
            List<Category> categories = new List<Category>{
                                            new Category{ CODE="GW",NAME="岗位类别"},
                                            new Category{ CODE="RYBH",NAME="人员编号"},
                                            new Category{ CODE="XM",NAME="姓名"},
                                            new Category{ CODE="LXDH",NAME="联系电话"},
                                            new Category{ CODE="XB",NAME="性别"},
                                            new Category{ CODE="NL",NAME="年龄"},
                                            new Category{ CODE="XL",NAME="学历"},
                                            new Category{ CODE="JKZK",NAME="健康状况"},
                                            new Category{ CODE="ZC",NAME="职称"},
                                            new Category{ CODE="JCZ",NAME="井控证"},
                                            new Category{ CODE="SGZ",NAME="上岗证"},
                                            new Category{ CODE="HSE",NAME="HSE证"},
                                            new Category{ CODE="NDSJTS",NAME="年度上井天数"},
                                            new Category{ CODE="XMB",NAME="项目部"},
                                            new Category{ CODE="RYZT",NAME="人员状态"},
                                            new Category{ CODE="YGXZ",NAME="用工性质"},
                                            new Category{ CODE="SJJH",NAME="上井井号"},
                                            new Category{ CODE="KSSJRQ",NAME="开始上井日期"},
                                            new Category{ CODE="JSSJRQ",NAME="结束上井日期"},
                                            new Category{ CODE="GWXS",NAME="岗位系数"},
                                            new Category{ CODE="BZ",NAME="备注"},

                                        };
            return categories;
        }

        public List<Category> CL_CategoryList()
        {
            List<Category> categories = new List<Category>{
                               new Category   { CODE="SBMC",NAME="设备名称"},
                                            new Category{ CODE="DW",NAME="单位名称"},
                                            new Category{ CODE="GGXH",NAME="规格型号"},
                                            new Category{ CODE="SCCJ",NAME="生产厂家"},
                                            new Category{ CODE="GB",NAME="国别"},
                                            new Category{ CODE="CCRQ",NAME="出厂日期"},
                                            new Category{ CODE="CCBH",NAME="出厂编号"},
                                            new Category{ CODE="TCRQ",NAME="投产日期"},
                                            new Category{ CODE="SBZK",NAME="设备状况"},
                                            new Category{ CODE="ZJNX",NAME="折旧年限"},
                                            new Category{ CODE="RLFL",NAME="燃料分类"},
                                            new Category{ CODE="SBSZWZ",NAME="设备所在位置"},
                                            new Category{ CODE="DXQK",NAME="大修情况"},
                                            new Category{ CODE="BZ",NAME="备注"},

                                        };
            return categories;
        }

        public List<Category> DHFX_CategoryList()
        {
            List<Category> categories = new List<Category>{
                               new Category   { CODE="SBMC",NAME="设备名称"},
                                            new Category{ CODE="DW",NAME="单位名称"},
                                            new Category{ CODE="GGXH",NAME="规格型号"},
                                            new Category{ CODE="SCCJ",NAME="生产厂家"},
                                            new Category{ CODE="GB",NAME="国别"},
                                            new Category{ CODE="CCRQ",NAME="出厂日期"},
                                            new Category{ CODE="CCBH",NAME="出厂编号"},
                                            new Category{ CODE="TCRQ",NAME="投产日期"},
                                            new Category{ CODE="ZBH",NAME="自编号"},
                                            new Category{ CODE="SBZK",NAME="设备状况"},
                                            new Category{ CODE="SBSZWZ",NAME="设备所在位置"},
                                            new Category{ CODE="SSDW",NAME="所属单位"},
                                            new Category{ CODE="BZ",NAME="备注"},

                                        };
            return categories;
        }

        public List<Category> ZSY_CategoryList()
        {
            List<Category> categories = new List<Category>{
                               new Category   { CODE="SBMC",NAME="设备名称"},
                                            new Category{ CODE="DW",NAME="所属单位"},
                                            new Category{ CODE="GGXH",NAME="规格型号"},
                                            new Category{ CODE="SCCJ",NAME="生产厂家"},
                                            new Category{ CODE="GB",NAME="国别"},
                                            new Category{ CODE="CCRQ",NAME="出厂日期"},
                                            new Category{ CODE="CCBH",NAME="出厂编号"},
                                            new Category{ CODE="TCRQ",NAME="投产日期"},
                                            new Category{ CODE="SBXBH",NAME="设备现编号"},
                                            new Category{ CODE="SBZBH",NAME="设备自编号"},
                                            new Category{ CODE="SBZK",NAME="设备状况"},
                                            new Category{ CODE="SBSZWZ",NAME="设备所在位置"},
                                            new Category{ CODE="DXSJ",NAME="大修时间"},
                                            new Category{ CODE="BZ",NAME="备注"},

                                        };
            return categories;
        }

        public List<Category> ZHY_CategoryList()
        {
            List<Category> categories = new List<Category>{
                               new Category   { CODE="SBMC",NAME="设备名称"},
                                            new Category{ CODE="DW",NAME="单位名称"},
                                            new Category{ CODE="SSXD",NAME="所属小队"},
                                            new Category{ CODE="ZZ",NAME="资质"},
                                            new Category{ CODE="GGXH",NAME="规格型号"},
                                            new Category{ CODE="SCCJ",NAME="生产厂家"},
                                            new Category{ CODE="GB",NAME="国别"},
                                            new Category{ CODE="CCRQ",NAME="出厂日期"},
                                            new Category{ CODE="CCBH",NAME="出厂编号"},
                                            new Category{ CODE="TCRQ",NAME="投产日期"},
                                            new Category{ CODE="SBXBH",NAME="设备现编号"},
                                            new Category{ CODE="SBZBH",NAME="设备自编号"},
                                            new Category{ CODE="SP",NAME="色谱"},
                                            new Category{ CODE="SPFXZQ",NAME="色谱分析周期"},
                                            new Category{ CODE="SBZK",NAME="设备状况"},
                                            new Category{ CODE="SSDW",NAME="所属单位"},
                                            new Category{ CODE="SBSZWZ",NAME="设备所在位置"},
                                            new Category{ CODE="DXSJ",NAME="大修时间"},
                                            new Category{ CODE="LHQTT",NAME="硫化氢探头"},
                                            new Category{ CODE="LHQNJ",NAME="硫化氢年检"},
                                            new Category{ CODE="QTBY",NAME="气体标样"},
                                            new Category{ CODE="BZ",NAME="备注"},

                                        };
            return categories;
        }

        public List<Category> WX_CategoryList()
        {
            List<Category> categories = new List<Category>{
                               new Category   { CODE="SBMC",NAME="设备名称"},
                                            new Category{ CODE="DW",NAME="单位名称"},
                                            new Category{ CODE="GGXH",NAME="规格型号"},
                                            new Category{ CODE="SCCJ",NAME="生产厂家"},
                                            new Category{ CODE="GB",NAME="国别"},
                                            new Category{ CODE="CCRQ",NAME="出厂日期"},
                                            new Category{ CODE="CCBH",NAME="出厂编号"},
                                            new Category{ CODE="TCRQ",NAME="投产日期"},
                                            new Category{ CODE="ZBH",NAME="自编号"},
                                            new Category{ CODE="SBZK",NAME="设备状况"},
                                            new Category{ CODE="SBSZWZ",NAME="设备所在位置"},
                                            new Category{ CODE="ZCBH",NAME="资产编号"},
                                            new Category{ CODE="BZ",NAME="备注"},

                                        };
            return categories;
        }


        public List<Category> GCCSY_CategoryList()
        {
            List<Category> categories = new List<Category>{
                               new Category   { CODE="SBMC",NAME="设备名称"},
                                            new Category{ CODE="DW",NAME="所属单位"},
                                            new Category{ CODE="GGXH",NAME="规格型号"},
                                            new Category{ CODE="SCCJ",NAME="生产厂家"},
                                            new Category{ CODE="GB",NAME="国别"},
                                            new Category{ CODE="CCRQ",NAME="出厂日期"},
                                            new Category{ CODE="CCBH",NAME="出厂编号"},
                                            new Category{ CODE="TCRQ",NAME="投产日期"},
                                            new Category{ CODE="SBXBH",NAME="设备现编号"},
                                            new Category{ CODE="SBZBH",NAME="设备自编号"},
                                            new Category{ CODE="SBZK",NAME="设备状况"},
                                            new Category{ CODE="SBSZWZ",NAME="设备所在位置"},
                                            new Category{ CODE="DXSJ",NAME="大修时间"},
                                            new Category{ CODE="BZ",NAME="备注"},

                                        };
            return categories;
        }



        public List<Category> FW_CategoryList()
        {
            List<Category> categories = new List<Category>{
                               new Category   { CODE="LJFGS",NAME="项目部"},
                                            new Category{ CODE="CCBH",NAME="编号"},
                                            new Category{ CODE="GGXH",NAME="型号"},
                                            new Category{ CODE="SBZK",NAME="状况"},
                                            new Category{ CODE="SBSZWZ",NAME="所在位置"},
                                            new Category{ CODE="BZ",NAME="备注"},

                                        };
            return categories;
        }







        /// <summary>
        /// 运算符号下拉列表
        /// </summary>
        /// <returns></returns>
        public List<Category> SymbolList()
        {
            List<Category> list = new List<Category>{
                                            new Category{ CODE="=",NAME="＝"},
                                            new Category{ CODE=">",NAME="＞"},
                                            new Category{ CODE="<",NAME="＜"},
                                            new Category{ CODE=">=",NAME="≥"},
                                            new Category{ CODE="<=",NAME="≤"},
                                            new Category{ CODE="like",NAME="like"}
                                        };
            return list;
        }

        /// <summary>
        /// 设计上传-井型下拉列表
        /// </summary>
        /// <returns></returns>
        public List<Category> JX_List()
        {

            List<Category> categories = new List<Category>{
                                            new Category{ CODE="预探井",NAME="预探井"},
                                            new Category{ CODE="评价井",NAME="评价井"},
                                            new Category{ CODE="开发井",NAME="开发井"}
                                        };
            return categories;

        }

        /// <summary>
        /// 设计上传-井别下拉列表
        /// </summary>
        /// <returns></returns>
        public List<Category> TYPE_List()
        {

            List<Category> categories = new List<Category>{
                                            new Category{ CODE="探井",NAME="探井"},
                                            new Category{ CODE="评价井",NAME="评价井"},
                                            new Category{ CODE="开发井",NAME="开发井"}
                                        };
            return categories;

        }

        /// <summary>
        /// 人员条件列表
        /// </summary>
        /// <returns></returns>
        public List<Category> RYTJ_List()
        {

            List<Category> categories = new List<Category>{
                                            new Category{ CODE="XM",NAME="员工姓名"},
                                            new Category{ CODE="RYZT",NAME="人员状态"},
                                            new Category{ CODE="GW",NAME="岗位"},
                                            new Category{ CODE="LXDH",NAME="电话"},
                                        };
            return categories;

        }


        /// <summary>
        /// 设备分类列表
        /// </summary>
        /// <returns></returns>
        public List<Category> SBFL_List()
        {

            List<Category> categories = new List<Category>{
                                            new Category{ CODE=" ",NAME="全部"},
                                            new Category{ CODE="ZHYSB",NAME="综合仪设备"},
                                            new Category{ CODE="ZSYSB",NAME="钻时仪设备"},
                                            new Category{ CODE="GCYSB",NAME="工程参数仪设备"},
                                            new Category{ CODE="DHYSB",NAME="地化分析设备"},
                                            new Category{ CODE="WXSB",NAME="卫星设备"},
                                            new Category{ CODE="CLSB",NAME="车辆设备"}
                                        };
            return categories;

        }



        /// <summary>
        /// 设备条件列表
        /// </summary>
        /// <returns></returns>
        public List<Category> SBTJ_List()
        {

            List<Category> categories = new List<Category>{
                                            new Category{ CODE="CCBH",NAME="设备编号"},
                                            new Category{ CODE="SBMC",NAME="设备名称"},
                                            new Category{ CODE="DW",NAME="所属单位"},
                                            new Category{ CODE="SBSZWZ",NAME="设备所在位置"},
                                            new Category{ CODE="CCRQ",NAME="出厂日期"},
                                            new Category{ CODE="TCRQ",NAME="投厂日期"},
                                            new Category{ CODE="SBZK",NAME="设备状态"}
                                        };
            return categories;

        }



        private void YL(HttpContext context)
        {
            string json = "";
            try
            {
                int Year = DateTime.Now.Year;
                List<YEARS> list = Y_List();
                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"Code\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }
        /// <summary>
        /// 年份下拉列表
        /// </summary>
        /// <returns></returns>
		public List<YEARS> Y_List()
        {
            DateTime now = DateTime.Now;
            int year = now.Year - 10;
            List<YEARS> YearList = new List<YEARS>();
            for (int i = 0; i < 12; i++)
            {
                YEARS yEARS = new YEARS();
                yEARS.Y = (year + i).ToString();
                YearList.Add(yEARS);
            }

            return YearList;
        }

        /// <summary>
        /// 选择字段
        /// </summary>
        /// <param name="context"></param>
		private void DJSJ_ZD(HttpContext context)
        {
            string json = "";

            try
            {
                List<Category> clist = DJSJ_CategoryList();
                json = JsonConvert.SerializeObject(clist);
            }
            catch (Exception)
            {

                throw;
            }
            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        private void LJXM_ZD(HttpContext context)
        {
            string json = "";

            try
            {
                List<Category> clist = LJXM_CategoryList();
                json = JsonConvert.SerializeObject(clist);
            }
            catch (Exception)
            {

                throw;
            }
            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        private void WJKP_ZD(HttpContext context)
        {
            string json = "";

            try
            {
                List<Category> clist = WJKP_CategoryList();
                json = JsonConvert.SerializeObject(clist);
            }
            catch (Exception)
            {

                throw;
            }
            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        private void GCJD_ZD(HttpContext context)
        {
            string json = "";

            try
            {
                List<Category> clist = GCJD_CategoryList();
                json = JsonConvert.SerializeObject(clist);
            }
            catch (Exception)
            {

                throw;
            }
            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        private void DJCHYAQHSE_ZD(HttpContext context)
        {
            string json = "";

            try
            {
                List<Category> clist = DJCHYAQHSE_CategoryList();
                json = JsonConvert.SerializeObject(clist);
            }
            catch (Exception)
            {

                throw;
            }
            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        private void RYGL_ZD(HttpContext context)
        {
            string json = "";

            try
            {
                List<Category> clist = RYGL_CategoryList();
                json = JsonConvert.SerializeObject(clist);
            }
            catch (Exception)
            {

                throw;
            }
            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        private void CL_ZD(HttpContext context)
        {
            string json = "";

            try
            {
                List<Category> clist = CL_CategoryList();
                json = JsonConvert.SerializeObject(clist);
            }
            catch (Exception)
            {

                throw;
            }
            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        private void WX_ZD(HttpContext context)
        {
            string json = "";

            try
            {
                List<Category> clist = WX_CategoryList();
                json = JsonConvert.SerializeObject(clist);
            }
            catch (Exception)
            {

                throw;
            }
            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        private void DHFX_ZD(HttpContext context)
        {
            string json = "";

            try
            {
                List<Category> clist = DHFX_CategoryList();
                json = JsonConvert.SerializeObject(clist);
            }
            catch (Exception)
            {

                throw;
            }
            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        private void GCCSY_ZD(HttpContext context)
        {
            string json = "";

            try
            {
                List<Category> clist = GCCSY_CategoryList();
                json = JsonConvert.SerializeObject(clist);
            }
            catch (Exception)
            {

                throw;
            }
            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        private void ZSY_ZD(HttpContext context)
        {
            string json = "";

            try
            {
                List<Category> clist = ZSY_CategoryList();
                json = JsonConvert.SerializeObject(clist);
            }
            catch (Exception)
            {

                throw;
            }
            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        private void ZHY_ZD(HttpContext context)
        {
            string json = "";

            try
            {
                List<Category> clist = ZHY_CategoryList();
                json = JsonConvert.SerializeObject(clist);
            }
            catch (Exception)
            {

                throw;
            }
            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }


        private void FW_ZD(HttpContext context)
        {
            string json = "";

            try
            {
                List<Category> clist = FW_CategoryList();
                json = JsonConvert.SerializeObject(clist);
            }
            catch (Exception)
            {

                throw;
            }
            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }


        private void List_GWLB(HttpContext context)
        {
            string json = "";
            try
            {
                List<Sys_Dictionary> list = new List<Sys_Dictionary>();
                list = colBLL.List_GWLB();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"Code\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        private void List_XMBGW(HttpContext context)
        {
            string json = "";
            try
            {
                List<Sys_Dictionary> list = new List<Sys_Dictionary>();
                list = colBLL.List_XMBGW();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"Code\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        private void List_XB(HttpContext context)
        {
            string json = "";
            try
            {
                List<Sys_Dictionary> list = new List<Sys_Dictionary>();
                list = colBLL.List_XB();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"Code\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        private void List_XL(HttpContext context)
        {
            string json = "";
            try
            {
                List<Sys_Dictionary> list = new List<Sys_Dictionary>();
                list = colBLL.List_XL();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"Code\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        private void List_YGXZ(HttpContext context)
        {
            string json = "";
            try
            {
                List<Sys_Dictionary> list = new List<Sys_Dictionary>();
                list = colBLL.List_YGXZ();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"Code\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        private void List_JKZK(HttpContext context)
        {
            string json = "";
            try
            {
                List<Sys_Dictionary> list = new List<Sys_Dictionary>();
                list = colBLL.List_JKZK();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"Code\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        private void List_ZC(HttpContext context)
        {
            string json = "";
            try
            {
                List<Sys_Dictionary> list = new List<Sys_Dictionary>();
                list = colBLL.List_ZC();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"Code\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        private void List_RYZT(HttpContext context)
        {
            string json = "";
            try
            {
                List<Sys_Dictionary> list = new List<Sys_Dictionary>();
                list = colBLL.List_RYZT();

                json = JsonConvert.SerializeObject(list);
            }
            catch (Exception e)
            {
                json = "{\"Code\":\"0\",\"Name\":\"数据出现异常！\"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        /// <summary>
        /// /设备管理下拉字段表
        /// </summary>
        /// <returns></returns>
        public List<Category> CategoryList_SBGL()
        {

            List<Category> categories = new List<Category>{
                                            new Category{ CODE="SBMC",NAME="设备名称"},
                                            new Category{ CODE="DW",NAME="单位名称"},
                                            new Category{ CODE="GGXH",NAME="规格型号"},
                                            new Category{ CODE="SCCJ",NAME="生产厂家"},
                                            new Category{ CODE="GB",NAME="国别"},
                                            new Category{ CODE="CCRQ",NAME="出厂日期"},
                                            new Category{ CODE="CCBH",NAME="出厂编号"},
                                            new Category{ CODE="TCRQ",NAME="投产日期"},
                                            new Category{ CODE="SBZK",NAME="设备状况"},
                                            new Category{ CODE="ZJNX",NAME="折旧年限"},
                                            new Category{ CODE="RLFL",NAME="燃料分类"},
                                            new Category{ CODE="SBSZWZ",NAME="设备所在位置"},
                                            new Category{ CODE="DXQK",NAME="大修情况"},
                                            new Category{ CODE="DXSJ",NAME="大修时间"},
                                            new Category{ CODE="SBXBH",NAME="设备现编号"},
                                            new Category{ CODE="SBZBH",NAME="设备自编号"},
                                            new Category{ CODE="SSDW",NAME="所属单位"},
                                            new Category{ CODE="DXSJ",NAME="大修时间"},
                                            new Category{ CODE="SSXD",NAME="所属小队"},
                                            new Category{ CODE="ZZ",NAME="资质"},
                                            new Category{ CODE="SP",NAME="色谱"},
                                            new Category{ CODE="SPFXZQ",NAME="色谱分析周期"},
                                            new Category{ CODE="LHQTT",NAME="硫化氢探头"},
                                            new Category{ CODE="LHQNJ",NAME="硫化氢年检"},
                                            new Category{ CODE="QTBY",NAME="气体标样"},
                                            new Category{ CODE="ZBH",NAME="自编号"},
                                            new Category{ CODE="FL",NAME="分类"},
                                            new Category{ CODE="XMB",NAME="项目部"},
                                            new Category{ CODE="CCBH",NAME="编号"},//房屋表
                                            new Category{ CODE="GGXH",NAME="型号"},//房屋表
                                            new Category{ CODE="SBZK",NAME="状况"},//房屋表
                                            new Category{ CODE="SBSZWZ",NAME="所在位置"},//房屋表

                                        };
            return categories;

        }



        /// <summary>
        /// /人员管理下拉字段表
        /// </summary>
        /// <returns></returns>
        public List<Category> CategoryList_RYGL()
        {

            List<Category> categories = new List<Category>{
                                            new Category{ CODE="RYBH",NAME="人员编号"},
                                            new Category{ CODE="LXDH",NAME="联系电话"},
                                            new Category{ CODE="XB",NAME="性别"},
                                            new Category{ CODE="NL",NAME="年龄"},
                                            new Category{ CODE="XL",NAME="学历"},
                                            new Category{ CODE="JKZK",NAME="健康状况"},
                                            new Category{ CODE="ZC",NAME="职称"},
                                            new Category{ CODE="XMB",NAME="项目部"},
                                            new Category{ CODE="RYZT",NAME="人员状态"},
                                            new Category{ CODE="YGXZ",NAME="用工性质"},
                                            new Category{ CODE="KSSJRQ",NAME="开始上井时间"},
                                            new Category{ CODE="JSSJRQ",NAME="结束上井时间"},
                                            new Category{ CODE="SJTS",NAME="上井天数"},
                                            new Category{ CODE="NDSJTS",NAME="累计上井天数"},
                                            new Category{ CODE="GWXS",NAME="岗位系数"}
                                        };
            return categories;

        }

        /// <summary>
        /// 设备管理选择字段
        /// </summary>
        /// <param name="context"></param>
        private void getZD_SBGL(HttpContext context)
        {
            string json = "";

            try
            {
                List<string> zd = new List<string>();
                var list = context.Request["zdlist"];
                if (list != null)
                {
                    //catelist.Clear();
                    catelist_sb = new List<Category> { new Category { CODE = "SBMC", NAME = "设备名称" } };
                    zd = JsonConvert.DeserializeObject<List<string>>(list);
                    List<Category> clist = CategoryList_SBGL();
                    for (int i = 0; i < zd.Count; i++)
                    {
                        for (int j = 0; j < clist.Count; j++)
                        {
                            if (zd[i] == clist[j].NAME)
                            {
                                catelist_sb.Add(clist[j]);
                            }
                        }
                    }

                }
                else
                {
                    json = JsonConvert.SerializeObject(catelist_sb);
                    //catelist.Clear();
                    catelist_sb = new List<Category> { new Category { CODE = "SBMC", NAME = "设备名称" } };
                }

            }
            catch (Exception)
            {

                throw;
            }
            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }


        private void getZD_FW(HttpContext context)
        {
            string json = "";

            try
            {
                List<string> zd = new List<string>();
                var list = context.Request["zdlist"];
                if (list != null)
                {
                    //catelist.Clear();
                    catelist_fw = new List<Category> { new Category { CODE = "LJFGS", NAME = "项目部" } };
                    zd = JsonConvert.DeserializeObject<List<string>>(list);
                    List<Category> clist = CategoryList_SBGL();
                    for (int i = 0; i < zd.Count; i++)
                    {
                        for (int j = 0; j < clist.Count; j++)
                        {
                            if (zd[i] == clist[j].NAME)
                            {
                                catelist_fw.Add(clist[j]);
                            }
                        }
                    }

                }
                else
                {
                    json = JsonConvert.SerializeObject(catelist_fw);
                    //catelist.Clear();
                    catelist_fw = new List<Category> { new Category { CODE = "LJFGS", NAME = "项目部" } };
                }

            }
            catch (Exception)
            {

                throw;
            }
            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        private void getZD_RYGL(HttpContext context)
        {
            string json = "";

            try
            {
                List<string> zd = new List<string>();
                var list = context.Request["zdlist"];
                if (list != null)
                {
                    //catelist.Clear();
                    catelist_ry = new List<Category> { new Category { CODE = "XM", NAME = "姓名" } };
                    zd = JsonConvert.DeserializeObject<List<string>>(list);
                    List<Category> clist = CategoryList_RYGL();
                    for (int i = 0; i < zd.Count; i++)
                    {
                        for (int j = 0; j < clist.Count; j++)
                        {
                            if (zd[i] == clist[j].NAME)
                            {
                                catelist_ry.Add(clist[j]);
                            }
                        }
                    }

                }
                else
                {
                    json = JsonConvert.SerializeObject(catelist_ry);
                    //catelist.Clear();
                    catelist_ry = new List<Category> { new Category { CODE = "XM", NAME = "姓名" } };
                }

            }
            catch (Exception)
            {

                throw;
            }
            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }


        private void getZD_RYGLZB(HttpContext context)
        {
            string json = "";

            try
            {
                List<string> zd = new List<string>();
                var list = context.Request["zdlist"];
                if (list != null)
                {
                    //catelist.Clear();
                    catelist_ryzb = new List<Category> { new Category { CODE = "XM", NAME = "姓名" } };
                    zd = JsonConvert.DeserializeObject<List<string>>(list);
                    List<Category> clist = CategoryList_RYGL();
                    for (int i = 0; i < zd.Count; i++)
                    {
                        for (int j = 0; j < clist.Count; j++)
                        {
                            if (zd[i] == clist[j].NAME)
                            {
                                catelist_ryzb.Add(clist[j]);
                            }
                        }
                    }

                }
                else
                {
                    json = JsonConvert.SerializeObject(catelist_ryzb);
                    //catelist.Clear();
                    catelist_ryzb = new List<Category> { new Category { CODE = "XM", NAME = "姓名" } };
                }

            }
            catch (Exception)
            {

                throw;
            }
            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();

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