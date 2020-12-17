using LJZY.DBUtility;
using LJZY.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using LJZY.COMMON;
using System.Collections;

namespace LJZY.DAO.LQGL
{
    public class LQ_LJXMDAO
    {
        #region 录井项目模块

        public DataSet LJXM_Check(string strWhere, string dtName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ROW_NUMBER() OVER(ORDER BY SC3, JH DESC,REPORT_TYPE) AS TROW,T.* FROM " + dtName + " T");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1 " + strWhere);
            }

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 录井项目修改
        /// </summary>
        /// <param name="LJXM"></param>
        /// <returns></returns>
        public bool Update(LQ_LJXM LJXM, string dtName)
        {
            //Hashtable ht = new Hashtable ( );
            string sqlStr = string.Format(@"
Update " + dtName + @"
Set 
SC3=:SC3, 
SC2=:SC2, 
QK=:QK, 
REPORT_TYPE=:REPORT_TYPE, 
LJXL=:LJXL, 
SJJS=:SJJS, 
JSSJJS=:JSSJJS, 
SCFL=:SCFL, 
GJ=:GJ, 
SC1=:SC1, 
DZJDXM=:DZJDXM, 
DZJDZJH=:DZJDZJH,
DZJDSSGS=:DZJDSSGS, 
ZJJDXM=:ZJJDXM, 
ZJJDZJH=:ZJJDZJH, 
ZJJDSSGS=:ZJJDSSGS, 
LJFGS=:LJFGS, 
LJDWZZ=:LJDWZZ, 
LJDH=:LJDH, 
LJYQXH=:LJYQXH, 
YQZZ=:YQZZ, 
DWZBH=:DWZBH, 
DZS=:DZS, 
STARAZR=:STARAZR, 
STARCCR=:STARCCR, 
SGDW=:SGDW, 
SGDH=:SGDH,
BQJL=:BQJL,       
DQZT=:DQZT, 
CHOUXIYOU=:CHOUXIYOU, 
HXJW=:HXJW, 
HXJDH=:HXJDH, 
JDDT=:JDDT, 
LSDW=:LSDW, 
XMBJWXX=:XMBJWXX, 
PGZDTS=:PGZDTS,         
XQXMB=:XQXMB,       
JX=:JX,
STAREND =:STAREND,
STARSTART =:STARSTART,
YJBASJ =:YJBASJ,
SJBASJ =:SJBASJ,
HQSJ =:HQSJ 
WHERE JH=:JH  ");

            OracleParameter[] parameter = {
                                            new OracleParameter(":SC3",OracleDbType.Varchar2,30),
                                            new OracleParameter(":SC2",OracleDbType.Varchar2,30),
                                            new OracleParameter(":QK",OracleDbType.Varchar2,10),
                                            new OracleParameter(":REPORT_TYPE",OracleDbType.Varchar2,16),
                                            new OracleParameter(":LJXL",OracleDbType.Varchar2,10),
                                            new OracleParameter(":SJJS",OracleDbType.Decimal),
                                            new OracleParameter(":JSSJJS",OracleDbType.Decimal),
                                            new OracleParameter(":SCFL",OracleDbType.Varchar2,30),
                                            new OracleParameter(":GJ",OracleDbType.Varchar2,30),
                                            new OracleParameter(":SC1",OracleDbType.Varchar2,30),
                                            new OracleParameter(":DZJDXM",OracleDbType.Varchar2,50),
                                            new OracleParameter(":DZJDZJH",OracleDbType.Varchar2,50),
                                            new OracleParameter(":DZJDSSGS",OracleDbType.Varchar2,50),
                                            new OracleParameter(":ZJJDXM",OracleDbType.Varchar2,50),
                                            new OracleParameter(":ZJJDZJH",OracleDbType.Varchar2,50),
                                            new OracleParameter(":ZJJDSSGS",OracleDbType.Varchar2,50),
                                            new OracleParameter(":LJFGS",OracleDbType.Varchar2,50),
                                            new OracleParameter(":LJDWZZ",OracleDbType.Varchar2,30),
                                            new OracleParameter(":LJDH",OracleDbType.Varchar2,50),
                                            new OracleParameter(":LJYQXH",OracleDbType.Varchar2,20),
                                            new OracleParameter(":YQZZ",OracleDbType.Varchar2,30),
                                            new OracleParameter(":DWZBH",OracleDbType.Varchar2,50),
                                            new OracleParameter(":DZS",OracleDbType.Varchar2,50),
                                            new OracleParameter(":STARAZR",OracleDbType.Varchar2,50),
                                            new OracleParameter(":STARCCR",OracleDbType.Varchar2,50),
                                            new OracleParameter(":SGDW",OracleDbType.Varchar2,50),
                                            new OracleParameter(":SGDH",OracleDbType.Varchar2,50),
                                            new OracleParameter(":BQJL",OracleDbType.Decimal),
                                            new OracleParameter(":DQZT",OracleDbType.Varchar2,50),
                                            new OracleParameter(":CHOUXIYOU",OracleDbType.Varchar2,50),
                                            new OracleParameter(":HXJW",OracleDbType.Varchar2,50),
                                            new OracleParameter(":HXJDH",OracleDbType.Varchar2,50),
                                            new OracleParameter(":JDDT",OracleDbType.Varchar2,50),
                                            new OracleParameter(":LSDW",OracleDbType.Varchar2,50),
                                            new OracleParameter(":XMBJWXX",OracleDbType.Varchar2,50),
                                            new OracleParameter(":PGZDTS",OracleDbType.Varchar2,50),
                                            new OracleParameter(":XQXMB",OracleDbType.Varchar2,50),
                                            new OracleParameter(":JX",OracleDbType.Varchar2,50),
                                            new OracleParameter(":STARSTART",OracleDbType.Date),
                                            new OracleParameter(":STAREND",OracleDbType.Date),
                                            new OracleParameter(":YJBASJ",OracleDbType.Date),
                                            new OracleParameter(":SJBASJ",OracleDbType.Date),
                                            new OracleParameter(":HQSJ",OracleDbType.Date),
                                            new OracleParameter(":JH",OracleDbType.Varchar2,50)

                                        };

            parameter[0].Value = LJXM.SC3;
            parameter[1].Value = LJXM.SC2;
            parameter[2].Value = LJXM.QK;
            parameter[3].Value = LJXM.REPORT_TYPE;
            parameter[4].Value = LJXM.LJXL;
            parameter[5].Value = LJXM.SJJS;
            parameter[6].Value = LJXM.JSSJJS;
            parameter[7].Value = LJXM.SCFL;
            parameter[8].Value = LJXM.GJ;
            parameter[9].Value = LJXM.SC1;
            parameter[10].Value = LJXM.DZJDXM;
            parameter[11].Value = LJXM.DZJDZJH;
            parameter[12].Value = LJXM.DZJDSSGS;
            parameter[13].Value = LJXM.ZJJDXM;
            parameter[14].Value = LJXM.ZJJDZJH;
            parameter[15].Value = LJXM.ZJJDSSGS;
            parameter[16].Value = LJXM.LJFGS;
            parameter[17].Value = LJXM.LJDWZZ;
            parameter[18].Value = LJXM.LJDH;
            parameter[19].Value = LJXM.LJYQXH;
            parameter[20].Value = LJXM.YQZZ;
            parameter[21].Value = LJXM.DWZBH;
            parameter[22].Value = LJXM.DZS;
            parameter[23].Value = LJXM.STARAZR;
            parameter[24].Value = LJXM.STARCCR;
            parameter[25].Value = LJXM.SGDW;
            parameter[26].Value = LJXM.SGDH;
            parameter[27].Value = LJXM.BQJL;
            parameter[28].Value = LJXM.DQZT;
            parameter[29].Value = LJXM.CHOUXIYOU;
            parameter[30].Value = LJXM.HXJW;
            parameter[31].Value = LJXM.HXJDH;
            parameter[32].Value = LJXM.JDDT;
            parameter[33].Value = LJXM.LSDW;
            parameter[34].Value = LJXM.XMBJWXX;
            parameter[35].Value = LJXM.PGZDTS;
            parameter[36].Value = LJXM.XQXMB;
            parameter[37].Value = LJXM.JX;
            parameter[38].Value = LJXM.STARSTART;
            parameter[39].Value = LJXM.STAREND;
            parameter[40].Value = LJXM.YJBASJ;
            parameter[41].Value = LJXM.SJBASJ;
            parameter[42].Value = LJXM.HQSJ;
            parameter[43].Value = LJXM.JH;
            // ht.Add ( sqlStr, parameter );
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

        public bool importUpdate(List<LQ_LJXM> list, string dtName)
        {
            Hashtable arrList = new Hashtable();
            for (int i = 0; i < list.Count; i++)
            {
                string sqlStr = string.Format(@"
Update " + dtName + @"
Set 
SC3=:SC3{0}, 
SC2=:SC2{0}, 
QK=:QK{0}, 
REPORT_TYPE=:REPORT_TYPE{0}, 
LJXL=:LJXL{0}, 
SJJS=:SJJS{0}, 
JSSJJS=:JSSJJS{0}, 
SCFL=:SCFL{0}, 
GJ=:GJ{0}, 
SC1=:SC1{0}, 
DZJDXM=:DZJDXM{0}, 
DZJDZJH=:DZJDZJH{0},
DZJDSSGS=:DZJDSSGS{0}, 
ZJJDXM=:ZJJDXM{0}, 
ZJJDZJH=:ZJJDZJH{0}, 
ZJJDSSGS=:ZJJDSSGS{0}, 
LJFGS=:LJFGS{0}, 
LJDWZZ=:LJDWZZ{0}, 
LJDH=:LJDH{0}, 
LJYQXH=:LJYQXH{0}, 
YQZZ=:YQZZ{0}, 
DWZBH=:DWZBH{0}, 
DZS=:DZS{0}, 
STARAZR=:STARAZR{0}, 
STARCCR=:STARCCR{0}, 
SGDW=:SGDW{0}, 
SGDH=:SGDH{0},
BQJL=:BQJL{0},       
DQZT=:DQZT{0}, 
CHOUXIYOU=:CHOUXIYOU{0}, 
HXJW=:HXJW{0}, 
HXJDH=:HXJDH{0}, 
JDDT=:JDDT{0}, 
LSDW=:LSDW{0}, 
XMBJWXX=:XMBJWXX{0}, 
PGZDTS=:PGZDTS{0},         
XQXMB=:XQXMB{0},       
JX=:JX{0},
STAREND =:STAREND{0},
STARSTART =:STARSTART{0},
YJBASJ =:YJBASJ{0},
SJBASJ =:SJBASJ{0},
HQSJ =:HQSJ{0} 
WHERE JH=:JH{0}  ", i);

                OracleParameter[] parameter = {
                                            new OracleParameter(string.Format(":SC3{0}",i),OracleDbType.Varchar2,30),
                                            new OracleParameter(string.Format(":SC2{0}",i),OracleDbType.Varchar2,30),
                                            new OracleParameter(string.Format(":QK{0}",i),OracleDbType.Varchar2,10),
                                            new OracleParameter(string.Format(":REPORT_TYPE{0}",i),OracleDbType.Varchar2,16),
                                            new OracleParameter(string.Format(":LJXL{0}",i),OracleDbType.Varchar2,10),
                                            new OracleParameter(string.Format(":SJJS{0}",i),OracleDbType.Decimal),
                                            new OracleParameter(string.Format(":JSSJJS{0}",i),OracleDbType.Decimal),
                                            new OracleParameter(string.Format(":SCFL{0}",i),OracleDbType.Varchar2,30),
                                            new OracleParameter(string.Format(":GJ{0}",i),OracleDbType.Varchar2,30),
                                            new OracleParameter(string.Format(":SC1{0}",i),OracleDbType.Varchar2,30),
                                            new OracleParameter(string.Format(":DZJDXM{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":DZJDZJH{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":DZJDSSGS{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":ZJJDXM{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":ZJJDZJH{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":ZJJDSSGS{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":LJFGS{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":LJDWZZ{0}",i),OracleDbType.Varchar2,30),
                                            new OracleParameter(string.Format(":LJDH{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":LJYQXH{0}",i),OracleDbType.Varchar2,20),
                                            new OracleParameter(string.Format(":YQZZ{0}",i),OracleDbType.Varchar2,30),
                                            new OracleParameter(string.Format(":DWZBH{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":DZS{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":STARAZR{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":STARCCR{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":SGDW{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":SGDH{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":BQJL{0}",i),OracleDbType.Decimal),
                                            new OracleParameter(string.Format(":DQZT{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":CHOUXIYOU{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":HXJW{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":HXJDH{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":JDDT{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":LSDW{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":XMBJWXX{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":PGZDTS{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":XQXMB{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":JX{0}",i),OracleDbType.Varchar2,50),
                                            new OracleParameter(string.Format(":STARSTART{0}",i),OracleDbType.Date),
                                            new OracleParameter(string.Format(":STAREND{0}",i),OracleDbType.Date),
                                            new OracleParameter(string.Format(":YJBASJ{0}",i),OracleDbType.Date),
                                            new OracleParameter(string.Format(":SJBASJ{0}",i),OracleDbType.Date),
                                            new OracleParameter(string.Format(":HQSJ{0}",i),OracleDbType.Date),
                                            new OracleParameter(string.Format(":JH{0}",i),OracleDbType.Varchar2,50)
                                        };

                parameter[0].Value = list[i].SC3;
                parameter[1].Value = list[i].SC2;
                parameter[2].Value = list[i].QK;
                parameter[3].Value = list[i].REPORT_TYPE;
                parameter[4].Value = list[i].LJXL;
                parameter[5].Value = list[i].SJJS;
                parameter[6].Value = list[i].JSSJJS;
                parameter[7].Value = list[i].SCFL;
                parameter[8].Value = list[i].GJ;
                parameter[9].Value = list[i].SC1;
                parameter[10].Value = list[i].DZJDXM;
                parameter[11].Value = list[i].DZJDZJH;
                parameter[12].Value = list[i].DZJDSSGS;
                parameter[13].Value = list[i].ZJJDXM;
                parameter[14].Value = list[i].ZJJDZJH;
                parameter[15].Value = list[i].ZJJDSSGS;
                parameter[16].Value = list[i].LJFGS;
                parameter[17].Value = list[i].LJDWZZ;
                parameter[18].Value = list[i].LJDH;
                parameter[19].Value = list[i].LJYQXH;
                parameter[20].Value = list[i].YQZZ;
                parameter[21].Value = list[i].DWZBH;
                parameter[22].Value = list[i].DZS;
                parameter[23].Value = list[i].STARAZR;
                parameter[24].Value = list[i].STARCCR;
                parameter[25].Value = list[i].SGDW;
                parameter[26].Value = list[i].SGDH;
                parameter[27].Value = list[i].BQJL;
                parameter[28].Value = list[i].DQZT;
                parameter[29].Value = list[i].CHOUXIYOU;
                parameter[30].Value = list[i].HXJW;
                parameter[31].Value = list[i].HXJDH;
                parameter[32].Value = list[i].JDDT;
                parameter[33].Value = list[i].LSDW;
                parameter[34].Value = list[i].XMBJWXX;
                parameter[35].Value = list[i].PGZDTS;
                parameter[36].Value = list[i].XQXMB;
                parameter[37].Value = list[i].JX;
                parameter[38].Value = list[i].STARSTART;
                parameter[39].Value = list[i].STAREND;
                parameter[40].Value = list[i].YJBASJ;
                parameter[41].Value = list[i].SJBASJ;
                parameter[42].Value = list[i].HQSJ;
                parameter[43].Value = list[i].JH;
                arrList.Add(sqlStr, parameter);

            
            }
            return DbHelperOra.ExecuteSqlTran(arrList);
        }

        /// <summary>
        /// 录井项目删除
        /// </summary>
        /// <param name="JH"></param>
        /// <returns></returns>
        public bool Del(string JH, string JX, string dtName1)
        {
            ArrayList list = new ArrayList();
            string Sql = string.Format(@"DELETE FROM  " + dtName1 + "   WHERE JH='{0}' ", JH);
            list.Add(Sql);
            string Sql1 = string.Format(@"DELETE FROM LQ_RYFP WHERE JH='{0}' ", JH);
            list.Add(Sql1);
            string Sql2 = string.Format(@"DELETE FROM LQ_SBFP WHERE JH='{0}' ", JH);
            list.Add(Sql2);
            string Sql3 = string.Format(@"DELETE FROM LQ_FWFP WHERE JH='{0}' ", JH);
            list.Add(Sql3);
            return DbHelperOra.ExecuteSqlTrans(list);
        }

        /// <summary>
        /// 录井项目信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet LJXMInfo(string typeWhere, string strWhere, string dtName1, string dtName61)
        {
            string strSql = string.Format(@"
SELECT * FROM (SELECT ROW_NUMBER () OVER (ORDER BY SC3, JH DESC, REPORT_TYPE) TROW, T1.*
          FROM (SELECT A.*, A61.DRJS, A61.SGZT
                  FROM " + dtName1 + @"  A
                       LEFT OUTER JOIN " + dtName61 + @" A61
                           ON A.JH = A61.JH AND HBRQ = SYSDATE ) T1
                 WHERE 1 = 1 {0})
                  WHERE 1 = 1 {1}", typeWhere, strWhere);
            return DbHelperOra.Query(strSql);
        }

        /// <summary>
        /// 根据条件获取录井项目分页数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="filedOrder"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public DataSet LJXMInfo_strWhere(string strWhere, int pageSize, int pageIndex, string filedOrder, out int recordCount, string dtName1, string dtName61)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT ROW_NUMBER () OVER (ORDER BY SC3, JH DESC,REPORT_TYPE) TROW, DT.* FROM (SELECT A.*,A61.DRJS,A61.SGZT FROM " + dtName1 + " A ");
            strSql.Append(" LEFT OUTER JOIN " + dtName61 + " A61 ON A.JH=A61.JH AND A61.HBRQ=SYSDATE )DT ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("WHERE 1=1" + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperOra.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperOra.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        public DataSet LJXMInfo_strWhere(string strWhere, string dtName1, string dtName61)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT ROW_NUMBER () OVER (ORDER BY SC3, JH DESC,REPORT_TYPE) TROW, DT.* FROM (SELECT A.*,A61.DRJS,A61.SGZT FROM " + dtName1 + " A ");
            strSql.Append(" LEFT OUTER JOIN " + dtName61 + " A61 ON A.JH=A61.JH AND A61.HBRQ=SYSDATE )DT ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("WHERE 1=1" + strWhere);
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
            strSql.Append(" SELECT COUNT(*) FROM (SELECT ROW_NUMBER () OVER (ORDER BY SC3, JH DESC,REPORT_TYPE) TROW, DT.* FROM (SELECT A.*,A61.DRJS,A61.SGZT FROM " + dtName1 + " A ");
            strSql.Append(" LEFT OUTER JOIN " + dtName61 + " A61 ON A.JH=A61.JH AND HBRQ=SYSDATE ) DT) ");
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
        /// 当日数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="dtName61"></param>
        /// <returns></returns>
        public DataSet DRInfo(string strWhere, string dtName61)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT ROW_NUMBER() OVER(ORDER BY T.HBRQ DESC,T.JH ) AS TROW,T.DRJS,T.SGZT FROM " + dtName61 + " T ");
            if (strWhere.Trim() != "")
            {
                strSql.Append("WHERE 1=1" + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据条件获取地质师
        /// </summary>
        /// <param name="JH">井号</param>
        /// <param name="GW">岗位</param>
        /// <returns></returns>
        public string DZS_List(string JH, string GW)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT XM FROM LQ_RYSJK K ");
            strSql.Append(" LEFT JOIN LQ_RYFP P ON K.RYBH=P.RYBH ");
            strSql.Append(" WHERE P.JH='" + JH + "' AND GW='" + GW + "' ");

            object result = DbHelperOra.GetSingle(strSql.ToString());
            if (result != null)
            {
                return result.ToString();
            }
            return "";
        }

        /// <summary>
        /// 录井项目实体类
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public LQ_LJXM LJXMModel(DataRow dr)
        {
            LQ_LJXM model = new LQ_LJXM();
            if (dr["TROW"] != null && dr["TROW"].ToString() != "")
            {
                model.TROW = Convert.ToInt32(dr["TROW"]);
            }
            if (dr["JH"] != null && dr["JH"].ToString() != "")
            {
                model.JH = dr["JH"].ToString();
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

            if (dr["ZJH"] != null && dr["ZJH"].ToString() != "")
            {
                model.ZJH = dr["ZJH"].ToString();
            }

            if (dr["LJXL"] != null && dr["LJXL"].ToString() != "")
            {
                model.LJXL = dr["LJXL"].ToString();
            }

            if (dr["SJJS"] != null && dr["SJJS"].ToString() != "")
            {
                model.SJJS = Convert.ToDecimal(dr["SJJS"]);
            }

            if (dr["JSSJJS"] != null && dr["JSSJJS"].ToString() != "")
            {
                model.JSSJJS = Convert.ToDecimal(dr["JSSJJS"]);
            }

            if (dr["SCFL"] != null && dr["SCFL"].ToString() != "")
            {
                model.SCFL = dr["SCFL"].ToString();
            }

            if (dr["GJ"] != null && dr["GJ"].ToString() != "")
            {
                model.GJ = dr["GJ"].ToString();
            }

            if (dr["SC1"] != null && dr["SC1"].ToString() != "")
            {
                model.SC1 = dr["SC1"].ToString();
            }

            if (dr["DZJDXM"] != null && dr["DZJDXM"].ToString() != "")
            {
                model.DZJDXM = dr["DZJDXM"].ToString();
            }

            if (dr["DZJDZJH"] != null && dr["DZJDZJH"].ToString() != "")
            {
                model.DZJDZJH = dr["DZJDZJH"].ToString();
            }

            if (dr["DZJDSSGS"] != null && dr["DZJDSSGS"].ToString() != "")
            {
                model.DZJDSSGS = dr["DZJDSSGS"].ToString();
            }

            if (dr["ZJJDXM"] != null && dr["ZJJDXM"].ToString() != "")
            {
                model.ZJJDXM = dr["ZJJDXM"].ToString();
            }

            if (dr["ZJJDZJH"] != null && dr["ZJJDZJH"].ToString() != "")
            {
                model.ZJJDZJH = dr["ZJJDZJH"].ToString();
            }

            if (dr["ZJJDSSGS"] != null && dr["ZJJDSSGS"].ToString() != "")
            {
                model.ZJJDSSGS = dr["ZJJDSSGS"].ToString();
            }

            if (dr["LJFGS"] != null && dr["LJFGS"].ToString() != "")
            {
                model.LJFGS = dr["LJFGS"].ToString();
            }

            if (dr["LJDWZZ"] != null && dr["LJDWZZ"].ToString() != "")
            {
                model.LJDWZZ = dr["LJDWZZ"].ToString();
            }

            if (dr["LJDH"] != null && dr["LJDH"].ToString() != "")
            {
                model.LJDH = dr["LJDH"].ToString();
            }

            if (dr["LJYQXH"] != null && dr["LJYQXH"].ToString() != "")
            {
                model.LJYQXH = dr["LJYQXH"].ToString();
            }

            if (dr["YQZZ"] != null && dr["YQZZ"].ToString() != "")
            {
                model.YQZZ = dr["YQZZ"].ToString();
            }

            if (dr["DWZBH"] != null && dr["DWZBH"].ToString() != "")
            {
                model.DWZBH = dr["DWZBH"].ToString();
            }

            //if (dr["DZS"] != null && dr["DZS"].ToString() != "")
            //{
            //    model.DZS = DZS_List(model.JH, "录井地质师");
            //    //model.DZS = dr["DZS"].ToString();
            //}

            if (dr["STARSTART"] != null && dr["STARSTART"].ToString() != "")
            {
                model.STARSTART = Convert.ToDateTime(dr["STARSTART"]);
                model.STARSTART_DG = Convert.ToDateTime(dr["STARSTART"]).ToString("yyyy-MM-dd");
            }
            else
            {
                model.STARSTART_DG = "";
            }

            if (dr["STARAZR"] != null && dr["STARAZR"].ToString() != "")
            {
                model.STARAZR = dr["STARAZR"].ToString();
            }

            if (dr["STAREND"] != null && dr["STAREND"].ToString() != "")
            {
                model.STAREND = Convert.ToDateTime(dr["STAREND"]);
                model.STAREND_DG = Convert.ToDateTime(dr["STAREND"]).ToString("yyyy-MM-dd");
            }
            else
            {
                model.STAREND_DG = "";
            }

            if (dr["STARCCR"] != null && dr["STARCCR"].ToString() != "")
            {
                model.STARCCR = dr["STARCCR"].ToString();
            }
            if (dr["SGDW"] != null && dr["SGDW"].ToString() != "")
            {
                model.SGDW = dr["SGDW"].ToString();
            }
            if (dr["SGDH"] != null && dr["SGDH"].ToString() != "")
            {
                model.SGDH = dr["SGDH"].ToString();
            }
            if (dr["YJBASJ"] != null && dr["YJBASJ"].ToString() != "")
            {
                model.YJBASJ = Convert.ToDateTime(dr["YJBASJ"]);
                model.YJBASJ_DG = Convert.ToDateTime(dr["YJBASJ"]).ToString("yyyy-MM-dd");
            }
            else
            {
                model.YJBASJ_DG = "";
            }
            if (dr["SJBASJ"] != null && dr["SJBASJ"].ToString() != "")
            {
                model.SJBASJ = Convert.ToDateTime(dr["SJBASJ"]);
                model.SJBASJ_DG = Convert.ToDateTime(dr["SJBASJ"]).ToString("yyyy-MM-dd");
            }
            else
            {
                model.SJBASJ_DG = "";
            }
            if (dr["BQJL"] != null && dr["BQJL"].ToString() != "")
            {
                model.BQJL = Convert.ToDecimal(dr["BQJL"]);
            }
            if (dr["HQSJ"] != null && dr["HQSJ"].ToString() != "")
            {
                model.HQSJ = Convert.ToDateTime(dr["HQSJ"]);
                model.HQSJ_DG = Convert.ToDateTime(dr["HQSJ"]).ToString("yyyy-MM-dd");
            }
            else
            {
                model.HQSJ_DG = "";
            }
            if (dr["DQZT"] != null && dr["DQZT"].ToString() != "")
            {
                model.DQZT = dr["DQZT"].ToString();
            }
            if (dr["CHOUXIYOU"] != null && dr["CHOUXIYOU"].ToString() != "")
            {
                model.CHOUXIYOU = dr["CHOUXIYOU"].ToString();
            }
            if (dr["HXJW"] != null && dr["HXJW"].ToString() != "")
            {
                model.HXJW = dr["HXJW"].ToString();
            }
            if (dr["HXJDH"] != null && dr["HXJDH"].ToString() != "")
            {
                model.HXJDH = dr["HXJDH"].ToString();
            }
            if (dr["JDDT"] != null && dr["JDDT"].ToString() != "")
            {
                model.JDDT = dr["JDDT"].ToString();
            }
            if (dr["LSDW"] != null && dr["LSDW"].ToString() != "")
            {
                model.LSDW = dr["LSDW"].ToString();
            }
            if (dr["XMBJWXX"] != null && dr["XMBJWXX"].ToString() != "")
            {
                model.XMBJWXX = dr["XMBJWXX"].ToString();
            }
            if (dr["PGZDTS"] != null && dr["PGZDTS"].ToString() != "")
            {
                model.PGZDTS = dr["PGZDTS"].ToString();
            }
            if (dr["XQXMB"] != null && dr["XQXMB"].ToString() != "")
            {
                model.XQXMB = dr["XQXMB"].ToString();
            }
            if (dr["DRJS"] != null && dr["DRJS"].ToString() != "")
            {
                model.DRJS = Convert.ToDecimal(dr["DRJS"]);
            }
            if (dr["SGZT"] != null && dr["SGZT"].ToString() != "")
            {
                model.SGZT = dr["SGZT"].ToString();
            }
            model.DZS = DZS_List(model.JH, "录井地质师");
            return model;

        }
        #endregion

        #region 人员分配模块


        /// <summary>
        /// 人员编号信息
        /// </summary>
        /// <param name="RYBH"></param>
        /// <returns></returns>
        public DataSet RYInfo(string RYBH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT ROW_NUMBER() OVER(ORDER BY K.TJSJ DESC) AS TROW,K.*,P.JH FROM LQ_RYSJK K ");
            strSql.Append(" LEFT JOIN LQ_RYFP P ON K.RYBH=P.RYBH ");
            strSql.Append(" WHERE RYBH='" + RYBH + "' ");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取人员日志信息
        /// </summary>
        /// <param name="RYBH"></param>
        /// <returns></returns>
        public DataSet SJRZInfo()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@" 
SELECT *
  FROM LQ_SJRZ
 WHERE JSSJRQ IS NULL ");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 人员分配待派
        /// </summary>
        /// <param name="RYBH_List"></param>
        /// <param name="FP_List"></param>
        /// <returns></returns>
        public bool RYFPToDP(List<LQ_RYFP> FP_List, List<string> rzList)
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < rzList.Count; i++)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.AppendFormat(@" 
 UpDate LQ_SJRZ
 SET JSSJRQ=SYSDATE
 WHERE ID='{0}'", rzList[i].ToString());
                list.Add(strSql.ToString());
            }

            for (int i = 0; i < FP_List.Count; i++)
            {
                string Sql = string.Format(@"
UPDATE LQ_RYSJK
SET RYZT='待派'
WHERE RYBH='{0}'", FP_List[i].RYBH);

                list.Add(Sql);
            }


            for (int i = 0; i < FP_List.Count; i++)
            {
                string Sql1 = string.Format(@"DELETE FROM LQ_RYFP WHERE JH='{0}' AND RYBH='{1}'", FP_List[i].JH, FP_List[i].RYBH);
                list.Add(Sql1);
            }

            return DbHelperOra.ExecuteSqlTrans(list);
        }

        /// <summary>
        /// 人员分配在岗
        /// </summary>
        /// <param name="FP_List"></param>
        /// <returns></returns>
        public bool RYFPToZG(List<LQ_RYFP> FP_List, string JH, string dtName1)
        {
            ArrayList list = new ArrayList();
            string strSql = string.Format(@"
UPDATE LQ_SCPG
SET FPZT=2
WHERE JH='{0}'", JH);
            list.Add(strSql);
            string strSql1 = string.Format(@"
UPDATE " + dtName1 + @"
SET ISFINISH=1
WHERE JH='{0}'", JH);
            list.Add(strSql1);
            for (int i = 0; i < FP_List.Count; i++)
            {
                string Sql = string.Format(@"
UPDATE LQ_RYSJK
SET RYZT='在岗'
WHERE RYBH='{0}'", FP_List[i].RYBH);
                list.Add(Sql);
            }

            for (int i = 0; i < FP_List.Count; i++)
            {
                string Sql1 = string.Format(@"INSERT INTO LQ_RYFP(JH,RYBH,TJR,TJSJ)VALUES('{0}','{1}','{2}',SYSDATE)", FP_List[i].JH, FP_List[i].RYBH, FP_List[i].TJR);
                list.Add(Sql1);
            }

            for (int i = 0; i < FP_List.Count; i++)
            {
                string Sql1 = string.Format(@"INSERT INTO LQ_SJRZ(RYBH,XM,JH,KSSJRQ,TJSJ)VALUES('{0}','{1}','{2}',SYSDATE,SYSDATE)", FP_List[i].RYBH, FP_List[i].XM, FP_List[i].JH);
                list.Add(Sql1);
            }

            return DbHelperOra.ExecuteSqlTrans(list);
        }

        /// <summary>
        /// 人员待派列表
        /// </summary>
        /// <returns></returns>
        public DataSet RYXZ_List(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT ROW_NUMBER() OVER(ORDER BY K.TJSJ DESC) AS TROW,K.*,P.JH FROM LQ_RYSJK K ");
            strSql.Append(" LEFT JOIN LQ_RYFP P ON K.RYBH=P.RYBH ");
            strSql.Append(" WHERE RYZT='待派'  ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());

        }



        /// <summary>
        /// 人员在岗列表
        /// </summary>
        /// <param name="JH"></param>
        /// <returns></returns>
        public DataSet RYSJK_ZGList(string JH, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT ROW_NUMBER() OVER(ORDER BY K.TJSJ DESC) AS TROW,K.*,P.JH FROM LQ_RYSJK K ");
            strSql.Append(" LEFT JOIN LQ_RYFP P ON K.RYBH=P.RYBH ");
            strSql.Append(" WHERE P.JH='" + JH + "' ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 人员分配类类型
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public LQ_RYSJK RYSJKModel(DataRow dr)
        {
            LQ_RYSJK model = new LQ_RYSJK();
            if (dr["TROW"] != null && dr["TROW"].ToString() != "")
            {
                model.TROW = Convert.ToInt32(dr["TROW"]);
            }
            if (dr["ID"] != null && dr["ID"].ToString() != "")
            {
                model.ID = dr["ID"].ToString();
            }
            if (dr["XM"] != null && dr["XM"].ToString() != "")
            {
                model.XM = dr["XM"].ToString();
            }

            if (dr["RYBH"] != null && dr["RYBH"].ToString() != "")
            {
                model.RYBH = dr["RYBH"].ToString();
            }

            if (dr["GW"] != null && dr["GW"].ToString() != "")
            {
                model.GW = dr["GW"].ToString();
            }

            if (dr["LXDH"] != null && dr["LXDH"].ToString() != "")
            {
                model.LXDH = dr["LXDH"].ToString();
            }

            if (dr["RYZT"] != null && dr["RYZT"].ToString() != "")
            {
                model.RYZT = dr["RYZT"].ToString();
            }

            if (dr["JH"] != null && dr["JH"].ToString() != "")
            {
                model.JH = dr["JH"].ToString();
            }
            if (dr["XMB"] != null && dr["XMB"].ToString() != "")
            {
                model.XMB = dr["XMB"].ToString();
            }
            if (dr["BZ"] != null && dr["BZ"].ToString() != "")
            {
                model.BZ = dr["BZ"].ToString();
            }

            return model;

        }

        public LQ_SJRZ SJRZModel(DataRow dr)
        {
            LQ_SJRZ model = new LQ_SJRZ();

            if (dr["ID"] != null && dr["ID"].ToString() != "")
            {
                model.ID = dr["ID"].ToString();
            }

            if (dr["RYBH"] != null && dr["RYBH"].ToString() != "")
            {
                model.RYBH = dr["RYBH"].ToString();
            }

            if (dr["JH"] != null && dr["JH"].ToString() != "")
            {
                model.JH = dr["JH"].ToString();
            }
            return model;

        }
        #endregion

        #region 设备分配模块
        /// <summary>
        /// 闲置车辆
        /// </summary>
        /// <returns></returns>
        public DataSet CL_XZList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT ROW_NUMBER() OVER(ORDER BY K.SBMC ) AS TROW,K.ID AS SBID, K.SBMC,K.CCBH,SBZK,BZ,GGXH ,P.JH FROM LQ_SB_CL K ");
            strSql.Append(" LEFT JOIN LQ_SBFP P ON K.ID=P.SBID ");
            strSql.Append(" WHERE K.SBSZWZ='厂区' ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());

        }

        /// <summary>
        /// 闲置钻时仪
        /// </summary>
        /// <returns></returns>
        public DataSet ZSY_XZList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT ROW_NUMBER() OVER(ORDER BY K.SBMC) AS TROW,K.ID AS SBID, K.SBMC,K.CCBH,SBZK,BZ,GGXH ,P.JH FROM LQ_SB_ZSY K ");
            strSql.Append(" LEFT JOIN LQ_SBFP P ON K.ID=P.SBID ");
            strSql.Append(" WHERE K.SBSZWZ='厂区' ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());

        }

        /// <summary>
        /// 闲置工程参数仪设备表
        /// </summary>
        /// <returns></returns>
        public DataSet GCCSY_XZList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT ROW_NUMBER() OVER(ORDER BY K.SBMC) AS TROW,K.ID AS SBID, K.SBMC,K.CCBH,SBZK,BZ,GGXH ,P.JH FROM LQ_SB_GCCSY K ");
            strSql.Append(" LEFT JOIN LQ_SBFP P ON K.ID=P.SBID ");
            strSql.Append(" WHERE K.SBSZWZ='厂区' ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 闲置地化分析设备表
        /// </summary>
        /// <returns></returns>
        public DataSet DHFX_XZList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT ROW_NUMBER() OVER(ORDER BY K.SBMC) AS TROW,K.ID AS SBID, K.SBMC,K.CCBH,SBZK,BZ,GGXH ,P.JH FROM LQ_SB_DHFX K ");
            strSql.Append(" LEFT JOIN LQ_SBFP P ON K.ID=P.SBID ");
            strSql.Append(" WHERE K.SBSZWZ='厂区' ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 闲置综合仪（气测）表
        /// </summary>
        /// <returns></returns>
        public DataSet ZHY_XZList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT ROW_NUMBER() OVER(ORDER BY K.SBMC) AS TROW,K.ID AS SBID, K.SBMC,K.CCBH,SBZK,BZ,GGXH ,P.JH FROM LQ_SB_ZHY K ");
            strSql.Append(" LEFT JOIN LQ_SBFP P ON K.ID=P.SBID ");
            strSql.Append(" WHERE K.SBSZWZ='厂区' ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 闲置卫星设备表
        /// </summary>
        /// <returns></returns>
        public DataSet WX_XZList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT ROW_NUMBER() OVER(ORDER BY K.SBMC) AS TROW,K.ID AS SBID, K.SBMC,K.CCBH,SBZK,BZ,GGXH ,P.JH FROM LQ_SB_WX K ");
            strSql.Append(" LEFT JOIN LQ_SBFP P ON K.ID=P.SBID ");
            strSql.Append(" WHERE K.SBSZWZ='厂区' ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 在用车辆
        /// </summary>
        /// <returns></returns>
        public DataSet CL_ZYList(string JH, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT ROW_NUMBER() OVER(ORDER BY K.SBMC DESC) AS TROW,K.ID AS SBID, K.SBMC,K.CCBH,SBZK,BZ,GGXH ,P.JH FROM LQ_SB_CL K ");
            strSql.Append(" LEFT JOIN LQ_SBFP P ON K.ID=P.SBID ");
            strSql.Append(" WHERE P.JH ='" + JH + "' ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());

        }

        /// <summary>
        /// 在用钻时仪
        /// </summary>
        /// <returns></returns>
        public DataSet ZSY_ZYList(string JH, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT ROW_NUMBER() OVER(ORDER BY K.SBMC) AS TROW,K.ID AS SBID, K.SBMC,K.CCBH,SBZK,BZ,GGXH ,P.JH FROM LQ_SB_ZSY K ");
            strSql.Append(" LEFT JOIN LQ_SBFP P ON K.ID=P.SBID ");
            strSql.Append(" WHERE P.JH ='" + JH + "' ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());

        }

        /// <summary>
        /// 在用工程参数仪设备表
        /// </summary>
        /// <returns></returns>
        public DataSet GCCSY_ZYList(string JH, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT ROW_NUMBER() OVER(ORDER BY K.SBMC) AS TROW,K.ID AS SBID, K.SBMC,K.CCBH,SBZK,BZ,GGXH ,P.JH FROM LQ_SB_GCCSY K ");
            strSql.Append(" LEFT JOIN LQ_SBFP P ON K.ID=P.SBID ");
            strSql.Append(" WHERE P.JH ='" + JH + "' ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 在用地化分析设备表
        /// </summary>
        /// <returns></returns>
        public DataSet DHFX_ZYList(string JH, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT ROW_NUMBER() OVER(ORDER BY K.SBMC) AS TROW,K.ID AS SBID, K.SBMC,K.CCBH,SBZK,BZ ,GGXH,P.JH FROM LQ_SB_DHFX K ");
            strSql.Append(" LEFT JOIN LQ_SBFP P ON K.ID=P.SBID ");
            strSql.Append(" WHERE P.JH ='" + JH + "' ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 在用综合仪（气测）表
        /// </summary>
        /// <returns></returns>
        public DataSet ZHY_ZYList(string JH, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT ROW_NUMBER() OVER(ORDER BY K.SBMC) AS TROW,K.ID AS SBID, K.SBMC,K.CCBH,SBZK,BZ,GGXH,P.JH FROM LQ_SB_ZHY K ");
            strSql.Append(" LEFT JOIN LQ_SBFP P ON K.ID=P.SBID ");
            strSql.Append(" WHERE P.JH ='" + JH + "' ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 在用卫星设备表
        /// </summary>
        /// <returns></returns>
        public DataSet WX_ZYList(string JH, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT ROW_NUMBER() OVER(ORDER BY K.SBMC) AS TROW,K.ID AS SBID, K.SBMC,K.CCBH,SBZK,BZ,GGXH,P.JH FROM LQ_SB_WX K ");
            strSql.Append(" LEFT JOIN LQ_SBFP P ON K.ID=P.SBID ");
            strSql.Append(" WHERE P.JH ='" + JH + "' ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 设备分配闲置
        /// </summary>
        /// <param name="RYBH_List"></param>
        /// <param name="FP_List"></param>
        /// <returns></returns>
        public bool SBFPTo_XZ(List<LQ_SBFP> FP_List)
        {
            ArrayList list = new ArrayList();
            string TableName = "";
            for (int i = 0; i < FP_List.Count; i++)
            {
                switch (FP_List[i].SBFL)
                {
                    case "车辆设备":
                        TableName = "LQ_SB_CL";
                        break;
                    case "钻时仪设备":
                        TableName = "LQ_SB_ZSY";
                        break;
                    case "工程参数仪设备":
                        TableName = "LQ_SB_GCCSY";
                        break;
                    case "地化分析设备":
                        TableName = "LQ_SB_DHFX";
                        break;
                    case "综合仪设备":
                        TableName = "LQ_SB_ZHY";
                        break;
                    case "卫星设备":
                        TableName = "LQ_SB_WX";
                        break;
                }

                string Sql = string.Format(@"
UPDATE {0}
SET SBSZWZ='厂区'
WHERE ID='{1}'", TableName, FP_List[i].SBID);

                list.Add(Sql);
            }


            for (int i = 0; i < FP_List.Count; i++)
            {
                string Sql1 = string.Format(@"DELETE FROM LQ_SBFP WHERE JH='{0}' AND SBID='{1}' AND SBFL='{2}' ", FP_List[i].JH, FP_List[i].SBID, FP_List[i].SBFL);

                list.Add(Sql1);
            }

            return DbHelperOra.ExecuteSqlTrans(list);
        }

        /// <summary>
        /// 设备分配在用
        /// </summary>
        /// <param name="FP_List"></param>
        /// <returns></returns>
        public bool SBFPTo_ZY(List<LQ_SBFP> FP_List)
        {
            ArrayList list = new ArrayList();
            string TableName = "";
            for (int i = 0; i < FP_List.Count; i++)
            {
                switch (FP_List[i].SBFL)
                {
                    case "车辆设备":
                        TableName = "LQ_SB_CL";
                        break;
                    case "钻时仪设备":
                        TableName = "LQ_SB_ZSY";
                        break;
                    case "工程参数仪设备":
                        TableName = "LQ_SB_GCCSY";
                        break;
                    case "地化分析设备":
                        TableName = "LQ_SB_DHFX";
                        break;
                    case "综合仪设备":
                        TableName = "LQ_SB_ZHY";
                        break;
                    case "卫星设备":
                        TableName = "LQ_SB_WX";
                        break;
                }

                string Sql = string.Format(@"
UPDATE {0}
SET SBSZWZ='{1}'
WHERE ID='{2}' ", TableName, FP_List[i].JH, FP_List[i].SBID);

                list.Add(Sql);
            }

            for (int i = 0; i < FP_List.Count; i++)
            {
                string Sql1 = string.Format(@"INSERT INTO LQ_SBFP(JH,SBID,SBFL,TJR,TJSJ)VALUES('{0}','{1}','{2}','{3}',SYSDATE)", FP_List[i].JH, FP_List[i].SBID, FP_List[i].SBFL, FP_List[i].TJR);
                list.Add(Sql1);
            }

            return DbHelperOra.ExecuteSqlTrans(list);
        }

        /// <summary>
        /// 设备分配
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public LQ_SBFP SBPFModel(DataRow dr)
        {
            LQ_SBFP model = new LQ_SBFP();
            if (dr["TROW"] != null && dr["TROW"].ToString() != "")
            {
                model.TROW = Convert.ToInt32(dr["TROW"]);
            }

            //if (dr["ID"] != null && dr["ID"].ToString() != "")
            //{
            //	model.ID = dr["ID"].ToString();
            //}

            if (dr["SBMC"] != null && dr["SBMC"].ToString() != "")
            {
                model.SBMC = dr["SBMC"].ToString();
            }

            if (dr["SBID"] != null && dr["SBID"].ToString() != "")
            {
                model.SBID = dr["SBID"].ToString();
            }

            //if (dr["TJR"] != null && dr["TJR"].ToString() != "")
            //{
            //	model.TJR = dr["TJR"].ToString();
            //}

            if (dr["CCBH"] != null && dr["CCBH"].ToString() != "")
            {
                model.CCBH = dr["CCBH"].ToString();
            }

            if (dr["SBZK"] != null && dr["SBZK"].ToString() != "")
            {
                model.SBZK = dr["SBZK"].ToString();
            }

            if (dr["JH"] != null && dr["JH"].ToString() != "")
            {
                model.JH = dr["JH"].ToString();
            }

            if (dr["BZ"] != null && dr["BZ"].ToString() != "")
            {
                model.BZ = dr["BZ"].ToString();
            }

            return model;

        }
        #endregion

        #region	房屋操作模块
        /// <summary>
        /// 闲置房屋列表
        /// </summary>
        /// <returns></returns>
        public DataSet FWXZ_List(string FL)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT ROW_NUMBER() OVER(ORDER BY K.CCBH) AS TROW,K.ID AS FWID,K.CCBH,K.GGXH,K.SBZK,K.BZ,P.JH FROM LQ_FW K ");
            strSql.Append(" LEFT JOIN LQ_FWFP P ON K.ID=P.FWID ");
            strSql.Append(" WHERE K.FL='" + FL + "' AND P.JH IS NULL ");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 在用房屋列表
        /// </summary>
        /// <param name="JH"></param>
        /// <returns></returns>
        public DataSet FWZY_List(string JH, string FL)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT ROW_NUMBER() OVER(ORDER BY K.CCBH) AS TROW,K.ID AS FWID,K.CCBH,K.GGXH,K.SBZK,K.BZ,P.JH FROM LQ_FW K ");
            strSql.Append(" LEFT JOIN LQ_FWFP P ON K.ID=P.FWID ");
            strSql.Append(" WHERE K.FL='" + FL + "' AND P.JH ='" + JH + "' ");
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 房屋分配闲置
        /// </summary>
        /// <param name="RYBH_List"></param>
        /// <param name="FP_List"></param>
        /// <returns></returns>
        public bool FWFPTo_XZ(List<LQ_FWFP> FP_List)
        {
            ArrayList list = new ArrayList();

            for (int i = 0; i < FP_List.Count; i++)
            {
                string Sql = string.Format(@"
UPDATE LQ_FW
SET SBSZWZ='厂区'
WHERE ID='{0}' ", FP_List[i].FWID);

                list.Add(Sql);
            }


            for (int i = 0; i < FP_List.Count; i++)
            {
                string Sql1 = string.Format(@"DELETE FROM LQ_FWFP WHERE JH='{0}' AND FWID='{1}'", FP_List[i].JH, FP_List[i].FWID);

                list.Add(Sql1);
            }

            return DbHelperOra.ExecuteSqlTrans(list);
        }

        /// <summary>
        /// 房屋分配在用
        /// </summary>
        /// <param name="FP_List"></param>
        /// <returns></returns>
        public bool FWFPTo_ZY(List<LQ_FWFP> FP_List)
        {
            ArrayList list = new ArrayList();

            for (int i = 0; i < FP_List.Count; i++)
            {

                string Sql = string.Format(@"
UPDATE LQ_FW
SET SBSZWZ='{0}'
WHERE ID='{1}' ", FP_List[i].JH, FP_List[i].FWID);

                list.Add(Sql);
            }

            for (int i = 0; i < FP_List.Count; i++)
            {
                string Sql1 = string.Format(@"INSERT INTO LQ_FWFP(JH,FWID,TJR,TJRQ)VALUES('{0}','{1}','{2}',SYSDATE)", FP_List[i].JH, FP_List[i].FWID, FP_List[i].TJR);
                list.Add(Sql1);
            }

            return DbHelperOra.ExecuteSqlTrans(list);
        }

        /// <summary>
        /// 房屋分配
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public LQ_FWFP FWPFModel(DataRow dr)
        {
            LQ_FWFP model = new LQ_FWFP();
            if (dr["TROW"] != null && dr["TROW"].ToString() != "")
            {
                model.TROW = Convert.ToInt32(dr["TROW"]);
            }

            if (dr["FWID"] != null && dr["FWID"].ToString() != "")
            {
                model.FWID = dr["FWID"].ToString();
            }

            if (dr["CCBH"] != null && dr["CCBH"].ToString() != "")
            {
                model.CCBH = dr["CCBH"].ToString();
            }

            //if (dr["SBFL"] != null && dr["SBFL"].ToString() != "")
            //{
            //	model.SBFL = dr["SBFL"].ToString();
            //}

            //if (dr["TJR"] != null && dr["TJR"].ToString() != "")
            //{
            //	model.TJR = dr["TJR"].ToString();
            //}

            if (dr["GGXH"] != null && dr["GGXH"].ToString() != "")
            {
                model.GGXH = dr["GGXH"].ToString();
            }

            if (dr["SBZK"] != null && dr["SBZK"].ToString() != "")
            {
                model.SBZK = dr["SBZK"].ToString();
            }

            if (dr["JH"] != null && dr["JH"].ToString() != "")
            {
                model.JH = dr["JH"].ToString();
            }

            if (dr["BZ"] != null && dr["BZ"].ToString() != "")
            {
                model.BZ = dr["BZ"].ToString();
            }

            return model;

        }
        #endregion




        public bool DicAdd(Sys_Dictionary dic)
        {
            string sqlStr = @"
insert into SYS_DICTIONARY(
DICTIONARYID,
CODE,
NAME,
PTYPE,
TYPE, 
ADDEMP,
ADDTIME
)
values(
:DICTIONARYID,
:CODE,
:NAME,
:PTYPE,
:TYPE, 
:ADDEMP,
SYSDATE)";
            OracleParameter[] parameter = {
                                            new OracleParameter(":DICTIONARYID",OracleDbType.Varchar2,50),
                                            new OracleParameter(":CODE",OracleDbType.Varchar2,50),
                                            new OracleParameter(":NAME",OracleDbType.Varchar2,50),
                                            new OracleParameter(":PTYPE",OracleDbType.Varchar2,50),
                                            new OracleParameter(":TYPE",OracleDbType.Varchar2,50),
                                            new OracleParameter(":ADDEMP",OracleDbType.Varchar2,50)
                                        };

            parameter[0].Value = dic.DICTIONARYID;
            parameter[1].Value = dic.CODE;
            parameter[2].Value = dic.NAME;
            parameter[3].Value = dic.PTYPE;
            parameter[4].Value = dic.TYPE;
            parameter[5].Value = dic.ADDEMP;
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


        #region =====设备状态统计
        public DataSet SB_Count(string LJFGS)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"  
SELECT TYPE, COUNT(ID) ZHY
  FROM (SELECT CASE SBSZWZ WHEN '厂区' THEN '待派' ELSE '在用' END
                   AS TYPE,
               ID
          FROM LQ_SB_ZHY
          WHERE SSDW='{0}') DT
          GROUP BY TYPE", LJFGS);
            return DbHelperOra.Query(strSql.ToString());
        }

        public DataSet FW_Count(string LJFGS)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"  
SELECT TYPE,
         SUM (CASE WHEN FL = '地质房' THEN 1 ELSE 0 END) DZF,
         SUM (CASE WHEN FL = '仪器房' THEN 1 ELSE 0 END) YQF,
         SUM (CASE WHEN FL = '住房' THEN 1 ELSE 0 END)  ZF,
         SUM (CASE WHEN FL = '库房' THEN 1 ELSE 0 END)  KF
    FROM (SELECT CASE SBSZWZ WHEN '厂区' THEN '待派' ELSE '在用' END
                     AS TYPE,
                 FL
            FROM LQ_FW
WHERE LJFGS='{0}') T

GROUP BY TYPE", LJFGS);
            return DbHelperOra.Query(strSql.ToString());
        }

        public SB_FW_Count SB_Model(DataRow dr)
        {
            SB_FW_Count model = new SB_FW_Count();
            if (dr["TYPE"] != null && dr["TYPE"].ToString() != "")
            {
                model.TYPE = dr["TYPE"].ToString();
            }
            if (dr["ZHY"] != null && dr["ZHY"].ToString() != "")
            {
                model.ZHY = Convert.ToInt32(dr["ZHY"]);
            }
            return model;
        }


        public SB_FW_Count FW_Model(DataRow dr)
        {
            SB_FW_Count model = new SB_FW_Count();
            if (dr["TYPE"] != null && dr["TYPE"].ToString() != "")
            {
                model.TYPE = dr["TYPE"].ToString();
            }
            if (dr["DZF"] != null && dr["DZF"].ToString() != "")
            {
                model.DZF = Convert.ToInt32(dr["DZF"]);
            }
            if (dr["YQF"] != null && dr["YQF"].ToString() != "")
            {
                model.YQF = Convert.ToInt32(dr["YQF"]);
            }
            if (dr["ZF"] != null && dr["ZF"].ToString() != "")
            {
                model.ZF = Convert.ToInt32(dr["ZF"]);
            }
            if (dr["KF"] != null && dr["KF"].ToString() != "")
            {
                model.KF = Convert.ToInt32(dr["KF"]);
            }
            return model;
        }

        #endregion

        #region 人员状态统计
        public DataSet RY_Count(string LJFGS)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"  
  SELECT TYPE,
         SUM (CASE WHEN GW = '录井地质师' THEN 1 ELSE 0 END) LJDZS,
         SUM (CASE WHEN GW = '录井工程师' THEN 1 ELSE 0 END) LJGCS,
         SUM (CASE WHEN GW = '操作员' THEN 1 ELSE 0 END)  CZY,
         SUM (CASE WHEN GW = '地质工' THEN 1 ELSE 0 END)  DZG,
         SUM (CASE WHEN GW = '实习生' THEN 1 ELSE 0 END)  SXS,
         SUM (CASE WHEN GW = '地质助理' THEN 1 ELSE 0 END)  DZZL,
         SUM (CASE WHEN GW = '开发井地质师' THEN 1 ELSE 0 END)  KFJDZS
    FROM (SELECT CASE RYZT WHEN '待派' THEN '待派' WHEN '在岗' THEN '在岗' END
                     AS TYPE,
                 GW
            FROM LQ_RYSJK
WHERE XMB='{0}') T
GROUP BY TYPE", LJFGS);
            return DbHelperOra.Query(strSql.ToString());
        }

        public RY_Count RY_Model(DataRow dr)
        {
            RY_Count model = new RY_Count();
            if (dr["TYPE"] != null && dr["TYPE"].ToString() != "")
            {
                model.TYPE = dr["TYPE"].ToString();
            }
            if (dr["LJDZS"] != null && dr["LJDZS"].ToString() != "")
            {
                model.LJDZS = Convert.ToInt32(dr["LJDZS"]);
            }
            if (dr["LJGCS"] != null && dr["LJGCS"].ToString() != "")
            {
                model.LJGCS = Convert.ToInt32(dr["LJGCS"]);
            }
            if (dr["CZY"] != null && dr["CZY"].ToString() != "")
            {
                model.CZY = Convert.ToInt32(dr["CZY"]);
            }
            if (dr["DZG"] != null && dr["DZG"].ToString() != "")
            {
                model.DZG = Convert.ToInt32(dr["DZG"]);
            }
            if (dr["SXS"] != null && dr["SXS"].ToString() != "")
            {
                model.SXS = Convert.ToInt32(dr["SXS"]);
            }
            if (dr["DZZL"] != null && dr["DZZL"].ToString() != "")
            {
                model.DZZL = Convert.ToInt32(dr["DZZL"]);
            }
            if (dr["KFJDZS"] != null && dr["KFJDZS"].ToString() != "")
            {
                model.KFJDZS = Convert.ToInt32(dr["KFJDZS"]);
            }
            return model;
        }
        #endregion
    }
}
