using LJZY.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LJZY.MODEL;
using Oracle.DataAccess.Client;

namespace LJZY.DAO.SYSTEM
{
	public class MenuDAO
	{
		public DataSet SYS_MenuList(string str)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select * from SYS_MENU");
			if (str.Trim() != "")
			{
				strSql.Append(" WHERE 1=1 " + str);
			}

			return DbHelperOra.Query(strSql.ToString());
		}



        /// <summary>
        /// 获取用户菜单数据
        /// </summary>
        /// <returns></returns>
        public DataSet GetRoleMenu(Sys_User model,string str)
        {
            StringBuilder strSql = new StringBuilder();
           strSql.Append( @"SELECT DISTINCT B.* FROM REF_ROLEMENUBTN A
                            JOIN SYS_MENU B ON A.MENUID=B.MENUID
                            WHERE  ROLEID  IN (SELECT ROLEID FROM SYS_ROLEUSER WHERE USERID='"+model.USERNAME+"')");
            if (str.Trim()!="")
            {
                strSql.Append(str);
            }
         
            return DbHelperOra.Query(strSql.ToString());
        }





        public Sys_Menu MenuModel(DataRow dr)
		{
			Sys_Menu model = new Sys_Menu();
			if (dr["MENUID"] != null && dr["MENUID"].ToString() != "")
			{
				model.MENUID = dr["MENUID"].ToString();
			}

			if (dr["NAME"] != null && dr["NAME"].ToString() != "")
			{
				model.NAME = dr["NAME"].ToString();
			}

			if (dr["CODE"] != null && dr["CODE"].ToString() != "")
			{
				model.CODE = dr["CODE"].ToString();
			}

			if (dr["PID"] != null && dr["PID"].ToString() != "")
			{
				model.PID = dr["PID"].ToString();
			}

			if (dr["ADDTIME"] != null && dr["ADDTIME"].ToString() != "")
			{
				model.ADDTIME = dr["ADDTIME"].ToString();
			}

			if (dr["ADDEMP"] != null && dr["ADDEMP"].ToString() != "")
			{
				model.ADDEMP = dr["ADDEMP"].ToString();
			}

			if (dr["REMARK"] != null && dr["REMARK"].ToString() != "")
			{
				model.REMARK = dr["REMARK"].ToString();
			}

			if (dr["ISLINK"] != null && dr["ISLINK"].ToString() != "")
			{
				model.ISLINK = dr["ISLINK"].ToString();
			}

			if (dr["ADDRESS"] != null && dr["ADDRESS"].ToString() != "")
			{
				model.ADDRESS = dr["ADDRESS"].ToString();
			}
			return model;

		}

	}
}
