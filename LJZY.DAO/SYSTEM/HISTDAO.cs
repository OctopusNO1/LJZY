using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using LJZY.MODEL;
using System.Data.OleDb;
using Oracle.DataAccess.Client;
using LJZY.DBUtility;
using System.Data;

namespace LJZY.DAO.SYSTEM
{
    public class HISTDAO
    {
        
        public bool Add(Sys_Hostroy hist)
        {

            string sqlStr = @"insert into SYS_HISTORY (ID,TITLE,URL,USER_ID,ADDTIME)
            values(:ID, :TITLE, :URL, :USER_ID, :ADDTIME)";
            OracleParameter[] parameter = {
                                            new OracleParameter(":ID",OracleDbType.Varchar2,50),
                                            new OracleParameter(":TITLE",OracleDbType.Varchar2,100),
                                            new OracleParameter(":URL",OracleDbType.Varchar2,100),
                                            new OracleParameter(":USER_ID",OracleDbType.Varchar2,50),
                                            new OracleParameter(":ADDTIME",OracleDbType.Date)
                                           
                                        };
            parameter[0].Value = hist.ID;
            parameter[1].Value = hist.TITLE;
            parameter[2].Value = hist.URL;
            parameter[3].Value = hist.USER_ID;
            parameter[4].Value = hist.ADDTIME;
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

        public bool Delete(string str)
        {
            string sql = "delete from  SYS_HISTORY";
            if (str.Trim()!="")
            {
                sql+=(" WHERE 1=1" + str);
            }
            int rows = DbHelperOra.ExecuteSql(sql);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Sys_Hostroy> GetList( string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SYS_HISTORY ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1" + strWhere);
            }
            strSql.Append(" order by ADDTIME DESC ");
             DataSet dt=DbHelperOra.Query(strSql.ToString());
            List<Sys_Hostroy> List = new List<Sys_Hostroy>();
            if (dt.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Tables[0].Rows)
                {
                    List.Add(DataRowToModel(dr));
                }
            }
            return List;

        }

        #region-------扩展方法--------------
        public Sys_Hostroy DataRowToModel(DataRow row)
        {
            Sys_Hostroy model = new Sys_Hostroy();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = row["ID"].ToString();
                }
                if (row["TITLE"] != null && row["TITLE"].ToString() != "")
                {
                    model.TITLE = row["TITLE"].ToString();
                }
                if (row["URL"] != null && row["URL"].ToString() != "")
                {
                    model.URL = row["URL"].ToString();
                }
                if (row["USER_ID"] != null && row["USER_ID"].ToString() != "")
                {
                    model.USER_ID = row["USER_ID"].ToString();
                }
                if (row["ADDTIME"] != null)
                {
                    model.ADDTIME = Convert.ToDateTime(row["ADDTIME"]);
                }           
                
            }
            return model;
        }

        #endregion


        /// <summary>
        /// 获取登录人最后一条浏览的页面地址
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<Sys_Hostroy> GetUserLastHistory(string uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT * FROM(SELECT * FROM SYS_HISTORY WHERE USER_ID='" + uid + "'  ORDER  BY ADDTIME DESC ) WHERE ROWNUM=1");
            DataSet dt = DbHelperOra.Query(strSql.ToString());
            List<Sys_Hostroy> List = new List<Sys_Hostroy>();
            if (dt.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Tables[0].Rows)
                {
                    List.Add(DataRowToModel(dr));
                }
            }
            return List;

        }

        /// <summary>
        /// 判断当前用户是否有浏览记录
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int CheckHistoryIsHave(string uid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(*) from SYS_HISTORY WHERE  USER_ID='" + uid + "'");

            object result = DbHelperOra.GetSingle(strSql.ToString());
            if (result == null)
            {
                return 0;
            }
            return Convert.ToInt32(result);

        }
    }
}
