using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJZY.MODEL;
using LJZY.DBUtility;
using Oracle.DataAccess.Client;
using System.Data;

namespace LJZY.DAO.SYSTEM
{
    public class UserDAO
    {

        /// <summary>
        /// 登录验证信息
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        public DataSet LoginCheck(string userName, string Pwd, string dtName)
        {
            string strSql = @"SELECT * FROM " + dtName + @" WHERE USERNAME='{0}' AND USERPASS='{1}'";
            strSql = string.Format(strSql, userName, Pwd);
            return DbHelperOra.Query(strSql);
        }
        public Sys_User GetModel(string where, string dtName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT *   FROM " + dtName + @" where 1=1  " + where);

            DataSet ds = DbHelperOra.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

       // public bool Add(Sys_User user, string dtName)
       // {
       //     string sqlStr = @"INSERT INTO " + dtName + @"(EMPLOYEENO, PASSWORD, STATUS, ADDTIME, ADDEMP)
							//VALUES(:EMPLOYEENO, :PASSWORD, :STATUS, :ADDTIME, :ADDEMP)";
       //     OracleParameter[] parameter = {
       //                                     new OracleParameter(":EMPLOYEENO",OracleDbType.Varchar2,50),
       //                                     new OracleParameter(":PASSWORD",OracleDbType.Varchar2,50),
       //                                     new OracleParameter(":STATUS",OracleDbType.Varchar2,50),
       //                                     new OracleParameter(":ADDTIME",OracleDbType.Varchar2,50),
       //                                     new OracleParameter(":ADDEMP",OracleDbType.Varchar2,50)
       //                                 };
       //     parameter[0].Value = user.EMPLOYEENO;
       //     parameter[1].Value = user.PASSWORD;
       //     parameter[2].Value = user.STATUS;
       //     parameter[3].Value = user.ADDTIME;
       //     parameter[4].Value = user.ADDEMP;
       //     int rows = DbHelperOra.ExecuteSql(sqlStr, parameter);
       //     if (rows > 0)
       //     {
       //         return true;
       //     }
       //     else
       //     {
       //         return false;
       //     }
       // }

        #region-------扩展方法--------------
        public Sys_User DataRowToModel(DataRow row)
        {
            Sys_User model = new Sys_User();
            if (row != null)
            {
                if (row["USERNAME"] != null && row["USERNAME"].ToString() != "")
                {
                    model.USERNAME = row["USERNAME"].ToString();
                }
                if (row["REALNAME"] != null && row["REALNAME"].ToString() != "")
                {
                    model.REALNAME = row["REALNAME"].ToString();
                }
                if (row["USERPASS"] != null && row["REALNAME"].ToString() != "")
                {
                    model.USERPASS = row["USERPASS"].ToString();
                }
                 
            }
            return model;
        }
        #endregion

    }
}
