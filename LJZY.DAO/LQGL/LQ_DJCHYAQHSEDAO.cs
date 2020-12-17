using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LJZY.MODEL;
using Oracle.DataAccess.Client;
using LJZY.DBUtility;
using System.Data;
using LJZY.COMMON;

namespace LJZY.DAO.LQGL
{
   public class LQ_DJCHYAQHSEDAO
    {
        /// <summary>
        /// 单井策划 应急预案 QSHE作业计划书添加
        /// </summary>
        /// <param name="DJCHYAQHSE"></param>
        /// <returns></returns>
        public bool Add(LQ_DJCHYAQHSE DJCHYAQHSE)
        {
            string sqlStr = string.Format(@"
insert into LQ_DJCHYAQHSE(ZJH,XH,FL,
SC3,
JH, 
JX, 
REPORT_TYPE, 
SC2, 
QK, 
LJFGS, 
BZR, 
BZRQ, 
TJR, 
TJSJ, 
BZ)
values
 ('{0}',
'{1}',
'{2}',
'{3}',
'{4}', 
'{5}', 
'{6}', 
'{7}', 
'{8}', 
'{9}', 
'{10}', 
to_date('{11}','yyyy_MM_dd'), 
'{12}', 
SYSDATE, 
'{13}')", DJCHYAQHSE.ZJH, DJCHYAQHSE.XH, DJCHYAQHSE.FL, DJCHYAQHSE.SC3, DJCHYAQHSE.JH, DJCHYAQHSE.JX, DJCHYAQHSE.REPORT_TYPE, DJCHYAQHSE.SC2, DJCHYAQHSE.QK, DJCHYAQHSE.LJFGS, DJCHYAQHSE.BZR, DJCHYAQHSE.BZRQ_DG, DJCHYAQHSE.TJR, DJCHYAQHSE.BZ);

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
        /// 修改
        /// </summary>
        /// <param name="DJCHYAQHSE"></param>
        /// <returns></returns>
        public bool Update(LQ_DJCHYAQHSE DJCHYAQHSE,string type)
        {
            string sqlStr = string.Format(@"
Update LQ_DJCHYAQHSE Set 
ZJH='{0}'
SC3='{1}',
JH='{2}', 
JX='{3}', 
REPORT_TYPE='{4}', 
SC2='{5}', 
QK='{6}', 
LJFGS='{7}', 
BZR='{8}', 
BZRQ=to_date('{9}','yyyy_MM_dd'),
BZ='{10}' WHERE ID='{11}' AND FL=:'"+type+"'", DJCHYAQHSE.ZJH, DJCHYAQHSE.SC3, DJCHYAQHSE.JH, DJCHYAQHSE.JX, DJCHYAQHSE.REPORT_TYPE, DJCHYAQHSE.SC2, DJCHYAQHSE.QK, DJCHYAQHSE.LJFGS, DJCHYAQHSE.BZR, DJCHYAQHSE.BZRQ_DG, DJCHYAQHSE.BZ, DJCHYAQHSE.ID,type);

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
        /// 删除
        /// </summary>
        /// <param name="ZJH"></param>
        /// <param name="FL"></param>
        /// <returns></returns>
        public bool Del(string ZJH,string FL)
        {
            try
            {
                string sqlStr = @" delete from  LQ_DJCHYAQHSE   WHERE ZJH=:ZJH AND FL=:FL ";
                OracleParameter[] parameter = {
                                            new OracleParameter(":ZJH",OracleDbType.Varchar2,10),
                                             new OracleParameter(":FL",OracleDbType.Varchar2,10)
                                          };
                parameter[0].Value = ZJH;
                parameter[1].Value = FL;
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


        /// 获取二级菜单字段分类
        /// <summary>
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public string Ptype(string Name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT PTYPE FROM SYS_DICTIONARY");
            strSql.Append(" WHERE 1=1 AND NAME='" + Name + "'");

            object result = DbHelperOra.GetSingle(strSql.ToString());
            if (result == null)
            {
                return "";
            }
            return result.ToString();
        }

        public DataSet DJCHYAQSHE_strWhere(string type,string strWhere, int pageSize, int pageIndex, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ROW_NUMBER() OVER(ORDER BY TJSJ DESC) AS TROW,d.* from LQ_DJCHYAQHSE d WHERE FL='"+type+"'");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperOra.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperOra.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
            //return DbHelperOra.Query(strSql.ToString());
        }

        public LQ_DJCHYAQHSE DJCHYAQHSEModel(DataRow dr)
        {
            LQ_DJCHYAQHSE model = new LQ_DJCHYAQHSE();
            if (dr["ZJH"] != null && dr["ZJH"].ToString() != "")
            {
                model.ZJH = dr["ZJH"].ToString();
            }

            if (dr["XH"] != null && dr["XH"].ToString() != "")
            {
                model.XH = Convert.ToInt32(dr["XH"]);
            }

            if (dr["FL"] != null && dr["FL"].ToString() != "")
            {
                model.FL = dr["FL"].ToString();
            }

            if (dr["SC3"] != null && dr["SC3"].ToString() != "")
            {
                model.SC3 = dr["SC3"].ToString();
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

            if (dr["SC2"] != null && dr["SC2"].ToString() != "")
            {
                model.SC2 = dr["SC2"].ToString();
            }

            if (dr["QK"] != null && dr["QK"].ToString() != "")
            {
                model.QK = dr["QK"].ToString();
            }

            if (dr["LJFGS"] != null && dr["LJFGS"].ToString() != "")
            {
                model.LJFGS = dr["LJFGS"].ToString();
            }

            if (dr["BZR"] != null && dr["BZR"].ToString() != "")
            {
                model.BZR = dr["BZR"].ToString();
            }

            if (dr["BZRQ"] != null && dr["BZRQ"].ToString() != "")
            {
                model.BZRQ =Convert.ToDateTime(dr["BZRQ"]);
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

            return model;

        }

        public int CheckDJCHYAHSE(string str,string type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(*) from LQ_DJCHYAQHSE WHERE  ID='" + str + "' AND  FL='"+type+"'");

            object result = DbHelperOra.GetSingle(strSql.ToString());
            if (result == null)
            {
                return 0;
            }
            return Convert.ToInt32(result);

        }


    }
}
