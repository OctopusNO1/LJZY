using LJZY.DAO.LQGL;
using LJZY.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.BLL.LQGL
{
    public class LQ_SCPGBLL
    {
        private readonly LQ_SCPGDAO dal;

        public LQ_SCPGBLL()
        {
            dal = new LQ_SCPGDAO();
        }

        public bool SCPG_Check(int Num, string JHstr, string dtName1)
        {

            int CountNum = dal.SCPG_Check(JHstr, dtName1);
            if (Num == CountNum)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool RWTH_Check(string JHstr)
        {

            int CountNum = dal.RWTH_Check(JHstr);
            if (CountNum > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool SCPG_Insert(List<LQ_SCPG> list, string dtName1)
        {
            return dal.SCPG_Insert(list, dtName1);
        }

        public bool SCPG_Del(List<string> JHList, string dtName1)
        {
            return dal.SCPG_Del(JHList, dtName1);
        }

        public bool QTPG_Del(List<LQ_SCPG> JHList, string REPORT_TYPE, string dtName1)
        {
            return dal.QTPG_Del(JHList, REPORT_TYPE, dtName1);
        }

        public Dictionary<string, object> JHList_QT(string dtName1)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();

            List<LQ_SCPG> list = new List<LQ_SCPG>();
            DataTable dt = dal.JHList_QT(dtName1).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_SCPG model = new LQ_SCPG();
                DataRow dr = dt.Rows[i];
                model = dal.SCPG_Model(dr);
                list.Add(model);
            }
            dic.Add("count", list.Count);
            dic.Add("code", 0);
            dic.Add("msg", null);
            dic.Add("data", list);
            return dic;
        }

        /// <summary>
        /// 待派井列表
        /// </summary>
        /// <param name="dtName1"></param>
        /// <returns></returns>
        public Dictionary<string, object> JHList_DP(string strSql, string dtName1)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();

            List<LQ_SCPG> list = new List<LQ_SCPG>();
            int IsFinish = 0;//待分配
            DataTable dt = dal.JHList(IsFinish, strSql, dtName1).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_SCPG model = new LQ_SCPG();
                DataRow dr = dt.Rows[i];
                model = dal.SCPG_Model(dr);
                list.Add(model);
            }
            dic.Add("count", list.Count);
            dic.Add("code", 0);
            dic.Add("msg", null);
            dic.Add("data", list);
            return dic;
        }

        public Dictionary<string, object> JHList_DFP(string dtName1)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();

            List<LQ_SCPG> list = new List<LQ_SCPG>();

            DataTable dt = dal.JHList(1, "  AND b.LJFGS !='其他' ", dtName1).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_SCPG model = new LQ_SCPG();
                DataRow dr = dt.Rows[i];
                model = dal.SCPG_Model(dr);
                list.Add(model);
            }

            List<LQ_SCPG> List_KFJ = new List<LQ_SCPG>();
            List<LQ_SCPG> List_PJJ = new List<LQ_SCPG>();
            List<LQ_SCPG> List_KTJ = new List<LQ_SCPG>();


            //for (int i = 0; i < list.Count; i++)
            //{

            List_KTJ = list.Where(m => m.REPORT_TYPE == "探井").Take(20).ToList<LQ_SCPG>();
            List_PJJ = list.Where(m => m.REPORT_TYPE == "评价井").Take(20).ToList<LQ_SCPG>();
            List_KFJ = list.Where(m => m.REPORT_TYPE == "开发井").Take(20).ToList<LQ_SCPG>();

            for (int i = 0; i < List_KTJ.Count; i++)
            {
                List_KTJ[i].TROW = i + 1;
            }
            for (int i = 0; i < List_PJJ.Count; i++)
            {
                List_PJJ[i].TROW = i + 1;
            }
            for (int i = 0; i < List_KFJ.Count; i++)
            {
                List_KFJ[i].TROW = i + 1;
            }
            dic.Add("KFJ", List_KFJ);
            dic.Add("KTJ", List_KTJ);
            dic.Add("PJJ", List_PJJ);
            return dic;
        }

        public Dictionary<string, object> JHList_XMBPG(string dtName1)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            List<LQ_SCPG> list = new List<LQ_SCPG>();


            DataTable dt = dal.JHList(1, " ", dtName1).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_SCPG model = new LQ_SCPG();
                DataRow dr = dt.Rows[i];
                model = dal.SCPG_Model(dr);
                list.Add(model);
            }

            LQ_XMBPG DYXMB = new LQ_XMBPG();
            DYXMB.LJFGS = "第一项目部";
            LQ_XMBPG DEXMB = new LQ_XMBPG();
            DEXMB.LJFGS = "第二项目部";
            LQ_XMBPG DSXMB = new LQ_XMBPG();
            DSXMB.LJFGS = "第三项目部";
            LQ_XMBPG ZDXMB = new LQ_XMBPG();
            ZDXMB.LJFGS = "准东项目部";
            LQ_XMBPG TLMXMB = new LQ_XMBPG();
            TLMXMB.LJFGS = "塔里木项目部";
            LQ_XMBPG HWXMB = new LQ_XMBPG();
            HWXMB.LJFGS = "海外项目部";
         
            DYXMB.KFJ_List = list.Where(m => m.REPORT_TYPE == "开发井" && m.LJFGS == DYXMB.LJFGS).ToList<LQ_SCPG>();
            DYXMB.KTJ_List = list.Where(m => m.REPORT_TYPE == "探井" && m.LJFGS == DYXMB.LJFGS).ToList<LQ_SCPG>();
            DYXMB.PJJ_List = list.Where(m => m.REPORT_TYPE == "评价井" && m.LJFGS == DYXMB.LJFGS).ToList<LQ_SCPG>();

            DEXMB.KFJ_List = list.Where(m => m.REPORT_TYPE == "开发井" && m.LJFGS == DEXMB.LJFGS).ToList<LQ_SCPG>();
            DEXMB.KTJ_List = list.Where(m => m.REPORT_TYPE == "探井" && m.LJFGS == DEXMB.LJFGS).ToList<LQ_SCPG>();
            DEXMB.PJJ_List = list.Where(m => m.REPORT_TYPE == "评价井" && m.LJFGS == DEXMB.LJFGS).ToList<LQ_SCPG>();

            DSXMB.KFJ_List = list.Where(m => m.REPORT_TYPE == "开发井" && m.LJFGS == DSXMB.LJFGS).ToList<LQ_SCPG>();
            DSXMB.KTJ_List = list.Where(m => m.REPORT_TYPE == "探井" && m.LJFGS == DSXMB.LJFGS).ToList<LQ_SCPG>();
            DSXMB.PJJ_List = list.Where(m => m.REPORT_TYPE == "评价井" && m.LJFGS == DSXMB.LJFGS).ToList<LQ_SCPG>();

            ZDXMB.KFJ_List = list.Where(m => m.REPORT_TYPE == "开发井" && m.LJFGS == ZDXMB.LJFGS).ToList<LQ_SCPG>();
            ZDXMB.KTJ_List = list.Where(m => m.REPORT_TYPE == "探井" && m.LJFGS == ZDXMB.LJFGS).ToList<LQ_SCPG>();
            ZDXMB.PJJ_List = list.Where(m => m.REPORT_TYPE == "评价井" && m.LJFGS == ZDXMB.LJFGS).ToList<LQ_SCPG>();

            TLMXMB.KFJ_List = list.Where(m => m.REPORT_TYPE == "开发井" && m.LJFGS == TLMXMB.LJFGS).ToList<LQ_SCPG>();
            TLMXMB.KTJ_List = list.Where(m => m.REPORT_TYPE == "探井" && m.LJFGS == TLMXMB.LJFGS).ToList<LQ_SCPG>();
            TLMXMB.PJJ_List = list.Where(m => m.REPORT_TYPE == "评价井" && m.LJFGS == TLMXMB.LJFGS).ToList<LQ_SCPG>();

            HWXMB.KFJ_List = list.Where(m => m.REPORT_TYPE == "开发井" && m.LJFGS == HWXMB.LJFGS).ToList<LQ_SCPG>();
            HWXMB.KTJ_List = list.Where(m => m.REPORT_TYPE == "探井" && m.LJFGS == HWXMB.LJFGS).ToList<LQ_SCPG>();
            HWXMB.PJJ_List = list.Where(m => m.REPORT_TYPE == "评价井" && m.LJFGS == HWXMB.LJFGS).ToList<LQ_SCPG>();
             
            dic.Add("DYXMB", DYXMB);
            dic.Add("DEXMB", DEXMB);
            dic.Add("DSXMB", DSXMB);
            dic.Add("ZDXMB", ZDXMB);
            dic.Add("TLMXMB", TLMXMB);
            dic.Add("HWXMB", HWXMB); 
            return dic;
        }

        #region ==========队伍动用统计===========
        public Dictionary<string, object> DWCountList(string dtName1, string dtName61)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            string Time = DateTime.Now.ToString("yyyy/MM/dd");
            //Time = "2018/07/20";
            List<SCJSK_Count> allList = new List<SCJSK_Count>();
            List<SCJSK_Count> dyList = new List<SCJSK_Count>();
            List<SCJSK_Count> xzList = new List<SCJSK_Count>();
            DataTable allDw = dal.DW_Count(Time, dtName1, dtName61).Tables[0];
            for (int i = 0; i < allDw.Rows.Count; i++)
            {
                SCJSK_Count model = new SCJSK_Count();
                model = dal.Count_Model(allDw.Rows[i]);
                allList.Add(model);
            }
            //动用队伍统计
            DataTable dyDw = dal.DWDY_Count(Time, dtName1, dtName61).Tables[0];
            for (int i = 0; i < dyDw.Rows.Count; i++)
            {
                SCJSK_Count model = new SCJSK_Count();
                model = dal.Count_Model(dyDw.Rows[i]);
                dyList.Add(model);
            }

            for (int i = 0; i < allList.Count; i++)
            {
                for (int j = 0; j < dyList.Count; j++)
                {
                    if (allList[i].LJFGS == dyList[j].LJFGS)
                    {
                        dyList[i].TYPE = "动用";
                        SCJSK_Count model = new SCJSK_Count();
                        model.TYPE = "闲置";
                        model.TOTAL = allList[i].TOTAL - dyList[i].TOTAL;
                        model.LJFGS = allList[i].LJFGS;
                        xzList.Add(model);

                    }
                }
            }
            dic.Add("dy", dyList);
            dic.Add("xz", xzList);
            return dic;
        }
        #endregion

        #region ==========施工统计===========
        public Dictionary<string, object> SGCountList(string dtName1, string dtName61)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            string Time = DateTime.Now.ToString("yyyy/MM/dd");
            //Time = "2018/07/20"; 
            List<SCJSK_Count> wzList = new List<SCJSK_Count>();
            List<SCJSK_Count> zzList = new List<SCJSK_Count>();
            //完钻统计
            DataTable SGWZ = dal.SGWZ_Count(Time, dtName1, dtName61).Tables[0];
            for (int i = 0; i < SGWZ.Rows.Count; i++)
            {
                SCJSK_Count model = new SCJSK_Count();
                model = dal.Count_Model(SGWZ.Rows[i]);
                model.TYPE = "完钻";
                wzList.Add(model);
            }
            //正钻统计
            DataTable SGZZ = dal.SGZZ_Count(Time, dtName1, dtName61).Tables[0];
            for (int i = 0; i < SGZZ.Rows.Count; i++)
            {
                SCJSK_Count model = new SCJSK_Count();
                model = dal.Count_Model(SGZZ.Rows[i]);
                model.TYPE = "正钻";
                zzList.Add(model);
            }

            dic.Add("wz", wzList);
            dic.Add("zz", zzList);
            return dic;
        }
        #endregion

        #region ==========完井明细列表===========
        public Dictionary<string, object> WJList(string dtName1)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
              
            List<LQ_WJMX> list = new List<LQ_WJMX>(); 
            //完钻统计
            DataTable dt = dal.WJList(dtName1).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_WJMX model = new LQ_WJMX();
                model = dal.WJMX_Model(dt.Rows[i]); 
                list.Add(model);
            }
            
            dic.Add("list", list); 
            return dic;
        }
        #endregion
    }
}
