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
    public class LQ_WJKPDAO
    {
        /// <summary>
        /// 完井统计信息添加
        /// </summary>
        /// <param name="WJKP"></param>
        /// <returns></returns>
        public bool Add(LQ_WJKP WJKP)
        {
            ArrayList list = new ArrayList();
            string sqlStr = string.Format(@"INSERT INTO KLLOGT.AJSJ01(ID,JH,JB,JX,SJZZBX,SJHZBY,SS,ZTMD,GZWZ,DLWZ,CXWZ,DMHB,SJJS,SJMDC) 
                VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}')",
                WJKP.AJSJ01_ID, WJKP.AJSJ01_JH, WJKP.AJSJ01_JB, WJKP.AJSJ01_JX, WJKP.AJSJ01_SJZZBX, WJKP.AJSJ01_SJHZBY, WJKP.AJSJ01_SS, WJKP.AJSJ01_ZTMD, WJKP.AJSJ01_GZWZ, WJKP.AJSJ01_DLWZ, WJKP.AJSJ01_CXWZ, WJKP.AJSJ01_DMHB, WJKP.AJSJ01_SJJS, WJKP.AJSJ01_SJMDC);
            list.Add(sqlStr);
            return DbHelperOra.ExecuteSqlTrans(list);

        //    string sqlStr = @"insert into LQ_WJKP(RYBH,GW,
        //XM,
        //LXDH, 
        //XB, 
        //NL, 
        //XL, 
        //JKZK, 
        //ZC, 
        //JCZ, 
        //SGZ, 
        //NDSJTS, 
        //HSE, 
        //XMB,
        //RYZT,
        //TJR,
        //TJSJ,
        //BZ,
        //YGXZ,
        //GWXS)
        //values
        // (:RYBH,
        //:GW,
        //:XM,
        //:LXDH, 
        //:XB, 
        //:NL, 
        //:XL, 
        //:JKZK, 
        //:ZC, 
        //:JCZ, 
        //:SGZ, 
        //:NDSJTS, 
        //:HSE, 
        //:XMB,
        //:RYZT,
        //:TJR,
        //:TJSJ,
        //:BZ,
        //:YGXZ,
        //:GWXS)";
        //    OracleParameter[] parameter = {
        //                                            new OracleParameter(":RYBH",OracleDbType.Varchar2,16),
        //                                            new OracleParameter(":GW",OracleDbType.Varchar2,50),
        //                                            new OracleParameter(":XM",OracleDbType.Varchar2,26),
        //                                            new OracleParameter(":LXDH",OracleDbType.Varchar2,18),
        //                                            new OracleParameter(":XB",OracleDbType.Varchar2,2),
        //                                            new OracleParameter(":NL",OracleDbType.Varchar2,3),
        //                                            new OracleParameter(":XL",OracleDbType.Varchar2,10),
        //                                            new OracleParameter(":JKZK",OracleDbType.Varchar2,4),
        //                                            new OracleParameter(":ZC",OracleDbType.Varchar2,10),
        //                                            new OracleParameter(":JCZ",OracleDbType.Varchar2,50),
        //                                            new OracleParameter(":SGZ",OracleDbType.Varchar2,50),
        //                                            new OracleParameter(":NDSJTS",OracleDbType.Varchar2,50),
        //                                            new OracleParameter(":HSE",OracleDbType.Varchar2,50),
        //                                            new OracleParameter(":XMB",OracleDbType.Varchar2,10),
        //                                            new OracleParameter(":RYZT",OracleDbType.Varchar2,4),
        //                                            new OracleParameter(":TJR",OracleDbType.Varchar2,20),
        //                                            new OracleParameter(":TJSJ",OracleDbType.Date),
        //                                            new OracleParameter(":BZ",OracleDbType.Varchar2,200),
        //                                            new OracleParameter(":YGXZ",OracleDbType.Varchar2,50),
        //                                            new OracleParameter(":GWXS",OracleDbType.Varchar2,50),


        //                                        };

        //    parameter[0].Value = WJKP.RYBH;
        //    parameter[1].Value = WJKP.GW;
        //    parameter[2].Value = WJKP.XM;
        //    parameter[3].Value = WJKP.LXDH;
        //    parameter[4].Value = WJKP.XB;
        //    parameter[5].Value = WJKP.NL;
        //    parameter[6].Value = WJKP.XL;
        //    parameter[7].Value = WJKP.JKZK;
        //    parameter[8].Value = WJKP.ZC;
        //    parameter[9].Value = WJKP.JCZ;
        //    parameter[10].Value = WJKP.SGZ;
        //    parameter[11].Value = WJKP.NDSJTS;
        //    parameter[12].Value = WJKP.HSE;
        //    parameter[13].Value = WJKP.XMB;
        //    parameter[14].Value = WJKP.RYZT;
        //    parameter[15].Value = WJKP.TJR;
        //    parameter[16].Value = DateTime.Now;
        //    parameter[17].Value = WJKP.BZ;
        //    parameter[18].Value = WJKP.YGXZ;
        //    parameter[19].Value = WJKP.GWXS;
        //    int rows = DbHelperOra.ExecuteSql(sqlStr, parameter);
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        }
        /// <summary>
        /// 完井统计信息修改
        /// </summary>
        /// <param name="WJKP"></param>
        /// <returns></returns>
        /// :GW,:XM,:LXDH, :XB, :NL, :XL, :JKZK, :ZC, :JCZ, :SGZ, :NDSJTS, :HSE, :XMB,:RYZT:BZ,:YGXZ,:GWXS
        public bool Update(LQ_WJKP WJKP)
        {
        ArrayList list = new ArrayList();
        string sqlStr = string.Format(@"Update KLLOGT.AJSJ01 AJSJ01 Set AJSJ01.JB='{1}',AJSJ01.JX='{2}',AJSJ01.SJZZBX='{3}',AJSJ01.SJHZBY='{4}',AJSJ01.SS='{5}',AJSJ01.ZTMD='{6}',AJSJ01.GZWZ='{7}',AJSJ01.DLWZ='{8}',AJSJ01.CXWZ='{9}',AJSJ01.DMHB='{10}',AJSJ01.SJJS='{11}',AJSJ01.SJMDC='{12}' WHERE AJSJ01.JH= '{0}' ", 
            WJKP.AJSJ01_JH, WJKP.AJSJ01_JB, WJKP.AJSJ01_JX, WJKP.AJSJ01_SJZZBX, WJKP.AJSJ01_SJHZBY, WJKP.AJSJ01_SS, WJKP.AJSJ01_ZTMD, WJKP.AJSJ01_GZWZ, WJKP.AJSJ01_DLWZ, WJKP.AJSJ01_CXWZ, WJKP.AJSJ01_DMHB, WJKP.AJSJ01_SJJS, WJKP.AJSJ01_SJMDC);
        list.Add(sqlStr);
        return DbHelperOra.ExecuteSqlTrans(list);
        }
        /// <summary>
        /// 人员管理删除
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        //public bool Del(string ID)
        //{
        //    try
        //    {
        //        string sqlStr = @" delete from  LQ_WJKP  WHERE ID=:ID";
        //        OracleParameter[] parameter = {
        //                                    new OracleParameter(":ID",OracleDbType.Varchar2,32),
        //                                  };
        //        parameter[0].Value = ID;
        //        int rows = DbHelperOra.ExecuteSql(sqlStr, parameter);
        //        if (rows > 0)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}


        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet WJKPInfo(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"
 SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY TJSJ DESC) AS TROW,JCZ,SGZ,HSE,ID,GW,RYBH,XM,LXDH,XB,NL,XL,JKZK,ZC,NDSJTS,XMB,RYZT,TJR,TJSJ,BZ,YGXZ,SJJH,KSSJRQ,JSSJRQ,GWXS,NDJZ FROM LQ_WJKP T)");
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
            strSql.Append("select COUNT(*) from LQ_WJKP ");

            object result = DbHelperOra.GetSingle(strSql.ToString());
            if (result == null)
            {
                return 0;
            }
            return Convert.ToInt32(result);
        }



        public int CheckRY(string JH)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(*) from KLLOGT.AJSJ01 WHERE  JH='" + JH + "'");

            object result = DbHelperOra.GetSingle(strSql.ToString());
            if (result == null)
            {
                return 0;
            }
            return Convert.ToInt32(result);

        }


        /// <summary>
        ///完井统计信息查询分页
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="filedOrder"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public DataSet WJKP_strWhere(string strWhere, int pageSize, int pageIndex, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"SELECT WJKP.* FROM (
SELECT AJSJ01.JH AJSJ01_JH, AJSJ01.JB AJSJ01_JB, AJSJ01.JX AJSJ01_JX, AJSJ01.SJZZBX AJSJ01_SJZZBX, AJSJ01.SJHZBY AJSJ01_SJHZBY, AJSJ01.SS AJSJ01_SS, AJSJ01.ZTMD AJSJ01_ZTMD, AJSJ01.GZWZ AJSJ01_GZWZ, AJSJ01.DLWZ AJSJ01_DLWZ, AJSJ01.CXWZ AJSJ01_CXWZ, AJSJ01.DMHB AJSJ01_DMHB, AJSJ01.SJJS AJSJ01_SJJS, AJSJ01.SJMDC AJSJ01_SJMDC,
ADLJ01.BXHB ADLJ01_BXHB, ADLJ01.SGDW ADLJ01_SGDW, ADLJ01.SGDH ADLJ01_SGDH, ADLJ01.KZRQ ADLJ01_KZRQ, ADLJ01.WZRQ ADLJ01_WZRQ, ADLJ01.WJRQ ADLJ01_WJRQ, ADLJ01.WZJS ADLJ01_WZJS, ADLJ01.WZCS ADLJ01_WZCS, ADLJ01.WZCW ADLJ01_WZCW, ADLJ01.WJFF ADLJ01_WJFF,
ADLJ35.CDSD ADLJ35_CDSD, ADLJ35.ZDJXJ ADLJ35_ZDJXJ, ADLJ35.FWJ ADLJ35_FWJ, ADLJ35.BHFWJ ADLJ35_BHFWJ, ADLJ35.BHJ ADLJ35_BHJ, 
ADLJ09.DJSD1 ADLJ09_DJSD1, ADLJ09.DJSD2 ADLJ09_DJSD2, ADLJ09.ZJYMD1 ADLJ09_ZJYMD1, ADLJ09.ZJYMD2 ADLJ09_ZJYMD2, ADLJ09.ZJYND1 ADLJ09_ZJYND1, ADLJ09.ZJYND2 ADLJ09_ZJYND2, 
NULL ADLJ25_CW, NULL ADLJ25_SJFC, NULL ADLJ25_SZFC, NULL ADLJ25_DCFC, 
NULL ADLJ34_ZTZJ, NULL ADLJ34_ZDJS2,  
NULL ADLJ36_TGMC, NULL ADLJ36_TGWJ, NULL ADLJ36_XRJS, NULL ADLJ36_SNFS, NULL ADLJ36_GJZL,  
NULL ADLJ04_TC, NULL ADLJ04_DJSD1, NULL ADLJ04_DJSD2, NULL ADLJ04_CW1, NULL ADLJ04_DJSD2_DJSD1, NULL ADLJ04_YXCD, NULL ADLJ04_YXCD_DJSD2_DJSD1, NULL ADLJ04_BZ,  
NULL ADLJ75_JSCH, NULL ADLJ75_CW, NULL ADLJ75_DJSD1, NULL ADLJ75_DJSD2, NULL ADLJ75_DJSD2_DJSD1, NULL ADLJ75_HYJB, NULL ADLJ75_YSMC  
FROM((KLLOGT.AJSJ01 AJSJ01 INNER JOIN KLLOGT.ADLJ01 ADLJ01 ON AJSJ01.JH = ADLJ01.JH) INNER JOIN KLLOGT.ADLJ35 ADLJ35 ON AJSJ01.JH = ADLJ35.JH)  
INNER JOIN KLLOGT.ADLJ09 ADLJ09 ON AJSJ01.JH = ADLJ09.JH  
UNION 
SELECT AJSJ01.JH AJSJ01_JH, AJSJ01.JB AJSJ01_JB, AJSJ01.JX AJSJ01_JX, AJSJ01.SJZZBX AJSJ01_SJZZBX, AJSJ01.SJHZBY AJSJ01_SJHZBY, AJSJ01.SS AJSJ01_SS, AJSJ01.ZTMD AJSJ01_ZTMD, AJSJ01.GZWZ AJSJ01_GZWZ, AJSJ01.DLWZ AJSJ01_DLWZ, AJSJ01.CXWZ AJSJ01_CXWZ, AJSJ01.DMHB AJSJ01_DMHB, AJSJ01.SJJS AJSJ01_SJJS, AJSJ01.SJMDC AJSJ01_SJMDC,
ADLJ01.BXHB ADLJ01_BXHB, ADLJ01.SGDW ADLJ01_SGDW, ADLJ01.SGDH ADLJ01_SGDH, ADLJ01.KZRQ ADLJ01_KZRQ, ADLJ01.WZRQ ADLJ01_WZRQ, ADLJ01.WJRQ ADLJ01_WJRQ, ADLJ01.WZJS ADLJ01_WZJS, ADLJ01.WZCS ADLJ01_WZCS, ADLJ01.WZCW ADLJ01_WZCW, ADLJ01.WJFF ADLJ01_WJFF,
ADLJ35.CDSD ADLJ35_CDSD, ADLJ35.ZDJXJ ADLJ35_ZDJXJ, ADLJ35.FWJ ADLJ35_FWJ, ADLJ35.BHFWJ ADLJ35_BHFWJ, ADLJ35.BHJ ADLJ35_BHJ, 
NULL ADLJ09_DJSD1, NULL ADLJ09_DJSD2, NULL ADLJ09_ZJYMD1, NULL ADLJ09_ZJYMD2, NULL ADLJ09_ZJYND1, NULL ADLJ09_ZJYND2, 
ADLJ25.CW ADLJ25_CW, ADLJ25.SJFC ADLJ25_SJFC, ADLJ25.SZFC ADLJ25_SZFC, ADLJ25.DCFC ADLJ25_DCFC, 
NULL ADLJ34_ZTZJ, NULL ADLJ34_ZDJS2, 
NULL ADLJ36_TGMC, NULL ADLJ36_TGWJ, NULL ADLJ36_XRJS, NULL ADLJ36_SNFS, NULL ADLJ36_GJZL, 
NULL ADLJ04_TC, NULL ADLJ04_DJSD1, NULL ADLJ04_DJSD2, NULL ADLJ04_CW1, NULL ADLJ04_DJSD2_DJSD1, NULL ADLJ04_YXCD, NULL ADLJ04_YXCD_DJSD2_DJSD1, NULL ADLJ04_BZ, 
NULL ADLJ75_JSCH, NULL ADLJ75_CW, NULL ADLJ75_DJSD1, NULL ADLJ75_DJSD2, NULL ADLJ75_DJSD2_DJSD1, NULL ADLJ75_HYJB, NULL ADLJ75_YSMC 
FROM((KLLOGT.AJSJ01 AJSJ01 INNER JOIN KLLOGT.ADLJ01 ADLJ01 ON AJSJ01.JH = ADLJ01.JH) INNER JOIN KLLOGT.ADLJ35 ADLJ35 ON AJSJ01.JH = ADLJ35.JH)  
INNER JOIN KLLOGT.ADLJ25 ADLJ25 ON AJSJ01.JH = ADLJ25.JH 
UNION 
SELECT AJSJ01.JH AJSJ01_JH, AJSJ01.JB AJSJ01_JB, AJSJ01.JX AJSJ01_JX, AJSJ01.SJZZBX AJSJ01_SJZZBX, AJSJ01.SJHZBY AJSJ01_SJHZBY, AJSJ01.SS AJSJ01_SS, AJSJ01.ZTMD AJSJ01_ZTMD, AJSJ01.GZWZ AJSJ01_GZWZ, AJSJ01.DLWZ AJSJ01_DLWZ, AJSJ01.CXWZ AJSJ01_CXWZ, AJSJ01.DMHB AJSJ01_DMHB, AJSJ01.SJJS AJSJ01_SJJS, AJSJ01.SJMDC AJSJ01_SJMDC,
ADLJ01.BXHB ADLJ01_BXHB, ADLJ01.SGDW ADLJ01_SGDW, ADLJ01.SGDH ADLJ01_SGDH, ADLJ01.KZRQ ADLJ01_KZRQ, ADLJ01.WZRQ ADLJ01_WZRQ, ADLJ01.WJRQ ADLJ01_WJRQ, ADLJ01.WZJS ADLJ01_WZJS, ADLJ01.WZCS ADLJ01_WZCS, ADLJ01.WZCW ADLJ01_WZCW, ADLJ01.WJFF ADLJ01_WJFF,
ADLJ35.CDSD ADLJ35_CDSD, ADLJ35.ZDJXJ ADLJ35_ZDJXJ, ADLJ35.FWJ ADLJ35_FWJ, ADLJ35.BHFWJ ADLJ35_BHFWJ, ADLJ35.BHJ ADLJ35_BHJ, 
NULL ADLJ09_DJSD1, NULL ADLJ09_DJSD2, NULL ADLJ09_ZJYMD1, NULL ADLJ09_ZJYMD2, NULL ADLJ09_ZJYND1, NULL ADLJ09_ZJYND2, 
NULL ADLJ25_CW, NULL ADLJ25_SJFC, NULL ADLJ25_SZFC, NULL ADLJ25_DCFC,
ADLJ34.ZTZJ ADLJ34_ZTZJ, ADLJ34.ZDJS2 ADLJ34_ZDJS2, 
NULL ADLJ36_TGMC, NULL ADLJ36_TGWJ, NULL ADLJ36_XRJS, NULL ADLJ36_SNFS, NULL ADLJ36_GJZL,
NULL ADLJ04_TC, NULL ADLJ04_DJSD1, NULL ADLJ04_DJSD2, NULL ADLJ04_CW1, NULL ADLJ04_DJSD2_DJSD1, NULL ADLJ04_YXCD, NULL ADLJ04_YXCD_DJSD2_DJSD1, NULL ADLJ04_BZ,
NULL ADLJ75_JSCH, NULL ADLJ75_CW, NULL ADLJ75_DJSD1, NULL ADLJ75_DJSD2, NULL ADLJ75_DJSD2_DJSD1, NULL ADLJ75_HYJB, NULL ADLJ75_YSMC
FROM((KLLOGT.AJSJ01 AJSJ01 INNER JOIN KLLOGT.ADLJ01 ADLJ01 ON AJSJ01.JH = ADLJ01.JH) INNER JOIN KLLOGT.ADLJ35 ADLJ35 ON AJSJ01.JH = ADLJ35.JH)  
INNER JOIN KLLOGT.ADLJ34 ADLJ34 ON AJSJ01.JH = ADLJ34.JH
UNION
SELECT AJSJ01.JH AJSJ01_JH, AJSJ01.JB AJSJ01_JB, AJSJ01.JX AJSJ01_JX, AJSJ01.SJZZBX AJSJ01_SJZZBX, AJSJ01.SJHZBY AJSJ01_SJHZBY, AJSJ01.SS AJSJ01_SS, AJSJ01.ZTMD AJSJ01_ZTMD, AJSJ01.GZWZ AJSJ01_GZWZ, AJSJ01.DLWZ AJSJ01_DLWZ, AJSJ01.CXWZ AJSJ01_CXWZ, AJSJ01.DMHB AJSJ01_DMHB, AJSJ01.SJJS AJSJ01_SJJS, AJSJ01.SJMDC AJSJ01_SJMDC,
ADLJ01.BXHB ADLJ01_BXHB, ADLJ01.SGDW ADLJ01_SGDW, ADLJ01.SGDH ADLJ01_SGDH, ADLJ01.KZRQ ADLJ01_KZRQ, ADLJ01.WZRQ ADLJ01_WZRQ, ADLJ01.WJRQ ADLJ01_WJRQ, ADLJ01.WZJS ADLJ01_WZJS, ADLJ01.WZCS ADLJ01_WZCS, ADLJ01.WZCW ADLJ01_WZCW, ADLJ01.WJFF ADLJ01_WJFF,
ADLJ35.CDSD ADLJ35_CDSD, ADLJ35.ZDJXJ ADLJ35_ZDJXJ, ADLJ35.FWJ ADLJ35_FWJ, ADLJ35.BHFWJ ADLJ35_BHFWJ, ADLJ35.BHJ ADLJ35_BHJ, 
NULL ADLJ09_DJSD1, NULL ADLJ09_DJSD2, NULL ADLJ09_ZJYMD1, NULL ADLJ09_ZJYMD2, NULL ADLJ09_ZJYND1, NULL ADLJ09_ZJYND2, 
NULL ADLJ25_CW, NULL ADLJ25_SJFC, NULL ADLJ25_SZFC, NULL ADLJ25_DCFC,
NULL ADLJ34_ZTZJ, NULL ADLJ34_ZDJS2, 
ADLJ36.TGMC ADLJ36_TGMC, ADLJ36.TGWJ ADLJ36_TGWJ, ADLJ36.XRJS ADLJ36_XRJS, ADLJ36.SNFS ADLJ36_SNFS, ADLJ36.GJZL ADLJ36_GJZL,
NULL ADLJ04_TC, NULL ADLJ04_DJSD1, NULL ADLJ04_DJSD2, NULL ADLJ04_CW1, NULL ADLJ04_DJSD2_DJSD1, NULL ADLJ04_YXCD, NULL ADLJ04_YXCD_DJSD2_DJSD1, NULL ADLJ04_BZ,
NULL ADLJ75_JSCH, NULL ADLJ75_CW, NULL ADLJ75_DJSD1, NULL ADLJ75_DJSD2, NULL ADLJ75_DJSD2_DJSD1, NULL ADLJ75_HYJB, NULL ADLJ75_YSMC
FROM((KLLOGT.AJSJ01 AJSJ01 INNER JOIN KLLOGT.ADLJ01 ADLJ01 ON AJSJ01.JH = ADLJ01.JH) INNER JOIN KLLOGT.ADLJ35 ADLJ35 ON AJSJ01.JH = ADLJ35.JH)
INNER JOIN KLLOGT.ADLJ36 ADLJ36 ON AJSJ01.JH = ADLJ36.JH
UNION
SELECT AJSJ01.JH AJSJ01_JH, AJSJ01.JB AJSJ01_JB, AJSJ01.JX AJSJ01_JX, AJSJ01.SJZZBX AJSJ01_SJZZBX, AJSJ01.SJHZBY AJSJ01_SJHZBY, AJSJ01.SS AJSJ01_SS, AJSJ01.ZTMD AJSJ01_ZTMD, AJSJ01.GZWZ AJSJ01_GZWZ, AJSJ01.DLWZ AJSJ01_DLWZ, AJSJ01.CXWZ AJSJ01_CXWZ, AJSJ01.DMHB AJSJ01_DMHB, AJSJ01.SJJS AJSJ01_SJJS, AJSJ01.SJMDC AJSJ01_SJMDC,
ADLJ01.BXHB ADLJ01_BXHB, ADLJ01.SGDW ADLJ01_SGDW, ADLJ01.SGDH ADLJ01_SGDH, ADLJ01.KZRQ ADLJ01_KZRQ, ADLJ01.WZRQ ADLJ01_WZRQ, ADLJ01.WJRQ ADLJ01_WJRQ, ADLJ01.WZJS ADLJ01_WZJS, ADLJ01.WZCS ADLJ01_WZCS, ADLJ01.WZCW ADLJ01_WZCW, ADLJ01.WJFF ADLJ01_WJFF,
ADLJ35.CDSD ADLJ35_CDSD, ADLJ35.ZDJXJ ADLJ35_ZDJXJ, ADLJ35.FWJ ADLJ35_FWJ, ADLJ35.BHFWJ ADLJ35_BHFWJ, ADLJ35.BHJ ADLJ35_BHJ, 
NULL ADLJ09_DJSD1, NULL ADLJ09_DJSD2, NULL ADLJ09_ZJYMD1, NULL ADLJ09_ZJYMD2, NULL ADLJ09_ZJYND1, NULL ADLJ09_ZJYND2, 
NULL ADLJ25_CW, NULL ADLJ25_SJFC, NULL ADLJ25_SZFC, NULL ADLJ25_DCFC,
NULL ADLJ34_ZTZJ, NULL ADLJ34_ZDJS2, 
NULL ADLJ36_TGMC, NULL ADLJ36_TGWJ, NULL ADLJ36_XRJS, NULL ADLJ36_SNFS, NULL ADLJ36_GJZL,
ADLJ04.TC ADLJ04_TC, ADLJ04.DJSD1 ADLJ04_DJSD1, ADLJ04.DJSD2 ADLJ04_DJSD2, ADLJ04.CW1 ADLJ04_CW1, ADLJ04.DJSD2-ADLJ04.DJSD1 ADLJ04_DJSD2_DJSD1, ADLJ04.YXCD ADLJ04_YXCD, (round((ADLJ04.YXCD/(ADLJ04.DJSD2-ADLJ04.DJSD1))*100,2))||'%' ADLJ04_YXCD_DJSD2_DJSD1, ADLJ04.BZ ADLJ04_BZ,
NULL ADLJ75_JSCH, NULL ADLJ75_CW, NULL ADLJ75_DJSD1, NULL ADLJ75_DJSD2, NULL ADLJ75_DJSD2_DJSD1, NULL ADLJ75_HYJB, NULL ADLJ75_YSMC
FROM((KLLOGT.AJSJ01 AJSJ01 INNER JOIN KLLOGT.ADLJ01 ADLJ01 ON AJSJ01.JH = ADLJ01.JH) INNER JOIN KLLOGT.ADLJ35 ADLJ35 ON AJSJ01.JH = ADLJ35.JH)
INNER JOIN KLLOGT.ADLJ04 ADLJ04 ON AJSJ01.JH = ADLJ04.JH
UNION
SELECT AJSJ01.JH AJSJ01_JH, AJSJ01.JB AJSJ01_JB, AJSJ01.JX AJSJ01_JX, AJSJ01.SJZZBX AJSJ01_SJZZBX, AJSJ01.SJHZBY AJSJ01_SJHZBY, AJSJ01.SS AJSJ01_SS, AJSJ01.ZTMD AJSJ01_ZTMD, AJSJ01.GZWZ AJSJ01_GZWZ, AJSJ01.DLWZ AJSJ01_DLWZ, AJSJ01.CXWZ AJSJ01_CXWZ, AJSJ01.DMHB AJSJ01_DMHB, AJSJ01.SJJS AJSJ01_SJJS, AJSJ01.SJMDC AJSJ01_SJMDC,
ADLJ01.BXHB ADLJ01_BXHB, ADLJ01.SGDW ADLJ01_SGDW, ADLJ01.SGDH ADLJ01_SGDH, ADLJ01.KZRQ ADLJ01_KZRQ, ADLJ01.WZRQ ADLJ01_WZRQ, ADLJ01.WJRQ ADLJ01_WJRQ, ADLJ01.WZJS ADLJ01_WZJS, ADLJ01.WZCS ADLJ01_WZCS, ADLJ01.WZCW ADLJ01_WZCW, ADLJ01.WJFF ADLJ01_WJFF,
ADLJ35.CDSD ADLJ35_CDSD, ADLJ35.ZDJXJ ADLJ35_ZDJXJ, ADLJ35.FWJ ADLJ35_FWJ, ADLJ35.BHFWJ ADLJ35_BHFWJ, ADLJ35.BHJ ADLJ35_BHJ, 
NULL ADLJ09_DJSD1, NULL ADLJ09_DJSD2, NULL ADLJ09_ZJYMD1, NULL ADLJ09_ZJYMD2, NULL ADLJ09_ZJYND1, NULL ADLJ09_ZJYND2, 
NULL ADLJ25_CW, NULL ADLJ25_SJFC, NULL ADLJ25_SZFC, NULL ADLJ25_DCFC,
NULL ADLJ34_ZTZJ, NULL ADLJ34_ZDJS2, 
NULL ADLJ36_TGMC, NULL ADLJ36_TGWJ, NULL ADLJ36_XRJS, NULL ADLJ36_SNFS, NULL ADLJ36_GJZL,
NULL ADLJ04_TC, NULL ADLJ04_DJSD1, NULL ADLJ04_DJSD2, NULL ADLJ04_CW1, NULL ADLJ04_DJSD2_DJSD1, NULL ADLJ04_YXCD, NULL ADLJ04_YXCD_DJSD2_DJSD1, NULL ADLJ04_BZ,
ADLJ75.JSCH ADLJ75_JSCH, ADLJ75.CW ADLJ75_CW, ADLJ75.DJSD1 ADLJ75_DJSD1, ADLJ75.DJSD2 ADLJ75_DJSD2, ADLJ75.DJSD2-ADLJ75.DJSD1 ADLJ75_DJSD2_DJSD1, ADLJ75.HYJB ADLJ75_HYJB, ADLJ75.YSMC ADLJ75_YSMC
FROM((KLLOGT.AJSJ01 AJSJ01 INNER JOIN KLLOGT.ADLJ01 ADLJ01 ON AJSJ01.JH = ADLJ01.JH) INNER JOIN KLLOGT.ADLJ35 ADLJ35 ON AJSJ01.JH = ADLJ35.JH)
INNER JOIN KLLOGT.ADLJ75 ADLJ75 ON AJSJ01.JH = ADLJ75.JH
WHERE ADLJ75.XH = 1 
) WJKP");   // grant select on KLLOGT.ADLJ01 to LJZY

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
       LEFT JOIN LQ_WJKP D ON T.RYBH = D.RYBH
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
       LEFT JOIN LQ_WJKP D ON T.RYBH = D.RYBH
       LEFT JOIN " + dtName1 + " F ON T.JH = F.JH ) ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1 " + strWhere);
            }
             
            return DbHelperOra.Query(strSql.ToString());
        }

        public DataSet EXCEL_WJKP(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ROW_NUMBER() OVER(ORDER BY TJSJ DESC) AS TROW,XMB,GW,RYBH,XM,LXDH,XB,NL,XL,YGXZ,JKZK,ZC,GWXS,RYZT,NDSJTS,JCZ,HSE,SGZ,BZ,ID,TJR,TJSJ,SJJH,KSSJRQ,JSSJRQ from LQ_WJKP  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1 " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        // model values
        public LQ_WJKP WJKPModel(DataRow dr)
        {
            LQ_WJKP model = new LQ_WJKP();
            if (dr["AJSJ01_JH"] != null && dr["AJSJ01_JH"].ToString() != "")
            {
                model.AJSJ01_JH = dr["AJSJ01_JH"].ToString();
            }
            if (dr["AJSJ01_JB"] != null && dr["AJSJ01_JB"].ToString() != "")
            {
                model.AJSJ01_JB = dr["AJSJ01_JB"].ToString();
            }
            if (dr["AJSJ01_JX"] != null && dr["AJSJ01_JX"].ToString() != "")
            {
                model.AJSJ01_JX = dr["AJSJ01_JX"].ToString();
            }
            if (dr["AJSJ01_SJZZBX"] != null && dr["AJSJ01_SJZZBX"].ToString() != "")
            {
                model.AJSJ01_SJZZBX = dr["AJSJ01_SJZZBX"].ToString();
            }
            if (dr["AJSJ01_SJHZBY"] != null && dr["AJSJ01_SJHZBY"].ToString() != "")
            {
                model.AJSJ01_SJHZBY = dr["AJSJ01_SJHZBY"].ToString();
            }
            if (dr["AJSJ01_SS"] != null && dr["AJSJ01_SS"].ToString() != "")
            {
                model.AJSJ01_SS = dr["AJSJ01_SS"].ToString();
            }
            if (dr["AJSJ01_ZTMD"] != null && dr["AJSJ01_ZTMD"].ToString() != "")
            {
                model.AJSJ01_ZTMD = dr["AJSJ01_ZTMD"].ToString();
            }
            if (dr["AJSJ01_GZWZ"] != null && dr["AJSJ01_GZWZ"].ToString() != "")
            {
                model.AJSJ01_GZWZ = dr["AJSJ01_GZWZ"].ToString();
            }
            if (dr["AJSJ01_DLWZ"] != null && dr["AJSJ01_DLWZ"].ToString() != "")
            {
                model.AJSJ01_DLWZ = dr["AJSJ01_DLWZ"].ToString();
            }
            if (dr["AJSJ01_CXWZ"] != null && dr["AJSJ01_CXWZ"].ToString() != "")
            {
                model.AJSJ01_CXWZ = dr["AJSJ01_CXWZ"].ToString();
            }
            if (dr["AJSJ01_DMHB"] != null && dr["AJSJ01_DMHB"].ToString() != "")
            {
                model.AJSJ01_DMHB = dr["AJSJ01_DMHB"].ToString();
            }
            if (dr["AJSJ01_SJJS"] != null && dr["AJSJ01_SJJS"].ToString() != "")
            {
                model.AJSJ01_SJJS = dr["AJSJ01_SJJS"].ToString();
            }
            if (dr["AJSJ01_SJMDC"] != null && dr["AJSJ01_SJMDC"].ToString() != "")
            {
                model.AJSJ01_SJMDC = dr["AJSJ01_SJMDC"].ToString();
            }

            if (dr["ADLJ01_BXHB"] != null && dr["ADLJ01_BXHB"].ToString() != "")
            {
                model.ADLJ01_BXHB = dr["ADLJ01_BXHB"].ToString();
            }
            if (dr["ADLJ01_SGDW"] != null && dr["ADLJ01_SGDW"].ToString() != "")
            {
                model.ADLJ01_SGDW = dr["ADLJ01_SGDW"].ToString();
            }
            if (dr["ADLJ01_SGDH"] != null && dr["ADLJ01_SGDH"].ToString() != "")
            {
                model.ADLJ01_SGDH = dr["ADLJ01_SGDH"].ToString();
            }
            if (dr["ADLJ01_KZRQ"] != null && dr["ADLJ01_KZRQ"].ToString() != "")
            {
                model.ADLJ01_KZRQ = dr["ADLJ01_KZRQ"].ToString();
            }
            if (dr["ADLJ01_WZRQ"] != null && dr["ADLJ01_WZRQ"].ToString() != "")
            {
                model.ADLJ01_WZRQ = dr["ADLJ01_WZRQ"].ToString();
            }
            if (dr["ADLJ01_WJRQ"] != null && dr["ADLJ01_WJRQ"].ToString() != "")
            {
                model.ADLJ01_WJRQ = dr["ADLJ01_WJRQ"].ToString();
            }
            if (dr["ADLJ01_WZJS"] != null && dr["ADLJ01_WZJS"].ToString() != "")
            {
                model.ADLJ01_WZJS = dr["ADLJ01_WZJS"].ToString();
            }
            if (dr["ADLJ01_WZCS"] != null && dr["ADLJ01_WZCS"].ToString() != "")
            {
                model.ADLJ01_WZCS = dr["ADLJ01_WZCS"].ToString();
            }
            if (dr["ADLJ01_WZCW"] != null && dr["ADLJ01_WZCW"].ToString() != "")
            {
                model.ADLJ01_WZCW = dr["ADLJ01_WZCW"].ToString();
            }
            if (dr["ADLJ01_WJFF"] != null && dr["ADLJ01_WJFF"].ToString() != "")
            {
                model.ADLJ01_WJFF = dr["ADLJ01_WJFF"].ToString();
            }

            if (dr["ADLJ35_CDSD"] != null && dr["ADLJ35_CDSD"].ToString() != "")
            {
                model.ADLJ35_CDSD = dr["ADLJ35_CDSD"].ToString();
            }
            if (dr["ADLJ35_ZDJXJ"] != null && dr["ADLJ35_ZDJXJ"].ToString() != "")
            {
                model.ADLJ35_ZDJXJ = dr["ADLJ35_ZDJXJ"].ToString();
            }
            if (dr["ADLJ35_FWJ"] != null && dr["ADLJ35_FWJ"].ToString() != "")
            {
                model.ADLJ35_FWJ = dr["ADLJ35_FWJ"].ToString();
            }
            if (dr["ADLJ35_BHFWJ"] != null && dr["ADLJ35_BHFWJ"].ToString() != "")
            {
                model.ADLJ35_BHFWJ = dr["ADLJ35_BHFWJ"].ToString();
            }
            if (dr["ADLJ35_BHJ"] != null && dr["ADLJ35_BHJ"].ToString() != "")
            {
                model.ADLJ35_BHJ = dr["ADLJ35_BHJ"].ToString();
            }

            if (dr["ADLJ09_DJSD1"] != null && dr["ADLJ09_DJSD1"].ToString() != "")
            {
                model.ADLJ09_DJSD1 = dr["ADLJ09_DJSD1"].ToString();
            }
            if (dr["ADLJ09_DJSD2"] != null && dr["ADLJ09_DJSD2"].ToString() != "")
            {
                model.ADLJ09_DJSD2 = dr["ADLJ09_DJSD2"].ToString();
            }
            if (dr["ADLJ09_ZJYMD1"] != null && dr["ADLJ09_ZJYMD1"].ToString() != "")
            {
                model.ADLJ09_ZJYMD1 = dr["ADLJ09_ZJYMD1"].ToString();
            }
            if (dr["ADLJ09_ZJYMD2"] != null && dr["ADLJ09_ZJYMD2"].ToString() != "")
            {
                model.ADLJ09_ZJYMD2 = dr["ADLJ09_ZJYMD2"].ToString();
            }
            if (dr["ADLJ09_ZJYND1"] != null && dr["ADLJ09_ZJYND1"].ToString() != "")
            {
                model.ADLJ09_ZJYND1 = dr["ADLJ09_ZJYND1"].ToString();
            }
            if (dr["ADLJ09_ZJYND2"] != null && dr["ADLJ09_ZJYND2"].ToString() != "")
            {
                model.ADLJ09_ZJYND2 = dr["ADLJ09_ZJYND2"].ToString();
            }

            if (dr["ADLJ25_CW"] != null && dr["ADLJ25_CW"].ToString() != "")
            {
                model.ADLJ25_CW = dr["ADLJ25_CW"].ToString();
            }
            if (dr["ADLJ25_SJFC"] != null && dr["ADLJ25_SJFC"].ToString() != "")
            {
                model.ADLJ25_SJFC = dr["ADLJ25_SJFC"].ToString();
            }
            if (dr["ADLJ25_SZFC"] != null && dr["ADLJ25_SZFC"].ToString() != "")
            {
                model.ADLJ25_SZFC = dr["ADLJ25_SZFC"].ToString();
            }
            if (dr["ADLJ25_DCFC"] != null && dr["ADLJ25_DCFC"].ToString() != "")
            {
                model.ADLJ25_DCFC = dr["ADLJ25_DCFC"].ToString();
            }

            if (dr["ADLJ34_ZTZJ"] != null && dr["ADLJ34_ZTZJ"].ToString() != "")
            {
                model.ADLJ34_ZTZJ = dr["ADLJ34_ZTZJ"].ToString();
            }
            if (dr["ADLJ34_ZDJS2"] != null && dr["ADLJ34_ZDJS2"].ToString() != "")
            {
                model.ADLJ34_ZDJS2 = dr["ADLJ34_ZDJS2"].ToString();
            }

            if (dr["ADLJ36_TGMC"] != null && dr["ADLJ36_TGMC"].ToString() != "")
            {
                model.ADLJ36_TGMC = dr["ADLJ36_TGMC"].ToString();
            }
            if (dr["ADLJ36_TGWJ"] != null && dr["ADLJ36_TGWJ"].ToString() != "")
            {
                model.ADLJ36_TGWJ = dr["ADLJ36_TGWJ"].ToString();
            }
            if (dr["ADLJ36_XRJS"] != null && dr["ADLJ36_XRJS"].ToString() != "")
            {
                model.ADLJ36_XRJS = dr["ADLJ36_XRJS"].ToString();
            }
            if (dr["ADLJ36_SNFS"] != null && dr["ADLJ36_SNFS"].ToString() != "")
            {
                model.ADLJ36_SNFS = dr["ADLJ36_SNFS"].ToString();
            }
            if (dr["ADLJ36_GJZL"] != null && dr["ADLJ36_GJZL"].ToString() != "")
            {
                model.ADLJ36_GJZL = dr["ADLJ36_GJZL"].ToString();
            }

            if (dr["ADLJ04_TC"] != null && dr["ADLJ04_TC"].ToString() != "")
            {
                model.ADLJ04_TC = dr["ADLJ04_TC"].ToString();
            }
            if (dr["ADLJ04_DJSD1"] != null && dr["ADLJ04_DJSD1"].ToString() != "")
            {
                model.ADLJ04_DJSD1 = dr["ADLJ04_DJSD1"].ToString();
            }
            if (dr["ADLJ04_DJSD2"] != null && dr["ADLJ04_DJSD2"].ToString() != "")
            {
                model.ADLJ04_DJSD2 = dr["ADLJ04_DJSD2"].ToString();
            }
            if (dr["ADLJ04_CW1"] != null && dr["ADLJ04_CW1"].ToString() != "")
            {
                model.ADLJ04_CW1 = dr["ADLJ04_CW1"].ToString();
            }
            if (dr["ADLJ04_DJSD2_DJSD1"] != null && dr["ADLJ04_DJSD2_DJSD1"].ToString() != "")
            {
                model.ADLJ04_DJSD2_DJSD1 = dr["ADLJ04_DJSD2_DJSD1"].ToString();
            }
            if (dr["ADLJ04_YXCD"] != null && dr["ADLJ04_YXCD"].ToString() != "")
            {
                model.ADLJ04_YXCD = dr["ADLJ04_YXCD"].ToString();
            }
            if (dr["ADLJ04_YXCD_DJSD2_DJSD1"] != null && dr["ADLJ04_YXCD_DJSD2_DJSD1"].ToString() != "")
            {
                model.ADLJ04_YXCD_DJSD2_DJSD1 = dr["ADLJ04_YXCD_DJSD2_DJSD1"].ToString();
            }
            if (dr["ADLJ04_BZ"] != null && dr["ADLJ04_BZ"].ToString() != "")
            {
                model.ADLJ04_BZ = dr["ADLJ04_BZ"].ToString();
            }

            if (dr["ADLJ75_JSCH"] != null && dr["ADLJ75_JSCH"].ToString() != "")
            {
                model.ADLJ75_JSCH = dr["ADLJ75_JSCH"].ToString();
            }
            if (dr["ADLJ75_CW"] != null && dr["ADLJ75_CW"].ToString() != "")
            {
                model.ADLJ75_CW = dr["ADLJ75_CW"].ToString();
            }
            if (dr["ADLJ75_DJSD1"] != null && dr["ADLJ75_DJSD1"].ToString() != "")
            {
                model.ADLJ75_DJSD1 = dr["ADLJ75_DJSD1"].ToString();
            }
            if (dr["ADLJ75_DJSD2"] != null && dr["ADLJ75_DJSD2"].ToString() != "")
            {
                model.ADLJ75_DJSD2 = dr["ADLJ75_DJSD2"].ToString();
            }
            if (dr["ADLJ75_DJSD2_DJSD1"] != null && dr["ADLJ75_DJSD2_DJSD1"].ToString() != "")
            {
                model.ADLJ75_DJSD2_DJSD1 = dr["ADLJ75_DJSD2_DJSD1"].ToString();
            }
            if (dr["ADLJ75_HYJB"] != null && dr["ADLJ75_HYJB"].ToString() != "")
            {
                model.ADLJ75_HYJB = dr["ADLJ75_HYJB"].ToString();
            }
            if (dr["ADLJ75_YSMC"] != null && dr["ADLJ75_YSMC"].ToString() != "")
            {
                model.ADLJ75_YSMC = dr["ADLJ75_YSMC"].ToString();
            }

            //if (dr["TROW"] != null && dr["TROW"].ToString() != "")
            //{
            //    model.TROW = Convert.ToInt32(dr["TROW"]);
            //}

            //if (dr["KSSJRQ"] != null && dr["KSSJRQ"].ToString() != "")
            //{
            //    model.KSSJRQ = Convert.ToDateTime(dr["KSSJRQ"]);
            //    model.KSSJRQ_DG = Convert.ToDateTime(dr["KSSJRQ"]).ToString("yyyy-MM-dd");
            //}
            //else
            //{
            //    model.KSSJRQ_DG = "";
            //}

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

        //public bool ADDNDJZ(LQ_WJKP lQ_WJKP, string ID)
        //{
        //    string sqlStr = string.Format(@"UPDATE LQ_WJKP SET  NDJZ='{0}' WHERE ID='{1}'", lQ_WJKP.NDJZ, ID);
        //    int rows = DbHelperOra.ExecuteSql(sqlStr);
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
