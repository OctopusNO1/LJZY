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
    public class LQ_GCJDBLL
    {
        private readonly LQ_GCJDDAO dal;

        public LQ_GCJDBLL()
        {
            dal = new LQ_GCJDDAO();
        }

        #region 工程进度模块
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="GCJD"></param>
        /// <returns></returns>
        //public bool Add( LQ_GCJD GCJD, LQ_GCJD_CZ CZ, LQ_GCJD_ZT ZT )
        //{
        //    string CZSql = dal.GCJDCZ_Check ( CZ );
        //    string ZTSql = dal.GCJDZT_Check ( ZT );
        //    return dal.Add ( GCJD, CZSql, ZTSql );
        //}

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="GCJD"></param>
        /// <returns></returns>
        public bool Update(LQ_GCJD GCJD, LQ_GCJD_CZ CZ, LQ_GCJD_ZT ZT, string dtName1)
        {
            string CZSql = dal.GCJDCZ_Check(CZ);
            string ZTSql = dal.GCJDZT_Check(ZT);
            return dal.Update(GCJD, CZSql, ZTSql, dtName1);
        }

        public bool Update(List<LQ_GCJD> list,string dtName1)
        { 
            return dal.Update(list, dtName1);
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
        public DataTable LQ_GCJDInfo_Check(string JH, string JX, string dtName1)
        {
            List<LQ_GCJD> list = new List<LQ_GCJD>();
            string strSql = string.Format(@" AND JH='{0}' ", JH, JX);
            DataTable dt = dal.GCJD_Check(strSql, dtName1).Tables[0];

            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    LQ_GCJD model = new LQ_GCJD ( );
            //    DataRow dr = dt.Rows[i];
            //    model = dal.GCJDModel ( dr );
            //    list.Add ( model );
            //}
            return dt;
        }

        /// <summary>
        /// 工程进度表格分页数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public Dictionary<string, object> GCJDDataGrid(string strWhere, int rows, int page, string sort, string order, string dtName1, string dtName61)
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
            List<LQ_GCJD> list = new List<LQ_GCJD>();

            DataTable dt = dal.GCJDInfo_strWhere(strWhere, rows, page, filedOrder, out recordCount, dtName1, dtName61).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_GCJD model = new LQ_GCJD();
                DataRow dr = dt.Rows[i];
                model = dal.GCJDModel(dr);
                list.Add(model);
            }


            dic.Add("total", recordCount.ToString());
            dic.Add("rows", list);
            return dic;
        }

        public DataTable GCJDData(string strWhere, string dtName1, string dtName61)
        {
             
            DataTable dt = dal.GCJDData(strWhere, dtName1, dtName61).Tables[0]; 
            return dt;
        }

        /// <summary>
        /// 工程进度根据井号获取
        /// </summary>
        /// <param name="ZJH"></param>
        /// <returns></returns>
        public LQ_GCJD GCJDInfo_JH(string JH, string strWhere, string dtName1, string dtName61)
        {
            LQ_GCJD model = new LQ_GCJD();
            model.TROW = 0;
            string JHWhere = string.Format(" AND JH='{0}' ", JH);
            DataTable dt = dal.GCJDInfo(JHWhere, strWhere, dtName1, dtName61).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                model = dal.GCJDModel(dr);
            }
            return model;
        }

        /// <summary>
        /// 通过条件获取工程进度信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<LQ_GCJD> GCJDInfo_List(string strWhere, string dtName1, string dtName61)
        {
            List<LQ_GCJD> list = new List<LQ_GCJD>();
            DataTable dt = dal.GCJDInfo(strWhere, dtName1, dtName61).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_GCJD model = new LQ_GCJD();
                DataRow dr = dt.Rows[i];
                model = dal.GCJDModel(dr);
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
        public LQ_GCJD GCJDInfo(int TROW, string strWhere, string dtName1, string dtName61)
        {
            LQ_GCJD model = new LQ_GCJD();
            model.TROW = 0;
            string JHWhere = string.Format(" AND TROW={0} ", TROW);
            DataTable dt = dal.GCJDInfo(JHWhere, strWhere, dtName1, dtName61).Tables[0];

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                model = dal.GCJDModel(dr);
            }
            

            DataTable ZTdt = dal.ZTInfo(string.Format(@" AND ZJH='{0}'", model.ZJH)).Tables[0];
            if (ZTdt.Rows.Count > 0)
            {
                model.ZTMC = ZTdt.Rows[0]["ZTMC"].ToString();
                if (ZTdt.Rows[0]["ZTKSSJ"] == DBNull.Value)
                {
                    model.ZTKSSJ = null;
                }
                else
                {
                    model.ZTKSSJ = Convert.ToDateTime(ZTdt.Rows[0]["ZTKSSJ"]);
                }

                if (ZTdt.Rows[0]["ZTJSSJ"] == DBNull.Value)
                {
                    model.ZTJSSJ = null;
                }
                else
                {
                    model.ZTJSSJ = Convert.ToDateTime(ZTdt.Rows[0]["ZTJSSJ"]);
                }

               
            }
            else
            {
                model.ZTKSSJ = null;
                model.ZTJSSJ = null;
            }
            return model;
        }

        public List<LQ_GCJD> AllGCJDInfo(string strWhere, string dtName1, string dtName61)
        {
            List<LQ_GCJD> list = new List<LQ_GCJD>();

            DataTable dt = dal.GCJDInfo_TROW(strWhere, dtName1, dtName61).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_GCJD model = new LQ_GCJD();
                DataRow dr = dt.Rows[i];
                model = dal.GCJDModel(dr);
                list.Add(model);
            }
            return list;
        }

        public int COUNT_List(string strWhere, string dtName1, string dtName61)
        {
            return dal.COUNT_List(strWhere, dtName1, dtName61);

        }

        ///// <summary>
        ///// 统计数据总条数
        ///// </summary>
        ///// <returns></returns>
        //public int COUNT_List( string strWhere, string dtName1, string dtName61 )
        //{
        //    return dal.COUNT_List ( strWhere, dtName1, dtName61 );
        //}


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

        /// <summary>
        /// 根据井号获取表单数据
        /// </summary>
        /// <param name="JH"></param>
        /// <returns></returns>
        public LQ_GCJD GCJDInfoByJH(string JH)
        {
            LQ_GCJD model = new LQ_GCJD();
            DataTable dt = dal.GCJDInfoByJH(JH).Tables[0];
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                model = dal.GCJDModelByJH(dr);
            }
            return model;
        }
        #endregion
    }
}
