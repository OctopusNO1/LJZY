using LJZY.DBUtility;
using LJZY.MODEL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.DAO.LQGL
{
    public class LQ_SCPGDAO
    {
        public int SCPG_Check(string JHstr, string dtName1)
        {
            string Sql = @"
SELECT Count(*)
  FROM " + dtName1 + @" a
  LEFT JOIN LQ_SCPG b ON a.JH = b.JH
 WHERE nvl( b.FPZT, 0 ) = 0 AND a.JH IN (" + JHstr + ") ";
            object result = DbHelperOra.GetSingle(Sql);
            if (result != null)
            {
                return Convert.ToInt32(result);
            }
            return 0;
        }

        public int RWTH_Check(string JHstr)
        {
            string Sql = @"
SELECT Count(*)
  FROM LQ_SCPG  
 WHERE JH IN (" + JHstr + ") ";
            object result = DbHelperOra.GetSingle(Sql);
            if (result != null)
            {
                return Convert.ToInt32(result);
            }
            return 0;
        }


        public bool SCPG_Insert(List<LQ_SCPG> list, string dtName1)
        {
            ArrayList arrlist = new ArrayList();
            for (int i = 0; i < list.Count; i++)
            {
                string Sql = string.Format(@" 
INSERT INTO  LQ_SCPG (JH, LJFGS,TJR, TJSJ) 
VALUES ( '{0}','{1}','{2}',TO_DATE('{3}','YYYY-MM-DD')) ", list[i].JH, list[i].LJFGS, list[i].TJR, list[i].TJSJ);
                arrlist.Add(Sql);
                StringBuilder strSql = new StringBuilder();
                strSql.AppendFormat(@" Update " + dtName1 + @"
                                    SET ISFINISH = 1
                                    WHERE JH = '{0}' ", list[i].JH);
                arrlist.Add(strSql.ToString());
            }
            return DbHelperOra.ExecuteSqlTrans(arrlist);
        }

        public bool SCPG_Del(List<string> JHList, string dtName1)
        {
            ArrayList arrlist = new ArrayList();
            for (int i = 0; i < JHList.Count; i++)
            {
                string Sql = string.Format(@" 
DELETE FROM LQ_SCPG WHERE JH='{0}'", JHList[i].ToString());
                arrlist.Add(Sql);
                StringBuilder strSql = new StringBuilder();
                strSql.AppendFormat(@" Update " + dtName1 + @"
                                    SET ISFINISH = 0
                                    WHERE JH = '{0}' ", JHList[i].ToString());
                arrlist.Add(strSql.ToString());
            }
            return DbHelperOra.ExecuteSqlTrans(arrlist);
        }

        public bool QTPG_Del(List<LQ_SCPG> JHList, string REPORT_TYPE, string dtName1)
        {
            ArrayList arrlist = new ArrayList();
            for (int i = 0; i < JHList.Count; i++)
            {
                string Sql = string.Format(@" 
DELETE LQ_SCPG
WHERE JH IN (SELECT JH
                FROM RB_ADLJ01
               WHERE JH = '{0}' ) ", JHList[i].JH);
                arrlist.Add(Sql);
                StringBuilder strSql = new StringBuilder();
                strSql.AppendFormat(@" Update " + dtName1 + @"
                                    SET ISFINISH = 0
                                    WHERE JH = '{0}'  ", JHList[i].JH, REPORT_TYPE);
                arrlist.Add(strSql.ToString());
            }
            return DbHelperOra.ExecuteSqlTrans(arrlist);
        }

        /// <summary>
        /// 待派工井号列表
        /// </summary>
        /// <param name="dtName1"></param>
        /// <returns></returns>
        public DataSet JHList(int FPZT, string strWhere, string dtName1)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"
SELECT a.JH,nvl( a.ISFINISH, 0 ) ISFINISH,nvl( a.ISLATESTRECORD, 0 ) ISLATESTRECORD,a.REPORT_TYPE,b.LJFGS
  FROM " + dtName1 + @" a
  LEFT JOIN LQ_SCPG b ON a.JH = b.JH
 WHERE nvl( a.ISLATESTRECORD, 0 )=1 AND nvl( a.ISFINISH, 0 )={0} ", FPZT);
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 分配其他井号列表
        /// </summary>
        /// <param name="dtName1"></param>
        /// <returns></returns>
        public DataSet JHList_QT(string dtName1)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@" SELECT JH,LJFGS,'' REPORT_TYPE FROM LQ_SCPG Where LJFGS='其他' ");

            return DbHelperOra.Query(strSql.ToString());
        }

        public DataSet Count_ZSY()
        {
            string strSql = @"SELECT DW LJFGS,COUNT(*) DWZS,COUNT(CASE SBSZWZ WHEN '厂区' THEN SBSZWZ ELSE NULL END) DMDW FROM LQ_SB_ZSY ";

            strSql += "GROUP BY DW ";
            return DbHelperOra.Query(strSql);
        }

        public DataSet Count_ZHY()
        {
            string strSql = @"SELECT SSDW LJFGS,COUNT(*) DWZS,COUNT(CASE SBSZWZ WHEN '厂区' THEN SBSZWZ ELSE NULL END) DMDW FROM LQ_SB_ZHY ";

            strSql += "GROUP BY SSDW ";
            return DbHelperOra.Query(strSql);
        }

        public DataSet Count_GCCSY()
        {
            string strSql = @"SELECT DW LJFGS,COUNT(*) DWZS,COUNT(CASE SBSZWZ WHEN '厂区' THEN SBSZWZ ELSE NULL END) DMDW FROM LQ_SB_GCCSY ";

            strSql += "GROUP BY DW ";
            return DbHelperOra.Query(strSql);
        }

        public DataSet Count_DHFX()
        {
            string strSql = @"SELECT SSDW LJFGS,COUNT(*) DWZS,COUNT(CASE SBSZWZ WHEN '厂区' THEN SBSZWZ ELSE NULL END) DMDW FROM LQ_SB_DHFX ";

            strSql += "GROUP BY SSDW ";
            return DbHelperOra.Query(strSql);
        }

        public LQ_XMBPG XMBCount_Model(DataRow dr)
        {
            LQ_XMBPG model = new LQ_XMBPG();
            if (dr["LJFGS"] != null && dr["LJFGS"].ToString() != "")
            {
                model.LJFGS = dr["LJFGS"].ToString();
            }
            if (dr["DWZS"] != null && dr["DWZS"].ToString() != "")
            {
                model.DWZS = Convert.ToInt32(dr["DWZS"]);
            }
            if (dr["DMDW"] != null && dr["DMDW"].ToString() != "")
            {
                model.DMDW = Convert.ToInt32(dr["DMDW"]);
            }
            return model;
        }


        public LQ_SCPG SCPG_Model(DataRow dr)
        {
            LQ_SCPG model = new LQ_SCPG();
            if (dr["JH"] != null && dr["JH"].ToString() != "")
            {
                model.JH = dr["JH"].ToString();
            }
            if (dr["LJFGS"] != null && dr["LJFGS"].ToString() != "")
            {
                model.LJFGS = dr["LJFGS"].ToString();
            }
            if (dr["REPORT_TYPE"] != null && dr["REPORT_TYPE"].ToString() != "")
            {
                model.REPORT_TYPE = dr["REPORT_TYPE"].ToString();
            }
            //if (dr["FPZT"] != null && dr["FPZT"].ToString ( ) != "")
            //{
            //    model.FPZT = Convert.ToInt32 ( dr["FPZT"] );
            //}
            return model;
        }

        #region ==========队伍动用统计==========
        public DataSet DW_Count(string Time, string dtName1, string dtName61)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"  
SELECT LJFGS, COUNT (LJFGS) TOTAL
    FROM (SELECT CASE L.LJFGS
                     WHEN '第一项目部' THEN '第一项目部'
                     WHEN '第二项目部' THEN '第二项目部'
                     WHEN '第三项目部' THEN '第三项目部'
                     WHEN '准东项目部' THEN '准东项目部'
                     WHEN '塔里木项目部' THEN '塔里木项目部'
                     WHEN '海外项目部' THEN '第二项目部'
                     ELSE '其他'
                 END
                     LJFGS,
                 L.LJYQXH
            FROM " + dtName1 + @" L INNER JOIN " + dtName61 + @" D ON L.JH = D.JH
           WHERE    HBRQ = TO_DATE ('{0}', 'YYYY/MM/DD')
                 OR L.DQZT = '待录') T
GROUP BY LJFGS", Time);

            return DbHelperOra.Query(strSql.ToString());
        }


        public DataSet DWDY_Count(string Time, string dtName1, string dtName61)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"  
SELECT LJFGS, COUNT (LJYQXH) TOTAL
    FROM (SELECT CASE L.LJFGS
                     WHEN '第一项目部' THEN '第一项目部'
                     WHEN '第二项目部' THEN '第二项目部'
                     WHEN '第三项目部' THEN '第三项目部'
                     WHEN '准东项目部' THEN '准东项目部'
                     WHEN '塔里木项目部' THEN '塔里木项目部'
                     WHEN '海外项目部' THEN '第二项目部'
                     ELSE '其他'
                 END
                     LJFGS,
                 L.LJYQXH
            FROM " + dtName1 + @" L INNER JOIN " + dtName61 + @" D ON L.JH = D.JH
           WHERE    HBRQ = TO_DATE ('{0}', 'YYYY/MM/DD')
                 OR L.DQZT = '待录') T
GROUP BY LJFGS", Time);

            return DbHelperOra.Query(strSql.ToString());
        }


        public SCJSK_Count Count_Model(DataRow dr)
        {

            SCJSK_Count model = new SCJSK_Count();
            if (dr["LJFGS"] != null && dr["LJFGS"].ToString() != "")
            {
                model.LJFGS = dr["LJFGS"].ToString();
            }

            if (dr["TOTAL"] != null && dr["TOTAL"].ToString() != "")
            {
                model.TOTAL = Convert.ToInt32(dr["TOTAL"]);
            }

            return model;
        }
        #endregion

        #region ========施工统计=========
        public DataSet SGZZ_Count(string Time, string dtName1, string dtName61)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"  
  SELECT LJFGS, COUNT (JH) TOTAL,TYPE
    FROM (SELECT CASE L.LJFGS
                     WHEN '第一项目部' THEN '第一项目部'
                     WHEN '第二项目部' THEN '第二项目部'
                     WHEN '第三项目部' THEN '第三项目部'
                     WHEN '准东项目部' THEN '准东项目部'
                     WHEN '塔里木项目部' THEN '塔里木项目部'
                     WHEN '海外项目部' THEN '第二项目部'
                     ELSE '其他'
                 END
                     LJFGS,
                 L.JH,CASE L.DQZT WHEN '正录' THEN '正钻' WHEN '待录' THEN '正钻' WHEN '待派' THEN '正钻' WHEN '完井' THEN '完钻' END AS TYPE
            FROM " + dtName1 + @" L INNER JOIN " + dtName61 + @" D ON L.JH = D.JH
           WHERE    HBRQ = TO_DATE ('{0}', 'YYYY/MM/DD') ) T
           WHERE TYPE!='完钻'
GROUP BY LJFGS,TYPE", Time);

            return DbHelperOra.Query(strSql.ToString());
        }


        public DataSet SGWZ_Count(string Time, string dtName1, string dtName61)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"  
  SELECT LJFGS, COUNT (JH) TOTAL,TYPE
    FROM (SELECT CASE L.LJFGS
                     WHEN '第一项目部' THEN '第一项目部'
                     WHEN '第二项目部' THEN '第二项目部'
                     WHEN '第三项目部' THEN '第三项目部'
                     WHEN '准东项目部' THEN '准东项目部'
                     WHEN '塔里木项目部' THEN '塔里木项目部'
                     WHEN '海外项目部' THEN '第二项目部'
                     ELSE '其他'
                 END
                     LJFGS,
                 L.JH,CASE L.DQZT WHEN '正录' THEN '正钻' WHEN '待录' THEN '正钻' WHEN '待派' THEN '正钻' WHEN '完井' THEN '完钻' END AS TYPE
            FROM " + dtName1 + @" L INNER JOIN " + dtName61 + @" D ON L.JH = D.JH
           WHERE    HBRQ = TO_DATE ('{0}', 'YYYY/MM/DD') ) T
           WHERE TYPE='完钻'
GROUP BY LJFGS,TYPE", Time);
            return DbHelperOra.Query(strSql.ToString());
        }
        #endregion

        #region ========完井明细表========


        public DataSet WJList(string dtName1)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"  
SELECT ROW_NUMBER ()
       OVER (
           ORDER BY
               CASE LJFGS
                   WHEN '第一项目部' THEN 0
                   WHEN '第二项目部' THEN 1
                   WHEN '第三项目部' THEN 2
                   WHEN '准东项目部' THEN 3
                   WHEN '塔里木项目部' THEN 4
                   WHEN '海外项目部' THEN 5
                   ELSE 100
               END ASC)
           AS TROW,
       LJFGS,
       JH,
       LJDH,
       SGDH,
       YJWJRQ
  FROM " + dtName1 + " WHERE DQZT='完井'  ");
            return DbHelperOra.Query(strSql.ToString());
        }


        public LQ_WJMX WJMX_Model(DataRow dr)
        {
            LQ_WJMX model = new LQ_WJMX();
            if (dr["TROW"] != null && dr["TROW"].ToString() != "")
            {
                model.TROW = Convert.ToInt32(dr["TROW"]);
            }
            if (dr["JH"] != null && dr["JH"].ToString() != "")
            {
                model.JH = dr["JH"].ToString();
            }
            if (dr["LJFGS"] != null && dr["LJFGS"].ToString() != "")
            {
                model.LJFGS = dr["LJFGS"].ToString();
            }
            if (dr["LJDH"] != null && dr["LJDH"].ToString() != "")
            {
                model.LJDH = dr["LJDH"].ToString();
            }
            if (dr["SGDH"] != null && dr["SGDH"].ToString() != "")
            {
                model.SGDH = dr["SGDH"].ToString();
            }
            if (dr["YJWJRQ"] != null && dr["YJWJRQ"].ToString() != "")
            {
                model.YJWJRQ = dr["YJWJRQ"].ToString();
            }
            return model;
        }
        #endregion
    }
}
