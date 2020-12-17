using LJZY.DBUtility;
using LJZY.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.DAO.LQGL
{
    public class LQ_SCDTDAO
    {
        /// <summary>
        /// 生产动态列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet SCDT_List(string Time, string strWhere, string dtName1, string dtName61)
        {

            string strSql = string.Format(@"
SELECT ROW_NUMBER ()
       OVER (
           ORDER BY
               CASE L.XQXMB
                   WHEN '第一项目部' THEN 0
                   WHEN '第二项目部' THEN 1
                   WHEN '第三项目部' THEN 2
                   WHEN '准东项目部' THEN 3
                   WHEN '塔里木项目部' THEN 4
                   WHEN '海外项目部' THEN 5    
                   ELSE 100
               END ASC,
               L.XQXMB ASC, 
               CASE L.DQZT
                   WHEN '正录' THEN 0
                   WHEN '待录' THEN 1
                   WHEN '待派' THEN 2
                   ELSE 100
               END ASC,
               L.DQZT ASC,
               L.KZRQ DESC)
           AS TROW,
       L.XQXMB,
       L.LJFGS,
       L.DWZBH,
       L.LJYQXH,
       L.LJDH,
       L.SGDH,
       L.JDDT, 
       L.ZJH,
       ''
           AS XDT,
       L.SJJS,
       D.DRJS,
       TO_CHAR (L.KZRQ, 'YYYY-MM-DD') KZRQ,
       TO_CHAR (L.YJWJRQ, 'YYYY-MM-DD') YJWJRQ,
       L.HXJW,
       L.HXJDH,
       D.SGZT,
       L.REPORT_TYPE,
       L.LJFGS LSDW,
       L.DQZT,
       L.BZ
  FROM " + dtName1 + @" L
  INNER JOIN " + dtName61 + @" D ON L.JH=D.JH
  WHERE HBRQ=TO_DATE('{0}','YYYY/MM/DD') ", Time);

            if (strWhere.Trim() != "")
            {
                strSql += strWhere;
            }

            return DbHelperOra.Query(strSql);
        }

        /// <summary>
        /// 工程进度实体类
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public LQ_SCDT SCDTModel(DataRow dr)
        {
            //DateTimeFormatInfo dtFormat = new System.Globalization.DateTimeFormatInfo();
            //dtFormat.ShortDatePattern = "yyyy-MM-dd";
            LQ_SCDT model = new LQ_SCDT();
            if (dr["TROW"] != null && dr["TROW"].ToString() != "")
            {
                model.TROW = Convert.ToInt32(dr["TROW"]);
            }
            if (dr["LJFGS"] != null && dr["LJFGS"].ToString() != "")
            {
                model.LJFGS = dr["LJFGS"].ToString();
            }
            if (dr["ZJH"] != null && dr["ZJH"].ToString() != "")
            {
                model.ZJH = dr["ZJH"].ToString();
            }
            if (dr["LJYQXH"] != null && dr["LJYQXH"].ToString() != "")
            {
                model.LJYQXH = dr["LJYQXH"].ToString();
            }
            if (dr["LJDH"] != null && dr["LJDH"].ToString() != "")
            {
                model.LJDH = dr["LJDH"].ToString();
            }
            if (dr["SGDH"] != null && dr["SGDH"].ToString() != "")
            {
                model.SGDH = dr["SGDH"].ToString();
            }
            if (dr["XDT"] != null && dr["XDT"].ToString() != "")
            {
                model.XDT = dr["XDT"].ToString();
            }
            if (dr["SJJS"] != null && dr["SJJS"].ToString() != "")
            {
                model.SJJS = Convert.ToDecimal(dr["SJJS"]);
            }
            if (dr["DRJS"] != null && dr["DRJS"].ToString() != "")
            {
                model.DRJS = dr["DRJS"].ToString();
            }

            if (dr["KZRQ"] != null && dr["KZRQ"].ToString() != "")
            {
                model.KZRQ = string.Format("{0:yyyy-MM-dd}", dr["KZRQ"]);
                //model.KZRQ = Convert.ToDateTime(KZRQ);

            }
            if (dr["YJWJRQ"] != null && dr["YJWJRQ"].ToString() != "")
            {
                model.YJWJRQ = string.Format("{0:yyyy-MM-dd}", dr["YJWJRQ"]);
                //model.WJRQ = Convert.ToDateTime(WJRQ);
                //model.WJRQ = Convert.ToDateTime(dr["WJRQ"], dtFormat);
            }
            if (dr["HXJW"] != null && dr["HXJW"].ToString() != "")
            {
                model.HXJW = dr["HXJW"].ToString();
            }
            if (dr["HXJDH"] != null && dr["HXJDH"].ToString() != "")
            {
                model.HXJDH = dr["HXJDH"].ToString();
            }
            if (dr["SGZT"] != null && dr["SGZT"].ToString() != "")
            {
                model.SGZT = dr["SGZT"].ToString();
            }
            if (dr["REPORT_TYPE"] != null && dr["REPORT_TYPE"].ToString() != "")
            {
                model.REPORT_TYPE = dr["REPORT_TYPE"].ToString();
            }

            if (dr["DQZT"] != null && dr["DQZT"].ToString() != "")
            {
                model.DQZT = dr["DQZT"].ToString();
            }

            if (dr["BZ"] != null && dr["BZ"].ToString() != "")
            {
                model.BZ = dr["BZ"].ToString();
            }
            if (dr["XQXMB"] != null && dr["XQXMB"].ToString() != "")
            {
                model.XQXMB = dr["XQXMB"].ToString();
            }
            return model;

        }
    }
}
