using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.MODEL
{
   public class Sys_Menu
    {
        private string _MENUID;

        public string MENUID
        {
            get { return _MENUID; }
            set { _MENUID = value; }
        }
        private string _NAME;

        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }
        private string _CODE;

        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }
        private string _PID;

        public string PID
        {
            get { return _PID; }
            set { _PID = value; }
        }
        private string _ADDTIME;

        public string ADDTIME
        {
            get { return _ADDTIME; }
            set { _ADDTIME = value; }
        }
        private string _ADDEMP;

        public string ADDEMP
        {
            get { return _ADDEMP; }
            set { _ADDEMP = value; }
        }
        private string _REMARK;

        public string REMARK
        {
            get { return _REMARK; }
            set { _REMARK = value; }
        }
        private string _ISLINK;

        public string ISLINK
        {
            get { return _ISLINK; }
            set { _ISLINK = value; }
        }
        private string _ADDRESS;

        public string ADDRESS
        {
            get { return _ADDRESS; }
            set { _ADDRESS = value; }
        }

        private List<Sys_Menu> _itermList;
        /// <summary>
        /// 子集合
        /// </summary>
        [DisplayName("ItermList")]
        public List<Sys_Menu> ItermList
        {
            get { return _itermList; }
            set { _itermList = value; }
        }
    }
}
