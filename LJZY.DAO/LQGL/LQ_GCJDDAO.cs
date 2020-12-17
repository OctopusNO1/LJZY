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
    public class LQ_GCJDDAO
    {
        #region 工程进度模块

        public DataSet GCJD_Check(string strWhere, string dtName1)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ROW_NUMBER() OVER(ORDER BY A.SC3, A.JH DESC,A.REPORT_TYPE) AS TROW,A.* FROM " + dtName1 + "  A");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1 " + strWhere);
            }

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 侧钻数据验证
        /// </summary>
        /// <param name="CZ"></param>
        /// <returns></returns>
        public string GCJDCZ_Check(LQ_GCJD_CZ CZ)
        {
            string CZKSSJ_Str = "";
            string CZJSSJ_Str = "";
            if (CZ.CZKSSJ == null)
            {
                CZKSSJ_Str = "DEFAULT,";
            }
            else
            {
                CZKSSJ_Str = "TO_DATE('{0}', 'YYYY-MM-DD'),";
            }
            if (CZ.CZJSSJ == null)
            {
                CZJSSJ_Str = "DEFAULT,";

            }
            else
            {
                CZJSSJ_Str = "TO_DATE('{1}', 'YYYY-MM-DD'),";
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ROW_NUMBER() OVER(ORDER BY TJSJ DESC) AS TROW,T.* from LQ_GCJD_CZ T ");
            strSql.Append(string.Format(" WHERE ZJH='{0}' AND CZMC='{1}'", CZ.ZJH, CZ.CZMC));
            DataTable dt = DbHelperOra.Query(strSql.ToString()).Tables[0];
            string CZstr = "";
            if (dt.Rows.Count > 0)
            {
                CZstr = string.Format(@"UPDATE LQ_GCJD_CZ
SET CZKSSJ=" + CZKSSJ_Str + @" CZJSSJ=" + CZJSSJ_Str + @" CZKSJS={2},CZJSJS={3}
WHERE CZMC='{4}' AND ZJH='{5}'", CZ.CZKSSJ_Str, CZ.CZJSSJ_Str, CZ.CZKSJS, CZ.CZJSJS, CZ.CZMC, CZ.ZJH);
            }
            else
            {
                CZstr = string.Format(@"INSERT INTO LQ_GCJD_CZ(CZKSSJ,CZJSSJ,CZKSJS,CZJSJS,CZMC,ZJH,TJSJ)
VALUES(" + CZKSSJ_Str + " " + CZJSSJ_Str + " {2},{3},'{4}','{5}',SYSDATE)", CZ.CZKSSJ_Str, CZ.CZJSSJ_Str, CZ.CZKSJS, CZ.CZJSJS, CZ.CZMC, CZ.ZJH);
            }

            return CZstr;
        }

        /// <summary>
        /// 中停数据验证
        /// </summary>
        /// <param name="ZT"></param>
        /// <returns></returns>
        public string GCJDZT_Check(LQ_GCJD_ZT ZT)
        {
            string ZTKSSJ_Str = "";
            string ZTJSSJ_Str = "";
            if (ZT.ZTKSSJ == null)
            {
                ZTKSSJ_Str = "DEFAULT,";
            }
            else
            {
                ZTKSSJ_Str = "TO_DATE('{0}', 'YYYY-MM-DD'),";
            }
            if (ZT.ZTJSSJ == null)
            {
                ZTJSSJ_Str = "DEFAULT,";

            }
            else
            {
                ZTJSSJ_Str = "TO_DATE('{1}', 'YYYY-MM-DD'),";
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ROW_NUMBER() OVER(ORDER BY TJSJ DESC) AS TROW,T.* from LQ_GCJD_ZT T ");
            strSql.Append(string.Format(" WHERE ZJH='{0}' AND ZTMC='{1}'", ZT.ZJH, ZT.ZTMC));
            DataTable dt = DbHelperOra.Query(strSql.ToString()).Tables[0];
            string ZTstr = "";
            if (dt.Rows.Count > 0)
            {
                ZTstr = string.Format(@"UPDATE LQ_GCJD_ZT
SET ZTKSSJ=" + ZTKSSJ_Str + @" ZTJSSJ=" + ZTJSSJ_Str + @"
WHERE ZTMC='{2}' AND ZJH='{3}'", ZT.ZTKSSJ_Str, ZT.ZTJSSJ_Str, ZT.ZTMC, ZT.ZJH);
            }
            else
            {
                ZTstr = string.Format(@"INSERT INTO LQ_GCJD_ZT(ZTKSSJ,ZTJSSJ,ZTMC,ZJH,TJSJ)
VALUES(" + ZTKSSJ_Str + " " + ZTJSSJ_Str + " '{2}','{3}',SYSDATE)", ZT.ZTKSSJ_Str, ZT.ZTJSSJ_Str, ZT.ZTMC, ZT.ZJH);
            }

            return ZTstr;
        }

        /// <summary>
        /// 工程进度修改
        /// </summary>
        /// <param name="GCJD"></param>
        /// <returns></returns>
        public bool Update(LQ_GCJD GCJD, string CZSql, string ZTSql, string dtName1)
        {
            string STARSTART_str = "";
            string STAREND_str = "";
            string GCFZCLSJ_str = "";
            string KZRQ_str = "";
            string WZRQ_str = "";
            string GJRQ_str = "";
            string WJRQ_str = "";
            string DZLJKSSJ_Str = "";
            string YXLJKSSJ_str = "";
            string QCLJKSSJ_str = "";
            string ZHLJKSSJ_str = "";
            string YJWJRQ_str = "";
            if (GCJD.STARSTART == null)
            {
                STARSTART_str = "DEFAULT,";
            }
            else
            {
                STARSTART_str = "TO_DATE('{4}','YYYY-MM-DD'),";
            }
            if (GCJD.STAREND == null)
            {
                STAREND_str = "DEFAULT,";
            }
            else
            {
                STAREND_str = "TO_DATE('{5}','YYYY-MM-DD'),";
            }

            if (GCJD.GCFZCLSJ == null)
            {
                GCFZCLSJ_str = "DEFAULT,";
            }
            else
            {
                GCFZCLSJ_str = "TO_DATE('{40}','YYYY-MM-DD'),";
            }
            if (GCJD.KZRQ == null)
            {
                KZRQ_str = "DEFAULT,";
            }
            else
            {
                KZRQ_str = "TO_DATE('{41}','YYYY-MM-DD'),";
            }
            if (GCJD.WZRQ == null)
            {
                WZRQ_str = "DEFAULT,";
            }
            else
            {
                WZRQ_str = "TO_DATE('{42}','YYYY-MM-DD'),";
            }
            if (GCJD.GJRQ == null)
            {
                GJRQ_str = "DEFAULT,";
            }
            else
            {
                GJRQ_str = "TO_DATE('{43}','YYYY-MM-DD'),";
            }
            if (GCJD.WJRQ == null)
            {
                WJRQ_str = "DEFAULT,";
            }
            else
            {
                WJRQ_str = "TO_DATE('{44}','YYYY-MM-DD'),";
            }
            if (GCJD.DZLJKSSJ == null)
            {
                DZLJKSSJ_Str = "DEFAULT,";
            }
            else
            {
                DZLJKSSJ_Str = "TO_DATE('{45}','YYYY-MM-DD'),";
            }


            if (GCJD.YXLJKSSJ == null)
            {
                YXLJKSSJ_str = "DEFAULT,";
            }
            else
            {
                YXLJKSSJ_str = "TO_DATE('{46}','YYYY-MM-DD'),";
            }


            if (GCJD.QCLJKSSJ == null)
            {
                QCLJKSSJ_str = "DEFAULT,";
            }
            else
            {
                QCLJKSSJ_str = "TO_DATE('{47}','YYYY-MM-DD'),";
            }
            if (GCJD.ZHLJKSSJ == null)
            {
                ZHLJKSSJ_str = "DEFAULT,";
            }
            else
            {
                ZHLJKSSJ_str = "TO_DATE('{48}','YYYY-MM-DD'),";
            }
            if (GCJD.YJWJRQ == null)
            {
                YJWJRQ_str = "DEFAULT,";
            }
            else
            {
                YJWJRQ_str = "TO_DATE('{50}','YYYY-MM-DD'),";
            }
            ArrayList list = new ArrayList();
            string sqlStr = string.Format(@"
            Update " + dtName1 + @"
            Set 
            SC3='{0}', SC2='{1}', QK='{2}', REPORT_TYPE='{3}', STARSTART=" + STARSTART_str + @" STAREND=" + STAREND_str + @"  LJXL='{6}', DZLJKSJS={7}, YXLJKSJS={8}, QCLJKSJS={9}, ZHLJKSJS={10}, SJJS={11}, JSSJJS={12}, WZJS={13}, SJZZB={14}, SJHZB={15}, DMHB={16}, BXG={17}, SGDW='{18}', SGDH='{19}', LJFGS='{20}', LJDH='{21}', LJYQXH='{22}', ZYMDC='{23}', WZCW='{24}', WJFF='{25}', DYNZDJS={26}, DENZDJS={27}, SFJJYQXS='{28}', SFQX='{29}', SFJSYQC='{30}', SFCXGCFZ='{31}', CXGCFZLX='{32}', SFXYCTG='{33}', SJWZYZ='{34}', WZYJ='{35}', SFBF='{36}', BFLX='{37}', ZTLX='{38}', BZ='{39}', GCFZCLSJ=" + GCFZCLSJ_str + @" KZRQ=" + KZRQ_str + @" WZRQ=" + WZRQ_str + @" GJRQ=" + GJRQ_str + @" WJRQ=" + WJRQ_str + @" DZLJKSSJ=" + DZLJKSSJ_Str + @" YXLJKSSJ=" + YXLJKSSJ_str + @" QCLJKSSJ=" + QCLJKSSJ_str + @" ZHLJKSSJ=" + ZHLJKSSJ_str + @" SGDDH='{49}',YJWJRQ=" + YJWJRQ_str + @" JX='{51}' 
            WHERE JH='{52}' ", GCJD.SC3, GCJD.SC2, GCJD.QK, GCJD.REPORT_TYPE, GCJD.STARSTART_Str, GCJD.STAREND_Str, GCJD.LJXL, GCJD.DZLJKSJS, GCJD.YXLJKSJS, GCJD.QCLJKSJS, GCJD.ZHLJKSJS, GCJD.SJJS, GCJD.JSSJJS, GCJD.WZJS, GCJD.SJZZB, GCJD.SJHZB, GCJD.DMHB, GCJD.BXG, GCJD.SGDW, GCJD.SGDH, GCJD.LJFGS, GCJD.LJDH, GCJD.LJYQXH, GCJD.ZYMDC, GCJD.WZCW, GCJD.WJFF, GCJD.DYNZDJS, GCJD.DENZDJS, GCJD.SFJJYQXS, GCJD.SFQX, GCJD.SFJSYQC, GCJD.SFCXGCFZ, GCJD.CXGCFZLX, GCJD.SFXYCTG, GCJD.SJWZYZ, GCJD.WZYJ, GCJD.SFBF, GCJD.BFLX, GCJD.ZTLX, GCJD.BZ, GCJD.GCFZCLSJ_Str, GCJD.KZRQ_Str, GCJD.WZRQ_Str, GCJD.GJRQ_Str, GCJD.WJRQ_Str, GCJD.DZLJKSSJ_Str, GCJD.YXLJKSSJ_Str, GCJD.QCLJKSSJ_Str, GCJD.ZHLJKSSJ_Str, GCJD.SGDDH, GCJD.YJWJRQ, GCJD.JX, GCJD.JH);
            //string sqlStr = string.Format(@"
            //Update " + dtName1 + @"
            //Set 
            //SC3='{0}', SC2='{1}', QK='{2}', REPORT_TYPE='{3}', STARSTART=TO_DATE('{4}','YYYY-MM-DD'), STAREND=TO_DATE('{5}','YYYY-MM-DD') , LJXL='{6}', DZLJKSJS={7}, YXLJKSJS={8}, QCLJKSJS={9}, ZHLJKSJS={10}, SJJS={11}, JSSJJS={12}, WZJS={13}, SJZZB={14}, SJHZB={15}, DMHB={16}, BXG={17}, SGDW='{18}', SGDH='{19}', LJFGS='{20}', LJDH='{21}', LJYQXH='{22}', ZYMDC='{23}', WZCW='{24}', WJFF='{25}', DYNZDJS={26}, DENZDJS={27}, SFJJYQXS='{28}', SFQX='{29}', SFJSYQC='{30}', SFCXGCFZ='{31}', CXGCFZLX='{32}', SFXYCTG='{33}', SJWZYZ='{34}', WZYJ='{35}', SFBF='{36}', BFLX='{37}', ZTLX='{38}', BZ='{39}', GCFZCLSJ=TO_DATE('{40}','YYYY-MM-DD'), KZRQ=TO_DATE('{41}','YYYY-MM-DD'), WZRQ=TO_DATE('{42}','YYYY-MM-DD'), GJRQ=TO_DATE('{43}','YYYY-MM-DD'), WJRQ=TO_DATE('{44}','YYYY-MM-DD'), DZLJKSSJ=TO_DATE('{45}','YYYY-MM-DD'), YXLJKSSJ=TO_DATE('{46}','YYYY-MM-DD'), QCLJKSSJ=TO_DATE('{47}','YYYY-MM-DD'), ZHLJKSSJ=TO_DATE('{48}','YYYY-MM-DD'),SGDDH='{49}',YJWJRQ=TO_DATE('{50}','YYYY-MM-DD'),JX='{51}' 
            //WHERE JH='{52}' ", GCJD.SC3, GCJD.SC2, GCJD.QK, GCJD.REPORT_TYPE, GCJD.STARSTART.Value.ToShortDateString(), GCJD.STAREND.ToShortDateString(), GCJD.LJXL, GCJD.DZLJKSJS, GCJD.YXLJKSJS, GCJD.QCLJKSJS, GCJD.ZHLJKSJS, GCJD.SJJS, GCJD.JSSJJS, GCJD.WZJS, GCJD.SJZZB, GCJD.SJHZB, GCJD.DMHB, GCJD.BXG, GCJD.SGDW, GCJD.SGDH, GCJD.LJFGS, GCJD.LJDH, GCJD.LJYQXH, GCJD.ZYMDC, GCJD.WZCW, GCJD.WJFF, GCJD.DYNZDJS, GCJD.DENZDJS, GCJD.SFJJYQXS, GCJD.SFQX, GCJD.SFJSYQC, GCJD.SFCXGCFZ, GCJD.CXGCFZLX, GCJD.SFXYCTG, GCJD.SJWZYZ, GCJD.WZYJ, GCJD.SFBF, GCJD.BFLX, GCJD.ZTLX, GCJD.BZ, GCJD.GCFZCLSJ.ToShortDateString(), GCJD.KZRQ.ToShortDateString(), GCJD.WZRQ.ToShortDateString(), GCJD.GJRQ.ToShortDateString(), GCJD.WJRQ.ToShortDateString(), GCJD.DZLJKSSJ.ToShortDateString(), GCJD.YXLJKSSJ.ToShortDateString(), GCJD.QCLJKSSJ.ToShortDateString(), GCJD.ZHLJKSSJ.ToShortDateString(), GCJD.SGDDH, GCJD.YJWJRQ, GCJD.JX, GCJD.JH);
            list.Add(sqlStr);
            list.Add(CZSql);
            list.Add(ZTSql);
            return DbHelperOra.ExecuteSqlTrans(list);
        }

        public bool Update(List<LQ_GCJD> list, string dtName1)
        {

            Hashtable arrList = new Hashtable();

            for (int i = 0; i < list.Count; i++)
            {
                string sqlStr = string.Format(@"
UPDATE " + dtName1 + @" 
   SET SC3 = :SC3{0},
       SC2 = :SC2{0},
       QK = :QK{0},
       REPORT_TYPE = :REPORT_TYPE{0},
       STARSTART = :STARSTART{0},
       STAREND = :STAREND{0},
       LJXL = :LJXL{0},
       DZLJKSJS = :DZLJKSJS{0},
       YXLJKSJS = :YXLJKSJS{0},
       QCLJKSJS = :QCLJKSJS{0},
       ZHLJKSJS = :ZHLJKSJS{0},
       SJJS = :SJJS{0},
       JSSJJS = :JSSJJS{0},
       WZJS = :WZJS{0},
       SJZZB = :SJZZB{0},
       SJHZB = :SJHZB{0},
       DMHB = :DMHB{0},
       BXG = :BXG{0},
       SGDW = :SGDW{0},
       SGDH = :SGDH{0},
       LJFGS = :LJFGS{0},
       LJDH = :LJDH{0},
       LJYQXH = :LJYQXH{0},
       ZYMDC = :ZYMDC{0},
       WZCW = :WZCW{0},
       WJFF = :WJFF{0},
       DYNZDJS = :DYNZDJS{0},
       DENZDJS = :DENZDJS{0},
       SFJJYQXS = :SFJJYQXS{0},
       SFQX = :SFQX{0},
       SFJSYQC = :SFJSYQC{0},
       SFCXGCFZ = :SFCXGCFZ{0},
       CXGCFZLX = :CXGCFZLX{0},
       SFXYCTG = :SFXYCTG{0},
       SJWZYZ = :SJWZYZ{0},
       WZYJ = :WZYJ{0},
       SFBF = :SFBF{0},
       BFLX = :BFLX{0},
       ZTLX = :ZTLX{0},
       BZ = :BZ{0},
       GCFZCLSJ = :GCFZCLSJ{0},
       KZRQ = :KZRQ{0},
       WZRQ = :WZRQ{0},
       GJRQ = :GJRQ{0},
       WJRQ = :WJRQ{0},
       DZLJKSSJ = :DZLJKSSJ{0},
       YXLJKSSJ = :YXLJKSSJ{0},
       QCLJKSSJ = :QCLJKSSJ{0},
       ZHLJKSSJ = :ZHLJKSSJ{0},
       SGDDH = :SGDDH{0},
       YJWJRQ = :YJWJRQ{0},
       JX = :JX{0}
 WHERE JH = :JH{0} ", i);

                OracleParameter[] parameter = {
                                            new OracleParameter(string.Format(":SC3{0}",i),OracleDbType.Varchar2,30),
                                            new OracleParameter(string.Format(":SC2{0}",i),OracleDbType.Varchar2,30),
                                            new OracleParameter(string.Format(":QK{0}",i),OracleDbType.Varchar2,10),
                                            new OracleParameter(string.Format(":REPORT_TYPE{0}",i),OracleDbType.Varchar2,16),
                                            new OracleParameter(string.Format(":STARSTART{0}",i),OracleDbType.Date),
                                            new OracleParameter(string.Format(":STAREND{0}",i),OracleDbType.Date),
                                            new OracleParameter(string.Format(":LJXL{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":DZLJKSJS{0}",i),OracleDbType.Decimal),
                                            new OracleParameter(string.Format(":YXLJKSJS{0}",i),OracleDbType.Decimal),
                                            new OracleParameter(string.Format(":QCLJKSJS{0}",i),OracleDbType.Decimal),
                                            new OracleParameter(string.Format(":ZHLJKSJS{0}",i),OracleDbType.Decimal),
                                            new OracleParameter(string.Format(":SJJS{0}",i),OracleDbType.Decimal),
                                            new OracleParameter(string.Format(":JSSJJS{0}",i),OracleDbType.Decimal),
                                            new OracleParameter(string.Format(":WZJS{0}",i),OracleDbType.Decimal),
                                            new OracleParameter(string.Format(":SJZZB{0}",i),OracleDbType.Decimal),
                                            new OracleParameter(string.Format(":SJHZB{0}",i),OracleDbType.Decimal),
                                            new OracleParameter(string.Format(":DMHB{0}",i),OracleDbType.Decimal),
                                            new OracleParameter(string.Format(":BXG{0}",i),OracleDbType.Decimal),
                                            new OracleParameter(string.Format(":SGDW{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":SGDH{0}",i),OracleDbType.Varchar2,30),
                                            new OracleParameter(string.Format(":LJFGS{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":LJDH{0}",i),OracleDbType.Varchar2,20),
                                            new OracleParameter(string.Format(":LJYQXH{0}",i),OracleDbType.Varchar2,30),
                                            new OracleParameter(string.Format(":ZYMDC{0}",i),OracleDbType.Varchar2,255),
                                            new OracleParameter(string.Format(":WZCW{0}",i),OracleDbType.Varchar2,30),
                                            new OracleParameter(string.Format(":WJFF{0}",i),OracleDbType.Varchar2,16),
                                            new OracleParameter(string.Format(":DYNZDJS{0}",i),OracleDbType.Decimal),
                                            new OracleParameter(string.Format(":DENZDJS{0}",i),OracleDbType.Decimal),
                                            new OracleParameter(string.Format(":SFJJYQXS{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":SFQX{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":SFJSYQC{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":SFCXGCFZ{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":CXGCFZLX{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":SFXYCTG{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":SJWZYZ{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":WZYJ{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":SFBF{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":BFLX{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":ZTLX{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":BZ{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":GCFZCLSJ{0}",i),OracleDbType.Date),
                                            new OracleParameter(string.Format(":KZRQ{0}",i),OracleDbType.Date),
                                            new OracleParameter(string.Format(":WZRQ{0}",i),OracleDbType.Date),
                                            new OracleParameter(string.Format(":GJRQ{0}",i),OracleDbType.Date),
                                            new OracleParameter(string.Format(":WJRQ{0}",i),OracleDbType.Date),
                                            new OracleParameter(string.Format(":DZLJKSSJ{0}",i),OracleDbType.Date),
                                            new OracleParameter(string.Format(":YXLJKSSJ{0}",i),OracleDbType.Date),
                                            new OracleParameter(string.Format(":QCLJKSSJ{0}",i),OracleDbType.Date),
                                            new OracleParameter(string.Format(":ZHLJKSSJ{0}",i),OracleDbType.Date),
                                            new OracleParameter(string.Format(":SGDDH{0}",i),OracleDbType.Date),
                                            new OracleParameter(string.Format(":YJWJRQ{0}",i),OracleDbType.Date),
                                            new OracleParameter(string.Format(":JX{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":JH{0}",i),OracleDbType.Varchar2,50)
                                        };

                parameter[0].Value = list[i].SC3;
                parameter[1].Value = list[i].SC2;
                parameter[2].Value = list[i].QK;
                parameter[3].Value = list[i].REPORT_TYPE;
                parameter[4].Value = list[i].STARSTART;
                parameter[5].Value = list[i].STAREND;
                parameter[6].Value = list[i].LJXL;
                parameter[7].Value = list[i].DZLJKSJS;
                parameter[8].Value = list[i].YXLJKSJS;
                parameter[9].Value = list[i].QCLJKSJS;
                parameter[10].Value = list[i].ZHLJKSJS;
                parameter[11].Value = list[i].SJJS;
                parameter[12].Value = list[i].JSSJJS;
                parameter[13].Value = list[i].WZJS;
                parameter[14].Value = list[i].SJZZB;
                parameter[15].Value = list[i].SJHZB;
                parameter[16].Value = list[i].DMHB;
                parameter[17].Value = list[i].BXG;
                parameter[18].Value = list[i].SGDW;
                parameter[19].Value = list[i].SGDH;
                parameter[20].Value = list[i].LJFGS;
                parameter[21].Value = list[i].LJDH;
                parameter[22].Value = list[i].LJYQXH;
                parameter[23].Value = list[i].ZYMDC;
                parameter[24].Value = list[i].WZCW;
                parameter[25].Value = list[i].WJFF;
                parameter[26].Value = list[i].DYNZDJS;
                parameter[27].Value = list[i].DENZDJS;
                parameter[28].Value = list[i].SFJJYQXS;
                parameter[29].Value = list[i].SFQX;
                parameter[30].Value = list[i].SFJSYQC;
                parameter[31].Value = list[i].SFCXGCFZ;
                parameter[32].Value = list[i].CXGCFZLX;
                parameter[33].Value = list[i].SFXYCTG;
                parameter[34].Value = list[i].SJWZYZ;
                parameter[35].Value = list[i].WZYJ;
                parameter[36].Value = list[i].SFBF;
                parameter[37].Value = list[i].BFLX;
                parameter[38].Value = list[i].ZTLX;
                parameter[39].Value = list[i].BZ;
                parameter[40].Value = list[i].GCFZCLSJ;
                parameter[41].Value = list[i].KZRQ;
                parameter[42].Value = list[i].WZRQ;
                parameter[43].Value = list[i].GJRQ;
                parameter[44].Value = list[i].WJRQ;
                parameter[45].Value = list[i].DZLJKSSJ;
                parameter[46].Value = list[i].YXLJKSSJ;
                parameter[47].Value = list[i].QCLJKSSJ;
                parameter[48].Value = list[i].ZHLJKSSJ;
                parameter[49].Value = list[i].SGDDH;
                parameter[50].Value = list[i].YJWJRQ;
                parameter[51].Value = list[i].JX;
                parameter[52].Value = list[i].JH;

                arrList.Add(sqlStr, parameter);


            }
            return DbHelperOra.ExecuteSqlTran(arrList);
        }

        /// <summary>
        /// 工程进度删除
        /// </summary>
        /// <param name="ZJH"></param>
        /// <returns></returns>
        public bool Del(string JH, string JX, string dtName1)
        {

            string sqlStr = @" delete from " + dtName1 + "   WHERE JH=:JH ";
            OracleParameter[] parameter = {
                                            new OracleParameter(":JH",OracleDbType.Varchar2,10)
                                          };
            parameter[0].Value = JH;
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
        /// 工程进度信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GCJDInfo(string strWhere, string dtName1, string dtName61)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT DT.* FROM (SELECT ROW_NUMBER () OVER (ORDER BY A.SC3, A.JH DESC, A.REPORT_TYPE) TROW,A.*,A61.DRJS,A61.SGZT FROM " + dtName1 + " A");
            strSql.Append(" LEFT OUTER JOIN " + dtName61 + " A61 ON A.JH=A61.JH AND HBRQ=SYSDATE ) DT ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("Where 1=1 " + strWhere);
            }

            return DbHelperOra.Query(strSql.ToString());
        }

        public DataSet GCJDInfo_TROW(string strWhere, string dtName1, string dtName61)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ROW_NUMBER () OVER (ORDER BY SC3, JH DESC,REPORT_TYPE) TROW, DT.* FROM (SELECT A.*,A61.DRJS,A61.SGZT FROM " + dtName1 + " A");
            strSql.Append(" LEFT OUTER JOIN " + dtName61 + " A61 ON A.JH=A61.JH AND HBRQ=SYSDATE ) DT ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("WHERE 1=1 " + strWhere);
            }

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 查询侧钻信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet CZInfo(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY T.TJSJ DESC) AS TROW,T.* FROM LQ_GCJD_CZ T) ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1" + strWhere);
            }

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 查询中停信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet ZTInfo(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY T.TJSJ DESC) AS TROW,T.* FROM LQ_GCJD_ZT T) ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1" + strWhere);
            }

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据条件获取工程进度分页数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="filedOrder"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public DataSet GCJDInfo_strWhere(string strWhere, int pageSize, int pageIndex, string filedOrder, out int recordCount, string dtName1, string dtName61)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ROW_NUMBER () OVER (ORDER BY SC3, JH DESC,REPORT_TYPE) TROW, DT.* FROM (SELECT A.*,A61.DRJS,A61.SGZT FROM " + dtName1 + " A ");
            strSql.Append(" LEFT OUTER JOIN " + dtName61 + " A61 ON A.JH=A61.JH AND A61.HBRQ=SYSDATE ) DT");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1" + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperOra.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperOra.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
        public DataSet GCJDData(string strWhere, string dtName1, string dtName61)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ROW_NUMBER () OVER (ORDER BY SC3, JH DESC,REPORT_TYPE) TROW, DT.* FROM (SELECT A.*,A61.DRJS,A61.SGZT FROM " + dtName1 + " A ");
            strSql.Append(" LEFT OUTER JOIN " + dtName61 + " A61 ON A.JH=A61.JH AND A61.HBRQ=SYSDATE ) DT");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1" + strWhere);
            }

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 统计数据条数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int COUNT_List(string strWhere, string dtName1, string dtName61)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT COUNT(*) FROM (SELECT ROW_NUMBER() OVER(ORDER BY A.SC3, A.JH DESC,A.REPORT_TYPE ) AS TROW,A.*,A61.DRJS,A61.SGZT FROM " + dtName1 + " A ");
            strSql.Append(" LEFT OUTER JOIN " + dtName61 + " A61 ON A.JH=A61.JH AND HBRQ=SYSDATE ) Dt ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1 " + strWhere);
            }
            object result = DbHelperOra.GetSingle(strSql.ToString());
            if (result == null)
            {
                return 0;
            }
            return Convert.ToInt32(result);
        }

        /// <summary>
        /// 工程进度实体类
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public LQ_GCJD GCJDModel(DataRow dr)
        {
            LQ_GCJD model = new LQ_GCJD();
            if (dr["TROW"] != null && dr["TROW"].ToString() != "")
            {
                model.TROW = Convert.ToInt32(dr["TROW"]);
            }
            if (dr["ZJH"] != null && dr["ZJH"].ToString() != "")
            {
                model.ZJH = dr["ZJH"].ToString();
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

            if (dr["LJXL"] != null && dr["LJXL"].ToString() != "")
            {
                model.LJXL = dr["LJXL"].ToString();
            }

            if (dr["DZLJKSJS"] != null && dr["DZLJKSJS"].ToString() != "")
            {
                model.DZLJKSJS = Convert.ToDecimal(dr["DZLJKSJS"]);
            }

            if (dr["DZLJKSSJ"] != null && dr["DZLJKSSJ"].ToString() != "")
            {
                model.DZLJKSSJ = Convert.ToDateTime(dr["DZLJKSSJ"]);
                model.DZLJKSSJ_DG = Convert.ToDateTime(dr["DZLJKSSJ"]).ToString("yyyy-MM-dd");
            }
            else
            {
                model.DZLJKSSJ = null;
                model.DZLJKSSJ_DG = "";
            }

            if (dr["YXLJKSJS"] != null && dr["YXLJKSJS"].ToString() != "")
            {
                model.YXLJKSJS = Convert.ToDecimal(dr["YXLJKSJS"]);
            }

            if (dr["YXLJKSSJ"] != null && dr["YXLJKSSJ"].ToString() != "")
            {
                model.YXLJKSSJ = Convert.ToDateTime(dr["YXLJKSSJ"]);
                model.YXLJKSSJ_DG = Convert.ToDateTime(dr["YXLJKSSJ"]).ToString("yyyy-MM-dd");
            }
            else
            {
                model.YXLJKSSJ = null;
                model.YXLJKSSJ_DG = "";
            }

            if (dr["QCLJKSJS"] != null && dr["QCLJKSJS"].ToString() != "")
            {
                model.QCLJKSJS = Convert.ToDecimal(dr["QCLJKSJS"]);
            }

            if (dr["QCLJKSSJ"] != null && dr["QCLJKSSJ"].ToString() != "")
            {
                model.QCLJKSSJ = Convert.ToDateTime(dr["QCLJKSSJ"]);
                model.QCLJKSSJ_DG = Convert.ToDateTime(dr["QCLJKSSJ"]).ToString("yyyy-MM-dd");
            }
            else
            {
                model.QCLJKSSJ = null;
                model.QCLJKSSJ_DG = "";
            }

            if (dr["ZHLJKSJS"] != null && dr["ZHLJKSJS"].ToString() != "")
            {
                model.ZHLJKSJS = Convert.ToDecimal(dr["ZHLJKSJS"]);
            }

            if (dr["ZHLJKSSJ"] != null && dr["ZHLJKSSJ"].ToString() != "")
            {
                model.ZHLJKSSJ = Convert.ToDateTime(dr["ZHLJKSSJ"]);
                model.ZHLJKSSJ_DG = Convert.ToDateTime(dr["ZHLJKSSJ"]).ToString("yyyy-MM-dd");
            }
            else
            {
                model.ZHLJKSSJ = null;
                model.ZHLJKSSJ_DG = "";
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

            if (dr["SGDW"] != null && dr["SGDW"].ToString() != "")
            {
                model.SGDW = dr["SGDW"].ToString();
            }

            if (dr["SGDH"] != null && dr["SGDH"].ToString() != "")
            {
                model.SGDH = dr["SGDH"].ToString();
            }

            if (dr["LJFGS"] != null && dr["LJFGS"].ToString() != "")
            {
                model.LJFGS = dr["LJFGS"].ToString();
            }

            if (dr["LJDH"] != null && dr["LJDH"].ToString() != "")
            {
                model.LJDH = dr["LJDH"].ToString();
            }

            if (dr["LJYQXH"] != null && dr["LJYQXH"].ToString() != "")
            {
                model.LJYQXH = dr["LJYQXH"].ToString();
            }

            //if (dr["KZRQ"] != null && dr["KZRQ"].ToString() != "")
            //{
            //	model.KZRQ = Convert.ToDateTime(dr["KZRQ"]);
            //}

            if (dr["KZRQ"] != null && dr["KZRQ"].ToString() != "")
            {
                model.KZRQ = Convert.ToDateTime(dr["KZRQ"]);
                model.KZRQ_DG = Convert.ToDateTime(dr["KZRQ"]).ToString("yyyy-MM-dd");
            }
            else
            {
                model.KZRQ = null;
                model.KZRQ_DG = "";
            }

            if (dr["WZRQ"] != null && dr["WZRQ"].ToString() != "")
            {
                model.WZRQ = Convert.ToDateTime(dr["WZRQ"]);
                model.WZRQ_DG = Convert.ToDateTime(dr["WZRQ"]).ToString("yyyy-MM-dd");
            }
            else
            {
                model.WZRQ = null;
                model.WZRQ_DG = "";
            }

            if (dr["GJRQ"] != null && dr["GJRQ"].ToString() != "")
            {
                model.GJRQ = Convert.ToDateTime(dr["GJRQ"]);
                model.GJRQ_DG = Convert.ToDateTime(dr["GJRQ"]).ToString("yyyy-MM-dd");
            }
            else
            {
                model.GJRQ = null;
                model.GJRQ_DG = "";
            }

            if (dr["WJRQ"] != null && dr["WJRQ"].ToString() != "")
            {
                model.WJRQ = Convert.ToDateTime(dr["WJRQ"]);
                model.WJRQ_DG = Convert.ToDateTime(dr["WJRQ"]).ToString("yyyy-MM-dd");
            }
            else
            {
                model.WJRQ = null;
                model.WJRQ_DG = "";
            }

            if (dr["ZYMDC"] != null && dr["ZYMDC"].ToString() != "")
            {
                model.ZYMDC = dr["ZYMDC"].ToString();
            }

            if (dr["WZCW"] != null && dr["WZCW"].ToString() != "")
            {
                model.WZCW = dr["WZCW"].ToString();
            }

            if (dr["WJFF"] != null && dr["WJFF"].ToString() != "")
            {
                model.WJFF = dr["WJFF"].ToString();
            }

            if (dr["DYNZDJS"] != null && dr["DYNZDJS"].ToString() != "")
            {
                model.DYNZDJS = Convert.ToDecimal(dr["DYNZDJS"]);
            }

            if (dr["DENZDJS"] != null && dr["DENZDJS"].ToString() != "")
            {
                model.DENZDJS = Convert.ToDecimal(dr["DENZDJS"]);
            }

            if (dr["SFJJYQXS"] != null && dr["SFJJYQXS"].ToString() != "")
            {
                model.SFJJYQXS = dr["SFJJYQXS"].ToString();
            }

            if (dr["SFQX"] != null && dr["SFQX"].ToString() != "")
            {
                model.SFQX = dr["SFQX"].ToString();
            }

            if (dr["SFJSYQC"] != null && dr["SFJSYQC"].ToString() != "")
            {
                model.SFJSYQC = dr["SFJSYQC"].ToString();
            }

            if (dr["SFCXGCFZ"] != null && dr["SFCXGCFZ"].ToString() != "")
            {
                model.SFCXGCFZ = dr["SFCXGCFZ"].ToString();
            }

            if (dr["CXGCFZLX"] != null && dr["CXGCFZLX"].ToString() != "")
            {
                model.CXGCFZLX = dr["CXGCFZLX"].ToString();
            }
            if (dr["GCFZCLSJ"] != null && dr["GCFZCLSJ"].ToString() != "")
            {
                model.GCFZCLSJ = Convert.ToDateTime(dr["GCFZCLSJ"]);
                model.GCFZCLSJ_DG = Convert.ToDateTime(dr["GCFZCLSJ"]).ToString("yyyy-MM-dd");
            }
            else
            {
                model.GCFZCLSJ = null;
                model.GCFZCLSJ_DG = "";
            }
            if (dr["SFXYCTG"] != null && dr["SFXYCTG"].ToString() != "")
            {
                model.SFXYCTG = dr["SFXYCTG"].ToString();
            }
            if (dr["SJWZYZ"] != null && dr["SJWZYZ"].ToString() != "")
            {
                model.SJWZYZ = dr["SJWZYZ"].ToString();
            }
            if (dr["WZYJ"] != null && dr["WZYJ"].ToString() != "")
            {
                model.WZYJ = dr["WZYJ"].ToString();
            }

            if (dr["SFBF"] != null && dr["SFBF"].ToString() != "")
            {
                model.SFBF = dr["SFBF"].ToString();
            }

            if (dr["BFLX"] != null && dr["BFLX"].ToString() != "")
            {
                model.BFLX = dr["BFLX"].ToString();
            }

            if (dr["STARSTART"] != null && dr["STARSTART"].ToString() != "")
            {
                model.STARSTART = Convert.ToDateTime(dr["STARSTART"]);
                model.STARSTART_DG = Convert.ToDateTime(dr["STARSTART"]).ToString("yyyy-MM-dd");
            }
            else
            {
                model.STARSTART = null;
                model.STARSTART_DG = "";
            }
            if (dr["STAREND"] != null && dr["STAREND"].ToString() != "")
            {
                model.STAREND = Convert.ToDateTime(dr["STAREND"]);
                model.STAREND_DG = Convert.ToDateTime(dr["STAREND"]).ToString("yyyy-MM-dd");
            }
            else
            {
                model.STAREND = null;
                model.STAREND_DG = "";
            }

            if (dr["ZTLX"] != null && dr["ZTLX"].ToString() != "")
            {
                model.ZTLX = dr["ZTLX"].ToString();

            }

            //if (dr["ZTSJ1"] != null && dr["ZTSJ1"].ToString ( ) != "")
            //{
            //    model.ZTSJ1 = Convert.ToDateTime ( dr["ZTSJ1"] );
            //}
            //if (dr["ZTJSSJ1"] != null && dr["ZTJSSJ1"].ToString ( ) != "")
            //{
            //    model.ZTJSSJ1 = Convert.ToDateTime ( dr["CZKSLJSJ2"] );
            //}
            //if (dr["ZTSJ2"] != null && dr["ZTSJ2"].ToString ( ) != "")
            //{
            //    model.ZTSJ2 = Convert.ToDateTime ( dr["ZTSJ2"] );
            //}

            //if (dr["ZTJSSJ2"] != null && dr["ZTJSSJ2"].ToString ( ) != "")
            //{
            //    model.ZTJSSJ2 = Convert.ToDateTime ( dr["ZTJSSJ2"] );
            //}
            //if (dr["ZTSJ3"] != null && dr["ZTSJ3"].ToString ( ) != "")
            //{
            //    model.ZTSJ3 = Convert.ToDateTime ( dr["ZTSJ3"] );
            //}
            if (dr["DRJS"] != null && dr["DRJS"].ToString() != "")
            {
                model.DRJS = Convert.ToDecimal(dr["DRJS"]);
            }
            if (dr["SGZT"] != null && dr["SGZT"].ToString() != "")
            {
                model.SGZT = dr["SGZT"].ToString();
            }

            if (dr["BZ"] != null && dr["BZ"].ToString() != "")
            {
                model.BZ = dr["BZ"].ToString();
            }
            //if (dr["CZKSSJ"] != null && dr["CZKSSJ"].ToString() != "")
            //{
            //    model.CZKSSJ = Convert.ToDateTime(dr["CZKSSJ"]);
            //}
            //else
            //{
            //    model.CZKSSJ = null;
            //}
            //if (dr["CZJSSJ"] != null && dr["CZJSSJ"].ToString() != "")
            //{
            //    model.CZJSSJ = Convert.ToDateTime(dr["CZJSSJ"]);
            //}
            //else
            //{
            //    model.CZJSSJ = null;
            //}
            //if (dr["TJR"] != null && dr["TJR"].ToString ( ) != "")
            //{
            //    model.TJR = dr["TJR"].ToString ( );
            //}
            //if (dr["ID"] != null && dr["ID"].ToString ( ) != "")
            //{
            //    model.ID = dr["ID"].ToString ( );
            //}
            return model;

        }

        public LQ_GCJD GCJDModelByJH(DataRow dr)
        {
            LQ_GCJD model = new LQ_GCJD();

            if (dr["ZJH"] != null && dr["ZJH"].ToString() != "")
            {
                model.ZJH = dr["ZJH"].ToString();
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

            if (dr["LJXL"] != null && dr["LJXL"].ToString() != "")
            {
                model.LJXL = dr["LJXL"].ToString();
            }

            //if (dr["DZLJKSJS"] != null && dr["DZLJKSJS"].ToString() != "")
            //{
            //	model.DZLJKSJS = Convert.ToDecimal(dr["DZLJKSJS"]);
            //}

            //if (dr["DZLJKSSJ"] != null && dr["DZLJKSSJ"].ToString() != "")
            //{
            //	model.DZLJKSSJ = Convert.ToDateTime(dr["DZLJKSSJ"]);
            //}

            //if (dr["YXLJKSJS"] != null && dr["YXLJKSJS"].ToString() != "")
            //{
            //	model.YXLJKSJS = Convert.ToDecimal(dr["YXLJKSJS"]);
            //}

            //if (dr["YXLJKSSJ"] != null && dr["YXLJKSSJ"].ToString() != "")
            //{
            //	model.YXLJKSSJ = Convert.ToDateTime(dr["YXLJKSSJ"]);
            //}

            //if (dr["QCLJKSJS"] != null && dr["QCLJKSJS"].ToString() != "")
            //{
            //	model.QCLJKSJS = Convert.ToDecimal(dr["QCLJKSJS"]);
            //}

            //if (dr["QCLJKSSJ"] != null && dr["QCLJKSSJ"].ToString() != "")
            //{
            //	model.QCLJKSSJ = Convert.ToDateTime(dr["QCLJKSSJ"]);
            //}

            //if (dr["ZHLJKSJS"] != null && dr["ZHLJKSJS"].ToString() != "")
            //{
            //	model.ZHLJKSJS = Convert.ToDecimal(dr["ZHLJKSJS"]);
            //}

            //if (dr["ZHLJKSSJ"] != null && dr["ZHLJKSSJ"].ToString() != "")
            //{
            //	model.ZHLJKSSJ = Convert.ToDateTime(dr["ZHLJKSSJ"]);
            //}

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

            if (dr["SGDW"] != null && dr["SGDW"].ToString() != "")
            {
                model.SGDW = dr["SGDW"].ToString();
            }

            if (dr["SGDH"] != null && dr["SGDH"].ToString() != "")
            {
                model.SGDH = dr["SGDH"].ToString();
            }

            if (dr["LJFGS"] != null && dr["LJFGS"].ToString() != "")
            {
                model.LJFGS = dr["LJFGS"].ToString();
            }

            if (dr["LJDH"] != null && dr["LJDH"].ToString() != "")
            {
                model.LJDH = dr["LJDH"].ToString();
            }

            if (dr["LJYQXH"] != null && dr["LJYQXH"].ToString() != "")
            {
                model.LJYQXH = dr["LJYQXH"].ToString();
            }
            if (dr["STARSTART"] != null && dr["STARSTART"].ToString() != "")
            {
                model.STARSTART = Convert.ToDateTime(dr["STARSTART"]);
                model.STARSTART_DG = Convert.ToDateTime(dr["STARSTART"]).ToString("yyyy-MM-dd");
            }
            else
            {
                model.STARSTART = null;
                model.STARSTART_DG = "";
            }
            if (dr["STAREND"] != null && dr["STAREND"].ToString() != "")
            {
                model.STAREND = Convert.ToDateTime(dr["STAREND"]);
                model.STAREND_DG = Convert.ToDateTime(dr["STAREND"]).ToString("yyyy-MM-dd");
            }
            else
            {
                model.STAREND = null;
                model.STAREND_DG = "";
            }


            return model;

        }
        #endregion
        #region 翻页
        public DataSet GCJDInfo(string JHWhere, string strWhere, string dtName1, string dtName61)
        {
            string strSql = string.Format(@"
SELECT * FROM(
 SELECT  ROW_NUMBER () OVER (ORDER BY SC3, JH DESC, REPORT_TYPE) TROW,
               T1.*
  FROM (SELECT A.*,
               A61.DRJS,
               A61.SGZT
          FROM " + dtName1 + @"  A
               LEFT OUTER JOIN " + dtName61 + @" A61
                   ON A.JH = A61.JH AND HBRQ = SYSDATE ) T1
              WHERE 1=1  {0} )
 WHERE 1 = 1 {1} ", strWhere, JHWhere);

            return DbHelperOra.Query(strSql);
        }
        #endregion
        /// <summary>
        /// 根据井号获取表单数据
        /// </summary>
        /// <param name="JH"></param>
        /// <returns></returns>
        public DataSet GCJDInfoByJH(string JH)
        {
            string strSql = string.Format(@"SELECT L.ZJH,L.SC3,L.QK,L.SC2,L.REPORT_TYPE,L.JX,L.JH,L.LJXL,L.SJJS,L.JSSJJS,D.WZJS,D.SJZZB,D.SJHZB,D.DMHB,D.BXG,L.SGDW,L.SGDH,L.LJFGS,L.LJDH,L.LJYQXH,L.STARSTART,L.STAREND FROM LQ_LJXM L
					LEFT JOIN LQ_DJSJ D ON L.ZJH=D.ZJH
					WHERE L.JH='{0}'", JH);
            return DbHelperOra.Query(strSql);
        }
    }
}
