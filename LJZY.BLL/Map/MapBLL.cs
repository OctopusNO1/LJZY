using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LJZY.DAO.Map;
using LJZY.MODEL;
using System.Data;

namespace LJZY.BLL.Map
{
    public class MapBLL
    {
        private readonly MapDAO dal;

        public MapBLL()
        {
            dal = new MapDAO();
        }
        public List<BDMap> List_MapByJH(string strWhere, string dtName1, string dtName61)
        {
            List<BDMap> list = new List<BDMap>();
            List<LQ_RYFP> rylist = new List<LQ_RYFP>();
            DataTable dt = dal.MapListByJH(strWhere, dtName1, dtName61).Tables[0];
            DataTable rydt = dal.RYList().Tables[0];

            for (int i = 0; i < rydt.Rows.Count; i++)
            {
                LQ_RYFP model = new LQ_RYFP();
                DataRow dr = rydt.Rows[i];
                model = dal.RYModel(dr);
                rylist.Add(model);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BDMap model = new BDMap();
                DataRow dr = dt.Rows[i];
                if (!string.IsNullOrEmpty(dr["SJHZBB"].ToString()) && !string.IsNullOrEmpty(dr["SJZZBB"].ToString()))
                {
                    model = dal.MapModel(dr);
                    model.RyList = rylist.Where(m => m.JH == model.JH).ToList<LQ_RYFP>();
                    list.Add(model);

                }
            }

            return list;
        }
        /// <summary>
        /// 地图列表
        /// </summary>
        /// <returns></returns>
        public List<BDMap> List_Map(string Time, string strWhere, string dtName1, string dtName61)
        {
             
            List<BDMap> list = new List<BDMap>();
            List<LQ_RYFP> rylist = new List<LQ_RYFP>();
            DataTable dt = dal.MapList(Time, strWhere, dtName1, dtName61).Tables[0];
            DataTable rydt = dal.RYList().Tables[0];

            for (int i = 0; i < rydt.Rows.Count; i++)
            {
                LQ_RYFP model = new LQ_RYFP();
                DataRow dr = rydt.Rows[i];
                model = dal.RYModel(dr);
                rylist.Add(model);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BDMap model = new BDMap();
                DataRow dr = dt.Rows[i];
                if (!string.IsNullOrEmpty(dr["SJHZBB"].ToString()) && !string.IsNullOrEmpty(dr["SJZZBB"].ToString()))
                {
                    model = dal.MapModel(dr);
                    model.RyList = rylist.Where(m => m.JH == model.JH).ToList<LQ_RYFP>();
                    list.Add(model);

                }
            }

            return list;
        }

        /// <summary>
        /// 页面统计区域数据
        /// </summary>
        /// <param name="Time"></param>
        /// <param name="dtName1"></param>
        /// <param name="dtName61"></param>
        /// <returns></returns>
        public List<int> CountNum(string Time, string dtName1, string dtName61)
        {
            
            List<int> dic = new List<int>();
            string strWhere_SY = string.Format(" AND b.HBRQ = TO_DATE('{0}', 'YYYY/MM/DD')", Time);
            string strWhere_ZZ = string.Format(" AND b.HBRQ = TO_DATE('{0}', 'YYYY/MM/DD') AND b.SJJS>0 ", Time);
            string strWhere_DP = string.Format(" AND b.HBRQ = TO_DATE('{0}', 'YYYY/MM/DD') AND NVL(a.ISLATESTRECORD,0)=1 AND NVL(a.ISFINISH,0)=0", Time);
            string strWhere_KT = string.Format(" AND b.HBRQ = TO_DATE('{0}', 'YYYY/MM/DD') AND b.SJJS>0 AND a.SC3='勘探公司'", Time);
            string strWhere_KF = string.Format(" AND b.HBRQ = TO_DATE('{0}', 'YYYY/MM/DD') AND b.SJJS>0 AND a.SC3='开发公司'", Time);
            int Count_SY = 0;
            int Count_ZZ = 0;
            int Count_DP = 0;
            int Count_KT = 0;
            int Count_KF = 0;
            Count_SY = dal.CountNum(strWhere_SY, dtName1, dtName61);
            Count_ZZ = dal.CountNum(strWhere_ZZ, dtName1, dtName61);
            Count_DP = dal.CountNum(strWhere_DP, dtName1, dtName61);
            Count_KT = dal.CountNum(strWhere_KT, dtName1, dtName61);
            Count_KF = dal.CountNum(strWhere_KF, dtName1, dtName61);

            //TotalCharts total1 = new TotalCharts();
            //total1.TotalName = "总井数";
            //total1.TotalNum = Count_SY;
            dic.Add(Count_SY);

            //TotalCharts total2 = new TotalCharts();
            //total2.TotalName = "正钻";
            //total2.TotalNum = Count_ZZ;
            dic.Add(Count_ZZ);

            //TotalCharts total3 = new TotalCharts();
            //total3.TotalName = "待派";
            //total3.TotalNum = Count_DP;
            dic.Add(Count_DP);

            //TotalCharts total4 = new TotalCharts();
            //total4.TotalName = "勘探";
            //total4.TotalNum = Count_KTDP;
            //dic.Add(total4);
            dic.Add(Count_KT);
            dic.Add(Count_KF);
            return dic;
        }
    }
}
