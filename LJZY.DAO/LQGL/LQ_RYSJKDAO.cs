using LJZY.COMMON;
using LJZY.DBUtility;
using LJZY.MODEL;
using Oracle.DataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LJZY.DAO.LQGL
{
    public class LQ_RYSJKDAO
    {
        /// <summary>
        /// 人员信息添加
        /// </summary>
        /// <param name="RYSJK"></param>
        /// <returns></returns>
        public bool Add(LQ_RYSJK RYSJK)
        {
            string sqlStr = @"
insert into LQ_RYSJK(RYBH,GW,
XM,
LXDH, 
XB, 
NL, 
XL, 
JKZK, 
ZC, 
JCZ, 
SGZ, 
NDSJTS, 
HSE, 
XMB,
RYZT,
TJR,
TJSJ,
BZ,
YGXZ,
GWXS)
values
 (:RYBH,
:GW,
:XM,
:LXDH, 
:XB, 
:NL, 
:XL, 
:JKZK, 
:ZC, 
:JCZ, 
:SGZ, 
:NDSJTS, 
:HSE, 
:XMB,
:RYZT,
:TJR,
:TJSJ,
:BZ,
:YGXZ,
:GWXS)";
            OracleParameter[] parameter = {
                                            new OracleParameter(":RYBH",OracleDbType.Varchar2,16),
                                            new OracleParameter(":GW",OracleDbType.Varchar2,50),
                                            new OracleParameter(":XM",OracleDbType.Varchar2,26),
                                            new OracleParameter(":LXDH",OracleDbType.Varchar2,18),
                                            new OracleParameter(":XB",OracleDbType.Varchar2,2),
                                            new OracleParameter(":NL",OracleDbType.Varchar2,3),
                                            new OracleParameter(":XL",OracleDbType.Varchar2,10),
                                            new OracleParameter(":JKZK",OracleDbType.Varchar2,4),
                                            new OracleParameter(":ZC",OracleDbType.Varchar2,10),
                                            new OracleParameter(":JCZ",OracleDbType.Varchar2,50),
                                            new OracleParameter(":SGZ",OracleDbType.Varchar2,50),
                                            new OracleParameter(":NDSJTS",OracleDbType.Varchar2,50),
                                            new OracleParameter(":HSE",OracleDbType.Varchar2,50),
                                            new OracleParameter(":XMB",OracleDbType.Varchar2,10),
                                            new OracleParameter(":RYZT",OracleDbType.Varchar2,4),
                                            new OracleParameter(":TJR",OracleDbType.Varchar2,20),
                                            new OracleParameter(":TJSJ",OracleDbType.Date),
                                            new OracleParameter(":BZ",OracleDbType.Varchar2,200),
                                            new OracleParameter(":YGXZ",OracleDbType.Varchar2,50),
                                            new OracleParameter(":GWXS",OracleDbType.Varchar2,50),


                                        };

            parameter[0].Value = RYSJK.RYBH;
            parameter[1].Value = RYSJK.GW;
            parameter[2].Value = RYSJK.XM;
            parameter[3].Value = RYSJK.LXDH;
            parameter[4].Value = RYSJK.XB;
            parameter[5].Value = RYSJK.NL;
            parameter[6].Value = RYSJK.XL;
            parameter[7].Value = RYSJK.JKZK;
            parameter[8].Value = RYSJK.ZC;
            parameter[9].Value = RYSJK.JCZ;
            parameter[10].Value = RYSJK.SGZ;
            parameter[11].Value = RYSJK.NDSJTS;
            parameter[12].Value = RYSJK.HSE;
            parameter[13].Value = RYSJK.XMB;
            parameter[14].Value = RYSJK.RYZT;
            parameter[15].Value = RYSJK.TJR;
            parameter[16].Value = DateTime.Now;
            parameter[17].Value = RYSJK.BZ;
            parameter[18].Value = RYSJK.YGXZ;
            parameter[19].Value = RYSJK.GWXS;
            int rows = DbHelperOra.ExecuteSql(sqlStr, parameter);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 人员管理修改
        /// </summary>
        /// <param name="RYSJK"></param>
        /// <returns></returns>
        /// :GW,:XM,:LXDH, :XB, :NL, :XL, :JKZK, :ZC, :JCZ, :SGZ, :NDSJTS, :HSE, :XMB,:RYZT:BZ,:YGXZ,:GWXS
        public bool Update(LQ_RYSJK RYSJK)
        {
            ArrayList list = new ArrayList();
            string sqlStr = string.Format(@"
Update LQ_RYSJK Set 
GW='{0}',
XM='{1}',
LXDH='{2}', 
XB='{3}', 
NL='{4}', 
XL='{5}', 
JKZK='{6}', 
ZC='{7}', 
JCZ='{8}', 
SGZ='{9}', 
NDSJTS='{10}', 
HSE='{11}', 
XMB='{12}',
RYZT='{13}',
BZ='{14}',
YGXZ='{15}',
GWXS='{16}'

WHERE RYBH= '{17}' ", RYSJK.GW, RYSJK.XM, RYSJK.LXDH, RYSJK.XB, RYSJK.NL, RYSJK.XL, RYSJK.JKZK, RYSJK.ZC, RYSJK.JCZ, RYSJK.SGZ, RYSJK.NDSJTS, RYSJK.HSE, RYSJK.XMB, RYSJK.RYZT, RYSJK.BZ, RYSJK.YGXZ, RYSJK.GWXS, RYSJK.RYBH);
            list.Add(sqlStr);
            string sqlStr2 = string.Format(@"UPDATE LQ_SJRZ SET JSSJRQ=to_date('{0}','yyyy-MM-dd hh24:mi:ss'),GWXS='{1}' WHERE ID IN( SELECT ID FROM (SELECT * FROM LQ_SJRZ ORDER BY TJSJ DESC  ) where ROWNUM=1 AND RYBH='{2}')", RYSJK.JSSJRQ, RYSJK.GWXS, RYSJK.RYBH);
            list.Add(sqlStr2);
            return DbHelperOra.ExecuteSqlTrans(list);
        }
        /// <summary>
        /// 人员管理删除
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool Del(string ID)
        {
            try
            {
                string sqlStr = @" delete from  LQ_RYSJK  WHERE ID=:ID";
                OracleParameter[] parameter = {
                                            new OracleParameter(":ID",OracleDbType.Varchar2,32),
                                          };
                parameter[0].Value = ID;
                int rows = DbHelperOra.ExecuteSql(sqlStr, parameter);
                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet RYSJKInfo(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"
 SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY TJSJ DESC) AS TROW,JCZ,SGZ,HSE,ID,GW,RYBH,XM,LXDH,XB,NL,XL,JKZK,ZC,NDSJTS,XMB,RYZT,TJR,TJSJ,BZ,YGXZ,SJJH,KSSJRQ,JSSJRQ,GWXS,NDJZ FROM LQ_RYSJK T)");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1" + strWhere);
            }

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 查询人员上井日志信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet SJRZInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"
  SELECT *FROM(SELECT * FROM LQ_SJRZ  ORDER BY TJSJ DESC )WHERE ROWNUM=1 AND
 RYBH='" + strWhere + "'");

            return DbHelperOra.Query(strSql.ToString());
        }


        public DataSet GetYearDay(string rybh, string starttime, string endtime, string JH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"
 select * from LQ_SJRZ where KSSJRQ >= to_date('" + starttime + "','yyyy-mm-dd') and JSSJRQ <= to_date('" + endtime + "','yyyy-mm-dd') AND RYBH='" + rybh + "' AND JH='" + JH + "'");

            return DbHelperOra.Query(strSql.ToString());
        }



        /// <summary>
		/// 查询最大序号值
		/// </summary>
		/// <param name="strWhere"></param>
		/// <returns></returns>
        public int COUNT_List()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(*) from LQ_RYSJK ");

            object result = DbHelperOra.GetSingle(strSql.ToString());
            if (result == null)
            {
                return 0;
            }
            return Convert.ToInt32(result);
        }



        public int CheckRY(string RYBH)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(*) from LQ_RYSJK WHERE  RYBH='" + RYBH + "'");

            object result = DbHelperOra.GetSingle(strSql.ToString());
            if (result == null)
            {
                return 0;
            }
            return Convert.ToInt32(result);

        }


        /// <summary>
        ///人员管理查询分页
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="filedOrder"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public DataSet RYSJK_strWhere(string strWhere, int pageSize, int pageIndex, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ROW_NUMBER() OVER(ORDER BY TJSJ DESC) AS TROW,XMB,GW,RYBH,XM,LXDH,XB,NL,XL,YGXZ,JKZK,ZC,GWXS,RYZT,NDSJTS,JCZ,HSE,SGZ,BZ,ID,TJR,TJSJ,SJJH,KSSJRQ,JSSJRQ from LQ_RYSJK  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1 " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperOra.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperOra.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }


        /// <summary>
        /// 人员日志查询分页
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="filedOrder"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public DataSet RYRZ_strWhere(string dtName1, string strWhere, int pageSize, int pageIndex, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@" 
SELECT TROW,ID,RYBH,KSSJRQ,JSSJRQ,GWXS,TJSJ,JH,XM,SJTS,LJSJTS,NVL(JXS,0)JXS,REPORT_TYPE,BZ FROM (
SELECT ROW_NUMBER () OVER (ORDER BY T.TJSJ DESC)
           AS TROW,
       T.ID,
       T.RYBH,
       T.KSSJRQ,
       T.JSSJRQ,
       T.GWXS,
       T.TJSJ,
       T.JH,
       D.XM,
       CAST (
           ROUND (
                 (CASE WHEN T.JSSJRQ IS NULL THEN SYSDATE ELSE T.JSSJRQ END)
               - T.KSSJRQ) AS INT)
           AS SJTS,
       (SELECT SUM (
                   CAST (
                       ROUND (
                             (CASE
                                  WHEN JSSJRQ IS NULL THEN SYSDATE
                                  ELSE JSSJRQ
                              END)
                           - KSSJRQ) AS INT))
                   TOTAL
          FROM LQ_SJRZ
         WHERE RYBH = T.RYBH)
           AS LJSJTS,
       F.JXS,
       F.REPORT_TYPE,D.BZ
  FROM LQ_SJRZ  T
       LEFT JOIN LQ_RYSJK D ON T.RYBH = D.RYBH
       LEFT JOIN " + dtName1 + " F ON T.JH = F.JH ) V");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1 " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperOra.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperOra.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        public DataSet RYRZ_strWhere(string dtName1, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@" 
SELECT TROW,ID,RYBH,TO_CHAR (KSSJRQ, 'YYYY-MM-DD') KSSJRQ,TO_CHAR (JSSJRQ, 'YYYY-MM-DD') JSSJRQ,GWXS,TJSJ,JH,XM,SJTS,LJSJTS,NVL(JXS,0)JXS,REPORT_TYPE,BZ FROM (
SELECT ROW_NUMBER () OVER (ORDER BY T.TJSJ DESC)
           AS TROW,
       T.ID,
       T.RYBH,
       T.KSSJRQ,
       T.JSSJRQ,
       T.GWXS,
       T.TJSJ,
       T.JH,
       D.XM,
       CAST (
           ROUND (
                 (CASE WHEN T.JSSJRQ IS NULL THEN SYSDATE ELSE T.JSSJRQ END)
               - T.KSSJRQ) AS INT)
           AS SJTS,
       (SELECT SUM (
                   CAST (
                       ROUND (
                             (CASE
                                  WHEN JSSJRQ IS NULL THEN SYSDATE
                                  ELSE JSSJRQ
                              END)
                           - KSSJRQ) AS INT))
                   TOTAL
          FROM LQ_SJRZ
         WHERE RYBH = T.RYBH)
           AS LJSJTS,
       F.JXS,
       F.REPORT_TYPE,D.BZ
  FROM LQ_SJRZ  T
       LEFT JOIN LQ_RYSJK D ON T.RYBH = D.RYBH
       LEFT JOIN " + dtName1 + " F ON T.JH = F.JH ) ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1 " + strWhere);
            }
             
            return DbHelperOra.Query(strSql.ToString());
        }

        public DataSet EXCEL_RYSJK(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ROW_NUMBER() OVER(ORDER BY TJSJ DESC) AS TROW,XMB,GW,RYBH,XM,LXDH,XB,NL,XL,YGXZ,JKZK,ZC,GWXS,RYZT,NDSJTS,JCZ,HSE,SGZ,BZ,ID,TJR,TJSJ,SJJH,KSSJRQ,JSSJRQ from LQ_RYSJK  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1 " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        public LQ_RYSJK RYSJKModel(DataRow dr)
        {
            LQ_RYSJK model = new LQ_RYSJK();
            if (dr["ID"] != null && dr["ID"].ToString() != "")
            {
                model.ID = dr["ID"].ToString();
            }

            if (dr["TROW"] != null && dr["TROW"].ToString() != "")
            {
                model.TROW = Convert.ToInt32(dr["TROW"]);
            }

            if (dr["GW"] != null && dr["GW"].ToString() != "")
            {
                model.GW = dr["GW"].ToString();
            }

            if (dr["RYBH"] != null && dr["RYBH"].ToString() != "")
            {
                model.RYBH = dr["RYBH"].ToString();
            }

            if (dr["XM"] != null && dr["XM"].ToString() != "")
            {
                model.XM = dr["XM"].ToString();
            }

            if (dr["LXDH"] != null && dr["LXDH"].ToString() != "")
            {
                model.LXDH = dr["LXDH"].ToString();
            }

            if (dr["XB"] != null && dr["XB"].ToString() != "")
            {
                model.XB = dr["XB"].ToString();
            }

            if (dr["NL"] != null && dr["NL"].ToString() != "")
            {
                model.NL = dr["NL"].ToString();
            }

            if (dr["XL"] != null && dr["XL"].ToString() != "")
            {
                model.XL = dr["XL"].ToString();
            }

            if (dr["JKZK"] != null && dr["JKZK"].ToString() != "")
            {
                model.JKZK = dr["JKZK"].ToString();
            }

            if (dr["ZC"] != null && dr["ZC"].ToString() != "")
            {
                model.ZC = dr["ZC"].ToString();
            }

            if (dr["JCZ"] != null && dr["JCZ"].ToString() != "")
            {
                model.JCZ = dr["JCZ"].ToString();
            }

            if (dr["SGZ"] != null && dr["SGZ"].ToString() != "")
            {
                model.SGZ = dr["SGZ"].ToString();
            }

            if (dr["NDSJTS"] != null && dr["NDSJTS"].ToString() != "")
            {
                model.NDSJTS = dr["NDSJTS"].ToString();
            }

            if (dr["HSE"] != null && dr["HSE"].ToString() != "")
            {
                model.HSE = dr["HSE"].ToString();
            }

            if (dr["XMB"] != null && dr["XMB"].ToString() != "")
            {
                model.XMB = dr["XMB"].ToString();
            }

            if (dr["RYZT"] != null && dr["RYZT"].ToString() != "")
            {
                model.RYZT = dr["RYZT"].ToString();
            }

            if (dr["TJR"] != null && dr["TJR"].ToString() != "")
            {
                model.TJR = dr["TJR"].ToString();
            }

            if (dr["TJSJ"] != null && dr["TJSJ"].ToString() != "")
            {
                model.TJSJ = Convert.ToDateTime(dr["TJSJ"]);
            }

            if (dr["BZ"] != null && dr["BZ"].ToString() != "")
            {
                model.BZ = dr["BZ"].ToString();
            }
            if (dr["YGXZ"] != null && dr["YGXZ"].ToString() != "")
            {
                model.YGXZ = dr["YGXZ"].ToString();
            }
            if (dr["SJJH"] != null && dr["SJJH"].ToString() != "")
            {
                model.SJJH = dr["SJJH"].ToString();
            }
            if (dr["KSSJRQ"] != null && dr["KSSJRQ"].ToString() != "")
            {
                model.KSSJRQ = Convert.ToDateTime(dr["KSSJRQ"]);
                model.KSSJRQ_DG = Convert.ToDateTime(dr["KSSJRQ"]).ToString("yyyy-MM-dd");
            }
            else
            {
                model.KSSJRQ_DG = "";
            }
            if (dr["JSSJRQ"] != null && dr["JSSJRQ"].ToString() != "")
            {
                model.JSSJRQ = Convert.ToDateTime(dr["JSSJRQ"]);
                model.JSSJRQ_DG = Convert.ToDateTime(dr["JSSJRQ"]).ToString("yyyy-MM-dd");
            }
            else
            {
                model.JSSJRQ_DG = "";

            }
            if (dr["GWXS"] != null && dr["GWXS"].ToString() != "")
            {
                model.GWXS = dr["GWXS"].ToString();
            }



            return model;

        }

        public LQ_SJRZ RYRZModel(DataRow dr)
        {
            LQ_SJRZ model = new LQ_SJRZ();
            if (dr["ID"] != null && dr["ID"].ToString() != "")
            {
                model.ID = dr["ID"].ToString();
            }

            if (dr["TROW"] != null && dr["TROW"].ToString() != "")
            {
                model.TROW = Convert.ToInt32(dr["TROW"]);
            }

            if (dr["XM"] != null && dr["XM"].ToString() != "")
            {
                model.XM = dr["XM"].ToString();
            }

            if (dr["RYBH"] != null && dr["RYBH"].ToString() != "")
            {
                model.RYBH = dr["RYBH"].ToString();
            }

            if (dr["TJSJ"] != null && dr["TJSJ"].ToString() != "")
            {
                model.TJSJ = Convert.ToDateTime(dr["TJSJ"]);
            }

            if (dr["KSSJRQ"] != null && dr["KSSJRQ"].ToString() != "")
            {
                model.KSSJRQ = Convert.ToDateTime(dr["KSSJRQ"]);
            }
            else
            {
                model.KSSJRQ_GD = "";
            }
            if (dr["JSSJRQ"] != null && dr["JSSJRQ"].ToString() != "")
            {
                model.JSSJRQ = Convert.ToDateTime(dr["JSSJRQ"]);
            }
            else
            {
                model.JSSJRQ_GD = "";
            }
            if (dr["GWXS"] != null && dr["GWXS"].ToString() != "")
            {
                model.GWXS = dr["GWXS"].ToString();
            }
            if (dr["JH"] != null && dr["JH"].ToString() != "")
            {
                model.JH = dr["JH"].ToString();
            }
            if (dr["SJTS"] != null && dr["SJTS"].ToString() != "")
            {
                model.SJTS = Convert.ToInt32(dr["SJTS"]);
            }
            if (dr["LJSJTS"] != null && dr["LJSJTS"].ToString() != "")
            {
                model.LJSJTS = Convert.ToInt32(dr["LJSJTS"]);
            }
            if (dr["JXS"] != null && dr["JXS"].ToString() != "")
            {
                model.JXS = Convert.ToInt32(dr["JXS"]);
            }
            if (dr["REPORT_TYPE"] != null && dr["REPORT_TYPE"].ToString() != "")
            {
                model.REPORT_TYPE = dr["REPORT_TYPE"].ToString();
            }
            return model;

        }

        public bool ADDNDJZ(LQ_RYSJK lQ_RYSJK, string ID)
        {
            string sqlStr = string.Format(@"UPDATE LQ_RYSJK SET  NDJZ='{0}' WHERE ID='{1}'", lQ_RYSJK.NDJZ, ID);
            int rows = DbHelperOra.ExecuteSql(sqlStr);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
