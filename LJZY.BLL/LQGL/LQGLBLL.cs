using LJZY.MODEL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls.Map;
using LJZY.DAO.LQGL;

namespace LJZY.BLL.LQGL
{
    public class LQGLBLL
    {
        private readonly LQGLDAO dal;

        public LQGLBLL()
        {
            dal = new LQGLDAO();
        }

        /// <summary>
        /// 获取菜单字段表中分类
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public string Ptype(string Name)
        {
            return dal.Ptype(Name);
        }

        /// <summary>
        /// 单井设计列表数据
        /// </summary>
        /// <returns></returns>
        public List<LQ_DJSJ> DJSJInfo_List(string strWhere, string dtName)
        {
            List<LQ_DJSJ> list = new List<LQ_DJSJ>();
            DataTable dt = dal.DJSJInfo(strWhere, dtName).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_DJSJ model = new LQ_DJSJ();
                DataRow dr = dt.Rows[i];
                model = dal.DJSJModel(dr);
                list.Add(model);
            }
            return list;
        }

        public List<LQ_DJSJ> JH_List(string strWhere, string dtName)
        {
            List<LQ_DJSJ> list = new List<LQ_DJSJ>();
            DataTable dt = dal.JHList(strWhere, dtName).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_DJSJ model = new LQ_DJSJ();
                DataRow dr = dt.Rows[i];
                model = dal.DJSJModel(dr);
                list.Add(model);
            }
            return list;
        }


        /// <summary>
        /// 单井设计表格分页数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public Dictionary<string, object> DJSJDataGrid(string strWhere, int rows, int page, string dtName)
        {

            Dictionary<string, object> dic = new Dictionary<string, object>();
            int recordCount = 0;
            List<LQ_DJSJ> list = new List<LQ_DJSJ>();

            DataTable dt = dal.DJSJInfo_strWhere(strWhere, rows, page, " JH DESC,REPORT_TYPE ", out recordCount, dtName).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)    //dt转List<LQ_DJSJ>
            {
                LQ_DJSJ model = new LQ_DJSJ();
                DataRow dr = dt.Rows[i];
                model = dal.DJSJModel(dr);
                list.Add(model);
            }

            LQ_FILEBLL fileBLL = new LQ_FILEBLL();
            for (int i = 0; i < list.Count; i++)
            {
                //井位设计
                list[i].JWSJList = fileBLL.FileInfoList(list[i].ZJH, "井位设计");
                list[i].ZJDZSJList = fileBLL.FileInfoList(list[i].ZJH, "钻井地质设计");
                list[i].ZJGCSJList = fileBLL.FileInfoList(list[i].ZJH, "钻井工程设计");
                list[i].SJTLDMTList = fileBLL.FileInfoList(list[i].ZJH, "设计讨论多媒体");
            }

            dic.Add("count", recordCount.ToString());
            dic.Add("code", 0);
            dic.Add("msg", null);
            dic.Add("data", list);
            return dic;
        }

        /// <summary>
        /// 单井设计根据井号获取
        /// </summary>
        /// <param name="ZJH"></param>
        /// <returns></returns>
        public List<LQ_DJSJ> DJSJInfo_JH(string REPORT_TYPE, string JH, string JX, string dtName)
        {
            List<LQ_DJSJ> list = new List<LQ_DJSJ>();
            string strWhere = string.Format(@" AND JH='{0}'", JH);

            DataTable dt = dal.DJSJInfo(REPORT_TYPE, strWhere, dtName).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_DJSJ model = new LQ_DJSJ();
                DataRow dr = dt.Rows[i];
                model = dal.DJSJModel(dr);
                model.XH = i;
                list.Add(model);
            }
            return list;
        }

        /// <summary>
        /// 单井设计根据排序条件获取
        /// </summary>
        /// <param name="MaxXH"></param>
        /// <returns></returns>
        public List<LQ_DJSJ> DJSJInfo(int TROW, string strWhere, string dtName)
        {
            List<LQ_DJSJ> list = new List<LQ_DJSJ>();

            DataTable dt = dal.DJSJInfo_TROW(strWhere, dtName).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_DJSJ model = new LQ_DJSJ();
                DataRow dr = dt.Rows[i];
                model = dal.DJSJModel(dr);
                list.Add(model);
            }

            list = list.Where(o => o.TROW == TROW).ToList<LQ_DJSJ>();
            return list;
        }

        /// <summary>
        /// 判断ZJH是否存在
        /// </summary>
        /// <param name="ZJH"></param>
        /// <returns></returns>
        public bool DJSJInfo_Check(string JH, out string Message, string dtName)
        {
             
            string strSql = string.Format(@" AND JH='{0}' ", JH);
            DataTable dt = dal.DJSJInfo(strSql, dtName).Tables[0];
            if (dt.Rows.Count > 0)
            {
                LQ_DJSJ model = new LQ_DJSJ();
                DataRow dr = dt.Rows[0];
                model = dal.DJSJModel(dr);
                if (model.ISFINISH == 1)
                {
                    Message = "该井号已完成派工,无法修改!";
                    return false;
                }
                Message = "";
                return true;
            }
            else
            {
                Message = "";
                return false;
            }
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    LQ_DJSJ model = new LQ_DJSJ();
            //    DataRow dr = dt.Rows[i];
            //    model = dal.DJSJModel(dr);
            //    list.Add(model);
            //}
            //if (list.Count > 0)
            //{
                
            //}
            //else
            //{
            //    Message = "";
            //    return false;
            //}


        }

        /// <summary>
        /// 单井设计数据修改
        /// </summary>
        /// <param name="DJSJ"></param>
        /// <returns></returns>
        public bool Del(string JH, string JX, string dtName1)
        {
            return dal.Del(JH, JX, dtName1);
        }

        /// <summary>
        /// 单井设计数据修改
        /// </summary>
        /// <param name="DJSJ"></param>
        /// <returns></returns>
        public bool Update(LQ_DJSJ DJSJ, string dtName)
        {
            return dal.Update(DJSJ, dtName);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(LQ_DJSJ model, string dtName)
        {
            return dal.Add(model, dtName);
        }

        /// <summary>
        /// 统计数据总条数
        /// </summary>
        /// <returns></returns>
        public int COUNT_List(string dtName, string strWhere)
        {
            return dal.COUNT_List(dtName, strWhere);
        }


        /// <summary>
        /// 地图列表
        /// </summary>
        /// <returns></returns>
        public DataTable List_Map()
        {
            try
            {
                //ObservableCollection<MapItem> list = new ObservableCollection<MapItem>();
                DataTable dt = dal.MapList().Tables[0];
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    DataRow dr = dt.Rows[i];
                //    MapItem model = new MapItem(dr["SC3"].ToString(), new Location(Convert.ToDouble(dr["SJZZB"]), Convert.ToDouble(dr["SJHZB"])), 5, new ZoomRange(5, 12)); 

                //    list.Add(model);
                //}
                return dt;
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
