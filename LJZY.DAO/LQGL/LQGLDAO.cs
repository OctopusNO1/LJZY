using LJZY.COMMON;
using LJZY.DBUtility;
using LJZY.MODEL;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls.Map;

namespace LJZY.DAO.LQGL
{
    public class LQGLDAO
    {


        /// <summary>
        /// 根据条件获取单井设计信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet DJSJInfo_TROW(string strWhere, string dtName)
        {
            string strSql = @"
SELECT ROW_NUMBER () OVER (ORDER BY JH DESC,REPORT_TYPE,SJRQ DESC) AS TROW,Dt.*
  FROM (SELECT T.JH,
               T.ZJH,
               T.SC3,
               T.SC2,
               T.QK,
               T.REPORT_TYPE,
               T.JX,
               T.SJJS,
               T.JSSJJS,
               T.WZJS,
               T.DLWZ,
               T.GZWZ,
               T.CXWZ,
               T.SJZZBB,
               T.SJHZBB,
               T.SJZZBX,
               T.SJHZBX,
               T.SJZZB,
               T.SJHZB,
               T.DMHB,
               T.BXG,
               T.ZYMDC,
               T.SJR,
               T.SPR,
               T.SJRQ,
               T.SPRQ,
               T.BZ,
               T.LJFGS,
               T.ISLATESTRECORD,
               T.ISFINISH,
               TO_CHAR(T.KZRQ,'yyyy') ND,
               T.ID
          FROM " + dtName + " T) Dt ";
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql += "WHERE 1=1" + strWhere;
            }

            return DbHelperOra.Query(strSql);
        }

        public DataSet DJSJInfo(string strWhere, string dtName)
        {
            string strSql = @"
SELECT  Dt.*
  FROM (SELECT ROW_NUMBER () OVER (ORDER BY T.JH DESC,T.REPORT_TYPE,T.SJRQ DESC) AS TROW,
               T.JH,
               T.ZJH,
               T.SC3,
               T.SC2,
               T.QK,
               T.REPORT_TYPE,
               T.JX,
               T.SJJS,
               T.JSSJJS,
               T.WZJS,
               T.DLWZ,
               T.GZWZ,
               T.CXWZ,
               T.SJZZBB,
               T.SJHZBB,
               T.SJZZBX,
               T.SJHZBX,
               T.SJZZB,
               T.SJHZB,
               T.DMHB,
               T.BXG,
               T.ZYMDC,
               T.SJR,
               T.SPR,
               T.SJRQ,
               T.SPRQ,
               T.BZ,
               T.LJFGS,              
               NVL(T.ISLATESTRECORD,0) ISLATESTRECORD,
               NVL(T.ISFINISH,0) ISFINISH,
               TO_CHAR(T.KZRQ,'yyyy') ND,
               T.ID
          FROM " + dtName + " T ) Dt ";
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql += "WHERE 1=1" + strWhere;
            }

            return DbHelperOra.Query(strSql);
        }

        public DataSet DJSJInfo(string REPORT_TYPE, string strWhere, string dtName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"
SELECT  Dt.*
  FROM (SELECT ROW_NUMBER () OVER (ORDER BY T.JH DESC,T.REPORT_TYPE,T.SJRQ DESC) AS TROW,
               T.JH,
               T.ZJH,
               T.SC3,
               T.SC2,
               T.QK,
               T.REPORT_TYPE,
               T.JX,
               T.SJJS,
               T.JSSJJS,
               T.WZJS,
               T.DLWZ,
               T.GZWZ,
               T.CXWZ,
               T.SJZZBB,
               T.SJHZBB,
               T.SJZZBX,
               T.SJHZBX,
               T.SJZZB,
               T.SJHZB,
               T.DMHB,
               T.BXG,
               T.ZYMDC,
               T.SJR,
               T.SPR,
               T.SJRQ,
               T.SPRQ,
               T.BZ,
               T.LJFGS,
               T.ISLATESTRECORD,
               T.ISFINISH,
               TO_CHAR(T.KZRQ,'yyyy') ND,
               T.ID
          FROM " + dtName + " T  WHERE 1=1 {0} ) Dt ", REPORT_TYPE);
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append("WHERE 1=1" + strWhere);
            }

            return DbHelperOra.Query(strSql.ToString());
        }

        public DataSet JHList(string strWhere, string dtName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"
SELECT  Dt.*
  FROM (SELECT ROW_NUMBER () OVER (ORDER BY T.JH DESC,T.REPORT_TYPE,T.SJRQ DESC) AS TROW,
               T.JH,
               T.ZJH,
               T.SC3,
               T.SC2,
               T.QK,
               T.REPORT_TYPE,
               T.JX,
               T.SJJS,
               T.JSSJJS,
               T.WZJS,
               T.DLWZ,
               T.GZWZ,
               T.CXWZ,
               T.SJZZBB,
               T.SJHZBB,
               T.SJZZBX,
               T.SJHZBX,
               T.SJZZB,
               T.SJHZB,
               T.DMHB,
               T.BXG,
               T.ZYMDC,
               T.SJR,
               T.SPR,
               T.SJRQ,
               T.SPRQ,
               T.BZ,
               T.LJFGS,
               T.ISLATESTRECORD,
               T.ISFINISH,
               TO_CHAR(T.KZRQ,'yyyy') ND,
               T.ID
          FROM " + dtName + @" T
          WHERE 1=1 {0} ) Dt 
            WHERE  TROW<10 ", strWhere);

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 通过条件查询单井设计信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet DJSJInfo_strWhere(string strWhere, int pageSize, int pageIndex, string filedOrder, out int recordCount, string dtName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ROW_NUMBER() OVER(ORDER BY T1.JH DESC,T1.REPORT_TYPE,T1.SJRQ DESC) AS TROW,T1.* from " + dtName + " T1 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1 " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperOra.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperOra.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
            //return DbHelperOra.Query(strSql.ToString());
        }



        /// <summary>
        /// 单井设计数据删除
        /// </summary>
        /// <param name="ZJH"></param>
        /// <returns></returns>
        public bool Del(string JH, string JX, string dtName1)
        {

            string sqlStr = @" delete from  " + dtName1 + "   WHERE JH=:JH ";
            OracleParameter[] parameter = {
                                            new OracleParameter(":JH",OracleDbType.Varchar2,10)
                                          };
            parameter[0].Value = JH;
            //parameter[1].Value = JX;
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
        /// 单井设计数据修改
        /// </summary>
        /// <param name="DJSJ"></param>
        /// <returns></returns>
        public bool Update(LQ_DJSJ DJSJ, string dtName)
        {
            string SJRQ_Str = "";
            string SPRQ_Str = "";
            if (DJSJ.SJRQ == null)
            {
                SJRQ_Str = "DEFAULT,";
            }
            else
            {
                SJRQ_Str = "TO_DATE ( '{21}', 'YYYY-MM-DD' ),";
            }
            if (DJSJ.SPRQ==null)
            {
                SPRQ_Str = "DEFAULT,";
            }
            else
            {
                SPRQ_Str = "TO_DATE ( '{22}', 'YYYY-MM-DD' ),";
            }
            string sqlStr = string.Format(@"
Update " + dtName + @"
Set SC3 = '{0}',
SC2 = '{1}',
QK = '{2}',
REPORT_TYPE = '{3}',
SJJS = {4}, 
JSSJJS = {5}, 
WZJS = {6}, 
DLWZ = '{7}', 
GZWZ = '{8}', 
CXWZ = '{9}', 
SJZZBB = {10}, 
SJHZBB = {11}, 
SJZZBX = {12}, 
SJHZBX = {13}, 
SJZZB = {14}, 
SJHZB = {15}, 
DMHB = {16}, 
BXG = {17}, 
ZYMDC = '{18}', 
SJR = '{19}', 
SPR = '{20}', 
SJRQ = "+ SJRQ_Str + @" 
SPRQ = "+ SPRQ_Str + @"
BZ = '{23}', 
LJFGS = '{24}',
JX = '{25}', 
ISLATESTRECORD = {26},
ISFINISH = {27}
WHERE JH = '{28}' "
,
DJSJ.SC3,
DJSJ.SC2,
DJSJ.QK,
DJSJ.REPORT_TYPE,
DJSJ.SJJS,
DJSJ.JSSJJS,
DJSJ.WZJS,
DJSJ.DLWZ,
DJSJ.GZWZ,
DJSJ.CXWZ,
DJSJ.SJZZBB,
DJSJ.SJHZBB,
DJSJ.SJZZBX,
DJSJ.SJHZBX,
DJSJ.SJZZB,
DJSJ.SJHZB,
DJSJ.DMHB,
DJSJ.BXG,
DJSJ.ZYMDC,
DJSJ.SJR,
DJSJ.SPR,
DJSJ.SJRQ,
DJSJ.SPRQ,
DJSJ.BZ,
DJSJ.LJFGS,
DJSJ.JX,
DJSJ.ISLATESTRECORD,
DJSJ.ISFINISH,
DJSJ.JH);

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

        /// <summary>
        /// 设计入库数据录入
        /// </summary>
        /// <param name="DJSJ"></param>
        /// <returns></returns>
        public bool Add(LQ_DJSJ DJSJ, string dtName)
        {
            string sqlStr = string.Format(@"insert into  " + dtName + @"(ZJH, SC3, SC2, QK, REPORT_TYPE, JX, JH, SJJS, JSSJJS, WZJS, DLWZ, GZWZ, CXWZ, SJZZBB, SJHZBB, SJZZBX, SJHZBX, SJZZB, SJHZB, DMHB, BXG, ZYMDC, SJR, SPR, SPRQ, SJRQ, BCRQ, BZ, LJFGS,REPORT_TYPE,ISLATESTRECORD,ISFINISH)
values(:ZJH, :SC3, :SC2, :QK, :REPORT_TYPE, :JX, :JH, :SJJS, :JSSJJS, :WZJS, :DLWZ, :GZWZ, :CXWZ, :SJZZBB, :SJHZBB, :SJZZBX, :SJHZBX, :SJZZB, :SJHZB, :DMHB, :BXG, :ZYMDC, :SJR, :SPR, :SPRQ, :SJRQ, :BCRQ, :BZ, :LJFGS,:REPORT_TYPE,:ISLATESTRECORD,:ISFINISH )");
            OracleParameter[] parameter = {
                                            new OracleParameter(":ZJH",OracleDbType.Varchar2,30),
                                            new OracleParameter(":SC3",OracleDbType.Varchar2,30),
                                            new OracleParameter(":SC2",OracleDbType.Varchar2,30),
                                            new OracleParameter(":QK",OracleDbType.Varchar2,10),
                                            new OracleParameter(":REPORT_TYPE",OracleDbType.Varchar2,10),
                                            new OracleParameter(":JX",OracleDbType.Varchar2,10),
                                            new OracleParameter(":JH",OracleDbType.Varchar2,10),
                                            new OracleParameter(":SJJS",OracleDbType.Decimal),
                                            new OracleParameter(":JSSJJS",OracleDbType.Decimal),
                                            new OracleParameter(":WZJS",OracleDbType.Decimal),
                                            new OracleParameter(":DLWZ",OracleDbType.Varchar2,255),
                                            new OracleParameter(":GZWZ",OracleDbType.Varchar2,255),
                                            new OracleParameter(":CXWZ",OracleDbType.Varchar2,255),
                                            new OracleParameter(":SJZZBB",OracleDbType.Decimal),
                                            new OracleParameter(":SJHZBB",OracleDbType.Decimal),
                                            new OracleParameter(":SJZZBX",OracleDbType.Decimal),
                                            new OracleParameter(":SJHZBX",OracleDbType.Decimal),
                                            new OracleParameter(":SJZZB",OracleDbType.Decimal),
                                            new OracleParameter(":SJHZB",OracleDbType.Decimal),
                                            new OracleParameter(":DMHB",OracleDbType.Decimal),
                                            new OracleParameter(":BXG",OracleDbType.Decimal),
                                            new OracleParameter(":ZYMDC",OracleDbType.Varchar2,255),
                                            new OracleParameter(":SJR",OracleDbType.Varchar2,10),
                                            new OracleParameter(":SPR",OracleDbType.Varchar2,10),
                                            new OracleParameter(":SJRQ",OracleDbType.Date),
                                            new OracleParameter(":SPRQ",OracleDbType.Date),
                                            new OracleParameter(":BCRQ",OracleDbType.Date),
                                            new OracleParameter(":BZ",OracleDbType.Varchar2,255),
                                            new OracleParameter(":LJFGS",OracleDbType.Varchar2,50),
                                            new OracleParameter(":REPORT_TYPE",OracleDbType.Varchar2,30),
                                            new OracleParameter(":ISLATESTRECORD",OracleDbType.Int32),
                                            new OracleParameter(":ISFINISH",OracleDbType.Int32)
                                        };
            parameter[0].Value = DJSJ.ZJH;
            parameter[1].Value = DJSJ.SC3;
            parameter[2].Value = DJSJ.SC2;
            parameter[3].Value = DJSJ.QK;
            parameter[4].Value = DJSJ.REPORT_TYPE;
            parameter[5].Value = DJSJ.JX;
            parameter[6].Value = DJSJ.JH;
            parameter[7].Value = DJSJ.SJJS;
            parameter[8].Value = DJSJ.JSSJJS;
            parameter[9].Value = DJSJ.WZJS;
            parameter[10].Value = DJSJ.DLWZ;
            parameter[11].Value = DJSJ.GZWZ;
            parameter[12].Value = DJSJ.CXWZ;
            parameter[13].Value = DJSJ.SJZZBB;
            parameter[14].Value = DJSJ.SJHZBB;
            parameter[15].Value = DJSJ.SJZZBX;
            parameter[16].Value = DJSJ.SJHZBX;
            parameter[17].Value = DJSJ.SJZZB;
            parameter[18].Value = DJSJ.SJHZB;
            parameter[19].Value = DJSJ.DMHB;
            parameter[20].Value = DJSJ.BXG;
            parameter[21].Value = DJSJ.ZYMDC;
            parameter[22].Value = DJSJ.SJR;
            parameter[23].Value = DJSJ.SPR;
            parameter[24].Value = DJSJ.SJRQ_date;
            parameter[25].Value = DJSJ.SPRQ_date;
            parameter[26].Value = DateTime.Now;
            parameter[27].Value = DJSJ.BZ;
            parameter[28].Value = DJSJ.LJFGS;
            parameter[29].Value = DJSJ.JX;    //REPORT_TYPE对应井型值
            parameter[30].Value = DJSJ.ISLATESTRECORD;   //派工标识
            parameter[31].Value = DJSJ.ISFINISH;   //派工完成标识
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
        /// 查询最大序号值
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int COUNT_List(string dtName, string strWhere)
        {
            string strSql = @"SELECT COUNT(*) FROM " + dtName;
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql += " WHERE 1=1" + strWhere;
            }
            object result = DbHelperOra.GetSingle(strSql.ToString());
            if (result == null)
            {
                return 0;
            }
            return Convert.ToInt32(result);
        }

        /// <summary>
        /// 获取菜单字段表中分类
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public string Ptype(string Name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT PTYPE FROM SYS_DICTIONARY");
            strSql.Append(" WHERE 1=1 AND NAME='" + Name + "'");

            DataTable dt = DbHelperOra.Query(strSql.ToString()).Tables[0];
            string result = "";
            if (dt.Rows.Count > 0)
            {
                result = dt.Rows[0]["PTYPE"].ToString();
            }
            return result.ToString();
        }

        #region 实体类



        /// <summary>
        /// 单井设计实体类
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public LQ_DJSJ DJSJModel(DataRow dr)
        {
            LQ_DJSJ model = new LQ_DJSJ();
            if (dr["ZJH"] != null && dr["ZJH"].ToString() != "")
            {
                model.ZJH = dr["ZJH"].ToString();
            }

            if (dr["TROW"] != null && dr["TROW"].ToString() != "")
            {
                model.TROW = Convert.ToInt32(dr["TROW"]);
            }

            if (dr["SC3"] != null && dr["SC3"].ToString() != "")
            {
                model.SC3 = dr["SC3"].ToString();
            }

            if (dr["SC2"] != null && dr["SC2"].ToString() != "")
            {
                model.SC2 = dr["SC2"].ToString();
            }

            if (dr["QK"] != null && dr["QK"].ToString() != "")
            {
                model.QK = dr["QK"].ToString();
            }

            if (dr["REPORT_TYPE"] != null && dr["REPORT_TYPE"].ToString() != "")
            {
                model.REPORT_TYPE = dr["REPORT_TYPE"].ToString();
            }

            if (dr["JX"] != null && dr["JX"].ToString() != "")
            {
                model.JX = dr["JX"].ToString();
            }

            if (dr["JH"] != null && dr["JH"].ToString() != "")
            {
                model.JH = dr["JH"].ToString();
            }

            if (dr["SJJS"] != null && dr["SJJS"].ToString() != "")
            {
                model.SJJS = Convert.ToDecimal(dr["SJJS"]);
            }

            if (dr["JSSJJS"] != null && dr["JSSJJS"].ToString() != "")
            {
                model.JSSJJS = Convert.ToDecimal(dr["JSSJJS"]);
            }

            if (dr["WZJS"] != null && dr["WZJS"].ToString() != "")
            {
                model.WZJS = Convert.ToDecimal(dr["WZJS"]);
            }

            if (dr["DLWZ"] != null && dr["DLWZ"].ToString() != "")
            {
                model.DLWZ = dr["DLWZ"].ToString();
            }

            if (dr["GZWZ"] != null && dr["GZWZ"].ToString() != "")
            {
                model.GZWZ = dr["GZWZ"].ToString();
            }

            if (dr["CXWZ"] != null && dr["CXWZ"].ToString() != "")
            {
                model.CXWZ = dr["CXWZ"].ToString();
            }

            if (dr["SJZZBB"] != null && dr["SJZZBB"].ToString() != "")
            {
                model.SJZZBB = Convert.ToDecimal(dr["SJZZBB"]);
            }

            if (dr["SJHZBB"] != null && dr["SJHZBB"].ToString() != "")
            {
                model.SJHZBB = Convert.ToDecimal(dr["SJHZBB"]);
            }

            if (dr["SJZZBX"] != null && dr["SJZZBX"].ToString() != "")
            {
                model.SJZZBX = Convert.ToDecimal(dr["SJZZBX"]);
            }

            if (dr["SJHZBX"] != null && dr["SJHZBX"].ToString() != "")
            {
                model.SJHZBX = Convert.ToDecimal(dr["SJHZBX"]);
            }

            if (dr["SJZZB"] != null && dr["SJZZB"].ToString() != "")
            {
                model.SJZZB = Convert.ToDecimal(dr["SJZZB"]);
            }

            if (dr["SJHZB"] != null && dr["SJHZB"].ToString() != "")
            {
                model.SJHZB = Convert.ToDecimal(dr["SJHZB"]);
            }

            if (dr["DMHB"] != null && dr["DMHB"].ToString() != "")
            {
                model.DMHB = Convert.ToDecimal(dr["DMHB"]);
            }

            if (dr["BXG"] != null && dr["BXG"].ToString() != "")
            {
                model.BXG = Convert.ToDecimal(dr["BXG"]);
            }

            if (dr["ZYMDC"] != null && dr["ZYMDC"].ToString() != "")
            {
                model.ZYMDC = dr["ZYMDC"].ToString();
            }

            if (dr["SJR"] != null && dr["SJR"].ToString() != "")
            {
                model.SJR = dr["SJR"].ToString();
            }

            if (dr["SPR"] != null && dr["SPR"].ToString() != "")
            {
                model.SPR = dr["SPR"].ToString();
            }

            if (dr["SJRQ"] != null && dr["SJRQ"].ToString() != "")
            {
                model.SJRQ = Convert.ToDateTime(dr["SJRQ"]).ToString("yyyy-MM-dd");
                model.SJRQ_DG = Convert.ToDateTime(dr["SJRQ"]).ToString("yyyy-MM-dd");
            }
            else
            {
                model.SJRQ_DG = "";
            }

            if (dr["SPRQ"] != null && dr["SPRQ"].ToString() != "")
            {
                model.SPRQ = Convert.ToDateTime(dr["SPRQ"]).ToString("yyyy-MM-dd");
                model.SPRQ_DG = Convert.ToDateTime(dr["SPRQ"]).ToString("yyyy-MM-dd");
            }
            else
            {
                model.SPRQ_DG = "";
            }

            //if (dr["TJRQ"] != null && dr["TJRQ"].ToString ( ) != "")
            //{
            //    model.TJRQ = Convert.ToDateTime ( dr["TJRQ"] );
            //}

            if (dr["BZ"] != null && dr["BZ"].ToString() != "")
            {
                model.BZ = dr["BZ"].ToString();
            }

            if (dr["LJFGS"] != null && dr["LJFGS"].ToString() != "")
            {
                model.LJFGS = dr["LJFGS"].ToString();
            }

            if (dr["ID"] != null && dr["ID"].ToString() != "")
            {
                model.ID = dr["ID"].ToString();
            }
            if (dr["ISLATESTRECORD"] != null && dr["ISLATESTRECORD"].ToString() != "")
            {
                model.ISLATESTRECORD = Convert.ToInt32(dr["ISLATESTRECORD"]);
            }
            if (dr["ISFINISH"] != null && dr["ISFINISH"].ToString() != "")
            {
                model.ISFINISH = Convert.ToInt32(dr["ISFINISH"]);
            }
            return model;

        }

        #endregion

        #region 地图列表
        /// <summary>
        /// 地图列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet MapList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ZJH, SC3, SJHZB,SJZZB  FROM LQ_DJSJ");
            return DbHelperOra.Query(strSql.ToString());
        }
        #endregion

        /// <summary>
        /// 地图实体类
        /// </summary>
        /// <returns></returns>
        //public MapItem MapModel(DataRow dr)
        //{

        //    //model.Caption=
        //    if (dr["SC3"] != null && dr["SC3"].ToString() != "")
        //    {
        //        model.Caption = dr["SC3"].ToString();
        //    }

        //    if ((dr["SJHZB"] != null && dr["SJHZB"].ToString() != "") || (dr["SJZZB"] != null && dr["SJZZB"].ToString() != ""))
        //    {
        //        //Location loc = ;
        //        model.Location = new Location(Convert.ToDouble(dr["SJZZB"]), Convert.ToDouble(dr["SJHZB"]));
        //    }
        //    model.BaseZoomLevel = 5;
        //    model.ZoomRange = new ZoomRange(3, 18);
        //    return model;

        //}
    }
}
