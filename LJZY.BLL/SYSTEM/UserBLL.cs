using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJZY.MODEL;
using System.Data;
using LJZY.DAO.SYSTEM;
namespace LJZY.BLL.SYSTEM
{
    public class UserBLL
    {
        private readonly DAO.SYSTEM.UserDAO dal;
        public UserBLL()
        {
            dal = new DAO.SYSTEM.UserDAO();
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        public DataSet LoginCheck(string userName, string Pwd,string dtName)
        {
            return dal.LoginCheck(userName, Pwd,dtName);
        }
        public Sys_User GetModel(string USERNAME, string dtName)
        {
            string strSql = string.Format(" AND USERNAME='{0}'", USERNAME);
            return dal.GetModel(strSql, dtName);
        }

        //public bool Add(Sys_User user, string dtName)
        //{ 
        //    user.PASSWORD = "123";
        //    user.STATUS = "0";
        //    user.ADDTIME = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //    user.ADDEMP = "admin"; 
        //    return dal.Add(user, dtName);
        //}
    }
}
