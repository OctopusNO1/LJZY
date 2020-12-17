using LJZY.DAO.LQGL;
using LJZY.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LJZY.BLL.LQGL
{
    public class LQ_LJXMBLL
    {
        private readonly LQ_LJXMDAO dal;

        public LQ_LJXMBLL()
        {
            dal = new LQ_LJXMDAO();
        }

        public List<LQ_LJXM> LJXMInfoByZJH(string ZJH, string dtName1, string dtName61)
        {
            List<LQ_LJXM> list = new List<LQ_LJXM>();


            string strSql = string.Format(@" AND ZJH='{0}'", ZJH);

            DataTable dt = dal.LJXMInfo("", strSql, dtName1, dtName61).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_LJXM model = new LQ_LJXM();
                DataRow dr = dt.Rows[i];
                model = dal.LJXMModel(dr);
                list.Add(model);
            }
            return list;
        }

        #region 翻页
        /// <summary>
        /// 录井项目根据井号获取
        /// </summary>
        /// <param name="ZJH"></param>
        /// <returns></returns>
        public LQ_LJXM LJXMInfo_JH(string JH, string typeWhere, string dtName1, string dtName61)
        {
            LQ_LJXM model = new LQ_LJXM();
            model.TROW = 0;
            string strSql = string.Format(@" AND JH='{0}'", JH);

            DataTable dt = dal.LJXMInfo(typeWhere, strSql, dtName1, dtName61).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                model = dal.LJXMModel(dr);
            }
            return model;
        }

        public LQ_LJXM LJXMInfo(int TROW, string strWhere, string dtName1, string dtName61)
        {
            LQ_LJXM model = new LQ_LJXM();
            model.TROW = 0;
            string strSql = string.Format(" AND TROW={0} ", TROW);
            DataTable dt = dal.LJXMInfo(strWhere, strSql, dtName1, dtName61).Tables[0];

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                model = dal.LJXMModel(dr);
            }
            return model;
        }
        #endregion

        #region 录井项目模块
        ///// <summary>
        ///// 新增
        ///// </summary>
        ///// <param name="LJXM"></param>
        ///// <returns></returns>
        //public bool Add(LQ_LJXM LJXM, string dtName )
        //{
        //	return dal.Add(LJXM,dtName);
        //}

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="LJXM"></param>
        /// <returns></returns>
        public bool Update(LQ_LJXM LJXM, string dtName)
        {
            return dal.Update(LJXM, dtName);
        }

        /// <summary>
        /// 数据导入
        /// </summary>
        /// <param name="LJXM"></param>
        /// <param name="dtName"></param>
        /// <returns></returns>
        public bool importUpdate(List<LQ_LJXM> List, string dtName)
        {
            return dal.importUpdate(List, dtName);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="DJSJ"></param>
        /// <returns></returns>
        public bool Del(string JH, string JX, string dtName1)
        {
            return dal.Del(JH, JX, dtName1);
        }

        /// <summary>
        /// 判断井号是否存在
        /// </summary>
        /// <param name="ZJH"></param>
        /// <returns></returns>
        public DataTable LQ_LJXMInfo_Check(string JH, string JX, string dtName)
        {
            List<LQ_LJXM> list = new List<LQ_LJXM>();
            string strSql = string.Format(@" AND JH='{0}' AND JX='{1}'", JH, JX);
            DataTable dt = dal.LJXM_Check(strSql, dtName).Tables[0];

            return dt;
        }

        /// <summary>
        /// 录井项目表格分页数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public Dictionary<string, object> LJXMDataGrid(string strWhere, int rows, int page, string sort, string order, string dtName1, string dtName61)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            string filedOrder = "";
            if (!string.IsNullOrEmpty(sort))
            {
                filedOrder = sort + " " + order;
            }
            else
            {
                filedOrder = " SC3, JH DESC,REPORT_TYPE ";
            }
            int recordCount = 0;
            List<LQ_LJXM> list = new List<LQ_LJXM>();

            DataTable dt = dal.LJXMInfo_strWhere(strWhere, rows, page, filedOrder, out recordCount, dtName1, dtName61).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_LJXM model = new LQ_LJXM();
                DataRow dr = dt.Rows[i];
                model = dal.LJXMModel(dr);

                list.Add(model);
            }

            //dic.Add("count", recordCount.ToString());
            //dic.Add("code", 0);
            //dic.Add("msg", null);
            //dic.Add("data", list);
            dic.Add("total", recordCount.ToString());
            dic.Add("rows", list);
            return dic;
        }

        public DataTable LJXMData(string strWhere, string dtName1, string dtName61)
        {
             
            DataTable dt = dal.LJXMInfo_strWhere(strWhere, dtName1, dtName61).Tables[0];
             
            return dt;
        }

        /// <summary>
        /// 录井项目根据井号获取
        /// </summary>
        /// <param name="ZJH"></param>
        /// <returns></returns>
        public List<LQ_LJXM> LJXMInfo_ID(string typeWhere, string JH, string JX, string dtName1, string dtName61)
        {
            List<LQ_LJXM> list = new List<LQ_LJXM>();
            string strSql = string.Format(@" AND JH='{0}'", JH);

            DataTable dt = dal.LJXMInfo(typeWhere, strSql, dtName1, dtName61).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_LJXM model = new LQ_LJXM();
                DataRow dr = dt.Rows[i];
                model = dal.LJXMModel(dr);

                list.Add(model);
            }
            return list;
        }

        /// <summary>
        /// 通过条件获取录井项目信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<LQ_LJXM> LJXMInfo_List(string strType, string strWhere, string dtName1, string dtName61)
        {
            List<LQ_LJXM> list = new List<LQ_LJXM>();
            DataTable dt = dal.LJXMInfo(strType, strWhere, dtName1, dtName61).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_LJXM model = new LQ_LJXM();
                DataRow dr = dt.Rows[i];
                model = dal.LJXMModel(dr);

                list.Add(model);
            }
            return list;
        }

        /// <summary>
        /// 表单分页效果查询
        /// </summary>
        /// <param name="TROW"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<LQ_LJXM> LJXMInfo(string strType, int TROW, string strWhere, string dtName1, string dtName61)
        {
            List<LQ_LJXM> list = new List<LQ_LJXM>();
            //string strSql = string.Format ( @" AND TROW={0} {1} ", TROW, strWhere );
            DataTable dt = dal.LJXMInfo(strType, strWhere, dtName1, dtName61).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_LJXM model = new LQ_LJXM();
                DataRow dr = dt.Rows[i];
                model = dal.LJXMModel(dr);
                list.Add(model);
            }
            list = list.Where(o => o.TROW == TROW).ToList<LQ_LJXM>();
            return list;
        }

        /// <summary>
        /// 统计数据总条数
        /// </summary>
        /// <returns></returns>
        public int COUNT_List(string strWhere, string dtName1, string dtName61)
        {
            return dal.COUNT_List(strWhere, dtName1, dtName61);
        }

        #endregion

        #region 人员分配模块

        /// <summary>
        /// 人员分配待派列表
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public Dictionary<string, object> RYXZ_List(string strSql)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            int recordCount = 0;
            List<LQ_RYSJK> list = new List<LQ_RYSJK>();

            DataTable dt = dal.RYXZ_List(strSql).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_RYSJK model = new LQ_RYSJK();
                DataRow dr = dt.Rows[i];
                model = dal.RYSJKModel(dr);
                list.Add(model);
            }
            dic.Add("total", recordCount.ToString());
            dic.Add("rows", list);
            return dic;

        }

        /// <summary>
        /// 人员在岗列表
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <param name="ZJH"></param>
        /// <returns></returns>
        public Dictionary<string, object> RYZG_List(string JH, string strSql)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            int recordCount = 0;
            List<LQ_RYSJK> list = new List<LQ_RYSJK>();

            DataTable dt = dal.RYSJK_ZGList(JH, strSql).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_RYSJK model = new LQ_RYSJK();
                DataRow dr = dt.Rows[i];
                model = dal.RYSJKModel(dr);
                list.Add(model);
            }
            dic.Add("total", recordCount.ToString());
            dic.Add("rows", list);
            return dic;
        }

        /// <summary>
        /// 人员分配待派
        /// </summary>
        /// <param name="RYBH_List"></param>
        /// <param name="FP_List"></param>
        /// <returns></returns>
        public bool RYFPToDP(List<LQ_RYFP> FP_List,List<string> rzList)
        {

            return dal.RYFPToDP(FP_List, rzList);

        }

        /// <summary>
        /// 人员分配在岗
        /// </summary>
        /// <param name="FP_List"></param>
        /// <returns></returns>
        public bool RYFPTo_ZG(List<LQ_RYFP> FP_List, string JH, string dtName1)
        {
            return dal.RYFPToZG(FP_List, JH, dtName1);
        }
        #endregion

        #region 设备分配模块
        /// <summary>
        /// 设备分配闲置
        /// </summary>
        /// <param name="FP_List"></param>
        /// <returns></returns>
        public bool SBFPTo_XZ(List<LQ_SBFP> FP_List)
        {
            return dal.SBFPTo_XZ(FP_List);
        }

        /// <summary>
        /// 设备分配在用
        /// </summary>
        /// <param name="FP_List"></param>
        /// <returns></returns>
        public bool SBFPTo_ZY(List<LQ_SBFP> FP_List)
        {
            return dal.SBFPTo_ZY(FP_List);
        }

        /// <summary>
        /// 闲置设备列表
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public Dictionary<string, object> SBXZ_List(string strWhere)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            List<LQ_SBFP> list = new List<LQ_SBFP>();

            DataTable dt1 = dal.CL_XZList(strWhere).Tables[0];
            //List<LQ_SBFP> CLlist = new List<LQ_SBFP>();
            //CLlist = SB_List(dt1, "车辆设备");
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                LQ_SBFP model = new LQ_SBFP();
                DataRow dr = dt1.Rows[i];
                model = dal.SBPFModel(dr);
                model.SBFL = "车辆设备";
                list.Add(model);
            }

            DataTable dt2 = dal.ZSY_XZList(strWhere).Tables[0];
            //List<LQ_SBFP> ZSYlist = new List<LQ_SBFP>();
            //ZSYlist = SB_List(dt2, "钻时仪设备");
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                LQ_SBFP model = new LQ_SBFP();
                DataRow dr = dt2.Rows[i];
                model = dal.SBPFModel(dr);
                model.SBFL = "钻时仪设备";
                list.Add(model);
            }

            DataTable dt3 = dal.GCCSY_XZList(strWhere).Tables[0];
            //List<LQ_SBFP> GCYlist = new List<LQ_SBFP>();
            //GCYlist = SB_List(dt3, "工程参数仪设备");
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                LQ_SBFP model = new LQ_SBFP();
                DataRow dr = dt3.Rows[i];
                model = dal.SBPFModel(dr);
                model.SBFL = "工程参数仪设备";
                list.Add(model);
            }


            DataTable dt4 = dal.DHFX_XZList(strWhere).Tables[0];
            //List<LQ_SBFP> DHYlist = new List<LQ_SBFP>();
            //DHYlist = SB_List(dt4, "地化分析设备");
            for (int i = 0; i < dt4.Rows.Count; i++)
            {
                LQ_SBFP model = new LQ_SBFP();
                DataRow dr = dt4.Rows[i];
                model = dal.SBPFModel(dr);
                model.SBFL = "地化分析设备";
                list.Add(model);
            }

            DataTable dt5 = dal.ZHY_XZList(strWhere).Tables[0];
            //List<LQ_SBFP> ZHYlist = new List<LQ_SBFP>();
            //ZHYlist = SB_List(dt5, "综合仪设备");
            for (int i = 0; i < dt5.Rows.Count; i++)
            {
                LQ_SBFP model = new LQ_SBFP();
                DataRow dr = dt5.Rows[i];
                model = dal.SBPFModel(dr);
                model.SBFL = "综合仪设备";
                list.Add(model);
            }

            DataTable dt6 = dal.WX_XZList(strWhere).Tables[0];
            //List<LQ_SBFP> WXlist = new List<LQ_SBFP>();
            //WXlist = SB_List(dt6, "卫星设备");
            for (int i = 0; i < dt6.Rows.Count; i++)
            {
                LQ_SBFP model = new LQ_SBFP();
                DataRow dr = dt6.Rows[i];
                model = dal.SBPFModel(dr);
                model.SBFL = "卫星设备";
                list.Add(model);
            }

            dic.Add("total", list.Count);
            dic.Add("rows", list);
            return dic;
        }

        /// <summary>
        /// 根据分类查询设备列表
        /// </summary>
        /// <param name="SBFL"></param>
        /// <returns></returns>
        public Dictionary<string, object> SB_FL_List(string SBFL, string strSql)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            int recordCount = 0;
            List<LQ_SBFP> list = new List<LQ_SBFP>();
            DataTable dt = new DataTable();
            switch (SBFL)
            {
                case "车辆设备":
                    dt = dal.CL_XZList(strSql).Tables[0];
                    break;
                case "钻时仪设备":
                    dt = dal.ZSY_XZList(strSql).Tables[0];
                    break;
                case "工程参数仪设备":
                    dt = dal.GCCSY_XZList(strSql).Tables[0];
                    break;
                case "地化分析设备":
                    dt = dal.DHFX_XZList(strSql).Tables[0];
                    break;
                case "综合仪设备":
                    dt = dal.ZHY_XZList(strSql).Tables[0];
                    break;
                case "卫星设备":
                    dt = dal.WX_XZList(strSql).Tables[0];
                    break;
            }
            list = SB_List(dt, SBFL);

            dic.Add("total", recordCount.ToString());
            dic.Add("rows", list);
            return dic;
        }

        /// <summary>
        /// 根据分类获取设备列表
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="SBFL"></param>
        /// <param name="strFL"></param>
        /// <returns></returns>
        public List<LQ_SBFP> SB_List(DataTable dt, string SBFL)
        {
            List<LQ_SBFP> list = new List<LQ_SBFP>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_SBFP model = new LQ_SBFP();
                DataRow dr = dt.Rows[i];
                model = dal.SBPFModel(dr);
                model.SBFL = SBFL;
                list.Add(model);
            }
            return list;
        }

        /// <summary>
        /// 再用设备列表
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public Dictionary<string, object> SBZY_List(string ZJH, string strSql)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            int recordCount = 0;
            List<LQ_SBFP> list = new List<LQ_SBFP>();

            DataTable dt1 = dal.CL_ZYList(ZJH, strSql).Tables[0];

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                LQ_SBFP model = new LQ_SBFP();
                DataRow dr = dt1.Rows[i];
                model = dal.SBPFModel(dr);
                model.SBFL = "车辆设备";
                list.Add(model);
            }

            DataTable dt2 = dal.ZSY_ZYList(ZJH, strSql).Tables[0];

            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                LQ_SBFP model = new LQ_SBFP();
                DataRow dr = dt2.Rows[i];
                model = dal.SBPFModel(dr);
                model.SBFL = "钻时仪设备";
                list.Add(model);
            }

            DataTable dt3 = dal.GCCSY_ZYList(ZJH, strSql).Tables[0];

            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                LQ_SBFP model = new LQ_SBFP();
                DataRow dr = dt3.Rows[i];
                model = dal.SBPFModel(dr);
                model.SBFL = "工程参数仪设备";
                list.Add(model);
            }


            DataTable dt4 = dal.DHFX_ZYList(ZJH, strSql).Tables[0];

            for (int i = 0; i < dt4.Rows.Count; i++)
            {
                LQ_SBFP model = new LQ_SBFP();
                DataRow dr = dt4.Rows[i];
                model = dal.SBPFModel(dr);
                model.SBFL = "地化分析设备";
                list.Add(model);
            }

            DataTable dt5 = dal.ZHY_ZYList(ZJH, strSql).Tables[0];

            for (int i = 0; i < dt5.Rows.Count; i++)
            {
                LQ_SBFP model = new LQ_SBFP();
                DataRow dr = dt5.Rows[i];
                model = dal.SBPFModel(dr);
                model.SBFL = "综合仪设备";
                list.Add(model);
            }

            DataTable dt6 = dal.WX_ZYList(ZJH, strSql).Tables[0];

            for (int i = 0; i < dt6.Rows.Count; i++)
            {
                LQ_SBFP model = new LQ_SBFP();
                DataRow dr = dt6.Rows[i];
                model = dal.SBPFModel(dr);
                model.SBFL = "卫星设备";
                list.Add(model);
            }
            dic.Add("total", recordCount.ToString());
            dic.Add("rows", list);
            return dic;
        }

        public Dictionary<string, object> SB_FL_List(string ZJH, string SBFL, string strSql)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            int recordCount = 0;
            DataTable dt = new DataTable();
            switch (SBFL)
            {
                case "车辆设备":
                    dt = dal.CL_ZYList(ZJH, strSql).Tables[0];
                    break;
                case "钻时仪设备":
                    dt = dal.ZSY_ZYList(ZJH, strSql).Tables[0];
                    break;
                case "工程参数仪设备":
                    dt = dal.GCCSY_ZYList(ZJH, strSql).Tables[0];
                    break;
                case "地化分析设备":
                    dt = dal.DHFX_ZYList(ZJH, strSql).Tables[0];
                    break;
                case "综合仪设备":
                    dt = dal.ZHY_ZYList(ZJH, strSql).Tables[0];
                    break;
                case "卫星设备":
                    dt = dal.WX_ZYList(ZJH, strSql).Tables[0];
                    break;
            }

            List<LQ_SBFP> list = new List<LQ_SBFP>();
            list = SB_List(dt, SBFL);

            dic.Add("total", recordCount.ToString());
            dic.Add("rows", list);
            return dic;
        }
        #endregion

        #region 房屋分配模块

        /// <summary>
        /// 根据分类获取闲置房屋列表
        /// </summary>
        /// <param name="FL"></param>
        /// <returns></returns>
        public Dictionary<string, object> FWXZ_List(string FL)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            int recordCount = 0;
            List<LQ_FWFP> list = new List<LQ_FWFP>();

            DataTable dt = dal.FWXZ_List(FL).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_FWFP model = new LQ_FWFP();
                DataRow dr = dt.Rows[i];
                model = dal.FWPFModel(dr);
                list.Add(model);
            }
            dic.Add("total", recordCount.ToString());
            dic.Add("rows", list);
            return dic;
        }

        /// <summary>
        /// 根据分类和井号获取在用房屋列表
        /// </summary>
        /// <param name="ZJH"></param>
        /// <param name="FL"></param>
        /// <returns></returns>
        public Dictionary<string, object> FWZY_List(string ZJH, string FL)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            int recordCount = 0;
            List<LQ_FWFP> list = new List<LQ_FWFP>();

            DataTable dt = dal.FWZY_List(ZJH, FL).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_FWFP model = new LQ_FWFP();
                DataRow dr = dt.Rows[i];
                model = dal.FWPFModel(dr);
                list.Add(model);
            }
            dic.Add("total", recordCount.ToString());
            dic.Add("rows", list);
            return dic;
        }

        /// <summary>
        /// 房屋分配闲置
        /// </summary>
        /// <param name="FP_List"></param>
        /// <returns></returns>
        public bool FWFPTo_XZ(List<LQ_FWFP> FP_List)
        {
            return dal.FWFPTo_XZ(FP_List);
        }

        /// <summary>
        /// 房屋分配在用
        /// </summary>
        /// <param name="FP_List"></param>
        /// <returns></returns>
        public bool FWFPTo_ZY(List<LQ_FWFP> FP_List)
        {
            return dal.FWFPTo_ZY(FP_List);
        }
        #endregion



        /// <summary>
        /// 通过人员编号获取人员信息
        /// </summary>
        /// <param name="ZJH"></param>
        /// <returns></returns>
        public LQ_RYSJK RYInfoByRYBH(string RYBH)
        {
            DataTable dt = dal.RYInfo(RYBH).Tables[0];
            LQ_RYSJK model = new LQ_RYSJK();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                model = dal.RYSJKModel(dr);
            }
            return model;
        }

        public List<LQ_SJRZ> SJRZList()
        {
            List<LQ_SJRZ> list = new List<LQ_SJRZ>();
            DataTable dt = dal.SJRZInfo().Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_SJRZ model = new LQ_SJRZ();
                DataRow dr = dt.Rows[i];
                model = dal.SJRZModel(dr);
                list.Add(model);
            } 
            return list;
        } 
        /// <summary>
        /// 获取菜单字段表中分类
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public string Ptype(string Name)
        {
            LQGLBLL bll = new LQGLBLL();
            return bll.Ptype(Name);
        }

        public bool DicAdd(Sys_Dictionary dic)
        {
            return dal.DicAdd(dic);
        }

        public List<SB_FW_Count> SBFW_CountList(string LJFGS)
        {
            List<SB_FW_Count> list = new List<SB_FW_Count>();
            List<SB_FW_Count> sbList = new List<SB_FW_Count>();
            List<SB_FW_Count> fwList = new List<SB_FW_Count>();

            SB_FW_Count zy = new SB_FW_Count();
            SB_FW_Count dp = new SB_FW_Count();
            DataTable sbDT = dal.SB_Count(LJFGS).Tables[0];
            for (int i = 0; i < sbDT.Rows.Count; i++)
            {
                SB_FW_Count model = new SB_FW_Count();
                DataRow dr = sbDT.Rows[i];
                model = dal.SB_Model(dr);
                sbList.Add(model);
            }
            DataTable fwDT = dal.FW_Count(LJFGS).Tables[0];
            for (int i = 0; i < fwDT.Rows.Count; i++)
            {
                SB_FW_Count model = new SB_FW_Count();
                DataRow dr = fwDT.Rows[i];
                model = dal.FW_Model(dr);
                fwList.Add(model);
            }
            zy.TYPE = "在用";
            List<SB_FW_Count> sbzy = sbList.Where(o => o.TYPE == zy.TYPE).ToList();
            if (sbzy.Count > 0)
            {
                zy.ZHY = sbzy[0].ZHY;
            }
            List<SB_FW_Count> fwzy = fwList.Where(o => o.TYPE == zy.TYPE).ToList();
            if (fwzy.Count > 0)
            {
                zy.DZF = fwzy[0].DZF;
                zy.YQF = fwzy[0].YQF;
                zy.ZF = fwzy[0].ZF;
                zy.KF = fwzy[0].KF;
            }
            list.Add(zy);
            dp.TYPE = "待派";
            List<SB_FW_Count> sbdp = sbList.Where(o => o.TYPE == dp.TYPE).ToList();
            if (sbdp.Count > 0)
            {
                dp.ZHY = sbdp[0].ZHY;
            }
            List<SB_FW_Count> fwdp = fwList.Where(o => o.TYPE == dp.TYPE).ToList();
            if (fwdp.Count > 0)
            {
                dp.DZF = fwdp[0].DZF;
                dp.YQF = fwdp[0].YQF;
                dp.ZF = fwdp[0].ZF;
                dp.KF = fwdp[0].KF;
            }
            list.Add(dp);
            return list;
        }

        public List<RY_Count> RY_CountList(string LJFGS)
        {
            List<RY_Count> list = new List<RY_Count>();
            List<RY_Count> ryList = new List<RY_Count>(); 

            RY_Count zg = new RY_Count();
            RY_Count dp = new RY_Count();
            DataTable ryDT = dal.RY_Count(LJFGS).Tables[0];
            for (int i = 0; i < ryDT.Rows.Count; i++)
            {
                RY_Count model = new RY_Count();
                DataRow dr = ryDT.Rows[i];
                model = dal.RY_Model(dr);
                ryList.Add(model);
            }

            zg.TYPE = "在岗";
           
            List<RY_Count> ryzg = ryList.Where(o => o.TYPE == zg.TYPE).ToList();
            if (ryzg.Count > 0)
            {
                zg.LJDZS = ryzg[0].LJDZS;
                zg.LJGCS = ryzg[0].LJGCS;
                zg.CZY = ryzg[0].CZY;
                zg.DZG = ryzg[0].DZG;
                zg.SXS = ryzg[0].SXS;
                zg.DZZL = ryzg[0].DZZL;
                zg.KFJDZS = ryzg[0].KFJDZS; 
            }
            list.Add(zg);
            dp.TYPE = "待派"; 
            List<RY_Count> rydp = ryList.Where(o => o.TYPE == dp.TYPE).ToList();
            if (rydp.Count > 0)
            {
                dp.LJDZS = rydp[0].LJDZS;
                dp.LJGCS = rydp[0].LJGCS;
                dp.CZY = rydp[0].CZY;
                dp.DZG = rydp[0].DZG;
                dp.SXS = rydp[0].SXS;
                dp.DZZL = rydp[0].DZZL;
                dp.KFJDZS = rydp[0].KFJDZS;
            }
            list.Add(dp);
            return list;
        }
    }
}
