using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LJZY.MODEL
{
    public class Sys_User
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Sys_User()
        {
 
        }
        //private string _USERID;
        ///// <summary>
        ///// 用户id
        ///// </summary>
        //[DisplayName("USERID")]
        //public string USERID
        //{
        //    get { return _USERID; }
        //    set { _USERID = value; }
        //}
        private string _USERNAME;
        /// <summary>
        /// 登录用户名
        /// </summary>
        [DisplayName("USERNAME")]
        public string USERNAME
        {
            get { return _USERNAME; }
            set { _USERNAME = value; }
        }
        private string _USERPASS;
        /// <summary>
        /// 登录密码
        /// </summary>
        [DisplayName("USERPASS")]
        public string USERPASS
        {
            get { return _USERPASS; }
            set { _USERPASS = value; }
        }

        private string _REALNAME;
        /// <summary>
        /// 真实姓名
        /// </summary>
        [DisplayName("REALNAME")]
        public string REALNAME
        {
            get { return _REALNAME; }
            set { _REALNAME = value; }
        }

        //private string _STATUS;
        ///// <summary>
        ///// 状态
        ///// </summary>
        //[DisplayName("STATUS")]
        //public string STATUS
        //{
        //    get { return _STATUS; }
        //    set { _STATUS = value; }
        //}
        //private string _ADDTIME;
        ///// <summary>
        ///// 添加时间
        ///// </summary>
        //[DisplayName("ADDTIME")]
        //public string ADDTIME
        //{
        //    get { return _ADDTIME; }
        //    set { _ADDTIME = value; }
        //}
        //private string _ADDEMP;
        ///// <summary>
        ///// 添加人
        ///// </summary>
        //[DisplayName("ADDEMP")]
        //public string ADDEMP
        //{
        //    get { return _ADDEMP; }
        //    set { _ADDEMP = value; }
        //}
        //private string _REMARK;
        ///// <summary>
        ///// 备注
        ///// </summary>
        //[DisplayName("REMARK")]
        //public string REMARK
        //{
        //    get { return _REMARK; }
        //    set { _REMARK = value; }
        //}


    }
}
